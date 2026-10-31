using System;

namespace BJ_CA
{
    [Serializable()]
    public class BJCAShoeClass
    {

        public int[] Cards = new int[11];
        public int[,] Suits = new int[11, 4];

        public int CardsLeft;
        public BJCAHandClass Hand = new BJCAHandClass();

        public void Reset(BJCAShoeClass originalShoe)
        {
            int card;

            for (card = 1; card <= 10; card++)
            {
                Cards[card] = originalShoe.Cards[card];
                Suits[card, 0] = originalShoe.Suits[card, 0];
                Suits[card, 1] = originalShoe.Suits[card, 1];
                Suits[card, 2] = originalShoe.Suits[card, 2];
                Suits[card, 3] = originalShoe.Suits[card, 3];
            }

            CardsLeft = originalShoe.CardsLeft;
            Hand.Empty();
        }

        public void Reset(int nDecks)
        {
            int card;

            for (card = 1; card <= 9; card++)
            {
                Cards[card] = 4 * nDecks;
                Suits[card, 0] = nDecks;
                Suits[card, 1] = nDecks;
                Suits[card, 2] = nDecks;
                Suits[card, 3] = nDecks;
            }
            Cards[10] = 16 * nDecks;
            Suits[10, 0] = 4 * nDecks;
            Suits[10, 1] = 4 * nDecks;
            Suits[10, 2] = 4 * nDecks;
            Suits[10, 3] = 4 * nDecks;

            CardsLeft = nDecks * 52;
            Hand.Empty();
        }

        public void Deal(int card, int nCards = 1)
        {
            Cards[card] -= nCards;
            CardsLeft -= nCards;

            Hand.Cards[card] += nCards;
            Hand.NumCards += nCards;
        }

        public void Deal(BJCAHandClass dealtHand)
        {
            Cards[1] -= dealtHand.Cards[1];
            Cards[2] -= dealtHand.Cards[2];
            Cards[3] -= dealtHand.Cards[3];
            Cards[4] -= dealtHand.Cards[4];
            Cards[5] -= dealtHand.Cards[5];
            Cards[6] -= dealtHand.Cards[6];
            Cards[7] -= dealtHand.Cards[7];
            Cards[8] -= dealtHand.Cards[8];
            Cards[9] -= dealtHand.Cards[9];
            Cards[10] -= dealtHand.Cards[10];
            CardsLeft -= dealtHand.NumCards;

            Hand.Cards[1] += dealtHand.Cards[1];
            Hand.Cards[2] += dealtHand.Cards[2];
            Hand.Cards[3] += dealtHand.Cards[3];
            Hand.Cards[4] += dealtHand.Cards[4];
            Hand.Cards[5] += dealtHand.Cards[5];
            Hand.Cards[6] += dealtHand.Cards[6];
            Hand.Cards[7] += dealtHand.Cards[7];
            Hand.Cards[8] += dealtHand.Cards[8];
            Hand.Cards[9] += dealtHand.Cards[9];
            Hand.Cards[10] += dealtHand.Cards[10];
            Hand.NumCards += dealtHand.NumCards;
        }

        public void Undeal(int card, int nCards = 1)
        {
            Cards[card] += nCards;
            CardsLeft += nCards;

            Hand.Cards[card] -= nCards;
            Hand.NumCards -= nCards;
        }

        public void Undeal(BJCAHandClass dealthand)
        {
            Cards[1] += dealthand.Cards[1];
            Cards[2] += dealthand.Cards[2];
            Cards[3] += dealthand.Cards[3];
            Cards[4] += dealthand.Cards[4];
            Cards[5] += dealthand.Cards[5];
            Cards[6] += dealthand.Cards[6];
            Cards[7] += dealthand.Cards[7];
            Cards[8] += dealthand.Cards[8];
            Cards[9] += dealthand.Cards[9];
            Cards[10] += dealthand.Cards[10];
            CardsLeft += dealthand.NumCards;

            Hand.Cards[1] -= dealthand.Cards[1];
            Hand.Cards[2] -= dealthand.Cards[2];
            Hand.Cards[3] -= dealthand.Cards[3];
            Hand.Cards[4] -= dealthand.Cards[4];
            Hand.Cards[5] -= dealthand.Cards[5];
            Hand.Cards[6] -= dealthand.Cards[6];
            Hand.Cards[7] -= dealthand.Cards[7];
            Hand.Cards[8] -= dealthand.Cards[8];
            Hand.Cards[9] -= dealthand.Cards[9];
            Hand.Cards[10] -= dealthand.Cards[10];
            Hand.NumCards -= dealthand.NumCards;
        }

        public void DealSuited(int card, int suit, int nCards = 1)
        {
            Cards[card] -= nCards;
            Suits[card, suit] -= nCards;
            CardsLeft -= nCards;

            Hand.Cards[card] += nCards;
            Hand.NumCards += nCards;
        }

