using System;
using Microsoft.VisualBasic.CompilerServices;

namespace BJ_CA
{
    [Serializable()]
    public class BJCAHandClass
    {
        public int[] Cards = new int[11];        // Number of each card in the hand
        public int NumCards;         // Total number of cards in the hand
        public int Total;            // Total value of the hand
        public bool Soft;             // Is the hand soft?

        public void Empty()
        {
            Cards[0] = 0;
            Cards[1] = 0;
            Cards[2] = 0;
            Cards[3] = 0;
            Cards[4] = 0;
            Cards[5] = 0;
            Cards[6] = 0;
            Cards[7] = 0;
            Cards[8] = 0;
            Cards[9] = 0;
            Cards[10] = 0;
            NumCards = 0;
            Total = 0;
            Soft = Conversions.ToBoolean(0);
        }

        public void Copy(BJCAHandClass fromHand)
        {
            Cards[0] = fromHand.Cards[0];
            Cards[1] = fromHand.Cards[1];
            Cards[2] = fromHand.Cards[2];
            Cards[3] = fromHand.Cards[3];
            Cards[4] = fromHand.Cards[4];
            Cards[5] = fromHand.Cards[5];
            Cards[6] = fromHand.Cards[6];
            Cards[7] = fromHand.Cards[7];
            Cards[8] = fromHand.Cards[8];
            Cards[9] = fromHand.Cards[9];
            Cards[10] = fromHand.Cards[10];
            NumCards = fromHand.NumCards;
            Total = fromHand.Total;
            Soft = fromHand.Soft;
        }

        public void UpdateTotal()
        {
            Total = 0;
            Soft = false;
            NumCards = 0;
            Total += Cards[1];
            Total += 2 * Cards[2];
            Total += 3 * Cards[3];
            Total += 4 * Cards[4];
            Total += 5 * Cards[5];
            Total += 6 * Cards[6];
            Total += 7 * Cards[7];
            Total += 8 * Cards[8];
            Total += 9 * Cards[9];
            Total += 10 * Cards[10];
            NumCards += Cards[0];
            NumCards += Cards[1];
            NumCards += Cards[2];
            NumCards += Cards[3];
            NumCards += Cards[4];
            NumCards += Cards[5];
            NumCards += Cards[6];
            NumCards += Cards[7];
            NumCards += Cards[8];
            NumCards += Cards[9];
            NumCards += Cards[10];
            if (Total < 12 & Cards[1] > 0)
            {
                Soft = true;
                Total += 10;
            }
        }

        public bool SameAs(BJCAHandClass fromHand)
        {
            bool SameAsRet = default;
            SameAsRet = Cards[0] == fromHand.Cards[0] & Cards[1] == fromHand.Cards[1] & Cards[2] == fromHand.Cards[2] & Cards[3] == fromHand.Cards[3] & Cards[4] == fromHand.Cards[4] & Cards[5] == fromHand.Cards[5] & Cards[6] == fromHand.Cards[6] & Cards[7] == fromHand.Cards[7] & Cards[8] == fromHand.Cards[8] & Cards[9] == fromHand.Cards[9] & Cards[10] == fromHand.Cards[10] & NumCards == fromHand.NumCards & Total == fromHand.Total & Soft == fromHand.Soft;












            return SameAsRet;
        }

        public bool Includes(BJCAHandClass includedHand)
        {
            bool IncludesRet = default;
            IncludesRet = Cards[0] >= includedHand.Cards[0] & Cards[1] >= includedHand.Cards[1] & Cards[2] >= includedHand.Cards[2] & Cards[3] >= includedHand.Cards[3] & Cards[4] >= includedHand.Cards[4] & Cards[5] >= includedHand.Cards[5] & Cards[6] >= includedHand.Cards[6] & Cards[7] >= includedHand.Cards[7] & Cards[8] >= includedHand.Cards[8] & Cards[9] >= includedHand.Cards[9] & Cards[10] >= includedHand.Cards[10] & NumCards >= includedHand.NumCards;










            return IncludesRet;
        }

