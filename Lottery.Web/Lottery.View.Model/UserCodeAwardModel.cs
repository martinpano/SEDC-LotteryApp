using Lottery.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.View.Model
{
    public class UserCodeAwardModel
    {
        public UserCodeAwardModel()
        {
            UserCode = new UserCodeModel();
            Award = new AwardModel();
        }

        public UserCodeModel UserCode { get; set; }

        public AwardModel Award { get; set; }

        public DateTime WonAt { get; set; }
    }
}
