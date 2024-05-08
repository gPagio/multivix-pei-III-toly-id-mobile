#if ANDROID
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif

namespace TolyID;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // REMOVE SUBLINHADO DE 'ENTRY'
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
#endif
        });


        MainPage = new AppShell();
    }
}
