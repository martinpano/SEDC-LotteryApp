using System;
using System.Collections.Generic;
using System.Linq;
using Lottery.Data;
using Lottery.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Lottery.Service
{
    public class LotteryManager : ILotteryManager
    {
        
        private readonly IRepository<Award> _awardRepository;
        private readonly IRepository<UserCode> _userCodeRepository;
        private readonly IRepository<UserCodeAward> _userCodeAwardRepository;

        public LotteryManager(IRepository<Award> awardRepository, 
            IRepository<UserCodeAward> userCodeAwardRepository, 
            IRepository<UserCode> userCodeRepository)
        {
            _awardRepository = awardRepository;
            _userCodeRepository = userCodeRepository;
            _userCodeAwardRepository = userCodeAwardRepository;
        }

        public void GiveAwards(RaffledType type)
        {
            var awardQuantity = GetAwardQuantityPerType(type);

            for (int i = 0; i < awardQuantity; i++)
            {
                GiveAward(type);
            }

        }

        private void GiveAward(RaffledType type)
        {
            var loosers = _userCodeRepository.GetAll().Include(x => x.Code).Where(x => !x.Code.IsWinning);

            if (type == RaffledType.PerDay)
            {
                loosers = loosers.Where(x => x.SentAt.Date == DateTime.Now.Date);
            }

            var loosersList = loosers.ToList();

            var awardedUsers = _userCodeAwardRepository.GetAll().ToList();

            loosersList = loosersList.Where(x => awardedUsers.All(y => y.UserCodeId != x.Id)).ToList();

            if (!loosersList.Any()) return;
            

            var rnd = new Random();
            var randomIndex = rnd.Next(0, loosersList.Count() - 1);

            var winningUser = loosersList[randomIndex];


            var randomAward = GetRanodmAward(type);

            _userCodeAwardRepository.Insert(new UserCodeAward
            {
                Award = randomAward,
                UserCode = winningUser,
                WonAt = DateTime.Now
            });
        }

        private int GetAwardQuantityPerType(RaffledType type)
        {
            var awardsQuantity = _awardRepository.GetAll().Where(x => x.RaffledType == (byte)type).Select(x => x.Quantity).Sum();

            return awardsQuantity;
        }
        
        private Award GetRanodmAward(RaffledType type)
        {
            var awards = _awardRepository.GetAll().Where(x => x.RaffledType == (byte)type).ToList();
            var awardedAwards = _userCodeAwardRepository.GetAll().Where(x => x.Award.RaffledType == (byte)type);

            if(type == RaffledType.PerDay)
            {
                awardedAwards = awardedAwards.Where(x => x.WonAt.Date == DateTime.Now.Date);
            }
                
               var awardedAwardsGroup = awardedAwards.Select(x => x.Award).GroupBy(x => x.Id).ToList();
            
            var availableAwards = new List<Award>();

            foreach (var award in awards)
            {
                var numberOfAwardedAwards = awardedAwardsGroup.FirstOrDefault(x => x.Key == award.Id)?.Count() ?? 0;
                var awardsLeft = award.Quantity - numberOfAwardedAwards;
                availableAwards.AddRange(Enumerable.Repeat(award, awardsLeft));
            }

            if (availableAwards.Count == 0)
                throw new ApplicationException("We are out of awards. Sorry!");

            var rnd = new Random();
            var randomAwardIndex = rnd.Next(0, availableAwards.Count);
            return availableAwards[randomAwardIndex];
        }
        
    }
}
