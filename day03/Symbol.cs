namespace day03;

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