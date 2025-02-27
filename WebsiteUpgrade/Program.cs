namespace WebsiteUpgrade;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();
        builder.Services.AddReverseProxy()
        .LoadFromConfig(builder.Configuration.GetSection("YARP"));

        var app = builder.Build();

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();
        app.MapRazorPages();

        app.MapReverseProxy();

        app.Run();
    }
}