        public void Deal(int card)
        {
            NumCards += 1;
            Cards[card] += 1;
            Total += card;
            if (card == 1 & Total < 12)
            {
                Total += 10;
                Soft = true;
            }
            else if (Total > 21 & Soft)
            {
                Total -= 10;
                Soft = false;
            }
        }

        public void Undeal(int card)
        {
            Cards[card] -= 1;
            NumCards -= 1;
            Total -= card;

            if (card == 1 & Cards[1] == 0 & Soft)
            {
                Total -= 10;
                Soft = false;
            }
            else if (Total < 12 & Cards[1] > 0 & !Soft)
            {
                Total += 10;
                Soft = true;
            }
        }

        public bool IsBJ()
        {
            return NumCards == 2 & Cards[1] == 1 & Cards[10] == 1;
        }

        public bool IsPair()
        {
            return NumCards == 2 & (Cards[1] == 2 | Cards[2] == 2 | Cards[3] == 2 | Cards[4] == 2 | Cards[5] == 2 | Cards[6] == 2 | Cards[7] == 2 | Cards[8] == 2 | Cards[9] == 2 | Cards[10] == 2);


        }

        public int Paircard()
        {
            int card;

            if (NumCards != 2)
            {
                return 0;
            }
            else
            {
                for (card = 1; card <= 10; card++)
                {
                    if (Cards[card] == 2)
                    {
                        break;
                    }
                }
                if (card == 11)
                {
                    return 0;
                }
                else
                {
                    return card;
                }
            }
        }

        public object BJProb(int upcard, BJCAShoeClass shoe, bool handIncluded)
        {
            if (upcard != 1 & upcard != 10 | !handIncluded & !shoe.HandPossible(this))
            {
                return 0;
            }
            else if (upcard == 1)
            {
                if (handIncluded)
                {
                    return shoe.Cards[10] / (double)shoe.CardsLeft;
                }
                else
                {
                    return (shoe.Cards[10] - Cards[10]) / (double)(shoe.CardsLeft - NumCards);
                }
            }
            else if (handIncluded)
            {
                return shoe.Cards[1] / (double)shoe.CardsLeft;
            }
            else
            {
                return (shoe.Cards[1] - Cards[1]) / (double)(shoe.CardsLeft - NumCards);
            }
        }

    }

    // The engine creates these in its inner loops but each caller uses only a few of the arrays, so each
    // array is created on first use. An array that has not been created reads as its initial value.
    [Serializable()]
    public class BJCAHandEVsClass
    {
        private double[] _prob, _sumSuited, _standEV, _standPushEV, _dEV, _dPushEV, _dStratEV, _dStratPushEV, _surrEV, _bjProb, _bjStandEV, _bonusEV;
        private double[,] _probSuited, _dealerProbs;
        private bool[,] _suitedPossible;
        private bool[] _standDone;
        private int[] _dStrat;

        public double[] Prob => _prob ??= new double[11];                          // Probability of Hand occurring given upcard
        public double[] SumSuited => _sumSuited ??= new double[11];                // Net probability of the hand being suited
        public double[,] ProbSuited => _probSuited ??= new double[11, 5];          // Probability of Hand being a given suit
        public bool[,] SuitedPossible => _suitedPossible ??= new bool[11, 5];      // Possibility of Hand being suited

        public double[] StandEV => _standEV ??= new double[11];                    // Upcard   Stand EV's relative to each dealer upcard
        public double[] StandPushEV => _standPushEV ??= new double[11];            // Upcard   EV of pushing; can be used for special rules and variance
        public bool[] StandDone => _standDone ??= new bool[11];
        public double[,] DealerProbs => _dealerProbs ??= new double[11, 5];        // Upcard

        public double[] DEV => _dEV ??= new double[11];                            // Upcard   Double EV's relative to each dealer upcard
        public double[] DPushEV => _dPushEV ??= new double[11];                    // Upcard   EV of pushing; can be used for special rules and variance

        public int[] DStrat => _dStrat ??= new int[11];
        public double[] DStratEV => _dStratEV ??= new double[11];
        public double[] DStratPushEV => _dStratPushEV ??= new double[11];          // Upcard   This is necessary because of soft doubles can be hard

