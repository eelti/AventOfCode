namespace day03;

public class EngineSchematic
{
    public EngineSchematic(int lineLen, int numberOfLines)
    {
        LineLen = lineLen;
        NumberOfLines = numberOfLines;
        Numbers = new List<Number>();
        Symbols = new List<Symbol>();
    }

    public int LineLen { get; private set; }
    public int NumberOfLines { get; private set; }
    public List<Number> Numbers { get; set; }
    public List<Symbol> Symbols { get; set; }
}

public class Number(int value, int rowNumber, int index)
{
    public int Value { get; set; } = value;
    public int RowNumber { get; set; } = rowNumber;
    public int Index { get; set; } = index;


    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        var number = (Number)obj;
        return Value == number.Value && RowNumber == number.RowNumber && Index == number.Index;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value, RowNumber, Index);
    }
}

public class Symbol(string value, int rowNumber, int index)
{
    public string Value { get; set; } = value;
    public int RowNumber { get; set; } = rowNumber;
    public int Index { get; set; } = index;
    
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        var symbol = (Symbol)obj;
        return Value == symbol.Value && RowNumber == symbol.RowNumber && Index == symbol.Index;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value, RowNumber, Index);
    }
}