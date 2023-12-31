using day04;
using day04.Models;

namespace TestAventOfCode.Day04;

[TestFixture]
public class Part01Test
{
    [SetUp]
    //how to build the setup for nUnit test
    public void Setup()
    {
        _gameData = new[]
        {
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
            "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
            "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
            "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
            "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
            "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
        };
    }

    private string[] _gameData;

    [Test]
    public void LoadDeck()
    {
        Deck deck = new();
        var expected = DeckFactpry();

        deck.LoadCard(_gameData);
        var cards = deck.Cards.ToList();

        CollectionAssert.AreEquivalent(expected.Cards, cards);
    }

    [Test]
    public void GetMyWinningNumber_Should_Return_Valid_WinningNumbers()
    {
        // Arrange
        Deck deck = new();
        deck.LoadCard(_gameData);
        var expected = MyWinningNumber();

        // Act
        var actual = deck.GetMyWinningCards();

        // Assert
        Assert.That(actual.Count, Is.EqualTo(expected.Count));

        foreach (var ex in expected)
        {
            var actualCard = actual.Find(a => a.CardId == ex.CardId);
            Assert.That(actualCard, Is.Not.Null);
            CollectionAssert.AreEquivalent(ex.MyNumbers, actualCard?.MyNumbers);
        }
    }
    
    [TestCase(1, 8)]
    [TestCase(2, 2)]
    [TestCase(3, 2)]
    [TestCase(4, 1)]
    [Test]
    public void ValidateEachCardWinning(int cardId, int result)
    {
        // Arrange
        Deck deck = new();
        deck.LoadCard(_gameData);
        var expected = MyWinningNumber();
        var actual = deck.GetMyWinningCards();

        // Act
        var cardPoints = deck.GetCardPoints(cardId);

        // Assert
        Assert.That(cardPoints, Is.EqualTo(result));
    }

    [Test]
    public void GetGrandTotal()
    {
        // Arrange
        Deck deck = new();
        deck.LoadCard(_gameData);
        // Act
        var actual = deck.GetGrandTotal();

        // Assert
        Assert.That(13, Is.EqualTo(actual));
    }

    private static Deck DeckFactpry()
    {
        var expected = new Deck
        {
            Cards = new List<Card>
            {
                new(1)
                {
                    WinNumbers = new List<int> { 41, 48, 83, 86, 17 },
                    MyNumbers = new List<int> { 83, 86, 6, 31, 17, 9, 48, 53 }
                },
                new(2)
                {
                    WinNumbers = new List<int> { 13, 32, 20, 16, 61 },
                    MyNumbers = new List<int> { 61, 30, 68, 82, 17, 32, 24, 19 }
                },
                new(3)
                {
                    WinNumbers = new List<int> { 1, 21, 53, 59, 44 },
                    MyNumbers = new List<int> { 69, 82, 63, 72, 16, 21, 14, 1 }
                },
                new(4)
                {
                    WinNumbers = new List<int> { 41, 92, 73, 84, 69 },
                    MyNumbers = new List<int> { 59, 84, 76, 51, 58, 5, 54, 83 }
                },
                new(5)
                {
                    WinNumbers = new List<int> { 87, 83, 26, 28, 32 },
                    MyNumbers = new List<int> { 88, 30, 70, 12, 93, 22, 82, 36 }
                },
                new(6)
                {
                    WinNumbers = new List<int> { 31, 18, 13, 56, 72 },
                    MyNumbers = new List<int> { 74, 77, 10, 23, 35, 67, 36, 11 }
                }
            }
        };
        return expected;
    }

    private static List<CardWinning> MyWinningNumber()
    {
        var cards = new List<CardWinning>
        {
            new(1) { MyNumbers = new List<int> { 83, 86, 17, 48 } },
            new(2) { MyNumbers = new List<int> { 61, 32 } },
            new(3) { MyNumbers = new List<int> { 21, 1 } },
            new(4) { MyNumbers = new List<int> { 84 } }
        };

        return cards;
    }
}