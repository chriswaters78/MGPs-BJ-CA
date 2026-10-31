using System;
using static BJ_CA.BJCAShared;

namespace BJ_CA
{

    [Serializable()]
    public class BJCABonusRulesClass
    {
        public string Name;
        public bool RuleOn;
        public bool UseSpecificHand;

        public BJCAHandClass Hand = new BJCAHandClass();
        public bool HardSoftOnly;
        public bool HardOnly;
        public bool SoftOnly;
        public bool ExactMatch;
        public bool OrMore;
        public bool OrLess;
        public bool SpecificTen;
        public double SpecificTenFraction;

        public double PayoffGeneral;
        public double PayoffSuited;
        public double PayoffSpecificSuit;

        public double PayoffGeneralBJ;
        public double PayoffSuitedBJ;
        public double PayoffSpecificSuitBJ;
        public bool BJAUp;
        public bool BJTUp;

        public double PayoffUCGeneral;
        public double PayoffUCSuited;
        public double PayoffUCSpecificSuit;

        public int Upcard;

        public bool Suited;
        public bool SpecificSuit;
        public int SuitToWin;

        public bool MustWin;
        public bool HandContinues;
        public bool PreSplit;
        public bool PostSplit;

        public int Index;

        public BJCABonusRulesClass()
        {
            Name = "";
            RuleOn = false;
            UseSpecificHand = false;

            Hand.Empty();
            HardSoftOnly = false;
            HardOnly = true;
            SoftOnly = false;
            OrMore = false;
            OrLess = false;
            ExactMatch = true;
            SpecificTen = false;
            SpecificTenFraction = 0.25d;

            PayoffGeneral = 1d;
            PayoffSuited = 0d;
            PayoffSpecificSuit = 0d;
            PayoffGeneralBJ = -1;
            PayoffSuitedBJ = -1;
            PayoffSpecificSuitBJ = -1;
            BJAUp = true;
            BJTUp = true;

            PayoffUCGeneral = 0d;
            PayoffUCSuited = 0d;
            PayoffUCSpecificSuit = 0d;
            Upcard = 0;

            Suited = false;
            SpecificSuit = false;
            SuitToWin = 0;

            MustWin = false;
            HandContinues = false;
            PreSplit = true;
            PostSplit = false;

            Index = -1;
        }

        public void Empty()
        {
            Name = "";
            RuleOn = false;
            UseSpecificHand = false;

            Hand.Empty();
            HardSoftOnly = false;
            HardOnly = false;
            SoftOnly = false;
            OrMore = false;
            OrLess = false;
            ExactMatch = true;
            SpecificTen = false;
            SpecificTenFraction = 0.25d;

            PayoffGeneral = 1d;
            PayoffSuited = 0d;
            PayoffSpecificSuit = 0d;
            PayoffGeneralBJ = -1;
            PayoffSuitedBJ = -1;
            PayoffSpecificSuitBJ = -1;
            BJAUp = true;
            BJTUp = true;

            PayoffUCGeneral = 0d;
            PayoffUCSuited = 0d;
            PayoffUCSpecificSuit = 0d;
            Upcard = 0;

            Suited = false;
            SpecificSuit = false;
            SuitToWin = 0;

            MustWin = false;
            HandContinues = false;
            PreSplit = true;
            PostSplit = false;

            Index = -1;
        }

    }

    [Serializable()]
    public class BJCABonusRulesListClass
    {
        public int NumRules;
        public BJCABonusRulesClass[] L;

        public BJCABonusRulesListClass()
        {
            NumRules = 0;
        }

        public void Empty()
        {
            int rule;

            var loopTo = NumRules - 1;
            for (rule = 0; rule <= loopTo; rule++)
                L[rule] = null;
            L = new BJCABonusRulesClass[1];
            NumRules = 0;
        }

