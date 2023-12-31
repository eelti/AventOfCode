namespace day04.Models
{
    public class CardWinning
    {
        public int CardId { get; set; }
        public List<int> MyNumbers { get; set; }

        public CardWinning(int cardId)
        {
            CardId = cardId;
            MyNumbers = new List<int>();
        }


        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            CardWinning otherCard = (CardWinning)obj;

            return CardId == otherCard.CardId &&
                   MyNumbers.SequenceEqual(otherCard.MyNumbers);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + CardId.GetHashCode();
                hash = hash * 23 + MyNumbers.GetHashCode();
                return hash;
            }
        }

    }
}
