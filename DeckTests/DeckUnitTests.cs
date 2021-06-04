using System;
using Xunit;
using DeckExcersice;

namespace DeckTests
{
    public class DeckUnitTests
    {
        [Fact]
        public void DealOne()
        {
            var deckActions = new DeckActions();
            var result = deckActions.DealOne();

            Assert.True(result != null, result.name + " card dealt");

        }

        [Fact]
        public void Test1()
        {
            var deckActions = new DeckActions();
            var result = deckActions.DealN(52);

            Assert.True(result.Count == 52, result.Count + " cards present. Expected: 52");

        }

        [Theory]
        [InlineData(5)]
        [InlineData(54)]
        public void DealNCards(int cards_dealt)
        {
            var deckActions = new DeckActions();
            int init_deck_size = deckActions.GetDeck().Count;
            var result = deckActions.DealN(cards_dealt);

            Assert.True(result.Count == cards_dealt || init_deck_size == result.Count, cards_dealt + " cards returned");

            Assert.True(result.Count == cards_dealt || init_deck_size == result.Count, deckActions.GetCardsDealt().Count + " cards returned");

        }

        [Fact]
        public void HandShuffle()
        {
            var deckActions = new DeckActions();
            deckActions.HandShuffle();

            Assert.True(true, "Did not crash");
        }

        [Fact]
        public void RandomShuffle()
        {
            var deckActions = new DeckActions();
            deckActions.RandomShuffle();

            Assert.True(true, "Did not crash");
        }
    }
}
