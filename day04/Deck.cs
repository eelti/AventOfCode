using day04.Models;
using System.Text.RegularExpressions;

namespace day04
{
    public class Deck
    {
        public List<Card> Cards { get; set; } = new List<Card>();

        public List<CardWinning> GetMyWinningCards()
        {
            List<CardWinning> cardWinnings = new List<CardWinning>();
           foreach (var card in Cards)
            {
                var myWinningNumbers = card.WinNumbers.Intersect(card.MyNumbers).ToList();
                if (myWinningNumbers.Count > 0)
                    cardWinnings.Add( new CardWinning(card.CardId) { MyNumbers= myWinningNumbers});
            }
           return cardWinnings;
        }

        // ...

        public void LoadCard(string[] gameDate)
        {
            foreach (var card in gameDate)
            {
                var cardId = int.Parse(card.Split(':')[0].Split(' ')[1]);
                //"Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
                //use regex to get the numbers after the : and before the |
                var numbers = Regex.Match(card, @": (.*)\|").Groups[1].Value.Replace("  ", " ");

                var cardWinNumbers = numbers.Trim().Split(' ').Select(int.Parse).ToList();
                //use regex to get the numbers after the | and split them into a list

                var cardMyNumbers00 = Regex.Match(card, @"\| (.*)").Groups[1].Value.Replace("  ", " ");
                var cardMyNumbers = cardMyNumbers00.Trim().Split(' ').Select(int.Parse).ToList();
                Cards.Add(new Card(cardId) { WinNumbers = cardWinNumbers, MyNumbers = cardMyNumbers });
            }
        }
    }
}