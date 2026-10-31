using System;

namespace BJ_CA
{
    [Serializable()]
    public class BJCARulesClass
    {
        public BJCABonusRulesClass BJBonuses = new BJCABonusRulesClass();
        public BJCABonusRulesListClass BonusRulesList = new BJCABonusRulesListClass();
        public BJCAForcedRulesListClass ForcedTableRulesList = new BJCAForcedRulesListClass();
        public BJCAForcedRulesListClass ForcedRulesList = new BJCAForcedRulesListClass();
        public BJCAColorTableClass ColorTable = new BJCAColorTableClass();

        public bool InfiniteDecks;
        public BJCAShoeClass Shoe = new BJCAShoeClass();

        public double BJPays;
        public int StandOnSoft;

        public bool ENHC;
        public bool BBO;
        public bool OBBO;
        public bool AOBBO;
        public bool CheckAce;
        public bool CheckTen;

        public bool[,,] DoubleTable = new bool[22, 4, 2]; // Total, 2CH-MultiH-2CS-MultiS, Pre/Post Split
        public bool DAS;
        public bool DSoftAllHard;
        public bool DSoft19Hard;
        public bool DSA;
        public bool DDR;       // Double down rescue
        public bool DDRPS;     // Double down rescue Post-Split
        public int DDRType;
        public bool RDA;       // Redoubling allowed
        public bool RDAPS;     // Redoubling allowed Post-Split
        public int RDDepth;   // Redouble Depth

        public int SPL;
        public bool HSA;
        public bool SMA;

        public double SurrPays;
        public double SurrDBJPays;
        public bool SAN;
        public bool SAS;
        public bool SSA;
        public bool MacauSurrender2to10;
        public bool MacauSurrenderAce;
        public int[] SurrenderTable = new int[11];

        public bool BJSPlitAces;
        public bool BJSplitTens;

        public bool[] SplitAllowed = new bool[11];
        public bool CDP;
        public bool CDPN;
        public bool TDPlus;
        public bool TCPlus;

        public bool P21Autowin;
        public double[] PDTies = new double[23];

        public string DeckType;
        public string DoubleType;
        public string SurrType;
        public bool DAN;

        public int ForcednCD;
        public bool ForcedTablePreSplit;
        public bool ForcedTablePostSplit;

        public bool[] UCAllowed = new bool[11];

        public bool ComputeTD;
        public bool ComputeTC;
        public bool ComputeForced;
        public bool PrintPSExceptions;
        public bool UseDPDictionary;
        public bool SaveDPDictionary;

        public string OutputPath;
        public string ExcelFilePath;
        public string ProbsPath;

    }
}