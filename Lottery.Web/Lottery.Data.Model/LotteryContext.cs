using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Data.Model
{
    public class LotteryContext : DbContext
    {
        public LotteryContext() : base("LotteryDb")
        {
        }

        public virtual DbSet<Code> Codes { get; set; }

        public virtual DbSet<UserCode> UserCodes { get; set; }

        public virtual DbSet<Award> Awards { get; set; }

        public virtual DbSet<UserCodeAward> UserCodeAwards { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
