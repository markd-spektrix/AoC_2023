namespace AdventOfCode;

public sealed class Day01 : BaseDay
{
    private static readonly string[] WrittenNumbers =
        { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

    private static readonly Dictionary<string, int> WordToNumberLookup = new()
    {
        { "one", 1 }, { "two", 2 }, { "three", 3 }, { "four", 4 }, { "five", 5 }, { "six", 6 }, { "seven", 7 },
        { "eight", 8 }, { "nine", 9 }
    };

    private readonly int _part1Solution;
    private readonly int _part2Solution;


    public Day01()
    {
        var input = File.ReadAllText(InputFilePath);
        Console.WriteLine("Hello, World!");
        Console.WriteLine(InputFilePath);

        _part1Solution = GetSumValue(input);
        _part2Solution = GetWordySumValue(input);
    }

    public override ValueTask<string> Solve_1()
    {
        return new ValueTask<string>($"{_part1Solution}");
    }

    public override ValueTask<string> Solve_2()
    {
        return new ValueTask<string>($"{_part2Solution}");
    }

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

    private static string[] SplitDocument(string inputDocument)
    {
        var splitDocument = inputDocument.Split("\r\n");

        return splitDocument;
    }

    public static int GetSumValue(string inputFile)
    {
        var splitDocument = SplitDocument(inputFile);

        return splitDocument.Sum(GetPairedNumber);
    }

    public static int GetWordyPairedNumber(string inputFile)
    {
        return Convert.ToInt32("" + GetFirstWordyNumber(inputFile) + GetLastWordyNumber(inputFile));
    }

    public static int GetWordySumValue(string inputFile)
    {
        var splitDocument = SplitDocument(inputFile);

        return splitDocument.Sum(GetWordyPairedNumber);
    }

    public static int GetFirstWordyNumber(string inputFile)
    {
        var firstRealNumber = GetFirstNumber(inputFile);
        var firstRealNumberIndex = inputFile.IndexOf(firstRealNumber.ToString(), StringComparison.Ordinal);

        var earliestWord = firstRealNumber;
        var earliestIndex = firstRealNumberIndex;

        foreach (var writtenNumber in WrittenNumbers)
        {
            var indexOf = inputFile.IndexOf(writtenNumber, StringComparison.Ordinal);

            if ((indexOf < earliestIndex && indexOf != -1) || earliestIndex == -1)
            {
                earliestIndex = indexOf;

                WordToNumberLookup.TryGetValue(writtenNumber, out earliestWord);
            }
        }

        return earliestWord;
    }

    public static int GetLastWordyNumber(string inputFile)
    {
        var lastRealNumber = GetLastNumber(inputFile);
        var lastRealNumberIndex = inputFile.LastIndexOf(lastRealNumber.ToString(), StringComparison.Ordinal);

        var lastWord = lastRealNumber;
        var lastIndex = lastRealNumberIndex;

        foreach (var writtenNumber in WrittenNumbers)
        {
            var indexOf = inputFile.LastIndexOf(writtenNumber, StringComparison.Ordinal);

            if ((indexOf > lastIndex && indexOf != -1) || lastIndex == -1)
            {
                lastIndex = indexOf;

                WordToNumberLookup.TryGetValue(writtenNumber, out lastWord);
            }
        }

        return lastWord;
    }
}