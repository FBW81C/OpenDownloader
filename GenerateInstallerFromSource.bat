@echo off
setlocal enabledelayedexpansion

:: ===== CONFIGURATION =====
set PROJECT_DIR=%~dp0
set CSPROJ_FILE=%PROJECT_DIR%OpenDownloader\OpenDownloader.csproj
set ISS_FILE=%PROJECT_DIR%OpenDownloader.iss
set ISS_FILE_NODEPENDENCIES=%PROJECT_DIR%OpenDownloader_nodependencies.iss
set INSTALLER_OUTPUT_DIR=%PROJECT_DIR%Installers
set INNO_SETUP_PATH="C:\Program Files (x86)\Inno Setup 6\ISCC.exe"

:: ===== GET CURRENT VERSION FROM CSPROJ =====
for /f "usebackq delims=" %%A in (`powershell -NoProfile -Command "[xml]$p=Get-Content '%CSPROJ_FILE%'; $p.Project.PropertyGroup.InformationalVersion"`) do set VERSION=%%A

echo Current version: %VERSION%
set /p NEW_VERSION=Enter new version (leave blank to keep current):

if not "%NEW_VERSION%"=="" (
    set VERSION=%NEW_VERSION%
    echo Updating version in .csproj to %NEW_VERSION%...

    powershell -NoProfile -Command "[xml]$p=Get-Content '%CSPROJ_FILE%'; $p.Project.PropertyGroup.InformationalVersion='%NEW_VERSION%'; $p.Save('%CSPROJ_FILE%')"
)

:: ===== BUILD .NET APP =====
echo.
echo Building OpenDownloader v%VERSION%...
dotnet publish "%PROJECT_DIR%OpenDownloader" -c Release -r win-x64 --self-contained false -p:PublishSingleFile=true
if errorlevel 1 (
    echo ERROR: dotnet publish failed.
    pause
    exit /b 1
)

:: ===== CREATE OUTPUT DIR =====
if not exist "%INSTALLER_OUTPUT_DIR%" mkdir "%INSTALLER_OUTPUT_DIR%"

:: ===== COMPILE INSTALLER =====
echo.
echo Compiling installer...
%INNO_SETUP_PATH% "%ISS_FILE%"
if errorlevel 1 (
    echo ERROR: Inno Setup compilation failed.
    pause
    exit /b 1
)

:: ===== MOVE INSTALLER TO Installers FOLDER =====
if exist "%PROJECT_DIR%Output\OpenDownloaderInstaller.exe" (
    move /Y "%PROJECT_DIR%Output\OpenDownloaderInstaller.exe" "%INSTALLER_OUTPUT_DIR%\OpenDownloaderInstaller_v%VERSION%.exe"
	echo.
    echo Installer saved to: %INSTALLER_OUTPUT_DIR%\OpenDownloaderInstaller_v%VERSION%.exe
) else (
    echo ERROR: Could not find generated installer file.
)

:: ===== COMPILE INSTALLER NO DEPENDENCIES =====
echo.
echo Compiling installer no depedencies...
%INNO_SETUP_PATH% "%ISS_FILE_NODEPENDENCIES%"
if errorlevel 1 (
    echo ERROR: Inno Setup compilation failed.
    pause
    exit /b 1
)

:: ===== MOVE INSTALLER NO DEPENDENCIES TO Installers FOLDER =====
if exist "%PROJECT_DIR%Output\OpenDownloaderInstaller_nodependencies.exe" (
    move /Y "%PROJECT_DIR%Output\OpenDownloaderInstaller_nodependencies.exe" "%INSTALLER_OUTPUT_DIR%\OpenDownloaderInstaller_v%VERSION%_nodependencies.exe"
	echo.
    echo Installer saved to: %INSTALLER_OUTPUT_DIR%\OpenDownloaderInstaller_v%VERSION%_nodependencies.exe
) else (
    echo ERROR: Could not find generated installer file.
)

:: ===== CLEANING UP =====
echo.
echo Cleaning up...
rd /s /q "%PROJECT_DIR%Output"

:: ===== DONE =====
echo.
echo Done!
pause