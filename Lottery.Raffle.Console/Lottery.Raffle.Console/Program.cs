using Lottery.Data;
using Lottery.Data.Model;
using Lottery.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Lottery.Raffle.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = Configure();

            var lotteryManager = serviceProvider.GetService<ILotteryManager>();
            var configuration = serviceProvider.GetService<IConfigurationRoot>();

            var finalRuffle = DateTime.Parse(configuration.GetSection("FinalRaffle").Value);

            if(DateTime.Now.Date <= finalRuffle)
            {
                lotteryManager.GiveAwards(RaffledType.PerDay);
            }

            if(DateTime.Now.Date == finalRuffle)
            {
                lotteryManager.GiveAwards(RaffledType.Final);
            }
        }

        static IServiceProvider Configure()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json",optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var serviceProvider = new ServiceCollection()
                .AddSingleton(provider => configuration)
                .AddSingleton<DbContext, LotteryContext>()
                .AddSingleton<ILotteryManager, LotteryManager>()
                .AddSingleton(typeof(IRepository<>), typeof(Repository<>))
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
