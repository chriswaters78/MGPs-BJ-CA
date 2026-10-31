using System;

namespace BJ_CA
{
    [Serializable()]
    public class BJCAStrategyClass
    {
        public string Name;
        public int NCardsCD;
        public bool ComputeStrat;
        public bool NCardOn;

        public BJCAHandStrategyClass[] HandEVs = new BJCAHandStrategyClass[3085];    // 3072 = Max hands without busting (10 1 card, 2 0 hands)
        public BJCASplitStateStrategyClass[,] SplitStateEVs = new BJCASplitStateStrategyClass[11, 11];
        public BJCAGameEVsClass GameEVs = new BJCAGameEVsClass();
        public BJCATDStratClass[,] StratTD = new BJCATDStratClass[22, 2];
    }

    [Serializable()]
    public class BJCAHandStrategyClass
    {
        // Strategies allowed by the forced rules
        public bool[] SPreallowed = new bool[11];     // Stand Allowed Pre-Split
        public bool[] DPreallowed = new bool[11];     // Double Allowed Pre-Split
        public bool[] HPreallowed = new bool[11];     // Hit Allowed Pre-Split
        public int[] RPreallowed = new int[11];     // Surrender Allowed Pre-Split
        public bool[] PAllowed = new bool[11];        // Split Allowed

        public bool[] SPostallowed = new bool[11];    // Stand Allowed Post-Split
        public bool[] DPostallowed = new bool[11];    // Double Allowed Post-Split
        public bool[] HPostallowed = new bool[11];    // Hit Allowed Post-Split
        public int[] RPostallowed = new int[11];    // Surrender Allowed Post-Split

        public BJCAHandStrategyEVsClass EVs = new BJCAHandStrategyEVsClass();
        public bool[] PreForced = new bool[11];
        public bool[] PostForced = new bool[11];
        public int[] HandUsed = new int[11];        // Is the hand used for the given strategy
        public int[] Multiplier = new int[11];      // How often is the hand encountered for the given strategy

        // Public HandUsedPost(10) As Integer              'Is the hand used after splitting
        // Public MultiplierPost(10, 10) As Integer        'Paircard, Upcard      Post-Split Multiplier

        public double[] SplitEV = new double[11];          // EV based on the number of splits allowed
        public double[,] SPLEV = new double[11, 4];         // All SPL EV's up to the number of splits allowed
        public BJCAHandStrategyEVsClass[,] SplitData = new BJCAHandStrategyEVsClass[7, 11];     // Paircard, Split Shoe State      Holds split hand probs

        public BJCAHandStrategyClass()
        {
            int upcard;
            int paircard;

            for (upcard = 1; upcard <= 10; upcard++)
            {
                SPreallowed[upcard] = true;
                DPreallowed[upcard] = true;
                HPreallowed[upcard] = true;

                SPostallowed[upcard] = true;
                HPostallowed[upcard] = true;

                // For paircard = 1 To 10
                // MultiplierPost(paircard, upcard) = 1
                // Next paircard
            }
        }
    }

    [Serializable()]
    public class BJCAHandStrategyEVsClass
    {
        public int[] Strat = new int[11];             // Strategy of hand for given strategy
        public int[] ForcedPostStrat = new int[11];   // Forced Post-Split Strategy of hand
        public double[] StratEV = new double[11];            // EV of hand for given strategy
        public double[] StratPushEV = new double[11];        // EV of push for given strategy

        public double[] HitEV = new double[11];              // Hit EV for given strategy
        public double[] HitPushEV = new double[11];          // Hit Push EV for given strategy
    }

    [Serializable()]
    public class BJCATDStratClass
    {
        public int[] Strat = new int[11];
        public double[] NetProb = new double[11];
        // Public Forced(10) As Boolean

        public double[] NetSProb = new double[11];
        public double[] NetHProb = new double[11];
        public double[] NetDProb = new double[11];
        public double[] NetSurrProb = new double[11];

        public double[] SStandEV = new double[11];
        public double[] SHitEV = new double[11];
        public double[] SDEV = new double[11];
        public double[] SSurrEV = new double[11];

        public double[] StratEV = new double[11];
        public double[] StratStandEV = new double[11];
        public double[] StratDEV = new double[11];
        public double[] StratSurrEV = new double[11];
        public double[] StratHitEV = new double[11];

        public int[] NCardDeviation = new int[11];
        public int[] NCardStrat = new int[11];
    }

    [Serializable()]
    public class BJCAGameEVsClass
    {
        public double NetGameEV;
        public double[] CardProbs = new double[11];
        public double[] FirstCardEVs = new double[11];
        public double[] UpcardEVs = new double[11];
    }
}