        public double[] SurrEV => _surrEV ??= new double[11];                      // Upcard   Surrender EV's relative to each dealer upcard

        public double[] BJProb => _bjProb ??= new double[11];                      // Upcard   Stand EV's relative to each dealer upcard
        public double[] BJStandEV => _bjStandEV ??= NewBJStandEV();                // Upcard   Stand EV's relative to each dealer upcard

        public double[] BonusEV => _bonusEV ??= new double[11];                    // Upcard   Stand EV's relative to each dealer upcard

        private static double[] NewBJStandEV()
        {
            var bjStandEV = new double[11];
            bjStandEV[1] = -1;
            bjStandEV[10] = -1;
            return bjStandEV;
        }

        // Resets everything except the suited and blackjack probabilities to its initial value.
        public void Empty()
        {
            Clear(_prob);
            Clear(_standEV);
            Clear(_standPushEV);
            if (_standDone is not null) Array.Clear(_standDone);
            Clear(_dEV);
            Clear(_dPushEV);
            if (_dStrat is not null) Array.Clear(_dStrat);
            Clear(_dStratEV);
            Clear(_dStratPushEV);
            Clear(_surrEV);
            if (_bjStandEV is not null)
            {
                Array.Clear(_bjStandEV);
                _bjStandEV[1] = -1;
                _bjStandEV[10] = -1;
            }
            Clear(_bonusEV);
            if (_dealerProbs is not null) Array.Clear(_dealerProbs);
        }

        // Copies everything except the suited and blackjack probabilities, in place.
        public void Copy(BJCAHandEVsClass originalHand)
        {
            CopyArray(ref _prob, originalHand._prob);
            CopyArray(ref _standEV, originalHand._standEV);
            CopyArray(ref _standPushEV, originalHand._standPushEV);
            CopyArray(ref _standDone, originalHand._standDone);
            CopyArray(ref _dEV, originalHand._dEV);
            CopyArray(ref _dPushEV, originalHand._dPushEV);
            CopyArray(ref _dStrat, originalHand._dStrat);
            CopyArray(ref _dStratEV, originalHand._dStratEV);
            CopyArray(ref _dStratPushEV, originalHand._dStratPushEV);
            CopyArray(ref _surrEV, originalHand._surrEV);
            if (originalHand._bjStandEV is not null || _bjStandEV is not null)
                Array.Copy(originalHand.BJStandEV, BJStandEV, 11);
            CopyArray(ref _bonusEV, originalHand._bonusEV);
            if (originalHand._dealerProbs is not null)
                Array.Copy(originalHand._dealerProbs, DealerProbs, originalHand._dealerProbs.Length);
            else if (_dealerProbs is not null)
                Array.Clear(_dealerProbs);
        }

        private static void Clear(double[] array)
        {
            if (array is not null) Array.Clear(array);
        }

        // Makes target hold source's values, treating a missing array as all zeros.
        private static void CopyArray<T>(ref T[] target, T[] source)
        {
            if (source is not null)
                Array.Copy(source, target ??= new T[source.Length], source.Length);
            else if (target is not null)
                Array.Clear(target);
        }
    }

    [Serializable()]
    public class BJCAStratHandEVsClass
    {
        public double[] Prob = new double[11];                 // Probability of Hand occurring given upcard

        public int[] Strat = new int[11];               // Upcard     Stand EV's relative to each dealer upcard
        public double[] StratEV = new double[11];              // Upcard     Stand EV's relative to each dealer upcard
        public double[] StratPushEV = new double[11];          // Upcard     Stand EV's relative to each dealer upcard
        public double[] StratBustProb = new double[11];        // Upcard     Stand EV's relative to each dealer upcard

        public double[] StandEV = new double[11];              // Upcard     Stand EV's relative to each dealer upcard
        public double[] StandPushEV = new double[11];          // Upcard     EV of pushing; can be used for special rules and variance
        public double[,] DealerProbs = new double[11, 5];       // Upcard

