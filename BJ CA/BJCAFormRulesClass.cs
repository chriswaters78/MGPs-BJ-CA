using System;
using System.Drawing;
using static BJ_CA.BJCAShared;

namespace BJ_CA
{

    [Serializable()]
    public class BJCAFormRulesClass
    {

        #region  Declarations 

        // Bonus Rules Declarations
        public BJCABonusRulesListClass BonusRulesList = new BJCABonusRulesListClass();
        public BJCABonusRulesListClass DefaultBonusRulesList = new BJCABonusRulesListClass();

        // Forced Rules Declarations
        public BJCAForcedRulesStratClass ForcedStrat = new BJCAForcedRulesStratClass();
        public BJCAForcedRulesListClass DefaultForcedRulesList = new BJCAForcedRulesListClass();

        // Other Declarations
        public BJCAGeneralRulesClass General = new BJCAGeneralRulesClass();
        public BJCAGeneralRulesClass DefaultGeneralRules = new BJCAGeneralRulesClass();

        public BJCADoubleTableClass DoubleTable = new BJCADoubleTableClass();
        public BJCAShoeClass ForcedShoe = new BJCAShoeClass();
        public BJCAColorTableClass ColorTable = new BJCAColorTableClass();
        public BJCAColorTableClass DefaultColorTable = new BJCAColorTableClass();
        public int[] PDTies = new int[23];                  // 0=Player Wins  1=Push  2=Dealer Wins
        public BJCAFileSetClass FileNames = new BJCAFileSetClass();

        #endregion

        public BJCAFormRulesClass()
        {
            DefineDefaultGeneralRules();
            DefineDefaultBonusRules();
            DefineDefaultForcedStrat();
            DefineDefaultPDTies();
            DefineDefaultColorTable();

            General = (BJCAGeneralRulesClass)CloneObject(DefaultGeneralRules);
            BonusRulesList = (BJCABonusRulesListClass)CloneObject(DefaultBonusRulesList);
            ForcedStrat.ForcedRulesList = (BJCAForcedRulesListClass)CloneObject(DefaultForcedRulesList);
            ColorTable = (BJCAColorTableClass)CloneObject(DefaultColorTable);


        }

        #region  Default Definitions 

