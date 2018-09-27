

using Lottery.Data.Model;

namespace Lottery.Service
{
    public interface ILotteryManager
    {
        void GiveAwards(RaffledType type);
    }
}
