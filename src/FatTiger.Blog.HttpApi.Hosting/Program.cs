using System.Threading.Tasks;
using FatTiger.Blog.ToolKits.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace FatTiger.Blog.HttpApi.Hosting
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder(args)
                .UseLog4Net()
                .ConfigureWebHostDefaults(builder =>
                {
                    builder.UseIISIntegration()
                    .UseStartup<Startup>();
                }).UseAutofac().Build().RunAsync();

        }
    }
}
