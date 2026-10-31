using System;
using static BJ_CA.BJCAShared;

namespace BJ_CA
{

    [Serializable()]
    public class BJCAForcedRulesClass
    {
        public string Name;
        public bool RuleOn;
        public bool UseSpecificHand;

        public BJCAHandClass Hand = new BJCAHandClass();
        public bool ExactMatch;

        public bool OrMore;
        public bool OrLess;

        public bool PreSplit;
        public bool PostSplit;

        public int Upcard;
        public int Strat;

        public int Index;

        public BJCAForcedRulesClass()
        {
            Name = "";
            RuleOn = false;
            UseSpecificHand = false;

            Hand.Empty();
            ExactMatch = true;

            OrMore = false;
            OrLess = false;

            PreSplit = true;
            PostSplit = true;

            Upcard = 0;
            Strat = 0;

            Index = -1;
        }

        public void Empty()
        {
            Name = "";
            RuleOn = false;
            UseSpecificHand = false;

            Hand.Empty();
            ExactMatch = true;

            OrMore = false;
            OrLess = false;

            PreSplit = true;
            PostSplit = true;

            Upcard = 0;
            Strat = 0;

            Index = -1;
        }

    }

    [Serializable()]
    public class BJCAForcedRulesListClass
    {
        public int NumRules;
        public BJCAForcedRulesClass[] L;

        public BJCAForcedRulesListClass()
        {
            NumRules = 0;
        }

        public void Empty()
        {
            int rule;

            var loopTo = NumRules - 1;
            for (rule = 0; rule <= loopTo; rule++)
                L[rule] = null;
            L = new BJCAForcedRulesClass[1];
            NumRules = 0;
        }

        public void AddForcedRule(BJCAForcedRulesClass newRule)
        {
            NumRules += 1;
            Array.Resize(ref L, NumRules);
            L[NumRules - 1] = new BJCAForcedRulesClass();
            L[NumRules - 1] = (BJCAForcedRulesClass)CloneObject(newRule);
            L[NumRules - 1].Index = NumRules - 1;
        }

        public void DeleteForcedRule(int index)
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

        public void MoveForcedRuleUp(int currentIndex)
        {
            var tempRule = new BJCAForcedRulesClass();

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

        public void MoveForcedRuleDown(int currentIndex)
        {
            var tempRule = new BJCAForcedRulesClass();

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
    public class BJCAForcedRulesTableClass
    {
        public int ForcednCD;
        public bool ForcedTablePreSplit;
        public bool ForcedTablePostSplit;

        public BJCAForcedRulesListClass ForcedTableRulesList = new BJCAForcedRulesListClass();
    }

    [Serializable()]
    public class BJCAForcedRulesStratClass
    {
        public int ForcednCD;
        public bool ForcedTablePreSplit;
        public bool ForcedTablePostSplit;

        public BJCAForcedRulesListClass ForcedRulesList = new BJCAForcedRulesListClass();
        public BJCAForcedRulesListClass ForcedTableRulesList = new BJCAForcedRulesListClass();
    }
}