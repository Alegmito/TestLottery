using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestLottery.LotteryTest
{
  public class Lottery
  {
    public Lottery(int step)
    {
      Step = step;
    }

    public int Step { get; set; }
    // solution where we iterate through list and remove elements until only one left
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

    // Solutions where we use recursive equation system
    // Winner(1) = 1
    // Winner(n) = (Winner(n - 1) + k) % n
    // But we use this recursive equation in iterative form
    public int GetLotteryWinnerAlt(int participantsCount)
    {
      int result = 0;

      for (int i = 2; i < participantsCount + 1; i++)
        result = (result + Step) % i;

      return ++result;
    }

    public StringBuilder MakeSeveralLotteriesAlt(List<int> ParticipantsCounts)
    {
      return MakeSeveralLotteriesFunc(ParticipantsCounts, GetLotteryWinnerAlt);
    }

    public StringBuilder MakeSeveralLotteries(List<int> ParticipantsCounts)
    {
      return MakeSeveralLotteriesFunc(ParticipantsCounts, GetLotteryWinner);
    }

    public StringBuilder MakeSeveralLotteriesFunc(List<int> lotteriesParticipants, Func<int, int> lotteryWinnerFunc)
    {
      var result = new StringBuilder();
      if (lotteriesParticipants.Count <= 0)
        return result;

      result.AppendLine($"Participants step removal is: {Step}");
      foreach (var item in lotteriesParticipants)
      {
        result.AppendLine($"Lottery participants: {item}; lottery winner is {lotteryWinnerFunc(item)} ");
      }

      return result;
    }
  }
}