        public void DealSuited(BJCAHandClass dealtHand, int suit)
        {
            Cards[1] -= dealtHand.Cards[1];
            Cards[2] -= dealtHand.Cards[2];
            Cards[3] -= dealtHand.Cards[3];
            Cards[4] -= dealtHand.Cards[4];
            Cards[5] -= dealtHand.Cards[5];
            Cards[6] -= dealtHand.Cards[6];
            Cards[7] -= dealtHand.Cards[7];
            Cards[8] -= dealtHand.Cards[8];
            Cards[9] -= dealtHand.Cards[9];
            Cards[10] -= dealtHand.Cards[10];
            CardsLeft -= dealtHand.NumCards;

            Suits[1, suit] -= dealtHand.Cards[1];
            Suits[2, suit] -= dealtHand.Cards[2];
            Suits[3, suit] -= dealtHand.Cards[3];
            Suits[4, suit] -= dealtHand.Cards[4];
            Suits[5, suit] -= dealtHand.Cards[5];
            Suits[6, suit] -= dealtHand.Cards[6];
            Suits[7, suit] -= dealtHand.Cards[7];
            Suits[8, suit] -= dealtHand.Cards[8];
            Suits[9, suit] -= dealtHand.Cards[9];
            Suits[10, suit] -= dealtHand.Cards[10];

            Hand.Cards[1] += dealtHand.Cards[1];
            Hand.Cards[2] += dealtHand.Cards[2];
            Hand.Cards[3] += dealtHand.Cards[3];
            Hand.Cards[4] += dealtHand.Cards[4];
            Hand.Cards[5] += dealtHand.Cards[5];
            Hand.Cards[6] += dealtHand.Cards[6];
            Hand.Cards[7] += dealtHand.Cards[7];
            Hand.Cards[8] += dealtHand.Cards[8];
            Hand.Cards[9] += dealtHand.Cards[9];
            Hand.Cards[10] += dealtHand.Cards[10];
            Hand.NumCards += dealtHand.NumCards;
        }

        public void UndealSuited(int card, int suit, int nCards = 1)
        {
            Cards[card] += nCards;
            Suits[card, suit] += nCards;
            CardsLeft += nCards;

            Hand.Cards[card] -= nCards;
            Hand.NumCards -= nCards;
        }

        public void UndealSuited(BJCAHandClass dealthand, int suit)
        {
            Cards[1] += dealthand.Cards[1];
            Cards[2] += dealthand.Cards[2];
            Cards[3] += dealthand.Cards[3];
            Cards[4] += dealthand.Cards[4];
            Cards[5] += dealthand.Cards[5];
            Cards[6] += dealthand.Cards[6];
            Cards[7] += dealthand.Cards[7];
            Cards[8] += dealthand.Cards[8];
            Cards[9] += dealthand.Cards[9];
            Cards[10] += dealthand.Cards[10];
            CardsLeft += dealthand.NumCards;

            Suits[1, suit] += dealthand.Cards[1];
            Suits[2, suit] += dealthand.Cards[2];
            Suits[3, suit] += dealthand.Cards[3];
            Suits[4, suit] += dealthand.Cards[4];
            Suits[5, suit] += dealthand.Cards[5];
            Suits[6, suit] += dealthand.Cards[6];
            Suits[7, suit] += dealthand.Cards[7];
            Suits[8, suit] += dealthand.Cards[8];
            Suits[9, suit] += dealthand.Cards[9];
            Suits[10, suit] += dealthand.Cards[10];

            Hand.Cards[1] -= dealthand.Cards[1];
            Hand.Cards[2] -= dealthand.Cards[2];
            Hand.Cards[3] -= dealthand.Cards[3];
            Hand.Cards[4] -= dealthand.Cards[4];
            Hand.Cards[5] -= dealthand.Cards[5];
            Hand.Cards[6] -= dealthand.Cards[6];
            Hand.Cards[7] -= dealthand.Cards[7];
            Hand.Cards[8] -= dealthand.Cards[8];
            Hand.Cards[9] -= dealthand.Cards[9];
            Hand.Cards[10] -= dealthand.Cards[10];
            Hand.NumCards -= dealthand.NumCards;
        }

        public bool HandPossible(BJCAHandClass hand)
        {
            bool HandPossibleRet = default;
            HandPossibleRet = Cards[1] >= hand.Cards[1] & Cards[2] >= hand.Cards[2] & Cards[3] >= hand.Cards[3] & Cards[4] >= hand.Cards[4] & Cards[5] >= hand.Cards[5] & Cards[6] >= hand.Cards[6] & Cards[7] >= hand.Cards[7] & Cards[8] >= hand.Cards[8] & Cards[9] >= hand.Cards[9] & Cards[10] >= hand.Cards[10];








            return HandPossibleRet;
        }

    }
}