using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.Email;
using System.Net;

namespace BrainstormSessions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                            .WriteTo.File("log.txt")
                            .WriteTo.Email(new EmailConnectionInfo
                            {
                                FromEmail = "aliya.alimbayeva@gmail.com",
                                ToEmail = "alimbayeva.ali@gmail.com",
                                MailServer = "smtp.gmail.com",
                                NetworkCredentials = new NetworkCredential("aliya.alimbayeva@gmail.com", "password"),
                                EnableSsl = true
                            })
                            .CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                 webBuilder.UseStartup<Startup>();
            });
    }
}
