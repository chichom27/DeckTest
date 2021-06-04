using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckExcersice
{

    public enum Suit { Spade, Heart, Diamond, Club}


    public class Card
    {
        public string name;
        public Suit suit;
        public int number;

        public Card(int inc_number, char inc_suit)
        {
            switch (inc_suit)
            {
                case 'S':
                    suit = Suit.Spade;
                    break;
                case 'H':
                    suit = Suit.Heart;
                    break;
                case 'D':
                    suit = Suit.Diamond;
                    break;
                case 'C':
                    suit = Suit.Club;
                    break;
                default:
                    throw new ArgumentException();
            }

            number = inc_number;

            string number_name;
            switch (inc_number)
            {
                case 11:
                    number_name = "J";
                    break;
                case 12:
                    number_name = "Q";
                    break;
                case 13:
                    number_name = "K";
                    break;
                case 1:
                    number_name = "A";
                    break;
                default:
                    number_name = inc_number.ToString();
                    break;
            }
            name = number_name + inc_suit.ToString();
        }
    }

    public class DeckActions
    {
        Stack<Card> _deck = new Stack<Card>();
        List<Card> _dealt = new List<Card>();

        public DeckActions()
        {
            for (int i = 1; i < 14; i++)
                _deck.Push(new Card(i, 'S'));
            for (int i = 1; i < 14; i++)
                _deck.Push(new Card(i, 'H'));
            for (int i = 1; i < 14; i++)
                _deck.Push(new Card(i, 'D'));
            for (int i = 1; i < 14; i++)
                _deck.Push(new Card(i, 'C'));
        }

        public List<Card> GetCardsDealt()
        {
            return _dealt;
        }

        public List<Card> GetDeck()
        {
            return _deck.ToList();
        }

        public Card DealOne()
        {
            var card = _deck.Pop();
            _dealt.Add(card);

            Console.WriteLine("Dealt: " + card.name);

            return card;
        }

        public List<Card> DealN(int amount)
        {
            Card card;
            List<Card> dealt_hand = new List<Card>();
            int deck_total = _deck.Count;
            for (int i = 0; i < amount && i < deck_total; i++)
            {
                card = _deck.Pop();
                _dealt.Add(card);
                dealt_hand.Add(card);
            }

            return dealt_hand;
        }

        public void AllDealtToTopOfDeck()
        {
            foreach (var card in _dealt)
                _deck.Push(card);
            _dealt.Clear();
        }

        public void AllDealtToBottomOfDeck()
        {
            var deck_list = _deck.ToList();
            deck_list.AddRange(_dealt);
            _dealt.Clear();
            _deck = new Stack<Card>(deck_list);
        }

        public void HandShuffle()
        {
            Random rnd = new Random();
            int times = rnd.Next(3, 12);
            HandShuffle(times);
        }

        public void HandShuffle(int shuffle_times)
        {
            if (shuffle_times < 0)
                return;

            if (_deck.Count < 2)
                return;

            var split = new Stack<Card>();

            for (int i = 0; i < _deck.Count / 2; i++)
                split.Push(_deck.Pop());

            var shuffled_deck = new Stack<Card>();
            Random rnd_spread = new Random();
            int spread;
            while (_deck.Count > 0 && split.Count > 0)
            {
                spread = rnd_spread.Next(1, 4);
                for (int i = 0; i < spread; i++)
                { 
                    if (_deck.Count > 0)
                        shuffled_deck.Push(_deck.Pop());
                }
                spread = rnd_spread.Next(1, 4);
                for (int i = 0; i < spread; i++)
                {
                    if (split.Count > 0)
                        shuffled_deck.Push(split.Pop());
                }
            }

            _deck = shuffled_deck;
        }

        public void RandomShuffle()
        {
            Stack<Card> shuffled_deck = new Stack<Card>();
            Random rnd = new Random();
            int location;
            List<Card> original_deck = _deck.ToList();
            while (original_deck.Count > 1)
            {
                location = rnd.Next(0, original_deck.Count - 1);
                shuffled_deck.Push(original_deck[location]);
                original_deck.RemoveAt(location);
            }
            _deck = shuffled_deck;
        }
    }

}
