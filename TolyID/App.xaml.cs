#if ANDROID
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif

using TolyID.Services;

namespace TolyID;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        //if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tatu.db3")))
        //{
        //    File.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tatu.db3"));
        //}

        MainPage = new AppShell();
    }
}
