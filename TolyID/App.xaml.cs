#if ANDROID
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif

namespace TolyID;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // REMOVE SUBLINHADO DE 'Entry'
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
#endif
        });

        // REMOVE SUBLINHADO DE 'Editor'
        Microsoft.Maui.Handlers.EditorHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
        {
#if ANDROID
                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
#endif
        });

        // REMOVE SUBLINHADO DE 'DatePicker'
        Microsoft.Maui.Handlers.DatePickerHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
        {
#if ANDROID
                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
#endif
        });

        // REMOVE SUBLINHADO DE 'TimePicker'
        Microsoft.Maui.Handlers.TimePickerHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
        {
#if ANDROID
                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
#endif
        });

        MainPage = new AppShell();
    }
}
