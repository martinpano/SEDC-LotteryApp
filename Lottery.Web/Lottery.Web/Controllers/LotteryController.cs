using Lottery.Service;
using Lottery.View.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lottery.Web.Controllers
{
    public class LotteryController : ApiController
    {
        private ILotteryManager _lotteryManager;

        public LotteryController(ILotteryManager lotteryManager)
        {
            _lotteryManager = lotteryManager;
        }


        [HttpPost]
        public AwardModel SubmitCode([FromBody] UserCodeModel userCodeModel)
        {
            return _lotteryManager.CheckCode(userCodeModel);
        }
    }
}
