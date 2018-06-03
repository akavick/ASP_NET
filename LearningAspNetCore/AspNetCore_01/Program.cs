using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;





namespace AspNetCore_01
{

    public class Program
    {
        public static void Main(string[] args)
        {
            //using (var host = WebHost.Start("http://localhost:8080", async context =>
            //{
            //    context.Response.ContentType = "text/html; charset=utf-8";
            //    await context.Response.WriteAsync("Привет мир!");
            //}))
            //{
            //    host.WaitForShutdown();
            //}


            //var host = new WebHostBuilder()
            //           .UseKestrel()               // настраиваем веб-сервер Kestrel 
            //           .UseContentRoot(Directory.GetCurrentDirectory())    // настраиваем корневой каталог приложения
            //           .UseIISIntegration()        // обеспечиваем интеграцию с IIS
            //           .UseStartup<Startup>()    // устанавливаем главный файл приложения
            //           .Build();                   // создаем хост
            //host.Run();


            CreateWebHostBuilder(args).Build()
                                      .Run();
        }





        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var builder = WebHost.CreateDefaultBuilder(args)
                                 .UseStartup<Startup>();

            return builder;
        }
    }

}
