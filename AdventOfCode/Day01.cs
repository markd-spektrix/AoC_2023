namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly string _input;
    private readonly int _part1Solution;

    public Day01()
    {
        _input = File.ReadAllText(InputFilePath);
        Console.WriteLine("Hello, World!");
        Console.WriteLine(InputFilePath);

        _part1Solution = GetSumValue(_input);

    }

    public override ValueTask<string> Solve_1() => new($"{_part1Solution}");

    public override ValueTask<string> Solve_2() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 2");

    private static int GetFirstNumber(string calibrationInput)
    {
        var charArray = calibrationInput.ToCharArray();

        return RetrieveFirstNumberFromArray(charArray);
    }


    private static int GetLastNumber(string calibrationInput)
    {
        var charArray = calibrationInput.ToCharArray();
        Array.Reverse(charArray);
        return RetrieveFirstNumberFromArray(charArray);
    }

    private static int RetrieveFirstNumberFromArray(IEnumerable<char> charArray)
    {
        var firstNumberFromArray = -1;
        foreach (var inputCharacter in charArray)
            if (int.TryParse(inputCharacter.ToString(), out firstNumberFromArray))
                break;

        return firstNumberFromArray;
    }


    private static int GetPairedNumber(string input)
    {
        return Convert.ToInt32("" + GetFirstNumber(input) + GetLastNumber(input));
    }

    private static IEnumerable<string> SplitDocument(string inputDocument)
    {
        var splitDocument = inputDocument.Split("\r\n");

        return splitDocument;
    }

    public static int GetSumValue(string inputFile)
    {
        var splitDocument = SplitDocument(inputFile);

        return splitDocument.Sum(GetPairedNumber);
    }

    private static string GetCalibrationFile(string calibrationLocation)
    {
        return File.ReadAllText(calibrationLocation);
    }
}
