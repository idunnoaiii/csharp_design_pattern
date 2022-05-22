// See https://aka.ms/new-console-template for more information

public class BetterFormattedText
{
    private readonly string _plainText;
    private List<TextRange> formatting = new();

    public BetterFormattedText(string plainText)
    {
        _plainText = plainText;
        
    }

    public TextRange GetRange(int start, int end)
    {
        var range = new TextRange {Start = start, End = end};
        formatting.Add(range);
        return range;
    }

    public class TextRange
    {
        public int Start, End;
        public bool Capitalize, Bold, Italic;

        public bool Cover(int pos)
        {
            return pos >= Start && pos <= End;
        }
    }
}