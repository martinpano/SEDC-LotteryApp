using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Data.Model.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<LotteryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LotteryContext context)
        {
            var codes = new List<Code>
            {
                new Code
                {
                    CodeValue = "CC8940",
                    IsWinning = true
                },
                new Code
                {
                    CodeValue = "CC8941",
                    IsWinning = false
                },
                new Code
                {
                    CodeValue = "CC8942",
                    IsWinning = false
                },
                new Code
                {
                    CodeValue = "CC8943",
                    IsWinning = true
                }
            };
            context.Codes.AddRange(codes);

            var awards = new List<Award>
            {
                new Award
                {
                    AwardName = "Beer",
                    AwardDescription = "You won a beer",
                    Quantity = 100,
                    RaffledType = (byte) RaffledType.Immediate
                },
                new Award
                {
                    AwardName = "iPhoneX",
                    AwardDescription = "You won an iPhoneX",
                    Quantity = 2,
                    RaffledType = (byte) RaffledType.Immediate
                },
                new Award
                {
                    AwardName = "WV Polo",
                    AwardDescription = "You won a Polo",
                    Quantity = 1,
                    RaffledType = (byte) RaffledType.Final
                },
            };

            context.Awards.AddRange(awards);

            context.SaveChanges();
        }
    }
}
