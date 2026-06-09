# OpenDownloader

**OpenDownloader** is a free and open-source video downloader for Windows.  

![Logo OpenDownloader](https://github.com/FBW81C/OpenDownloader/blob/main/OpenDownloader/Assets/logo/Logo.png)

[![Release Version Badge](https://img.shields.io/github/v/release/FBW81C/OpenDownloader)](https://github.com/FBW81C/OpenDownloader/releases)
[![Downloads@latest](https://img.shields.io/github/downloads/FBW81C/OpenDownloader/latest/total)](https://github.com/FBW81C/OpenDownloader/releases/latest)
[![Total Downloads](https://img.shields.io/github/downloads/FBW81C/OpenDownloader/total)](https://github.com/FBW81C/OpenDownloader/releases)

## Overview

OpenDownloader allows you to download videos from popular website like YouTube.
All functionality runs **locally and without telemetry**.

## Core Features
- Video Download with Thumbnail preview (via URL)
- Mode (Video & Audio, Video, Audio)
- Format (Best, Worst, Specific)
- Parallel downloads (multiple video downloads at the same time)
- History (get informed if video was already downloaded)
- Post download actions
  - Always navigate to file
  - Navigate on notification click
  - Open file
  - Do nothing
- Auto-removal of items after download
  - Always
  - On success
  - Never
- Notifications if download complete
- Estimated filesize and download durations
- Real time logging (log window or save to file)

## Dependencies
- **.NET 8 (Core)**, you need to install it manually.
- yt-dlp [https://github.com/yt-dlp/yt-dlp](https://github.com/yt-dlp/yt-dlp)
- ffmpeg [https://ffmpeg.org/](https://ffmpeg.org/)

## Installer
You can compile the installer yourself if you want to.
There are different types of installers:
- Normal installer
- No dependency installer: yt-dlp and ffmpeg aren't included in this installer.

## Platform
- Windows x64

## Possible future features
- **YT Playlist support**: Currently playlists are blocked.
- **Link-Collector**: Upload a .txt file or enter links line by line to add multiple links at once.
- **Bulk-Download**: Button for downloading all added links at once.
- **Updater**: Get notified if a new version of OpenDownloader is available

## License
- see LICENSE.txt
- see Assets/yt-dlp_license.txt for yt-dlp license
- see Assets/ffmpeg_license.txt for ffmpeg license

## Links
- GitHub: https://github.com/FBW81C/OpenDownloader

Free Software, Hell Yeah!
