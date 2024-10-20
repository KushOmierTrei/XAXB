namespace CoreMVC002;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // 在容器中新增服務.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // 配置HTTP請求管道.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        //
        app.MapControllerRoute(
            name: "GuessNumber",
            pattern: "GuessNumber",
            defaults: new { controller = "Game", action = "Index" });
        //
        app.Run();
    }
}
