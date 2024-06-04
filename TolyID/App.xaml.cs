#if ANDROID
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif

using TolyID.MVVM.Views;

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

        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());


#endif
        });


        Microsoft.Maui.Handlers.EditorHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());


#endif
        });

        MainPage = new AppShell();
        //MainPage = new CadastroCapturaTabbedView();
    }
}
