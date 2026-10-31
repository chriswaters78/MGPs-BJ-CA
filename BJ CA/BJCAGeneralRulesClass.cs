using System;

namespace BJ_CA
{
    [Serializable()]
    public class BJCAGeneralRulesClass
    {
        public bool FiniteDecks;
        public bool InfiniteDecks;
        public bool UseForcedShoe;
        public int NDecks;
        public bool SpanishDecks;

        public float BJPays;
        public bool S17;
        public bool S18;

        public bool OBO;
        public bool ENHC;
        public bool BBO;
        public bool OBBO;
        public bool AOBBO;
        public bool UseDefault;
        public bool CheckAce;
        public bool CheckTen;

        public bool DAS;
        public bool DAN;
        public bool DOA;
        public bool D91011;
        public bool D1011;
        public bool UseDTable;
        public bool DDR;      // Double down rescue
        public bool DDRPS;    // Double down rescue Post-Split
        public int DDRType;
        public bool RDA;      // Redoubling allowed
        public bool RDAPS;    // Redoubling allowed Post-Split
        public int RDDepth;  // Redouble Depth

        public bool NS;
        public bool LS;
        public bool ES;
        public bool ES10;
        public bool UseSTable;
        public float SurrPays;

        public bool SPL0;
        public bool SPL1;
        public bool SPL2;
        public bool SPL3;
        public bool HSA;
        public bool SMA;

        public bool DSoftAllHard;
        public bool DSoft19Hard;
        public bool DSA;

        public float SurrDBJPays;
        public bool SAN;
        public bool SAS;
        public bool SSA;
        public bool MacauSurrender2to10;
        public bool MacauSurrenderAce;
        public int SurrToggleAll;
        public int[] SurrComboValueArray = new int[10];

        public bool BJSPlitAces;
        public bool BJSplitTens;
        public bool SpToggleAll;
        public bool[] SpCheckValueArray = new bool[10];
        public bool CDZ;
        public bool CDP;
        public bool CDPN;
        public bool TDPlus;
        public bool TCPlus;

        public bool P21Autowin;
        public int PDTiesToggleAll;
        public float[] PDTiesValueArray = new float[6];
        public int[] PDTiesComboValueArray = new int[6];

        public float RefDecks;

        public BJCABonusRulesClass BJBonuses = new BJCABonusRulesClass();

        public bool UCToggleAll;
        public bool[] UCCheckValueArray = new bool[10];

        public bool ComputeTD;
        public bool ComputeTC;
        public bool ComputeForced;
        public bool PrintPSExceptions;
        public bool UseDPDictionary;
        public bool SaveDPDictionary;
        public bool RTSPL1Est;
        public bool RTSmall;

    }
}