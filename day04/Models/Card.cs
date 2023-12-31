using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day04.Models
{
    public class Card(int cardId)
    {
        public int CardId { get; set; } = cardId;
        public List<int> WinNumbers { get; set; } = new List<int>();
        public List<int> MyNumbers { get; set; } = new List<int>();
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Card otherCard = (Card)obj;

            return CardId == otherCard.CardId &&
                   WinNumbers.SequenceEqual(otherCard.WinNumbers) &&
                   MyNumbers.SequenceEqual(otherCard.MyNumbers);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + CardId.GetHashCode();
                hash = hash * 23 + WinNumbers.GetHashCode();
                hash = hash * 23 + MyNumbers.GetHashCode();
                return hash;
            }
        }
    }
}
