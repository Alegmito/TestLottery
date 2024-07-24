// See https://aka.ms/new-console-template for more information
using TestLottery.LotteryTest;

Console.WriteLine("Hello, World!");
var testLotteries = new List<NaiveLotterySolution>();
var NumberOfSteps = 5;
for (int i = 2; i <= NumberOfSteps + 2; i ++)
{
  testLotteries.Add(new NaiveLotterySolution(i));
}

var participantsCounts = Enumerable.Range(1, 20);

foreach (var testLottery in testLotteries)
{
  Console.WriteLine(
  testLottery.MakeSeveralLotteries(participantsCounts.ToList()));
}

Console.ReadLine();