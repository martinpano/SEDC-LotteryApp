using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottery.Data;
using Lottery.Data.Model;
using Lottery.View.Model;

namespace Lottery.Service
{
    public class LotteryManagerV0 : ILotteryManager
    {
        public AwardModel CheckCode(UserCodeModel userCodeModel)
        {
            
            var _codeRepository = new Repository<Code>(new DbContext("LotteryDb"));

            var code = _codeRepository.GetAll().FirstOrDefault(x => x.CodeValue == userCodeModel.Code.CodeValue);

            if (code == null)
                throw new ApplicationException("Invalid code.");

            if (code.IsUsed)
                throw new ApplicationException("Code is used already.");

            var userCode = new UserCode
            {
                Code = code,
                Email = userCodeModel.Email,
                FirstName = userCodeModel.FirstName,
                LastName = userCodeModel.LastName,
                SentAt = DateTime.Now
            };

            var _userCodeRepository = new Repository<UserCode>(new DbContext("LotteryDb"));
            _userCodeRepository.Insert(userCode);

            Award award = new Award()
            {
                RaffledType = (byte)RaffledType.Immediate,
                AwardName = "Another 0.5 Bottle",
                Quantity = 1
            };

            var userCodeAward = new UserCodeAward
            {
                Award = award,
                UserCode = userCode,
                WonAt = DateTime.Now
            };

            var _userCodeAwardRepository = new Repository<UserCodeAward>(new DbContext("LotteryDb"));
            _userCodeAwardRepository.Insert(userCodeAward);

            return new AwardModel()
            {
                AwardName = award.AwardName,
                AwardDescription = award.AwardDescription
            };

        }

        public List<UserCodeAwardModel> GetAllWinners()
        {
            return null;
        }
    }
}