        public double[] DEV = new double[11];                  // Upcard     Double EV's relative to each dealer upcard
        public double[] DPushEV = new double[11];              // Upcard     EV of pushing; can be used for special rules and variance
        public double[] DBustProb = new double[11];            // Upcard     EV of pushing; can be used for special rules and variance

        public double[] SurrEV = new double[11];               // Upcard     Surrender EV's relative to each dealer upcard

        public double[] HitEV = new double[11];                // Upcard     Double EV's relative to each dealer upcard
        public double[] HitPushEV = new double[11];            // Upcard     EV of pushing; can be used for special rules and variance
        public double[] HitBustProb = new double[11];          // Upcard     EV of pushing; can be used for special rules and variance

        public double[] SplitEV = new double[11];              // Upcard     Surrender EV's relative to each dealer upcard

        public bool[] DAllowed = new bool[11];            // Double Allowed Pre-Split
        public int[] RAllowed = new int[11];            // Surrender Type Allowed Pre-Split
        public bool[] PAllowed = new bool[11];            // Split Allowed

        public void Empty()
        {
            int card;
            int total;

            for (card = 0; card <= 10; card++)
            {
                Prob[card] = 0d;
                Strat[card] = 0;
                StratEV[card] = 0d;
                StratPushEV[card] = 0d;
                StratBustProb[card] = 0d;
                StandEV[card] = 0d;
                StandPushEV[card] = 0d;
                DEV[card] = 0d;
                DPushEV[card] = 0d;
                DBustProb[card] = 0d;
                SurrEV[card] = 0d;
                HitEV[card] = 0d;
                HitPushEV[card] = 0d;
                HitBustProb[card] = 0d;
                SplitEV[card] = 0d;
                DAllowed[card] = false;
                RAllowed[card] = 0;
                PAllowed[card] = false;
                for (total = 0; total <= 4; total++)
                    DealerProbs[card, total] = 0d;
            }
        }

        public void Copy(BJCAStratHandEVsClass originalHand)
        {
            int card;
            int total;

            for (card = 0; card <= 10; card++)
            {
                Prob[card] = originalHand.Prob[card];
                StandEV[card] = originalHand.StandEV[card];
                StandPushEV[card] = originalHand.StandPushEV[card];
                DEV[card] = originalHand.DEV[card];
                DPushEV[card] = originalHand.DPushEV[card];
                SurrEV[card] = originalHand.SurrEV[card];
                HitEV[card] = originalHand.HitEV[card];
                HitPushEV[card] = originalHand.HitPushEV[card];
                SplitEV[card] = originalHand.SplitEV[card];
                for (total = 0; total <= 4; total++)
                    DealerProbs[card, total] = originalHand.DealerProbs[card, total];
            }
        }
    }

    [Serializable()]
    // The split recursion creates one of these per node as scratch space and uses only Hand and HandEVs,
    // so the other arrays are created on first use.
    public class BJCAPlayerHandClass
    {
        private int[] _hitHand, _rPreallowed, _rPostallowed, _pairIndex;
        private bool[] _pAllowed, _dPreallowed, _dPostallowed;
        private BJCAHandEVsClass[,] _splitEVs;

        public BJCAHandClass Hand = new BJCAHandClass();            // The actual hand
        public BJCAHandEVsClass HandEVs = new BJCAHandEVsClass();      // EVs for full deck

        public int[] HitHand => _hitHand ??= new int[11];                  // Hand in index that follows if (card) is hit
        public int NextHand;                  // Next hand in list with same count

        // Strategies allowed by the game rules
        public bool[] PAllowed => _pAllowed ??= new bool[11];              // Split Allowed
        public bool[] DPreallowed => _dPreallowed ??= new bool[11];        // Double Allowed Pre-Split
        public int[] RPreallowed => _rPreallowed ??= new int[11];          // Surrender Type Allowed Pre-Split

        public bool[] DPostallowed => _dPostallowed ??= new bool[11];      // Double Allowed Post-Split
        public int[] RPostallowed => _rPostallowed ??= new int[11];        // Surrender Type Allowed Post-Split

