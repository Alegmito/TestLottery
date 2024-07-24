// See https://aka.ms/new-console-template for more information
using TestLottery.LotteryTest;

Console.WriteLine("Enter Two number, separated by comma: the number of lottery participants, kick-out step");
var lotteryArgs = Console.ReadLine()?.Split(',').Select((string str) => 
  {
    int result = 0;
    int.TryParse(str, out result);
    return result;
  }).Take(2).ToList();

var lottery = new Lottery(lotteryArgs[1]);
Console.WriteLine($"The winner is: {lottery.GetLotteryWinnerAlt(lotteryArgs[0])}");
Console.ReadLine();