        public void DefineDefaultGeneralRules()
        {
            int i;

            {
                ref var withBlock = ref DefaultGeneralRules;
                withBlock.FiniteDecks = true;
                withBlock.InfiniteDecks = false;
                withBlock.UseForcedShoe = false;
                withBlock.NDecks = 1;

                withBlock.BJPays = 1.5f;
                withBlock.S17 = true;
                withBlock.S18 = false;

                withBlock.OBO = true;
                withBlock.ENHC = false;
                withBlock.BBO = false;
                withBlock.OBBO = false;
                withBlock.AOBBO = false;
                withBlock.UseDefault = true;
                withBlock.CheckAce = true;
                withBlock.CheckTen = true;

                withBlock.DAS = true;
                withBlock.DAN = false;
                withBlock.DOA = true;
                withBlock.D91011 = false;
                withBlock.D1011 = false;
                withBlock.UseDTable = false;

                withBlock.NS = true;
                withBlock.LS = false;
                withBlock.ES = false;
                withBlock.ES10 = false;
                withBlock.UseSTable = false;
                withBlock.SurrPays = (float)-0.5d;

                withBlock.SPL0 = false;
                withBlock.SPL1 = false;
                withBlock.SPL2 = false;
                withBlock.SPL3 = true;
                withBlock.HSA = false;
                withBlock.SMA = false;

                withBlock.DSoftAllHard = false;
                withBlock.DSoft19Hard = false;
                withBlock.DSA = false;
                withBlock.DDR = false;
                withBlock.DDRType = 1;
                withBlock.DDRPS = false;
                withBlock.RDA = false;
                withBlock.RDAPS = false;
                withBlock.RDDepth = 1;

                withBlock.SAN = false;
                withBlock.SAS = false;
                withBlock.SurrDBJPays = (float)-0.5d;
                withBlock.SSA = false;
                withBlock.MacauSurrender2to10 = false;
                withBlock.MacauSurrenderAce = false;
                withBlock.SurrToggleAll = 0;
                for (i = 0; i <= 9; i++)
                    withBlock.SurrComboValueArray[i] = 0;

                withBlock.BJSPlitAces = false;
                withBlock.BJSplitTens = false;
                withBlock.SpToggleAll = true;
                for (i = 0; i <= 9; i++)
                    withBlock.SpCheckValueArray[i] = true;
                withBlock.CDZ = true;
                withBlock.CDP = false;
                withBlock.CDPN = false;
                withBlock.TDPlus = false;
                withBlock.TCPlus = false;

                withBlock.P21Autowin = false;
                withBlock.PDTiesToggleAll = 0;
                for (i = 0; i <= 5; i++)
                {
                    withBlock.PDTiesComboValueArray[i] = 0;
                    withBlock.PDTiesValueArray[i] = 0f;
                }

                withBlock.RefDecks = 6f;
                withBlock.SpanishDecks = false;

                withBlock.BJBonuses.Empty();
                // .BJBonuses.SpecificTenFraction     Holds Spec10Bonus Specific 10 Fraction
                // .BJBonuses.PayoffBJ                Holds Spec10Bonus Payoff
                // .BJBonuses.PayoffGeneral           Holds Spec10Bonus Suited Payoff
                // .BJBonuses.PayoffUC                Holds Spec10Bonus Specific Suit Payoff
                // .BJBonuses.Upcard                  Holds Spec10Bonus Suit to Win
                withBlock.BJBonuses.SpecificTenFraction = 0.25d;
                withBlock.BJBonuses.PayoffGeneralBJ = 0d;
                withBlock.BJBonuses.PayoffGeneral = 0d;
                withBlock.BJBonuses.PayoffUCGeneral = 0d;
                withBlock.BJBonuses.Upcard = 0;

                withBlock.UCToggleAll = true;
                for (i = 0; i <= 9; i++)
                    withBlock.UCCheckValueArray[i] = true;

                withBlock.ComputeTD = true;
                withBlock.ComputeTC = true;
                withBlock.ComputeForced = true;
                withBlock.PrintPSExceptions = false;
                withBlock.UseDPDictionary = true;
                withBlock.SaveDPDictionary = true;
                withBlock.RTSPL1Est = true;
                withBlock.RTSmall = false;
            }

        }

