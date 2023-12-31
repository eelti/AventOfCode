namespace day04.Models;

public class Card(int cardId)
{
    public int CardId { get; set; } = cardId;
    public List<int> WinNumbers { get; set; } = new();
    public List<int> MyNumbers { get; set; } = new();

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;

        var otherCard = (Card)obj;

        return CardId == otherCard.CardId &&
               WinNumbers.SequenceEqual(otherCard.WinNumbers) &&
               MyNumbers.SequenceEqual(otherCard.MyNumbers);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = hash * 23 + CardId.GetHashCode();
            hash = hash * 23 + WinNumbers.GetHashCode();
            hash = hash * 23 + MyNumbers.GetHashCode();
            return hash;
        }
    }
}