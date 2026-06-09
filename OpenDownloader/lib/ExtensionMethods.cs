using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenDownloader.model.Text;

namespace OpenDownloader.lib;
public static class ExtensionMethods
{
    public static void AppendRichText(this RichTextBox box, RichText item)
    {
        var color = item.Type switch
        {
            TextType.Normal => Color.Black,
            TextType.Warning => Color.Orange,
            TextType.Error => Color.Red,
            _ => Color.Black
        };

        box.SelectionStart = box.TextLength;
        box.SelectionLength = 0;
        box.SelectionColor = color;
        box.AppendText($"[{item.Sender}]: ");
        box.SelectionColor = box.ForeColor;
        box.AppendText(item.Text + Environment.NewLine);
    }
}
