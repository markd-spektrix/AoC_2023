namespace AdventOfCode.Tests;

public class Day01
{
    private const string Part1Input = @"C:\repos\freedom-friday\AoC_2023\AdventOfCode.Tests\Inputs\01_1.txt";
    private const string Part2Input = @"C:\repos\freedom-friday\AoC_2023\AdventOfCode.Tests\Inputs\01_2.txt";


    [Test]
    public void ShouldGetCalibrationSum()
    {
        Assert.That(AdventOfCode.Day01.GetSumValue(File.ReadAllText(Part1Input)), Is.EqualTo(142));
    }

    [Test]
    public void ShouldGetWordyCalibrationSum()
    {
        Assert.That(AdventOfCode.Day01.GetWordySumValue(File.ReadAllText(Part2Input)), Is.EqualTo(281));
    }

    [TestCase("two1nine", 2)]
    [TestCase("eightwothree", 8)]
    [TestCase("abcone2threexyz", 1)]
    [TestCase("xtwone3four", 2)]
    [TestCase("4nineeightseven2", 4)]
    [TestCase("zoneight234", 1)]
    [TestCase("7pqrstsixteen", 7)]
    [TestCase("eighthree", 8)]
    [TestCase("sevenine", 7)]
    [TestCase("threehpbsevenffnqgdjcftjkdjhhk7dvzmkmqthreefflb", 3)]
    public void ShouldGetFirstWordedNumber(string input, int expected)
    {
        Assert.That(AdventOfCode.Day01.GetFirstWordyNumber(input), Is.EqualTo(expected));
    }

    [TestCase("two1nine", 9)]
    [TestCase("eightwothree", 3)]
    [TestCase("abcone2threexyz", 3)]
    [TestCase("xtwone3four", 4)]
    [TestCase("4nineeightseven2", 2)]
    [TestCase("zoneight234", 4)]
    [TestCase("7pqrstsixteen", 6)]
    [TestCase("eighthree", 3)]
    [TestCase("sevenine", 9)]
    [TestCase("threehpbsevenffnqgdjcftjkdjhhk7dvzmkmqthreefflb", 3)]
    public void ShouldGetLastWordedNumber(string input, int expected)
    {
        Assert.That(AdventOfCode.Day01.GetLastWordyNumber(input), Is.EqualTo(expected));
    }

    [TestCase("two1nine", 29)]
    [TestCase("eightwothree", 83)]
    [TestCase("abcone2threexyz", 13)]
    [TestCase("xtwone3four", 24)]
    [TestCase("4nineeightseven2", 42)]
    [TestCase("zoneight234", 14)]
    [TestCase("7pqrstsixteen", 76)]
    [TestCase("eighthree", 83)]
    [TestCase("sevenine", 79)]
    [TestCase("threehpbsevenffnqgdjcftjkdjhhk7dvzmkmqthreefflb", 33)]
    public void ShouldGetWordySumValue(string input, int expected)
    {
        Assert.That(AdventOfCode.Day01.GetWordyPairedNumber(input), Is.EqualTo(expected));
    }
}