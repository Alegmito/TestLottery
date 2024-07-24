using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestLottery.LotteryTest
{
  internal class NaiveLotterySolution
  {
    public NaiveLotterySolution(int step)
    {
      Step = step;
    }

    public int Step { get; set; }

    public int GetLotteryWinner(int participantsCount)
    {
      var participants = Enumerable.Range(1, participantsCount).ToList();

      var toRemove = participantsCount;
      while (participants.Count > 1)
      {
        toRemove = (toRemove + Step - 1) % participants.Count;
        participants.RemoveAt(toRemove);
      }

      return participants[0];
    }

    public StringBuilder MakeSeveralLotteries(List<int> lotteriesParticipants)
    {
      var result = new StringBuilder();
      if (lotteriesParticipants.Count <= 0)
        return result;

      result.AppendLine($"Participants step removal is: {Step}");
      foreach (var item in lotteriesParticipants)
      {
        result.AppendLine($"Lottery participants: {item}; lottery winner is {GetLotteryWinner(item)} ");
      }

      return result;
    }
  }
}
