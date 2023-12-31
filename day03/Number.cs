namespace day03;

public class Number(int value, int rowNumber, int index)
{
    public int Value { get; set; } = value;
    public int RowNumber { get; set; } = rowNumber;
    public int Index { get; set; } = index;
    public int IndexEnd { get; set; } = index + (value.ToString().Length - 1);


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