        private void DefineDefaultBonusRules()
        {
            DefaultBonusRulesList.NumRules = 9;
            DefaultBonusRulesList.L = new BJCABonusRulesClass[DefaultBonusRulesList.NumRules];

            DefaultBonusRulesList.L[0] = new BJCABonusRulesClass();
            DefaultBonusRulesList.L[1] = new BJCABonusRulesClass();
            DefaultBonusRulesList.L[2] = new BJCABonusRulesClass();
            DefaultBonusRulesList.L[3] = new BJCABonusRulesClass();
            DefaultBonusRulesList.L[4] = new BJCABonusRulesClass();
            DefaultBonusRulesList.L[5] = new BJCABonusRulesClass();
            DefaultBonusRulesList.L[6] = new BJCABonusRulesClass();
            DefaultBonusRulesList.L[7] = new BJCABonusRulesClass();
            DefaultBonusRulesList.L[8] = new BJCABonusRulesClass();

            {
                ref var withBlock = ref DefaultBonusRulesList.L[0];
                withBlock.Name = "5-card Charlie";
                withBlock.RuleOn = false;
                withBlock.UseSpecificHand = false;

                withBlock.Hand.NumCards = 5;
                withBlock.Hand.Soft = false;
                withBlock.HardSoftOnly = false;
                withBlock.HardOnly = true;
                withBlock.SoftOnly = false;
                withBlock.OrMore = true;
                withBlock.OrLess = false;

                withBlock.ExactMatch = true;
                withBlock.SpecificTen = false;
                withBlock.SpecificTenFraction = 0.25d;

                withBlock.PayoffGeneral = 1d;
                withBlock.PayoffSuited = 0d;
                withBlock.PayoffSpecificSuit = 0d;
                withBlock.PayoffGeneralBJ = -1;
                withBlock.PayoffSuitedBJ = -1;
                withBlock.PayoffSpecificSuitBJ = -1;
                withBlock.BJAUp = true;
                withBlock.BJTUp = true;

                withBlock.PayoffUCGeneral = 0d;
                withBlock.PayoffUCSuited = 0d;
                withBlock.PayoffUCSpecificSuit = 0d;
                withBlock.Upcard = 0;

                withBlock.Suited = false;
                withBlock.SpecificSuit = false;
                withBlock.SuitToWin = 0;

                withBlock.MustWin = false;
                withBlock.HandContinues = false;
                withBlock.PreSplit = true;
                withBlock.PostSplit = false;
                withBlock.Index = 0;

            }

            {
                ref var withBlock1 = ref DefaultBonusRulesList.L[1];
                withBlock1.Name = "6-card Charlie";
                withBlock1.RuleOn = false;
                withBlock1.UseSpecificHand = false;

                withBlock1.Hand.NumCards = 6;
                withBlock1.Hand.Soft = false;
                withBlock1.HardSoftOnly = false;
                withBlock1.HardOnly = true;
                withBlock1.SoftOnly = false;
                withBlock1.OrMore = true;
                withBlock1.OrLess = false;

                withBlock1.ExactMatch = true;
                withBlock1.SpecificTen = false;
                withBlock1.SpecificTenFraction = 0.25d;

                withBlock1.PayoffGeneral = 1d;
                withBlock1.PayoffSuited = 0d;
                withBlock1.PayoffSpecificSuit = 0d;
                withBlock1.PayoffGeneralBJ = -1;
                withBlock1.PayoffSuitedBJ = -1;
                withBlock1.PayoffSpecificSuitBJ = -1;
                withBlock1.BJAUp = true;
                withBlock1.BJTUp = true;

                withBlock1.PayoffUCGeneral = 0d;
                withBlock1.PayoffUCSuited = 0d;
                withBlock1.PayoffUCSpecificSuit = 0d;
                withBlock1.Upcard = 0;

                withBlock1.Suited = false;
                withBlock1.SpecificSuit = false;
                withBlock1.SuitToWin = 0;

                withBlock1.MustWin = false;
                withBlock1.HandContinues = false;
                withBlock1.PreSplit = true;
                withBlock1.PostSplit = false;
                withBlock1.Index = 1;

            }

            {
                ref var withBlock2 = ref DefaultBonusRulesList.L[2];
                withBlock2.Name = "6-7-8";
                withBlock2.RuleOn = false;
                withBlock2.UseSpecificHand = true;

                withBlock2.HardSoftOnly = false;
                withBlock2.HardOnly = true;
                withBlock2.SoftOnly = false;
                withBlock2.OrMore = false;
                withBlock2.OrLess = false;

                withBlock2.ExactMatch = true;
                withBlock2.Hand.Cards[6] = 1;
                withBlock2.Hand.Cards[7] = 1;
                withBlock2.Hand.Cards[8] = 1;
                withBlock2.Hand.NumCards = 3;
                withBlock2.Hand.Total = 21;
                withBlock2.Hand.Soft = false;
                withBlock2.SpecificTen = false;
                withBlock2.SpecificTenFraction = 0.25d;

                withBlock2.PayoffGeneral = 2d;
                withBlock2.PayoffSuited = 0d;
                withBlock2.PayoffSpecificSuit = 0d;
                withBlock2.PayoffGeneralBJ = -1;
                withBlock2.PayoffSuitedBJ = -1;
                withBlock2.PayoffSpecificSuitBJ = -1;
                withBlock2.BJAUp = true;
                withBlock2.BJTUp = true;

                withBlock2.PayoffUCGeneral = 0d;
                withBlock2.PayoffUCSuited = 0d;
                withBlock2.PayoffUCSpecificSuit = 0d;
                withBlock2.Upcard = 0;

                withBlock2.Suited = false;
                withBlock2.SpecificSuit = false;
                withBlock2.SuitToWin = 0;

                withBlock2.MustWin = false;
                withBlock2.HandContinues = false;
                withBlock2.PreSplit = true;
                withBlock2.PostSplit = false;
                withBlock2.Index = 2;

            }

            {
                ref var withBlock3 = ref DefaultBonusRulesList.L[3];
                withBlock3.Name = "7-7-7";
                withBlock3.RuleOn = false;
                withBlock3.UseSpecificHand = true;

                withBlock3.HardSoftOnly = false;
                withBlock3.HardOnly = true;
                withBlock3.SoftOnly = false;
                withBlock3.OrMore = false;
                withBlock3.OrLess = false;

                withBlock3.ExactMatch = true;
                withBlock3.Hand.Cards[7] = 3;
                withBlock3.Hand.NumCards = 3;
                withBlock3.Hand.Total = 21;
                withBlock3.Hand.Soft = false;
                withBlock3.SpecificTen = false;
                withBlock3.SpecificTenFraction = 0.25d;

                withBlock3.PayoffGeneral = 2d;
                withBlock3.PayoffSuited = 0d;
                withBlock3.PayoffSpecificSuit = 0d;
                withBlock3.PayoffGeneralBJ = -1;
                withBlock3.PayoffSuitedBJ = -1;
                withBlock3.PayoffSpecificSuitBJ = -1;
                withBlock3.BJAUp = true;
                withBlock3.BJTUp = true;

                withBlock3.PayoffUCGeneral = 0d;
                withBlock3.PayoffUCSuited = 0d;
                withBlock3.PayoffUCSpecificSuit = 0d;
                withBlock3.Upcard = 0;

                withBlock3.Suited = false;
                withBlock3.SpecificSuit = false;
                withBlock3.SuitToWin = 0;

                withBlock3.MustWin = false;
                withBlock3.HandContinues = false;
                withBlock3.PreSplit = true;
                withBlock3.PostSplit = false;
                withBlock3.Index = 3;

            }

            {
                ref var withBlock4 = ref DefaultBonusRulesList.L[4];
                withBlock4.Name = "5-Card 21";
                withBlock4.RuleOn = false;
                withBlock4.UseSpecificHand = false;

                withBlock4.Hand.NumCards = 5;
                withBlock4.Hand.Total = 21;
                withBlock4.Hand.Soft = false;
                withBlock4.HardSoftOnly = false;
                withBlock4.HardOnly = true;
                withBlock4.SoftOnly = false;
                withBlock4.OrMore = true;
                withBlock4.OrLess = false;

                withBlock4.ExactMatch = true;
                withBlock4.SpecificTen = false;
                withBlock4.SpecificTenFraction = 0.25d;

                withBlock4.PayoffGeneral = 2d;
                withBlock4.PayoffSuited = 0d;
                withBlock4.PayoffSpecificSuit = 0d;
                withBlock4.PayoffGeneralBJ = -1;
                withBlock4.PayoffSuitedBJ = -1;
                withBlock4.PayoffSpecificSuitBJ = -1;
                withBlock4.BJAUp = true;
                withBlock4.BJTUp = true;

                withBlock4.PayoffUCGeneral = 0d;
                withBlock4.PayoffUCSuited = 0d;
                withBlock4.PayoffUCSpecificSuit = 0d;
                withBlock4.Upcard = 0;

                withBlock4.Suited = false;
                withBlock4.SpecificSuit = false;
                withBlock4.SuitToWin = 0;

                withBlock4.MustWin = false;
                withBlock4.HandContinues = false;
                withBlock4.PreSplit = true;
                withBlock4.PostSplit = false;
                withBlock4.Index = 4;

            }

            {
                ref var withBlock5 = ref DefaultBonusRulesList.L[5];
                withBlock5.Name = "5-Card 21 Must Win";
                withBlock5.RuleOn = false;
                withBlock5.UseSpecificHand = false;
                withBlock5.Hand.NumCards = 5;
                withBlock5.Hand.Total = 21;
                withBlock5.Hand.Soft = false;
                withBlock5.HardSoftOnly = false;
                withBlock5.HardOnly = true;
                withBlock5.SoftOnly = false;
                withBlock5.OrMore = true;
                withBlock5.OrLess = false;

                withBlock5.ExactMatch = true;
                withBlock5.SpecificTen = false;
                withBlock5.SpecificTenFraction = 0.25d;

                withBlock5.PayoffGeneral = 2d;
                withBlock5.PayoffSuited = 0d;
                withBlock5.PayoffSpecificSuit = 0d;
                withBlock5.PayoffGeneralBJ = -1;
                withBlock5.PayoffSuitedBJ = -1;
                withBlock5.PayoffSpecificSuitBJ = -1;
                withBlock5.BJAUp = true;
                withBlock5.BJTUp = true;

                withBlock5.PayoffUCGeneral = 0d;
                withBlock5.PayoffUCSuited = 0d;
                withBlock5.PayoffUCSpecificSuit = 0d;
                withBlock5.Upcard = 0;

                withBlock5.Suited = false;
                withBlock5.SpecificSuit = false;
                withBlock5.SuitToWin = 0;

                withBlock5.MustWin = true;
                withBlock5.HandContinues = false;
                withBlock5.PreSplit = true;
                withBlock5.PostSplit = false;
                withBlock5.Index = 5;

            }

            {
                ref var withBlock6 = ref DefaultBonusRulesList.L[6];
                withBlock6.Name = "6-Card 21";
                withBlock6.RuleOn = false;
                withBlock6.UseSpecificHand = false;

                withBlock6.Hand.NumCards = 6;
                withBlock6.Hand.Total = 21;
                withBlock6.Hand.Soft = false;
                withBlock6.HardSoftOnly = false;
                withBlock6.HardOnly = true;
                withBlock6.SoftOnly = false;
                withBlock6.OrMore = true;
                withBlock6.OrLess = false;

                withBlock6.ExactMatch = true;
                withBlock6.SpecificTen = false;
                withBlock6.SpecificTenFraction = 0.25d;

                withBlock6.PayoffGeneral = 2d;
                withBlock6.PayoffSuited = 0d;
                withBlock6.PayoffSpecificSuit = 0d;
                withBlock6.PayoffGeneralBJ = -1;
                withBlock6.PayoffSuitedBJ = -1;
                withBlock6.PayoffSpecificSuitBJ = -1;
                withBlock6.BJAUp = true;
                withBlock6.BJTUp = true;

                withBlock6.PayoffUCGeneral = 0d;
                withBlock6.PayoffUCSuited = 0d;
                withBlock6.PayoffUCSpecificSuit = 0d;
                withBlock6.Upcard = 0;

                withBlock6.Suited = false;
                withBlock6.SpecificSuit = false;
                withBlock6.SuitToWin = 0;

                withBlock6.MustWin = false;
                withBlock6.HandContinues = false;
                withBlock6.PreSplit = true;
                withBlock6.PostSplit = false;
                withBlock6.Index = 6;

            }

            {
                ref var withBlock7 = ref DefaultBonusRulesList.L[7];
                withBlock7.Name = "6-7-8 Suited";
                withBlock7.RuleOn = false;
                withBlock7.UseSpecificHand = true;

                withBlock7.HardSoftOnly = false;
                withBlock7.HardOnly = true;
                withBlock7.SoftOnly = false;
                withBlock7.OrMore = false;
                withBlock7.OrLess = false;

                withBlock7.ExactMatch = true;
                withBlock7.Hand.Cards[6] = 1;
                withBlock7.Hand.Cards[7] = 1;
                withBlock7.Hand.Cards[8] = 1;
                withBlock7.Hand.NumCards = 3;
                withBlock7.Hand.Total = 21;
                withBlock7.Hand.Soft = false;
                withBlock7.SpecificTen = false;
                withBlock7.SpecificTenFraction = 0.25d;

                withBlock7.PayoffGeneral = 2d;
                withBlock7.PayoffSuited = 3d;
                withBlock7.PayoffSpecificSuit = 0d;
                withBlock7.PayoffGeneralBJ = -1;
                withBlock7.PayoffSuitedBJ = -1;
                withBlock7.PayoffSpecificSuitBJ = -1;
                withBlock7.BJAUp = true;
                withBlock7.BJTUp = true;

                withBlock7.PayoffUCGeneral = 0d;
                withBlock7.PayoffUCSuited = 0d;
                withBlock7.PayoffUCSpecificSuit = 0d;
                withBlock7.Upcard = 0;

                withBlock7.Suited = true;
                withBlock7.SpecificSuit = false;
                withBlock7.SuitToWin = 0;

                withBlock7.MustWin = false;
                withBlock7.HandContinues = false;
                withBlock7.PreSplit = true;
                withBlock7.PostSplit = false;
                withBlock7.Index = 2;

            }

            {
                ref var withBlock8 = ref DefaultBonusRulesList.L[8];
                withBlock8.Name = "7-7-7 Suited";
                withBlock8.RuleOn = false;
                withBlock8.UseSpecificHand = true;

                withBlock8.HardSoftOnly = false;
                withBlock8.HardOnly = true;
                withBlock8.SoftOnly = false;
                withBlock8.OrMore = false;
                withBlock8.OrLess = false;

                withBlock8.ExactMatch = true;
                withBlock8.Hand.Cards[7] = 3;
                withBlock8.Hand.NumCards = 3;
                withBlock8.Hand.Total = 21;
                withBlock8.Hand.Soft = false;
                withBlock8.SpecificTen = false;
                withBlock8.SpecificTenFraction = 0.25d;

                withBlock8.PayoffGeneral = 2d;
                withBlock8.PayoffSuited = 3d;
                withBlock8.PayoffSpecificSuit = 0d;
                withBlock8.PayoffGeneralBJ = -1;
                withBlock8.PayoffSuitedBJ = -1;
                withBlock8.PayoffSpecificSuitBJ = -1;
                withBlock8.BJAUp = true;
                withBlock8.BJTUp = true;

                withBlock8.PayoffUCGeneral = 0d;
                withBlock8.PayoffUCSuited = 0d;
                withBlock8.PayoffUCSpecificSuit = 0d;
                withBlock8.Upcard = 0;

                withBlock8.Suited = true;
                withBlock8.SpecificSuit = false;
                withBlock8.SuitToWin = 0;

                withBlock8.MustWin = false;
                withBlock8.HandContinues = false;
                withBlock8.PreSplit = true;
                withBlock8.PostSplit = false;
                withBlock8.Index = 3;

            }

        }

