using System;

namespace BJ_CA
{
    [Serializable()]
    public class BJCAEORsClass
    {
        public double ForcedNetGameEV;
        public double ForcedNetGameEVEOR;
        public BJCATDStratClass[,] ForcedStratTD = new BJCATDStratClass[22, 2];

        public double CDNetGameEV;
        public double CDNetGameEVEOR;

        public double TDNetGameEV;
        public double TDNetGameEVEOR;
        public BJCATDStratClass[,] TDStratTD = new BJCATDStratClass[22, 2];

        public BJCAEOREVsClass[] EVs = new BJCAEOREVsClass[3085];
    }

    [Serializable()]
    public class BJCAEOREVsClass
    {
        public double[] StandEV = new double[11];                // Upcard     Stand EV's relative to each dealer upcard
        public double[] StandPushEV = new double[11];            // Upcard     EV of pushing; can be used for special rules and variance
        public double[] DEV = new double[11];                    // Upcard     Double EV's relative to each dealer upcard
        public double[] DPushEV = new double[11];                // Upcard     EV of pushing; can be used for special rules and variance
        public double[] SurrEV = new double[11];                 // Upcard     Surrender EV's relative to each dealer upcard

        public int[] ForcedStrat = new int[11];           // Hit EV for given strategy
        public double[] ForcedHitEV = new double[11];            // Hit EV for given strategy
        public double[] ForcedHitPushEV = new double[11];        // Hit Push EV for given strategy
        public double[] ForcedSplitEV = new double[11];          // EV based on the number of splits allowed

        public int[] CDStrat = new int[11];               // Hit EV for given strategy
        public double[] CDHitEV = new double[11];                // Hit EV for given strategy
        public double[] CDHitPushEV = new double[11];            // Hit Push EV for given strategy
        public double[] CDSplitEV = new double[11];              // EV based on the number of splits allowed

        public int[] TDStrat = new int[11];               // Hit EV for given strategy
        public double[] TDHitEV = new double[11];                // Hit EV for given strategy
        public double[] TDHitPushEV = new double[11];            // Hit Push EV for given strategy
        public double[] TDSplitEV = new double[11];              // EV based on the number of splits allowed
    }
}