        public void AddBonusRule(BJCABonusRulesClass newRule)
        {
            NumRules += 1;
            Array.Resize(ref L, NumRules);
            L[NumRules - 1] = new BJCABonusRulesClass();
            L[NumRules - 1] = (BJCABonusRulesClass)CloneObject(newRule);
            L[NumRules - 1].Index = NumRules - 1;
        }

        public void DeleteBonusRule(int index)
        {
            int rule;

            var loopTo = NumRules - 1;
            for (rule = index + 1; rule <= loopTo; rule++)
            {
                L[rule].Index -= 1;
                L[rule - 1] = L[rule];
            }
            L[NumRules - 1] = null;
            NumRules -= 1;
            Array.Resize(ref L, NumRules);
        }

        public void MoveBonusRuleUp(int currentIndex)
        {
            var tempRule = new BJCABonusRulesClass();

            if (currentIndex > 0 & NumRules > 1)
            {
                // First move the index
                L[currentIndex].Index -= 1;
                L[currentIndex - 1].Index += 1;

                // Then move the actual rule
                tempRule = L[currentIndex];
                L[currentIndex] = L[currentIndex - 1];
                L[currentIndex - 1] = tempRule;

            }
        }

        public void MoveBonusRuleDown(int currentIndex)
        {
            var tempRule = new BJCABonusRulesClass();

            if (currentIndex < NumRules - 1 & NumRules > 1)
            {
                // First move the index
                L[currentIndex].Index += 1;
                L[currentIndex + 1].Index -= 1;

                // Then move the actual rule
                tempRule = L[currentIndex];
                L[currentIndex] = L[currentIndex + 1];
                L[currentIndex + 1] = tempRule;
            }
        }

    }

    [Serializable()]
    public class BJCASuitedBonusEVClass
    {
        public double[] SuitedNetEV = new double[11];
        public double[] SuitedNetBJEV = new double[11];
        public double[,] SuitedStratEV = new double[11, 5];
        public double[,] SuitedStratBJEV = new double[11, 5];
        public int[,] SuitedStrat = new int[11, 5];

        public double[,] SuitedStandEV = new double[11, 5];
        public double[,] SuitedStandBJEV = new double[11, 5];
        public double[,] SuitedHitEV = new double[11, 5];
        public double[,] SuitedHitBJEV = new double[11, 5];

        public double[,] SuitedBonusEV = new double[11, 5];

        public BJCASuitedBonusEVClass()
        {
            int card;
            int suit;

            for (card = 0; card <= 10; card++)
            {
                SuitedNetEV[card] = 0d;
                SuitedNetBJEV[card] = 0d;
                for (suit = 0; suit <= 4; suit++)
                {
                    SuitedStrat[card, suit] = 0;
                    SuitedStratEV[card, suit] = 0d;

                    SuitedStandEV[card, suit] = 0d;
                    SuitedHitEV[card, suit] = 0d;

                    SuitedBonusEV[card, suit] = 0d;

                    if (card == 1 | card == 10)
                    {
                        SuitedStratBJEV[card, suit] = 0d;
                        SuitedStandBJEV[card, suit] = 0d;
                        SuitedHitBJEV[card, suit] = 0d;
                    }
                }
            }
        }


        public void Empty()
        {
            int card;
            int suit;

            for (card = 0; card <= 10; card++)
            {
                SuitedNetEV[card] = 0d;
                SuitedNetBJEV[card] = 0d;
                for (suit = 0; suit <= 4; suit++)
                {
                    SuitedStrat[card, suit] = 0;
                    SuitedStratEV[card, suit] = 0d;

                    SuitedStandEV[card, suit] = 0d;
                    SuitedHitEV[card, suit] = 0d;

                    SuitedBonusEV[card, suit] = 0d;

                    if (card == 1 | card == 10)
                    {
                        SuitedStratBJEV[card, suit] = 0d;
                        SuitedStandBJEV[card, suit] = 0d;
                        SuitedHitBJEV[card, suit] = 0d;
                    }
                }
            }
        }

    }
}