        private void DefineDefaultForcedStrat()
        {
            ForcedStrat.ForcednCD = 2;
            ForcedStrat.ForcedTablePreSplit = true;
            ForcedStrat.ForcedTablePostSplit = true;

            DefineDefaultForcedRules();
        }

        private void DefineDefaultForcedRules()
        {
            DefaultForcedRulesList.NumRules = 1;
            DefaultForcedRulesList.L = new BJCAForcedRulesClass[DefaultForcedRulesList.NumRules];

            DefaultForcedRulesList.L[0] = new BJCAForcedRulesClass();
            // DefaultForcedRulesList.L(1) = New BJCAForcedRulesClass
            // DefaultForcedRulesList.L(2) = New BJCAForcedRulesClass
            // DefaultForcedRulesList.L(3) = New BJCAForcedRulesClass
            // DefaultForcedRulesList.L(4) = New BJCAForcedRulesClass
            // DefaultForcedRulesList.L(5) = New BJCAForcedRulesClass
            // DefaultForcedRulesList.L(6) = New BJCAForcedRulesClass

            {
                ref var withBlock = ref DefaultForcedRulesList.L[0];
                withBlock.Name = "16 v 10 Multicard Stand";
                withBlock.RuleOn = false;
                withBlock.UseSpecificHand = false;

                withBlock.Hand.Total = 16;
                withBlock.Hand.Soft = false;
                withBlock.Hand.NumCards = 3;

                withBlock.ExactMatch = false;

                withBlock.OrMore = true;
                withBlock.OrLess = false;

                withBlock.PreSplit = true;
                withBlock.PostSplit = true;

                withBlock.Upcard = 10;
                withBlock.Strat = 1;
                withBlock.Index = 0;
            }
        }

