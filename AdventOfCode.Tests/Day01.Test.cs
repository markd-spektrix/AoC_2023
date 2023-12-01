namespace AdventOfCode.Tests;

public class Day01
{
    private const string CalibrationLocation = @"C:\repos\freedom-friday\AoC_2023\AdventOfCode.Tests\Inputs\01.txt";

    [Test]
    public void ShouldGetCalibrationSum()
    {
        Assert.That(AdventOfCode.Day01.GetSumValue(File.ReadAllText(CalibrationLocation)), Is.EqualTo(142));
    }
}