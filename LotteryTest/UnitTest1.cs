using TestLottery.LotteryTest;

namespace LotteryTest
{
  [TestClass]
  public class LotteryTests
  {

    public Lottery Lottery { get; set; } = new Lottery(2);

    public static IEnumerable<object[]> LotteryTestData
    {
      get
      {
        return new[]
        {
            new object[] { 2, 1, 1 },
            new object[] { 2, 2, 1 },
            new object[] { 2, 3, 3 },
            new object[] { 2, 4, 1 },
            new object[] { 2, 100, 73 },
            new object[] { 3, 1, 1 },
            new object[] { 3, 2, 2 },
            new object[] { 3, 5, 4 },
        };
      }
    }

    [TestMethod]
    [DynamicData(nameof(LotteryTestData))]
    public void GetLotteryWinner_ReturnsValidAnswer(int step, int participantsCount, int expected)
    {
      Lottery.Step = step;
      Assert.AreEqual(expected, Lottery.GetLotteryWinner(participantsCount));
    }

    [TestMethod]
    [DynamicData(nameof(LotteryTestData))]
    public void GetLotteryWinnerAlt_ReturnsValidAnswer(int step, int participantsCount, int expected)
    {
      Lottery.Step = step;
      Assert.AreEqual(expected, Lottery.GetLotteryWinnerAlt(participantsCount));
    }
  }
}