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

    public int GetGrandTotalOfWinningsCard()
    {
        GetMyWinningCards();
        var maxCardId = Cards.Max(c => c.CardId);
        var keyValuePairs = new List<KeyValuePair<int, int>>();
        foreach (var c in Cards)
        {
            keyValuePairs.Add(new KeyValuePair<int, int>(c.CardId, WinningCard(c.CardId)));
        }
        /*foreach (var cardWinning in _cardWinnings)
            keyValuePairs.Add(new KeyValuePair<int, int>(cardWinning.CardId, WinningCard(cardWinning.CardId)));
            //FindNotWinningCard(cardWinning.CardId, maxCardId, keyValuePairs);*/

        var kpListIndex = 0;
        var k = 0;
        do
        {
            k = Loop(kpListIndex, keyValuePairs, maxCardId);
            kpListIndex += k;
        } while (k != 0);

        return keyValuePairs.Count;
    }

    private void FindNotWinningCard(int cardId, int maxCardId, List<KeyValuePair<int, int>> keyValuePairs)
    {
        var card = Cards.Find(f => f.CardId == cardId + 1);
        if (card == null || card.CardId > maxCardId) return;
        {
            var winning = WinningCard(card.CardId);
            keyValuePairs.Add(new KeyValuePair<int, int>(card.CardId, winning) );
        }
    }

    private int WinningCard(int cardId)
    {
        var winning = _cardWinnings.Find(f => f.CardId == cardId)?.MyNumbers.Count??0;
        return winning;
    }

    private CardWinning? NextCard(int cardId)
    {
        return _cardWinnings.Find(f => f.CardId == cardId + 1);
    }

    private int Loop(int kpListIndex, List<KeyValuePair<int, int>> keyValuePairs, int maxCardId)
    {
        var count = -1;
        var kpIndex = keyValuePairs.Count;
        for (int i = kpListIndex; i < kpIndex; i++)
        {
            if (keyValuePairs[i].Key > maxCardId) break;
            for (int j = 0; j < keyValuePairs[i].Value; j++)
            {
                var cardId = keyValuePairs[i].Key+j;
                var cardWinning = NextCard(cardId);
                if (cardWinning != null)
                {
                    keyValuePairs.Add(new(cardWinning.CardId, cardWinning?.MyNumbers?.Count??0));
                }
                else
                {
                    FindNotWinningCard(cardId,maxCardId,keyValuePairs);
                }
            }
            count++;
        }

        return count;
    }
}