        public int[] PairIndex => _pairIndex ??= new int[11];              // Paircard - stores the reference index for the split data
        public BJCAHandEVsClass[,] SplitEVs => _splitEVs ??= new BJCAHandEVsClass[7, 12];

        public BJCASuitedBonusEVClass SuitedBonusEVs;   // Only initialize if suited bonus is possible
    }

    [Serializable()]
    public class BJCADealerHandClass
    {
        public BJCAHandClass Hand = new BJCAHandClass();               // The actual hand
        public int NextHandTotal;                // Next hand in list with same total
        public int[] NextHandTotalUC = new int[11];          // Next hand in list with same total for a given upcard
        public int[] Multiplier = new int[11];               // Number of different ways the Dealer hand can be reached for a given upcard
    }

    [Serializable()]
    public class BJCARealtimeHandClass
    {
        public BJCAStratHandEVsClass Hand = new BJCAStratHandEVsClass();       // The hand evs
        public BJCASuitedBonusEVClass SuitedEVs;     // This is only initialized if needed
    }

    // Created once per node of the split recursion, so, as with BJCAHandEVsClass, each array is created on
    // first use and an array that has not been created reads as its initial value.
    [Serializable()]
    public class BJCASplitHandEVsClass
    {
        private double[] _prob, _standEV, _dEV, _surrEV, _bjProb, _bjEV, _bonusEV, _cEV, _bjCEV, _pRes, _bboEV, _obboEV;

        public double[] Prob => _prob ??= new double[11];                  // Probability of Hand occurring given upcard
        public double[] StandEV => _standEV ??= new double[11];            // Upcard   Stand EV's relative to each dealer upcard
        public double[] DEV => _dEV ??= new double[11];                    // Upcard   Double EV's relative to each dealer upcard
        public double[] SurrEV => _surrEV ??= new double[11];              // Upcard   Surrender EV's relative to each dealer upcard
        public double[] BJProb => _bjProb ??= new double[11];              // Upcard   Stand EV's relative to each dealer upcard
        public double[] BJEV => _bjEV ??= NewBJEV();                       // Upcard   Stand EV's relative to each dealer upcard
        public double[] BonusEV => _bonusEV ??= new double[11];            // Upcard   Stand EV's relative to each dealer upcard

        // The following are used for OBBO Calcs
        public double[] CEV => _cEV ??= new double[11];                    // Upcard   CEV
        public double[] BJCEV => _bjCEV ??= new double[11];                // Upcard   p*EV
        public double[] PRes => _pRes ??= new double[11];                  // Upcard   Probability of Resolving Hand with BJ
        public double[] BBOEV => _bboEV ??= new double[11];                // Upcard   BBO EV
        public double[] OBBOEV => _obboEV ??= new double[11];              // Upcard   OBBO EV

        private static double[] NewBJEV()
        {
            var bjEV = new double[11];
            bjEV[1] = -1;
            bjEV[10] = -1;
            return bjEV;
        }

        // Resets the stand, double, surrender and bonus EVs to their initial values.
        public void Empty()
        {
            if (_prob is not null) Array.Clear(_prob);
            if (_standEV is not null) Array.Clear(_standEV);
            if (_dEV is not null) Array.Clear(_dEV);
            if (_surrEV is not null) Array.Clear(_surrEV);
            if (_bjEV is not null)
            {
                Array.Clear(_bjEV);
                _bjEV[1] = -1;
                _bjEV[10] = -1;
            }
            if (_bonusEV is not null) Array.Clear(_bonusEV);
        }

        public void Copy(BJCAHandEVsClass originalHand)
        {
            Array.Copy(originalHand.Prob, Prob, 11);
            Array.Copy(originalHand.StandEV, StandEV, 11);
            Array.Copy(originalHand.DEV, DEV, 11);
            Array.Copy(originalHand.SurrEV, SurrEV, 11);
            Array.Copy(originalHand.BJStandEV, BJEV, 11);
            Array.Copy(originalHand.BonusEV, BonusEV, 11);
        }
    }
}