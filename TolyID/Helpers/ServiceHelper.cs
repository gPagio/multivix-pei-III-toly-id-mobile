namespace TolyID.Helpers;

public static class ServiceHelper
{
    public static T GetService<T>() =>
        (T)Application.Current!.Handler.MauiContext!.Services.GetService(typeof(T))!;
}
