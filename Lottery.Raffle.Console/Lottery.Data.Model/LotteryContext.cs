using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lottery.Data.Model
{
   public class LotteryContext : DbContext
    {
        private readonly IConfigurationRoot _configuration;

        public LotteryContext(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }
        public DbSet<Code> Codes { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<UserCode> UserCodes { get; set; }
        public DbSet<UserCodeAward> UserCodeAwards { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("LotteryDatabase"));
        }
    }
}