        public void DefineDefaultPDTies()
        {
            int total;

            for (total = 17; total <= 22; total++)
            {
                PDTies[total] = 0;
                PDTies[total] = 0;
                PDTies[total] = 0;
            }
        }

        public void DefineDefaultColorTable()
        {
            DefaultColorTable.C[(int)BJCAGlobalsClass.Strat.None] = Color.White;            // Blank strategy
            DefaultColorTable.C[(int)BJCAGlobalsClass.Strat.S] = Color.Red;                 // Stand
            DefaultColorTable.C[(int)BJCAGlobalsClass.Strat.D] = Color.Yellow;              // Double, Hit
            DefaultColorTable.C[(int)BJCAGlobalsClass.Strat.DS] = Color.Yellow;             // Double, Stand
            DefaultColorTable.C[(int)BJCAGlobalsClass.Strat.H] = Color.Lime;                // Hit
            DefaultColorTable.C[(int)BJCAGlobalsClass.Strat.R] = Color.HotPink;             // Surrender, Hit
            DefaultColorTable.C[(int)BJCAGlobalsClass.Strat.RS] = Color.HotPink;            // Surrender, Stand
            DefaultColorTable.C[(int)BJCAGlobalsClass.Strat.P] = Color.DeepSkyBlue;          // Split
            DefaultColorTable.C[(int)BJCAGlobalsClass.Strat.PS] = Color.DeepSkyBlue;         // Split, Stand
            DefaultColorTable.C[(int)BJCAGlobalsClass.Strat.PD] = Color.DeepSkyBlue;         // Split, Double
            DefaultColorTable.C[(int)BJCAGlobalsClass.Strat.PH] = Color.DeepSkyBlue;         // Split, Hit
            DefaultColorTable.C[(int)BJCAGlobalsClass.Strat.PR] = Color.DeepSkyBlue;         // Split, Surrender

            DefaultColorTable.C[(int)BJCAGlobalsClass.Strat.xS] = Color.DarkSalmon;         // Don't Stand
            DefaultColorTable.C[(int)BJCAGlobalsClass.Strat.xD] = Color.Khaki;              // Don't Double, Hit
            DefaultColorTable.C[(int)BJCAGlobalsClass.Strat.xH] = Color.YellowGreen;        // Don't Hit
            DefaultColorTable.C[(int)BJCAGlobalsClass.Strat.xR] = Color.PaleVioletRed;      // Don't Surrender, Hit
            DefaultColorTable.C[(int)BJCAGlobalsClass.Strat.xP] = Color.MediumAquamarine;          // Don't Split
        }

        #endregion

    }
}