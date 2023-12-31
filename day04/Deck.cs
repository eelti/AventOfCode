using System.Text.RegularExpressions;
using day04.Models;

namespace day04;

public class Deck
{
    private List<CardWinning> _cardWinnings;
    public List<Card> Cards { get; set; } = new();

    public List<CardWinning> GetMyWinningCards()
    {
        _cardWinnings = new List<CardWinning>();
        foreach (var card in Cards)
        {
            var myWinningNumbers = card.WinNumbers.Intersect(card.MyNumbers).ToList();
            if (myWinningNumbers.Count > 0)
                _cardWinnings.Add(new CardWinning(card.CardId) { MyNumbers = myWinningNumbers });
        }

        return _cardWinnings;
    }

    // ...

    public void LoadCard(string[] gameDate)
    {
        foreach (var card in gameDate)
        {
            var cardId = int.Parse(card.Split(':')[0].Replace("   ", " ").Replace("  ", " ").Split(' ')[1]);
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

    public int GetCardPoints(int cardId)
    {
        var cardWinning = _cardWinnings.Find(f => f.CardId == cardId);
        var sum = 0;
        if (cardWinning == null) return sum;
        for (var i = 0; i < cardWinning.MyNumbers.Count; i++)
            if (i == 0)
                sum = 1;
            else
                sum *= 2;
        return sum;
    }

    public int GetGrandTotal()
    {
        GetMyWinningCards();
        var sum = 0;
        foreach (var cardWinning in _cardWinnings)
        {
            sum += GetCardPoints(cardWinning.CardId);
        }

        return sum;
    }
}