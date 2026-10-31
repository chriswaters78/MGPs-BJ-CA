using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static BJ_CA.BJCAShared;
using ClosedXML.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace BJ_CA
{

    [Serializable()]
    public class BJCA
    {

        #region  Declarations 
        public bool AOBBO;
        public bool P21AutoWin;
        public int DDRType;

        // Declarations needed for EOR's and Realtime Strategies
        public BJCARulesClass OriginalRules = new BJCARulesClass();

        // Strategy Declarations
        public BJCAStrategyClass Opt = new BJCAStrategyClass();
        public BJCAStrategyClass TD = new BJCAStrategyClass();
        public BJCAStrategyClass TC = new BJCAStrategyClass();
        public BJCAStrategyClass Forced = new BJCAStrategyClass();

        // General Declarations
        public CardProbDelegate CardProb = null;
        public BJCAGlobalsClass C = new BJCAGlobalsClass();

        // Declarations for Probability Arrays
        public double[,,] BJHandNumerator = new double[11, 31, 31];       // Card, Cards Played, Cards in Hand
        public double[,] BJHandDivisor = new double[41, 41];             // Cards played, Cards in hand

        // Player Hand Declarations
        public int NumPHands;                        // Number of possible player hands
        public int[,] PlayerHandTotal = new int[22, 2];           // Count, Soft True/False
        public BJCAPlayerHandClass[] PlayerHands = new BJCAPlayerHandClass[3085];    // 3072 = Max hands without busting (10 1 card, 2 0 hands)
        public BJCAHandClass CurrentPHand = new BJCAHandClass();           // Current player hand
        public int BJIndex;                          // Index of player BJ
        public bool[,] DoubleNeeded = new bool[3085, 11];
        public bool[,] SurrenderNeeded = new bool[3085, 11];

        // Dealer Hand Declarations
        public int NumDHands;                        // Number of possible dealer hands
        public int[] DealerHandTotal = new int[22];              // List of dealer hands with a given count
        public int[,] DealerHandTotalUC = new int[11, 22];        // Upcard, count      Used during splits
        public BJCADealerHandClass[] DealerHands = new BJCADealerHandClass[1741];    // 1740 = Max hands with H17, No check
        public BJCADealerHandClass CurrentDHand = new BJCADealerHandClass();     // Current dealer hand

        // Shoe Declarations
        public BJCAShoeClass CurrentShoe = new BJCAShoeClass();
        public BJCAShoeClass OriginalShoe = new BJCAShoeClass();
        public bool InfiniteDeck;

        // Split Declarations
        public int NSplitHands;                               // Hands used depending on SPL
        public int NSplitCalcs;                               // Number of shoe states needed for splits
        public int[] SplitCalcHands = new int[6];                         // Used to index the shoe states that need to be calculated
        public BJCANPxClass[] NPxHands = new BJCANPxClass[12];                         // Different possible NPx hands
        public int[] NRounds = new int[4];                                // Rounds used depending on SPL
        public BJCASplitProbsClass[,] SplitProbs = new BJCASplitProbsClass[11, 11];            // Hand probs based on Paircard, upcard
        public BJCASplitRoundsClass SplitRounds = new BJCASplitRoundsClass();              // Different possible rounds
        public BJCASplitRoundProbsClass[,] SplitRoundProbs = new BJCASplitRoundProbsClass[11, 11];  // Round probs based on Paircard, upcard

        // Bonus Declarations
        public bool BonusRuleOn;
        public int NSuitedBonusHands;             // Number of hands that a suited bonus directly applies
        public int NSuitedHands;                  // Number of hands that can lead to a suited bonus
        public int[] SuitedBonusHands = new int[3085];        // Array of indices for Suited bonus hands
        public int[] SuitedHandsList = new int[3085];         // Array of indices for hands that can lead to a suited bonus

        // Exceptions Declarations
        public BJCAExceptionListClass ExceptionsList = new BJCAExceptionListClass();
        public BJCANCardExceptionListClass NCardExceptionsList = new BJCANCardExceptionListClass();

        // Rules Declarations
        public int MaxPlayerCards;
        public int MaxDealerCards;

        public double BJPays;
        public int StandOnSoft;
        public double SurrPays;
        public double SurrDBJPays;

        public bool ENHC;
        public bool BBO;
        public bool OBBO;
        public bool CheckAce;
        public bool CheckTen;

        public int SPL;
        public bool HSA;
        public bool SMA;

        public bool DAS;
        public bool SAS;
        public bool SAN;
        public bool DSA;
        public bool DDR;
        public bool DDRPS;
        public bool RDA;
        public bool RDAPS;
        public int RDDepth;

        public bool SSA;
        public string SurrType;
        public string MacauType;
        public bool BJSplitAces;
        public bool BJSplitTens;

        public bool CDP;
        public bool CDPN;
        public bool TDPlus;
        public bool TCPlus;

        public bool DSoftAllHard;
        public bool DSoft19Hard;
        public double[] PDTies = new double[23];

        public string DeckType;
        public string DoubleType;
        public bool DAN;

        public int ForcednCD;
        public bool ForcedTablePreSplit;
        public bool ForcedTablePostSplit;

        public bool[] UCAllowed = new bool[11];
        public bool[] SplitAllowed = new bool[11];
        public int[,] SplitIndex = new int[11, 11];     // paircard, upcard  index of hand = 0 if not enough cards
        public int[,] SplitTotalIndex = new int[22, 2]; // Total, Soft+1     index of paircard if exists

        // Special Rules Declarations
        public BJCABonusRulesClass BJBonuses = new BJCABonusRulesClass();
        public BJCABonusRulesListClass BonusRulesList = new BJCABonusRulesListClass();
        public BJCAForcedRulesListClass ForcedTableRulesList = new BJCAForcedRulesListClass();
        public BJCAForcedRulesListClass ForcedRulesList = new BJCAForcedRulesListClass();
        public BJCAColorTableClass ColorTable = new BJCAColorTableClass();

        public bool PrintPSExceptions;
        public bool UseDPDictionary;
        public bool SaveDPDictionary;

        public string OutputPath;
        public string ExcelFilePath;
        public string ProbsPath;

        public BJCADealerProbsDictionary DealerProbs = new BJCADealerProbsDictionary();

        // Debugging Declarations
        public double RunningTime;
        public double RunningTime2;
        public double RunningTime3;
        #endregion

        #region  BJCA Classes 

        #endregion

        public void Calculate(BJCARulesClass newRules, [Optional] ref BJCADealerProbsDictionary dpDict)
        {
            bool tempBool;
            int i;
            int j;

            GetRules(newRules);
            Initialize(newRules);
            if (UseDPDictionary)
            {
                if (dpDict is null)
                {
                    tempBool = LoadDealerProbsFile(ref DealerProbs, ProbsPath, newRules.StandOnSoft == 17, OriginalRules.DeckType);
                }
                else
                {
                    DealerProbs = dpDict;
                }
            }
            ApplyRulesStrat(newRules);
            ApplyForcedRules();

            ComputeHandProbsPreSplit();

            RunningTime = Environment.TickCount;
            ComputeStand();
            RunningTime = Environment.TickCount - RunningTime;
            ComputeBlackjack();
            ComputeSurrender();
            ComputeDouble();
            ApplyBonusRulesPreSuited();
            ComputeOptInitialStrat();
            ComputeOptHit();

            RunningTime2 = Environment.TickCount;
            InitializeSplits();
            ComputeOptSplit();
            RunningTime2 = Environment.TickCount - RunningTime2;

            RunningTime3 = Environment.TickCount;
            ComputeStrategies();
            RunningTime3 = Environment.TickCount - RunningTime3;

            EnumSuitedBonusHandList();
            EnumSuitedHandList();
            ApplyBJSuitedBonuses();
            ComputeSuitedHandNetEVs(ref Opt);

            ComputeExceptions();
            ComputeNCardExceptions();
            ComputeGameEVs();

            // MsgBox("TD GameEV: " + Chr(9) + CStr(TD.GameEVs.NetGameEV) + Chr(13) + "2C GameEV: " + Chr(9) + CStr(TC.GameEVs.NetGameEV) + Chr(13) + "Forced GameEV: " + Chr(9) + CStr(Forced.GameEVs.NetGameEV) + Chr(13) + "Opt GameEV: " + Chr(9) + CStr(Opt.GameEVs.NetGameEV) + Chr(13) + Chr(13) + "Stand: " + Chr(9) + Chr(9) + CStr(RunningTime / 1000) + Chr(13) + "Split: " + Chr(9) + Chr(9) + CStr(RunningTime2 / 1000) + Chr(13) + "Strategy: " + Chr(9) + CStr(RunningTime3 / 1000), MsgBoxStyle.OKOnly)

            // If a Dealer Probs Dictionary is supplied, it is up to the sender to save it
            if (SaveDPDictionary & dpDict is null)
                tempBool = SaveDealerProbsFile(ref DealerProbs, ProbsPath, StandOnSoft == 17, OriginalRules.DeckType);
        }

        #region  General Methods 

        public delegate double CardProbDelegate(int card, int upcard);

        public double FiniteCardProb(int card, int upcard)
        {
            double FiniteCardProbRet = default;
            if (upcard == 1 & CheckAce)
            {
                // Burn a Non-10 card away for dealer's second card since we know
                // the dealer doesn't have BJ
                if (card == 10)
                {
                    FiniteCardProbRet = CurrentShoe.Cards[10] / (double)(CurrentShoe.CardsLeft - 1);
                }
                else
                {
                    FiniteCardProbRet = (CurrentShoe.Cards[card] - CurrentShoe.Cards[card] / (double)(CurrentShoe.CardsLeft - CurrentShoe.Cards[10])) / (CurrentShoe.CardsLeft - 1);
                }
            }
            else if (upcard == 10 & CheckTen)
            {
                if (card == 1)
                {
                    FiniteCardProbRet = CurrentShoe.Cards[1] / (double)(CurrentShoe.CardsLeft - 1);
                }
                else
                {
                    FiniteCardProbRet = (CurrentShoe.Cards[card] - CurrentShoe.Cards[card] / (double)(CurrentShoe.CardsLeft - CurrentShoe.Cards[1])) / (CurrentShoe.CardsLeft - 1);
                }
            }
            else
            {
                FiniteCardProbRet = CurrentShoe.Cards[card] / (double)CurrentShoe.CardsLeft;
            }

            if (FiniteCardProbRet < 0d)
            {
                FiniteCardProbRet = 0d;
            }

            return FiniteCardProbRet;

        }

        public double InfiniteCardProb(int card, int upcard)
        {
            double InfiniteCardProbRet = default;
            InfiniteCardProbRet = OriginalShoe.Cards[card] / (double)OriginalShoe.CardsLeft;
            return InfiniteCardProbRet;
        }

        private double ConditionalValue(double a, double AB, double pB)
        {
            double ConditionalValueRet = default;
            // EV(A|~B) = (EV(A)- EV(A|B)*p(B))/ (1-p(B))
            // p(A|~B)  = (p(A) - p(A|B)* p(B))/ (1-p(B))

            ConditionalValueRet = (a - AB * pB) / (1d - pB);
            return ConditionalValueRet;
        }

        private void DealPCard(int card)
        {
            CurrentPHand.Deal(card);
            CurrentShoe.Deal(card);
        }

        private void DealDCard(int card)
        {
            CurrentDHand.Hand.Deal(card);
            CurrentShoe.Deal(card);
        }

        private void UndealPCard(int card)
        {
            CurrentPHand.Undeal(card);
            CurrentShoe.Undeal(card);
        }

        private void UndealDCard(int card)
        {
            CurrentDHand.Hand.Undeal(card);
            CurrentShoe.Undeal(card);
        }

        public int FindDealerHand(int Total, BJCAHandClass currentHand)
        {
            int FindDealerHandRet = default;
            int index;
            int card;
            bool handFound;

            index = DealerHandTotal[Total];
            handFound = false;
            while (!handFound && index != 0)
            {
                // Checking numcards first saves a loop if the hand doesn't match
                if (currentHand.NumCards != DealerHands[index].Hand.NumCards)
                {
                    index = DealerHands[index].NextHandTotal;
                }
                else
                {
                    for (card = 1; card <= 10; card++)
                    {
                        if (currentHand.Cards[card] != DealerHands[index].Hand.Cards[card])
                        {
                            index = DealerHands[index].NextHandTotal;
                            handFound = false;
                            break;
                        }
                        handFound = true;
                    }
                }
            }

            FindDealerHandRet = index;
            return FindDealerHandRet;
        }

        public int FindPlayerHand(BJCAHandClass currentHand)
        {
            int FindPlayerHandRet = default;
            int index;
            int card;
            int i;

            // This routine uses a simple loop to find the index of the currenthand
            // It is assumed that impossible hands or busted hands have been pre-screened
            index = 0;
            for (card = 1; card <= 10; card++)
            {
                i = 0;
                while (i < currentHand.Cards[card])
                {
                    index = PlayerHands[index].HitHand[card];
                    i = i + 1;
                }
            }
            FindPlayerHandRet = index;
            return FindPlayerHandRet;
        }

        private double GetHandProb(BJCAHandClass playedHand, BJCAHandClass currentHand, int extracard, double Multiplier)
        {
            double GetHandProbRet = default;
            if (extracard != 0)
            {
                if (BJHandNumerator[extracard, playedHand.Cards[extracard], 1] > 0d)
                {
                    Multiplier = Multiplier * BJHandDivisor[playedHand.NumCards, 1] / BJHandNumerator[extracard, playedHand.Cards[extracard], 1];
                }
                else
                {
                    Multiplier = 0d;
                }
            }
            GetHandProbRet = Multiplier * BJHandNumerator[1, playedHand.Cards[1], currentHand.Cards[1]] * BJHandNumerator[2, playedHand.Cards[2], currentHand.Cards[2]] * BJHandNumerator[3, playedHand.Cards[3], currentHand.Cards[3]] * BJHandNumerator[4, playedHand.Cards[4], currentHand.Cards[4]] * BJHandNumerator[5, playedHand.Cards[5], currentHand.Cards[5]] * BJHandNumerator[6, playedHand.Cards[6], currentHand.Cards[6]] * BJHandNumerator[7, playedHand.Cards[7], currentHand.Cards[7]] * BJHandNumerator[8, playedHand.Cards[8], currentHand.Cards[8]] * BJHandNumerator[9, playedHand.Cards[9], currentHand.Cards[9]] * BJHandNumerator[10, playedHand.Cards[10], currentHand.Cards[10]] / BJHandDivisor[playedHand.NumCards, currentHand.NumCards];









            return GetHandProbRet;
        }

        private bool HandPossible(BJCAHandClass currentHand)
        {
            bool HandPossibleRet = default;
            HandPossibleRet = BJHandNumerator[1, CurrentShoe.Hand.Cards[1], currentHand.Cards[1]] > 0d & BJHandNumerator[2, CurrentShoe.Hand.Cards[2], currentHand.Cards[2]] > 0d & BJHandNumerator[3, CurrentShoe.Hand.Cards[3], currentHand.Cards[3]] > 0d & BJHandNumerator[4, CurrentShoe.Hand.Cards[4], currentHand.Cards[4]] > 0d & BJHandNumerator[5, CurrentShoe.Hand.Cards[5], currentHand.Cards[5]] > 0d & BJHandNumerator[6, CurrentShoe.Hand.Cards[6], currentHand.Cards[6]] > 0d & BJHandNumerator[7, CurrentShoe.Hand.Cards[7], currentHand.Cards[7]] > 0d & BJHandNumerator[8, CurrentShoe.Hand.Cards[8], currentHand.Cards[8]] > 0d & BJHandNumerator[9, CurrentShoe.Hand.Cards[9], currentHand.Cards[9]] > 0d & BJHandNumerator[10, CurrentShoe.Hand.Cards[10], currentHand.Cards[10]] > 0d;








            return HandPossibleRet;
        }

        private bool MultiCardPossible(int card, int nCards)
        {
            bool MultiCardPossibleRet = default;
            if (CurrentShoe.Cards[card] < nCards)
            {
                MultiCardPossibleRet = false;
            }
            else
            {
                CurrentShoe.Deal(card, nCards - 1);
                MultiCardPossibleRet = CardProb(card, 0) > 0d;
                CurrentShoe.Undeal(card, nCards - 1);
            }

            return MultiCardPossibleRet;
        }

        private int GetPostSplitStrat(int preSplitStrat, int paircard, int upcard, BJCAStrategyClass cstrat, BJCAPlayerHandClass pHand)
        {
            int postSplitStrat;

            // PD, PR should not be passed if the rules don't allow it
            if (preSplitStrat == (int)BJCAGlobalsClass.Strat.P)
            {
                preSplitStrat = cstrat.StratTD[pHand.Hand.Total, Conversions.ToInteger(pHand.Hand.Soft) + 1].Strat[upcard];
            }
            postSplitStrat = preSplitStrat;
            if (paircard == 1 & !(HSA | DSA | SSA))
            {
                postSplitStrat = (int)BJCAGlobalsClass.Strat.S;
            }
            else
            {
                switch (preSplitStrat)
                {
                    case (int)BJCAGlobalsClass.Strat.H:
                    case (int)BJCAGlobalsClass.Strat.PH:
                        {
                            if (paircard == 1 & !HSA)
                            {
                                postSplitStrat = (int)BJCAGlobalsClass.Strat.S;
                            }
                            else
                            {
                                postSplitStrat = (int)BJCAGlobalsClass.Strat.H;
                            }

                            break;
                        }
                    case (int)BJCAGlobalsClass.Strat.D:
                    case (int)BJCAGlobalsClass.Strat.PD:
                        {
                            if (paircard == 1 & (!DSA | !pHand.DPostallowed[upcard]))
                            {
                                if (!HSA)
                                {
                                    postSplitStrat = (int)BJCAGlobalsClass.Strat.S;
                                }
                                else
                                {
                                    postSplitStrat = (int)BJCAGlobalsClass.Strat.H;
                                }
                            }
                            else if (!pHand.DPostallowed[upcard])
                            {
                                postSplitStrat = (int)BJCAGlobalsClass.Strat.H;
                            }
                            else
                            {
                                postSplitStrat = (int)BJCAGlobalsClass.Strat.D;
                            }

                            break;
                        }
                    case (int)BJCAGlobalsClass.Strat.DS:
                        {
                            if (paircard == 1 & !DSA | !pHand.DPostallowed[upcard])
                            {
                                postSplitStrat = (int)BJCAGlobalsClass.Strat.S;
                            }
                            else
                            {
                                postSplitStrat = (int)BJCAGlobalsClass.Strat.D;
                            }

                            break;
                        }
                    case (int)BJCAGlobalsClass.Strat.R:
                    case (int)BJCAGlobalsClass.Strat.PR:
                        {
                            if (paircard == 1 & (!SSA | pHand.RPostallowed[upcard] == 0))
                            {
                                if (!HSA)
                                {
                                    postSplitStrat = (int)BJCAGlobalsClass.Strat.S;
                                }
                                else
                                {
                                    postSplitStrat = (int)BJCAGlobalsClass.Strat.H;
                                }
                            }
                            else if (pHand.RPostallowed[upcard] == 0)
                            {
                                postSplitStrat = (int)BJCAGlobalsClass.Strat.H;
                            }
                            else
                            {
                                postSplitStrat = (int)BJCAGlobalsClass.Strat.R;
                            }

                            break;
                        }
                    case (int)BJCAGlobalsClass.Strat.RS:
                        {
                            if (paircard == 1 & !SSA | pHand.RPostallowed[upcard] == 0)
                            {
                                postSplitStrat = (int)BJCAGlobalsClass.Strat.S;
                            }
                            else
                            {
                                postSplitStrat = (int)BJCAGlobalsClass.Strat.R;
                            }

                            break;
                        }
                    case (int)BJCAGlobalsClass.Strat.PS:
                        {
                            postSplitStrat = (int)BJCAGlobalsClass.Strat.S;
                            break;
                        }
                }
            }

            return postSplitStrat;
        }

        private BJCAHandEVsClass GetHandEV(int total, BJCAHandEVsClass handEVs, int upcard, double bjadjprob)
        {
            var newEVs = new BJCAHandEVsClass();
            SetHandEV(total, handEVs, upcard, bjadjprob, newEVs);
            return newEVs;
        }

        // Writes the stand EVs for one upcard into newEVs, leaving its other entries alone.
        private void SetHandEV(int total, BJCAHandEVsClass handEVs, int upcard, double bjadjprob, BJCAHandEVsClass newEVs)
        {
            double win;
            var lose = default(double);
            var push = default(double);

            switch (total)
            {
                case var @case when @case < 17:
                    {
                        lose = handEVs.DealerProbs[upcard, 17 - 17] + handEVs.DealerProbs[upcard, 18 - 17] + handEVs.DealerProbs[upcard, 19 - 17] + handEVs.DealerProbs[upcard, 20 - 17] + handEVs.DealerProbs[upcard, 21 - 17];

                        push = 0d;
                        break;
                    }
                case 17:
                    {
                        lose = handEVs.DealerProbs[upcard, 18 - 17] + handEVs.DealerProbs[upcard, 19 - 17] + handEVs.DealerProbs[upcard, 20 - 17] + handEVs.DealerProbs[upcard, 21 - 17];

                        push = handEVs.DealerProbs[upcard, 17 - 17];
                        break;
                    }
                case 18:
                    {
                        lose = handEVs.DealerProbs[upcard, 19 - 17] + handEVs.DealerProbs[upcard, 20 - 17] + handEVs.DealerProbs[upcard, 21 - 17];
                        push = handEVs.DealerProbs[upcard, 18 - 17];
                        break;
                    }
                case 19:
                    {
                        lose = handEVs.DealerProbs[upcard, 20 - 17] + handEVs.DealerProbs[upcard, 21 - 17];
                        push = handEVs.DealerProbs[upcard, 19 - 17];
                        break;
                    }
                case 20:
                    {
                        lose = handEVs.DealerProbs[upcard, 21 - 17];
                        push = handEVs.DealerProbs[upcard, 20 - 17];
                        break;
                    }
                case 21:
                    {
                        // Player 21 Always wins
                        if (P21AutoWin)
                        {
                            lose = 0d;
                            push = 0d;
                        }
                        else
                        {
                            lose = bjadjprob;
                            push = handEVs.DealerProbs[upcard, 21 - 17] - bjadjprob;
                        }

                        break;
                    }
            }

            win = 1d - push - lose;

            // Apply PDTies now
            newEVs.StandEV[upcard] = win - lose + PDTies[total] * push;
            if (PDTies[total] != 0d)
            {
                newEVs.StandPushEV[upcard] = 0d;
            }
            else
            {
                newEVs.StandPushEV[upcard] = push;
            }

            if ((upcard == 1 & !CheckAce | upcard == 10 & !CheckTen) & total == 21 & P21AutoWin)
            {
                newEVs.BJStandEV[upcard] = 1d;
            }
            else
            {
                newEVs.BJStandEV[upcard] = upcard == 1 | upcard == 10 ? -1 : 0;   // a new BJCAHandEVsClass's value
            }
        }

        #endregion

        #region  Initialization Methods 

        private void GetRules(BJCARulesClass newRules)
        {
            int total;
            int card;

            OriginalRules = (BJCARulesClass)CloneObject(newRules);

            CurrentShoe.Reset(newRules.Shoe);
            OriginalShoe.Reset(newRules.Shoe);

            BJPays = newRules.BJPays;
            StandOnSoft = newRules.StandOnSoft;
            SurrPays = newRules.SurrPays;
            SurrDBJPays = newRules.SurrDBJPays;

            ENHC = newRules.ENHC;
            BBO = newRules.BBO;
            OBBO = newRules.OBBO;
            AOBBO = newRules.AOBBO;
            CheckAce = newRules.CheckAce;
            CheckTen = newRules.CheckTen;

            SPL = newRules.SPL;
            HSA = newRules.HSA;
            SMA = newRules.SMA;

            DAS = newRules.DAS;
            SAS = newRules.SAS;
            DSA = newRules.DSA;
            SSA = newRules.SSA;
            BJSplitAces = newRules.BJSPlitAces;
            BJSplitTens = newRules.BJSplitTens;

            CDP = newRules.CDP;
            CDPN = newRules.CDPN;
            TDPlus = newRules.TDPlus;
            TCPlus = newRules.TCPlus;

            DSoftAllHard = newRules.DSoftAllHard;
            DSoft19Hard = newRules.DSoft19Hard;
            DDR = newRules.DDR;
            DDRPS = newRules.DDRPS;
            DDRType = newRules.DDRType;

            RDA = newRules.RDA;
            RDAPS = newRules.RDAPS;
            RDDepth = newRules.RDDepth;

            P21AutoWin = newRules.P21Autowin;
            for (total = 17; total <= 22; total++)
                PDTies[total] = newRules.PDTies[total];

            ForcednCD = newRules.ForcednCD;
            ForcedTablePreSplit = newRules.ForcedTablePreSplit;
            ForcedTablePostSplit = newRules.ForcedTablePostSplit;
            ForcedTableRulesList = (BJCAForcedRulesListClass)CloneObject(newRules.ForcedTableRulesList);
            ForcedRulesList = (BJCAForcedRulesListClass)CloneObject(newRules.ForcedRulesList);

            SplitAllowed[0] = false;
            for (card = 1; card <= 10; card++)
            {
                if (OriginalShoe.Cards[card] > 0)
                {
                    UCAllowed[card] = newRules.UCAllowed[card];
                    if (OriginalShoe.Cards[card] > 1 & SPL > 0)
                    {
                        SplitAllowed[card] = newRules.SplitAllowed[card];
                    }
                }
                else
                {
                    UCAllowed[card] = false;
                    SplitAllowed[card] = false;
                }
            }

            BonusRulesList = (BJCABonusRulesListClass)CloneObject(newRules.BonusRulesList);
            ColorTable = (BJCAColorTableClass)CloneObject(newRules.ColorTable);
            BJBonuses = (BJCABonusRulesClass)CloneObject(newRules.BJBonuses);

            BonusRuleOn = false;
            if (BonusRulesList.NumRules > 0)
            {
                var loopTo = BonusRulesList.NumRules - 1;
                for (card = 0; card <= loopTo; card++)
                {
                    if (BonusRulesList.L[card].RuleOn)
                    {
                        BonusRuleOn = true;
                        break;
                    }
                }
            }

            Opt.ComputeStrat = true;
            TD.ComputeStrat = newRules.ComputeTD;
            TC.ComputeStrat = newRules.ComputeTC;
            Forced.ComputeStrat = newRules.ComputeForced;
            PrintPSExceptions = newRules.PrintPSExceptions;

            DeckType = newRules.DeckType;
            DoubleType = newRules.DoubleType;
            SurrType = newRules.SurrType;
            DAN = newRules.DAN;

            SAN = newRules.SAN;
            if (newRules.MacauSurrenderAce & newRules.MacauSurrender2to10)
            {
                MacauType = "True";
            }
            else if (newRules.MacauSurrenderAce)
            {
                MacauType = "Ace Only";
            }
            else if (newRules.MacauSurrender2to10)
            {
                MacauType = "2 to 10 Only";
            }
            else
            {
                MacauType = "False";
            }

            OutputPath = newRules.OutputPath;
            ExcelFilePath = newRules.ExcelFilePath;
            ProbsPath = newRules.ProbsPath;

            UseDPDictionary = newRules.UseDPDictionary;
            SaveDPDictionary = newRules.SaveDPDictionary;

        }

        private void Initialize(BJCARulesClass newRules)
        {
            int paircard;
            int upcard;
            int index;

            MaxDealerCards = 22;
            MaxPlayerCards = 22;

            if (newRules.InfiniteDecks)
            {
                CardProb = new CardProbDelegate(InfiniteCardProb);
                InfiniteDeck = true;
            }
            else
            {
                CardProb = new CardProbDelegate(FiniteCardProb);
                InfiniteDeck = false;
            }

            NumPHands = 1;
            NumDHands = 0;
            PlayerHands[0] = new BJCAPlayerHandClass();

            EnumBJHandNumerator(newRules.InfiniteDecks);
            EnumBJHandDivisor(newRules.InfiniteDecks);
            EnumDealerHands();
            EnumPlayerHands(0, 1);
            LinkPlayerHands();
            EnumSplitHands();

            Opt.Name = "CD";
            TD.Name = "TD";
            TC.Name = "TC";
            Forced.Name = "Forced";

            Opt.NCardsCD = 22;
            TD.NCardsCD = 0;
            TC.NCardsCD = 2;
            Forced.NCardsCD = ForcednCD;

            for (paircard = 1; paircard <= 10; paircard++)
            {
                if (SPL > 0 & SplitAllowed[paircard] & CardProb(paircard, 0) > 0d)
                {
                    DealPCard(paircard);
                    if (CardProb(paircard, 0) > 0d)
                    {
                        DealPCard(paircard);
                        index = FindPlayerHand(CurrentPHand);
                        SplitTotalIndex[CurrentPHand.Total, Conversions.ToInteger(CurrentPHand.Soft) + 1] = index;
                        for (upcard = 1; upcard <= 10; upcard++)
                        {
                            if (UCAllowed[upcard] & CardProb(upcard, 0) > 0d)
                            {
                                PlayerHands[index].PAllowed[upcard] = true;
                                SplitIndex[paircard, upcard] = index;
                                Opt.HandEVs[index].PAllowed[upcard] = true;
                                if (TD.ComputeStrat)
                                    TD.HandEVs[index].PAllowed[upcard] = true;
                                if (TC.ComputeStrat)
                                    TC.HandEVs[index].PAllowed[upcard] = true;
                                if (Forced.ComputeStrat)
                                    Forced.HandEVs[index].PAllowed[upcard] = true;
                            }
                            else
                            {
                                SplitIndex[paircard, upcard] = 0;
                            }
                        }
                        UndealPCard(paircard);
                    }
                    else
                    {
                        for (upcard = 1; upcard <= 10; upcard++)
                            SplitIndex[paircard, upcard] = 0;
                    }
                    UndealPCard(paircard);
                }
                else
                {
                    for (upcard = 1; upcard <= 10; upcard++)
                        SplitIndex[paircard, upcard] = 0;
                }
            }
        }

        public bool LoadDealerProbsFile(ref BJCADealerProbsDictionary dpDict, string dpPath, bool s17, string dType, string rtstring = "")
        {
            string standstr;
            bool loaded;

            if (s17)
            {
                standstr = "S17";
            }
            else
            {
                standstr = "H17";
            }

            loaded = true;
            try
            {
                dpDict = (BJCADealerProbsDictionary)LoadObjectFile(dpPath + @"\DealerProbs " + rtstring + dType + " " + standstr + ".dat");
            }
            catch
            {
                loaded = false;
            }

            return loaded;
        }

        public bool SaveDealerProbsFile(ref BJCADealerProbsDictionary dpDict, string dpPath, bool s17, string dType, string rtstring = "")
        {
            string standstr;
            bool saved;

            if (s17)
            {
                standstr = "S17";
            }
            else
            {
                standstr = "H17";
            }

            saved = true;
            try
            {
                SaveObjectFile(dpPath + @"\DealerProbs " + rtstring + dType + " " + standstr + ".dat", dpDict);
            }
            catch
            {
                saved = false;
            }

            return saved;
        }

        private void ApplyRulesStrat(BJCARulesClass newRules, bool postSplit = false)
        {
            int index;
            int upcard;
            int card;

            var loopTo = NumPHands;
            for (index = 1; index <= loopTo; index++)
            {
                if (PlayerHands[index].Hand.NumCards > 1)
                {
                    for (upcard = 1; upcard <= 10; upcard++)
                    {
                        if (UCAllowed[upcard])
                        {
                            // Apply Double rules from Double Table
                            // Total, 2CH-MultiH-2CS-MultiS, Pre/Post Split
                            switch (PlayerHands[index].Hand.NumCards)
                            {
                                case 2:
                                    {
                                        if (PlayerHands[index].Hand.Soft)
                                        {
                                            PlayerHands[index].DPreallowed[upcard] = newRules.DoubleTable[PlayerHands[index].Hand.Total, 2, 0];
                                            PlayerHands[index].DPostallowed[upcard] = newRules.DoubleTable[PlayerHands[index].Hand.Total, 2, 1];
                                        }
                                        else
                                        {
                                            PlayerHands[index].DPreallowed[upcard] = newRules.DoubleTable[PlayerHands[index].Hand.Total, 0, 0];
                                            PlayerHands[index].DPostallowed[upcard] = newRules.DoubleTable[PlayerHands[index].Hand.Total, 0, 1];
                                        }

                                        break;
                                    }
                                case var @case when @case > 2:
                                    {
                                        if (PlayerHands[index].Hand.Soft)
                                        {
                                            PlayerHands[index].DPreallowed[upcard] = newRules.DoubleTable[PlayerHands[index].Hand.Total, 3, 0];
                                            PlayerHands[index].DPostallowed[upcard] = newRules.DoubleTable[PlayerHands[index].Hand.Total, 3, 1];
                                        }
                                        else
                                        {
                                            PlayerHands[index].DPreallowed[upcard] = newRules.DoubleTable[PlayerHands[index].Hand.Total, 1, 0];
                                            PlayerHands[index].DPostallowed[upcard] = newRules.DoubleTable[PlayerHands[index].Hand.Total, 1, 1];
                                        }

                                        break;
                                    }
                            }

                            // Apply surrender rules from Surrender Table and surrender options
                            // Early surrender cannot be available after split if the dealer checks for BJ
                            switch (PlayerHands[index].Hand.NumCards)
                            {
                                case 2:
                                    {
                                        if (newRules.SurrenderTable[upcard] > 0)
                                        {
                                            PlayerHands[index].RPreallowed[upcard] = newRules.SurrenderTable[upcard];
                                            if (newRules.SAS)
                                            {
                                                if (upcard == 1 & CheckAce | upcard == 10 & CheckTen)
                                                {
                                                    PlayerHands[index].RPostallowed[upcard] = (int)BJCAGlobalsClass.Surr.LS;
                                                }
                                                else
                                                {
                                                    PlayerHands[index].RPostallowed[upcard] = newRules.SurrenderTable[upcard];
                                                }
                                            }
                                        }

                                        break;
                                    }
                                case 5:
                                    {
                                        if (upcard > 1 & newRules.MacauSurrender2to10 | upcard == 1 & newRules.MacauSurrenderAce)
                                        {
                                            // Macau is Early Surrender if not checking, otherwise assume LS
                                            if (upcard == 1 & CheckAce | upcard == 10 & CheckTen)
                                            {
                                                PlayerHands[index].RPreallowed[upcard] = (int)BJCAGlobalsClass.Surr.LS;
                                                if (newRules.SAS)
                                                {
                                                    PlayerHands[index].RPostallowed[upcard] = (int)BJCAGlobalsClass.Surr.LS;
                                                }
                                            }
                                            else
                                            {
                                                PlayerHands[index].RPreallowed[upcard] = (int)BJCAGlobalsClass.Surr.ES;
                                                if (newRules.SAS)
                                                {
                                                    PlayerHands[index].RPostallowed[upcard] = (int)BJCAGlobalsClass.Surr.ES;
                                                }
                                            }
                                        }
                                        else if (newRules.SAN & newRules.SurrenderTable[upcard] > 0)
                                        {
                                            PlayerHands[index].RPreallowed[upcard] = newRules.SurrenderTable[upcard];
                                            if (newRules.SAS)
                                            {
                                                if (upcard == 1 & CheckAce | upcard == 10 & CheckTen)
                                                {
                                                    PlayerHands[index].RPostallowed[upcard] = (int)BJCAGlobalsClass.Surr.LS;
                                                }
                                                else
                                                {
                                                    PlayerHands[index].RPostallowed[upcard] = newRules.SurrenderTable[upcard];
                                                }
                                            }
                                        }

                                        break;
                                    }

                                default:
                                    {
                                        if (newRules.SAN & newRules.SurrenderTable[upcard] > 0)
                                        {
                                            if (upcard == 1 & CheckAce | upcard == 10 & CheckTen)
                                            {
                                                PlayerHands[index].RPreallowed[upcard] = (int)BJCAGlobalsClass.Surr.LS;
                                            }
                                            else
                                            {
                                                PlayerHands[index].RPreallowed[upcard] = newRules.SurrenderTable[upcard];
                                            }
                                            if (newRules.SAS)
                                            {
                                                if (upcard == 1 & CheckAce | upcard == 10 & CheckTen)
                                                {
                                                    PlayerHands[index].RPostallowed[upcard] = (int)BJCAGlobalsClass.Surr.LS;
                                                }
                                                else
                                                {
                                                    PlayerHands[index].RPostallowed[upcard] = newRules.SurrenderTable[upcard];
                                                }
                                            }
                                        }

                                        break;
                                    }
                            }
                            if (postSplit)
                            {
                                PlayerHands[index].DPreallowed[upcard] = PlayerHands[index].DPostallowed[upcard];
                                PlayerHands[index].RPreallowed[upcard] = PlayerHands[index].RPostallowed[upcard];
                            }

                            // Transfer the initial rules to the individual strategies
                            Opt.HandEVs[index].DPreallowed[upcard] = PlayerHands[index].DPreallowed[upcard];
                            Opt.HandEVs[index].DPostallowed[upcard] = PlayerHands[index].DPostallowed[upcard];
                            Opt.HandEVs[index].RPreallowed[upcard] = PlayerHands[index].RPreallowed[upcard];
                            Opt.HandEVs[index].RPostallowed[upcard] = PlayerHands[index].RPostallowed[upcard];

                            if (TD.ComputeStrat)
                            {
                                TD.HandEVs[index].DPreallowed[upcard] = PlayerHands[index].DPreallowed[upcard];
                                TD.HandEVs[index].DPostallowed[upcard] = PlayerHands[index].DPostallowed[upcard];
                                TD.HandEVs[index].RPreallowed[upcard] = PlayerHands[index].RPreallowed[upcard];
                                TD.HandEVs[index].RPostallowed[upcard] = PlayerHands[index].RPostallowed[upcard];
                            }
                            if (TC.ComputeStrat)
                            {
                                TC.HandEVs[index].DPreallowed[upcard] = PlayerHands[index].DPreallowed[upcard];
                                TC.HandEVs[index].DPostallowed[upcard] = PlayerHands[index].DPostallowed[upcard];
                                TC.HandEVs[index].RPreallowed[upcard] = PlayerHands[index].RPreallowed[upcard];
                                TC.HandEVs[index].RPostallowed[upcard] = PlayerHands[index].RPostallowed[upcard];
                            }
                            if (Forced.ComputeStrat)
                            {
                                Forced.HandEVs[index].DPreallowed[upcard] = PlayerHands[index].DPreallowed[upcard];
                                Forced.HandEVs[index].DPostallowed[upcard] = PlayerHands[index].DPostallowed[upcard];
                                Forced.HandEVs[index].RPreallowed[upcard] = PlayerHands[index].RPreallowed[upcard];
                                Forced.HandEVs[index].RPostallowed[upcard] = PlayerHands[index].RPostallowed[upcard];
                            }

                            if (PlayerHands[index].DPreallowed[upcard] | RDA & PlayerHands[index].Hand.NumCards <= 2 + newRules.RDDepth | DDR & PlayerHands[index].Hand.NumCards <= 3)
                            {
                                DoubleNeeded[index, upcard] = true;
                            }

                            if (PlayerHands[index].RPreallowed[upcard] > 0 | DDR)
                            {
                                SurrenderNeeded[index, upcard] = true;
                            }

                        }
                    }
                }
            }
        }

        private void EnumBJHandNumerator(bool infinite)
        {
            int i;
            int j;
            int card;
            double tempNumerator;
            double tempCardsLeft;

            for (card = 1; card <= 10; card++)
            {
                for (i = 0; i <= 30; i++)
                {
                    tempCardsLeft = OriginalShoe.Cards[card] - i + 1;
                    if (tempCardsLeft > 0d)
                    {
                        tempNumerator = 1d;
                    }
                    else
                    {
                        tempNumerator = 0d;
                    }

                    BJHandNumerator[card, i, 0] = tempNumerator;
                    for (j = 1; j <= 30; j++)
                    {
                        if (infinite)
                        {
                            tempNumerator = tempNumerator * OriginalShoe.Cards[card];
                        }
                        else
                        {
                            tempNumerator = tempNumerator * (tempCardsLeft - j);
                        }
                        BJHandNumerator[card, i, j] = tempNumerator;
                    }
                }
            }
        }

        private void EnumBJHandDivisor(bool infinite)
        {
            int i;
            int j;
            double tempDivisor;
            double tempCardsLeft;

            for (i = 0; i <= 35; i++)
            {
                tempDivisor = 1d;
                tempCardsLeft = OriginalShoe.CardsLeft - i;
                for (j = 1; j <= 35; j++)
                {
                    if (infinite)
                    {
                        tempDivisor = tempDivisor * OriginalShoe.CardsLeft;
                    }
                    else
                    {
                        tempDivisor = tempDivisor * (tempCardsLeft - j + 1d);
                    }
                    BJHandDivisor[i, j] = tempDivisor;
                }
            }

            for (i = 0; i <= 35; i++)
            {
                for (j = 0; j <= 35; j++)
                {
                    if (BJHandDivisor[i, j] == 0d)
                        BJHandDivisor[i, j] = 1d;
                }
            }
        }

        private void EnumDealerHands()
        {
            int upcard;

            for (upcard = 1; upcard <= 10; upcard++)
            {
                if (CardProb(upcard, 0) > 0d)
                {
                    DealDCard(upcard);
                    EnumDealerHandsAll(upcard);
                    UndealDCard(upcard);
                }
            }
        }

        private void EnumDealerHandsAll(int upcard)
        {
            // Adds any missing hands (e.g. 11 aces and a 6) and fixes the multipliers
            int card;
            int index;
            int temp;

            for (card = 1; card <= 10; card++)
            {
                if (CardProb(card, 0) > 0d) // Card present
                {
                    DealDCard(card);

                    // If dealer's hand is already defined then find it and increase the multiplier for the upcard
                    if (CurrentDHand.Hand.Total >= StandOnSoft | !CurrentDHand.Hand.Soft & CurrentDHand.Hand.Total >= 17)
                    {
                        if (CurrentDHand.Hand.Total < 22)
                        {
                            index = FindDealerHand(CurrentDHand.Hand.Total, CurrentDHand.Hand);
                            if (Conversions.ToBoolean(index)) // Dealer's hand was found
                            {
                                DealerHands[index].Multiplier[upcard] = DealerHands[index].Multiplier[upcard] + 1;

                                // Adds the current hand into the handcount chain if this is it's first incidence for the upcard
                                if (DealerHands[index].Multiplier[upcard] == 1)
                                {
                                    temp = DealerHandTotalUC[upcard, CurrentDHand.Hand.Total];
                                    DealerHandTotalUC[upcard, CurrentDHand.Hand.Total] = index;
                                    DealerHands[index].NextHandTotalUC[upcard] = temp;
                                }
                            }
                            else // Dealer hand wasn't found - add it now.
                            {
                                NumDHands = NumDHands + 1;
                                DealerHands[NumDHands] = new BJCADealerHandClass();
                                DealerHands[NumDHands].Hand.Copy(CurrentDHand.Hand);

                                temp = DealerHandTotal[CurrentDHand.Hand.Total];
                                DealerHandTotal[CurrentDHand.Hand.Total] = NumDHands;
                                DealerHands[NumDHands].NextHandTotal = temp;

                                temp = DealerHandTotalUC[upcard, CurrentDHand.Hand.Total];
                                DealerHandTotalUC[upcard, CurrentDHand.Hand.Total] = NumDHands;
                                DealerHands[NumDHands].NextHandTotalUC[upcard] = temp;

                                DealerHands[NumDHands].Multiplier[upcard] = 1;
                            }
                        }
                    }
                    // Do nothing if dealer busts
                    else if (CurrentDHand.Hand.NumCards <= MaxDealerCards) // Keep dealing
                    {
                        EnumDealerHandsAll(upcard);
                    }
                    UndealDCard(card);
                }
            }
        }

        private void EnumPlayerHands(int index, int startCard)
        {
            int card;
            int i;
            int temp;

            for (card = startCard; card <= 10; card++)
            {
                if (CardProb(card, 0) > 0d)
                {
                    DealPCard(card);
                    if (CurrentPHand.Total <= 21 & CurrentPHand.NumCards <= MaxPlayerCards)
                    {
                        PlayerHands[index].HitHand[card] = NumPHands;
                        PlayerHands[NumPHands] = new BJCAPlayerHandClass();
                        PlayerHands[NumPHands].Hand.Copy(CurrentPHand);

                        if (CurrentPHand.IsBJ())
                        {
                            BJIndex = NumPHands;
                        }

                        Opt.HandEVs[NumPHands] = new BJCAHandStrategyClass();
                        if (TD.ComputeStrat)
                            TD.HandEVs[NumPHands] = new BJCAHandStrategyClass();
                        if (TC.ComputeStrat)
                            TC.HandEVs[NumPHands] = new BJCAHandStrategyClass();
                        if (Forced.ComputeStrat)
                            Forced.HandEVs[NumPHands] = new BJCAHandStrategyClass();

                        for (i = 1; i <= 10; i++)
                            PlayerHands[NumPHands].HitHand[i] = -1;
                        if (CurrentPHand.NumCards > 1)
                        {
                            temp = PlayerHandTotal[CurrentPHand.Total, Conversions.ToInteger(CurrentPHand.Soft) + 1];
                            PlayerHandTotal[CurrentPHand.Total, Conversions.ToInteger(CurrentPHand.Soft) + 1] = NumPHands;
                            PlayerHands[NumPHands].NextHand = temp;

                            temp = 1;
                            for (i = 1; i <= 10; i++)
                            {
                                if (PlayerHands[NumPHands].Hand.Cards[i] > 0)
                                {
                                    PlayerHands[NumPHands].PairIndex[i] = temp;
                                    temp = temp + 1;
                                }
                            }
                        }
                        NumPHands = NumPHands + 1;
                        EnumPlayerHands(NumPHands - 1, card);
                    }
                    else
                    {
                        PlayerHands[index].HitHand[card] = 0;
                    }
                    UndealPCard(card);
                }
            }
        }

        private void LinkPlayerHands()
        {
            int index;
            int card;

            // At the end of EnumPlayerHands, NumPHands is 1 too high
            NumPHands = NumPHands - 1;

            // Hithand will be -1 if it needs to be linked , and 0 if the hithand was busted previously
            // It will be linked if there are enough cards to hit and it's not busted, otherwise it will be set to 0
            var loopTo = NumPHands;
            for (index = 1; index <= loopTo; index++)
            {
                CurrentPHand.Copy(PlayerHands[index].Hand);
                for (card = 1; card <= 10; card++)
                {
                    if (PlayerHands[index].HitHand[card] == -1 & CurrentPHand.Cards[card] < CurrentShoe.Cards[card])
                    {
                        DealPCard(card);
                        if (CurrentPHand.Total <= 21)
                        {
                            PlayerHands[index].HitHand[card] = FindPlayerHand(CurrentPHand);
                        }
                        else
                        {
                            PlayerHands[index].HitHand[card] = 0;
                        }
                        UndealPCard(card);
                    }
                    else if (PlayerHands[index].HitHand[card] == -1 & CurrentPHand.Cards[card] >= CurrentShoe.Cards[card])
                    {
                        PlayerHands[index].HitHand[card] = 0;
                    }
                }
            }
            CurrentPHand.Empty();
        }

        private void EnumSplitHands()
        {
            // The original pair is assumed to have been removed
            // 0   Full Deck
            // 1   1P Removed
            // 2   2P's Removed
            // 3   1N Removed
            // 4   1P, 1N Removed
            // 5   3P's Removed
            // 6   4P's Removed
            // 7   2P's, 1N Removed
            // 8   3P's, 1N Removed
            // 9   1P, 2N's Removed
            // 10  2P's, 2N's Removed

            // At present only 3 splits are supported
            switch (SPL)
            {
                case 1:
                    {
                        NSplitHands = 0;
                        NSplitCalcs = 1;
                        break;
                    }
                case 2:
                    {
                        NSplitHands = 4;
                        NSplitCalcs = 3;
                        break;
                    }
                case 3:
                    {
                        NSplitHands = 10;
                        NSplitCalcs = 5;
                        break;
                    }
            }

            // These are the only hands that need to be calculated directly, the other hands are conditioned upon these.
            SplitCalcHands[1] = 0;
            SplitCalcHands[2] = 1;
            SplitCalcHands[3] = 2;
            SplitCalcHands[4] = 5;
            SplitCalcHands[5] = 6;

            // The hands are defined below
            NPxHands[0] = new BJCANPxClass();
            NPxHands[0].Name = "-Full";
            NPxHands[0].NP = 0;
            NPxHands[0].NN = 0;
            NPxHands[0].Nx = 0;
            NPxHands[0].UCH = -1;
            NPxHands[0].CH = -1;
            NPxHands[0].Used[0] = false;
            NPxHands[0].Used[1] = true;
            NPxHands[0].Used[2] = false;
            NPxHands[0].Used[3] = false;

            NPxHands[1] = new BJCANPxClass();
            NPxHands[1].Name = "-P";
            NPxHands[1].NP = 1;
            NPxHands[1].NN = 0;
            NPxHands[1].Nx = 0;
            NPxHands[1].UCH = 0;
            NPxHands[1].CH = -1;
            NPxHands[1].Used[0] = false;
            NPxHands[1].Used[1] = false;
            NPxHands[1].Used[2] = true;
            NPxHands[1].Used[3] = false;

            NPxHands[2] = new BJCANPxClass();
            NPxHands[2].Name = "-PP";
            NPxHands[2].NP = 2;
            NPxHands[2].NN = 0;
            NPxHands[2].Nx = 0;
            NPxHands[2].UCH = 1;
            NPxHands[2].CH = -1;
            NPxHands[2].Used[0] = false;
            NPxHands[2].Used[1] = false;
            NPxHands[2].Used[2] = false;
            NPxHands[2].Used[3] = true;

            NPxHands[3] = new BJCANPxClass();
            NPxHands[3].Name = "-N";
            NPxHands[3].NP = 0;
            NPxHands[3].NN = 1;
            NPxHands[3].Nx = 0;
            NPxHands[3].UCH = 0;
            NPxHands[3].CH = 1;
            NPxHands[3].Used[0] = false;
            NPxHands[3].Used[1] = false;
            NPxHands[3].Used[2] = true;
            NPxHands[3].Used[3] = true;

            NPxHands[4] = new BJCANPxClass();
            NPxHands[4].Name = "-PN";
            NPxHands[4].NP = 1;
            NPxHands[4].NN = 1;
            NPxHands[4].Nx = 0;
            NPxHands[4].UCH = 1;
            NPxHands[4].CH = 2;
            NPxHands[4].Used[0] = false;
            NPxHands[4].Used[1] = false;
            NPxHands[4].Used[2] = true;
            NPxHands[4].Used[3] = false;

            NPxHands[5] = new BJCANPxClass();
            NPxHands[5].Name = "-PPP";
            NPxHands[5].NP = 3;
            NPxHands[5].NN = 0;
            NPxHands[5].Nx = 0;
            NPxHands[5].UCH = 2;
            NPxHands[5].CH = -1;
            NPxHands[5].Used[0] = false;
            NPxHands[5].Used[1] = false;
            NPxHands[5].Used[2] = false;
            NPxHands[5].Used[3] = false;

            NPxHands[6] = new BJCANPxClass();
            NPxHands[6].Name = "-PPPP";
            NPxHands[6].NP = 4;
            NPxHands[6].NN = 0;
            NPxHands[6].Nx = 0;
            NPxHands[6].UCH = 5;
            NPxHands[6].CH = -1;
            NPxHands[6].Used[0] = false;
            NPxHands[6].Used[1] = false;
            NPxHands[6].Used[2] = false;
            NPxHands[6].Used[3] = false;

            NPxHands[7] = new BJCANPxClass();
            NPxHands[7].Name = "-PPN";
            NPxHands[7].NP = 2;
            NPxHands[7].NN = 1;
            NPxHands[7].Nx = 0;
            NPxHands[7].UCH = 2;
            NPxHands[7].CH = 5;
            NPxHands[7].Used[0] = false;
            NPxHands[7].Used[1] = false;
            NPxHands[7].Used[2] = false;
            NPxHands[7].Used[3] = true;

            NPxHands[8] = new BJCANPxClass();
            NPxHands[8].Name = "-PPPN";
            NPxHands[8].NP = 3;
            NPxHands[8].NN = 1;
            NPxHands[8].Nx = 0;
            NPxHands[8].UCH = 5;
            NPxHands[8].CH = 6;
            NPxHands[8].Used[0] = false;
            NPxHands[8].Used[1] = false;
            NPxHands[8].Used[2] = false;
            NPxHands[8].Used[3] = false;

            NPxHands[9] = new BJCANPxClass();
            NPxHands[9].Name = "-PNN";
            NPxHands[9].NP = 1;
            NPxHands[9].NN = 2;
            NPxHands[9].Nx = 0;
            NPxHands[9].UCH = 4;
            NPxHands[9].CH = 7;
            NPxHands[9].Used[0] = false;
            NPxHands[9].Used[1] = false;
            NPxHands[9].Used[2] = false;
            NPxHands[9].Used[3] = true;

            NPxHands[10] = new BJCANPxClass();
            NPxHands[10].Name = "-PPNN";
            NPxHands[10].NP = 2;
            NPxHands[10].NN = 2;
            NPxHands[10].Nx = 0;
            NPxHands[10].UCH = 7;
            NPxHands[10].CH = 8;
            NPxHands[10].Used[0] = false;
            NPxHands[10].Used[1] = false;
            NPxHands[10].Used[2] = false;
            NPxHands[10].Used[3] = true;
        }

        private void EnumSplitRounds()
        {
            // Hands
            // 0   Full Deck
            // 1   1P Removed
            // 2   2P's Removed
            // 3   1N Removed
            // 4   1P, 1N Removed
            // 5   3P's Removed
            // 6   4P's Removed
            // 7   2P's, 1N Removed
            // 8   3P's, 1N Removed
            // 9  1P, 2N's Removed
            // 10  2P's, 2N's Removed

            // Rounds
            // SPL1	    MGP	(spl2)				            Eric  (spl)
            // xx	        2*EV(x)					            2*EV(x) 
            // 
            // SPL2	    MGP					                Eric 
            // NN	        EV(N) + EV(N-N)			            2*EV(N-N) 
            // Pxxx	    3*EV(x-P)				            3*EV(x-P) 
            // NPxx	    EV(N) + 2*EV(x-PN)		            EV(N-P) + 2*EV(x-PN) 
            // 
            // SPL3	    MGP					                Eric 
            // NN	        EV(N) + EV(N-N)				        2*EV(N-N) 
            // PNNN	    EV(N-P) + EV(N-PN) + EV(N-PNN)		3*EV(N-PNN) 
            // NPNN	    EV(N) + EV(N-PN) + EV(N-PNN)		3*EV(N-PNN) 
            // PPxxxx	    4*EV(x-PP)				            4*EV(x-PP) 
            // PNPxxx	    EV(N-P) + 3*EV(x-PPN)			    EV(N-PP) + 3*EV(x-PPN) 
            // NPPxxx	    EV(N) + 3*EV(x-PPN)			        EV(N-PP) + 3*EV(x-PPN) 
            // PNNPxx	    EV(N-P) + EV(N-PN) + 2*EV(x-PPNN)	2*EV(N-PPN) + 2*EV(x-PPNN) 
            // NPNPxx	    EV(N) + EV(N-PN) + 2*EV(x-PPNN)		2*EV(N-PPN) + 2*EV(x-PPNN) 

            // These are the only hands that need to be calculated directly, the other hands are conditioned upon these.
            NRounds[0] = 0;
            NRounds[1] = 1;
            NRounds[2] = 3;
            NRounds[3] = 8;

            // SPL, Round, Hand, x/N

            // The rounds are defined below
            // SPL1
            // xx	        2*EV(x)					            2*EV(x) 
            SplitRounds.Name[1, 1] = "xx";
            SplitRounds.NN = 0;
            SplitRounds.NP = 0;
            SplitRounds.Nx = 2;
            SplitRounds.Hands[1, 1, (int)BJCAGlobalsClass.Hands.Full, 0] = 2;

            // SPL2
            // NN	        EV(N) + EV(N-N)			            2*EV(N-N) 
            SplitRounds.Name[2, 1] = "NN";
            SplitRounds.NN = 2;
            SplitRounds.NP = 0;
            SplitRounds.Nx = 2;
            SplitRounds.Hands[2, 1, (int)BJCAGlobalsClass.Hands.N, 1] = 2;
            // Pxxx	    3*EV(x-P)				            3*EV(x-P) 
            SplitRounds.Name[2, 2] = "Pxxx";
            SplitRounds.NN = 0;
            SplitRounds.NP = 1;
            SplitRounds.Nx = 3;
            SplitRounds.Hands[2, 2, (int)BJCAGlobalsClass.Hands.P, 0] = 3;
            // NPxx	    EV(N) + 2*EV(x-PN)		            EV(N-P) + 2*EV(x-PN) 
            SplitRounds.Name[2, 3] = "NPxx";
            SplitRounds.NN = 1;
            SplitRounds.NP = 1;
            SplitRounds.Nx = 2;
            SplitRounds.Hands[2, 3, (int)BJCAGlobalsClass.Hands.P, 1] = 1;
            SplitRounds.Hands[2, 3, (int)BJCAGlobalsClass.Hands.PN, 0] = 2;

            // SPL3
            // NN	        EV(N) + EV(N-N)			            2*EV(N-N) 
            SplitRounds.Name[3, 1] = "NN";
            SplitRounds.NN = 2;
            SplitRounds.NP = 0;
            SplitRounds.Nx = 0;
            SplitRounds.Hands[3, 1, (int)BJCAGlobalsClass.Hands.N, 1] = 2;
            // PNNN	    EV(N-P) + EV(N-PN) + EV(N-PNN)		3*EV(N-PNN) 
            SplitRounds.Name[3, 2] = "PNNN";
            SplitRounds.NN = 3;
            SplitRounds.NP = 1;
            SplitRounds.Nx = 0;
            SplitRounds.Hands[3, 2, (int)BJCAGlobalsClass.Hands.PNN, 1] = 3;
            // NPNN	    EV(N) + EV(N-PN) + EV(N-PNN)		3*EV(N-PNN) 
            SplitRounds.Name[3, 3] = "NPNN";
            SplitRounds.NN = 3;
            SplitRounds.NP = 1;
            SplitRounds.Nx = 0;
            SplitRounds.Hands[3, 3, (int)BJCAGlobalsClass.Hands.PNN, 1] = 3;
            // PPxxxx	    4*EV(x-PP)				            4*EV(x-PP) 
            SplitRounds.Name[3, 4] = "PPxxxx";
            SplitRounds.NN = 0;
            SplitRounds.NP = 2;
            SplitRounds.Nx = 4;
            SplitRounds.Hands[3, 4, (int)BJCAGlobalsClass.Hands.PP, 0] = 4;
            // PNPxxx	    EV(N-P) + 3*EV(x-PPN)			    EV(N-PP) + 3*EV(x-PPN) 
            SplitRounds.Name[3, 5] = "PNPxxx";
            SplitRounds.NN = 1;
            SplitRounds.NP = 2;
            SplitRounds.Nx = 3;
            SplitRounds.Hands[3, 5, (int)BJCAGlobalsClass.Hands.PP, 1] = 1;
            SplitRounds.Hands[3, 5, (int)BJCAGlobalsClass.Hands.PPN, 0] = 3;
            // NPPxxx	    EV(N) + 3*EV(x-PPN)			        EV(N-PP) + 3*EV(x-PPN) 
            SplitRounds.Name[3, 6] = "PNPxxx";
            SplitRounds.NN = 1;
            SplitRounds.NP = 2;
            SplitRounds.Nx = 3;
            SplitRounds.Hands[3, 6, (int)BJCAGlobalsClass.Hands.PP, 1] = 1;
            SplitRounds.Hands[3, 6, (int)BJCAGlobalsClass.Hands.PPN, 0] = 3;
            // PNNPxx	    EV(N-P) + EV(N-PN) + 2*EV(x-PPNN)	2*EV(N-PPN) + 2*EV(x-PPNN) 
            SplitRounds.Name[3, 7] = "PNNPxx";
            SplitRounds.NN = 2;
            SplitRounds.NP = 2;
            SplitRounds.Nx = 2;
            SplitRounds.Hands[3, 7, (int)BJCAGlobalsClass.Hands.PPN, 1] = 2;
            SplitRounds.Hands[3, 7, (int)BJCAGlobalsClass.Hands.PPNN, 0] = 2;
            // NPNPxx	    EV(N) + EV(N-PN) + 2*EV(x-PPNN)		2*EV(N-PPN) + 2*EV(x-PPNN) 
            SplitRounds.Name[3, 8] = "NPNPxx";
            SplitRounds.NN = 2;
            SplitRounds.NP = 2;
            SplitRounds.Nx = 2;
            SplitRounds.Hands[3, 8, (int)BJCAGlobalsClass.Hands.PPN, 1] = 2;
            SplitRounds.Hands[3, 8, (int)BJCAGlobalsClass.Hands.PPNN, 0] = 2;
        }

        public void ResetForcedRulesHands(ref BJCAStrategyClass cStrat)
        {
            int index;
            int upcard;

            var loopTo = NumPHands;
            for (index = 1; index <= loopTo; index++)
            {
                // Reset the strategy - this is needed since the forced rules can be recalculated
                for (upcard = 1; upcard <= 10; upcard++)
                {
                    if (cStrat.HandEVs[index] is not null)
                    {
                        cStrat.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.None;
                        cStrat.HandEVs[index].EVs.StratEV[upcard] = 0d;
                        cStrat.HandEVs[index].EVs.StratPushEV[upcard] = 0d;

                        cStrat.HandEVs[index].SPreallowed[upcard] = true;
                        cStrat.HandEVs[index].HPreallowed[upcard] = true;
                        cStrat.HandEVs[index].PAllowed[upcard] = PlayerHands[index].PAllowed[upcard];
                        cStrat.HandEVs[index].DPreallowed[upcard] = PlayerHands[index].DPreallowed[upcard];
                        cStrat.HandEVs[index].RPreallowed[upcard] = PlayerHands[index].RPreallowed[upcard];
                        cStrat.HandEVs[index].PreForced[upcard] = false;
                        cStrat.HandEVs[index].HandUsed[upcard] = 0;
                        cStrat.HandEVs[index].Multiplier[upcard] = 0;
                        cStrat.HandEVs[index].SplitEV[upcard] = 0d;

                        cStrat.HandEVs[index].SPostallowed[upcard] = true;
                        cStrat.HandEVs[index].HPostallowed[upcard] = true;
                        cStrat.HandEVs[index].DPostallowed[upcard] = PlayerHands[index].DPostallowed[upcard];
                        cStrat.HandEVs[index].RPostallowed[upcard] = PlayerHands[index].RPostallowed[upcard];
                        cStrat.HandEVs[index].PostForced[upcard] = false;
                        cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard] = (int)BJCAGlobalsClass.Strat.None;
                        // cStrat.HandEVs(index).HandUsedPost(upcard) = 0
                    }
                }

            }
        }

        public void ApplyForcedRules()
        {
            int index;
            int rule;
            int upcard;
            int total;
            bool apply;

            if (Forced.ComputeStrat)
            {
                // Clear out the Forced TD Strategies which are needed for the NCard strategies
                for (total = 5; total <= 21; total++)
                {
                    for (upcard = 1; upcard <= 10; upcard++)
                    {
                        if (Forced.StratTD[total, Conversions.ToInteger(false) + 1] is null)
                        {
                            Forced.StratTD[total, Conversions.ToInteger(false) + 1] = new BJCATDStratClass();
                        }
                        if (total > 12 & Forced.StratTD[total, Conversions.ToInteger(true) + 1] is null)
                        {
                            Forced.StratTD[total, Conversions.ToInteger(true) + 1] = new BJCATDStratClass();
                        }
                    }
                }

                // Reset the Forced Strategy before applying the rules
                ResetForcedRulesHands(ref Forced);

                // First apply all the Forced Table TD Rules
                var loopTo = ForcedTableRulesList.NumRules - 1;
                for (rule = 0; rule <= loopTo; rule++)
                {
                    if (ForcedTableRulesList.L[rule].RuleOn)
                    {
                        if (!(ForcedTableRulesList.L[rule].UseSpecificHand & ForcedTableRulesList.L[rule].ExactMatch))
                        {
                            Forced.StratTD[ForcedTableRulesList.L[rule].Hand.Total, Conversions.ToInteger(ForcedTableRulesList.L[rule].Hand.Soft) + 1].Strat[ForcedTableRulesList.L[rule].Upcard] = ForcedTableRulesList.L[rule].Strat;
                            ForcedTableRulesList.L[rule].Index = 0;

                            index = PlayerHandTotal[ForcedTableRulesList.L[rule].Hand.Total, Conversions.ToInteger(ForcedTableRulesList.L[rule].Hand.Soft) + 1];
                            while (index != 0)
                            {
                                // Don't apply general rules to pairs
                                if (PlayerHands[index].Hand.NumCards > 1 & !PlayerHands[index].Hand.IsPair() & (Forced.NCardsCD == 0 | PlayerHands[index].Hand.NumCards > Forced.NCardsCD))
                                {
                                    ApplyForcedRuleHand(ref Forced, index, ForcedTableRulesList.L[rule]);
                                }
                                index = PlayerHands[index].NextHand;
                            }
                        }
                    }
                }

                // Then find the hand indices for the table's CD Hands
                var loopTo1 = ForcedTableRulesList.NumRules - 1;
                for (rule = 0; rule <= loopTo1; rule++)
                {
                    if (ForcedTableRulesList.L[rule].RuleOn)
                    {
                        if (ForcedTableRulesList.L[rule].UseSpecificHand & ForcedTableRulesList.L[rule].ExactMatch)
                        {
                            index = FindPlayerHand(ForcedTableRulesList.L[rule].Hand);
                            ForcedTableRulesList.L[rule].Index = index;
                            ApplyForcedRuleHand(ref Forced, index, ForcedTableRulesList.L[rule]);
                        }
                    }
                }

                // Find the hand indices for the the non-table CD Hands
                var loopTo2 = ForcedRulesList.NumRules - 1;
                for (rule = 0; rule <= loopTo2; rule++)
                {
                    if (ForcedRulesList.L[rule].RuleOn)
                    {
                        if (ForcedRulesList.L[rule].UseSpecificHand & ForcedRulesList.L[rule].ExactMatch)
                        {
                            index = FindPlayerHand(ForcedRulesList.L[rule].Hand);
                            ForcedRulesList.L[rule].Index = index;
                            ApplyForcedRuleHand(ref Forced, index, ForcedRulesList.L[rule]);
                        }
                        else
                        {
                            ForcedRulesList.L[rule].Index = 0;
                            var loopTo3 = NumPHands;
                            for (index = 1; index <= loopTo3; index++)
                            {
                                if (PlayerHands[index].Hand.NumCards > 1)
                                {
                                    apply = false;

                                    // The hand does not require an exact match so don't apply it to pairs
                                    if (!PlayerHands[index].Hand.IsPair())
                                    {
                                        if (ForcedRulesList.L[rule].UseSpecificHand & !ForcedRulesList.L[rule].ExactMatch & PlayerHands[index].Hand.Includes(ForcedRulesList.L[rule].Hand))
                                        {
                                            // This will take care of specific hand rules
                                            apply = true;
                                        }
                                        // Finally check for rules that don't require specific hands
                                        else if (PlayerHands[index].Hand.Total == ForcedRulesList.L[rule].Hand.Total | ForcedRulesList.L[rule].Hand.Total == 0)
                                        {
                                            if (!ForcedRulesList.L[rule].Hand.Soft & !PlayerHands[index].Hand.Soft | ForcedRulesList.L[rule].Hand.Soft & PlayerHands[index].Hand.Soft)
                                            {
                                                if (ForcedRulesList.L[rule].Hand.NumCards == 0 | ForcedRulesList.L[rule].Hand.NumCards == PlayerHands[index].Hand.NumCards | ForcedRulesList.L[rule].OrLess & PlayerHands[index].Hand.NumCards <= ForcedRulesList.L[rule].Hand.NumCards | ForcedRulesList.L[rule].OrMore & PlayerHands[index].Hand.NumCards >= ForcedRulesList.L[rule].Hand.NumCards)
                                                {
                                                    apply = true;
                                                }
                                            }
                                        }
                                    }

                                    if (apply)
                                    {
                                        ApplyForcedRuleHand(ref Forced, index, ForcedRulesList.L[rule]);
                                    }
                                }
                            }
                        }
                    }
                }

                // Now that all the rules have been applied, adjust them for the current rules
                var loopTo4 = NumPHands;
                for (index = 1; index <= loopTo4; index++)
                {
                    if (PlayerHands[index].Hand.NumCards > 1)
                    {
                        for (upcard = 1; upcard <= 10; upcard++)
                        {
                            if (Forced.HandEVs[index].PreForced[upcard] | Forced.HandEVs[index].PostForced[upcard])
                            {
                                ApplyForcedRuleHandUpcard(ref Forced, index, upcard);
                            }
                        }
                    }
                }
            }
        }

        public void ApplyForcedRuleHand(ref BJCAStrategyClass cStrat, int index, BJCAForcedRulesClass rule)
        {
            int minUC;
            int maxUC;
            int upcard;

            if (rule.Upcard == 0)
            {
                minUC = 1;
                maxUC = 10;
            }
            else
            {
                minUC = rule.Upcard;
                maxUC = rule.Upcard;
            }

            var loopTo = maxUC;
            for (upcard = minUC; upcard <= loopTo; upcard++)
            {
                if (rule.PreSplit)
                {
                    cStrat.HandEVs[index].PreForced[upcard] = true;
                    cStrat.HandEVs[index].EVs.Strat[upcard] = rule.Strat;
                }
                if (rule.PostSplit)
                {
                    cStrat.HandEVs[index].PostForced[upcard] = true;
                    cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard] = rule.Strat;
                }
            }
        }

        private void ApplyForcedRuleHandUpcard(ref BJCAStrategyClass cStrat, int index, int upcard)
        {
            int card;

            if (cStrat.HandEVs[index].PreForced[upcard])
            {
                switch (cStrat.HandEVs[index].EVs.Strat[upcard])
                {
                    case (int)BJCAGlobalsClass.Strat.None:
                        {
                            cStrat.HandEVs[index].SPreallowed[upcard] = true;
                            cStrat.HandEVs[index].HPreallowed[upcard] = true;
                            cStrat.HandEVs[index].PAllowed[upcard] = true;
                            cStrat.HandEVs[index].DPreallowed[upcard] = PlayerHands[index].DPreallowed[upcard];
                            cStrat.HandEVs[index].RPreallowed[upcard] = PlayerHands[index].RPreallowed[upcard];
                            cStrat.HandEVs[index].PreForced[upcard] = false;
                            cStrat.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.None;
                            break;
                        }
                    case (int)BJCAGlobalsClass.Strat.S:
                    case (int)BJCAGlobalsClass.Strat.H:
                        {
                            break;
                        }
                    case (int)BJCAGlobalsClass.Strat.D:
                        {
                            if (!cStrat.HandEVs[index].DPreallowed[upcard])
                            {
                                cStrat.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.H;
                            }

                            break;
                        }
                    case (int)BJCAGlobalsClass.Strat.DS:
                        {
                            if (!cStrat.HandEVs[index].DPreallowed[upcard])
                            {
                                cStrat.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.S;
                            }

                            break;
                        }
                    case (int)BJCAGlobalsClass.Strat.R:
                        {
                            if (cStrat.HandEVs[index].RPreallowed[upcard] == 0)
                            {
                                cStrat.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.H;
                            }

                            break;
                        }
                    case (int)BJCAGlobalsClass.Strat.RS:
                        {
                            if (cStrat.HandEVs[index].RPreallowed[upcard] == 0)
                            {
                                cStrat.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.S;
                            }

                            break;
                        }
                    case (int)BJCAGlobalsClass.Strat.P:
                    case (int)BJCAGlobalsClass.Strat.PS:
                    case (int)BJCAGlobalsClass.Strat.PD:
                    case (int)BJCAGlobalsClass.Strat.PH:
                    case (int)BJCAGlobalsClass.Strat.PR:
                        {
                            for (card = 1; card <= 10; card++)
                            {
                                if (PlayerHands[index].Hand.Cards[card] == 2)
                                {
                                    break;
                                }
                            }
                            if (SplitIndex[card, upcard] > 0)
                            {
                                switch (cStrat.HandEVs[index].EVs.Strat[upcard])
                                {
                                    case (int)BJCAGlobalsClass.Strat.P:
                                        {
                                            cStrat.HandEVs[index].PostForced[upcard] = false;
                                            cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard] = (int)BJCAGlobalsClass.Strat.None;
                                            break;
                                        }
                                    case (int)BJCAGlobalsClass.Strat.PS:
                                        {
                                            cStrat.HandEVs[index].PostForced[upcard] = true;
                                            cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard] = (int)BJCAGlobalsClass.Strat.S;
                                            break;
                                        }
                                    case (int)BJCAGlobalsClass.Strat.PH:
                                        {
                                            cStrat.HandEVs[index].PostForced[upcard] = true;
                                            cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard] = (int)BJCAGlobalsClass.Strat.H;
                                            break;
                                        }
                                    case (int)BJCAGlobalsClass.Strat.PD:
                                        {
                                            if (cStrat.HandEVs[index].DPostallowed[upcard])
                                            {
                                                cStrat.HandEVs[index].PostForced[upcard] = true;
                                                cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard] = (int)BJCAGlobalsClass.Strat.D;
                                            }
                                            else
                                            {
                                                cStrat.HandEVs[index].PostForced[upcard] = false;
                                                cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard] = (int)BJCAGlobalsClass.Strat.None;
                                            }

                                            break;
                                        }
                                    case (int)BJCAGlobalsClass.Strat.PR:
                                        {
                                            if (cStrat.HandEVs[index].RPostallowed[upcard] > 0)
                                            {
                                                cStrat.HandEVs[index].PostForced[upcard] = true;
                                                cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard] = (int)BJCAGlobalsClass.Strat.R;
                                            }
                                            else
                                            {
                                                cStrat.HandEVs[index].PostForced[upcard] = false;
                                                cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard] = (int)BJCAGlobalsClass.Strat.None;
                                            }

                                            break;
                                        }
                                }
                            }

                            break;
                        }
                    case (int)BJCAGlobalsClass.Strat.xS:
                        {
                            cStrat.HandEVs[index].SPreallowed[upcard] = false;
                            cStrat.HandEVs[index].PreForced[upcard] = false;
                            cStrat.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.None;
                            break;
                        }
                    case (int)BJCAGlobalsClass.Strat.xH:
                        {
                            cStrat.HandEVs[index].HPreallowed[upcard] = false;
                            cStrat.HandEVs[index].PreForced[upcard] = false;
                            cStrat.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.None;
                            break;
                        }
                    case (int)BJCAGlobalsClass.Strat.xD:
                        {
                            cStrat.HandEVs[index].DPreallowed[upcard] = false;
                            cStrat.HandEVs[index].PreForced[upcard] = false;
                            cStrat.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.None;
                            break;
                        }
                    case (int)BJCAGlobalsClass.Strat.xR:
                        {
                            cStrat.HandEVs[index].RPreallowed[upcard] = Conversions.ToInteger(false);
                            cStrat.HandEVs[index].PreForced[upcard] = false;
                            cStrat.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.None;
                            break;
                        }
                    case (int)BJCAGlobalsClass.Strat.xP:
                        {
                            cStrat.HandEVs[index].PAllowed[upcard] = false;
                            cStrat.HandEVs[index].PreForced[upcard] = false;
                            cStrat.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.None;
                            break;
                        }
                }
            }

            if (cStrat.HandEVs[index].PostForced[upcard])
            {
                switch (cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard])
                {
                    case (int)BJCAGlobalsClass.Strat.None:
                        {
                            cStrat.HandEVs[index].SPostallowed[upcard] = true;
                            cStrat.HandEVs[index].HPostallowed[upcard] = true;
                            cStrat.HandEVs[index].DPostallowed[upcard] = PlayerHands[index].DPostallowed[upcard];
                            cStrat.HandEVs[index].RPostallowed[upcard] = PlayerHands[index].RPostallowed[upcard];
                            cStrat.HandEVs[index].PostForced[upcard] = false;
                            cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard] = (int)BJCAGlobalsClass.Strat.None;
                            break;
                        }
                    case (int)BJCAGlobalsClass.Strat.S:
                    case (int)BJCAGlobalsClass.Strat.H:
                        {
                            break;
                        }
                    case (int)BJCAGlobalsClass.Strat.D:
                        {
                            if (!cStrat.HandEVs[index].DPostallowed[upcard])
                            {
                                cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard] = (int)BJCAGlobalsClass.Strat.H;
                            }

                            break;
                        }
                    case (int)BJCAGlobalsClass.Strat.DS:
                        {
                            if (!cStrat.HandEVs[index].DPostallowed[upcard])
                            {
                                cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard] = (int)BJCAGlobalsClass.Strat.S;
                            }

                            break;
                        }
                    case (int)BJCAGlobalsClass.Strat.R:
                        {
                            if (cStrat.HandEVs[index].RPostallowed[upcard] == 0)
                            {
                                cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard] = (int)BJCAGlobalsClass.Strat.H;
                            }

                            break;
                        }
                    case (int)BJCAGlobalsClass.Strat.RS:
                        {
                            if (cStrat.HandEVs[index].RPostallowed[upcard] == 0)
                            {
                                cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard] = (int)BJCAGlobalsClass.Strat.S;
                            }

                            break;
                        }
                    case (int)BJCAGlobalsClass.Strat.P:
                    case (int)BJCAGlobalsClass.Strat.PS:
                    case (int)BJCAGlobalsClass.Strat.PD:
                    case (int)BJCAGlobalsClass.Strat.PH:
                    case (int)BJCAGlobalsClass.Strat.PR:
                        {
                            for (card = 1; card <= 10; card++)
                            {
                                if (PlayerHands[index].Hand.Cards[card] == 2)
                                {
                                    break;
                                }
                            }
                            if (SplitIndex[card, upcard] > 0)
                            {
                                switch (cStrat.HandEVs[index].EVs.Strat[upcard])
                                {
                                    case (int)BJCAGlobalsClass.Strat.P:
                                        {
                                            cStrat.HandEVs[index].PostForced[upcard] = false;
                                            cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard] = (int)BJCAGlobalsClass.Strat.None;
                                            break;
                                        }
                                    case (int)BJCAGlobalsClass.Strat.PS:
                                        {
                                            cStrat.HandEVs[index].PostForced[upcard] = true;
                                            cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard] = (int)BJCAGlobalsClass.Strat.S;
                                            break;
                                        }
                                    case (int)BJCAGlobalsClass.Strat.PH:
                                        {
                                            cStrat.HandEVs[index].PostForced[upcard] = true;
                                            cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard] = (int)BJCAGlobalsClass.Strat.H;
                                            break;
                                        }
                                    case (int)BJCAGlobalsClass.Strat.PD:
                                        {
                                            if (cStrat.HandEVs[index].DPostallowed[upcard])
                                            {
                                                cStrat.HandEVs[index].PostForced[upcard] = true;
                                                cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard] = (int)BJCAGlobalsClass.Strat.D;
                                            }
                                            else
                                            {
                                                cStrat.HandEVs[index].PostForced[upcard] = false;
                                                cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard] = (int)BJCAGlobalsClass.Strat.None;
                                            }

                                            break;
                                        }
                                    case (int)BJCAGlobalsClass.Strat.PR:
                                        {
                                            if (cStrat.HandEVs[index].RPostallowed[upcard] > 0)
                                            {
                                                cStrat.HandEVs[index].PostForced[upcard] = true;
                                                cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard] = (int)BJCAGlobalsClass.Strat.R;
                                            }
                                            else
                                            {
                                                cStrat.HandEVs[index].PostForced[upcard] = false;
                                                cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard] = (int)BJCAGlobalsClass.Strat.None;
                                            }

                                            break;
                                        }
                                }
                            }

                            break;
                        }
                    case (int)BJCAGlobalsClass.Strat.xS:
                        {
                            cStrat.HandEVs[index].SPostallowed[upcard] = false;
                            cStrat.HandEVs[index].PostForced[upcard] = false;
                            cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard] = (int)BJCAGlobalsClass.Strat.None;
                            break;
                        }
                    case (int)BJCAGlobalsClass.Strat.xH:
                        {
                            cStrat.HandEVs[index].HPostallowed[upcard] = false;
                            cStrat.HandEVs[index].PostForced[upcard] = false;
                            cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard] = (int)BJCAGlobalsClass.Strat.None;
                            break;
                        }
                    case (int)BJCAGlobalsClass.Strat.xD:
                        {
                            cStrat.HandEVs[index].DPostallowed[upcard] = false;
                            cStrat.HandEVs[index].PostForced[upcard] = false;
                            cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard] = (int)BJCAGlobalsClass.Strat.None;
                            break;
                        }
                    case (int)BJCAGlobalsClass.Strat.xR:
                        {
                            cStrat.HandEVs[index].RPostallowed[upcard] = Conversions.ToInteger(false);
                            cStrat.HandEVs[index].PostForced[upcard] = false;
                            cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard] = (int)BJCAGlobalsClass.Strat.None;
                            break;
                        }
                    case (int)BJCAGlobalsClass.Strat.xP:
                        {
                            cStrat.HandEVs[index].PAllowed[upcard] = false;
                            cStrat.HandEVs[index].PreForced[upcard] = false;
                            cStrat.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.None;
                            break;
                        }
                }
            }

            if (cStrat.HandEVs[index].SPreallowed[upcard] == false & cStrat.HandEVs[index].HPreallowed[upcard] == false & cStrat.HandEVs[index].PAllowed[upcard] == false & cStrat.HandEVs[index].DPreallowed[upcard] == false & cStrat.HandEVs[index].RPreallowed[upcard] == Conversions.ToInteger(false) & cStrat.HandEVs[index].PreForced[upcard] == true)




            {

                cStrat.HandEVs[index].SPreallowed[upcard] = true;
                cStrat.HandEVs[index].HPreallowed[upcard] = true;
                cStrat.HandEVs[index].PAllowed[upcard] = true;
                cStrat.HandEVs[index].DPreallowed[upcard] = PlayerHands[index].DPreallowed[upcard];
                cStrat.HandEVs[index].RPreallowed[upcard] = PlayerHands[index].RPreallowed[upcard];
                cStrat.HandEVs[index].PreForced[upcard] = false;
                cStrat.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.None;
            }
            if (cStrat.HandEVs[index].SPostallowed[upcard] == false & cStrat.HandEVs[index].HPostallowed[upcard] == false & cStrat.HandEVs[index].DPostallowed[upcard] == false & cStrat.HandEVs[index].RPostallowed[upcard] == Conversions.ToInteger(false) & cStrat.HandEVs[index].PostForced[upcard] == true)



            {

                cStrat.HandEVs[index].SPostallowed[upcard] = true;
                cStrat.HandEVs[index].HPostallowed[upcard] = true;
                cStrat.HandEVs[index].DPostallowed[upcard] = PlayerHands[index].DPostallowed[upcard];
                cStrat.HandEVs[index].RPostallowed[upcard] = PlayerHands[index].RPostallowed[upcard];
                cStrat.HandEVs[index].PostForced[upcard] = false;
                cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard] = (int)BJCAGlobalsClass.Strat.None;
            }
        }

        #endregion

        #region  Main Computation Methods 

        #region  Probability Methods 

        private void ComputeHandProbsPreSplit()
        {
            int index;
            int upcard;
            double ucprob;
            double prob = new double();
            var hand = new BJCAHandClass();

            int suit;
            int card;
            int i;

            var loopTo = NumPHands;
            for (index = 1; index <= loopTo; index++)
            {
                if (PlayerHands[index].Hand.NumCards > 1)
                {
                    for (upcard = 1; upcard <= 10; upcard++)
                    {
                        if (UCAllowed[upcard])
                        {
                            // Compute the Hand Prob
                            CurrentShoe.Deal(upcard);
                            PlayerHands[index].HandEVs.Prob[upcard] = GetHandProb(CurrentShoe.Hand, PlayerHands[index].Hand, 0, 1d);
                            CurrentShoe.Undeal(upcard);

                            // Compute the BJ probs
                            if (upcard == 1)
                            {
                                PlayerHands[index].HandEVs.BJProb[upcard] = BJHandNumerator[10, PlayerHands[index].Hand.Cards[10], 1] / BJHandDivisor[PlayerHands[index].Hand.NumCards + 1, 1];
                            }
                            else if (upcard == 10)
                            {
                                PlayerHands[index].HandEVs.BJProb[upcard] = BJHandNumerator[1, PlayerHands[index].Hand.Cards[1], 1] / BJHandDivisor[PlayerHands[index].Hand.NumCards + 1, 1];
                            }

                            // Compute the Suited Probs
                            ucprob = CardProb(upcard, 0);
                            for (suit = 0; suit <= 3; suit++)
                            {
                                PlayerHands[index].HandEVs.SuitedPossible[upcard, suit] = false;
                                PlayerHands[index].HandEVs.ProbSuited[upcard, suit] = 1d;
                                for (card = 1; card <= 10; card++)
                                {
                                    if (PlayerHands[index].HandEVs.ProbSuited[upcard, suit] > 0d)
                                    {
                                        var loopTo1 = PlayerHands[index].Hand.Cards[card];
                                        for (i = 1; i <= loopTo1; i++)
                                        {
                                            if (CurrentShoe.Suits[card, suit] > 0)
                                            {
                                                PlayerHands[index].HandEVs.ProbSuited[upcard, suit] *= CurrentShoe.Suits[card, suit] / (double)CurrentShoe.CardsLeft;
                                                if (!InfiniteDeck)
                                                    CurrentShoe.DealSuited(card, suit);
                                            }
                                            else
                                            {
                                                PlayerHands[index].HandEVs.ProbSuited[upcard, suit] = 0d;
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (PlayerHands[index].HandEVs.ProbSuited[upcard, suit] > 0d)
                                {
                                    // So far the suited prob does not take into account the upcard so we do that now
                                    PlayerHands[index].HandEVs.ProbSuited[upcard, suit] *= CardProb(upcard, 0);
                                    if (PlayerHands[index].HandEVs.ProbSuited[upcard, suit] > 0d)
                                    {
                                        PlayerHands[index].HandEVs.ProbSuited[upcard, suit] /= ucprob;
                                        PlayerHands[index].HandEVs.SuitedPossible[upcard, suit] = true;
                                    }
                                    else
                                    {

                                    }
                                }
                                PlayerHands[index].HandEVs.SumSuited[upcard] += PlayerHands[index].HandEVs.ProbSuited[upcard, suit];
                                CurrentShoe.Reset(OriginalShoe);
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region  Stand Methods 

        public BJCAHandEVsClass ComputeStandHand(BJCAHandClass hand, int minUC, int maxUC, bool computeAll)
        {
            int upcard;
            double prob;
            int dIndex;
            int total;
            double bjadjprob;
            var newEVs = new BJCAHandEVsClass();
            string key;
            // The Hand does not need to be dealt or undealt, however the Upcard should NOT be dealt yet.

            // Only dealer hands that push or win need to be calculated - this is all hands for total<17
            key = DealerProbs.GetHashKey(StandOnSoft, OriginalShoe, hand);
            if (DealerProbs.Contains(key) & UseDPDictionary)
            {
                for (total = 17; total <= 21; total++)
                {
                    var loopTo = maxUC;
                    for (upcard = minUC; upcard <= loopTo; upcard++)
                    {
                        if (UCAllowed[upcard])
                        {
                            newEVs.DealerProbs[upcard, total - 17] = DealerProbs[key].p[upcard, total - 17];
                        }
                    }
                }
            }
            else if (hand.Total > 16 & !computeAll & !SaveDPDictionary)
            {
                for (total = hand.Total; total <= 21; total++)
                {
                    dIndex = DealerHandTotal[total];
                    while (dIndex != 0)
                    {
                        prob = GetHandProb(hand, DealerHands[dIndex].Hand, 0, BJHandDivisor[hand.NumCards, 1]);
                        if (prob != 0d)
                        {
                            var loopTo2 = maxUC;
                            for (upcard = minUC; upcard <= loopTo2; upcard++)
                            {
                                if (UCAllowed[upcard] & DealerHands[dIndex].Multiplier[upcard] != 0 & BJHandNumerator[upcard, hand.Cards[upcard], 1] != 0d)
                                {
                                    newEVs.DealerProbs[upcard, DealerHands[dIndex].Hand.Total - 17] += prob * DealerHands[dIndex].Multiplier[upcard] / BJHandNumerator[upcard, hand.Cards[upcard], 1];
                                }
                            }
                        }
                        dIndex = DealerHands[dIndex].NextHandTotal;
                    }
                }
            }
            else if (SaveDPDictionary)
            {
                // Calculate all upcards regardless of UCAllowed status to save to the dictionary
                for (total = 17; total <= 21; total++)
                {
                    dIndex = DealerHandTotal[total];
                    while (dIndex != 0)
                    {
                        prob = GetHandProb(hand, DealerHands[dIndex].Hand, 0, BJHandDivisor[hand.NumCards, 1]);
                        if (prob != 0d)
                        {
                            for (upcard = 1; upcard <= 10; upcard++)
                            {
                                if (DealerHands[dIndex].Multiplier[upcard] != 0 & BJHandNumerator[upcard, hand.Cards[upcard], 1] != 0d)
                                {
                                    newEVs.DealerProbs[upcard, DealerHands[dIndex].Hand.Total - 17] += prob * DealerHands[dIndex].Multiplier[upcard] / BJHandNumerator[upcard, hand.Cards[upcard], 1];
                                }
                            }
                        }
                        dIndex = DealerHands[dIndex].NextHandTotal;
                    }
                }
            }
            else
            {
                // All dealer probs need to be calculated since the player has a stiff hand (total < 17)
                for (total = 17; total <= 21; total++)
                {
                    dIndex = DealerHandTotal[total];
                    while (dIndex != 0)
                    {
                        prob = GetHandProb(hand, DealerHands[dIndex].Hand, 0, BJHandDivisor[hand.NumCards, 1]);
                        if (prob != 0d)
                        {
                            var loopTo1 = maxUC;
                            for (upcard = minUC; upcard <= loopTo1; upcard++)
                            {
                                if (UCAllowed[upcard] & DealerHands[dIndex].Multiplier[upcard] != 0 & BJHandNumerator[upcard, hand.Cards[upcard], 1] != 0d)
                                {
                                    newEVs.DealerProbs[upcard, DealerHands[dIndex].Hand.Total - 17] += prob * DealerHands[dIndex].Multiplier[upcard] / BJHandNumerator[upcard, hand.Cards[upcard], 1];
                                }
                            }
                        }
                        dIndex = DealerHands[dIndex].NextHandTotal;
                    }
                }
            }

            // Update the dictionary with the non-BJ adjusted dealerprobs
            if (!DealerProbs.Contains(key) & SaveDPDictionary)
            {
                var dprobs = new BJCADealerProbsClass();
                for (upcard = 1; upcard <= 10; upcard++)
                {
                    for (total = 17; total <= 21; total++)
                        dprobs.p[upcard, total - 17] = newEVs.DealerProbs[upcard, total - 17];
                }
                DealerProbs.Add(key, dprobs);
            }

            var loopTo3 = maxUC;
            for (upcard = minUC; upcard <= loopTo3; upcard++)
            {
                prob = newEVs.DealerProbs[upcard, 17 - 17] + newEVs.DealerProbs[upcard, 18 - 17] + newEVs.DealerProbs[upcard, 19 - 17] + newEVs.DealerProbs[upcard, 20 - 17] + newEVs.DealerProbs[upcard, 21 - 17];



                if (UCAllowed[upcard] & (prob > 0d | !computeAll & hand.Total != 21))
                {
                    // bjadjprob is the prob of dealer blackjack given the current playerhand and upcard
                    if (upcard == 1)
                    {
                        bjadjprob = BJHandNumerator[10, hand.Cards[10], 1] / BJHandDivisor[hand.NumCards + 1, 1];
                        if (CheckAce)
                        {
                            newEVs.DealerProbs[upcard, 17 - 17] = newEVs.DealerProbs[upcard, 17 - 17] / (1d - bjadjprob);
                            newEVs.DealerProbs[upcard, 18 - 17] = newEVs.DealerProbs[upcard, 18 - 17] / (1d - bjadjprob);
                            newEVs.DealerProbs[upcard, 19 - 17] = newEVs.DealerProbs[upcard, 19 - 17] / (1d - bjadjprob);
                            newEVs.DealerProbs[upcard, 20 - 17] = newEVs.DealerProbs[upcard, 20 - 17] / (1d - bjadjprob);
                            newEVs.DealerProbs[upcard, 21 - 17] = (newEVs.DealerProbs[upcard, 21 - 17] - bjadjprob) / (1d - bjadjprob);
                        }
                    }
                    else if (upcard == 10)
                    {
                        bjadjprob = BJHandNumerator[1, hand.Cards[1], 1] / BJHandDivisor[hand.NumCards + 1, 1];
                        if (CheckTen)
                        {
                            newEVs.DealerProbs[upcard, 17 - 17] = newEVs.DealerProbs[upcard, 17 - 17] / (1d - bjadjprob);
                            newEVs.DealerProbs[upcard, 18 - 17] = newEVs.DealerProbs[upcard, 18 - 17] / (1d - bjadjprob);
                            newEVs.DealerProbs[upcard, 19 - 17] = newEVs.DealerProbs[upcard, 19 - 17] / (1d - bjadjprob);
                            newEVs.DealerProbs[upcard, 20 - 17] = newEVs.DealerProbs[upcard, 20 - 17] / (1d - bjadjprob);
                            newEVs.DealerProbs[upcard, 21 - 17] = (newEVs.DealerProbs[upcard, 21 - 17] - bjadjprob) / (1d - bjadjprob);
                        }
                    }
                    else
                    {
                        bjadjprob = 0d;
                    }


                    // Need to count pushes as losses against blackjack if dealer is not checking
                    // bjadjprob will only be sent to gethandevev if the adjustment needs to be made
                    if (!(hand.Total == 21 & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen)))
                    {
                        bjadjprob = 0d;
                    }

                    // SetHandEV reads only DealerProbs, which it does not write.
                    SetHandEV(hand.Total, newEVs, upcard, bjadjprob, newEVs);
                }
            }

            return newEVs;

        }

        // ComputeStandHand(hand, upcard, upcard, false) for the split code, which asks for the same shoe
        // state many times over (once per strategy, split state and card order). The rules it reads are
        // fixed for the life of this object, so its result depends only on the cards removed, the player's
        // total, the upcard and whether the dealer checks for blackjack (CheckAce/CheckTen are switched
        // during splits), and those form the key. Callers read only this upcard's stand EVs, and a fresh
        // copy is returned each time because callers modify it.
        [NonSerialized]
        private Dictionary<SplitStandKey, BJCAHandEVsClass> splitStandMemo;

        private readonly record struct SplitStandKey(ulong Ranks1To8, ushort Ranks9To10, byte Total, byte Upcard, ushort NumCards, bool CheckAce, bool CheckTen);

        private BJCAHandEVsClass ComputeSplitStandHand(BJCAHandClass hand, int upcard)
        {
            ulong ranks1To8 = 0;
            for (int card = 1; card <= 8; card++)
            {
                if (hand.Cards[card] is < 0 or > 255)
                    return ComputeStandHand(hand, upcard, upcard, false);
                ranks1To8 |= (ulong)hand.Cards[card] << (8 * (card - 1));
            }
            if (hand.Cards[9] is < 0 or > 255 | hand.Cards[10] is < 0 or > 255 | hand.Total is < 0 or > 255 | hand.NumCards is < 0 or > ushort.MaxValue)
                return ComputeStandHand(hand, upcard, upcard, false);

            var key = new SplitStandKey(ranks1To8, (ushort)(hand.Cards[9] | hand.Cards[10] << 8), (byte)hand.Total, (byte)upcard, (ushort)hand.NumCards, CheckAce, CheckTen);
            splitStandMemo ??= new Dictionary<SplitStandKey, BJCAHandEVsClass>();
            if (!splitStandMemo.TryGetValue(key, out var stored))
            {
                stored = ComputeStandHand(hand, upcard, upcard, false);
                splitStandMemo.Add(key, stored);
            }

            var newEVs = new BJCAHandEVsClass();
            newEVs.StandEV[upcard] = stored.StandEV[upcard];
            newEVs.StandPushEV[upcard] = stored.StandPushEV[upcard];
            newEVs.BJStandEV[upcard] = stored.BJStandEV[upcard];
            return newEVs;
        }

        private void ComputeStand()
        {
            int index;
            int upcard;
            var newEVs = new BJCAHandEVsClass();

            var loopTo = NumPHands;
            for (index = 1; index <= loopTo; index++)
            {
                if (PlayerHands[index].Hand.NumCards > 1)
                {

                    newEVs = ComputeStandHand(PlayerHands[index].Hand, 1, 10, true);

                    for (upcard = 1; upcard <= 10; upcard++)
                    {
                        if (UCAllowed[upcard])
                        {
                            PlayerHands[index].HandEVs.StandEV[upcard] = newEVs.StandEV[upcard];
                            PlayerHands[index].HandEVs.StandPushEV[upcard] = newEVs.StandPushEV[upcard];
                            PlayerHands[index].HandEVs.BJStandEV[upcard] = newEVs.BJStandEV[upcard];
                            PlayerHands[index].HandEVs.DealerProbs[upcard, 0] = newEVs.DealerProbs[upcard, 0];
                            PlayerHands[index].HandEVs.DealerProbs[upcard, 1] = newEVs.DealerProbs[upcard, 1];
                            PlayerHands[index].HandEVs.DealerProbs[upcard, 2] = newEVs.DealerProbs[upcard, 2];
                            PlayerHands[index].HandEVs.DealerProbs[upcard, 3] = newEVs.DealerProbs[upcard, 3];
                            PlayerHands[index].HandEVs.DealerProbs[upcard, 4] = newEVs.DealerProbs[upcard, 4];
                        }
                    }
                }
            }
        }

        #endregion

        #region  Blackjack Methods 

        private BJCAHandEVsClass ComputeBlackjackHand(BJCAHandClass hand, int upcard, bool postSplit)
        {
            double bjadjprob;
            double netev;
            double spec10Fraction;
            var newEVs = new BJCAHandEVsClass();

            // This is only called post-split if post-split BJ's apply

            if (UCAllowed[upcard])
            {
                // The easiest way to adjust the BJ values to account for suited bonuses is to 
                // adjust the payoffs.
                // The Player's BJ hand has been dealt but not the Dealer's upcard

                if (BJBonuses.SpecificTen)
                {
                    spec10Fraction = BJBonuses.SpecificTenFraction;
                }
                else
                {
                    spec10Fraction = 0d;
                }

                // Readjust BJ for upcard 1 if Not Checking Ace - i.e. adjbjpays * Prob Dealer doesn't have BJ
                if (upcard == 1 & !CheckAce)
                {
                    bjadjprob = BJHandNumerator[10, hand.Cards[10], 1] / BJHandDivisor[hand.NumCards + 1, 1];
                    newEVs.StandEV[upcard] = BJPays * (1d - bjadjprob) + PDTies[22] * bjadjprob;
                    // HandContinues holds the MustWin value for Specific Tens
                    if (BJBonuses.HandContinues)
                    {
                        newEVs.StandEV[upcard] = newEVs.StandEV[upcard] * (1d - spec10Fraction) + (BJBonuses.PayoffGeneralBJ * (1d - bjadjprob) + PDTies[22] * bjadjprob) * spec10Fraction;
                        if (PDTies[22] == 0d)
                        {
                            newEVs.StandPushEV[upcard] = bjadjprob;
                        }
                        else
                        {
                            newEVs.StandPushEV[upcard] = 0d;
                        }
                    }
                    else
                    {
                        newEVs.StandEV[upcard] = newEVs.StandEV[upcard] * (1d - spec10Fraction) + BJBonuses.PayoffGeneralBJ * spec10Fraction;
                        if (PDTies[22] == 0d)
                        {
                            newEVs.StandPushEV[upcard] = bjadjprob * (1d - spec10Fraction);
                        }
                        else
                        {
                            newEVs.StandPushEV[upcard] = 0d;
                        }
                    }
                }
                else if (upcard == 10 & !CheckTen)
                {
                    // Adjust BJ for upcard 10 if Not Checking Ten
                    bjadjprob = BJHandNumerator[1, hand.Cards[1], 1] / BJHandDivisor[hand.NumCards + 1, 1];
                    newEVs.StandEV[upcard] = BJPays * (1d - bjadjprob) + PDTies[22] * bjadjprob;
                    // HandContinues holds the MustWin value for Specific Tens
                    if (BJBonuses.HandContinues)
                    {
                        newEVs.StandEV[upcard] = newEVs.StandEV[upcard] * (1d - spec10Fraction) + (BJBonuses.PayoffGeneralBJ * (1d - bjadjprob) + PDTies[22] * bjadjprob) * spec10Fraction;
                        if (PDTies[22] == 0d)
                        {
                            newEVs.StandPushEV[upcard] = bjadjprob;
                        }
                        else
                        {
                            newEVs.StandPushEV[upcard] = 0d;
                        }
                    }
                    else
                    {
                        newEVs.StandEV[upcard] = newEVs.StandEV[upcard] * (1d - spec10Fraction) + BJBonuses.PayoffGeneralBJ * spec10Fraction;
                        if (PDTies[22] == 0d)
                        {
                            newEVs.StandPushEV[upcard] = bjadjprob * (1d - spec10Fraction);
                        }
                        else
                        {
                            newEVs.StandPushEV[upcard] = 0d;
                        }
                    }
                }
                else if (upcard != 1 & upcard != 10 | postSplit)
                {
                    // Either the upcard is non A/10 or the dealer's checking and post-split
                    newEVs.StandEV[upcard] = BJPays * (1d - spec10Fraction) + BJBonuses.PayoffGeneralBJ * spec10Fraction;
                    newEVs.StandPushEV[upcard] = 0d;
                }
                else
                {
                    // All that's left is BJ Possible and Dealer Checking and pre-split
                    // First we need the unconditional values
                    // netev = bjpays * (1 - bjadjprob) + pdties(22) * bjadjprob
                    // Next we condition the values to allow fair future comparison
                    // newEVs.StandEV(upcard) = (netev + bjadjprob) / (1 - bjadjprob)
                    if (upcard == 1)
                    {
                        bjadjprob = BJHandNumerator[10, hand.Cards[10], 1] / BJHandDivisor[hand.NumCards + 1, 1];
                    }
                    else
                    {
                        bjadjprob = BJHandNumerator[1, hand.Cards[1], 1] / BJHandDivisor[hand.NumCards + 1, 1];
                    }

                    newEVs.StandEV[upcard] = BJPays * (1d - spec10Fraction) + BJBonuses.PayoffGeneralBJ * spec10Fraction;
                    // HandContinues holds the MustWin value for Specific Tens
                    if (BJBonuses.HandContinues)
                    {
                        newEVs.BJStandEV[upcard] = PDTies[22];
                        if (PDTies[22] == 0d)
                        {
                            newEVs.StandPushEV[upcard] = bjadjprob;
                        }
                        else
                        {
                            newEVs.StandPushEV[upcard] = 0d;
                        }
                    }
                    else
                    {
                        newEVs.BJStandEV[upcard] = PDTies[22] * (1d - spec10Fraction) + BJBonuses.PayoffGeneralBJ * spec10Fraction;
                        newEVs.StandPushEV[upcard] = 0d;
                    }

                }
            }

            return newEVs;

        }

        private void ComputeBlackjack()
        {
            int index;
            int upcard;
            var newEVs = new BJCAHandEVsClass();

            // Deal the BJ to the Player and find the hand
            if (CardProb(1, 0) > 0d)
            {
                DealPCard(1);
                if (CardProb(10, 0) > 0d)
                {
                    DealPCard(10);
                    index = FindPlayerHand(CurrentPHand);
                    if (index > 0)
                    {
                        // Adjust BJ for all upcards
                        for (upcard = 1; upcard <= 10; upcard++)
                        {
                            if (UCAllowed[upcard] & CardProb(upcard, 0) > 0d)
                            {
                                newEVs = ComputeBlackjackHand(CurrentPHand, upcard, false);

                                PlayerHands[index].HandEVs.StandEV[upcard] = newEVs.StandEV[upcard];
                                PlayerHands[index].HandEVs.StandPushEV[upcard] = newEVs.StandPushEV[upcard];
                                PlayerHands[index].HandEVs.BJStandEV[upcard] = newEVs.BJStandEV[upcard];
                            }
                        }
                    }
                    UndealPCard(10);
                }
                UndealPCard(1);
            }
        }

        private BJCASuitedBonusEVClass ApplyBJSuitedBonusesPayoffHand(ref BJCAPlayerHandClass pHand, int upcard, double bjprob)
        {
            double currentPayoff;
            double BJEV;

            double spec10Fraction;
            int suit;
            double pSuited;
            double pSpecificSuit;
            double p10Suited;
            double p10SpecificSuit;

            var newHandEVs = new BJCASuitedBonusEVClass();

            currentPayoff = pHand.HandEVs.StandEV[upcard];
            BJEV = pHand.HandEVs.BJStandEV[upcard];

            if (BJBonuses.SpecificTen)
            {
                spec10Fraction = BJBonuses.SpecificTenFraction;
            }
            else
            {
                spec10Fraction = 0d;
            }

            for (suit = 0; suit <= 3; suit++)
            {
                if (pHand.HandEVs.SuitedPossible[upcard, suit])
                {
                    // Determine whether the suit is the Specific Suit or not
                    if (BJBonuses.SpecificSuit)
                    {
                        if (BJBonuses.SuitToWin == suit)
                        {
                            pSuited = 0d;
                            pSpecificSuit = 1d;
                        }
                        else
                        {
                            pSuited = 1d;
                            pSpecificSuit = 0d;
                        }
                    }
                    else
                    {
                        pSuited = 1d;
                        pSpecificSuit = 0d;
                    }

                    // Determine whether the suit is the Specific Suit or not for the Specific Ten bonuses
                    if (spec10Fraction > 0d)
                    {
                        // PreSplit and PostSplit hold the Suited and Specific Suit values for the Specific Ten Bonuses
                        if (BJBonuses.PostSplit)
                        {
                            // Upcard holds the specific suit for the specific 10 bonuses
                            if (BJBonuses.Upcard == suit)
                            {
                                p10Suited = 0d;
                                p10SpecificSuit = 1d;
                            }
                            else
                            {
                                p10Suited = 1d;
                                p10SpecificSuit = 0d;
                            }
                        }
                        else
                        {
                            p10Suited = 1d;
                            p10SpecificSuit = 0d;
                        }
                    }
                    else
                    {
                        p10Suited = 0d;
                        p10SpecificSuit = 0d;
                    }


                    // Now adjust the evs
                    if (upcard != 1 & upcard != 10)
                    {
                        // If UC<>(1 or 10) then BJ always wins
                        if (pSuited > 0d)
                        {
                            if (BJBonuses.PayoffSuited == 0d)
                            {
                                newHandEVs.SuitedStandEV[upcard, suit] = pSuited * currentPayoff;
                            }
                            else
                            {
                                newHandEVs.SuitedStandEV[upcard, suit] = pSuited * BJBonuses.PayoffSuited;
                            }
                        }

                        if (pSpecificSuit > 0d)
                        {
                            if (BJBonuses.PayoffSpecificSuit == 0d)
                            {
                                newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * currentPayoff;
                            }
                            else
                            {
                                newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * BJBonuses.PayoffSpecificSuit;
                            }
                        }
                    }


                    else if (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen)
                    {
                        // No checking for BJ but BJ possible
                        if (!BJBonuses.MustWin)
                        {
                            // If it's not necessary to win - then it always wins since it's BJ and it beats dealer BJ
                            if (pSuited > 0d)
                            {
                                if (BJBonuses.PayoffSuited == 0d)
                                {
                                    newHandEVs.SuitedStandEV[upcard, suit] = pSuited * currentPayoff;
                                }
                                else
                                {
                                    newHandEVs.SuitedStandEV[upcard, suit] = pSuited * BJBonuses.PayoffSuited;
                                }
                            }

                            if (pSpecificSuit > 0d)
                            {
                                if (BJBonuses.PayoffSpecificSuit == 0d)
                                {
                                    newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * currentPayoff;
                                }
                                else
                                {
                                    newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * BJBonuses.PayoffSpecificSuit;
                                }
                            }
                        }
                        else
                        {
                            // Since hand Must Win, then BJ PDTies are still PDTies and it's a win otherwise
                            if (pSuited > 0d)
                            {
                                if (BJBonuses.PayoffSuited == 0d)
                                {
                                    newHandEVs.SuitedStandEV[upcard, suit] = pSuited * currentPayoff;
                                }
                                else
                                {
                                    newHandEVs.SuitedStandEV[upcard, suit] = pSuited * ((1d - bjprob) * BJBonuses.PayoffSuited + bjprob * PDTies[22]);
                                }
                            }

                            if (pSpecificSuit > 0d)
                            {
                                if (BJBonuses.PayoffSpecificSuit == 0d)
                                {
                                    newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * currentPayoff;
                                }
                                else
                                {
                                    newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * ((1d - bjprob) * BJBonuses.PayoffSpecificSuit + bjprob * PDTies[22]);
                                }
                            }
                        }
                    }


                    // BJ Possible and dealer checking
                    else if (!BJBonuses.MustWin)
                    {
                        // BJEV must be adjusted accordingly
                        if (pSuited > 0d)
                        {
                            if (BJBonuses.PayoffSuited == 0d)
                            {
                                newHandEVs.SuitedStandEV[upcard, suit] = pSuited * currentPayoff;
                                newHandEVs.SuitedStandBJEV[upcard, suit] = pSuited * BJEV;
                            }
                            else
                            {
                                newHandEVs.SuitedStandEV[upcard, suit] = pSuited * BJBonuses.PayoffSuited;
                                newHandEVs.SuitedStandBJEV[upcard, suit] = pSuited * BJBonuses.PayoffSuited;
                            }
                        }

                        if (pSpecificSuit > 0d)
                        {
                            if (BJBonuses.PayoffSpecificSuit == 0d)
                            {
                                newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * currentPayoff;
                                newHandEVs.SuitedStandBJEV[upcard, suit] = pSpecificSuit * BJEV;
                            }
                            else
                            {
                                newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * BJBonuses.PayoffSpecificSuit;
                                newHandEVs.SuitedStandBJEV[upcard, suit] = pSpecificSuit * BJBonuses.PayoffSpecificSuit;
                            }
                        }
                    }
                    else
                    {
                        // Since hand Must Win, pushev is unaffected 
                        if (pSuited > 0d)
                        {
                            if (BJBonuses.PayoffSuited == 0d)
                            {
                                newHandEVs.SuitedStandEV[upcard, suit] = pSuited * currentPayoff;
                                newHandEVs.SuitedStandBJEV[upcard, suit] = pSuited * BJEV;
                            }
                            else
                            {
                                newHandEVs.SuitedStandEV[upcard, suit] = pSuited * BJBonuses.PayoffSuited;
                                newHandEVs.SuitedStandBJEV[upcard, suit] = pSuited * BJEV;
                            }
                        }

                        if (pSpecificSuit > 0d)
                        {
                            if (BJBonuses.PayoffSpecificSuit == 0d)
                            {
                                newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * currentPayoff;
                                newHandEVs.SuitedStandBJEV[upcard, suit] = pSpecificSuit * BJEV;
                            }
                            else
                            {
                                newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * BJBonuses.PayoffSpecificSuit;
                                newHandEVs.SuitedStandBJEV[upcard, suit] = pSpecificSuit * BJEV;
                            }
                        }
                    }
                }
                else
                {
                    newHandEVs.SuitedStandEV[upcard, suit] = pHand.HandEVs.StandEV[upcard];
                }  // Suited Possible
            }

            return newHandEVs;

        }

        private void ApplyBJSuitedBonuses()
        {
            int index;
            int upcard;
            int suit;
            double bjprob;
            BJCASuitedBonusEVClass newEVs;

            index = BJIndex;
            if (index > 0 & BJBonuses.Suited)
            {
                NSuitedBonusHands += 1;
                SuitedBonusHands[NSuitedBonusHands] = index;

                NSuitedHands += 1;
                SuitedHandsList[NSuitedHands] = index;
                PlayerHands[index].SuitedBonusEVs = new BJCASuitedBonusEVClass();

                for (upcard = 1; upcard <= 10; upcard++)
                {
                    if (UCAllowed[upcard])
                    {
                        bjprob = PlayerHands[index].HandEVs.BJProb[upcard];
                        newEVs = ApplyBJSuitedBonusesPayoffHand(ref PlayerHands[index], upcard, bjprob);
                        // First copy over the Stand and BJ Stand EV's
                        for (suit = 0; suit <= 3; suit++)
                        {
                            PlayerHands[index].SuitedBonusEVs.SuitedStandEV[upcard, suit] = newEVs.SuitedStandEV[upcard, suit];
                            PlayerHands[index].SuitedBonusEVs.SuitedStandBJEV[upcard, suit] = newEVs.SuitedStandBJEV[upcard, suit];
                        }

                        // Now we need to determine the strategy
                        for (suit = 0; suit <= 3; suit++)
                        {
                            newEVs.Empty();
                            newEVs = ComputeSuitedStratHand(ref Opt, index, upcard, suit, true);
                            PlayerHands[index].SuitedBonusEVs.SuitedStratEV[upcard, suit] = newEVs.SuitedStratEV[upcard, suit];
                            PlayerHands[index].SuitedBonusEVs.SuitedStratBJEV[upcard, suit] = newEVs.SuitedStratBJEV[upcard, suit];
                            PlayerHands[index].SuitedBonusEVs.SuitedStrat[upcard, suit] = newEVs.SuitedStrat[upcard, suit];
                        }
                    }
                }
            }

        }

        #endregion

        #region  Double Methods 

        private BJCAHandEVsClass ComputeDoubleCardEV(int index, int upcard, int depth)
        {
            int strat;
            int card;
            double prob;
            double EV;
            double push;
            int newIndex;
            var tempEVs = new BJCAHandEVsClass();
            var newEVs = new BJCAHandEVsClass();

            // Here we limit the amount of redoubling allowed
            strat = PlayerHands[index].HandEVs.DStrat[upcard];
            if (strat == (int)BJCAGlobalsClass.Strat.D & depth > RDDepth)
            {
                strat = (int)BJCAGlobalsClass.Strat.S;
            }

            switch (strat)
            {
                case (int)BJCAGlobalsClass.Strat.D:
                    {
                        EV = 0d;
                        push = 0d;
                        for (card = 1; card <= 10; card++)
                        {
                            prob = CardProb(card, 0);
                            if (prob > 0d)
                            {
                                newIndex = PlayerHands[index].HitHand[card];
                                if (newIndex > 0)
                                {
                                    DealPCard(card);
                                    tempEVs = ComputeDoubleCardEV(newIndex, upcard, depth + 1);
                                    EV = tempEVs.DStratEV[upcard];
                                    push = tempEVs.DStratPushEV[upcard];
                                    newEVs.DEV[upcard] += 2d * tempEVs.DEV[upcard] * prob;
                                    UndealPCard(card);
                                }
                                else
                                {
                                    EV = -1;
                                    push = 0d;
                                }
                            }
                            newEVs.DStratEV[upcard] += 2d * EV * prob;
                            newEVs.DStratPushEV[upcard] += 2d * push * prob;
                        }

                        break;
                    }
                case (int)BJCAGlobalsClass.Strat.R:
                    {
                        if (DDRType == (int)BJCAGlobalsClass.Surr.ES)
                        {
                            newEVs.DStratEV[upcard] = SurrPays;
                        }
                        else
                        {
                            newEVs.DStratEV[upcard] = PlayerHands[index].HandEVs.SurrEV[upcard];
                        }
                        newEVs.DStratPushEV[upcard] = 0d;
                        if ((BBO | OBBO | AOBBO) & DDRType == (int)BJCAGlobalsClass.Surr.ES)
                        {
                            // Let the calling function know the hand was resolved before the BJ check
                            newEVs.DEV[upcard] = 1d;
                        }   // Stand

                        break;
                    }

                default:
                    {
                        newEVs.DStratEV[upcard] = PlayerHands[index].HandEVs.StandEV[upcard];
                        newEVs.DStratPushEV[upcard] = PlayerHands[index].HandEVs.StandPushEV[upcard];
                        if ((BBO | OBBO | AOBBO) & PlayerHands[index].Hand.Total == 21 & P21AutoWin)
                        {
                            // Let the calling function know the hand was resolved before the BJ check
                            newEVs.DEV[upcard] = 1d;
                        }

                        break;
                    }
            }

            return newEVs;
        }

        private BJCAHandEVsClass ComputeDoubleHand(int index, int upcard)
        {
            int card;
            double prob;
            double bustprob;
            double bjadjprob;
            int newIndex;
            var tempEVs = new BJCAHandEVsClass();
            var newEVs = new BJCAHandEVsClass();

            // The Hand and Upcard should be dealt already

            // In addition to determining the actual Double EV, we need to determine the strategies
            // for the hand when it is post double.  This includes figuring out the value of
            // the hand when standing which is only different if double softs count as hard.

            bustprob = 0d;
            newEVs.DPushEV[upcard] = 0d;
            for (card = 1; card <= 10; card++)
            {
                prob = CardProb(card, upcard);
                if (prob > 0d)
                {
                    if (Conversions.ToBoolean(PlayerHands[index].HitHand[card] & Conversions.ToInteger(PlayerHands[index].Hand.Soft) & Conversions.ToInteger(PlayerHands[PlayerHands[index].HitHand[card]].Hand.Cards[1] == 1) & Conversions.ToInteger(DSoftAllHard | DSoft19Hard & PlayerHands[index].Hand.Total == 19)))
                    {
                        // These hands can't bust so the next hand always exists
                        tempEVs.Empty();
                        tempEVs = GetHandEV(PlayerHands[index].Hand.Total - 10 + card, PlayerHands[PlayerHands[index].HitHand[card]].HandEVs, upcard, 0d);
                        newEVs.DEV[upcard] += 2d * prob * tempEVs.StandEV[upcard];
                        newEVs.DPushEV[upcard] += 2d * prob * tempEVs.StandPushEV[upcard];
                        // Deal with Player 21 beats BJ and OBBO
                        if ((BBO | OBBO | AOBBO) & PlayerHands[PlayerHands[index].HitHand[card]].Hand.Total - 10 + card == 21 & P21AutoWin)
                        {
                            if (upcard == 1 & !CheckAce & CardProb(10, 0) > 0d)
                            {
                                CurrentShoe.Deal(10);
                                bustprob += CardProb(card, 0);
                                CurrentShoe.Undeal(10);
                            }
                            else if (upcard == 10 & !CheckTen & CardProb(1, 0) > 0d)
                            {
                                CurrentShoe.Deal(1);
                                bustprob += CardProb(card, 0);
                                CurrentShoe.Undeal(1);
                            }
                        }
                    }
                    else if (Conversions.ToBoolean(PlayerHands[index].HitHand[card]))
                    {
                        if (!(DDR | RDA))
                        {
                            // The only option is to stand
                            newEVs.DEV[upcard] += 2d * prob * PlayerHands[PlayerHands[index].HitHand[card]].HandEVs.StandEV[upcard];
                            newEVs.DPushEV[upcard] += 2d * prob * PlayerHands[PlayerHands[index].HitHand[card]].HandEVs.StandPushEV[upcard];
                            if ((BBO | OBBO | AOBBO) & PlayerHands[PlayerHands[index].HitHand[card]].Hand.Total == 21 & P21AutoWin)
                            {
                                if (upcard == 1 & !CheckAce & CardProb(10, 0) > 0d)
                                {
                                    CurrentShoe.Deal(10);
                                    bustprob += CardProb(card, 0);
                                    CurrentShoe.Undeal(10);
                                }
                                else if (upcard == 10 & !CheckTen & CardProb(1, 0) > 0d)
                                {
                                    CurrentShoe.Deal(1);
                                    bustprob += CardProb(card, 0);
                                    CurrentShoe.Undeal(1);
                                }
                            }
                        }
                        else
                        {
                            DealPCard(card);
                            // We need to figure out the EV limiting the number of doubles to maximum number of redoubles
                            tempEVs.Empty();
                            tempEVs = ComputeDoubleCardEV(PlayerHands[index].HitHand[card], upcard, 1);
                            newEVs.DEV[upcard] += 2d * prob * tempEVs.DStratEV[upcard];
                            newEVs.DPushEV[upcard] += 2d * prob * tempEVs.DStratPushEV[upcard];
                            UndealPCard(card);
                            // tempevs.DEV =1 if the hand was reolved before the BJ check
                            if ((BBO | OBBO | AOBBO) & tempEVs.DEV[upcard] == 1d)
                            {
                                if (upcard == 1 & !CheckAce & CardProb(10, 0) > 0d)
                                {
                                    CurrentShoe.Deal(10);
                                    bustprob += CardProb(card, 0);
                                    CurrentShoe.Undeal(10);
                                }
                                else if (upcard == 10 & !CheckTen & CardProb(1, 0) > 0d)
                                {
                                    CurrentShoe.Deal(1);
                                    bustprob += CardProb(card, 0);
                                    CurrentShoe.Undeal(1);
                                }
                            }
                        }
                    }
                    else
                    {
                        newEVs.DEV[upcard] -= 2d * prob;
                        if (BBO | OBBO | AOBBO)
                        {
                            if (upcard == 1 & !CheckAce & CardProb(10, 0) > 0d)
                            {
                                CurrentShoe.Deal(10);
                                bustprob += CardProb(card, 0);
                                CurrentShoe.Undeal(10);
                            }
                            else if (upcard == 10 & !CheckTen & CardProb(1, 0) > 0d)
                            {
                                CurrentShoe.Deal(1);
                                bustprob += CardProb(card, 0);
                                CurrentShoe.Undeal(1);
                            }
                        }
                    }
                }
            }

            // EV(Double | OBBO) = (1 - prob(BJ)) * CEV + prob(BJ) * ((1-p(Bust|BJ)-p(21 win|BJ)-p(R|BJ))*(-1) - 2*p(Bust|BJ) + 2*p(21 win|BJ)+0.5*p(R|BJ))
            // EV(Double | OBBO) = (1 - prob(BJ)) * CEV - prob(BJ) * ((1-p(Bust|BJ)-p(21 win|BJ)-p(R|BJ)) + 2*p(Bust|BJ) - 2*p(21 win|BJ)-0.5*p(R|BJ))
            // EV(Double | OBBO) = (1 - prob(BJ)) * CEV - prob(BJ) * (1 + p(Bust|BJ) - 3*p(21 win|BJ) - 1.5*p(R|BJ))

            // EV(Double | ENHC) = (1 - prob(BJ)) * CEV + prob(BJ)  * ((1 - p(21 win|BJ)-p(R|BJ))*(-2) + p(21 win|BJ)*2+0.5*P(R|BJ))
            // EV(Double | ENHC) = (1 - prob(BJ)) * CEV + prob(BJ)  * (-2 + 2*p(21 win|BJ) + 2*p(R|BJ)+ p(21 win|BJ)*2 + 0.5*p(R|BJ))
            // EV(Double | ENHC) = (1 - prob(BJ)) * CEV + prob(BJ)  * (-2 + 4*p(21 win|BJ) + 2.5*p(R|BJ))
            // EV(Double | ENHC) = (1 - prob(BJ)) * CEV - prob(BJ)  * (2 - 4*p(21 win|BJ) - 2.5p(R|BJ))
            // EV(Double | ENHC) = (1 - prob(BJ)) * CEV - prob(BJ)  * (1 + p(Bust|BJ) - 3*p(21 win|BJ)  - 1.5*p(R|BJ) + 1 - p(Bust|BJ) - p(21 win|BJ) - p(R|BJ))

            // EV(Double | ENHC) = EV(Double | OBBO) - prob(BJ) *(1 - p(Bust|BJ) - p(21 win|BJ)-p(R|BJ))
            // Therefore:
            // EV(Double | OBBO) = EV(Double | ENHC) + prob(BJ)*(1 - p(Bust|BJ) - p(21 win|BJ)-p(R|BJ))
            if (BBO | OBBO | AOBBO)
            {
                if (upcard == 1 & !CheckAce)
                {
                    bjadjprob = CardProb(10, 0);
                }
                else if (upcard == 10 & !CheckTen)
                {
                    bjadjprob = CardProb(1, 0);
                }
                else
                {
                    bjadjprob = 0d;
                }
                newEVs.DEV[upcard] += bjadjprob * (1d - bustprob);
            }

            // Now we have DEV and DStandEV so we need to figure out DStrat
            tempEVs.Empty();
            tempEVs = ComputeDoubleStratHand(newEVs, index, upcard);
            newEVs.DStrat[upcard] = tempEVs.DStrat[upcard];
            newEVs.DStratEV[upcard] = tempEVs.DStratEV[upcard];
            newEVs.DStratPushEV[upcard] = tempEVs.DStratPushEV[upcard];

            return newEVs;
        }

        private void ComputeDoubleTotal(int total, bool soft)
        {
            int index;
            int upcard;
            int card;

            double prob;
            double bustprob;
            double bjadjprob;
            var newEVs = new BJCAHandEVsClass();

            index = PlayerHandTotal[total, Conversions.ToInteger(soft) + 1];
            while (index != 0)
            {
                CurrentShoe.Deal(PlayerHands[index].Hand);
                for (upcard = 1; upcard <= 10; upcard++)
                {
                    if (DoubleNeeded[index, upcard])
                    {
                        CurrentShoe.Deal(upcard);
                        newEVs = ComputeDoubleHand(index, upcard);
                        PlayerHands[index].HandEVs.DEV[upcard] = newEVs.DEV[upcard];
                        PlayerHands[index].HandEVs.DPushEV[upcard] = newEVs.DPushEV[upcard];
                        PlayerHands[index].HandEVs.DStratEV[upcard] = newEVs.DStratEV[upcard];
                        PlayerHands[index].HandEVs.DStratPushEV[upcard] = newEVs.DStratPushEV[upcard];
                        PlayerHands[index].HandEVs.DStrat[upcard] = newEVs.DStrat[upcard];
                        CurrentShoe.Undeal(upcard);
                    }
                }
                CurrentShoe.Undeal(PlayerHands[index].Hand);
                index = PlayerHands[index].NextHand;
            }
        }

        private void ComputeDouble()
        {
            int Total;

            // It is necessary to go by total similar to hitting because of redoubling.
            for (Total = 21; Total >= 11; Total -= 1)
                ComputeDoubleTotal(Total, false);
            for (Total = 21; Total >= 12; Total -= 1)
                ComputeDoubleTotal(Total, true);
            for (Total = 10; Total >= 4; Total -= 1)
                ComputeDoubleTotal(Total, false);
        }

        private BJCAHandEVsClass ComputeDoubleStratHand(BJCAHandEVsClass currEVs, int index, int upcard)
        {
            var newEVs = new BJCAHandEVsClass();
            double surrEV;

            // Begin with Stand as the strategy
            newEVs.DStratEV[upcard] = PlayerHands[index].HandEVs.StandEV[upcard];
            newEVs.DStratPushEV[upcard] = PlayerHands[index].HandEVs.StandPushEV[upcard];
            newEVs.DStrat[upcard] = (int)BJCAGlobalsClass.Strat.S;

            // Now check for Double strategy
            if (RDA)
            {
                if (currEVs.DEV[upcard] > newEVs.DStratEV[upcard])
                {
                    newEVs.DStratEV[upcard] = currEVs.DEV[upcard];
                    newEVs.DStratPushEV[upcard] = currEVs.DPushEV[upcard];
                    newEVs.DStrat[upcard] = (int)BJCAGlobalsClass.Strat.D;
                }
            }

            // Now finally check for Surrender strategy
            if (DDR)
            {
                if (DDRType == (int)BJCAGlobalsClass.Surr.ES)
                {
                    surrEV = SurrPays;
                }
                else
                {
                    surrEV = PlayerHands[index].HandEVs.SurrEV[upcard];
                }
                if (surrEV > newEVs.DStratEV[upcard])
                {
                    newEVs.DStratEV[upcard] = surrEV;
                    newEVs.DStratPushEV[upcard] = 0d;
                    newEVs.DStrat[upcard] = (int)BJCAGlobalsClass.Strat.R;
                }
            }

            return newEVs;

        }

        #endregion

        #region  Surrender Methods 

        private BJCAHandEVsClass ComputeSurrenderHand(BJCAHandClass hand, int surrAllowed, int upcard)
        {
            double bjadjprob;
            var newEVs = new BJCAHandEVsClass();

            if (UCAllowed[upcard] & surrAllowed != 0)
            {
                switch (surrAllowed)
                {
                    case (int)BJCAGlobalsClass.Surr.LS:
                        {
                            // Need to compare to conditional EV and ENHC/OBBO EV's are unconditional
                            // bjadjprob is the prob of dealer blackjack given the current playerhand and upcard
                            if (upcard == 1 & !CheckAce)
                            {
                                bjadjprob = BJHandNumerator[10, hand.Cards[10], 1] / BJHandDivisor[hand.NumCards + 1, 1];
                            }
                            else if (upcard == 10 & !CheckTen)
                            {
                                bjadjprob = BJHandNumerator[1, hand.Cards[1], 1] / BJHandDivisor[hand.NumCards + 1, 1];
                            }
                            else
                            {
                                bjadjprob = 0d;
                            }
                            newEVs.SurrEV[upcard] = SurrPays * (1d - bjadjprob) - bjadjprob;
                            break;
                        }
                    case (int)BJCAGlobalsClass.Surr.ES:
                        {
                            // Need to compare to unconditional EV and OBO EV's are conditional
                            if (upcard == 1 & (CheckAce | SurrDBJPays != SurrPays))
                            {
                                bjadjprob = BJHandNumerator[10, hand.Cards[10], 1] / BJHandDivisor[hand.NumCards + 1, 1];
                            }
                            else if (upcard == 10 & (CheckTen | SurrDBJPays != SurrPays))
                            {
                                bjadjprob = BJHandNumerator[1, hand.Cards[1], 1] / BJHandDivisor[hand.NumCards + 1, 1];
                            }
                            else
                            {
                                bjadjprob = 0d;
                            }
                            if (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen)
                            {
                                newEVs.SurrEV[upcard] = SurrPays * (1d - bjadjprob) + SurrDBJPays * bjadjprob;
                            }
                            else
                            {
                                newEVs.SurrEV[upcard] = (SurrPays * (1d - bjadjprob) + SurrDBJPays * bjadjprob + bjadjprob) / (1d - bjadjprob);
                            }

                            break;
                        }
                }
            }

            return newEVs;

        }

        private void ComputeSurrender()
        {
            int index;
            int upcard;
            var newEVs = new BJCAHandEVsClass();

            var loopTo = NumPHands;
            for (index = 1; index <= loopTo; index++)
            {
                if (PlayerHands[index].Hand.NumCards > 1)
                {
                    for (upcard = 1; upcard <= 10; upcard++)
                    {
                        if (SurrenderNeeded[index, upcard])
                        {
                            if (PlayerHands[index].RPreallowed[upcard] > 0)
                            {
                                newEVs = ComputeSurrenderHand(PlayerHands[index].Hand, PlayerHands[index].RPreallowed[upcard], upcard);
                            }
                            else
                            {
                                newEVs = ComputeSurrenderHand(PlayerHands[index].Hand, (int)BJCAGlobalsClass.Surr.LS, upcard);
                            }
                            PlayerHands[index].HandEVs.SurrEV[upcard] = newEVs.SurrEV[upcard];
                        }
                    }
                }
            }
        }

        #endregion

        #region  Bonus Methods 

        private BJCAHandEVsClass ApplyBonusRulesNonSuitedHand(BJCAPlayerHandClass pHand, int upcard, double bjprob, bool postSplit, bool postDouble)
        {
            bool apply;
            double winEV;
            double loseEV;
            double pushEV;
            double netEV;
            double tempBJPayoff;

            int rule;
            var newHandEVs = new BJCAHandEVsClass();

            bool noRulesApply;

            noRulesApply = true;
            // Make sure the rule isn't applied to player BJ pre-split
            if (!pHand.Hand.IsBJ() | postSplit)
            {
                // netEV = winEV - loseEV
                // winEV = netEV + loseEV
                // push = 1 - winEV - loseEV = 1 - (netEV + loseEV) - loseEV = 1 - netEV - 2*loseEV
                // loseEV = (1 - netEV - push) / 2
                loseEV = (1d - pHand.HandEVs.StandEV[upcard] - pHand.HandEVs.StandPushEV[upcard]) / 2d;
                winEV = pHand.HandEVs.StandEV[upcard] + loseEV;
                pushEV = pHand.HandEVs.StandPushEV[upcard];

                var loopTo = BonusRulesList.NumRules - 1;
                for (rule = 0; rule <= loopTo; rule++)
                {
                    if (BonusRulesList.L[rule].RuleOn)
                    {
                        // First see if the hand qualifies to have the rule applied to it
                        apply = false;

                        // If post-split bonuses are added then add the following below:      ((Not postSplit And BonusRulesList.L(rule).PreSplit) Or (postSplit And BonusRulesList.L(rule).PostSplit)) And 

                        if (BonusRulesList.L[rule].PreSplit & !postSplit | BonusRulesList.L[rule].PostSplit & postSplit)
                        {
                            if (BonusRulesList.L[rule].UseSpecificHand)
                            {
                                if (BonusRulesList.L[rule].ExactMatch & pHand.Hand.SameAs(BonusRulesList.L[rule].Hand) | !BonusRulesList.L[rule].ExactMatch & pHand.Hand.Includes(BonusRulesList.L[rule].Hand))
                                {
                                    apply = true;
                                }
                            }
                            else if (pHand.Hand.Total == BonusRulesList.L[rule].Hand.Total | BonusRulesList.L[rule].Hand.Total == 0)
                            {
                                if (!BonusRulesList.L[rule].HardSoftOnly | BonusRulesList.L[rule].HardSoftOnly & !BonusRulesList.L[rule].Hand.Soft & !pHand.Hand.Soft | BonusRulesList.L[rule].HardSoftOnly & BonusRulesList.L[rule].Hand.Soft & pHand.Hand.Soft)
                                {
                                    if (BonusRulesList.L[rule].Hand.NumCards == 0 | BonusRulesList.L[rule].Hand.NumCards == pHand.Hand.NumCards | BonusRulesList.L[rule].OrLess & pHand.Hand.NumCards <= BonusRulesList.L[rule].Hand.NumCards | BonusRulesList.L[rule].OrMore & pHand.Hand.NumCards >= BonusRulesList.L[rule].Hand.NumCards)
                                    {
                                        apply = true;
                                    }
                                }
                            }
                        }

                        if (apply)
                        {
                            noRulesApply = false;
                            newHandEVs.Empty();

                            // Apply the upcard limitation on BJ Payoffs here
                            // No need to check for other UC's since bjprob is 0 for them
                            if (upcard == 1 & BonusRulesList.L[rule].BJAUp | upcard == 10 & BonusRulesList.L[rule].BJTUp)
                            {
                                tempBJPayoff = BonusRulesList.L[rule].PayoffGeneralBJ;
                            }
                            else if (pHand.Hand.Total == 21 & P21AutoWin)
                            {
                                tempBJPayoff = 1d;
                            }
                            else
                            {
                                tempBJPayoff = -1;
                            }

                            // Now adjust the evs
                            // The upcard can only be non-zero and therefore only match if UCPayoff <> 0
                            if (upcard != 1 & upcard != 10 | upcard == 1 & CheckAce & (pHand.Hand.NumCards > 2 | postSplit) | upcard == 10 & CheckTen & (pHand.Hand.NumCards > 2 | postSplit))
                            {
                                // No BJ Possible if UC<>(1 or 10) or if Checking and >2 cards in hand
                                if (!BonusRulesList.L[rule].MustWin & !BonusRulesList.L[rule].HandContinues)
                                {
                                    if (BonusRulesList.L[rule].PayoffGeneral == 0d & !(BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCGeneral > 0d))
                                    {
                                        newHandEVs.StandEV[upcard] = winEV - loseEV;
                                        // Only need to include pushevs when not winning since otherwise adding 0
                                        newHandEVs.StandPushEV[upcard] = pushEV;
                                    }
                                    else if (BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCGeneral > 0d)
                                    {
                                        newHandEVs.StandEV[upcard] = BonusRulesList.L[rule].PayoffUCGeneral;
                                    }
                                    else
                                    {
                                        newHandEVs.StandEV[upcard] = BonusRulesList.L[rule].PayoffGeneral;
                                    }
                                }

                                else if (BonusRulesList.L[rule].HandContinues)
                                {
                                    if (BonusRulesList.L[rule].PayoffGeneral == 0d & !(BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCGeneral > 0d))
                                    {
                                        newHandEVs.StandEV[upcard] = winEV - loseEV;
                                        // Only need to include pushevs when not winning since otherwise adding 0
                                        newHandEVs.StandPushEV[upcard] = pushEV;
                                    }
                                    else if (BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCGeneral > 0d)
                                    {
                                        newHandEVs.StandEV[upcard] = winEV - loseEV;
                                        newHandEVs.BonusEV[upcard] = BonusRulesList.L[rule].PayoffUCGeneral;
                                        newHandEVs.StandPushEV[upcard] = pushEV;
                                    }
                                    else
                                    {
                                        newHandEVs.StandEV[upcard] = winEV - loseEV;
                                        newHandEVs.BonusEV[upcard] = BonusRulesList.L[rule].PayoffGeneral;
                                        newHandEVs.StandPushEV[upcard] = pushEV;
                                    }
                                }

                                else
                                {
                                    // Since hand Must Win, pushev is unaffected
                                    newHandEVs.StandPushEV[upcard] = pushEV;
                                    if (BonusRulesList.L[rule].PayoffGeneral == 0d & !(BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCGeneral > 0d))
                                    {
                                        newHandEVs.StandEV[upcard] = winEV - loseEV;
                                    }
                                    else if (BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCGeneral > 0d)
                                    {
                                        newHandEVs.StandEV[upcard] = BonusRulesList.L[rule].PayoffUCGeneral * winEV - loseEV;
                                    }
                                    else
                                    {
                                        newHandEVs.StandEV[upcard] = BonusRulesList.L[rule].PayoffGeneral * winEV - loseEV;
                                    }
                                }
                            }


                            else if (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen)
                            {
                                // No checking for BJ but BJ possible
                                // BJStandEV is assigned but ignored during the game EV calcs since it's incorporated in the regular ev
                                // It is used however for post-split OBBO calcs
                                if (!BonusRulesList.L[rule].MustWin & !BonusRulesList.L[rule].HandContinues)
                                {
                                    if (BonusRulesList.L[rule].PayoffGeneral == 0d & !(BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCGeneral > 0d))
                                    {
                                        newHandEVs.StandEV[upcard] = winEV - loseEV + bjprob + bjprob * tempBJPayoff;
                                        // Only need to include pushevs when not winning since otherwise adding 0
                                        newHandEVs.StandPushEV[upcard] = pushEV;
                                        newHandEVs.BJStandEV[upcard] = tempBJPayoff;
                                    }
                                    else if (BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCGeneral > 0d)
                                    {
                                        newHandEVs.StandEV[upcard] = (1d - bjprob) * BonusRulesList.L[rule].PayoffUCGeneral + bjprob * tempBJPayoff;
                                        newHandEVs.BJStandEV[upcard] = tempBJPayoff;
                                    }
                                    else
                                    {
                                        newHandEVs.StandEV[upcard] = (1d - bjprob) * BonusRulesList.L[rule].PayoffGeneral + bjprob * tempBJPayoff;
                                        newHandEVs.BJStandEV[upcard] = tempBJPayoff;
                                    }
                                }
                                else if (BonusRulesList.L[rule].HandContinues)
                                {
                                    if (BonusRulesList.L[rule].PayoffGeneral == 0d & !(BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCGeneral > 0d))
                                    {
                                        newHandEVs.StandEV[upcard] = winEV - loseEV + bjprob + bjprob * tempBJPayoff;
                                        // Only need to include pushevs when not winning since otherwise adding 0
                                        newHandEVs.StandPushEV[upcard] = pushEV;
                                        newHandEVs.BJStandEV[upcard] = tempBJPayoff;
                                    }
                                    else if (BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCGeneral > 0d)
                                    {
                                        newHandEVs.StandEV[upcard] = winEV - loseEV + bjprob + bjprob * tempBJPayoff;
                                        newHandEVs.BonusEV[upcard] = BonusRulesList.L[rule].PayoffUCGeneral;
                                        newHandEVs.StandPushEV[upcard] = pushEV;
                                        newHandEVs.BJStandEV[upcard] = tempBJPayoff;
                                    }
                                    else
                                    {
                                        newHandEVs.StandEV[upcard] = winEV - loseEV + bjprob + bjprob * tempBJPayoff;
                                        newHandEVs.BonusEV[upcard] = BonusRulesList.L[rule].PayoffGeneral;
                                        newHandEVs.StandPushEV[upcard] = pushEV;
                                        newHandEVs.BJStandEV[upcard] = tempBJPayoff;
                                    }
                                }
                                else
                                {
                                    // Since hand Must Win, pushev is unaffected and hand cannot beat BJ
                                    // BJPayoff will be -1 automatically from the form with must win checked
                                    newHandEVs.StandPushEV[upcard] = pushEV;
                                    newHandEVs.BJStandEV[upcard] = tempBJPayoff;
                                    if (BonusRulesList.L[rule].PayoffGeneral == 0d & !(BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCGeneral > 0d))
                                    {
                                        newHandEVs.StandEV[upcard] = winEV - loseEV;
                                    }
                                    else if (BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCGeneral > 0d)
                                    {
                                        newHandEVs.StandEV[upcard] = BonusRulesList.L[rule].PayoffUCGeneral * winEV - loseEV;
                                    }
                                    else
                                    {
                                        newHandEVs.StandEV[upcard] = BonusRulesList.L[rule].PayoffGeneral * winEV - loseEV;
                                    }
                                }
                            }


                            // BJ Possible and dealer checking and player's hand has 2 cards presplit
                            // No BJ adjustments need to be made when the hand doesn't beat BJ
                            // I.e. if PayoffBJ is -1, then the hand is already appropriately conditioned
                            else if (!BonusRulesList.L[rule].MustWin & !BonusRulesList.L[rule].HandContinues)
                            {
                                if (BonusRulesList.L[rule].PayoffGeneral == 0d & !(BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCGeneral > 0d))
                                {
                                    newHandEVs.StandEV[upcard] = winEV - loseEV;
                                    // Only need to include pushevs when not winning since otherwise adding 0
                                    newHandEVs.StandPushEV[upcard] = pushEV;
                                    newHandEVs.BJStandEV[upcard] = tempBJPayoff;
                                }
                                else if (BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCGeneral > 0d)
                                {
                                    // NetPayoff = pBJ*PayoffBJ + (1-pBJ)*Payoff
                                    // NetPayoff = pBJ*(-1) + (1-pBJ)*CEV
                                    // CEV = (NetPayoff + pBJ)/(1-pBJ)
                                    // netEV = bjprob * tempBJPayoff + (1 - bjprob) * BonusRulesList.L(rule).PayoffUC
                                    // newHandEVs.StandEV(upcard) =  (netEV + bjprob) / (1 - bjprob)
                                    newHandEVs.StandEV[upcard] = BonusRulesList.L[rule].PayoffUCGeneral;
                                    newHandEVs.StandPushEV[upcard] = 0d;
                                    newHandEVs.BJStandEV[upcard] = tempBJPayoff;
                                }
                                else
                                {
                                    // netEV = bjprob * tempBJPayoff + (1 - bjprob) * BonusRulesList.L(rule).PayoffGeneral
                                    // newHandEVs.StandEV(upcard) =  (netEV + bjprob) / (1 - bjprob)
                                    newHandEVs.StandEV[upcard] = BonusRulesList.L[rule].PayoffGeneral;
                                    newHandEVs.StandPushEV[upcard] = 0d;
                                    newHandEVs.BJStandEV[upcard] = tempBJPayoff;
                                }
                            }
                            else if (BonusRulesList.L[rule].HandContinues)
                            {
                                if (BonusRulesList.L[rule].PayoffGeneral == 0d & !(BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCGeneral > 0d))
                                {
                                    newHandEVs.StandEV[upcard] = winEV - loseEV;
                                    // Only need to include pushevs when not winning since otherwise adding 0
                                    newHandEVs.BJStandEV[upcard] = tempBJPayoff;
                                    newHandEVs.StandPushEV[upcard] = pushEV;
                                }
                                else if (BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCGeneral > 0d)
                                {
                                    // NetPayoff = pBJ*PayoffBJ + (1-pBJ)*Payoff
                                    // NetPayoff = pBJ*(-1) + (1-pBJ)*CEV
                                    // CEV = (NetPayoff + pBJ)/(1-pBJ)
                                    // netEV = bjprob * tempBJPayoff + (1 - bjprob) * ((winEV - loseEV) + BonusRulesList.L(rule).PayoffUC)
                                    // newHandEVs.StandEV(upcard) =  (netEV + bjprob) / (1 - bjprob)
                                    newHandEVs.StandEV[upcard] = winEV - loseEV;
                                    newHandEVs.BonusEV[upcard] = BonusRulesList.L[rule].PayoffUCGeneral;
                                    newHandEVs.BJStandEV[upcard] = tempBJPayoff;
                                    newHandEVs.StandPushEV[upcard] = pushEV;
                                }
                                else
                                {
                                    // netEV = bjprob * tempBJPayoff + (1 - bjprob) * ((winEV - loseEV) + BonusRulesList.L(rule).PayoffGeneral)
                                    // newHandEVs.StandEV(upcard) =  (netEV + bjprob) / (1 - bjprob)
                                    newHandEVs.StandEV[upcard] = winEV - loseEV;
                                    newHandEVs.BonusEV[upcard] = BonusRulesList.L[rule].PayoffGeneral;
                                    newHandEVs.BJStandEV[upcard] = tempBJPayoff;
                                    newHandEVs.StandPushEV[upcard] = pushEV;
                                }
                            }
                            else
                            {
                                // Since hand Must Win, pushev is unaffected and BJ hand cannot beat BJ
                                // BJPayoff will be -1 automatically from the form with must win checked
                                newHandEVs.StandPushEV[upcard] = pushEV;
                                newHandEVs.BJStandEV[upcard] = tempBJPayoff;
                                if (BonusRulesList.L[rule].PayoffGeneral == 0d & !(BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCGeneral > 0d))
                                {
                                    newHandEVs.StandEV[upcard] = winEV - loseEV;
                                }
                                else if (BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCGeneral > 0d)
                                {
                                    newHandEVs.StandEV[upcard] = BonusRulesList.L[rule].PayoffUCGeneral * winEV - loseEV;
                                }
                                else
                                {
                                    newHandEVs.StandEV[upcard] = BonusRulesList.L[rule].PayoffGeneral * winEV - loseEV;
                                }
                            }
                        }  // Apply
                    }  // Rule On
                }

                if (pHand.Hand.Total == 21 & P21AutoWin & newHandEVs.BJStandEV[upcard] == -1)
                {
                    newHandEVs.BJStandEV[upcard] = 1d;
                }
            }  // Not BJ

            if (noRulesApply)
            {
                newHandEVs.StandEV[upcard] = pHand.HandEVs.StandEV[upcard];
                newHandEVs.StandPushEV[upcard] = pHand.HandEVs.StandPushEV[upcard];
            }

            return newHandEVs;
        }

        private void ApplyBonusRulesPreSuited()
        {
            // Apply both the Dealer-Player Push rules as well as the bonus Rules.
            // Bonus Rules override Dealer-Player push rules 
            int index;
            int upcard;
            var bjprob = default(double);
            var newEVs = new BJCAHandEVsClass();

            if (BonusRuleOn)
            {
                CurrentShoe.Reset(OriginalShoe);
                var loopTo = NumPHands;
                for (index = 1; index <= loopTo; index++)
                {
                    // Adjustment for player blackjack is separate
                    if (PlayerHands[index].Hand.NumCards > 1 & !PlayerHands[index].Hand.IsBJ())
                    {
                        for (upcard = 1; upcard <= 10; upcard++)
                        {
                            if (UCAllowed[upcard] & CardProb(upcard, 0) > 0d)
                            {
                                if (upcard == 1)
                                {
                                    bjprob = BJHandNumerator[10, PlayerHands[index].Hand.Cards[10], 1] / BJHandDivisor[PlayerHands[index].Hand.NumCards + 1, 1];
                                }
                                else if (upcard == 10)
                                {
                                    bjprob = BJHandNumerator[1, PlayerHands[index].Hand.Cards[1], 1] / BJHandDivisor[PlayerHands[index].Hand.NumCards + 1, 1];
                                }

                                // Rules will be applied in sequence and override the previous rules.
                                newEVs.Empty();
                                newEVs = ApplyBonusRulesNonSuitedHand(PlayerHands[index], upcard, bjprob, false, false);
                                PlayerHands[index].HandEVs.StandEV[upcard] = newEVs.StandEV[upcard];
                                PlayerHands[index].HandEVs.BJStandEV[upcard] = newEVs.BJStandEV[upcard];
                                PlayerHands[index].HandEVs.StandPushEV[upcard] = newEVs.StandPushEV[upcard];
                                PlayerHands[index].HandEVs.BonusEV[upcard] = newEVs.BonusEV[upcard];
                            }
                        }
                    }
                }
            }
        }

        private BJCASuitedBonusEVClass ApplyBonusRuleSuitedHand(int rule, ref BJCAPlayerHandClass pHand, int upcard, double bjprob)
        {
            double winEV;
            double loseEV;
            double pushEV;
            double netEV;
            double tempBJPayoff;

            int suit;
            int card;
            int i;

            double pSuited;
            double pSpecificSuit;

            var newHandEVs = new BJCASuitedBonusEVClass();

            // Make sure the rule isn't applied to player BJ
            if (!pHand.Hand.IsBJ())
            {
                // netEV = winEV - loseEV
                // winEV = netEV + loseEV
                // push = 1 - winEV - loseEV = 1 - (netEV + loseEV) - loseEV = 1 - netEV - 2*loseEV
                // loseEV = (1 - netEV - push) / 2
                loseEV = (1d - pHand.HandEVs.StandEV[upcard] - pHand.HandEVs.StandPushEV[upcard]) / 2d;
                winEV = pHand.HandEVs.StandEV[upcard] + loseEV;
                pushEV = pHand.HandEVs.StandPushEV[upcard];

                if (BonusRulesList.L[rule].RuleOn & BonusRulesList.L[rule].Suited)
                {
                    // First see if the hand qualifies to have the rule applied to it

                    for (suit = 0; suit <= 3; suit++)
                    {
                        if (pHand.HandEVs.SuitedPossible[upcard, suit])
                        {
                            if (BonusRulesList.L[rule].SpecificSuit)
                            {
                                if (BonusRulesList.L[rule].SuitToWin == suit)
                                {
                                    pSuited = 0d;
                                    pSpecificSuit = 1d;
                                }
                                else
                                {
                                    pSuited = 1d;
                                    pSpecificSuit = 0d;
                                }
                            }
                            else
                            {
                                pSuited = 1d;
                                pSpecificSuit = 0d;
                            }

                            // Apply the upcard limitation on BJ Payoffs here
                            // No need to check for other UC's since bjprob is 0 for them
                            if (upcard == 1 & BonusRulesList.L[rule].BJAUp | upcard == 10 & BonusRulesList.L[rule].BJTUp)
                            {
                                if (pSuited > 0d)
                                {
                                    tempBJPayoff = BonusRulesList.L[rule].PayoffSuitedBJ;
                                    newHandEVs.SuitedStandBJEV[upcard, suit] = 0d;
                                }
                                else if (pSpecificSuit > 0d)
                                {
                                    tempBJPayoff = BonusRulesList.L[rule].PayoffSpecificSuitBJ;
                                    newHandEVs.SuitedStandBJEV[upcard, suit] = 0d;
                                }
                                else
                                {
                                    tempBJPayoff = BonusRulesList.L[rule].PayoffSuitedBJ;
                                    newHandEVs.SuitedStandBJEV[upcard, suit] = tempBJPayoff;
                                }
                            }
                            else
                            {
                                tempBJPayoff = -1;
                            }

                            // Now adjust the evs
                            // The upcard can only be non-zero and therefore only match if UCPayoff <> 0
                            if (upcard != 1 & upcard != 10 | upcard == 1 & CheckAce & pHand.Hand.NumCards > 2 | upcard == 10 & CheckTen & pHand.Hand.NumCards > 2)
                            {
                                // No BJ Possible if UC<>(1 or 10) or if Checking and >2 cards in hand
                                if (!BonusRulesList.L[rule].MustWin & !BonusRulesList.L[rule].HandContinues)
                                {
                                    // Only need to include pushevs when not winning since otherwise adding 0
                                    if (pSuited > 0d)
                                    {
                                        if (BonusRulesList.L[rule].PayoffSuited == 0d & !(BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSuited > 0d))
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSuited * (winEV - loseEV);
                                        }
                                        // newHandEVs.StandPushEV(upcard) = pSuited * pushEV
                                        else if (BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSuited > 0d)
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSuited * BonusRulesList.L[rule].PayoffUCSuited;
                                        }
                                        else
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSuited * BonusRulesList.L[rule].PayoffSuited;
                                        }
                                    }

                                    if (pSpecificSuit > 0d)
                                    {
                                        if (BonusRulesList.L[rule].PayoffSpecificSuit == 0d & !(BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSpecificSuit > 0d))
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * (winEV - loseEV);
                                        }
                                        // newHandEVs.StandPushEV(upcard) = pSpecificSuit * pushEV
                                        else if (BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSpecificSuit > 0d)
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * BonusRulesList.L[rule].PayoffUCSpecificSuit;
                                        }
                                        else
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * BonusRulesList.L[rule].PayoffSpecificSuit;
                                        }
                                    }
                                }
                                else if (BonusRulesList.L[rule].HandContinues)
                                {
                                    // Only need to include pushevs when not winning since otherwise adding 0
                                    if (pSuited > 0d)
                                    {
                                        if (BonusRulesList.L[rule].PayoffSuited == 0d & !(BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSuited > 0d))
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSuited * (winEV - loseEV);
                                        }
                                        // newHandEVs.StandPushEV(upcard) = pSuited * pushEV
                                        else if (BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSuited > 0d)
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSuited * (winEV - loseEV);
                                            newHandEVs.SuitedBonusEV[upcard, suit] = pSuited * BonusRulesList.L[rule].PayoffUCSuited;
                                        }
                                        // newHandEVs.StandPushEV(upcard) = pSuited * pushEV
                                        else
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSuited * (winEV - loseEV);
                                            newHandEVs.SuitedBonusEV[upcard, suit] = pSuited * BonusRulesList.L[rule].PayoffSuited;
                                            // newHandEVs.StandPushEV(upcard) = pSuited * pushEV
                                        }
                                    }

                                    if (pSpecificSuit > 0d)
                                    {
                                        if (BonusRulesList.L[rule].PayoffSpecificSuit == 0d & !(BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSpecificSuit > 0d))
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * (winEV - loseEV);
                                        }
                                        // newHandEVs.StandPushEV(upcard) = pSpecificSuit * pushEV
                                        else if (BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSpecificSuit > 0d)
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * (winEV - loseEV);
                                            newHandEVs.SuitedBonusEV[upcard, suit] = pSpecificSuit * BonusRulesList.L[rule].PayoffUCSpecificSuit;
                                        }
                                        // newHandEVs.StandPushEV(upcard) = pSpecificSuit * pushEV
                                        else
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * (winEV - loseEV);
                                            newHandEVs.SuitedBonusEV[upcard, suit] = pSpecificSuit * BonusRulesList.L[rule].PayoffSpecificSuit;
                                            // newHandEVs.StandPushEV(upcard) = pSpecificSuit * pushEV
                                        }
                                    }
                                }
                                else
                                {
                                    // Since hand Must Win, pushev is unaffected
                                    // newHandEVs.StandPushEV(upcard) = pushEV
                                    if (pSuited > 0d)
                                    {
                                        if (BonusRulesList.L[rule].PayoffSuited == 0d & !(BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSuited > 0d))
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSuited * (winEV - loseEV);
                                        }
                                        else if (BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSuited > 0d)
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSuited * (BonusRulesList.L[rule].PayoffUCSuited * winEV - loseEV);
                                        }
                                        else
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSuited * (BonusRulesList.L[rule].PayoffSuited * winEV - loseEV);
                                        }
                                    }

                                    if (pSpecificSuit > 0d)
                                    {
                                        if (BonusRulesList.L[rule].PayoffSpecificSuit == 0d & !(BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSpecificSuit > 0d))
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * (winEV - loseEV);
                                        }
                                        else if (BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSpecificSuit > 0d)
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * (BonusRulesList.L[rule].PayoffUCSpecificSuit * winEV - loseEV);
                                        }
                                        else
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * (BonusRulesList.L[rule].PayoffSpecificSuit * winEV - loseEV);
                                        }
                                    }
                                }
                            }


                            else if (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen)
                            {
                                // No checking for BJ but BJ possible
                                if (!BonusRulesList.L[rule].MustWin & !BonusRulesList.L[rule].HandContinues)
                                {
                                    // Only need to include pushevs when not winning since otherwise adding 0
                                    if (pSuited > 0d)
                                    {
                                        if (BonusRulesList.L[rule].PayoffSuited == 0d & !(BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSuited > 0d))
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSuited * ((1d - bjprob) * (winEV - loseEV + bjprob) + bjprob * tempBJPayoff);
                                            newHandEVs.SuitedStandBJEV[upcard, suit] = pSuited * tempBJPayoff;
                                        }
                                        // newHandEVs.StandPushEV(upcard) = pSuited * pushEV
                                        else if (BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSuited > 0d)
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSuited * ((1d - bjprob) * BonusRulesList.L[rule].PayoffUCSuited + bjprob * tempBJPayoff);
                                            newHandEVs.SuitedStandBJEV[upcard, suit] = pSuited * tempBJPayoff;
                                        }
                                        else
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSuited * ((1d - bjprob) * BonusRulesList.L[rule].PayoffSuited + bjprob * tempBJPayoff);
                                            newHandEVs.SuitedStandBJEV[upcard, suit] = pSuited * tempBJPayoff;
                                        }
                                    }

                                    if (pSpecificSuit > 0d)
                                    {
                                        if (BonusRulesList.L[rule].PayoffSpecificSuit == 0d & !(BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSpecificSuit > 0d))
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * ((1d - bjprob) * (winEV - loseEV + bjprob) + bjprob * tempBJPayoff);
                                            newHandEVs.SuitedStandBJEV[upcard, suit] = pSpecificSuit * tempBJPayoff;
                                        }
                                        // newHandEVs.StandPushEV(upcard) = pSpecificSuit * pushEV
                                        else if (BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSpecificSuit > 0d)
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * ((1d - bjprob) * BonusRulesList.L[rule].PayoffUCSpecificSuit + bjprob * tempBJPayoff);
                                            newHandEVs.SuitedStandBJEV[upcard, suit] = pSpecificSuit * tempBJPayoff;
                                        }
                                        else
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * ((1d - bjprob) * BonusRulesList.L[rule].PayoffSpecificSuit + bjprob * tempBJPayoff);
                                            newHandEVs.SuitedStandBJEV[upcard, suit] = pSpecificSuit * tempBJPayoff;
                                        }
                                    }
                                }
                                else if (BonusRulesList.L[rule].HandContinues)
                                {
                                    // Only need to include pushevs when not winning since otherwise adding 0
                                    if (pSuited > 0d)
                                    {
                                        if (BonusRulesList.L[rule].PayoffSuited == 0d & BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSuited > 0d)
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSuited * (winEV - loseEV);
                                        }
                                        // newHandEVs.StandPushEV(upcard) = pSuited * pushEV
                                        else if (BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSuited > 0d)
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSuited * (winEV - loseEV);
                                            newHandEVs.SuitedBonusEV[upcard, suit] = pSuited * BonusRulesList.L[rule].PayoffUCSuited;
                                        }
                                        // newHandEVs.StandPushEV(upcard) = pSuited * pushEV
                                        else
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSuited * (winEV - loseEV);
                                            newHandEVs.SuitedBonusEV[upcard, suit] = pSuited * BonusRulesList.L[rule].PayoffSuited;
                                            // newHandEVs.StandPushEV(upcard) = pSuited * pushEV
                                        }
                                    }

                                    if (pSpecificSuit > 0d)
                                    {
                                        if (BonusRulesList.L[rule].PayoffSpecificSuit == 0d & !(BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSpecificSuit > 0d))
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * (winEV - loseEV);
                                        }
                                        // newHandEVs.StandPushEV(upcard) = pSpecificSuit * pushEV
                                        else if (BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSpecificSuit > 0d)
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * (winEV - loseEV);
                                            newHandEVs.SuitedBonusEV[upcard, suit] = pSpecificSuit * BonusRulesList.L[rule].PayoffUCSpecificSuit;
                                        }
                                        // newHandEVs.StandPushEV(upcard) = pSpecificSuit * pushEV
                                        else
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * (winEV - loseEV);
                                            newHandEVs.SuitedBonusEV[upcard, suit] = pSpecificSuit * BonusRulesList.L[rule].PayoffSpecificSuit;
                                            // newHandEVs.StandPushEV(upcard) = pSpecificSuit * pushEV
                                        }
                                    }
                                }

                                else
                                {
                                    // Since hand Must Win, pushev is unaffected and hand cannot beat BJ
                                    // newHandEVs.StandPushEV(upcard) = pushEV
                                    if (pSuited > 0d)
                                    {
                                        if (BonusRulesList.L[rule].PayoffSuited == 0d & !(BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSuited > 0d))
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSuited * (winEV - loseEV);
                                        }
                                        else if (BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSuited > 0d)
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSuited * (BonusRulesList.L[rule].PayoffUCSuited * winEV - loseEV);
                                        }
                                        else
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSuited * (BonusRulesList.L[rule].PayoffSuited * winEV - loseEV);
                                        }
                                    }

                                    if (pSpecificSuit > 0d)
                                    {
                                        if (BonusRulesList.L[rule].PayoffSpecificSuit == 0d & !(BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSpecificSuit > 0d))
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * (winEV - loseEV);
                                        }
                                        else if (BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSpecificSuit > 0d)
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * (BonusRulesList.L[rule].PayoffUCSpecificSuit * winEV - loseEV);
                                        }
                                        else
                                        {
                                            newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * (BonusRulesList.L[rule].PayoffSpecificSuit * winEV - loseEV);
                                        }
                                    }
                                }
                            }


                            // BJ Possible and dealer checking and player's hand has 2 cards
                            // No BJ adjustments need to be made when the hand doesn't beat BJ
                            // I.e. if PayoffBJ is -1, then the hand is already appropriately conditioned
                            else if (!BonusRulesList.L[rule].MustWin & !BonusRulesList.L[rule].HandContinues)
                            {
                                // Only need to include pushevs when not winning since otherwise adding 0
                                if (pSuited > 0d)
                                {
                                    if (BonusRulesList.L[rule].PayoffSuited == 0d & !(BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSuited > 0d))
                                    {
                                        newHandEVs.SuitedStandEV[upcard, suit] = pSuited * (winEV - loseEV);
                                        newHandEVs.SuitedStandBJEV[upcard, suit] = pSuited * tempBJPayoff;
                                    }
                                    // newHandEVs.StandPushEV(upcard) = pSuited * pushEV
                                    else if (BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSuited > 0d)
                                    {
                                        // netEV = bjprob * tempBJPayoff + (1 - bjprob) * BonusRulesList.L(rule).PayoffUC
                                        // newHandEVs.suitedstandev(upcard,suit) = pSuited * (netEV + bjprob) / (1 - bjprob)
                                        newHandEVs.SuitedStandEV[upcard, suit] = pSuited * BonusRulesList.L[rule].PayoffUCSuited;
                                        newHandEVs.SuitedStandBJEV[upcard, suit] = pSuited * tempBJPayoff;
                                    }
                                    else
                                    {
                                        // netEV = bjprob * tempBJPayoff + (1 - bjprob) * BonusRulesList.L(rule).PayoffSuited
                                        // newHandEVs.suitedstandev(upcard,suit) = pSuited * (netEV + bjprob) / (1 - bjprob)
                                        newHandEVs.SuitedStandEV[upcard, suit] = pSuited * BonusRulesList.L[rule].PayoffSuited;
                                        newHandEVs.SuitedStandBJEV[upcard, suit] = pSuited * tempBJPayoff;
                                    }
                                }

                                if (pSpecificSuit > 0d)
                                {
                                    if (BonusRulesList.L[rule].PayoffSpecificSuit == 0d & !(BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSpecificSuit > 0d))
                                    {
                                        newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * (winEV - loseEV);
                                        newHandEVs.SuitedStandBJEV[upcard, suit] = pSpecificSuit * tempBJPayoff;
                                    }
                                    // newHandEVs.StandPushEV(upcard) = pSpecificSuit * pushEV
                                    else if (BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSpecificSuit > 0d)
                                    {
                                        // netEV = bjprob * tempBJPayoff + (1 - bjprob) * BonusRulesList.L(rule).PayoffUC
                                        // newHandEVs.suitedstandev(upcard,suit) = pSpecificSuit * (netEV + bjprob) / (1 - bjprob)
                                        newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * BonusRulesList.L[rule].PayoffUCSpecificSuit;
                                        newHandEVs.SuitedStandBJEV[upcard, suit] = pSpecificSuit * tempBJPayoff;
                                    }
                                    else
                                    {
                                        // netEV = bjprob * tempBJPayoff + (1 - bjprob) * BonusRulesList.L(rule).PayoffSpecificSuit
                                        // newHandEVs.suitedstandev(upcard,suit) = pSpecificSuit * (netEV + bjprob) / (1 - bjprob)
                                        newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * BonusRulesList.L[rule].PayoffSpecificSuit;
                                        newHandEVs.SuitedStandBJEV[upcard, suit] = pSpecificSuit * tempBJPayoff;
                                    }
                                }
                            }
                            else if (BonusRulesList.L[rule].HandContinues)
                            {
                                // Only need to include pushevs when not winning since otherwise adding 0
                                if (pSuited > 0d)
                                {
                                    if (BonusRulesList.L[rule].PayoffSuited == 0d & !(BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSuited > 0d))
                                    {
                                        newHandEVs.SuitedStandEV[upcard, suit] = pSuited * (winEV - loseEV);
                                        newHandEVs.SuitedStandBJEV[upcard, suit] = pSuited * -1;
                                    }
                                    // newHandEVs.StandPushEV(upcard) = pSuited * pushEV
                                    else if (BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSuited > 0d)
                                    {
                                        // netEV = bjprob * tempBJPayoff + (1 - bjprob) * ((winEV - loseEV) + BonusRulesList.L(rule).PayoffUC)
                                        // newHandEVs.suitedstandev(upcard,suit) = pSuited * (netEV + bjprob) / (1 - bjprob)
                                        newHandEVs.SuitedStandEV[upcard, suit] = pSuited * (winEV - loseEV);
                                        newHandEVs.SuitedBonusEV[upcard, suit] = pSuited * BonusRulesList.L[rule].PayoffUCSuited;
                                        newHandEVs.SuitedStandBJEV[upcard, suit] = pSuited * tempBJPayoff;
                                    }
                                    // newHandEVs.StandPushEV(upcard) = pSuited * pushEV
                                    else
                                    {
                                        // netEV = bjprob * tempBJPayoff + (1 - bjprob) * ((winEV - loseEV) + BonusRulesList.L(rule).PayoffSuited)
                                        // newHandEVs.suitedstandev(upcard,suit) = pSuited * (netEV + bjprob) / (1 - bjprob)
                                        newHandEVs.SuitedStandEV[upcard, suit] = pSuited * (winEV - loseEV);
                                        newHandEVs.SuitedBonusEV[upcard, suit] = pSuited * BonusRulesList.L[rule].PayoffSuited;
                                        newHandEVs.SuitedStandBJEV[upcard, suit] = pSuited * tempBJPayoff;
                                        // newHandEVs.StandPushEV(upcard) = pSuited * pushEV
                                    }
                                }

                                if (pSpecificSuit > 0d)
                                {
                                    if (BonusRulesList.L[rule].PayoffSpecificSuit == 0d & !(BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSpecificSuit > 0d))
                                    {
                                        newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * (winEV - loseEV);
                                        newHandEVs.SuitedStandBJEV[upcard, suit] = pSpecificSuit * -1;
                                    }
                                    // newHandEVs.StandPushEV(upcard) = pSpecificSuit * pushEV
                                    else if (BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSpecificSuit > 0d)
                                    {
                                        // netEV = bjprob * tempBJPayoff + (1 - bjprob) * ((winEV - loseEV) + BonusRulesList.L(rule).PayoffUC)
                                        // newHandEVs.suitedstandev(upcard,suit) = pSpecificSuit * (netEV + bjprob) / (1 - bjprob)
                                        newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * (winEV - loseEV);
                                        newHandEVs.SuitedBonusEV[upcard, suit] = pSpecificSuit * BonusRulesList.L[rule].PayoffUCSpecificSuit;
                                        newHandEVs.SuitedStandBJEV[upcard, suit] = pSpecificSuit * tempBJPayoff;
                                    }
                                    // newHandEVs.StandPushEV(upcard) = pSpecificSuit * pushEV
                                    else
                                    {
                                        // netEV = bjprob * tempBJPayoff + (1 - bjprob) * ((winEV - loseEV) + BonusRulesList.L(rule).PayoffSpecificSuit)
                                        // newHandEVs.suitedstandev(upcard,suit) = pSpecificSuit * (netEV + bjprob) / (1 - bjprob)
                                        newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * (winEV - loseEV);
                                        newHandEVs.SuitedBonusEV[upcard, suit] = pSpecificSuit * BonusRulesList.L[rule].PayoffSpecificSuit;
                                        newHandEVs.SuitedStandBJEV[upcard, suit] = pSpecificSuit * tempBJPayoff;
                                        // newHandEVs.StandPushEV(upcard) = pSpecificSuit * pushEV
                                    }
                                }
                            }
                            else
                            {
                                // Since hand Must Win, pushev is unaffected and BJ hand cannot beat BJ
                                // newHandEVs.StandPushEV(upcard) = pushEV
                                if (pSuited > 0d)
                                {
                                    if (BonusRulesList.L[rule].PayoffSuited == 0d & !(BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSuited > 0d))
                                    {
                                        newHandEVs.SuitedStandEV[upcard, suit] = pSuited * (winEV - loseEV);
                                    }
                                    else if (BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSuited > 0d)
                                    {
                                        newHandEVs.SuitedStandEV[upcard, suit] = pSuited * (BonusRulesList.L[rule].PayoffUCSuited * winEV - loseEV);
                                    }
                                    else
                                    {
                                        newHandEVs.SuitedStandEV[upcard, suit] = pSuited * (BonusRulesList.L[rule].PayoffSuited * winEV - loseEV);
                                    }
                                }

                                if (pSpecificSuit > 0d)
                                {
                                    if (BonusRulesList.L[rule].PayoffSpecificSuit == 0d & !(BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSpecificSuit > 0d))
                                    {
                                        newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * (winEV - loseEV);
                                    }
                                    else if (BonusRulesList.L[rule].Upcard == upcard & BonusRulesList.L[rule].PayoffUCSpecificSuit > 0d)
                                    {
                                        newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * (BonusRulesList.L[rule].PayoffUCSpecificSuit * winEV - loseEV);
                                    }
                                    else
                                    {
                                        newHandEVs.SuitedStandEV[upcard, suit] = pSpecificSuit * (BonusRulesList.L[rule].PayoffSpecificSuit * winEV - loseEV);
                                    }
                                }
                            }
                        }
                        else
                        {
                            newHandEVs.SuitedStandEV[upcard, suit] = pHand.HandEVs.StandEV[upcard];
                        }  // Suited Possible
                    }
                }
            }  // Not BJ

            return newHandEVs;
        }

        private void EnumSuitedBonusHandList()
        {
            int index;
            int upcard;
            int suit;
            int rule;
            bool apply;
            double bjprob;
            BJCASuitedBonusEVClass newEVs;

            if (BonusRuleOn)
            {
                NSuitedHands = 0;
                NSuitedBonusHands = 0;
                var loopTo = NumPHands;
                for (index = 1; index <= loopTo; index++)
                {
                    if (index != BJIndex & PlayerHands[index].Hand.NumCards > 1)
                    {
                        var loopTo1 = BonusRulesList.NumRules - 1;
                        for (rule = 0; rule <= loopTo1; rule++)
                        {
                            if (BonusRulesList.L[rule].RuleOn & BonusRulesList.L[rule].Suited)
                            {
                                // First see if the hand qualifies to have the rule applied to it
                                apply = false;

                                // If post-split bonuses are added then add the following below:      ((Not postSplit And BonusRulesList.L(rule).PreSplit) Or (postSplit And BonusRulesList.L(rule).PostSplit)) And 

                                if (BonusRulesList.L[rule].UseSpecificHand)
                                {
                                    if (BonusRulesList.L[rule].ExactMatch & PlayerHands[index].Hand.SameAs(BonusRulesList.L[rule].Hand) | !BonusRulesList.L[rule].ExactMatch & PlayerHands[index].Hand.Includes(BonusRulesList.L[rule].Hand))
                                    {
                                        apply = true;
                                    }
                                }
                                else if (PlayerHands[index].Hand.Total == BonusRulesList.L[rule].Hand.Total | BonusRulesList.L[rule].Hand.Total == 0)
                                {
                                    if (!BonusRulesList.L[rule].HardSoftOnly | BonusRulesList.L[rule].HardSoftOnly & !BonusRulesList.L[rule].Hand.Soft & !PlayerHands[index].Hand.Soft | BonusRulesList.L[rule].HardSoftOnly & BonusRulesList.L[rule].Hand.Soft & PlayerHands[index].Hand.Soft)
                                    {
                                        if (BonusRulesList.L[rule].Hand.NumCards == 0 | BonusRulesList.L[rule].Hand.NumCards == PlayerHands[index].Hand.NumCards | BonusRulesList.L[rule].OrLess & PlayerHands[index].Hand.NumCards <= BonusRulesList.L[rule].Hand.NumCards | BonusRulesList.L[rule].OrMore & PlayerHands[index].Hand.NumCards >= BonusRulesList.L[rule].Hand.NumCards)
                                        {
                                            apply = true;
                                        }
                                    }
                                }

                                if (apply)
                                {
                                    NSuitedBonusHands += 1;
                                    SuitedBonusHands[NSuitedBonusHands] = index;

                                    NSuitedHands += 1;
                                    SuitedHandsList[NSuitedHands] = index;
                                    PlayerHands[index].SuitedBonusEVs = new BJCASuitedBonusEVClass();

                                    for (upcard = 1; upcard <= 10; upcard++)
                                    {
                                        if (UCAllowed[upcard])
                                        {
                                            bjprob = PlayerHands[index].HandEVs.BJProb[upcard];
                                            newEVs = ApplyBonusRuleSuitedHand(rule, ref PlayerHands[index], upcard, bjprob);
                                            // First copy over the Stand and BJ Stand EV's
                                            for (suit = 0; suit <= 3; suit++)
                                            {
                                                PlayerHands[index].SuitedBonusEVs.SuitedStandEV[upcard, suit] = newEVs.SuitedStandEV[upcard, suit];
                                                PlayerHands[index].SuitedBonusEVs.SuitedStandBJEV[upcard, suit] = newEVs.SuitedStandBJEV[upcard, suit];
                                                PlayerHands[index].SuitedBonusEVs.SuitedBonusEV[upcard, suit] = newEVs.SuitedBonusEV[upcard, suit];
                                            }
                                            // Now we need to determine the initial strategy
                                            // **** Hits are ignored for these hands ?
                                            // Currently set to include hits
                                            for (suit = 0; suit <= 3; suit++)
                                            {
                                                newEVs.Empty();
                                                newEVs = ComputeSuitedStratHand(ref Opt, index, upcard, suit, true);
                                                PlayerHands[index].SuitedBonusEVs.SuitedStratEV[upcard, suit] = newEVs.SuitedStratEV[upcard, suit];
                                                PlayerHands[index].SuitedBonusEVs.SuitedStratBJEV[upcard, suit] = newEVs.SuitedStratBJEV[upcard, suit];
                                                PlayerHands[index].SuitedBonusEVs.SuitedStrat[upcard, suit] = newEVs.SuitedStrat[upcard, suit];
                                            }
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ComputeSuitedBonusHitStratHand(ref BJCAStrategyClass cstrat, int index)
        {
            int card;
            int bonusHand;
            int newIndex;
            int upcard;
            double prob;
            double probsuit;
            int suit;
            var newEVs = new BJCASuitedBonusEVClass();
            var tempHand = new BJCAHandClass();

            // First find the hand and then figure out the value of hitting
            NSuitedHands += 1;
            SuitedHandsList[NSuitedHands] = index;
            PlayerHands[index].SuitedBonusEVs = new BJCASuitedBonusEVClass();

            for (upcard = 1; upcard <= 10; upcard++)
            {
                if (UCAllowed[upcard] & CardProb(upcard, 0) > 0d)
                {
                    CurrentShoe.Deal(upcard);
                    for (suit = 0; suit <= 3; suit++)
                    {
                        if (PlayerHands[index].HandEVs.SuitedPossible[upcard, suit])
                        {
                            CurrentShoe.DealSuited(PlayerHands[index].Hand, suit);
                            for (card = 1; card <= 10; card++)
                            {
                                prob = CardProb(card, upcard);
                                if (prob > 0d)
                                {
                                    // BJ EV can be ignored because it is only non-zero when
                                    // the hand has 2 cards and OBO and these hands are forced to
                                    // stand.
                                    if (PlayerHands[index].HitHand[card] > 0)
                                    {
                                        if (PlayerHands[PlayerHands[index].HitHand[card]].SuitedBonusEVs is null)
                                        {
                                            // Use the Strat play values for non-suited hits
                                            PlayerHands[index].SuitedBonusEVs.SuitedHitEV[upcard, suit] += prob * (cstrat.HandEVs[PlayerHands[index].HitHand[card]].EVs.StratEV[upcard] + PlayerHands[PlayerHands[index].HitHand[card]].HandEVs.BonusEV[upcard]);
                                            if (upcard == 1 | upcard == 10)
                                            {
                                                PlayerHands[index].SuitedBonusEVs.SuitedHitBJEV[upcard, suit] += prob * PlayerHands[PlayerHands[index].HitHand[card]].HandEVs.BJStandEV[upcard];
                                            }
                                        }
                                        else
                                        {
                                            // Break up hitting into suited hit and non-suited hit
                                            probsuit = CurrentShoe.Suits[card, suit] / (double)CurrentShoe.Cards[card];
                                            // SuitedStratEV includes the SuitedBonusEV so it doesn't need to be added here
                                            PlayerHands[index].SuitedBonusEVs.SuitedHitEV[upcard, suit] += prob * (1d - probsuit) * (cstrat.HandEVs[PlayerHands[index].HitHand[card]].EVs.StratEV[upcard] + PlayerHands[PlayerHands[index].HitHand[card]].HandEVs.BonusEV[upcard]);
                                            PlayerHands[index].SuitedBonusEVs.SuitedHitEV[upcard, suit] += prob * probsuit * PlayerHands[PlayerHands[index].HitHand[card]].SuitedBonusEVs.SuitedStratEV[upcard, suit];
                                            if (upcard == 1 | upcard == 10)
                                            {
                                                PlayerHands[index].SuitedBonusEVs.SuitedHitBJEV[upcard, suit] += prob * (1d - probsuit) * PlayerHands[PlayerHands[index].HitHand[card]].HandEVs.BJStandEV[upcard];
                                                PlayerHands[index].SuitedBonusEVs.SuitedHitBJEV[upcard, suit] += prob * probsuit * PlayerHands[PlayerHands[index].HitHand[card]].SuitedBonusEVs.SuitedStratBJEV[upcard, suit];
                                            }
                                        }
                                    }
                                    else
                                    {
                                        PlayerHands[index].SuitedBonusEVs.SuitedHitEV[upcard, suit] -= prob;
                                        if (upcard == 1 | upcard == 10)
                                        {
                                            PlayerHands[index].SuitedBonusEVs.SuitedHitBJEV[upcard, suit] -= prob;
                                        }
                                    }
                                }
                            }
                            CurrentShoe.UndealSuited(PlayerHands[index].Hand, suit);
                        }
                        else
                        {
                            PlayerHands[index].SuitedBonusEVs.SuitedHitEV[upcard, suit] = cstrat.HandEVs[index].EVs.HitEV[upcard];
                            if (upcard == 1 | upcard == 10)
                            {
                                PlayerHands[index].SuitedBonusEVs.SuitedHitBJEV[upcard, suit] = PlayerHands[index].HandEVs.BJStandEV[upcard];
                            }
                        }

                        // Copy Strat stand EV since these are the same for the non-bonus hands
                        PlayerHands[index].SuitedBonusEVs.SuitedStandEV[upcard, suit] = PlayerHands[index].HandEVs.StandEV[upcard];
                        PlayerHands[index].SuitedBonusEVs.SuitedStandBJEV[upcard, suit] = PlayerHands[index].HandEVs.BJStandEV[upcard];

                        // Then figure out if the strategy is to hit or follow the original CD strat
                        newEVs = ComputeSuitedStratHand(ref cstrat, index, upcard, suit, true);
                        PlayerHands[index].SuitedBonusEVs.SuitedStratEV[upcard, suit] = newEVs.SuitedStratEV[upcard, suit];
                        PlayerHands[index].SuitedBonusEVs.SuitedStratBJEV[upcard, suit] = newEVs.SuitedStratBJEV[upcard, suit];
                        PlayerHands[index].SuitedBonusEVs.SuitedStrat[upcard, suit] = newEVs.SuitedStrat[upcard, suit];
                    }
                    CurrentShoe.Undeal(upcard);
                }
            }

            // Finally, recursively go backwards through all the possible hands
            if (PlayerHands[index].Hand.NumCards > 2)
            {
                tempHand.Copy(PlayerHands[index].Hand);
                for (card = 1; card <= 10; card++)
                {
                    if (tempHand.Cards[card] > 0)
                    {
                        tempHand.Undeal(card);
                        newIndex = FindPlayerHand(tempHand);

                        if (PlayerHands[newIndex].SuitedBonusEVs is null)
                        {
                            ComputeSuitedBonusHitStratHand(ref cstrat, newIndex);
                        }
                        tempHand.Deal(card);
                    }
                }
            }

        }

        private void EnumSuitedHandList()
        {
            int index;
            int upcard;
            int card;
            int bonusHand;
            bool apply;
            var tempHand = new BJCAHandClass();

            var loopTo = NSuitedBonusHands;
            for (bonusHand = 1; bonusHand <= loopTo; bonusHand++)
            {
                // Work backwards through the suited hands to figure out the EV's
                if (PlayerHands[SuitedBonusHands[bonusHand]].Hand.NumCards > 2)
                {
                    tempHand.Copy(PlayerHands[SuitedBonusHands[bonusHand]].Hand);
                    for (card = 1; card <= 10; card++)
                    {
                        if (tempHand.Cards[card] > 0)
                        {
                            tempHand.Undeal(card);
                            index = FindPlayerHand(tempHand);

                            if (PlayerHands[index].SuitedBonusEVs is null)
                            {
                                ComputeSuitedBonusHitStratHand(ref Opt, index);
                            }
                            tempHand.Deal(card);
                        }
                    }
                }
            }
        }

        private BJCASuitedBonusEVClass ComputeSuitedStratHand(ref BJCAStrategyClass cstrat, int index, int upcard, int suit, bool includeHit)
        {
            var newEVs = new BJCASuitedBonusEVClass();

            // Begin with the current Strategy Play
            // This takes care of doubles, surrender and splits
            newEVs.SuitedStratEV[upcard, suit] = cstrat.HandEVs[index].EVs.StratEV[upcard] + PlayerHands[index].HandEVs.BonusEV[upcard];
            if (upcard == 1 | upcard == 10)
            {
                newEVs.SuitedStratBJEV[upcard, suit] = PlayerHands[index].HandEVs.BJStandEV[upcard];
            }
            newEVs.SuitedStrat[upcard, suit] = cstrat.HandEVs[index].EVs.Strat[upcard];

            // Now check for stand strategy
            if (PlayerHands[index].SuitedBonusEVs.SuitedStandEV[upcard, suit] + PlayerHands[index].SuitedBonusEVs.SuitedBonusEV[upcard, suit] > newEVs.SuitedStratEV[upcard, suit])
            {
                newEVs.SuitedStratEV[upcard, suit] = PlayerHands[index].SuitedBonusEVs.SuitedStandEV[upcard, suit] + PlayerHands[index].SuitedBonusEVs.SuitedBonusEV[upcard, suit];
                if (upcard == 1 | upcard == 10)
                {
                    newEVs.SuitedStratBJEV[upcard, suit] = PlayerHands[index].SuitedBonusEVs.SuitedStandBJEV[upcard, suit];
                }
                newEVs.SuitedStrat[upcard, suit] = (int)BJCAGlobalsClass.Strat.S;
            }
            else if (PlayerHands[index].Hand.NumCards == 2 & (upcard == 1 & CheckAce | upcard == 10 & CheckTen))
            {
                // The only time BJStand EV can cause a separate strategy from the rest of the
                // hand is with 2-card dealer checking hands.  When this occurs only the
                // BJEV is effected.
                // BJ EV's are otherwise kept for analysis displays only.
                if (PlayerHands[index].SuitedBonusEVs.SuitedStandBJEV[upcard, suit] > newEVs.SuitedStratBJEV[upcard, suit])
                {
                    newEVs.SuitedStratBJEV[upcard, suit] = PlayerHands[index].SuitedBonusEVs.SuitedStandBJEV[upcard, suit];
                }
            }

            // Finally check hitting
            if (includeHit & PlayerHands[index].SuitedBonusEVs.SuitedHitEV[upcard, suit] + PlayerHands[index].SuitedBonusEVs.SuitedBonusEV[upcard, suit] > newEVs.SuitedStratEV[upcard, suit])
            {
                newEVs.SuitedStratEV[upcard, suit] = PlayerHands[index].SuitedBonusEVs.SuitedHitEV[upcard, suit];
                if (upcard == 1 | upcard == 10)
                {
                    newEVs.SuitedStratBJEV[upcard, suit] = PlayerHands[index].SuitedBonusEVs.SuitedHitBJEV[upcard, suit] + PlayerHands[index].SuitedBonusEVs.SuitedBonusEV[upcard, suit];
                }
                newEVs.SuitedStrat[upcard, suit] = (int)BJCAGlobalsClass.Strat.H;
            }

            return newEVs;

        }

        private void ComputeSuitedHandNetEVs(ref BJCAStrategyClass cstrat)
        {
            int suitedIndex;
            int index;
            int suit;
            int upcard;
            var newEVs = new BJCASuitedBonusEVClass();

            if (BonusRuleOn)
            {
                for (upcard = 1; upcard <= 10; upcard++)
                {
                    if (UCAllowed[upcard])
                    {
                        var loopTo = NSuitedHands;
                        for (suitedIndex = 1; suitedIndex <= loopTo; suitedIndex++)
                        {
                            index = SuitedHandsList[suitedIndex];
                            if (PlayerHands[index].HandEVs.Prob[upcard] > 0d)
                            {
                                PlayerHands[index].SuitedBonusEVs.SuitedNetEV[upcard] = (cstrat.HandEVs[index].EVs.StratEV[upcard] + PlayerHands[index].HandEVs.BonusEV[upcard]) * (PlayerHands[index].HandEVs.Prob[upcard] - PlayerHands[index].HandEVs.SumSuited[upcard]);
                                PlayerHands[index].SuitedBonusEVs.SuitedNetBJEV[upcard] = PlayerHands[index].HandEVs.BJStandEV[upcard] * (PlayerHands[index].HandEVs.Prob[upcard] - PlayerHands[index].HandEVs.SumSuited[upcard]);

                                PlayerHands[index].SuitedBonusEVs.SuitedNetEV[upcard] += (PlayerHands[index].SuitedBonusEVs.SuitedStratEV[upcard, 0] + PlayerHands[index].SuitedBonusEVs.SuitedBonusEV[upcard, 0]) * PlayerHands[index].HandEVs.ProbSuited[upcard, 0];
                                PlayerHands[index].SuitedBonusEVs.SuitedNetBJEV[upcard] += PlayerHands[index].SuitedBonusEVs.SuitedStratBJEV[upcard, 0] * PlayerHands[index].HandEVs.ProbSuited[upcard, 0];

                                PlayerHands[index].SuitedBonusEVs.SuitedNetEV[upcard] += (PlayerHands[index].SuitedBonusEVs.SuitedStratEV[upcard, 1] + PlayerHands[index].SuitedBonusEVs.SuitedBonusEV[upcard, 1]) * PlayerHands[index].HandEVs.ProbSuited[upcard, 1];
                                PlayerHands[index].SuitedBonusEVs.SuitedNetBJEV[upcard] += PlayerHands[index].SuitedBonusEVs.SuitedStratBJEV[upcard, 1] * PlayerHands[index].HandEVs.ProbSuited[upcard, 1];

                                PlayerHands[index].SuitedBonusEVs.SuitedNetEV[upcard] += (PlayerHands[index].SuitedBonusEVs.SuitedStratEV[upcard, 2] + PlayerHands[index].SuitedBonusEVs.SuitedBonusEV[upcard, 2]) * PlayerHands[index].HandEVs.ProbSuited[upcard, 2];
                                PlayerHands[index].SuitedBonusEVs.SuitedNetBJEV[upcard] += PlayerHands[index].SuitedBonusEVs.SuitedStratBJEV[upcard, 2] * PlayerHands[index].HandEVs.ProbSuited[upcard, 2];

                                PlayerHands[index].SuitedBonusEVs.SuitedNetEV[upcard] += (PlayerHands[index].SuitedBonusEVs.SuitedStratEV[upcard, 3] + PlayerHands[index].SuitedBonusEVs.SuitedBonusEV[upcard, 3]) * PlayerHands[index].HandEVs.ProbSuited[upcard, 3];
                                PlayerHands[index].SuitedBonusEVs.SuitedNetBJEV[upcard] += PlayerHands[index].SuitedBonusEVs.SuitedStratBJEV[upcard, 3] * PlayerHands[index].HandEVs.ProbSuited[upcard, 3];

                                PlayerHands[index].SuitedBonusEVs.SuitedNetEV[upcard] /= PlayerHands[index].HandEVs.Prob[upcard];
                                PlayerHands[index].SuitedBonusEVs.SuitedNetBJEV[upcard] /= PlayerHands[index].HandEVs.Prob[upcard];
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region  Generic Strat Methods 

        private void ComputeOptInitialStrat()
        {
            int index;
            int upcard;
            var newEVs = new BJCAHandEVsClass();

            var loopTo = NumPHands;
            for (index = 1; index <= loopTo; index++)
            {
                if (PlayerHands[index].Hand.NumCards > 1)
                {
                    for (upcard = 1; upcard <= 10; upcard++)
                    {
                        if (UCAllowed[upcard])
                        {
                            // Begin with Stand as the strategy
                            Opt.HandEVs[index].EVs.StratEV[upcard] = PlayerHands[index].HandEVs.StandEV[upcard];
                            Opt.HandEVs[index].EVs.StratPushEV[upcard] = PlayerHands[index].HandEVs.StandPushEV[upcard];
                            Opt.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.S;

                            // Now check for Double strategy
                            if (PlayerHands[index].DPreallowed[upcard])
                            {
                                if (PlayerHands[index].HandEVs.DEV[upcard] > Opt.HandEVs[index].EVs.StratEV[upcard])
                                {
                                    Opt.HandEVs[index].EVs.StratEV[upcard] = PlayerHands[index].HandEVs.DEV[upcard];
                                    Opt.HandEVs[index].EVs.StratPushEV[upcard] = PlayerHands[index].HandEVs.DPushEV[upcard];
                                    Opt.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.D;
                                }
                            }

                            // Now finally check for Surrender strategy
                            if (PlayerHands[index].RPreallowed[upcard] > 0)
                            {
                                if (PlayerHands[index].HandEVs.SurrEV[upcard] > Opt.HandEVs[index].EVs.StratEV[upcard])
                                {
                                    Opt.HandEVs[index].EVs.StratEV[upcard] = PlayerHands[index].HandEVs.SurrEV[upcard];
                                    Opt.HandEVs[index].EVs.StratPushEV[upcard] = 0d;
                                    Opt.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.R;
                                }
                            }
                        }
                    }
                }
            }

        }

        #endregion

        #region  Hit Methods 

        private void ComputeOptHit()
        {
            int Total;

            for (Total = 21; Total >= 11; Total -= 1)
                ComputeOptHitTotal(Total, false);
            for (Total = 21; Total >= 12; Total -= 1)
                ComputeOptHitTotal(Total, true);
            for (Total = 10; Total >= 4; Total -= 1)
                ComputeOptHitTotal(Total, false);
        }

        private void ComputeOptHitTotal(int Total, bool Soft)
        {
            int index;
            int upcard;
            int card;
            double prob;

            index = PlayerHandTotal[Total, Conversions.ToInteger(Soft) + 1];
            while (index != 0)
            {
                CurrentShoe.Deal(PlayerHands[index].Hand);
                for (upcard = 1; upcard <= 10; upcard++)
                {
                    if (UCAllowed[upcard] & CardProb(upcard, 0) > 0d)
                    {
                        CurrentShoe.Deal(upcard);
                        for (card = 1; card <= 10; card++)
                        {
                            prob = CardProb(card, upcard);
                            if (prob > 0d)
                            {
                                if (PlayerHands[index].HitHand[card] > 0)
                                {
                                    Opt.HandEVs[index].EVs.HitEV[upcard] = Opt.HandEVs[index].EVs.HitEV[upcard] + prob * (Opt.HandEVs[PlayerHands[index].HitHand[card]].EVs.StratEV[upcard] + PlayerHands[PlayerHands[index].HitHand[card]].HandEVs.BonusEV[upcard]);
                                    Opt.HandEVs[index].EVs.HitPushEV[upcard] = Opt.HandEVs[index].EVs.HitPushEV[upcard] + prob * Opt.HandEVs[PlayerHands[index].HitHand[card]].EVs.StratPushEV[upcard];
                                }
                                else
                                {
                                    Opt.HandEVs[index].EVs.HitEV[upcard] = Opt.HandEVs[index].EVs.HitEV[upcard] - prob;
                                }
                            }
                        }
                        CurrentShoe.Undeal(upcard);

                        // Update Max strategy for Optimal Play
                        if (Opt.HandEVs[index].EVs.HitEV[upcard] > Opt.HandEVs[index].EVs.StratEV[upcard])
                        {
                            Opt.HandEVs[index].EVs.StratEV[upcard] = Opt.HandEVs[index].EVs.HitEV[upcard];
                            Opt.HandEVs[index].EVs.StratPushEV[upcard] = Opt.HandEVs[index].EVs.HitPushEV[upcard];
                            Opt.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.H;
                        }
                        if (Opt.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.D & PlayerHands[index].HandEVs.StandEV[upcard] > Opt.HandEVs[index].EVs.HitEV[upcard])
                            Opt.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.DS;
                        if (Opt.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.R & PlayerHands[index].HandEVs.StandEV[upcard] > Opt.HandEVs[index].EVs.HitEV[upcard])
                            Opt.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.RS;
                    }
                }
                CurrentShoe.Undeal(PlayerHands[index].Hand);
                index = PlayerHands[index].NextHand;
            }
        }

        #endregion

        #region  Split Methods 

        #region  Split Initializing Methods 

        private void LinkSplitStand()
        {
            int index;
            int upcard;
            int paircard;
            int nextIndex;
            int hands;
            double bjadjprob;
            var newEVs = new BJCAHandEVsClass();
            var newHand = new BJCAPlayerHandClass();

            // Copy all the Stand values from the hands to the proper split hands
            var loopTo = NumPHands;
            for (index = 1; index <= loopTo; index++)
            {
                if (PlayerHands[index].Hand.NumCards > 1)
                {
                    for (paircard = 1; paircard <= 10; paircard++)
                    {
                        if (SplitAllowed[paircard] & CardProb(paircard, 0) > 0d & PlayerHands[index].PairIndex[paircard] > 0)
                        {
                            DealPCard(paircard);
                            if (CardProb(paircard, 0) > 0d)
                            {
                                DealPCard(paircard);
                                nextIndex = PlayerHands[index].HitHand[paircard];
                                var loopTo1 = NSplitCalcs;
                                for (hands = 1; hands <= loopTo1; hands++)
                                {
                                    if (nextIndex != 0)
                                    {
                                        // Need to add the new objects
                                        if (PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] is null)
                                        {
                                            PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandEVsClass();
                                            Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandStrategyEVsClass();
                                            if (TD.ComputeStrat)
                                                TD.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandStrategyEVsClass();
                                            if (TC.ComputeStrat)
                                                TC.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandStrategyEVsClass();
                                            if (Forced.ComputeStrat)
                                                Forced.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandStrategyEVsClass();
                                        }
                                        for (upcard = 1; upcard <= 10; upcard++)
                                        {
                                            if (!PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StandDone[upcard] & UCAllowed[upcard] & CardProb(upcard, 0) > 0d)
                                            {
                                                newEVs.Empty();

                                                // Player 21's lose to dealer BJ when not checking.
                                                // Dealer checks have already been accounted for in the dealer probs
                                                if (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen)
                                                {
                                                    if (upcard == 1 & !CheckAce)
                                                    {
                                                        bjadjprob = BJHandNumerator[10, PlayerHands[nextIndex].Hand.Cards[10], 1] / BJHandDivisor[PlayerHands[nextIndex].Hand.NumCards + 1, 1];
                                                    }
                                                    else if (upcard == 10 & !CheckTen)
                                                    {
                                                        bjadjprob = BJHandNumerator[1, PlayerHands[nextIndex].Hand.Cards[1], 1] / BJHandDivisor[PlayerHands[nextIndex].Hand.NumCards + 1, 1];
                                                    }
                                                    else
                                                    {
                                                        bjadjprob = 0d;
                                                    }
                                                }
                                                else
                                                {
                                                    bjadjprob = 0d;
                                                }
                                                newEVs = GetHandEV(PlayerHands[index].Hand.Total, PlayerHands[nextIndex].HandEVs, upcard, bjadjprob);
                                                newHand.HandEVs.Empty();
                                                newHand.HandEVs.StandEV[upcard] = newEVs.StandEV[upcard];
                                                newHand.HandEVs.StandPushEV[upcard] = newEVs.StandPushEV[upcard];
                                                newHand.HandEVs.BJStandEV[upcard] = newEVs.BJStandEV[upcard];
                                                if (BonusRuleOn)
                                                {
                                                    newHand.Hand.Copy(PlayerHands[index].Hand);
                                                    newEVs.Empty();
                                                    newEVs = ApplyBonusRulesNonSuitedHand(newHand, upcard, bjadjprob, true, false);
                                                    newHand.HandEVs.StandEV[upcard] = newEVs.StandEV[upcard];
                                                    newHand.HandEVs.StandPushEV[upcard] = newEVs.StandPushEV[upcard];
                                                    newHand.HandEVs.BonusEV[upcard] = newEVs.BonusEV[upcard];
                                                    newHand.HandEVs.BJStandEV[upcard] = newEVs.BJStandEV[upcard];
                                                }
                                                PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StandEV[upcard] = newHand.HandEVs.StandEV[upcard];
                                                PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StandPushEV[upcard] = newHand.HandEVs.StandPushEV[upcard];
                                                PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].BonusEV[upcard] = newHand.HandEVs.BonusEV[upcard];
                                                PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].BJStandEV[upcard] = newHand.HandEVs.BJStandEV[upcard];
                                                PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StandDone[upcard] = true;
                                            }
                                        }
                                        nextIndex = PlayerHands[nextIndex].HitHand[paircard];
                                    }
                                }
                                UndealPCard(paircard);
                            }
                            UndealPCard(paircard);
                        }
                    }
                }
            }
        }

        private void InitializeSplits()
        {
            if (SPL > 0)
            {
                ComputeSplitHandProbs();
                LinkSplitStand();
                ComputeSplitBlackjack();
                InitializeStrategySplitStates(ref Opt);
                if (TD.ComputeStrat)
                    InitializeStrategySplitStates(ref TD);
                if (TC.ComputeStrat)
                    InitializeStrategySplitStates(ref TC);
                if (Forced.ComputeStrat)
                    InitializeStrategySplitStates(ref Forced);
            }
        }

        private void ComputeSplitRoundProbs()
        {
            int split;
            int round;
            int paircard;
            int upcard;
            int hands;

            if (SPL > 0)
            {
                for (paircard = 1; paircard <= 10; paircard++)
                {
                    for (upcard = 1; upcard <= 10; upcard++)
                    {
                        if (SplitIndex[paircard, upcard] > 0)
                        {
                            // SPL1
                            // xx	        2*EV(x)					            2*EV(x) 
                            SplitRoundProbs[paircard, upcard].RoundProbs[1, 1] = 1d;

                            // SPL2
                            // NN	        EV(N) + EV(N-N)			            2*EV(N-N) 
                            SplitRoundProbs[paircard, upcard].RoundProbs[2, 1] = 1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.Full, paircard];
                            SplitRoundProbs[paircard, upcard].RoundProbs[2, 1] *= 1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.N, paircard];
                            // Pxxx	    3*EV(x-P)				            3*EV(x-P) 
                            SplitRoundProbs[paircard, upcard].RoundProbs[2, 2] = SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.Full, paircard];
                            // NPxx	    EV(N) + 2*EV(x-PN)		            EV(N-P) + 2*EV(x-PN) 
                            SplitRoundProbs[paircard, upcard].RoundProbs[2, 3] = 1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.Full, paircard];
                            SplitRoundProbs[paircard, upcard].RoundProbs[2, 3] *= SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.N, paircard];

                            // SPL3
                            // NN	        EV(N) + EV(N-N)			            2*EV(N-N) 
                            SplitRoundProbs[paircard, upcard].RoundProbs[3, 1] = 1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.Full, paircard];
                            SplitRoundProbs[paircard, upcard].RoundProbs[3, 1] *= 1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.N, paircard];
                            // PNNN	    EV(N-P) + EV(N-PN) + EV(N-PNN)		3*EV(N-PNN) 
                            SplitRoundProbs[paircard, upcard].RoundProbs[3, 2] = SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.Full, paircard];
                            SplitRoundProbs[paircard, upcard].RoundProbs[3, 2] *= 1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.P, paircard];
                            SplitRoundProbs[paircard, upcard].RoundProbs[3, 2] *= 1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.PN, paircard];
                            SplitRoundProbs[paircard, upcard].RoundProbs[3, 2] *= 1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.PNN, paircard];
                            // NPNN	    EV(N) + EV(N-PN) + EV(N-PNN)		3*EV(N-PNN) 
                            SplitRoundProbs[paircard, upcard].RoundProbs[3, 3] = 1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.Full, paircard];
                            SplitRoundProbs[paircard, upcard].RoundProbs[3, 3] *= SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.N, paircard];
                            SplitRoundProbs[paircard, upcard].RoundProbs[3, 3] *= 1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.PN, paircard];
                            SplitRoundProbs[paircard, upcard].RoundProbs[3, 3] *= 1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.PNN, paircard];
                            // PPxxxx	    4*EV(x-PP)				            4*EV(x-PP) 
                            SplitRoundProbs[paircard, upcard].RoundProbs[3, 4] = SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.Full, paircard];
                            SplitRoundProbs[paircard, upcard].RoundProbs[3, 4] *= SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.P, paircard];
                            // PNPxxx	    EV(N-P) + 3*EV(x-PPN)			    EV(N-PP) + 3*EV(x-PPN) 
                            SplitRoundProbs[paircard, upcard].RoundProbs[3, 5] = SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.Full, paircard];
                            SplitRoundProbs[paircard, upcard].RoundProbs[3, 5] *= 1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.P, paircard];
                            SplitRoundProbs[paircard, upcard].RoundProbs[3, 5] *= SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.PN, paircard];
                            // NPPxxx	    EV(N) + 3*EV(x-PPN)			        EV(N-PP) + 3*EV(x-PPN) 
                            SplitRoundProbs[paircard, upcard].RoundProbs[3, 6] = 1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.Full, paircard];
                            SplitRoundProbs[paircard, upcard].RoundProbs[3, 6] *= SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.N, paircard];
                            SplitRoundProbs[paircard, upcard].RoundProbs[3, 6] *= SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.PN, paircard];
                            // PNNPxx	    EV(N-P) + EV(N-PN) + 2*EV(x-PPNN)	2*EV(N-PPN) + 2*EV(x-PPNN) 
                            SplitRoundProbs[paircard, upcard].RoundProbs[3, 7] = SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.Full, paircard];
                            SplitRoundProbs[paircard, upcard].RoundProbs[3, 7] *= 1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.P, paircard];
                            SplitRoundProbs[paircard, upcard].RoundProbs[3, 7] *= 1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.PN, paircard];
                            SplitRoundProbs[paircard, upcard].RoundProbs[3, 7] *= SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.PNN, paircard];
                            // NPNPxx	    EV(N) + EV(N-PN) + 2*EV(x-PPNN)		2*EV(N-PPN) + 2*EV(x-PPNN) 
                            SplitRoundProbs[paircard, upcard].RoundProbs[3, 8] = 1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.Full, paircard];
                            SplitRoundProbs[paircard, upcard].RoundProbs[3, 8] *= SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.N, paircard];
                            SplitRoundProbs[paircard, upcard].RoundProbs[3, 8] *= 1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.PN, paircard];
                            SplitRoundProbs[paircard, upcard].RoundProbs[3, 8] *= SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.PNN, paircard];

                            // Now add all the occurances of each hand to get it's net prob
                            var loopTo = SPL;
                            for (split = 1; split <= loopTo; split++)
                            {
                                var loopTo1 = NSplitHands;
                                for (hands = 0; hands <= loopTo1; hands++)
                                {
                                    SplitRoundProbs[paircard, upcard].NetHandProbs[split, hands, 0] = 0d;
                                    SplitRoundProbs[paircard, upcard].NetHandProbs[split, hands, 1] = 0d;
                                    var loopTo2 = NRounds[split];
                                    for (round = 1; round <= loopTo2; round++)
                                    {
                                        SplitRoundProbs[paircard, upcard].NetHandProbs[split, hands, 0] += SplitRoundProbs[paircard, upcard].RoundProbs[split, round] * SplitRounds.Hands[split, round, hands, 0];
                                        SplitRoundProbs[paircard, upcard].NetHandProbs[split, hands, 1] += SplitRoundProbs[paircard, upcard].RoundProbs[split, round] * SplitRounds.Hands[split, round, hands, 1];
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void InitializeStrategySplitStates(ref BJCAStrategyClass cStrat)
        {
            int paircard;
            int upcard;

            for (paircard = 1; paircard <= 10; paircard++)
            {
                if (SplitAllowed[paircard])
                {
                    for (upcard = 1; upcard <= 10; upcard++)
                    {
                        if (UCAllowed[upcard])
                        {
                            cStrat.SplitStateEVs[paircard, upcard] = new BJCASplitStateStrategyClass();
                        }
                    }
                }
            }
        }

        private void LinkSplitOptStrat()
        {
            int index;
            int upcard;
            int paircard;
            int hands;

            // Copy the regular strategies over to the split strategies for CDZ
            var loopTo = NumPHands;
            for (index = 1; index <= loopTo; index++)
            {
                if (PlayerHands[index].Hand.NumCards > 1)
                {
                    for (paircard = 1; paircard <= 10; paircard++)
                    {
                        if (SplitAllowed[paircard] & PlayerHands[index].PairIndex[paircard] > 0)
                        {
                            var loopTo1 = NSplitCalcs;
                            for (hands = 1; hands <= loopTo1; hands++)
                            {
                                if (PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] is null)
                                {
                                    PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandEVsClass();
                                    Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandStrategyEVsClass();
                                    if (TD.ComputeStrat)
                                        TD.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandStrategyEVsClass();
                                    if (TC.ComputeStrat)
                                        TC.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandStrategyEVsClass();
                                    if (Forced.ComputeStrat)
                                        Forced.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandStrategyEVsClass();
                                }
                                for (upcard = 1; upcard <= 10; upcard++)
                                {
                                    if (UCAllowed[upcard])
                                    {
                                        Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].Strat[upcard] = GetPostSplitStrat(Opt.HandEVs[index].EVs.Strat[upcard], paircard, upcard, Opt, PlayerHands[index]);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region  Opt Split Methods 

        private void ComputeOptSplit()
        {
            int paircard;
            int upcard;
            int index;
            int tempStrat;
            double tempEV;

            if (SPL > 0)
            {
                if (CDP | CDPN)
                {
                    ComputeSplitStand();
                    ComputeSplitDouble();
                    ComputeSplitSurrender();
                    ComputeSplitHit();
                }
                else    // CDZ
                {
                    LinkSplitOptStrat();
                }

                for (paircard = 1; paircard <= 10; paircard++)
                {
                    if (SplitAllowed[paircard])
                    {
                        for (upcard = 1; upcard <= 10; upcard++)
                        {
                            if (UCAllowed[upcard])
                            {
                                index = SplitIndex[paircard, upcard];
                                if (index > 0)
                                {
                                    ComputeSplit(ref Opt, paircard, upcard);

                                    // Update Max strategy for Optimal Play
                                    if (Opt.HandEVs[index].SplitEV[upcard] > Opt.HandEVs[index].EVs.StratEV[upcard])
                                    {
                                        Opt.HandEVs[index].EVs.StratEV[upcard] = Opt.HandEVs[index].SplitEV[upcard];

                                        // Strategy after split needs to be determined by the x Hands
                                        // Opt.HandEVs(index).EVs.Strat(upcard) = ComputePostsplitPairMaxEVStrat(Opt, paircard, upcard)

                                        if (paircard == 1)
                                        {
                                            // Need special check here for HSA, DSA, RSA
                                            tempStrat = (int)BJCAGlobalsClass.Strat.S;
                                            tempEV = PlayerHands[index].HandEVs.StandEV[upcard];
                                            if (HSA & Opt.HandEVs[index].EVs.HitEV[upcard] > tempEV)
                                            {
                                                tempStrat = (int)BJCAGlobalsClass.Strat.H;
                                                tempEV = Opt.HandEVs[index].EVs.HitEV[upcard];
                                            }
                                            if (DSA & PlayerHands[index].HandEVs.DEV[upcard] > tempEV)
                                            {
                                                tempStrat = (int)BJCAGlobalsClass.Strat.D;
                                                tempEV = PlayerHands[index].HandEVs.DEV[upcard];
                                            }
                                            if (SSA & PlayerHands[index].HandEVs.SurrEV[upcard] > tempEV)
                                            {
                                                tempStrat = (int)BJCAGlobalsClass.Strat.R;
                                                tempEV = PlayerHands[index].HandEVs.SurrEV[upcard];
                                            }
                                            if (tempStrat == (int)BJCAGlobalsClass.Strat.S & !(HSA | DSA | SSA))
                                            {
                                                tempStrat = (int)BJCAGlobalsClass.Strat.None;
                                            }
                                            switch (tempStrat)
                                            {
                                                case (int)BJCAGlobalsClass.Strat.None:
                                                    {
                                                        Opt.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.P;
                                                        break;
                                                    }
                                                case (int)BJCAGlobalsClass.Strat.S:
                                                    {
                                                        Opt.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PS;
                                                        break;
                                                    }
                                                case (int)BJCAGlobalsClass.Strat.H:
                                                    {
                                                        Opt.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PH;
                                                        break;
                                                    }
                                                case (int)BJCAGlobalsClass.Strat.D:
                                                    {
                                                        Opt.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PD;
                                                        break;
                                                    }
                                                case (int)BJCAGlobalsClass.Strat.R:
                                                    {
                                                        Opt.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PR;
                                                        break;
                                                    }
                                            }
                                        }
                                        else
                                        {
                                            switch (Opt.HandEVs[index].EVs.Strat[upcard])
                                            {
                                                case (int)BJCAGlobalsClass.Strat.S:
                                                    {
                                                        Opt.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PS;
                                                        break;
                                                    }
                                                case (int)BJCAGlobalsClass.Strat.D:
                                                    {
                                                        if (DAS)
                                                        {
                                                            Opt.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PD;
                                                        }
                                                        else
                                                        {
                                                            Opt.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PH;
                                                        }

                                                        break;
                                                    }
                                                case (int)BJCAGlobalsClass.Strat.DS:
                                                    {
                                                        if (DAS)
                                                        {
                                                            Opt.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PD;
                                                        }
                                                        else
                                                        {
                                                            Opt.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PS;
                                                        }

                                                        break;
                                                    }
                                                case (int)BJCAGlobalsClass.Strat.H:
                                                    {
                                                        Opt.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PH;
                                                        break;
                                                    }
                                                case (int)BJCAGlobalsClass.Strat.R:
                                                    {
                                                        if (SAS)
                                                        {
                                                            Opt.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PR;
                                                        }
                                                        else
                                                        {
                                                            Opt.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PH;
                                                        }

                                                        break;
                                                    }
                                                case (int)BJCAGlobalsClass.Strat.RS:
                                                    {
                                                        if (SAS)
                                                        {
                                                            Opt.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PR;
                                                        }
                                                        else
                                                        {
                                                            Opt.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PS;
                                                        }

                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ComputeSplitStand()
        {
            int index;
            int upcard;
            int paircard;
            int hands;
            var temphand = new BJCAHandClass();
            var pcprob = new double[12];    // Prob of paircard
            var newEVs = new BJCAHandEVsClass();
            var newBonusEVs = new BJCAHandEVsClass();
            var newHand = new BJCAPlayerHandClass();
            double bjadjprob;

            for (paircard = 1; paircard <= 10; paircard++)
            {
                if (SplitAllowed[paircard])
                {
                    var loopTo = NumPHands;
                    for (index = 1; index <= loopTo; index++)
                    {
                        // Only non-linked hands that have at least one paircard in them need to be calculated for a given paircard
                        if (PlayerHands[index].Hand.NumCards > 1 & PlayerHands[index].Hand.Cards[paircard] > 0 & !(paircard == 1 & !HSA & !DSA & PlayerHands[index].Hand.NumCards > 2))
                        {
                            temphand.Copy(PlayerHands[index].Hand);
                            var loopTo1 = NSplitCalcs;
                            for (hands = 1; hands <= loopTo1; hands++)
                            {
                                if (PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] is null & PlayerHands[index].Hand.Cards[paircard] + NPxHands[SplitCalcHands[hands]].NP + 1 - OriginalShoe.Cards[paircard] < 1)
                                {
                                    PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandEVsClass();
                                    if (Opt.ComputeStrat)
                                        Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandStrategyEVsClass();
                                    if (TD.ComputeStrat)
                                        TD.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandStrategyEVsClass();
                                    if (TC.ComputeStrat)
                                        TC.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandStrategyEVsClass();
                                    if (Forced.ComputeStrat)
                                        Forced.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandStrategyEVsClass();

                                    temphand.Cards[paircard] += NPxHands[SplitCalcHands[hands]].NP + 1;
                                    temphand.NumCards += NPxHands[SplitCalcHands[hands]].NP + 1;

                                    newEVs = ComputeStandHand(temphand, 1, 10, false);
                                    newHand.HandEVs.Empty();
                                    newHand.Hand.Copy(PlayerHands[index].Hand);

                                    for (upcard = 1; upcard <= 10; upcard++)
                                    {
                                        if (UCAllowed[upcard])
                                        {
                                            PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].DealerProbs[upcard, 0] = newEVs.DealerProbs[upcard, 0];
                                            PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].DealerProbs[upcard, 1] = newEVs.DealerProbs[upcard, 1];
                                            PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].DealerProbs[upcard, 2] = newEVs.DealerProbs[upcard, 2];
                                            PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].DealerProbs[upcard, 3] = newEVs.DealerProbs[upcard, 3];
                                            PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].DealerProbs[upcard, 4] = newEVs.DealerProbs[upcard, 4];
                                            newHand.HandEVs.StandEV[upcard] = newEVs.StandEV[upcard];
                                            newHand.HandEVs.StandPushEV[upcard] = newEVs.StandPushEV[upcard];
                                            newHand.HandEVs.BJStandEV[upcard] = newEVs.BJStandEV[upcard];

                                            if (BonusRuleOn)
                                            {
                                                if (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen)
                                                {
                                                    if (upcard == 1 & !CheckAce)
                                                    {
                                                        bjadjprob = BJHandNumerator[10, temphand.Cards[10], 1] / BJHandDivisor[temphand.NumCards + 1, 1];
                                                    }
                                                    else if (upcard == 10 & !CheckTen)
                                                    {
                                                        bjadjprob = BJHandNumerator[1, temphand.Cards[1], 1] / BJHandDivisor[temphand.NumCards + 1, 1];
                                                    }
                                                    else
                                                    {
                                                        bjadjprob = 0d;
                                                    }
                                                }
                                                else
                                                {
                                                    bjadjprob = 0d;
                                                }
                                                newBonusEVs.Empty();
                                                newBonusEVs = ApplyBonusRulesNonSuitedHand(newHand, upcard, bjadjprob, true, false);
                                                newHand.HandEVs.StandEV[upcard] = newBonusEVs.StandEV[upcard];
                                                newHand.HandEVs.StandPushEV[upcard] = newBonusEVs.StandPushEV[upcard];
                                                newHand.HandEVs.BonusEV[upcard] = newBonusEVs.BonusEV[upcard];
                                            }


                                            PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StandEV[upcard] = newHand.HandEVs.StandEV[upcard];
                                            PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StandPushEV[upcard] = newHand.HandEVs.StandPushEV[upcard];
                                            PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].BonusEV[upcard] = newHand.HandEVs.BonusEV[upcard];
                                            PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StandDone[upcard] = true;

                                            // Max strategy so far is Stand
                                            Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].Strat[upcard] = (int)BJCAGlobalsClass.Strat.S;
                                            Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StratEV[upcard] = PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StandEV[upcard];
                                            Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StratPushEV[upcard] = PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StandPushEV[upcard];
                                        }
                                    }

                                    temphand.Cards[paircard] -= NPxHands[SplitCalcHands[hands]].NP + 1;
                                    temphand.NumCards -= NPxHands[SplitCalcHands[hands]].NP + 1;
                                }
                                else if (!(PlayerHands[index].Hand.Cards[paircard] + NPxHands[SplitCalcHands[hands]].NP + 1 - OriginalShoe.Cards[paircard] < 1))
                                {
                                    // Hand is not possible
                                    PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandEVsClass();
                                    if (Opt.ComputeStrat)
                                        Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandStrategyEVsClass();
                                    if (TD.ComputeStrat)
                                        TD.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandStrategyEVsClass();
                                    if (TC.ComputeStrat)
                                        TC.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandStrategyEVsClass();
                                    if (Forced.ComputeStrat)
                                        Forced.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandStrategyEVsClass();
                                    for (upcard = 1; upcard <= 10; upcard++)
                                        PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StandDone[upcard] = true;
                                }
                                else
                                {
                                    for (upcard = 1; upcard <= 10; upcard++)
                                    {
                                        // Max strategy so far is Stand
                                        PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StandDone[upcard] = true;
                                        Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].Strat[upcard] = (int)BJCAGlobalsClass.Strat.S;
                                        Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StratEV[upcard] = PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StandEV[upcard];
                                        Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StratPushEV[upcard] = PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StandPushEV[upcard];
                                    }
                                }
                            }

                            if (CDPN)
                            {
                                CurrentShoe.Deal(paircard);
                                // Now the remaining shoe states need to be filled in
                                var loopTo2 = NSplitHands;
                                for (hands = 0; hands <= loopTo2; hands++)
                                {
                                    if (NPxHands[hands].NN > 0)
                                    {
                                        for (upcard = 1; upcard <= 10; upcard++)
                                        {
                                            if (UCAllowed[upcard] & CurrentShoe.Cards[upcard] > 0)
                                            {
                                                CurrentShoe.Deal(upcard);
                                                if (PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands] is null)
                                                {
                                                    // Will only fill in empty hands so BJ isn't overwritten
                                                    PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands] = new BJCAHandEVsClass();
                                                    if (Opt.ComputeStrat)
                                                        Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands] = new BJCAHandStrategyEVsClass();
                                                    if (TD.ComputeStrat)
                                                        TD.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands] = new BJCAHandStrategyEVsClass();
                                                    if (TC.ComputeStrat)
                                                        TC.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands] = new BJCAHandStrategyEVsClass();
                                                    if (Forced.ComputeStrat)
                                                        Forced.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands] = new BJCAHandStrategyEVsClass();
                                                }

                                                if (NPxHands[hands].NP + PlayerHands[index].Hand.Cards[paircard] > CurrentShoe.Cards[paircard])
                                                {
                                                    PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].StandEV[upcard] = 0d;
                                                    Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].Strat[upcard] = 0;
                                                    Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].StratEV[upcard] = 0d;
                                                    Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].StratPushEV[upcard] = 0d;
                                                    PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].StandDone[upcard] = true;
                                                }
                                                else
                                                {
                                                    // First need to figure out post split paircard probs of UCH and CH hands
                                                    if (NPxHands[hands].NN == 1)
                                                    {
                                                        if (upcard == 1 & CheckAce)
                                                        {
                                                            if (paircard == 10)
                                                            {
                                                                pcprob[hands] = (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP) / (double)(CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP);
                                                            }
                                                            else
                                                            {
                                                                pcprob[hands] = (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP - (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP) / (double)(CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP + 1 - (CurrentShoe.Cards[10] - PlayerHands[index].Hand.Cards[10]))) / (CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP);
                                                            }
                                                        }
                                                        else if (upcard == 10 & CheckTen)
                                                        {
                                                            if (paircard == 1)
                                                            {
                                                                pcprob[hands] = (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP) / (double)(CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP);
                                                            }
                                                            else
                                                            {
                                                                pcprob[hands] = (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP - (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP) / (double)(CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP + 1 - (CurrentShoe.Cards[1] - PlayerHands[index].Hand.Cards[1]))) / (CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            pcprob[hands] = (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP) / (double)(CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP + 1);
                                                        }
                                                    }
                                                    else if (upcard == 1 & CheckAce | upcard == 10 & CheckTen) // NPxHands(hands).NN = 2
                                                    {
                                                        pcprob[hands] = ConditionalValue(pcprob[NPxHands[hands].UCH], pcprob[NPxHands[hands].CH], pcprob[NPxHands[hands].UCH]);
                                                    }
                                                    else
                                                    {
                                                        pcprob[hands] = (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP) / (double)(CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP + 1);
                                                    }
                                                    // Then use these paircard probs for the strategy
                                                    PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].StandEV[upcard] = ConditionalValue(PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], NPxHands[hands].UCH].StandEV[upcard], PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], NPxHands[hands].CH].StandEV[upcard], pcprob[hands]);
                                                    PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].StandPushEV[upcard] = ConditionalValue(PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], NPxHands[hands].UCH].StandPushEV[upcard], PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], NPxHands[hands].CH].StandPushEV[upcard], pcprob[hands]);
                                                    PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].BonusEV[upcard] = ConditionalValue(PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], NPxHands[hands].UCH].BonusEV[upcard], PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], NPxHands[hands].CH].BonusEV[upcard], pcprob[hands]);
                                                }
                                                CurrentShoe.Undeal(upcard);

                                                // Max strategy so far is Stand
                                                PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].StandDone[upcard] = true;
                                                Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].Strat[upcard] = (int)BJCAGlobalsClass.Strat.S;
                                                Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].StratEV[upcard] = PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].StandEV[upcard];
                                                Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].StratPushEV[upcard] = PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].StandPushEV[upcard];
                                            }
                                        }
                                    }
                                }
                                CurrentShoe.Undeal(paircard);
                            }
                        }
                    }
                }
            }
        }

        private void ComputeSplitBlackjack()
        {
            int index;
            int upcard;
            int paircard;
            int hands;
            var temphand = new BJCAHandClass();
            var pcprob = new double[12];    // Prob of paircard
            var newEVs = new BJCAHandEVsClass();

            index = BJIndex;

            if (index > 0)
            {
                for (paircard = 1; paircard <= 10; paircard++)
                {
                    if (SplitAllowed[paircard] & (paircard == 1 & BJSplitAces | paircard == 10 & BJSplitTens))
                    {
                        temphand.Copy(PlayerHands[index].Hand);
                        var loopTo = NSplitCalcs;
                        for (hands = 1; hands <= loopTo; hands++)
                        {
                            if (PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] is null)
                            {
                                PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandEVsClass();
                                Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandStrategyEVsClass();
                                if (TD.ComputeStrat)
                                    TD.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandStrategyEVsClass();
                                if (TC.ComputeStrat)
                                    TC.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandStrategyEVsClass();
                                if (Forced.ComputeStrat)
                                    Forced.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandStrategyEVsClass();
                            }

                            if (PlayerHands[index].Hand.Cards[paircard] + NPxHands[SplitCalcHands[hands]].NP + 1 - OriginalShoe.Cards[paircard] < 1)
                            {
                                temphand.Cards[paircard] += NPxHands[SplitCalcHands[hands]].NP + 1;
                                temphand.NumCards += NPxHands[SplitCalcHands[hands]].NP + 1;

                                for (upcard = 1; upcard <= 10; upcard++)
                                {
                                    if (UCAllowed[upcard])
                                    {
                                        newEVs = ComputeBlackjackHand(temphand, upcard, true);

                                        PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StandEV[upcard] = newEVs.StandEV[upcard];
                                        PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StandPushEV[upcard] = newEVs.StandPushEV[upcard];
                                        PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StandDone[upcard] = true;

                                        // Max strategy so far is Stand
                                        Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].Strat[upcard] = (int)BJCAGlobalsClass.Strat.S;
                                        Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StratEV[upcard] = PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StandEV[upcard];
                                        Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StratPushEV[upcard] = PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StandPushEV[upcard];
                                    }
                                }

                                temphand.Cards[paircard] -= NPxHands[SplitCalcHands[hands]].NP + 1;
                                temphand.NumCards -= NPxHands[SplitCalcHands[hands]].NP + 1;
                            }
                        }

                        if (CDPN)
                        {
                            CurrentShoe.Deal(paircard);
                            // Now the remaining shoe states need to be filled in
                            var loopTo1 = NSplitHands;
                            for (hands = 0; hands <= loopTo1; hands++)
                            {
                                if (NPxHands[hands].NN > 0)
                                {
                                    for (upcard = 1; upcard <= 10; upcard++)
                                    {
                                        if (UCAllowed[upcard] & CurrentShoe.Cards[upcard] > 0)
                                        {
                                            CurrentShoe.Deal(upcard);
                                            if (PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands] is null)
                                            {
                                                PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands] = new BJCAHandEVsClass();
                                                Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands] = new BJCAHandStrategyEVsClass();
                                                if (TD.ComputeStrat)
                                                    TD.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands] = new BJCAHandStrategyEVsClass();
                                                if (TC.ComputeStrat)
                                                    TC.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands] = new BJCAHandStrategyEVsClass();
                                                if (Forced.ComputeStrat)
                                                    Forced.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands] = new BJCAHandStrategyEVsClass();
                                            }

                                            if (NPxHands[hands].NP + PlayerHands[index].Hand.Cards[paircard] > CurrentShoe.Cards[paircard])
                                            {
                                                PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].StandEV[upcard] = 0d;
                                                Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].Strat[upcard] = 0;
                                                Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].StratEV[upcard] = 0d;
                                                Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].StratPushEV[upcard] = 0d;
                                            }
                                            else
                                            {
                                                // First need to figure out post split paircard probs of UCH and CH hands
                                                if (NPxHands[hands].NN == 1)
                                                {
                                                    if (upcard == 1 & CheckAce)
                                                    {
                                                        if (paircard == 10)
                                                        {
                                                            pcprob[hands] = (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP) / (double)(CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP);
                                                        }
                                                        else
                                                        {
                                                            pcprob[hands] = (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP - (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP) / (double)(CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP + 1 - (CurrentShoe.Cards[10] - PlayerHands[index].Hand.Cards[10]))) / (CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP);
                                                        }
                                                    }
                                                    else if (upcard == 10 & CheckTen)
                                                    {
                                                        if (paircard == 1)
                                                        {
                                                            pcprob[hands] = (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP) / (double)(CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP);
                                                        }
                                                        else
                                                        {
                                                            pcprob[hands] = (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP - (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP) / (double)(CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP + 1 - (CurrentShoe.Cards[1] - PlayerHands[index].Hand.Cards[1]))) / (CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        pcprob[hands] = (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP) / (double)(CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP + 1);
                                                    }
                                                }
                                                else if (upcard == 1 & CheckAce | upcard == 10 & CheckTen) // NPxHands(hands).NN = 2
                                                {
                                                    pcprob[hands] = ConditionalValue(pcprob[NPxHands[hands].UCH], pcprob[NPxHands[hands].CH], pcprob[NPxHands[hands].UCH]);
                                                }
                                                else
                                                {
                                                    pcprob[hands] = (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP) / (double)(CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP + 1);
                                                }
                                                // Then use these paircard probs for the strategy
                                                PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].StandEV[upcard] = ConditionalValue(PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], NPxHands[hands].UCH].StandEV[upcard], PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], NPxHands[hands].CH].StandEV[upcard], pcprob[hands]);
                                                PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].StandPushEV[upcard] = ConditionalValue(PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], NPxHands[hands].UCH].StandPushEV[upcard], PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], NPxHands[hands].CH].StandPushEV[upcard], pcprob[hands]);
                                            }
                                            CurrentShoe.Undeal(upcard);

                                            // Max strategy so far is Stand
                                            PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].StandDone[upcard] = true;
                                            Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].Strat[upcard] = (int)BJCAGlobalsClass.Strat.S;
                                            Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].StratEV[upcard] = PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].StandEV[upcard];
                                            Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].StratPushEV[upcard] = PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].StandPushEV[upcard];
                                        }
                                    }
                                }
                            }
                            CurrentShoe.Undeal(paircard);
                        }
                    }
                }
            }
        }

        private void ComputeSplitDouble()
        {
            int index;
            int upcard;
            int card;
            double prob;
            int paircard;
            int hands;
            var tempHand = new BJCAHandClass();
            var tempHand2 = new BJCAHandClass();
            var newEVs = new BJCAHandEVsClass();
            var pcprob = new double[12];

            if (DAS)
            {
                for (paircard = 1; paircard <= 10; paircard++)
                {
                    if (SplitAllowed[paircard] & !(paircard == 1 & !DSA))
                    {
                        var loopTo = NumPHands;
                        for (index = 1; index <= loopTo; index++)
                        {
                            if (PlayerHands[index].Hand.Cards[paircard] > 0)
                            {
                                tempHand.Copy(PlayerHands[index].Hand);
                                for (upcard = 1; upcard <= 10; upcard++)
                                {
                                    if (UCAllowed[upcard] & PlayerHands[index].DPostallowed[upcard] & CurrentShoe.Cards[upcard] > 0)
                                    {
                                        CurrentShoe.Deal(upcard, 1);
                                        var loopTo1 = NSplitHands;
                                        for (hands = 0; hands <= loopTo1; hands++)
                                        {
                                            if (PlayerHands[index].Hand.Cards[paircard] + NPxHands[hands].NP + 1 <= CurrentShoe.Cards[paircard])
                                            {
                                                if (NPxHands[hands].NN == 0)
                                                {
                                                    tempHand.Cards[paircard] += NPxHands[hands].NP + 1;
                                                    tempHand.NumCards += NPxHands[hands].NP + 1;
                                                    if (HandPossible(tempHand))
                                                    {
                                                        CurrentShoe.Deal(tempHand);
                                                        for (card = 1; card <= 10; card++)
                                                        {
                                                            if (Conversions.ToBoolean(CurrentShoe.Cards[card]))
                                                            {
                                                                prob = CardProb(card, upcard);
                                                                if (prob > 0d)
                                                                {
                                                                    if (Conversions.ToBoolean(PlayerHands[index].HitHand[card] & Conversions.ToInteger(PlayerHands[index].Hand.Soft) & Conversions.ToInteger(PlayerHands[PlayerHands[index].HitHand[card]].Hand.Cards[1] == 1) & Conversions.ToInteger(DSoftAllHard | DSoft19Hard & PlayerHands[index].Hand.Total == 19)))
                                                                    {
                                                                        CurrentShoe.Undeal(upcard, 1);
                                                                        CurrentShoe.Deal(card);
                                                                        CurrentShoe.Hand.Total = PlayerHands[index].Hand.Total - 10 + card;
                                                                        newEVs = ComputeStandHand(CurrentShoe.Hand, upcard, upcard, false);
                                                                        PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].DEV[upcard] += 2d * prob * newEVs.StandEV[upcard];
                                                                        PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].DPushEV[upcard] += 2d * prob * newEVs.StandPushEV[upcard];
                                                                        CurrentShoe.Undeal(card);
                                                                        CurrentShoe.Deal(upcard, 1);
                                                                    }
                                                                    else if (Conversions.ToBoolean(PlayerHands[index].HitHand[card]))
                                                                    {
                                                                        PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].DEV[upcard] += 2d * prob * PlayerHands[PlayerHands[index].HitHand[card]].SplitEVs[PlayerHands[PlayerHands[index].HitHand[card]].PairIndex[paircard], hands].StandEV[upcard];
                                                                        PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].DPushEV[upcard] += 2d * prob * PlayerHands[PlayerHands[index].HitHand[card]].SplitEVs[PlayerHands[PlayerHands[index].HitHand[card]].PairIndex[paircard], hands].StandPushEV[upcard];
                                                                    }
                                                                    else
                                                                    {
                                                                        PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].DEV[upcard] -= 2d * prob;
                                                                    }
                                                                }
                                                            }
                                                        }

                                                        CurrentShoe.Undeal(tempHand);

                                                        // Update Max strategy
                                                        if (PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].DEV[upcard] > Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].StratEV[upcard])
                                                        {
                                                            Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].Strat[upcard] = (int)BJCAGlobalsClass.Strat.D;
                                                            Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].StratEV[upcard] = PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].DEV[upcard];
                                                            Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].StratPushEV[upcard] = PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].DPushEV[upcard];
                                                        }
                                                    }

                                                    tempHand.Cards[paircard] -= NPxHands[hands].NP + 1;
                                                    tempHand.NumCards -= NPxHands[hands].NP + 1;
                                                }
                                                else if (CDPN)
                                                {
                                                    CurrentShoe.Deal(paircard, 1);
                                                    if (NPxHands[hands].NP + PlayerHands[index].Hand.Cards[paircard] > CurrentShoe.Cards[paircard])
                                                    {
                                                        PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].DEV[upcard] = 0d;
                                                        PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].DPushEV[upcard] = 0d;
                                                        pcprob[hands] = 0d;
                                                    }
                                                    else
                                                    {
                                                        if (NPxHands[hands].NN == 1)
                                                        {
                                                            if (upcard == 1 & CheckAce)
                                                            {
                                                                if (paircard == 10)
                                                                {
                                                                    pcprob[hands] = (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP) / (double)(CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP);
                                                                }
                                                                else
                                                                {
                                                                    pcprob[hands] = (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP - (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP) / (double)(CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP + 1 - (CurrentShoe.Cards[10] - PlayerHands[index].Hand.Cards[10]))) / (CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP);
                                                                }
                                                            }
                                                            else if (upcard == 10 & CheckTen)
                                                            {
                                                                if (paircard == 1)
                                                                {
                                                                    pcprob[hands] = (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP) / (double)(CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP);
                                                                }
                                                                else
                                                                {
                                                                    pcprob[hands] = (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP - (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP) / (double)(CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP + 1 - (CurrentShoe.Cards[1] - PlayerHands[index].Hand.Cards[1]))) / (CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                pcprob[hands] = (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP) / (double)(CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP + 1);
                                                            }
                                                        }
                                                        else if (upcard == 1 & CheckAce | upcard == 10 & CheckTen) // NPxHands(hands).NN = 2
                                                        {
                                                            pcprob[hands] = ConditionalValue(pcprob[NPxHands[hands].UCH], pcprob[NPxHands[hands].CH], pcprob[NPxHands[hands].UCH]);
                                                        }
                                                        else
                                                        {
                                                            pcprob[hands] = (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP) / (double)(CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP + 1);
                                                        }
                                                        PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].DEV[upcard] = ConditionalValue(PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], NPxHands[hands].UCH].DEV[upcard], PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], NPxHands[hands].CH].DEV[upcard], pcprob[hands]);
                                                        PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].DPushEV[upcard] = ConditionalValue(PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], NPxHands[hands].UCH].DPushEV[upcard], PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], NPxHands[hands].CH].DPushEV[upcard], pcprob[hands]);
                                                    }
                                                    CurrentShoe.Undeal(paircard, 1);

                                                    // Update Max strategy
                                                    if (PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].DEV[upcard] > Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].StratEV[upcard])
                                                    {
                                                        Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].Strat[upcard] = (int)BJCAGlobalsClass.Strat.D;
                                                        Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].StratEV[upcard] = PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].DEV[upcard];
                                                        Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].StratPushEV[upcard] = PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].DPushEV[upcard];
                                                    }
                                                }
                                            }
                                        }
                                        CurrentShoe.Undeal(upcard, 1);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ComputeSplitSurrender()
        {
            int index;
            int upcard;
            int paircard;
            int hands;
            var temphand = new BJCAHandClass();
            var pcprob = new double[12];
            BJCAHandEVsClass newevs;

            if (SAS)
            {
                for (paircard = 1; paircard <= 10; paircard++)
                {
                    if (SplitAllowed[paircard] & !(paircard == 1 & !SSA))
                    {
                        var loopTo = NumPHands;
                        for (index = 1; index <= loopTo; index++)
                        {
                            if (PlayerHands[index].Hand.NumCards > 1 & PlayerHands[index].Hand.Cards[paircard] > 0)
                            {
                                temphand.Copy(PlayerHands[index].Hand);
                                var loopTo1 = NSplitCalcs;
                                for (hands = 1; hands <= loopTo1; hands++)
                                {
                                    if (PlayerHands[index].Hand.Cards[paircard] + NPxHands[SplitCalcHands[hands]].NP + 1 - OriginalShoe.Cards[paircard] < 1)
                                    {
                                        temphand.Cards[paircard] += NPxHands[SplitCalcHands[hands]].NP + 1;
                                        temphand.NumCards += NPxHands[SplitCalcHands[hands]].NP + 1;

                                        for (upcard = 1; upcard <= 10; upcard++)
                                        {
                                            if (UCAllowed[upcard] & PlayerHands[index].RPostallowed[upcard] > 0)
                                            {
                                                newevs = ComputeSurrenderHand(temphand, PlayerHands[index].RPostallowed[upcard], upcard);

                                                PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].SurrEV[upcard] = newevs.SurrEV[upcard];

                                                // Update Max strategy
                                                if (PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].SurrEV[upcard] > Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StratEV[upcard])
                                                {
                                                    Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].Strat[upcard] = (int)BJCAGlobalsClass.Strat.R;
                                                    Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StratEV[upcard] = PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].SurrEV[upcard];
                                                    Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StratPushEV[upcard] = 0d;
                                                }

                                                temphand.Cards[paircard] -= NPxHands[SplitCalcHands[hands]].NP + 1;
                                                temphand.NumCards -= NPxHands[SplitCalcHands[hands]].NP + 1;
                                            }
                                        }
                                    }
                                }

                                if (CDPN)
                                {
                                    CurrentShoe.Deal(paircard);
                                    var loopTo2 = NSplitHands;
                                    for (hands = 0; hands <= loopTo2; hands++)
                                    {
                                        if (NPxHands[hands].NN > 0)
                                        {
                                            for (upcard = 1; upcard <= 10; upcard++)
                                            {
                                                if (UCAllowed[upcard] & CurrentShoe.Cards[upcard] > 0)
                                                {
                                                    CurrentShoe.Deal(upcard);
                                                    if (NPxHands[hands].NP + PlayerHands[index].Hand.Cards[paircard] > CurrentShoe.Cards[paircard])
                                                    {
                                                        PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].SurrEV[upcard] = 0d;
                                                    }
                                                    else
                                                    {
                                                        // First need to figure out post split paircard probs of UCH and CH hands
                                                        if (NPxHands[hands].NN == 1)
                                                        {
                                                            if (upcard == 1 & CheckAce)
                                                            {
                                                                if (paircard == 10)
                                                                {
                                                                    pcprob[hands] = (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP) / (double)(CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP);
                                                                }
                                                                else
                                                                {
                                                                    pcprob[hands] = (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP - (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP) / (double)(CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP + 1 - (CurrentShoe.Cards[10] - PlayerHands[index].Hand.Cards[10]))) / (CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP);
                                                                }
                                                            }
                                                            else if (upcard == 10 & CheckTen)
                                                            {
                                                                if (paircard == 1)
                                                                {
                                                                    pcprob[hands] = (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP) / (double)(CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP);
                                                                }
                                                                else
                                                                {
                                                                    pcprob[hands] = (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP - (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP) / (double)(CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP + 1 - (CurrentShoe.Cards[1] - PlayerHands[index].Hand.Cards[1]))) / (CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                pcprob[hands] = (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP) / (double)(CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP + 1);
                                                            }
                                                        }
                                                        else if (upcard == 1 & CheckAce | upcard == 10 & CheckTen) // NPxHands(hands).NN = 2
                                                        {
                                                            pcprob[hands] = ConditionalValue(pcprob[NPxHands[hands].UCH], pcprob[NPxHands[hands].CH], pcprob[NPxHands[hands].UCH]);
                                                        }
                                                        else
                                                        {
                                                            pcprob[hands] = (CurrentShoe.Cards[paircard] - PlayerHands[index].Hand.Cards[paircard] - NPxHands[hands].NP) / (double)(CurrentShoe.CardsLeft - PlayerHands[index].Hand.NumCards - NPxHands[hands].NN - NPxHands[hands].NP + 1);
                                                        }
                                                        // Then use these paircard probs for the strategy
                                                        PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].SurrEV[upcard] = ConditionalValue(PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], NPxHands[hands].UCH].SurrEV[upcard], PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], NPxHands[hands].CH].SurrEV[upcard], pcprob[hands]);
                                                    }
                                                    CurrentShoe.Undeal(upcard);

                                                    // Update Max strategy
                                                    if (PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].SurrEV[upcard] > Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].StratEV[upcard])
                                                    {
                                                        Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].Strat[upcard] = (int)BJCAGlobalsClass.Strat.R;
                                                        Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].StratEV[upcard] = PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].SurrEV[upcard];
                                                        Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].StratPushEV[upcard] = 0d;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    CurrentShoe.Undeal(paircard);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ComputeSplitHit()
        {
            int Total;
            int paircard;

            for (paircard = 1; paircard <= 10; paircard++)
            {
                if (SplitAllowed[paircard] & CurrentShoe.Cards[paircard] > 1 & !(paircard == 1 & !HSA))
                {
                    // Hit Values for total 21 already defined during EnumPlayerHands
                    for (Total = 21; Total >= 11; Total -= 1)
                        ComputeSplitHitTotal(Total, false, paircard);
                    for (Total = 21; Total >= 12; Total -= 1)
                        ComputeSplitHitTotal(Total, true, paircard);
                    for (Total = 10; Total >= 4; Total -= 1)
                        ComputeSplitHitTotal(Total, false, paircard);
                }
            }

        }

        private void ComputeSplitHitTotal(int Total, bool Soft, int paircard)
        {
            int index;
            int upcard;
            int card;
            double prob;
            int hands;
            var cProb = new double[12, 11];   // Prob of card
            var pcprob = new double[12];      // Prob of paircard

            index = PlayerHandTotal[Total, Conversions.ToInteger(Soft) + 1];
            while (index != 0)
            {
                if (PlayerHands[index].Hand.Cards[paircard] > 0)
                {
                    CurrentShoe.Deal(PlayerHands[index].Hand);
                    for (upcard = 1; upcard <= 10; upcard++)
                    {
                        if (UCAllowed[upcard] & CurrentShoe.Cards[upcard] > 0)
                        {
                            CurrentShoe.Deal(upcard);
                            var loopTo = NSplitHands;
                            for (hands = 0; hands <= loopTo; hands++)
                            {
                                if (NPxHands[hands].NP + 1 > CurrentShoe.Cards[paircard] | NPxHands[hands].NN > 0 & !CDPN)
                                {
                                    pcprob[hands] = 0d;
                                    for (card = 1; card <= 10; card++)
                                        cProb[hands, card] = 0d;
                                }
                                else
                                {
                                    if (NPxHands[hands].NN == 0)
                                    {
                                        CurrentShoe.Deal(paircard, NPxHands[hands].NP + 1);
                                        pcprob[hands] = CardProb(paircard, upcard);
                                        CurrentShoe.Undeal(paircard, NPxHands[hands].NP + 1);
                                    }
                                    else
                                    {
                                        pcprob[hands] = ConditionalValue(pcprob[NPxHands[hands].UCH], pcprob[NPxHands[hands].CH], pcprob[NPxHands[hands].UCH]);
                                    }

                                    for (card = 1; card <= 10; card++)
                                    {
                                        if (Conversions.ToBoolean(CurrentShoe.Cards[card]))
                                        {
                                            if (NPxHands[hands].NN == 0)
                                            {
                                                CurrentShoe.Deal(paircard, NPxHands[hands].NP + 1);
                                                cProb[hands, card] = CardProb(card, upcard);
                                                CurrentShoe.Undeal(paircard, NPxHands[hands].NP + 1);
                                            }
                                            else
                                            {
                                                cProb[hands, card] = ConditionalValue(cProb[NPxHands[hands].UCH, card], cProb[NPxHands[hands].CH, card], pcprob[NPxHands[hands].UCH]);
                                            }
                                            prob = cProb[hands, card];

                                            if (Conversions.ToBoolean(Conversions.ToInteger(prob > 0d) & PlayerHands[index].HitHand[card]))
                                            {
                                                Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].HitEV[upcard] += prob * (Opt.HandEVs[PlayerHands[index].HitHand[card]].SplitData[PlayerHands[PlayerHands[index].HitHand[card]].PairIndex[paircard], hands].StratEV[upcard] + PlayerHands[PlayerHands[index].HitHand[card]].SplitEVs[PlayerHands[PlayerHands[index].HitHand[card]].PairIndex[paircard], hands].BonusEV[upcard]);
                                                Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].HitPushEV[upcard] += prob * Opt.HandEVs[PlayerHands[index].HitHand[card]].SplitData[PlayerHands[PlayerHands[index].HitHand[card]].PairIndex[paircard], hands].StratPushEV[upcard];
                                            }
                                            else
                                            {
                                                Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].HitEV[upcard] -= prob;
                                            }
                                        }
                                    }

                                    // Update Max strategy for Optimal Play
                                    if (Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].HitEV[upcard] > Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].StratEV[upcard])
                                    {
                                        Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].Strat[upcard] = (int)BJCAGlobalsClass.Strat.H;
                                        Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].StratEV[upcard] = Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].HitEV[upcard];
                                        Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].StratPushEV[upcard] = Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].HitPushEV[upcard];
                                    }
                                }
                            }
                            CurrentShoe.Undeal(upcard);
                        }
                    }
                    CurrentShoe.Undeal(PlayerHands[index].Hand);
                }
                index = PlayerHands[index].NextHand;
            }

        }

        #endregion

        #region  General Split Methods 

        private void ComputeSplitHandProbs()
        {
            int paircard;
            int upcard;
            int hands;
            int card;
            int i;

            for (paircard = 1; paircard <= 10; paircard++)
            {
                if (SplitAllowed[paircard])
                {
                    CurrentShoe.Deal(paircard);  // Remove the extra pair card from the shoe
                    if (CardProb(paircard, 0) > 0d)
                    {
                        DealPCard(paircard);
                        for (upcard = 1; upcard <= 10; upcard++)
                        {
                            if (UCAllowed[upcard] & CardProb(upcard, 0) > 0d)
                            {
                                CurrentShoe.Deal(upcard);
                                SplitProbs[paircard, upcard] = new BJCASplitProbsClass();

                                for (card = 1; card <= 10; card++)
                                {
                                    if (CardProb(card, 0) > 0d)
                                    {
                                        // Calculate the non-conditional probabilities needed for p(P)'s
                                        var loopTo = NSplitCalcs;
                                        for (hands = 1; hands <= loopTo; hands++)
                                        {
                                            i = NPxHands[SplitCalcHands[hands]].NP;
                                            if (i > CurrentShoe.Cards[paircard])
                                                i = CurrentShoe.Cards[paircard];
                                            CurrentShoe.Deal(paircard, i);

                                            SplitProbs[paircard, upcard].PxCards[SplitCalcHands[hands], card] = CardProb(card, upcard);

                                            if ((BBO | OBBO | AOBBO) & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen)) // things get really ugly!!
                                            {
                                                // Now get the probs conditioned on dealer BJ and of dealer BJ
                                                CheckAce = true;
                                                CheckTen = true;
                                                SplitProbs[paircard, upcard].PCEVxCards[SplitCalcHands[hands], card] = CardProb(card, upcard);
                                                CheckAce = false;
                                                CheckTen = false;
                                                SplitProbs[paircard, upcard].PBJ[SplitCalcHands[hands], card] = 0d;
                                                SplitProbs[paircard, upcard].PPairBJCards[SplitCalcHands[hands], card] = 0d;
                                                if (upcard == 1 & !CheckAce)
                                                {
                                                    CurrentShoe.Deal(card);
                                                    SplitProbs[paircard, upcard].PBJ[SplitCalcHands[hands], card] = CardProb(10, 0);
                                                    SplitProbs[paircard, upcard].PPairBJCards[SplitCalcHands[hands], card] = CardProb(paircard, 0);
                                                    CurrentShoe.Undeal(card);
                                                    if (CardProb(10, 0) > 0d)
                                                    {
                                                        CurrentShoe.Deal(10);
                                                        SplitProbs[paircard, upcard].PBJxCards[SplitCalcHands[hands], card] = CardProb(card, 0);
                                                        CurrentShoe.Undeal(10);
                                                    }
                                                    else
                                                    {
                                                        SplitProbs[paircard, upcard].PBJxCards[SplitCalcHands[hands], card] = 0d;
                                                    }
                                                }
                                                else if (upcard == 10 & !CheckTen)
                                                {
                                                    CurrentShoe.Deal(card);
                                                    SplitProbs[paircard, upcard].PBJ[SplitCalcHands[hands], card] = CardProb(1, 0);
                                                    SplitProbs[paircard, upcard].PPairBJCards[SplitCalcHands[hands], card] = CardProb(paircard, 0);
                                                    CurrentShoe.Undeal(card);
                                                    if (CardProb(1, 0) > 0d)
                                                    {
                                                        CurrentShoe.Deal(1);
                                                        SplitProbs[paircard, upcard].PBJxCards[SplitCalcHands[hands], card] = CardProb(card, 0);
                                                        CurrentShoe.Undeal(1);
                                                    }
                                                    else
                                                    {
                                                        SplitProbs[paircard, upcard].PBJxCards[SplitCalcHands[hands], card] = 0d;
                                                    }
                                                }
                                            }
                                            CurrentShoe.Undeal(paircard, i);
                                        }

                                        // Now fill in the conditional state probs
                                        var loopTo1 = NSplitHands;
                                        for (hands = 0; hands <= loopTo1; hands++)
                                        {
                                            if (NPxHands[hands].NN > 0)
                                            {
                                                SplitProbs[paircard, upcard].PxCards[hands, card] = ConditionalValue(SplitProbs[paircard, upcard].PxCards[NPxHands[hands].UCH, card], SplitProbs[paircard, upcard].PxCards[NPxHands[hands].CH, card], SplitProbs[paircard, upcard].PxCards[NPxHands[hands].UCH, paircard]);
                                                if ((BBO | OBBO | AOBBO) & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                                                {
                                                    SplitProbs[paircard, upcard].PBJ[hands, card] = ConditionalValue(SplitProbs[paircard, upcard].PBJ[NPxHands[hands].UCH, card], SplitProbs[paircard, upcard].PBJ[NPxHands[hands].CH, card], SplitProbs[paircard, upcard].PPairBJCards[NPxHands[hands].UCH, paircard]);
                                                    SplitProbs[paircard, upcard].PCEVxCards[hands, card] = ConditionalValue(SplitProbs[paircard, upcard].PCEVxCards[NPxHands[hands].UCH, card], SplitProbs[paircard, upcard].PCEVxCards[NPxHands[hands].CH, card], SplitProbs[paircard, upcard].PCEVxCards[NPxHands[hands].UCH, paircard]);
                                                    SplitProbs[paircard, upcard].PBJxCards[hands, card] = ConditionalValue(SplitProbs[paircard, upcard].PBJxCards[NPxHands[hands].UCH, card], SplitProbs[paircard, upcard].PBJxCards[NPxHands[hands].CH, card], SplitProbs[paircard, upcard].PBJxCards[NPxHands[hands].UCH, paircard]);
                                                }
                                            }
                                        }

                                    }  // Currentshoe(card)
                                }
                                CurrentShoe.Undeal(upcard);
                            }
                        }
                        UndealPCard(paircard);
                    }
                    CurrentShoe.Undeal(paircard);
                }
            }
        }

        private void ComputeSplitHandsEV(ref BJCAStrategyClass cStrat, int paircard, int upcard)
        {
            int hands;
            int card;
            int i;
            double prob;
            var cProb = default(double);
            int Strat;
            int index;
            int newIndex;
            double EV;
            double cEV;
            double netCEV;
            var bjadjprob = default(double);
            double pRes;
            double pResEV;
            var newEVs = new BJCAHandEVsClass();
            var newHitEVs = new BJCASplitHandEVsClass();
            var newHand = new BJCAPlayerHandClass();

            // Playerhand at this point should already have the first paircard and the upcard dealt

            // Saves alternative hands calculation for ev's
            double ev2;

            // Compute the EV's of the second cards in the hands to use to calculate the EV(x)'s and EV(N)'s
            // Play out hand to stand based on TD Strategy
            for (card = 1; card <= 10; card++)
            {
                if (CardProb(card, 0) > 0d)
                {
                    DealPCard(card);
                    index = FindPlayerHand(CurrentPHand);

                    var loopTo = NSplitCalcs;
                    for (hands = 1; hands <= loopTo; hands++)
                    {
                        // Check to see if the hands need to be added
                        if (PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] is null)
                        {
                            PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandEVsClass();
                            Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandStrategyEVsClass();
                            if (TD.ComputeStrat)
                                TD.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandStrategyEVsClass();
                            if (TC.ComputeStrat)
                                TC.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandStrategyEVsClass();
                            if (Forced.ComputeStrat)
                                Forced.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandStrategyEVsClass();
                        }

                        if (NPxHands[SplitCalcHands[hands]].NP != 0 & !MultiCardPossible(paircard, NPxHands[SplitCalcHands[hands]].NP))
                        {
                            EV = 0d;
                            PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StandEV[upcard] = EV;
                            PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StandDone[upcard] = true;
                        }
                        else if (cStrat.Name == "CD" & (CDPN | CDP))
                        {
                            cStrat.SplitStateEVs[paircard, upcard].EVCards[SplitCalcHands[hands], card] = cStrat.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StratEV[upcard];
                        }
                        else
                        {
                            CurrentShoe.Deal(paircard, NPxHands[SplitCalcHands[hands]].NP);

                            if (cStrat.HandEVs[index].PostForced[upcard])
                            {
                                Strat = GetPostSplitStrat(cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard], paircard, upcard, cStrat, PlayerHands[index]);
                            }
                            else if (cStrat.NCardsCD > 1)
                            {
                                Strat = GetPostSplitStrat(cStrat.HandEVs[index].EVs.Strat[upcard], paircard, upcard, cStrat, PlayerHands[index]);
                            }
                            else
                            {
                                Strat = GetPostSplitStrat(cStrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].Strat[upcard], paircard, upcard, cStrat, PlayerHands[index]);
                            }
                            if (!cStrat.HandEVs[index].PostForced[upcard])
                            {
                                cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard] = Strat;
                            }
                            switch (Strat)
                            {
                                case (int)BJCAGlobalsClass.Strat.S:
                                    {
                                        if (PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StandDone[upcard] & !P21AutoWin & !BonusRuleOn)
                                        {
                                            EV = PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StandEV[upcard];
                                            EV += PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].BonusEV[upcard];
                                            cStrat.SplitStateEVs[paircard, upcard].EVCards[SplitCalcHands[hands], card] = EV;
                                        }
                                        else
                                        {
                                            CurrentShoe.Undeal(upcard);
                                            CurrentShoe.Hand.Total = CurrentPHand.Total;
                                            newEVs = ComputeSplitStandHand(CurrentShoe.Hand, upcard);
                                            newHand.HandEVs.Empty();
                                            newHand.HandEVs.StandEV[upcard] = newEVs.StandEV[upcard];
                                            newHand.HandEVs.BJStandEV[upcard] = newEVs.BJStandEV[upcard];
                                            if (BonusRuleOn)
                                            {
                                                newHand.Hand.Copy(PlayerHands[index].Hand);
                                                if (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen)
                                                {
                                                    if (upcard == 1 & !CheckAce)
                                                    {
                                                        bjadjprob = BJHandNumerator[10, CurrentShoe.Hand.Cards[10], 1] / BJHandDivisor[CurrentShoe.Hand.NumCards + 1, 1];
                                                    }
                                                    else if (upcard == 10 & !CheckTen)
                                                    {
                                                        bjadjprob = BJHandNumerator[1, CurrentShoe.Hand.Cards[1], 1] / BJHandDivisor[CurrentShoe.Hand.NumCards + 1, 1];
                                                    }
                                                    else
                                                    {
                                                        bjadjprob = 0d;
                                                    }
                                                }
                                                else
                                                {
                                                    bjadjprob = 0d;
                                                }
                                                newEVs.Empty();
                                                newEVs = ApplyBonusRulesNonSuitedHand(newHand, upcard, bjadjprob, true, false);
                                                newHand.HandEVs.StandEV[upcard] = newEVs.StandEV[upcard];
                                                newHand.HandEVs.BonusEV[upcard] = newEVs.BonusEV[upcard];
                                                newHand.HandEVs.BJStandEV[upcard] = newEVs.BJStandEV[upcard];
                                            }
                                            CurrentShoe.Deal(upcard);
                                            EV = newHand.HandEVs.StandEV[upcard] + newHand.HandEVs.BonusEV[upcard];
                                            PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StandEV[upcard] = newHand.HandEVs.StandEV[upcard];
                                            PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].BonusEV[upcard] = newHand.HandEVs.BonusEV[upcard];
                                            PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].BJStandEV[upcard] = newHand.HandEVs.BJStandEV[upcard];
                                            PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].StandDone[upcard] = true;
                                            cStrat.SplitStateEVs[paircard, upcard].EVCards[SplitCalcHands[hands], card] = EV;
                                        }
                                        if ((BBO | OBBO | AOBBO) & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                                        {
                                            // ENHC = (1-p(BJ))*(EV|no dBJ) + p(BJ)*((1-sum(p(Res))*(-1) + sum(p(Res)*EV(Res|dBJ))
                                            // Non-Doubled
                                            // Note that pRes = 1 or 0 and BBO = ENHC when resolved
                                            // BBO = (1-p(BJ))*(EV|no dBJ) + p(BJ)*((1-sum(p(Res))*(0) + sum(p(Res)*EV(Res|dBJ))
                                            // BBO = ENHC + p(BJ)*(1-sum(p(Res))*(1)
                                            // OBBO = (1-p(BJ))*(EV|no dBJ) + p(BJ)*((1-sum(p(Res))*(-1) + sum(p(Res)*EV(Res|dBJ))
                                            // OBBO = ENHC

                                            if (PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].BJStandEV[upcard] != -1)
                                            {
                                                // The probability of resolution will be adjusted below for the player card
                                                cStrat.SplitStateEVs[paircard, upcard].PResCards[SplitCalcHands[hands], card] = 1d;
                                                cStrat.SplitStateEVs[paircard, upcard].PResEVCards[SplitCalcHands[hands], card] = PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].BJStandEV[upcard];
                                            }
                                            else
                                            {
                                                cStrat.SplitStateEVs[paircard, upcard].PResCards[SplitCalcHands[hands], card] = 0d;
                                                cStrat.SplitStateEVs[paircard, upcard].PResEVCards[SplitCalcHands[hands], card] = 0d;
                                            }
                                            if (EV == 0d)
                                            {
                                                cStrat.SplitStateEVs[paircard, upcard].BBOCards[SplitCalcHands[hands], card] = 0d;
                                                cStrat.SplitStateEVs[paircard, upcard].OBBOCards[SplitCalcHands[hands], card] = 0d;
                                                cStrat.SplitStateEVs[paircard, upcard].CEVCards[SplitCalcHands[hands], card] = 0d;
                                            }
                                            else
                                            {
                                                cStrat.SplitStateEVs[paircard, upcard].BBOCards[SplitCalcHands[hands], card] = cStrat.SplitStateEVs[paircard, upcard].EVCards[SplitCalcHands[hands], card] + SplitProbs[paircard, upcard].PBJ[SplitCalcHands[hands], card] * (1d - cStrat.SplitStateEVs[paircard, upcard].PResCards[SplitCalcHands[hands], card]);
                                                cStrat.SplitStateEVs[paircard, upcard].OBBOCards[SplitCalcHands[hands], card] = cStrat.SplitStateEVs[paircard, upcard].EVCards[SplitCalcHands[hands], card];

                                                // CEV = (UCEV - pBJ * netEVBJ) / (1 - pBJ)
                                                cStrat.SplitStateEVs[paircard, upcard].CEVCards[SplitCalcHands[hands], card] = (cStrat.SplitStateEVs[paircard, upcard].EVCards[SplitCalcHands[hands], card] - ((1d - cStrat.SplitStateEVs[paircard, upcard].PResCards[SplitCalcHands[hands], card]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVCards[SplitCalcHands[hands], card]) * SplitProbs[paircard, upcard].PBJ[SplitCalcHands[hands], card]) / (1d - SplitProbs[paircard, upcard].PBJ[SplitCalcHands[hands], card]);
                                            }
                                        }

                                        break;
                                    }
                                case (int)BJCAGlobalsClass.Strat.D:
                                    {
                                        EV = 0d;
                                        cEV = 0d;
                                        netCEV = 0d;
                                        pRes = 0d;
                                        pResEV = 0d;
                                        for (i = 1; i <= 10; i++) // Deal double card
                                        {
                                            if (CardProb(i, 0) == 0d)
                                            {
                                                EV = 0d;
                                                cEV = 0d;
                                            }
                                            else
                                            {
                                                prob = CardProb(i, upcard);
                                                if ((BBO | OBBO | AOBBO) & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                                                {
                                                    CheckAce = true;
                                                    CheckTen = true;
                                                    cProb = CardProb(i, upcard);
                                                    CheckAce = false;
                                                    CheckTen = false;
                                                }
                                                DealPCard(i);
                                                if ((BBO | OBBO | AOBBO) & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                                                {
                                                    if (upcard == 1 & !CheckAce)
                                                    {
                                                        bjadjprob = CardProb(10, 0);
                                                    }
                                                    else if (upcard == 10 & !CheckTen)
                                                    {
                                                        bjadjprob = CardProb(1, 0);
                                                    }
                                                    else
                                                    {
                                                        bjadjprob = 0d;
                                                    }
                                                }
                                                newIndex = PlayerHands[index].HitHand[i];
                                                if (newIndex > 0 & PlayerHands[newIndex].SplitEVs[PlayerHands[newIndex].PairIndex[paircard], SplitCalcHands[hands]] is null)
                                                {
                                                    PlayerHands[newIndex].SplitEVs[PlayerHands[newIndex].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandEVsClass();
                                                    Opt.HandEVs[newIndex].SplitData[PlayerHands[newIndex].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandStrategyEVsClass();
                                                    if (TD.ComputeStrat)
                                                        TD.HandEVs[newIndex].SplitData[PlayerHands[newIndex].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandStrategyEVsClass();
                                                    if (TC.ComputeStrat)
                                                        TC.HandEVs[newIndex].SplitData[PlayerHands[newIndex].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandStrategyEVsClass();
                                                    if (Forced.ComputeStrat)
                                                        Forced.HandEVs[newIndex].SplitData[PlayerHands[newIndex].PairIndex[paircard], SplitCalcHands[hands]] = new BJCAHandStrategyEVsClass();
                                                }
                                                if (PlayerHands[index].Hand.Soft & PlayerHands[newIndex].Hand.Cards[1] == 1 & (DSoftAllHard | DSoft19Hard & PlayerHands[index].Hand.Total == 19))
                                                {
                                                    CurrentShoe.Undeal(upcard);
                                                    CurrentShoe.Hand.Total = CurrentPHand.Total - 10;
                                                    newEVs = ComputeSplitStandHand(CurrentShoe.Hand, upcard);
                                                    EV = newEVs.StandEV[upcard] * prob;
                                                    cEV = cProb * (newEVs.StandEV[upcard] - newEVs.BJStandEV[upcard] * bjadjprob) / (1d - bjadjprob);
                                                    CurrentShoe.Deal(upcard);
                                                }
                                                else if (CurrentPHand.Total > 21)
                                                {
                                                    EV = -1;
                                                    if ((BBO | OBBO | AOBBO) & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                                                    {
                                                        cEV = -cProb;
                                                        // pRes for DAS conditioned on dealer actually having BJ
                                                        if (upcard == 1 & !CheckAce & CardProb(10, 0) > 0d)
                                                        {
                                                            UndealPCard(i);
                                                            CurrentShoe.Deal(10);
                                                            pRes += CardProb(i, 0);
                                                            pResEV -= CardProb(i, 0);
                                                            CurrentShoe.Undeal(10);
                                                            DealPCard(i);
                                                        }
                                                        else if (upcard == 10 & !CheckTen & CardProb(1, 0) > 0d)
                                                        {
                                                            UndealPCard(i);
                                                            CurrentShoe.Deal(1);
                                                            pRes += CardProb(i, 0);
                                                            pResEV -= CardProb(i, 0);
                                                            CurrentShoe.Undeal(1);
                                                            DealPCard(i);
                                                        }
                                                    }
                                                }
                                                else if (!(RDAPS | DDRPS))
                                                {
                                                    // No need to go through the hassle of figuring out the double strategy
                                                    if (PlayerHands[newIndex].SplitEVs[PlayerHands[newIndex].PairIndex[paircard], SplitCalcHands[hands]].StandDone[upcard])
                                                    {
                                                        EV = PlayerHands[newIndex].SplitEVs[PlayerHands[newIndex].PairIndex[paircard], SplitCalcHands[hands]].StandEV[upcard] * prob;
                                                        cEV = cProb * (EV / prob - PlayerHands[newIndex].SplitEVs[PlayerHands[newIndex].PairIndex[paircard], SplitCalcHands[hands]].BJStandEV[upcard] * bjadjprob) / (1d - bjadjprob);
                                                    }
                                                    else
                                                    {
                                                        CurrentShoe.Undeal(upcard);
                                                        CurrentShoe.Hand.Total = CurrentPHand.Total;
                                                        newEVs = ComputeSplitStandHand(CurrentShoe.Hand, upcard);
                                                        EV = newEVs.StandEV[upcard] * prob;
                                                        cEV = cProb * (newEVs.StandEV[upcard] - newEVs.BJStandEV[upcard] * bjadjprob) / (1d - bjadjprob);
                                                        CurrentShoe.Deal(upcard);
                                                        PlayerHands[newIndex].SplitEVs[PlayerHands[newIndex].PairIndex[paircard], SplitCalcHands[hands]].StandEV[upcard] = newEVs.StandEV[upcard];
                                                        PlayerHands[newIndex].SplitEVs[PlayerHands[newIndex].PairIndex[paircard], SplitCalcHands[hands]].BJStandEV[upcard] = newEVs.BJStandEV[upcard];
                                                        PlayerHands[newIndex].SplitEVs[PlayerHands[newIndex].PairIndex[paircard], SplitCalcHands[hands]].StandDone[upcard] = true;
                                                    }
                                                    if ((BBO | OBBO | AOBBO) & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen) & CurrentPHand.Total == 21 & P21AutoWin)
                                                    {
                                                        // pRes for DAS conditioned on dealer actually having BJ
                                                        if (upcard == 1 & !CheckAce & CardProb(10, 0) > 0d)
                                                        {
                                                            UndealPCard(i);
                                                            CurrentShoe.Deal(10);
                                                            pRes += CardProb(i, 0);
                                                            pResEV += 2d * CardProb(i, 0);
                                                            CurrentShoe.Undeal(10);
                                                            DealPCard(i);
                                                        }
                                                        else if (upcard == 10 & !CheckTen & CardProb(1, 0) > 0d)
                                                        {
                                                            UndealPCard(i);
                                                            CurrentShoe.Deal(1);
                                                            pRes += CardProb(i, 0);
                                                            pResEV += 2d * CardProb(i, 0);
                                                            CurrentShoe.Undeal(1);
                                                            DealPCard(i);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    // The hand is not busted and DDR and/or RDA is allowed after splitting
                                                    newEVs = ComputeSplitDoubleCardEV(newIndex, upcard, 1);
                                                    EV = newEVs.DStratEV[upcard] * prob;
                                                    if (newEVs.BJStandEV[upcard] != 1d)
                                                    {
                                                        cEV = cProb * (newEVs.DStratEV[upcard] - (-1 * bjadjprob)) / (1d - bjadjprob);
                                                    }
                                                    else
                                                    {
                                                        cEV = cProb * newEVs.DStratEV[upcard];
                                                    }
                                                    if ((BBO | OBBO | AOBBO) & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                                                    {
                                                        // pRes for DAS conditioned on dealer actually having BJ
                                                        if (upcard == 1 & !CheckAce & CardProb(10, 0) > 0d & newEVs.BJStandEV[upcard] == 1d)
                                                        {
                                                            UndealPCard(i);
                                                            CurrentShoe.Deal(10);
                                                            pRes += CardProb(i, 0);
                                                            pResEV += 2d * CardProb(i, 0) * newEVs.DStratEV[upcard];
                                                            CurrentShoe.Undeal(10);
                                                            DealPCard(i);
                                                        }
                                                        else if (upcard == 10 & !CheckTen & CardProb(1, 0) > 0d)
                                                        {
                                                            UndealPCard(i);
                                                            CurrentShoe.Deal(1);
                                                            pRes += CardProb(i, 0);
                                                            pResEV += 2d * CardProb(i, 0) * newEVs.DStratEV[upcard];
                                                            CurrentShoe.Undeal(1);
                                                            DealPCard(i);
                                                        }
                                                    }
                                                }
                                                UndealPCard(i);
                                            }
                                            cStrat.SplitStateEVs[paircard, upcard].EVCards[SplitCalcHands[hands], card] += EV;
                                            netCEV += cEV;
                                        }
                                        cStrat.SplitStateEVs[paircard, upcard].EVCards[SplitCalcHands[hands], card] *= 2d;
                                        netCEV *= 2d;
                                        PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].DEV[upcard] = cStrat.SplitStateEVs[paircard, upcard].EVCards[SplitCalcHands[hands], card];
                                        if ((BBO | OBBO | AOBBO) & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                                        {
                                            // ENHC = (1-p(BJ))*(EV|no dBJ) + p(BJ)*((1-sum(p(Res))*(-2) + sum(p(Res)*EV(Res|dBJ))
                                            // Doubled
                                            // Note that pRes = 1 or 0 and BBO = ENHC when resolved
                                            // BBO = (1-p(BJ))*(EV|no dBJ) + p(BJ)*((1-sum(p(Res))*(0) + sum(p(Res)*EV(Res|dBJ))
                                            // BBO = ENHC + p(BJ)*(1-sum(p(Res))*(2)
                                            // OBBO = (1-p(BJ))*(EV|no dBJ) + p(BJ)*((1-sum(p(Res))*(-1) + sum(p(Res)*EV(Res|dBJ))
                                            // OBBO = ENHC + p(BJ)*(1-sum(p(Res))

                                            cStrat.SplitStateEVs[paircard, upcard].PResCards[SplitCalcHands[hands], card] = pRes;
                                            cStrat.SplitStateEVs[paircard, upcard].PResEVCards[SplitCalcHands[hands], card] = pResEV;
                                            if (EV == 0d)
                                            {
                                                cStrat.SplitStateEVs[paircard, upcard].BBOCards[SplitCalcHands[hands], card] = 0d;
                                                cStrat.SplitStateEVs[paircard, upcard].OBBOCards[SplitCalcHands[hands], card] = 0d;
                                            }
                                            else
                                            {
                                                cStrat.SplitStateEVs[paircard, upcard].BBOCards[SplitCalcHands[hands], card] = cStrat.SplitStateEVs[paircard, upcard].EVCards[SplitCalcHands[hands], card] + 2d * SplitProbs[paircard, upcard].PBJ[SplitCalcHands[hands], card] * (1d - cStrat.SplitStateEVs[paircard, upcard].PResCards[SplitCalcHands[hands], card]);
                                                cStrat.SplitStateEVs[paircard, upcard].OBBOCards[SplitCalcHands[hands], card] = cStrat.SplitStateEVs[paircard, upcard].EVCards[SplitCalcHands[hands], card] + SplitProbs[paircard, upcard].PBJ[SplitCalcHands[hands], card] * (1d - cStrat.SplitStateEVs[paircard, upcard].PResCards[SplitCalcHands[hands], card]);
                                            }

                                            cStrat.SplitStateEVs[paircard, upcard].CEVCards[SplitCalcHands[hands], card] = netCEV;
                                        }

                                        break;
                                    }
                                case (int)BJCAGlobalsClass.Strat.H:
                                    {
                                        newHitEVs.Empty();
                                        cStrat.SplitStateEVs[paircard, upcard].PResCards[SplitCalcHands[hands], card] = 0d;
                                        cStrat.SplitStateEVs[paircard, upcard].PResEVCards[SplitCalcHands[hands], card] = 0d;
                                        newHitEVs = ComputeSplitHitHandEV(ref cStrat, paircard, upcard, SplitCalcHands[hands], index, card, 1d);
                                        EV = newHitEVs.StandEV[upcard];
                                        cStrat.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].HitEV[upcard] = EV;
                                        cStrat.SplitStateEVs[paircard, upcard].EVCards[SplitCalcHands[hands], card] = EV;
                                        if ((BBO | OBBO | AOBBO) & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                                        {
                                            // pRes is calculated automatically through splitplayerhit
                                            if (EV == 0d)
                                            {
                                                cStrat.SplitStateEVs[paircard, upcard].BBOCards[SplitCalcHands[hands], card] = 0d;
                                                cStrat.SplitStateEVs[paircard, upcard].OBBOCards[SplitCalcHands[hands], card] = 0d;
                                                cStrat.SplitStateEVs[paircard, upcard].CEVCards[SplitCalcHands[hands], card] = 0d;
                                            }
                                            else
                                            {
                                                cStrat.SplitStateEVs[paircard, upcard].BBOCards[SplitCalcHands[hands], card] = newHitEVs.BBOEV[upcard];
                                                cStrat.SplitStateEVs[paircard, upcard].OBBOCards[SplitCalcHands[hands], card] = newHitEVs.OBBOEV[upcard];

                                                cStrat.SplitStateEVs[paircard, upcard].CEVCards[SplitCalcHands[hands], card] = newHitEVs.CEV[upcard];
                                            }
                                        }

                                        break;
                                    }
                                case (int)BJCAGlobalsClass.Strat.R:
                                    {
                                        newEVs = ComputeSurrenderHand(CurrentShoe.Hand, cStrat.HandEVs[index].RPostallowed[upcard], upcard);
                                        EV = newEVs.SurrEV[upcard];
                                        PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], SplitCalcHands[hands]].SurrEV[upcard] = EV;
                                        cStrat.SplitStateEVs[paircard, upcard].EVCards[SplitCalcHands[hands], card] = EV;

                                        if ((BBO | OBBO | AOBBO) & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                                        {
                                            // See Stand for details
                                            if (cStrat.HandEVs[index].RPostallowed[upcard] == (int)BJCAGlobalsClass.Surr.ES)
                                            {
                                                cStrat.SplitStateEVs[paircard, upcard].PResCards[SplitCalcHands[hands], card] = 1d;
                                                cStrat.SplitStateEVs[paircard, upcard].PResEVCards[SplitCalcHands[hands], card] = SurrDBJPays;
                                            }
                                            else
                                            {
                                                cStrat.SplitStateEVs[paircard, upcard].PResCards[SplitCalcHands[hands], card] = 0d;
                                                cStrat.SplitStateEVs[paircard, upcard].PResEVCards[SplitCalcHands[hands], card] = 0d;
                                            }
                                            if (EV == 0d)
                                            {
                                                cStrat.SplitStateEVs[paircard, upcard].BBOCards[SplitCalcHands[hands], card] = 0d;
                                                cStrat.SplitStateEVs[paircard, upcard].OBBOCards[SplitCalcHands[hands], card] = 0d;
                                                cStrat.SplitStateEVs[paircard, upcard].CEVCards[SplitCalcHands[hands], card] = 0d;
                                            }
                                            else
                                            {
                                                cStrat.SplitStateEVs[paircard, upcard].BBOCards[SplitCalcHands[hands], card] = cStrat.SplitStateEVs[paircard, upcard].EVCards[SplitCalcHands[hands], card] + SplitProbs[paircard, upcard].PBJ[SplitCalcHands[hands], card] * (1d - cStrat.SplitStateEVs[paircard, upcard].PResCards[SplitCalcHands[hands], card]);
                                                cStrat.SplitStateEVs[paircard, upcard].OBBOCards[SplitCalcHands[hands], card] = cStrat.SplitStateEVs[paircard, upcard].EVCards[SplitCalcHands[hands], card];

                                                // CEV = (UCEV - pBJ * netEVBJ) / (1 - pBJ)
                                                cStrat.SplitStateEVs[paircard, upcard].CEVCards[SplitCalcHands[hands], card] = (cStrat.SplitStateEVs[paircard, upcard].EVCards[SplitCalcHands[hands], card] - ((1d - cStrat.SplitStateEVs[paircard, upcard].PResCards[SplitCalcHands[hands], card]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVCards[SplitCalcHands[hands], card]) * SplitProbs[paircard, upcard].PBJ[SplitCalcHands[hands], card]) / (1d - SplitProbs[paircard, upcard].PBJ[SplitCalcHands[hands], card]);
                                            }
                                        }

                                        break;
                                    }
                            }

                            CurrentShoe.Undeal(paircard, NPxHands[SplitCalcHands[hands]].NP);
                        }
                    }
                    UndealPCard(card);
                }  // Currentshoe(card)
            }

            // Compute EV(x)'s and EV(N)'s
            var loopTo1 = NSplitHands;
            for (hands = 0; hands <= loopTo1; hands++)
            {
                if (NPxHands[hands].NN == 0)
                {
                    for (card = 1; card <= 10; card++)
                        cStrat.SplitStateEVs[paircard, upcard].EVx[hands] += cStrat.SplitStateEVs[paircard, upcard].EVCards[hands, card] * SplitProbs[paircard, upcard].PxCards[hands, card];
                    cStrat.SplitStateEVs[paircard, upcard].EVN[hands] = ConditionalValue(cStrat.SplitStateEVs[paircard, upcard].EVx[hands], cStrat.SplitStateEVs[paircard, upcard].EVCards[hands, paircard], SplitProbs[paircard, upcard].PxCards[hands, paircard]);
                }
                else if (CDPN & cStrat.Name == "CD")
                {
                    if (CurrentShoe.Cards[paircard] >= NPxHands[hands].NP)
                    {
                        CurrentShoe.Deal(paircard, NPxHands[hands].NP);
                        for (card = 1; card <= 10; card++)
                        {
                            if (CurrentShoe.Cards[card] > 0)
                            {
                                DealPCard(card);
                                index = FindPlayerHand(CurrentPHand);
                                cStrat.SplitStateEVs[paircard, upcard].EVCards[hands, card] = cStrat.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].StratEV[upcard];
                                SplitProbs[paircard, upcard].PxCards[hands, card] = ConditionalValue(SplitProbs[paircard, upcard].PxCards[NPxHands[hands].UCH, card], SplitProbs[paircard, upcard].PxCards[NPxHands[hands].CH, card], SplitProbs[paircard, upcard].PxCards[NPxHands[hands].UCH, paircard]);
                                cStrat.SplitStateEVs[paircard, upcard].EVx[hands] = cStrat.SplitStateEVs[paircard, upcard].EVx[hands] + cStrat.SplitStateEVs[paircard, upcard].EVCards[hands, card] * SplitProbs[paircard, upcard].PxCards[hands, card];
                                UndealPCard(card);
                            }
                        }
                        cStrat.SplitStateEVs[paircard, upcard].EVN[hands] = ConditionalValue(cStrat.SplitStateEVs[paircard, upcard].EVx[hands], cStrat.SplitStateEVs[paircard, upcard].EVCards[hands, paircard], SplitProbs[paircard, upcard].PxCards[hands, paircard]);

                        CurrentShoe.Undeal(paircard, NPxHands[hands].NP);
                    }
                }
                else
                {
                    cStrat.SplitStateEVs[paircard, upcard].EVx[hands] = ConditionalValue(cStrat.SplitStateEVs[paircard, upcard].EVx[NPxHands[hands].UCH], cStrat.SplitStateEVs[paircard, upcard].EVx[NPxHands[hands].CH], SplitProbs[paircard, upcard].PxCards[NPxHands[hands].UCH, paircard]);
                    cStrat.SplitStateEVs[paircard, upcard].EVN[hands] = ConditionalValue(cStrat.SplitStateEVs[paircard, upcard].EVN[NPxHands[hands].UCH], cStrat.SplitStateEVs[paircard, upcard].EVN[NPxHands[hands].CH], SplitProbs[paircard, upcard].PxCards[hands, paircard]);
                }

                // Here we need not only the probability of busting, but also the conditional EV of each N and x
                if ((BBO | OBBO | AOBBO) & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    // Calculate the overall p(Bust) for N and x
                    if (NPxHands[hands].NN == 0)
                    {
                        for (card = 1; card <= 10; card++)
                        {
                            // Add up the probabilities of the hand resolving given a dealer BJ
                            cStrat.SplitStateEVs[paircard, upcard].PResx[hands] += cStrat.SplitStateEVs[paircard, upcard].PResCards[hands, card] * SplitProbs[paircard, upcard].PBJxCards[hands, card];
                            cStrat.SplitStateEVs[paircard, upcard].PResEVx[hands] += cStrat.SplitStateEVs[paircard, upcard].PResEVCards[hands, card] * SplitProbs[paircard, upcard].PBJxCards[hands, card];
                            // Add up the appropriate hand evs
                            cStrat.SplitStateEVs[paircard, upcard].BBOx[hands] += cStrat.SplitStateEVs[paircard, upcard].BBOCards[hands, card] * SplitProbs[paircard, upcard].PxCards[hands, card];
                            cStrat.SplitStateEVs[paircard, upcard].OBBOx[hands] += cStrat.SplitStateEVs[paircard, upcard].OBBOCards[hands, card] * SplitProbs[paircard, upcard].PxCards[hands, card];
                            // Add them with the correct probs to get the conditional EV
                            cStrat.SplitStateEVs[paircard, upcard].CEVx[hands] += cStrat.SplitStateEVs[paircard, upcard].CEVCards[hands, card] * SplitProbs[paircard, upcard].PCEVxCards[hands, card];
                        }
                        cStrat.SplitStateEVs[paircard, upcard].PResN[hands] = ConditionalValue(cStrat.SplitStateEVs[paircard, upcard].PResx[hands], cStrat.SplitStateEVs[paircard, upcard].PResCards[hands, paircard], SplitProbs[paircard, upcard].PBJxCards[hands, paircard]);
                        cStrat.SplitStateEVs[paircard, upcard].PResEVN[hands] = ConditionalValue(cStrat.SplitStateEVs[paircard, upcard].PResEVx[hands], cStrat.SplitStateEVs[paircard, upcard].PResEVCards[hands, paircard], SplitProbs[paircard, upcard].PBJxCards[hands, paircard]);
                        cStrat.SplitStateEVs[paircard, upcard].BBON[hands] = ConditionalValue(cStrat.SplitStateEVs[paircard, upcard].BBOx[hands], cStrat.SplitStateEVs[paircard, upcard].BBOCards[hands, paircard], SplitProbs[paircard, upcard].PxCards[hands, paircard]);
                        cStrat.SplitStateEVs[paircard, upcard].OBBON[hands] = ConditionalValue(cStrat.SplitStateEVs[paircard, upcard].OBBOx[hands], cStrat.SplitStateEVs[paircard, upcard].OBBOCards[hands, paircard], SplitProbs[paircard, upcard].PxCards[hands, paircard]);
                        // Then to get EVN, we also need the EVx of the paircard)
                        cStrat.SplitStateEVs[paircard, upcard].CEVN[hands] = ConditionalValue(cStrat.SplitStateEVs[paircard, upcard].CEVx[hands], cStrat.SplitStateEVs[paircard, upcard].CEVCards[hands, paircard], SplitProbs[paircard, upcard].PCEVxCards[hands, paircard]);
                    }
                    else
                    {
                        // Fill in the other states
                        cStrat.SplitStateEVs[paircard, upcard].PResx[hands] = ConditionalValue(cStrat.SplitStateEVs[paircard, upcard].PResx[NPxHands[hands].UCH], cStrat.SplitStateEVs[paircard, upcard].PResx[NPxHands[hands].CH], SplitProbs[paircard, upcard].PBJxCards[NPxHands[hands].UCH, paircard]);
                        cStrat.SplitStateEVs[paircard, upcard].PResN[hands] = ConditionalValue(cStrat.SplitStateEVs[paircard, upcard].PResN[NPxHands[hands].UCH], cStrat.SplitStateEVs[paircard, upcard].PResN[NPxHands[hands].CH], SplitProbs[paircard, upcard].PBJxCards[hands, paircard]);
                        cStrat.SplitStateEVs[paircard, upcard].PResEVx[hands] = ConditionalValue(cStrat.SplitStateEVs[paircard, upcard].PResEVx[NPxHands[hands].UCH], cStrat.SplitStateEVs[paircard, upcard].PResEVx[NPxHands[hands].CH], SplitProbs[paircard, upcard].PBJxCards[NPxHands[hands].UCH, paircard]);
                        cStrat.SplitStateEVs[paircard, upcard].PResEVN[hands] = ConditionalValue(cStrat.SplitStateEVs[paircard, upcard].PResEVN[NPxHands[hands].UCH], cStrat.SplitStateEVs[paircard, upcard].PResEVN[NPxHands[hands].CH], SplitProbs[paircard, upcard].PBJxCards[hands, paircard]);
                        cStrat.SplitStateEVs[paircard, upcard].BBOx[hands] = ConditionalValue(cStrat.SplitStateEVs[paircard, upcard].BBOx[NPxHands[hands].UCH], cStrat.SplitStateEVs[paircard, upcard].BBOx[NPxHands[hands].CH], SplitProbs[paircard, upcard].PxCards[NPxHands[hands].UCH, paircard]);
                        cStrat.SplitStateEVs[paircard, upcard].BBON[hands] = ConditionalValue(cStrat.SplitStateEVs[paircard, upcard].BBON[NPxHands[hands].UCH], cStrat.SplitStateEVs[paircard, upcard].BBON[NPxHands[hands].CH], SplitProbs[paircard, upcard].PxCards[hands, paircard]);
                        cStrat.SplitStateEVs[paircard, upcard].OBBOx[hands] = ConditionalValue(cStrat.SplitStateEVs[paircard, upcard].OBBOx[NPxHands[hands].UCH], cStrat.SplitStateEVs[paircard, upcard].OBBOx[NPxHands[hands].CH], SplitProbs[paircard, upcard].PxCards[NPxHands[hands].UCH, paircard]);
                        cStrat.SplitStateEVs[paircard, upcard].OBBON[hands] = ConditionalValue(cStrat.SplitStateEVs[paircard, upcard].OBBON[NPxHands[hands].UCH], cStrat.SplitStateEVs[paircard, upcard].OBBON[NPxHands[hands].CH], SplitProbs[paircard, upcard].PxCards[hands, paircard]);
                        cStrat.SplitStateEVs[paircard, upcard].CEVx[hands] = ConditionalValue(cStrat.SplitStateEVs[paircard, upcard].CEVx[NPxHands[hands].UCH], cStrat.SplitStateEVs[paircard, upcard].CEVx[NPxHands[hands].CH], SplitProbs[paircard, upcard].PCEVxCards[NPxHands[hands].UCH, paircard]);
                        cStrat.SplitStateEVs[paircard, upcard].CEVN[hands] = ConditionalValue(cStrat.SplitStateEVs[paircard, upcard].CEVN[NPxHands[hands].UCH], cStrat.SplitStateEVs[paircard, upcard].CEVN[NPxHands[hands].CH], SplitProbs[paircard, upcard].PCEVxCards[hands, paircard]);
                    }
                }
            }

        }

        private BJCASplitHandEVsClass ComputeSplitHitHandEV(ref BJCAStrategyClass cStrat, int paircard, int upcard, int hands, int oldindex, int basecard, double NetpResProb)
        {
            int card;
            int i;
            double EV;
            double CEV;
            double netCEV;
            double BBOEV;
            double OBBOEV;
            var pRes = default(double);
            double DEV;
            double prob;
            var cProb = default(double);
            double dProb;
            double cDEV;
            var cDProb = default(double);
            var bjadjprob = default(double);
            double tempEV;
            var tempPush = default(double);
            double tempBJEV;
            int strat;
            int index;
            int newIndex;
            double newNetpResProb;
            double dRes;
            double dResEV;
            double push;
            double dPush;
            var newEVs = new BJCAHandEVsClass();
            var newHitEVs = new BJCASplitHandEVsClass();
            var newHand = new BJCAPlayerHandClass();
            var tempHand = new BJCAHandClass();

            EV = 0d;
            CEV = 0d;
            push = 0d;
            BBOEV = 0d;
            OBBOEV = 0d;

            // Play out hand to stand based on the Strategy
            for (card = 1; card <= 10; card++)
            {
                if (CardProb(card, 0) > 0d)
                {
                    prob = CardProb(card, upcard);

                    newNetpResProb = NetpResProb;
                    if ((BBO | OBBO | AOBBO) & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                    {
                        CheckAce = true;
                        CheckTen = true;
                        cProb = CardProb(card, upcard);
                        CheckAce = false;
                        CheckTen = false;
                        if (upcard == 1 & !CheckAce)
                        {
                            if (CardProb(10, 0) > 0d)
                            {
                                CurrentShoe.Deal(10, 1);
                                newNetpResProb = NetpResProb * CardProb(card, 0);
                                CurrentShoe.Undeal(10, 1);
                            }
                            else
                            {
                                newNetpResProb = 0d;
                            }
                        }
                        else if (upcard == 10 & !CheckTen)
                        {
                            if (CardProb(1, 0) > 0d)
                            {
                                CurrentShoe.Deal(1, 1);
                                newNetpResProb = NetpResProb * CardProb(card, 0);
                                CurrentShoe.Undeal(1, 1);
                            }
                            else
                            {
                                newNetpResProb = 0d;
                            }
                        }
                    }

                    if (CurrentPHand.Total + card > 21 & !CurrentPHand.Soft)  // Busted
                    {
                        EV -= prob;
                        CEV -= cProb;
                        if ((BBO | OBBO | AOBBO) & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                        {
                            cStrat.SplitStateEVs[paircard, upcard].PResCards[hands, basecard] += newNetpResProb;
                            cStrat.SplitStateEVs[paircard, upcard].PResEVCards[hands, basecard] -= newNetpResProb;
                            BBOEV -= prob;
                            OBBOEV -= prob;
                        }
                    }
                    else    // Not busted
                    {
                        DealPCard(card);
                        index = PlayerHands[oldindex].HitHand[card];

                        if (PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands] is null)
                        {
                            PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands] = new BJCAHandEVsClass();
                        }
                        if (cStrat.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands] is null)
                        {
                            cStrat.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands] = new BJCAHandStrategyEVsClass();
                        }

                        if (cStrat.HandEVs[index].PostForced[upcard])
                        {
                            strat = GetPostSplitStrat(cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard], paircard, upcard, cStrat, PlayerHands[index]);
                        }
                        else if (cStrat.NCardsCD >= PlayerHands[index].Hand.NumCards)
                        {
                            strat = GetPostSplitStrat(cStrat.HandEVs[index].EVs.Strat[upcard], paircard, upcard, cStrat, PlayerHands[index]);
                        }
                        else
                        {
                            strat = GetPostSplitStrat(cStrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].Strat[upcard], paircard, upcard, cStrat, PlayerHands[index]);
                        }
                        if (!cStrat.HandEVs[index].PostForced[upcard])
                        {
                            cStrat.HandEVs[index].EVs.ForcedPostStrat[upcard] = strat;
                        }
                        switch (strat)
                        {
                            case (int)BJCAGlobalsClass.Strat.S:   // Stand
                                {
                                    if (PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].StandDone[upcard] & !P21AutoWin & !BonusRuleOn)
                                    {
                                        tempEV = PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].StandEV[upcard] + PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].BonusEV[upcard];
                                        tempPush = PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].StandPushEV[upcard];
                                        tempBJEV = PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].BJStandEV[upcard];
                                    }
                                    else
                                    {
                                        CurrentShoe.Undeal(upcard, 1);
                                        CurrentShoe.Hand.Total = CurrentPHand.Total;
                                        newEVs = ComputeSplitStandHand(CurrentShoe.Hand, upcard);
                                        newHand.HandEVs.Empty();
                                        newHand.HandEVs.StandEV[upcard] = newEVs.StandEV[upcard];
                                        newHand.HandEVs.StandPushEV[upcard] = newEVs.StandPushEV[upcard];
                                        newHand.HandEVs.BJStandEV[upcard] = newEVs.BJStandEV[upcard];
                                        if (BonusRuleOn)
                                        {
                                            newHand.Hand.Copy(PlayerHands[index].Hand);
                                            if (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen)
                                            {
                                                if (upcard == 1 & !CheckAce)
                                                {
                                                    bjadjprob = BJHandNumerator[10, CurrentShoe.Hand.Cards[10], 1] / BJHandDivisor[CurrentShoe.Hand.NumCards + 1, 1];
                                                }
                                                else if (upcard == 10 & !CheckTen)
                                                {
                                                    bjadjprob = BJHandNumerator[1, CurrentShoe.Hand.Cards[1], 1] / BJHandDivisor[CurrentShoe.Hand.NumCards + 1, 1];
                                                }
                                                else
                                                {
                                                    bjadjprob = 0d;
                                                }
                                            }
                                            else
                                            {
                                                bjadjprob = 0d;
                                            }
                                            newEVs.Empty();
                                            newEVs = ApplyBonusRulesNonSuitedHand(newHand, upcard, bjadjprob, true, false);
                                            newHand.HandEVs.StandEV[upcard] = newEVs.StandEV[upcard];
                                            newHand.HandEVs.StandPushEV[upcard] = newEVs.StandPushEV[upcard];
                                            newHand.HandEVs.BonusEV[upcard] = newEVs.BonusEV[upcard];
                                            newHand.HandEVs.BJStandEV[upcard] = newEVs.BJStandEV[upcard];
                                        }
                                        tempEV = newHand.HandEVs.StandEV[upcard] + newHand.HandEVs.BonusEV[upcard];
                                        tempPush = newHand.HandEVs.StandPushEV[upcard];
                                        tempBJEV = newEVs.BJStandEV[upcard];
                                        CurrentShoe.Deal(upcard, 1);
                                        PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].StandEV[upcard] = newEVs.StandEV[upcard];
                                        PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].StandPushEV[upcard] = newEVs.StandPushEV[upcard];
                                        PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].BonusEV[upcard] = newEVs.BonusEV[upcard];
                                        PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].BJStandEV[upcard] = newEVs.BJStandEV[upcard];
                                        PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].StandDone[upcard] = true;
                                    }

                                    EV += prob * tempEV;
                                    push += prob * tempPush;
                                    if ((BBO | OBBO | AOBBO) & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                                    {
                                        // ENHC = (1-p(BJ))*(EV|no dBJ) + p(BJ)*((1-sum(p(Res))*(-1) + sum(p(Res)*EV(Res|dBJ))
                                        // Non-Doubled
                                        // Note that pRes = 1 or 0 and BBO = ENHC when resolved
                                        // BBO = (1-p(BJ))*(EV|no dBJ) + p(BJ)*((1-sum(p(Res))*(0) + sum(p(Res)*EV(Res|dBJ))
                                        // BBO = ENHC + p(BJ)*(1-sum(p(Res))*(1)
                                        // OBBO = (1-p(BJ))*(EV|no dBJ) + p(BJ)*((1-sum(p(Res))*(-1) + sum(p(Res)*EV(Res|dBJ))
                                        // OBBO = ENHC
                                        if (upcard == 1 & !CheckAce)
                                        {
                                            bjadjprob = CardProb(10, 0);
                                        }
                                        else if (upcard == 10 & !CheckTen)
                                        {
                                            bjadjprob = CardProb(1, 0);
                                        }
                                        else
                                        {
                                            bjadjprob = 0d;
                                        }
                                        if (tempBJEV != -1)
                                        {
                                            // The probability of resolution will be adjusted below for the player card
                                            cStrat.SplitStateEVs[paircard, upcard].PResCards[hands, basecard] += newNetpResProb;
                                            cStrat.SplitStateEVs[paircard, upcard].PResEVCards[hands, basecard] += newNetpResProb * tempBJEV;
                                            pRes = 1d;
                                        }
                                        if (EV != 0d)
                                        {
                                            BBOEV += prob * (tempEV + bjadjprob * (1d - pRes));
                                            OBBOEV += prob * tempEV;

                                            // CEV = (UCEV - pBJ * netEVBJ) / (1 - pBJ)
                                            CEV += cProb * (tempEV - bjadjprob * tempBJEV) / (1d - bjadjprob);
                                        }
                                    }

                                    break;
                                }
                            case (int)BJCAGlobalsClass.Strat.D:   // Double
                                {
                                    DEV = 0d;
                                    dPush = 0d;
                                    dRes = 0d;
                                    dResEV = 0d;
                                    cDEV = 0d;
                                    netCEV = 0d;
                                    for (i = 1; i <= 10; i++) // Deal double card
                                    {
                                        dProb = CardProb(i, upcard);
                                        if (dProb == 0d)
                                        {
                                            DEV = 0d;
                                            cDEV = 0d;
                                        }
                                        else
                                        {
                                            if ((BBO | OBBO | AOBBO) & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                                            {
                                                CheckAce = true;
                                                CheckTen = true;
                                                cDProb = CardProb(i, upcard);
                                                CheckAce = false;
                                                CheckTen = false;
                                            }
                                            DealPCard(i);
                                            if ((BBO | OBBO | AOBBO) & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                                            {
                                                if (upcard == 1 & !CheckAce)
                                                {
                                                    bjadjprob = CardProb(10, 0);
                                                }
                                                else if (upcard == 10 & !CheckTen)
                                                {
                                                    bjadjprob = CardProb(1, 0);
                                                }
                                                else
                                                {
                                                    bjadjprob = 0d;
                                                }
                                            }
                                            newIndex = PlayerHands[index].HitHand[i];
                                            if (newIndex > 0 & PlayerHands[newIndex].SplitEVs[PlayerHands[newIndex].PairIndex[paircard], hands] is null)
                                            {
                                                PlayerHands[newIndex].SplitEVs[PlayerHands[newIndex].PairIndex[paircard], hands] = new BJCAHandEVsClass();
                                                cStrat.HandEVs[newIndex].SplitData[PlayerHands[newIndex].PairIndex[paircard], hands] = new BJCAHandStrategyEVsClass();
                                            }
                                            if (PlayerHands[oldindex].Hand.Soft & PlayerHands[newIndex].Hand.Cards[1] == 1 & (DSoftAllHard | DSoft19Hard & PlayerHands[oldindex].Hand.Total == 19))
                                            {
                                                CurrentShoe.Undeal(upcard, 1);
                                                CurrentShoe.Hand.Total = CurrentPHand.Total - 10;
                                                newEVs = ComputeSplitStandHand(CurrentShoe.Hand, upcard);

                                                tempEV = newEVs.StandEV[upcard];
                                                tempPush = newEVs.StandPushEV[upcard];
                                                cDEV = (newEVs.StandEV[upcard] - newEVs.BJStandEV[upcard] * bjadjprob) / (1d - bjadjprob);
                                                CurrentShoe.Deal(upcard, 1);
                                            }
                                            else if (CurrentPHand.Total > 21)
                                            {
                                                tempEV = -1;
                                                cDEV = -1;
                                                if ((BBO | OBBO | AOBBO) & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                                                {
                                                    // Busts for DAS conditioned on dealer actually having BJ
                                                    if (upcard == 1 & !CheckAce & CardProb(10, 0) > 0d)
                                                    {
                                                        UndealPCard(i);
                                                        CurrentShoe.Deal(10, 1);
                                                        dRes += CardProb(i, 0);
                                                        dResEV -= 2d * CardProb(i, 0);
                                                        CurrentShoe.Undeal(10, 1);
                                                        DealPCard(i);
                                                    }
                                                    else if (upcard == 10 & !CheckTen & CardProb(1, 0) > 0d)
                                                    {
                                                        UndealPCard(i);
                                                        CurrentShoe.Deal(1, 1);
                                                        dRes += CardProb(i, 0);
                                                        dResEV -= 2d * CardProb(i, 0);
                                                        CurrentShoe.Undeal(1, 1);
                                                        DealPCard(i);
                                                    }
                                                }
                                            }
                                            else if (!(RDAPS | DDRPS))
                                            {
                                                if (PlayerHands[newIndex].SplitEVs[PlayerHands[newIndex].PairIndex[paircard], hands].StandDone[upcard])
                                                {
                                                    tempEV = PlayerHands[newIndex].SplitEVs[PlayerHands[newIndex].PairIndex[paircard], hands].StandEV[upcard];
                                                    tempPush = PlayerHands[newIndex].SplitEVs[PlayerHands[newIndex].PairIndex[paircard], hands].StandPushEV[upcard];
                                                    tempBJEV = PlayerHands[newIndex].SplitEVs[PlayerHands[newIndex].PairIndex[paircard], hands].BJStandEV[upcard];

                                                    cDEV = (tempEV - tempBJEV * bjadjprob) / (1d - bjadjprob);
                                                }
                                                else
                                                {
                                                    CurrentShoe.Undeal(upcard, 1);
                                                    CurrentShoe.Hand.Total = CurrentPHand.Total;
                                                    newEVs = ComputeSplitStandHand(CurrentShoe.Hand, upcard);
                                                    tempEV = newEVs.StandEV[upcard];
                                                    tempPush = newEVs.StandPushEV[upcard];
                                                    tempBJEV = newEVs.BJStandEV[upcard];
                                                    cDEV = (newEVs.StandEV[upcard] - newEVs.BJStandEV[upcard] * bjadjprob) / (1d - bjadjprob);
                                                    CurrentShoe.Deal(upcard, 1);
                                                    PlayerHands[newIndex].SplitEVs[PlayerHands[newIndex].PairIndex[paircard], hands].StandEV[upcard] = newEVs.StandEV[upcard];
                                                    PlayerHands[newIndex].SplitEVs[PlayerHands[newIndex].PairIndex[paircard], hands].StandPushEV[upcard] = newEVs.StandPushEV[upcard];
                                                    PlayerHands[newIndex].SplitEVs[PlayerHands[newIndex].PairIndex[paircard], hands].BJStandEV[upcard] = newEVs.BJStandEV[upcard];
                                                    PlayerHands[newIndex].SplitEVs[PlayerHands[newIndex].PairIndex[paircard], hands].StandDone[upcard] = true;
                                                }
                                                if ((BBO | OBBO | AOBBO) & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen) & tempBJEV != -1)
                                                {
                                                    // pRes for DAS conditioned on dealer actually having BJ
                                                    if (upcard == 1 & !CheckAce & CardProb(10, 0) > 0d)
                                                    {
                                                        UndealPCard(i);
                                                        CurrentShoe.Deal(10);
                                                        dRes += CardProb(i, 0);
                                                        dResEV += 2d * CardProb(i, 0) * tempBJEV;
                                                        CurrentShoe.Undeal(10);
                                                        DealPCard(i);
                                                    }
                                                    else if (upcard == 10 & !CheckTen & CardProb(1, 0) > 0d)
                                                    {
                                                        UndealPCard(i);
                                                        CurrentShoe.Deal(1);
                                                        dRes += CardProb(i, 0);
                                                        dResEV += 2d * CardProb(i, 0) * tempBJEV;
                                                        CurrentShoe.Undeal(1);
                                                        DealPCard(i);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                // The hand is not busted and DDR and/or RDA is allowed after splitting
                                                newEVs = ComputeSplitDoubleCardEV(newIndex, upcard, 1);
                                                tempEV = newEVs.DStratEV[upcard];
                                                tempPush = newEVs.DStratPushEV[upcard];
                                                if (newEVs.BJStandEV[upcard] != 1d)
                                                {
                                                    cDEV = (newEVs.DStratEV[upcard] - (-1 * bjadjprob)) / (1d - bjadjprob);
                                                }
                                                else
                                                {
                                                    cDEV = newEVs.DStratEV[upcard];
                                                }
                                                if ((BBO | OBBO | AOBBO) & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen) & newEVs.BJStandEV[upcard] == 1d)
                                                {
                                                    // pRes for DAS conditioned on dealer actually having BJ
                                                    if (upcard == 1 & !CheckAce & CardProb(10, 0) > 0d)
                                                    {
                                                        UndealPCard(i);
                                                        CurrentShoe.Deal(10);
                                                        dRes += CardProb(i, 0);
                                                        dResEV += 2d * CardProb(i, 0) * newEVs.DStratEV[upcard];
                                                        CurrentShoe.Undeal(10);
                                                        DealPCard(i);
                                                    }
                                                    else if (upcard == 10 & !CheckTen & CardProb(1, 0) > 0d)
                                                    {
                                                        UndealPCard(i);
                                                        CurrentShoe.Deal(1);
                                                        dRes += CardProb(i, 0);
                                                        dResEV += 2d * CardProb(i, 0) * newEVs.DStratEV[upcard];
                                                        CurrentShoe.Undeal(1);
                                                        DealPCard(i);
                                                    }
                                                }
                                            }

                                            DEV += dProb * tempEV;
                                            dPush += dProb * tempPush;
                                            netCEV += cDProb * cDEV;
                                            UndealPCard(i);
                                        }
                                    }
                                    EV += prob * 2d * DEV;
                                    push += prob * 2d * dPush;
                                    if ((BBO | OBBO | AOBBO) & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                                    {
                                        cStrat.SplitStateEVs[paircard, upcard].PResCards[hands, basecard] += newNetpResProb * dRes;
                                        cStrat.SplitStateEVs[paircard, upcard].PResEVCards[hands, basecard] += newNetpResProb * dRes * dResEV;
                                        // ENHC = (1-p(BJ))*(EV|no dBJ) + p(BJ)*((1-sum(p(Res))*(-2) + sum(p(Res)*EV(Res|dBJ))
                                        // Doubled
                                        // Note that pRes = 1 or 0 and BBO = ENHC when resolved
                                        // BBO = (1-p(BJ))*(EV|no dBJ) + p(BJ)*((1-sum(p(Res))*(0) + sum(p(Res)*EV(Res|dBJ))
                                        // BBO = ENHC + p(BJ)*(1-sum(p(Res))*(2)
                                        // OBBO = (1-p(BJ))*(EV|no dBJ) + p(BJ)*((1-sum(p(Res))*(-1) + sum(p(Res)*EV(Res|dBJ))
                                        // OBBO = ENHC + p(BJ)*(1-sum(p(Res))

                                        if (upcard == 1 & !CheckAce)
                                        {
                                            bjadjprob = CardProb(10, 0);
                                        }
                                        else if (upcard == 10 & !CheckTen)
                                        {
                                            bjadjprob = CardProb(1, 0);
                                        }
                                        else
                                        {
                                            bjadjprob = 0d;
                                        }
                                        if (EV != 0d)
                                        {
                                            BBOEV += prob * (2d * DEV + 2d * bjadjprob * (1d - dRes));
                                            OBBOEV += prob * (2d * DEV + bjadjprob * (1d - dRes));
                                        }
                                        CEV += cProb * 2d * netCEV;
                                    }

                                    break;
                                }
                            case (int)BJCAGlobalsClass.Strat.H:  // Hit
                                {
                                    newHitEVs.Empty();
                                    newHitEVs = ComputeSplitHitHandEV(ref cStrat, paircard, upcard, hands, index, basecard, newNetpResProb);
                                    // The stand and push ev's are actually holding the hit and hitpush ev's
                                    tempEV = newHitEVs.StandEV[upcard];
                                    cStrat.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].HitEV[upcard] = tempEV;
                                    cStrat.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].HitPushEV[upcard] = tempPush;
                                    EV += prob * tempEV;
                                    push += prob * tempPush;
                                    if ((BBO | OBBO | AOBBO) & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                                    {
                                        BBOEV += prob * newHitEVs.BBOEV[upcard];
                                        OBBOEV += prob * newHitEVs.OBBOEV[upcard];

                                        // CEV = (UCEV - pBJ * netEVBJ) / (1 - pBJ)
                                        CEV += cProb * newHitEVs.CEV[upcard];
                                    }

                                    break;
                                }
                            case (int)BJCAGlobalsClass.Strat.R:
                                {
                                    newEVs = ComputeSurrenderHand(CurrentShoe.Hand, cStrat.HandEVs[index].RPostallowed[upcard], upcard);
                                    EV += prob * newEVs.SurrEV[upcard];
                                    if ((BBO | OBBO | AOBBO) & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                                    {
                                        // ENHC = (1-p(BJ))*(EV|no dBJ) + p(BJ)*((1-sum(p(Res))*(-1) + sum(p(Res)*EV(Res|dBJ))
                                        // Non-Doubled
                                        // Note that pRes = 1 or 0 and BBO = ENHC when resolved
                                        // BBO = (1-p(BJ))*(EV|no dBJ) + p(BJ)*((1-sum(p(Res))*(0) + sum(p(Res)*EV(Res|dBJ))
                                        // BBO = ENHC + p(BJ)*(1-sum(p(Res))*(1)
                                        // OBBO = (1-p(BJ))*(EV|no dBJ) + p(BJ)*((1-sum(p(Res))*(-1) + sum(p(Res)*EV(Res|dBJ))
                                        // OBBO = ENHC
                                        if (upcard == 1 & !CheckAce)
                                        {
                                            bjadjprob = CardProb(10, 0);
                                        }
                                        else if (upcard == 10 & !CheckTen)
                                        {
                                            bjadjprob = CardProb(1, 0);
                                        }
                                        else
                                        {
                                            bjadjprob = 0d;
                                        }
                                        if (cStrat.HandEVs[index].RPostallowed[upcard] == (int)BJCAGlobalsClass.Surr.ES)
                                        {
                                            cStrat.SplitStateEVs[paircard, upcard].PResCards[hands, basecard] += newNetpResProb;
                                            cStrat.SplitStateEVs[paircard, upcard].PResEVCards[hands, basecard] += newNetpResProb * SurrDBJPays;
                                            pRes = 1d;
                                        }
                                        else
                                        {
                                            pRes = 0d;
                                        }
                                        if (EV != 0d)
                                        {
                                            BBOEV += prob * (newEVs.SurrEV[upcard] + bjadjprob * (1d - pRes));
                                            OBBOEV += prob * newEVs.SurrEV[upcard];

                                            // CEV = (UCEV - pBJ * netEVBJ) / (1 - pBJ)
                                            CEV += cProb * (newEVs.SurrEV[upcard] - bjadjprob * SurrDBJPays) / (1d - bjadjprob);
                                        }
                                    }

                                    break;
                                }
                        }
                        UndealPCard(card);
                    }  // Busted
                }  // Currentshoe(card)
            }

            newHitEVs.StandEV[upcard] = EV;

            if ((BBO | OBBO | AOBBO) & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
            {
                // Hold BBO and OBBO values in Dealerprobs
                newHitEVs.BBOEV[upcard] = BBOEV;
                newHitEVs.OBBOEV[upcard] = OBBOEV;
                newHitEVs.CEV[upcard] = CEV;
            }

            return newHitEVs;

        }

        private void ComputeSplitEVs(ref BJCAStrategyClass cStrat, int paircard, int upcard)
        {
            double EV;
            var EV2 = default(double);
            var EV3 = default(double);
            double EV4;
            var bjadjprob = default(double);
            double prob;
            var p1 = default(double);
            var p2 = default(double);

            // Compute the SPL's now
            if (BBO | OBBO | AOBBO)
            {
                if (upcard == 1 & !CheckAce)
                {
                    bjadjprob = CardProb(10, 0);
                }
                else if (upcard == 10 & !CheckTen)
                {
                    bjadjprob = CardProb(1, 0);
                }
                else
                {
                    bjadjprob = 0d;
                }
            }

            // The first EV's take into account the effects of removal for each N and P card.
            // The second represent the actual shoe states when using a fixed strategy and not using OBBO/BBO.
            // When using a fixed stratey and non-OBBO/BBO play, the EV's for the two final split ev's are identical
            // BBO  = Sum(State UCEVs with loss bust) - (1 - Prob(All Bust))*pBJ
            // OBBO = UCEV(Original Bet with Loss 1) + Sum(UCEV's other hands with Loss Bust)
            // AustOBBO = Sum(State UCEVs with Loss 1)
            // The shoe states that take into account each card removed are closer to the sims so they are used.

            // ENHC = (1-p(BJ))*(EV|no dBJ) + p(BJ)*((1-sum(p(Res))*(-1) + sum(p(Res)*EV(Res|dBJ))


            // BBO = (1-p(BJ))*(EV|no dBJ) + p(BJ)*((1-sum(p(Res))*(0) + sum(p(Res)*EV(Res|dBJ))
            // BBO = ENHC + p(BJ)*(1-sum(p(Res))*(1)
            // OBBO = (1-p(BJ))*(EV|no dBJ) + p(BJ)*((1-sum(p(Res))*(-1) + sum(p(Res)*EV(Res|dBJ))
            // OBBO = ENHC

            // Note that in all cases, when a player doubles and busts, the extra loss is autmoatically included
            // above during the EVCards calculations as a shortcut.

            // Compute SPL1
            // xx
            // 2*EV(x)
            if (BBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
            {
                EV = 2d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.Full] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVx[(int)BJCAGlobalsClass.Hands.Full] * bjadjprob);
                EV -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.Full] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.Full]) * bjadjprob;

                EV2 = 2d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.Full] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.Full] * bjadjprob);
                EV2 -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.Full] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.Full]) * bjadjprob;

                EV3 = 2d * cStrat.SplitStateEVs[paircard, upcard].BBOx[(int)BJCAGlobalsClass.Hands.Full];
                EV3 -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.Full] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.Full]) * bjadjprob;
            }
            else if (OBBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
            {
                EV = cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.Full] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.Full]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVx[(int)BJCAGlobalsClass.Hands.Full]) * bjadjprob;
                EV += cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.Full] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVx[(int)BJCAGlobalsClass.Hands.Full] * bjadjprob;

                EV2 = cStrat.SplitStateEVs[paircard, upcard].OBBOx[(int)BJCAGlobalsClass.Hands.Full];
                EV2 += cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.Full] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.Full] * bjadjprob;

                EV3 = cStrat.SplitStateEVs[paircard, upcard].OBBOx[(int)BJCAGlobalsClass.Hands.Full];
                EV3 += cStrat.SplitStateEVs[paircard, upcard].BBOx[(int)BJCAGlobalsClass.Hands.Full];
            }
            else if (AOBBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
            {
                EV = 2d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.Full] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.Full]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVx[(int)BJCAGlobalsClass.Hands.Full]) * bjadjprob);

                EV2 = 2d * cStrat.SplitStateEVs[paircard, upcard].OBBOx[(int)BJCAGlobalsClass.Hands.Full];
            }
            else
            {
                EV = 2d * cStrat.SplitStateEVs[paircard, upcard].EVx[(int)BJCAGlobalsClass.Hands.Full];
            }
            cStrat.SplitStateEVs[paircard, upcard].SPL[1] = EV;
            cStrat.SplitStateEVs[paircard, upcard].SPL2[1] = EV2;
            cStrat.SplitStateEVs[paircard, upcard].SPL3[1] = EV3;
            if (SPL == 1)
            {
                p1 = EV / 2d;
                p2 = EV / 2d;
            }

            // Compute SPL2
            if (SPL > 1)
            {
                // NN
                // 2*EV(N-N)
                // EV(N) + EV(N-N)
                if (BBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.Full] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.Full] * bjadjprob;
                    EV += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.N] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.N] * bjadjprob;
                    EV -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.Full] * cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.N]) * bjadjprob;

                    EV2 = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.Full] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.Full] * bjadjprob;
                    EV2 += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.N] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.N] * bjadjprob;
                    EV2 -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.Full] * cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.N]) * bjadjprob;

                    EV3 = cStrat.SplitStateEVs[paircard, upcard].BBON[(int)BJCAGlobalsClass.Hands.Full] + cStrat.SplitStateEVs[paircard, upcard].BBON[(int)BJCAGlobalsClass.Hands.N];
                    EV3 -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.Full] * cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.N]) * bjadjprob;
                }
                else if (OBBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.Full] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.Full]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.Full]) * bjadjprob;
                    EV += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.N] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.N] * bjadjprob;

                    EV2 = cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.Full];
                    EV2 += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.N] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.N] * bjadjprob;

                    EV3 = cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.Full];
                    EV3 += cStrat.SplitStateEVs[paircard, upcard].BBON[(int)BJCAGlobalsClass.Hands.N];
                }
                else if (AOBBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.Full] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.Full]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.Full]) * bjadjprob;
                    EV += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.N] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.N]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.N]) * bjadjprob;

                    EV2 = cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.Full];
                    EV2 += cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.N];
                }
                else
                {
                    EV = 2d * cStrat.SplitStateEVs[paircard, upcard].EVN[(int)BJCAGlobalsClass.Hands.N];
                    // ev2 = cStrat.SplitStateEVs(paircard, upcard).EVN(BJCAGlobalsClass.Hands.Full) + cStrat.SplitStateEVs(paircard, upcard).EVN(BJCAGlobalsClass.Hands.N)
                }
                prob = (1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.Full, paircard]) * (1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.N, paircard]);
                cStrat.SplitStateEVs[paircard, upcard].SPL[2] = prob * EV;
                cStrat.SplitStateEVs[paircard, upcard].SPL2[2] = prob * EV2;
                cStrat.SplitStateEVs[paircard, upcard].SPL3[2] = prob * EV3;
                if (SPL > 2)
                {
                    cStrat.SplitStateEVs[paircard, upcard].SPL[3] = prob * EV;
                    cStrat.SplitStateEVs[paircard, upcard].SPL2[3] = prob * EV2;
                    cStrat.SplitStateEVs[paircard, upcard].SPL3[3] = prob * EV3;
                }
                if (SPL == 2 | SPL == 3)
                {
                    p1 = prob * EV / 2d;
                    p2 = prob * EV / 2d;
                }

                // Pxxx
                // 3*EV(x-P)
                if (BBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = 3d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.P] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVx[(int)BJCAGlobalsClass.Hands.P] * bjadjprob);
                    EV -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.P] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.P] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.P]) * bjadjprob;

                    EV2 = 3d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.P] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.P] * bjadjprob);
                    EV2 -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.P] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.P] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.P]) * bjadjprob;

                    EV3 = 3d * cStrat.SplitStateEVs[paircard, upcard].BBOx[(int)BJCAGlobalsClass.Hands.P];
                    EV3 -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.P] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.P] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.P]) * bjadjprob;
                }
                else if (OBBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.P] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.P]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVx[(int)BJCAGlobalsClass.Hands.P]) * bjadjprob;
                    EV += 2d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.P] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVx[(int)BJCAGlobalsClass.Hands.P] * bjadjprob);

                    EV2 = cStrat.SplitStateEVs[paircard, upcard].OBBOx[(int)BJCAGlobalsClass.Hands.P];
                    EV2 += 2d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.P] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.P] * bjadjprob);

                    EV3 = cStrat.SplitStateEVs[paircard, upcard].OBBOx[(int)BJCAGlobalsClass.Hands.P];
                    EV3 += 2d * cStrat.SplitStateEVs[paircard, upcard].BBOx[(int)BJCAGlobalsClass.Hands.P];
                }
                else if (AOBBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = 3d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.P] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.P]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVx[(int)BJCAGlobalsClass.Hands.P]) * bjadjprob);

                    EV2 = 3d * cStrat.SplitStateEVs[paircard, upcard].OBBOx[(int)BJCAGlobalsClass.Hands.P];
                }
                else
                {
                    EV = 3d * cStrat.SplitStateEVs[paircard, upcard].EVx[(int)BJCAGlobalsClass.Hands.P];
                }
                prob = SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.Full, paircard];
                cStrat.SplitStateEVs[paircard, upcard].SPL[2] += prob * EV;
                cStrat.SplitStateEVs[paircard, upcard].SPL2[2] += prob * EV2;
                cStrat.SplitStateEVs[paircard, upcard].SPL3[2] += prob * EV3;
                if (SPL == 2)
                {
                    p1 += prob * EV * 2d / 3d;
                    p2 += prob * EV * 1d / 3d;
                }

                // NPxx
                // EV(N-P) + 2*EV(x-PN)
                // EV(N) + 2*EV(x-PN)
                if (BBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.Full] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.Full] * bjadjprob;
                    EV += 2d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PN] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVx[(int)BJCAGlobalsClass.Hands.PN] * bjadjprob);
                    EV -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.Full] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PN] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PN]) * bjadjprob;

                    EV2 = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.Full] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.Full] * bjadjprob;
                    EV2 += 2d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PN] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PN] * bjadjprob);
                    EV2 -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.Full] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PN] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PN]) * bjadjprob;

                    EV3 = cStrat.SplitStateEVs[paircard, upcard].BBON[(int)BJCAGlobalsClass.Hands.Full] + 2d * cStrat.SplitStateEVs[paircard, upcard].BBOx[(int)BJCAGlobalsClass.Hands.PN];
                    EV3 -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.Full] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PN] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PN]) * bjadjprob;
                }
                else if (OBBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.Full] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.Full]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.Full]) * bjadjprob;
                    EV += 2d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PN] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVx[(int)BJCAGlobalsClass.Hands.PN] * bjadjprob);

                    EV2 = cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.Full];
                    EV2 += 2d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PN] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PN] * bjadjprob);

                    EV3 = cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.Full];
                    EV3 += 2d * cStrat.SplitStateEVs[paircard, upcard].BBOx[(int)BJCAGlobalsClass.Hands.PN];
                }
                else if (AOBBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.Full] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.Full]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.Full]) * bjadjprob;
                    EV += 2d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PN] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PN]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVx[(int)BJCAGlobalsClass.Hands.PN]) * bjadjprob);

                    EV2 = cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.Full];
                    EV2 += 2d * cStrat.SplitStateEVs[paircard, upcard].OBBOx[(int)BJCAGlobalsClass.Hands.PN];
                }
                else
                {
                    EV = cStrat.SplitStateEVs[paircard, upcard].EVN[(int)BJCAGlobalsClass.Hands.P] + 2d * cStrat.SplitStateEVs[paircard, upcard].EVx[(int)BJCAGlobalsClass.Hands.PN];
                    // ev2 = cStrat.SplitStateEVs(paircard, upcard).EVN(BJCAGlobalsClass.Hands.Full) + 2 * cStrat.SplitStateEVs(paircard, upcard).EVx(BJCAGlobalsClass.Hands.PN)
                }
                prob = (1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.Full, paircard]) * SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.N, paircard];
                cStrat.SplitStateEVs[paircard, upcard].SPL[2] += prob * EV;
                cStrat.SplitStateEVs[paircard, upcard].SPL2[2] += prob * EV2;
                cStrat.SplitStateEVs[paircard, upcard].SPL3[2] += prob * EV3;
                if (SPL == 2)
                {
                    p1 += prob * cStrat.SplitStateEVs[paircard, upcard].EVN[(int)BJCAGlobalsClass.Hands.P];
                    p2 += prob * 2d * cStrat.SplitStateEVs[paircard, upcard].EVx[(int)BJCAGlobalsClass.Hands.PN];
                }
            }

            // Compute SPL3
            if (SPL > 2)
            {
                // NN Already taken care of above with SPL2
                // PNNN
                // 3*EV(N-PNN)
                // EV(N-P) + EV(N-PN) + EV(N-PNN)
                if (BBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.P] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.P] * bjadjprob;
                    EV += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PN] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.PN] * bjadjprob;
                    EV += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PNN] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.PNN] * bjadjprob;
                    EV -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.P] * cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PN] * cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PNN]) * bjadjprob;

                    EV2 = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.P] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.P] * bjadjprob;
                    EV2 += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PN] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PN] * bjadjprob;
                    EV2 += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PNN] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PNN] * bjadjprob;
                    EV2 -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.P] * cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PN] * cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PNN]) * bjadjprob;

                    EV3 = cStrat.SplitStateEVs[paircard, upcard].BBON[(int)BJCAGlobalsClass.Hands.P];
                    EV3 += cStrat.SplitStateEVs[paircard, upcard].BBON[(int)BJCAGlobalsClass.Hands.PN];
                    EV3 += cStrat.SplitStateEVs[paircard, upcard].BBON[(int)BJCAGlobalsClass.Hands.PNN];
                    EV3 -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.P] * cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PN] * cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PNN]) * bjadjprob;
                }
                else if (OBBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.P] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.P]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.P]) * bjadjprob;
                    EV += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PN] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.PN] * bjadjprob;
                    EV += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PNN] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.PNN] * bjadjprob;

                    EV2 = cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.P];
                    EV2 += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PN] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PN] * bjadjprob;
                    EV2 += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PNN] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PNN] * bjadjprob;

                    EV3 = cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.P];
                    EV3 += cStrat.SplitStateEVs[paircard, upcard].BBON[(int)BJCAGlobalsClass.Hands.PN];
                    EV3 += cStrat.SplitStateEVs[paircard, upcard].BBON[(int)BJCAGlobalsClass.Hands.PNN];
                }
                else if (AOBBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.P] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.P]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.P]) * bjadjprob;
                    EV += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PN] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PN]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.PN]) * bjadjprob;
                    EV += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PNN] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PNN]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.PNN]) * bjadjprob;

                    EV2 = cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.P];
                    EV2 += cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.PN];
                    EV2 += cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.PNN];
                }
                else
                {
                    EV = 3d * cStrat.SplitStateEVs[paircard, upcard].EVN[(int)BJCAGlobalsClass.Hands.PNN];
                    // ev2 = cStrat.SplitStateEVs(paircard, upcard).EVN(BJCAGlobalsClass.Hands.P) + cStrat.SplitStateEVs(paircard, upcard).EVN(BJCAGlobalsClass.Hands.PN) + cStrat.SplitStateEVs(paircard, upcard).EVN(BJCAGlobalsClass.Hands.PNN)
                }
                prob = SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.Full, paircard] * (1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.P, paircard]) * (1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.PN, paircard]) * (1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.PNN, paircard]);
                cStrat.SplitStateEVs[paircard, upcard].SPL[3] += prob * EV;
                cStrat.SplitStateEVs[paircard, upcard].SPL2[3] += prob * EV2;
                cStrat.SplitStateEVs[paircard, upcard].SPL3[3] += prob * EV3;
                // If spl > 3 Then cStrat.SplitStateEVs(paircard, upcard).SPL(4) = cStrat.SplitStateEVs(paircard, upcard).SPL(4) + prob * ev
                if (SPL == 3)
                {
                    p1 += prob * EV * 2d / 3d;
                    p2 += prob * EV * 1d / 3d;
                }

                // NPNN
                // 3*EV(N-PNN)
                // EV(N) + EV(N-PN) + EV(N-PNN)
                if (BBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.Full] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.Full] * bjadjprob;
                    EV += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PN] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.PN] * bjadjprob;
                    EV += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PNN] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.PNN] * bjadjprob;
                    EV -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.Full] * cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PN] * cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PNN]) * bjadjprob;

                    EV2 = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.Full] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.Full] * bjadjprob;
                    EV2 += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PN] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PN] * bjadjprob;
                    EV2 += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PNN] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PNN] * bjadjprob;
                    EV2 -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.Full] * cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PN] * cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PNN]) * bjadjprob;

                    EV3 = cStrat.SplitStateEVs[paircard, upcard].BBON[(int)BJCAGlobalsClass.Hands.Full];
                    EV3 += cStrat.SplitStateEVs[paircard, upcard].BBON[(int)BJCAGlobalsClass.Hands.PN];
                    EV3 += cStrat.SplitStateEVs[paircard, upcard].BBON[(int)BJCAGlobalsClass.Hands.PNN];
                    EV3 -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.Full] * cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PN] * cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PNN]) * bjadjprob;
                }
                else if (OBBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.Full] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.Full]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.Full]) * bjadjprob;
                    EV += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PN] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.PN] * bjadjprob;
                    EV += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PNN] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.PNN] * bjadjprob;

                    EV2 = cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.Full];
                    EV2 += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PN] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PN] * bjadjprob;
                    EV2 += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PNN] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PNN] * bjadjprob;

                    EV3 = cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.Full];
                    EV3 += cStrat.SplitStateEVs[paircard, upcard].BBON[(int)BJCAGlobalsClass.Hands.PN];
                    EV3 += cStrat.SplitStateEVs[paircard, upcard].BBON[(int)BJCAGlobalsClass.Hands.PNN];
                }
                else if (AOBBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.Full] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.Full]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.Full]) * bjadjprob;
                    EV += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PN] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PN]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.PN]) * bjadjprob;
                    EV += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PNN] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PNN]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.PNN]) * bjadjprob;

                    EV2 = cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.Full];
                    EV2 += cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.PN];
                    EV2 += cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.PNN];
                }
                else
                {
                    EV = 3d * cStrat.SplitStateEVs[paircard, upcard].EVN[(int)BJCAGlobalsClass.Hands.PNN];
                    // ev2 = cStrat.SplitStateEVs(paircard, upcard).EVN(BJCAGlobalsClass.Hands.Full) + cStrat.SplitStateEVs(paircard, upcard).EVN(BJCAGlobalsClass.Hands.PN) + cStrat.SplitStateEVs(paircard, upcard).EVN(BJCAGlobalsClass.Hands.PNN)
                }
                prob = (1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.Full, paircard]) * SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.N, paircard] * (1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.PN, paircard]) * (1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.PNN, paircard]);
                cStrat.SplitStateEVs[paircard, upcard].SPL[3] += prob * EV;
                cStrat.SplitStateEVs[paircard, upcard].SPL2[3] += prob * EV2;
                cStrat.SplitStateEVs[paircard, upcard].SPL3[3] += prob * EV3;
                if (SPL == 3)
                {
                    p1 += prob * EV * 1d / 3d;
                    p2 += prob * EV * 2d / 3d;
                }

                // PPxxxx
                // 4*EV(x-PP)
                if (BBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = 4d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PP] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVx[(int)BJCAGlobalsClass.Hands.PP] * bjadjprob);
                    EV -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PP] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PP] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PP] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PP]) * bjadjprob;

                    EV2 = 4d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PP] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PP] * bjadjprob);
                    EV2 -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PP] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PP] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PP] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PP]) * bjadjprob;

                    EV3 = 4d * cStrat.SplitStateEVs[paircard, upcard].BBOx[(int)BJCAGlobalsClass.Hands.PP];
                    EV3 -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PP] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PP] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PP] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PP]) * bjadjprob;
                }
                else if (OBBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PP] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PP]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVx[(int)BJCAGlobalsClass.Hands.PP]) * bjadjprob;
                    EV += 3d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PP] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVx[(int)BJCAGlobalsClass.Hands.PP] * bjadjprob);

                    EV2 = cStrat.SplitStateEVs[paircard, upcard].OBBOx[(int)BJCAGlobalsClass.Hands.PP];
                    EV2 += 3d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PP] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PP] * bjadjprob);

                    EV3 = cStrat.SplitStateEVs[paircard, upcard].OBBOx[(int)BJCAGlobalsClass.Hands.PP];
                    EV3 = EV + 3d * cStrat.SplitStateEVs[paircard, upcard].BBOx[(int)BJCAGlobalsClass.Hands.PP];
                }
                else if (AOBBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = 4d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PP] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PP]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVx[(int)BJCAGlobalsClass.Hands.PP]) * bjadjprob);

                    EV2 = 4d * cStrat.SplitStateEVs[paircard, upcard].OBBOx[(int)BJCAGlobalsClass.Hands.PP];
                }
                else
                {
                    EV = 4d * cStrat.SplitStateEVs[paircard, upcard].EVx[(int)BJCAGlobalsClass.Hands.PP];
                }
                prob = SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.Full, paircard] * SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.P, paircard];
                cStrat.SplitStateEVs[paircard, upcard].SPL[3] += prob * EV;
                cStrat.SplitStateEVs[paircard, upcard].SPL2[3] += prob * EV2;
                cStrat.SplitStateEVs[paircard, upcard].SPL3[3] += prob * EV3;
                if (SPL == 3)
                {
                    p1 += prob * EV * 3d / 4d;
                    p2 += prob * EV * 1d / 4d;
                }

                // PNPxxx
                // EV(N-PP) + 3*EV(x-PPN)
                // EV(N-P) + 3*EV(x-PPN)
                if (BBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.P] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.P] * bjadjprob;
                    EV += 3d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PPN] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVx[(int)BJCAGlobalsClass.Hands.PPN] * bjadjprob);
                    EV -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.P] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPN] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPN] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPN]) * bjadjprob;

                    EV2 = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.P] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.P] * bjadjprob;
                    EV2 += 3d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PPN] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPN] * bjadjprob);
                    EV2 -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.P] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPN] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPN] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPN]) * bjadjprob;

                    EV3 = cStrat.SplitStateEVs[paircard, upcard].BBON[(int)BJCAGlobalsClass.Hands.P] + 3d * cStrat.SplitStateEVs[paircard, upcard].BBOx[(int)BJCAGlobalsClass.Hands.PPN];
                    EV3 -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.P] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPN] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPN] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPN]) * bjadjprob;
                }
                else if (OBBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.P] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.P]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.P]) * bjadjprob;
                    EV += 3d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PPN] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVx[(int)BJCAGlobalsClass.Hands.PPN] * bjadjprob);

                    EV2 = cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.P];
                    EV2 += 3d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PPN] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPN] * bjadjprob);

                    EV3 = cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.P];
                    EV3 += 3d * cStrat.SplitStateEVs[paircard, upcard].BBOx[(int)BJCAGlobalsClass.Hands.PPN];
                }
                else if (AOBBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.P] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.P]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.P]) * bjadjprob;
                    EV += 3d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PPN] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPN]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVx[(int)BJCAGlobalsClass.Hands.PPN]) * bjadjprob);

                    EV2 = cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.P];
                    EV2 += 3d * cStrat.SplitStateEVs[paircard, upcard].OBBOx[(int)BJCAGlobalsClass.Hands.PPN];
                }
                else
                {
                    EV = cStrat.SplitStateEVs[paircard, upcard].EVN[(int)BJCAGlobalsClass.Hands.PP] + 3d * cStrat.SplitStateEVs[paircard, upcard].EVx[(int)BJCAGlobalsClass.Hands.PPN];
                    // ev2 = cStrat.SplitStateEVs(paircard, upcard).EVN(BJCAGlobalsClass.Hands.P) + 3 * cStrat.SplitStateEVs(paircard, upcard).EVx(BJCAGlobalsClass.Hands.PPN)
                }
                prob = SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.Full, paircard] * (1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.P, paircard]) * SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.PN, paircard];
                cStrat.SplitStateEVs[paircard, upcard].SPL[3] += prob * EV;
                cStrat.SplitStateEVs[paircard, upcard].SPL2[3] += prob * EV2;
                cStrat.SplitStateEVs[paircard, upcard].SPL3[3] += prob * EV3;
                if (SPL == 3)
                {
                    p1 += prob * (cStrat.SplitStateEVs[paircard, upcard].EVN[(int)BJCAGlobalsClass.Hands.PP] + cStrat.SplitStateEVs[paircard, upcard].EVx[(int)BJCAGlobalsClass.Hands.PPN]);
                    p2 += prob * 2d * cStrat.SplitStateEVs[paircard, upcard].EVx[(int)BJCAGlobalsClass.Hands.PPN];
                }

                // NPPxxx
                // EV(N-PP) + 3*EV(x-PPN)
                // EV(N) + 3*EV(x-PPN)
                if (BBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.Full] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.Full] * bjadjprob;
                    EV += 3d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PPN] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVx[(int)BJCAGlobalsClass.Hands.PPN] * bjadjprob);
                    EV -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.Full] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPN] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPN] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPN]) * bjadjprob;

                    EV2 = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.Full] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.Full] * bjadjprob;
                    EV2 += 3d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PPN] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPN] * bjadjprob);
                    EV2 -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.Full] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPN] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPN] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPN]) * bjadjprob;

                    EV3 = cStrat.SplitStateEVs[paircard, upcard].BBON[(int)BJCAGlobalsClass.Hands.Full] + 3d * cStrat.SplitStateEVs[paircard, upcard].BBOx[(int)BJCAGlobalsClass.Hands.PPN];
                    EV3 -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.Full] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPN] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPN] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPN]) * bjadjprob;
                }
                else if (OBBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.Full] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.Full]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.Full]) * bjadjprob;
                    EV += 3d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PPN] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVx[(int)BJCAGlobalsClass.Hands.PPN] * bjadjprob);

                    EV2 = cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.Full];
                    EV2 += 3d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PPN] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPN] * bjadjprob);

                    EV3 = cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.Full];
                    EV3 += 3d * cStrat.SplitStateEVs[paircard, upcard].BBOx[(int)BJCAGlobalsClass.Hands.PPN];
                }
                else if (AOBBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.Full] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.Full]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.Full]) * bjadjprob;
                    EV += 3d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PPN] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPN]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVx[(int)BJCAGlobalsClass.Hands.PPN]) * bjadjprob);

                    EV2 = cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.Full];
                    EV2 += 3d * cStrat.SplitStateEVs[paircard, upcard].OBBOx[(int)BJCAGlobalsClass.Hands.PPN];
                }
                else
                {
                    EV = cStrat.SplitStateEVs[paircard, upcard].EVN[(int)BJCAGlobalsClass.Hands.PP] + 3d * cStrat.SplitStateEVs[paircard, upcard].EVx[(int)BJCAGlobalsClass.Hands.PPN];
                    // ev2 = cStrat.SplitStateEVs(paircard, upcard).EVN(BJCAGlobalsClass.Hands.Full) + 3 * cStrat.SplitStateEVs(paircard, upcard).EVx(BJCAGlobalsClass.Hands.PPN)
                }
                prob = (1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.Full, paircard]) * SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.N, paircard] * SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.PN, paircard];
                cStrat.SplitStateEVs[paircard, upcard].SPL[3] += prob * EV;
                cStrat.SplitStateEVs[paircard, upcard].SPL2[3] += prob * EV2;
                cStrat.SplitStateEVs[paircard, upcard].SPL3[3] += prob * EV3;
                if (SPL == 3)
                {
                    p1 += prob * cStrat.SplitStateEVs[paircard, upcard].EVN[(int)BJCAGlobalsClass.Hands.PP];
                    p2 += prob * 3d * cStrat.SplitStateEVs[paircard, upcard].EVx[(int)BJCAGlobalsClass.Hands.PPN];
                }

                // PNNPxx
                // 2*EV(N-PPN) + 2*EV(x-PPNN)
                // EV(N-P) + EV(N-PN) + 2*EV(x-PPNN)
                if (BBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.P] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.P] * bjadjprob;
                    EV += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PN] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.PN] * bjadjprob;
                    EV += 2d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PPNN] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVx[(int)BJCAGlobalsClass.Hands.PPNN] * bjadjprob);
                    EV -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.P] * cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PN] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPNN] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPNN]) * bjadjprob;

                    EV2 = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.P] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.P] * bjadjprob;
                    EV2 += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PN] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PN] * bjadjprob;
                    EV2 += 2d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PPNN] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPNN] * bjadjprob);
                    EV2 -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.P] * cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PN] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPNN] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPNN]) * bjadjprob;

                    EV3 = cStrat.SplitStateEVs[paircard, upcard].BBON[(int)BJCAGlobalsClass.Hands.P];
                    EV3 += cStrat.SplitStateEVs[paircard, upcard].BBON[(int)BJCAGlobalsClass.Hands.PN];
                    EV3 += 2d * cStrat.SplitStateEVs[paircard, upcard].BBOx[(int)BJCAGlobalsClass.Hands.PPNN];
                    EV3 -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.P] * cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PN] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPNN] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPNN]) * bjadjprob;
                }
                else if (OBBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.P] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.P]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.P]) * bjadjprob;
                    EV += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PN] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.PN] * bjadjprob;
                    EV += 2d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PPNN] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVx[(int)BJCAGlobalsClass.Hands.PPNN] * bjadjprob);

                    EV2 = cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.P];
                    EV2 += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PN] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PN] * bjadjprob;
                    EV2 += 2d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PPNN] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPNN] * bjadjprob);

                    EV3 = cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.P];
                    EV3 += cStrat.SplitStateEVs[paircard, upcard].BBON[(int)BJCAGlobalsClass.Hands.PN];
                    EV3 += 2d * cStrat.SplitStateEVs[paircard, upcard].BBOx[(int)BJCAGlobalsClass.Hands.PPNN];
                }
                else if (AOBBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.P] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.P]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.P]) * bjadjprob;
                    EV = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PN] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PN]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.PN]) * bjadjprob;
                    EV += 2d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PPNN] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPNN]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVx[(int)BJCAGlobalsClass.Hands.PPNN]) * bjadjprob);

                    EV2 = cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.P];
                    EV2 += cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.PN];
                    EV2 += 2d * cStrat.SplitStateEVs[paircard, upcard].OBBOx[(int)BJCAGlobalsClass.Hands.PPNN];
                }
                else
                {
                    EV = 2d * cStrat.SplitStateEVs[paircard, upcard].EVN[(int)BJCAGlobalsClass.Hands.PPN] + 2d * cStrat.SplitStateEVs[paircard, upcard].EVx[(int)BJCAGlobalsClass.Hands.PPNN];
                    // ev2 = cStrat.SplitStateEVs(paircard, upcard).EVN(BJCAGlobalsClass.Hands.P) + cStrat.SplitStateEVs(paircard, upcard).EVN(BJCAGlobalsClass.Hands.PN) + 2 * cStrat.SplitStateEVs(paircard, upcard).EVx(BJCAGlobalsClass.Hands.PPNN)
                }
                prob = SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.Full, paircard] * (1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.P, paircard]) * (1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.PN, paircard]) * SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.PNN, paircard];
                cStrat.SplitStateEVs[paircard, upcard].SPL[3] += prob * EV;
                cStrat.SplitStateEVs[paircard, upcard].SPL2[3] += prob * EV2;
                cStrat.SplitStateEVs[paircard, upcard].SPL3[3] += prob * EV3;
                if (SPL == 3)
                {
                    p1 += prob * (cStrat.SplitStateEVs[paircard, upcard].EVN[(int)BJCAGlobalsClass.Hands.PPN] + 2d * cStrat.SplitStateEVs[paircard, upcard].EVx[(int)BJCAGlobalsClass.Hands.PPNN]);
                    p2 += prob * cStrat.SplitStateEVs[paircard, upcard].EVN[(int)BJCAGlobalsClass.Hands.PPN];
                }

                // NPNPxx
                // 2*EV(N-PPN) + 2*EV(x-PPNN)
                // EV(N) + EV(N-PN) + 2*EV(x-PPNN)
                if (BBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.Full] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.Full] * bjadjprob;
                    EV += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PN] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.PN] * bjadjprob;
                    EV += 2d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PPNN] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVx[(int)BJCAGlobalsClass.Hands.PPNN] * bjadjprob);
                    EV -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.P] * cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PN] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPNN] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPNN]) * bjadjprob;

                    EV2 = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.Full] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.Full] * bjadjprob;
                    EV2 += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PN] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PN] * bjadjprob;
                    EV2 += 2d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PPNN] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPNN] * bjadjprob);
                    EV2 -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.Full] * cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PN] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPNN] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPNN]) * bjadjprob;

                    EV3 = cStrat.SplitStateEVs[paircard, upcard].BBON[(int)BJCAGlobalsClass.Hands.Full];
                    EV3 += cStrat.SplitStateEVs[paircard, upcard].BBON[(int)BJCAGlobalsClass.Hands.PN];
                    EV3 += 2d * cStrat.SplitStateEVs[paircard, upcard].BBOx[(int)BJCAGlobalsClass.Hands.PPNN];
                    EV3 -= (1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.Full] * cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PN] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPNN] * cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPNN]) * bjadjprob;
                }
                else if (OBBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.Full] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.Full]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.Full]) * bjadjprob;
                    EV += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PN] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.PN] * bjadjprob;
                    EV += 2d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PPNN] * (1d - bjadjprob) + cStrat.SplitStateEVs[paircard, upcard].PResEVx[(int)BJCAGlobalsClass.Hands.PPNN] * bjadjprob);

                    EV2 = cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.Full];
                    EV2 += cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PN] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PN] * bjadjprob;
                    EV2 += 2d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PPNN] * (1d - bjadjprob) - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPNN] * bjadjprob);

                    EV3 = cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.Full];
                    EV3 += cStrat.SplitStateEVs[paircard, upcard].BBON[(int)BJCAGlobalsClass.Hands.PN];
                    EV3 += 2d * cStrat.SplitStateEVs[paircard, upcard].BBOx[(int)BJCAGlobalsClass.Hands.PPNN];
                }
                else if (AOBBO & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                {
                    EV = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.Full] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.Full]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.Full]) * bjadjprob;
                    EV = cStrat.SplitStateEVs[paircard, upcard].CEVN[(int)BJCAGlobalsClass.Hands.PN] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResN[(int)BJCAGlobalsClass.Hands.PN]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVN[(int)BJCAGlobalsClass.Hands.PN]) * bjadjprob;
                    EV += 2d * (cStrat.SplitStateEVs[paircard, upcard].CEVx[(int)BJCAGlobalsClass.Hands.PPNN] * (1d - bjadjprob) + ((1d - cStrat.SplitStateEVs[paircard, upcard].PResx[(int)BJCAGlobalsClass.Hands.PPNN]) * -1 + cStrat.SplitStateEVs[paircard, upcard].PResEVx[(int)BJCAGlobalsClass.Hands.PPNN]) * bjadjprob);

                    EV2 = cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.Full];
                    EV2 += cStrat.SplitStateEVs[paircard, upcard].OBBON[(int)BJCAGlobalsClass.Hands.PN];
                    EV2 += 2d * cStrat.SplitStateEVs[paircard, upcard].OBBOx[(int)BJCAGlobalsClass.Hands.PPNN];
                }
                else
                {
                    EV = 2d * cStrat.SplitStateEVs[paircard, upcard].EVN[(int)BJCAGlobalsClass.Hands.PPN] + 2d * cStrat.SplitStateEVs[paircard, upcard].EVx[(int)BJCAGlobalsClass.Hands.PPNN];
                    // ev2 = cStrat.SplitStateEVs(paircard, upcard).EVN(BJCAGlobalsClass.Hands.Full) + cStrat.SplitStateEVs(paircard, upcard).EVN(BJCAGlobalsClass.Hands.PN) + 2 * cStrat.SplitStateEVs(paircard, upcard).EVx(BJCAGlobalsClass.Hands.PPNN)
                }
                prob = (1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.Full, paircard]) * SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.N, paircard] * (1d - SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.PN, paircard]) * SplitProbs[paircard, upcard].PxCards[(int)BJCAGlobalsClass.Hands.PNN, paircard];
                cStrat.SplitStateEVs[paircard, upcard].SPL[3] += prob * EV;
                cStrat.SplitStateEVs[paircard, upcard].SPL2[3] += prob * EV2;
                cStrat.SplitStateEVs[paircard, upcard].SPL3[3] += prob * EV3;
                if (SPL == 3)
                {
                    p1 += prob * cStrat.SplitStateEVs[paircard, upcard].EVN[(int)BJCAGlobalsClass.Hands.PPN];
                    p2 += prob * (cStrat.SplitStateEVs[paircard, upcard].EVN[(int)BJCAGlobalsClass.Hands.PPN] + 2d * cStrat.SplitStateEVs[paircard, upcard].EVx[(int)BJCAGlobalsClass.Hands.PPNN]);
                }

            }

            // If (p2 - p1) > 0.00000001 Then
            // MsgBox("Paircard: " + CStr(paircard) + "  Upcard: " + CStr(upcard))
            // End If


        }

        private void ComputeSplit(ref BJCAStrategyClass cStrat, int paircard, int upcard)
        {
            int index;
            int i;

            index = SplitIndex[paircard, upcard];
            if (index > 0)
            {
                CurrentShoe.Deal(paircard);  // Remove the extra pair card from the shoe
                DealPCard(paircard);
                CurrentShoe.Deal(upcard);    // Remove the upcard from the shoe

                // Reset the SplitHand values
                cStrat.SplitStateEVs[paircard, upcard].Empty();
                ComputeSplitHandsEV(ref cStrat, paircard, upcard);
                ComputeSplitEVs(ref cStrat, paircard, upcard);

                // Copy the split EVs into the hand EVs from the split state EVs
                if (paircard == 1 & !SMA)
                {
                    cStrat.HandEVs[index].SplitEV[upcard] = cStrat.SplitStateEVs[paircard, upcard].SPL[1];
                }
                else
                {
                    cStrat.HandEVs[index].SplitEV[upcard] = cStrat.SplitStateEVs[paircard, upcard].SPL[SPL];
                }
                var loopTo = SPL;
                for (i = 1; i <= loopTo; i++)
                    cStrat.HandEVs[index].SPLEV[upcard, i] = cStrat.SplitStateEVs[paircard, upcard].SPL[i];

                CurrentShoe.Undeal(upcard);
                UndealPCard(paircard);
                CurrentShoe.Undeal(paircard);
            }
        }

        private BJCAHandEVsClass ComputeSplitDoubleCardEV(int index, int upcard, int depth)
        {
            int strat;
            int card;
            double prob;
            double EV;
            double push;
            int newIndex;
            var tempEVs = new BJCAHandEVsClass();
            var newEVs = new BJCAHandEVsClass();

            // This function is only needed for RDA and DDR post-split
            // The CurrentShoe hand has the hand needed to calculate the necessary EVs.

            // The RDA and DDR Strategy will be the same as the PreSplit strategy so we only need to calculate the relevant EV
            strat = PlayerHands[index].HandEVs.DStrat[upcard];
            if (strat == (int)BJCAGlobalsClass.Strat.D & (!RDAPS | depth > RDDepth))
            {
                strat = (int)BJCAGlobalsClass.Strat.S;
            }
            if (strat == (int)BJCAGlobalsClass.Strat.R & !DDRPS)
            {
                strat = (int)BJCAGlobalsClass.Strat.S;
            }

            switch (strat)
            {
                case (int)BJCAGlobalsClass.Strat.D:
                    {
                        EV = 0d;
                        push = 0d;
                        for (card = 1; card <= 10; card++)
                        {
                            prob = CardProb(card, 0);
                            if (prob > 0d)
                            {
                                newIndex = PlayerHands[index].HitHand[card];
                                if (newIndex > 0)
                                {
                                    DealPCard(card);
                                    tempEVs = ComputeSplitDoubleCardEV(newIndex, upcard, depth + 1);
                                    EV = tempEVs.DStratEV[upcard];
                                    push = tempEVs.DStratPushEV[upcard];
                                    UndealPCard(card);
                                }
                                else
                                {
                                    EV = -1;
                                    push = 0d;
                                }
                            }
                            newEVs.DStratEV[upcard] += 2d * EV * prob;
                            newEVs.DStratPushEV[upcard] += 2d * push * prob;
                        }

                        break;
                    }
                case (int)BJCAGlobalsClass.Strat.R:
                    {
                        tempEVs.Empty();
                        tempEVs = ComputeSurrenderHand(CurrentShoe.Hand, DDRType, upcard);
                        newEVs.DStratEV[upcard] = tempEVs.SurrEV[upcard];
                        newEVs.DStratPushEV[upcard] = 0d;
                        if ((BBO | OBBO | AOBBO) & DDRType == (int)BJCAGlobalsClass.Surr.ES & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                        {
                            // Let the calling function know the hand was resolved before the BJ check
                            newEVs.BJStandEV[upcard] = 1d;
                        }   // Stand

                        break;
                    }

                default:
                    {
                        CurrentShoe.Undeal(upcard);
                        CurrentShoe.Hand.Total = CurrentPHand.Total;
                        tempEVs = ComputeStandHand(CurrentShoe.Hand, upcard, upcard, false);
                        newEVs.DStratEV[upcard] = tempEVs.StandEV[upcard];
                        newEVs.DStratPushEV[upcard] = tempEVs.StandPushEV[upcard];
                        CurrentShoe.Deal(upcard);
                        if ((BBO | OBBO | AOBBO) & PlayerHands[index].Hand.Total == 21 & P21AutoWin & (upcard == 1 & !CheckAce | upcard == 10 & !CheckTen))
                        {
                            // Let the calling function know the hand was resolved before the BJ check
                            newEVs.BJStandEV[upcard] = 1d;
                        }

                        break;
                    }
            }

            return newEVs;
        }

        #endregion

        #endregion

        #region  Strategy Methods 

        #region  General Strategy Methods 

        public void ComputeStrategy(ref BJCAStrategyClass cStrat)
        {
            int upcard;

            if (cStrat.ComputeStrat)
            {
                for (upcard = 1; upcard <= 10; upcard++)
                {
                    if (UCAllowed[upcard] & CardProb(upcard, 0) > 0d)
                    {
                        ComputeStrategyMaxEVMinus(ref cStrat, upcard);
                    }
                }
            }
        }

        private void ResetStrategyEVs(ref BJCAStrategyClass cStrat)
        {
            int index;
            int upcard;
            int i;


        }

        private void ComputeStrategies()
        {
            int upcard;

            // First figure out which hands are used in CD play
            for (upcard = 1; upcard <= 10; upcard++)
            {
                if (UCAllowed[upcard] & CardProb(upcard, 0) > 0d)
                {

                    DealDCard(upcard);
                    GetHandsUsed(ref Opt, upcard, 1, true, true);
                    UndealDCard(upcard);

                }
            }

            if (TD.ComputeStrat)
                ComputeStrategy(ref TD);
            if (TC.ComputeStrat)
                ComputeStrategy(ref TC);
            if (Forced.ComputeStrat)
                ComputeStrategy(ref Forced);
        }

        private void HandsUsed(ref BJCAStrategyClass cStrat, int upcard, int index, int stratIndex)
        {
            // Will play out the player's hands based on the Total Dependent strategy and increase the HandUsed index by 1
            // stratindex is used to avoid an endless loop if a hand was not played for 1 round and then played again.
            int card;
            int newIndex;
            int strat;

            for (card = 1; card <= 10; card++)
            {
                newIndex = PlayerHands[index].HitHand[card];
                if (CardProb(card, 0) > 0d & newIndex != 0)
                {
                    DealPCard(card);
                    // Check to see if hand has been used before - if so then increases multiplier.
                    // Otherwise it resets multiplier and the stratindex.
                    if (cStrat.HandEVs[newIndex].HandUsed[upcard] != -1)
                    {
                        if (cStrat.HandEVs[newIndex].HandUsed[upcard] == stratIndex)
                        {
                            cStrat.HandEVs[newIndex].Multiplier[upcard] += 1;
                        }
                        else
                        {
                            cStrat.HandEVs[newIndex].HandUsed[upcard] = stratIndex;
                            cStrat.HandEVs[newIndex].Multiplier[upcard] = 1;
                        }
                    }
                    strat = cStrat.HandEVs[newIndex].EVs.Strat[upcard];
                    // As in the original, "~RPreallowed" is non-zero for every surrender type (0-2), so any R
                    // hand is played on as a hit; probably meant to be "surrender not allowed".
                    if (strat == (int)BJCAGlobalsClass.Strat.H | strat == (int)BJCAGlobalsClass.Strat.P | strat == (int)BJCAGlobalsClass.Strat.PH | strat == (int)BJCAGlobalsClass.Strat.D & !cStrat.HandEVs[newIndex].DPreallowed[upcard] | strat == (int)BJCAGlobalsClass.Strat.R & ~cStrat.HandEVs[newIndex].RPreallowed[upcard] != 0)
                    {
                        HandsUsed(ref cStrat, upcard, newIndex, stratIndex);
                    }
                    UndealPCard(card);
                }
            }

        }

        private void GetHandsUsed(ref BJCAStrategyClass cStrat, int upcard, int stratIndex, bool resetHandsUsed, bool includeAll = false)
        {
            int card;
            int index;

            if (resetHandsUsed)
            {
                // Remove any non-strategy determining hands from consideration
                var loopTo = NumPHands;
                for (index = 1; index <= loopTo; index++)
                {
                    if (PlayerHands[index].Hand.NumCards < 2)
                    {
                        cStrat.HandEVs[index].HandUsed[upcard] = -1;
                    }
                    else if (!includeAll & (cStrat.HandEVs[index].PreForced[upcard] | PlayerHands[index].Hand.NumCards <= cStrat.NCardsCD))
                    {
                        cStrat.HandEVs[index].HandUsed[upcard] = -1;
                    }
                    else
                    {
                        cStrat.HandEVs[index].HandUsed[upcard] = 0;
                        cStrat.HandEVs[index].Multiplier[upcard] = 0;
                    }
                }

                // See if Split is the Strategy - these are done separately because there is only one kind of each pair possible
                for (card = 1; card <= 10; card++)
                {
                    if (SplitIndex[card, upcard] > 0)
                    {
                        index = SplitIndex[card, upcard];
                        if (!includeAll & (cStrat.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.P | cStrat.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.PS | cStrat.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.PD | cStrat.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.PR | cStrat.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.PH))
                        {
                            cStrat.HandEVs[index].HandUsed[upcard] = -1;
                        }
                    }
                }
            }

            for (card = 1; card <= 10; card++)
            {
                if (CardProb(card, 0) > 0d)
                {
                    DealPCard(card);
                    HandsUsed(ref cStrat, upcard, PlayerHands[0].HitHand[card], stratIndex);
                    UndealPCard(card);
                }
            }

        }

        private void ComputeStratHit(ref BJCAStrategyClass cStrat, int upcard)
        {
            // useTD is true for TD and false for TC
            int Total;

            for (Total = 21; Total >= 11; Total -= 1)
                ComputeStratHitTotal(ref cStrat, Total, false, upcard);
            for (Total = 21; Total >= 12; Total -= 1)
                ComputeStratHitTotal(ref cStrat, Total, true, upcard);
            for (Total = 10; Total >= 4; Total -= 1)
                ComputeStratHitTotal(ref cStrat, Total, false, upcard);

        }

        private void ComputeStratHitTotal(ref BJCAStrategyClass cStrat, int Total, bool Soft, int upcard)
        {
            int index;
            int card;
            double prob;
            int Strat;
            int newStrat;

            index = PlayerHandTotal[Total, Conversions.ToInteger(Soft) + 1];
            while (index != 0)
            {
                cStrat.HandEVs[index].EVs.HitEV[upcard] = 0d;
                cStrat.HandEVs[index].EVs.HitPushEV[upcard] = 0d;
                if (PlayerHands[index].Hand.NumCards > 1 & HandPossible(PlayerHands[index].Hand))
                {
                    CurrentShoe.Deal(PlayerHands[index].Hand);
                    for (card = 1; card <= 10; card++)
                    {
                        prob = CardProb(card, upcard);
                        if (prob > 0d)
                        {
                            if (PlayerHands[index].HitHand[card] > 0)
                            {
                                cStrat.HandEVs[index].EVs.HitEV[upcard] = cStrat.HandEVs[index].EVs.HitEV[upcard] + prob * (cStrat.HandEVs[PlayerHands[index].HitHand[card]].EVs.StratEV[upcard] + PlayerHands[PlayerHands[index].HitHand[card]].HandEVs.BonusEV[upcard]);
                                cStrat.HandEVs[index].EVs.HitPushEV[upcard] = cStrat.HandEVs[index].EVs.HitPushEV[upcard] + prob * cStrat.HandEVs[PlayerHands[index].HitHand[card]].EVs.StratPushEV[upcard];
                            }
                            else
                            {
                                cStrat.HandEVs[index].EVs.HitEV[upcard] = cStrat.HandEVs[index].EVs.HitEV[upcard] - prob;
                            }
                        }
                    }


                    // Update strat ev
                    if (cStrat.HandEVs[index].PreForced[upcard])
                    {
                        Strat = cStrat.HandEVs[index].EVs.Strat[upcard];
                    }
                    else if (cStrat.NCardsCD != 0 & PlayerHands[index].Hand.NumCards <= cStrat.NCardsCD)
                    {
                        Strat = cStrat.HandEVs[index].EVs.Strat[upcard];
                    }
                    else
                    {
                        Strat = cStrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].Strat[upcard];
                    }
                    if (Strat == (int)BJCAGlobalsClass.Strat.DS & !cStrat.HandEVs[index].DPreallowed[upcard] | Strat == (int)BJCAGlobalsClass.Strat.RS & !(cStrat.HandEVs[index].RPreallowed[upcard] > 0))
                    {
                        newStrat = (int)BJCAGlobalsClass.Strat.S;
                    }
                    else if (Strat == (int)BJCAGlobalsClass.Strat.D & !cStrat.HandEVs[index].DPreallowed[upcard] | Strat == (int)BJCAGlobalsClass.Strat.R & !(cStrat.HandEVs[index].RPreallowed[upcard] > 0))
                    {
                        newStrat = (int)BJCAGlobalsClass.Strat.H;
                    }
                    else
                    {
                        newStrat = Strat;
                    }

                    switch (newStrat)
                    {
                        case (int)BJCAGlobalsClass.Strat.S:
                            {
                                cStrat.HandEVs[index].EVs.StratEV[upcard] = PlayerHands[index].HandEVs.StandEV[upcard];
                                cStrat.HandEVs[index].EVs.StratPushEV[upcard] = PlayerHands[index].HandEVs.StandPushEV[upcard];
                                break;
                            }
                        case (int)BJCAGlobalsClass.Strat.D:
                        case (int)BJCAGlobalsClass.Strat.DS:
                            {
                                cStrat.HandEVs[index].EVs.StratEV[upcard] = PlayerHands[index].HandEVs.DEV[upcard];
                                cStrat.HandEVs[index].EVs.StratPushEV[upcard] = PlayerHands[index].HandEVs.DPushEV[upcard];
                                break;
                            }
                        case (int)BJCAGlobalsClass.Strat.H:
                            {
                                cStrat.HandEVs[index].EVs.StratEV[upcard] = cStrat.HandEVs[index].EVs.HitEV[upcard];
                                cStrat.HandEVs[index].EVs.StratPushEV[upcard] = cStrat.HandEVs[index].EVs.HitPushEV[upcard];
                                break;
                            }
                        case (int)BJCAGlobalsClass.Strat.R:
                        case (int)BJCAGlobalsClass.Strat.RS:
                            {
                                cStrat.HandEVs[index].EVs.StratEV[upcard] = PlayerHands[index].HandEVs.SurrEV[upcard];
                                cStrat.HandEVs[index].EVs.StratPushEV[upcard] = 0d;
                                break;
                            }
                    }

                    CurrentShoe.Undeal(PlayerHands[index].Hand);
                }
                index = PlayerHands[index].NextHand;
            }
        }

        private BJCAHandStrategyEVsClass GetStratMaxEVHand(int index, int upcard, ref BJCAStrategyClass toStrat, ref BJCAStrategyClass fromStrat, bool pre = true, bool includeSplits = false)
        {
            var newEvs = new BJCAHandStrategyEVsClass();
            int card;

            if (pre & !toStrat.HandEVs[index].PreForced[upcard])
            {
                if (toStrat.HandEVs[index].SPreallowed[upcard])
                {
                    newEvs.StratEV[upcard] = PlayerHands[index].HandEVs.StandEV[upcard];
                    newEvs.StratPushEV[upcard] = PlayerHands[index].HandEVs.StandPushEV[upcard];
                    newEvs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.S;
                }
                if (toStrat.HandEVs[index].DPreallowed[upcard])
                {
                    if (PlayerHands[index].HandEVs.DEV[upcard] > newEvs.StratEV[upcard])
                    {
                        newEvs.StratEV[upcard] = PlayerHands[index].HandEVs.DEV[upcard];
                        newEvs.StratPushEV[upcard] = PlayerHands[index].HandEVs.DPushEV[upcard];
                        newEvs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.D;
                    }
                }
                if (Conversions.ToBoolean(toStrat.HandEVs[index].RPreallowed[upcard]))
                {
                    if (PlayerHands[index].HandEVs.SurrEV[upcard] > newEvs.StratEV[upcard])
                    {
                        newEvs.StratEV[upcard] = PlayerHands[index].HandEVs.SurrEV[upcard];
                        newEvs.StratPushEV[upcard] = 0d;
                        newEvs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.R;
                    }
                }
                if (toStrat.HandEVs[index].HPreallowed[upcard])
                {
                    if (fromStrat.HandEVs[index].EVs.HitEV[upcard] > newEvs.StratEV[upcard])
                    {
                        newEvs.StratEV[upcard] = fromStrat.HandEVs[index].EVs.HitEV[upcard];
                        newEvs.StratPushEV[upcard] = fromStrat.HandEVs[index].EVs.HitPushEV[upcard];
                        newEvs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.H;
                    }
                }
                if (includeSplits & toStrat.HandEVs[index].PAllowed[upcard])
                {
                    for (card = 1; card <= 10; card++)
                    {
                        if (PlayerHands[index].Hand.Cards[card] == 2)
                            break;
                    }
                    // Make sure the split is allowed for the game not just the hand
                    if (SplitIndex[card, upcard] > 0)
                    {
                        if (fromStrat.HandEVs[index].SplitEV[upcard] > newEvs.StratEV[upcard])
                        {
                            newEvs.StratEV[upcard] = fromStrat.HandEVs[index].SplitEV[upcard];
                            if (toStrat.NCardsCD == 0)
                            {
                                newEvs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.P;
                            }
                            else
                            {
                                switch (newEvs.Strat[upcard])
                                {
                                    case (int)BJCAGlobalsClass.Strat.S:
                                        {
                                            if (toStrat.HandEVs[index].SPostallowed[upcard])
                                            {
                                                newEvs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PS;
                                            }
                                            else if (Conversions.ToBoolean(toStrat.HandEVs[index].RPostallowed[upcard] & Conversions.ToInteger(PlayerHands[index].HandEVs.SurrEV[upcard] > PlayerHands[index].HandEVs.DEV[upcard] | !toStrat.HandEVs[index].DPostallowed[upcard]) & Conversions.ToInteger(PlayerHands[index].HandEVs.SurrEV[upcard] > fromStrat.HandEVs[index].EVs.HitEV[upcard] | toStrat.HandEVs[index].HPostallowed[upcard])))
                                            {
                                                newEvs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PR;
                                            }
                                            else if (toStrat.HandEVs[index].DPostallowed[upcard] & PlayerHands[index].HandEVs.DEV[upcard] > fromStrat.HandEVs[index].EVs.HitEV[upcard])
                                            {
                                                newEvs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PD;
                                            }
                                            else
                                            {
                                                newEvs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PH;
                                            }

                                            break;
                                        }
                                    case (int)BJCAGlobalsClass.Strat.D:
                                        {
                                            if (toStrat.HandEVs[index].DPostallowed[upcard])
                                            {
                                                newEvs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PD;
                                            }
                                            else if (Conversions.ToBoolean(toStrat.HandEVs[index].RPostallowed[upcard] & Conversions.ToInteger(PlayerHands[index].HandEVs.SurrEV[upcard] > PlayerHands[index].HandEVs.StandEV[upcard] | !toStrat.HandEVs[index].SPostallowed[upcard]) & Conversions.ToInteger(PlayerHands[index].HandEVs.SurrEV[upcard] > fromStrat.HandEVs[index].EVs.HitEV[upcard] | toStrat.HandEVs[index].HPostallowed[upcard])))
                                            {
                                                newEvs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PR;
                                            }
                                            else if (toStrat.HandEVs[index].SPostallowed[upcard] & PlayerHands[index].HandEVs.StandEV[upcard] > fromStrat.HandEVs[index].EVs.HitEV[upcard])
                                            {
                                                newEvs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PS;
                                            }
                                            else
                                            {
                                                newEvs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PH;
                                            }

                                            break;
                                        }
                                    case (int)BJCAGlobalsClass.Strat.H:
                                        {
                                            if (toStrat.HandEVs[index].HPostallowed[upcard])
                                            {
                                                newEvs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PH;
                                            }
                                            else if (Conversions.ToBoolean(toStrat.HandEVs[index].RPostallowed[upcard] & Conversions.ToInteger(PlayerHands[index].HandEVs.SurrEV[upcard] > PlayerHands[index].HandEVs.DEV[upcard] | !toStrat.HandEVs[index].DPostallowed[upcard]) & Conversions.ToInteger(PlayerHands[index].HandEVs.SurrEV[upcard] > PlayerHands[index].HandEVs.StandEV[upcard] | toStrat.HandEVs[index].SPostallowed[upcard])))
                                            {
                                                newEvs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PR;
                                            }
                                            else if (toStrat.HandEVs[index].DPostallowed[upcard] & PlayerHands[index].HandEVs.DEV[upcard] > PlayerHands[index].HandEVs.StandEV[upcard])
                                            {
                                                newEvs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PD;
                                            }
                                            else
                                            {
                                                newEvs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PS;
                                            }

                                            break;
                                        }
                                    case (int)BJCAGlobalsClass.Strat.R:
                                        {
                                            if (Conversions.ToBoolean(toStrat.HandEVs[index].RPostallowed[upcard]))
                                            {
                                                newEvs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PR;
                                            }
                                            else if (toStrat.HandEVs[index].DPostallowed[upcard] & (PlayerHands[index].HandEVs.DEV[upcard] > PlayerHands[index].HandEVs.StandEV[upcard] | !toStrat.HandEVs[index].SPostallowed[upcard]) & (PlayerHands[index].HandEVs.DEV[upcard] > fromStrat.HandEVs[index].EVs.HitEV[upcard] | toStrat.HandEVs[index].HPostallowed[upcard]))
                                            {
                                                newEvs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PD;
                                            }
                                            else if (toStrat.HandEVs[index].SPostallowed[upcard] & PlayerHands[index].HandEVs.StandEV[upcard] > fromStrat.HandEVs[index].EVs.HitEV[upcard])
                                            {
                                                newEvs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PS;
                                            }
                                            else
                                            {
                                                newEvs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.PH;
                                            }

                                            break;
                                        }
                                }
                            }
                        }
                    }
                }
                switch (newEvs.Strat[upcard])
                {
                    case (int)BJCAGlobalsClass.Strat.D:
                        {
                            if (toStrat.HandEVs[index].SPreallowed[upcard] & !(DAN & DAS))
                            {
                                if (!toStrat.HandEVs[index].HPreallowed[upcard] | PlayerHands[index].HandEVs.StandEV[upcard] > fromStrat.HandEVs[index].EVs.HitEV[upcard])
                                {
                                    newEvs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.DS;
                                }
                            }

                            break;
                        }
                    case (int)BJCAGlobalsClass.Strat.R:
                        {
                            if (toStrat.HandEVs[index].SPreallowed[upcard] & !(SAN & SAS))
                            {
                                if (!toStrat.HandEVs[index].HPreallowed[upcard] | PlayerHands[index].HandEVs.StandEV[upcard] > fromStrat.HandEVs[index].EVs.HitEV[upcard])
                                {
                                    newEvs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.RS;
                                }
                            }

                            break;
                        }
                }
            }

            return newEvs;

        }

        private void CopyOptStratTotal(ref BJCAStrategyClass cStrat, int upcard, int total, int soft)
        {
            // Soft is passed as the Boolean+1 value
            int index;
            var newEvs = new BJCAHandStrategyEVsClass();

            // Need to copy the OptHitEvs as well for initialization of the strategies.
            index = PlayerHandTotal[total, soft];
            while (index != 0)
            {
                cStrat.HandEVs[index].HandUsed[upcard] = Opt.HandEVs[index].HandUsed[upcard];
                cStrat.HandEVs[index].Multiplier[upcard] = Opt.HandEVs[index].Multiplier[upcard];
                if (PlayerHands[index].Hand.NumCards > 1)
                {
                    cStrat.HandEVs[index].EVs.HitEV[upcard] = Opt.HandEVs[index].EVs.HitEV[upcard];
                    if (!cStrat.HandEVs[index].PreForced[upcard])
                    {
                        newEvs = GetStratMaxEVHand(index, upcard, ref cStrat, ref Opt, true, true);
                        cStrat.HandEVs[index].EVs.Strat[upcard] = newEvs.Strat[upcard];
                    }
                }
                index = PlayerHands[index].NextHand;
            }

        }

        private void CopyOptStrat(ref BJCAStrategyClass cStrat, int upcard)
        {
            int index;
            var newEvs = new BJCAHandStrategyEVsClass();

            // Need to copy the OptHitEvs as well for initialization of the strategies.
            var loopTo = NumPHands;
            for (index = 1; index <= loopTo; index++)
            {
                cStrat.HandEVs[index].HandUsed[upcard] = Opt.HandEVs[index].HandUsed[upcard];
                if (PlayerHands[index].Hand.NumCards > 1)
                {
                    cStrat.HandEVs[index].EVs.HitEV[upcard] = Opt.HandEVs[index].EVs.HitEV[upcard];
                    if (!cStrat.HandEVs[index].PreForced[upcard])
                    {
                        newEvs = GetStratMaxEVHand(index, upcard, ref cStrat, ref Opt, true, true);
                        cStrat.HandEVs[index].EVs.Strat[upcard] = newEvs.Strat[upcard];
                    }
                }
            }

        }

        #endregion

        #region  Max EV Minus Methods 

        private void ComputeStrategyMaxEVTotalMinus(ref BJCAStrategyClass cStrat, int total, int soft, int upcard)
        {
            // Soft is passed as the Boolean+1 value
            int index;
            double prob;
            var maxev = default(double);
            bool allForced;
            int rule;
            int forcedStrat;

            // The following procedure is based on the fact that the only values that change with
            // strategy changes are hit/split
            // The only thing these values can do is decrease compared to optimal play
            // Only a single pass is performed

            if (cStrat.StratTD[total, soft] is null)
            {
                cStrat.StratTD[total, soft] = new BJCATDStratClass();
            }

            DealDCard(upcard);

            // First empty the strategy
            cStrat.StratTD[total, soft].Strat[upcard] = 0;
            cStrat.StratTD[total, soft].StratEV[upcard] = 0d;
            cStrat.StratTD[total, soft].StratStandEV[upcard] = 0d;
            cStrat.StratTD[total, soft].StratHitEV[upcard] = 0d;
            cStrat.StratTD[total, soft].StratDEV[upcard] = 0d;
            cStrat.StratTD[total, soft].StratSurrEV[upcard] = 0d;

            cStrat.StratTD[total, soft].NetProb[upcard] = 0d;
            cStrat.StratTD[total, soft].NetSProb[upcard] = 0d;
            cStrat.StratTD[total, soft].NetHProb[upcard] = 0d;
            cStrat.StratTD[total, soft].NetDProb[upcard] = 0d;
            cStrat.StratTD[total, soft].NetSurrProb[upcard] = 0d;

            cStrat.StratTD[total, soft].SStandEV[upcard] = 0d;
            cStrat.StratTD[total, soft].SHitEV[upcard] = 0d;
            cStrat.StratTD[total, soft].SDEV[upcard] = 0d;
            cStrat.StratTD[total, soft].SSurrEV[upcard] = 0d;

            // Then copy the OP strategy including HandsUsed where necessary into the current strategy
            CopyOptStratTotal(ref cStrat, upcard, total, soft);

            // Now begin the actual strategy determination

            // The very first thing we need to do is see if the Total/Soft has any available hands
            // If not we need to fill in the strategy with any cd/split/forced hands available

            // Begin by removing hands that are CD dependent including split hands
            prob = 0d;
            index = PlayerHandTotal[total, soft];
            while (index != 0)
            {
                if (PlayerHands[index].Hand.NumCards < 2 | cStrat.NCardsCD != 0 & PlayerHands[index].Hand.NumCards <= cStrat.NCardsCD | cStrat.HandEVs[index].PreForced[upcard])
                {
                    cStrat.HandEVs[index].HandUsed[upcard] = -1;
                }
                // Don't include blackjack in the strategy determination
                if (PlayerHands[index].Hand.IsBJ())
                {
                    cStrat.HandEVs[index].HandUsed[upcard] = -1;
                }
                switch (cStrat.HandEVs[index].EVs.Strat[upcard])
                {
                    case (int)BJCAGlobalsClass.Strat.P:
                    case (int)BJCAGlobalsClass.Strat.PS:
                    case (int)BJCAGlobalsClass.Strat.PD:
                    case (int)BJCAGlobalsClass.Strat.PH:
                    case (int)BJCAGlobalsClass.Strat.PR:
                        {
                            cStrat.HandEVs[index].HandUsed[upcard] = -1;
                            break;
                        }
                }
                if (cStrat.HandEVs[index].HandUsed[upcard] == 1)
                {
                    prob += 1d;
                }
                index = PlayerHands[index].NextHand;
            }

            if (prob == 0d)
            {
                // All hands are either nonexistent, forced, split or CD
                // The strategy must be dealt with differently
                // First do a quick check of all the hands and see if they're all forced
                allForced = true;
                index = PlayerHandTotal[total, soft];
                while (index != 0)
                {
                    if (PlayerHands[index].Hand.NumCards > 1 & (cStrat.NCardsCD == 0 | PlayerHands[index].Hand.NumCards > cStrat.NCardsCD) & cStrat.HandEVs[index].HandUsed[upcard] == -1 & !cStrat.HandEVs[index].PreForced[upcard])
                    {
                        allForced = false;
                        break;
                    }
                    index = PlayerHands[index].NextHand;
                }

                if (allForced)
                {
                    // All the hands are forced so fill in from the Forced Table if possible.  Otherwise leave it blank.
                    var loopTo = ForcedTableRulesList.NumRules - 1;
                    for (rule = 0; rule <= loopTo; rule++)
                    {
                        if (ForcedTableRulesList.L[rule].Upcard == upcard & ForcedTableRulesList.L[rule].Hand.Total == total & Conversions.ToInteger(ForcedTableRulesList.L[rule].Hand.Soft) + 1 == soft & ForcedTableRulesList.L[rule].Hand.NumCards == 0)
                        {
                            cStrat.StratTD[total, soft].Strat[upcard] = ForcedTableRulesList.L[rule].Strat;
                        }
                    }
                }
                else
                {
                    // Non-forced hands are available for strategy determination
                    cStrat.StratTD[total, soft].NetProb[upcard] = 0d;
                    cStrat.StratTD[total, soft].NetSProb[upcard] = 0d;
                    cStrat.StratTD[total, soft].NetHProb[upcard] = 0d;
                    cStrat.StratTD[total, soft].NetDProb[upcard] = 0d;
                    cStrat.StratTD[total, soft].NetSurrProb[upcard] = 0d;

                    cStrat.StratTD[total, soft].StratStandEV[upcard] = 0d;
                    cStrat.StratTD[total, soft].StratHitEV[upcard] = 0d;
                    cStrat.StratTD[total, soft].StratDEV[upcard] = 0d;
                    cStrat.StratTD[total, soft].StratSurrEV[upcard] = 0d;

                    // Now fill in all the evs
                    index = PlayerHandTotal[total, soft];
                    while (index != 0)
                    {
                        if (PlayerHands[index].Hand.NumCards > 1 & (cStrat.NCardsCD == 0 | PlayerHands[index].Hand.NumCards > cStrat.NCardsCD) & cStrat.HandEVs[index].HandUsed[upcard] == -1 & !cStrat.HandEVs[index].PreForced[upcard])
                        {
                            prob = PlayerHands[index].HandEVs.Prob[upcard] * cStrat.HandEVs[index].Multiplier[upcard];
                            cStrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].NetProb[upcard] += prob;
                            if (cStrat.HandEVs[index].SPreallowed[upcard])
                            {
                                cStrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].NetSProb[upcard] += prob;
                                cStrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].StratStandEV[upcard] += prob * PlayerHands[index].HandEVs.StandEV[upcard];
                            }
                            if (cStrat.HandEVs[index].HPreallowed[upcard])
                            {
                                cStrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].NetHProb[upcard] += prob;
                                cStrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].StratHitEV[upcard] += prob * cStrat.HandEVs[index].EVs.HitEV[upcard];
                            }
                            if (cStrat.HandEVs[index].DPreallowed[upcard])
                            {
                                cStrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].NetDProb[upcard] += prob;
                                cStrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].StratDEV[upcard] += prob * PlayerHands[index].HandEVs.DEV[upcard];
                            }
                            if (cStrat.HandEVs[index].RPreallowed[upcard] > 0)
                            {
                                cStrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].NetSurrProb[upcard] += prob;
                                cStrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].StratSurrEV[upcard] += prob * PlayerHands[index].HandEVs.SurrEV[upcard];
                            }
                        }
                        index = PlayerHands[index].NextHand;
                    }

                    // Now we need to normalize the ev's
                    if (cStrat.StratTD[total, soft].NetSProb[upcard] != 0d)
                    {
                        cStrat.StratTD[total, soft].StratStandEV[upcard] = cStrat.StratTD[total, soft].StratStandEV[upcard] / cStrat.StratTD[total, soft].NetSProb[upcard];
                    }
                    if (cStrat.StratTD[total, soft].NetHProb[upcard] != 0d)
                    {
                        cStrat.StratTD[total, soft].StratHitEV[upcard] = cStrat.StratTD[total, soft].StratHitEV[upcard] / cStrat.StratTD[total, soft].NetHProb[upcard];
                    }
                    if (cStrat.StratTD[total, soft].NetDProb[upcard] != 0d)
                    {
                        cStrat.StratTD[total, soft].StratDEV[upcard] = cStrat.StratTD[total, soft].StratDEV[upcard] / cStrat.StratTD[total, soft].NetDProb[upcard];
                    }
                    if (cStrat.StratTD[total, soft].NetSurrProb[upcard] != 0d)
                    {
                        cStrat.StratTD[total, soft].StratSurrEV[upcard] = cStrat.StratTD[total, soft].StratSurrEV[upcard] / cStrat.StratTD[total, soft].NetSurrProb[upcard];
                    }

                    // Fill in the final TD values for each total
                    if (cStrat.StratTD[total, soft].NetProb[upcard] != 0d)
                    {
                        // Then see if any hands actually exist with the Total/Soft
                        if (cStrat.StratTD[total, soft].NetSProb[upcard] != 0d)
                        {
                            cStrat.StratTD[total, soft].Strat[upcard] = (int)BJCAGlobalsClass.Strat.S;
                            maxev = cStrat.StratTD[total, soft].StratStandEV[upcard];
                        }
                        if (maxev == 0d | cStrat.StratTD[total, soft].NetHProb[upcard] != 0d & cStrat.StratTD[total, soft].StratHitEV[upcard] > maxev)
                        {
                            cStrat.StratTD[total, soft].Strat[upcard] = (int)BJCAGlobalsClass.Strat.H;
                            maxev = cStrat.StratTD[total, soft].StratHitEV[upcard];
                        }
                        if (maxev == 0d | cStrat.StratTD[total, soft].NetDProb[upcard] != 0d & cStrat.StratTD[total, soft].StratDEV[upcard] > maxev)
                        {
                            if (maxev == 0d | cStrat.StratTD[total, soft].Strat[upcard] == (int)BJCAGlobalsClass.Strat.H | DAN & DAS)
                            {
                                cStrat.StratTD[total, soft].Strat[upcard] = (int)BJCAGlobalsClass.Strat.D;
                            }
                            else
                            {
                                cStrat.StratTD[total, soft].Strat[upcard] = (int)BJCAGlobalsClass.Strat.DS;
                            }
                            maxev = cStrat.StratTD[total, soft].StratDEV[upcard];
                        }
                        if (maxev == 0d | cStrat.StratTD[total, soft].NetSurrProb[upcard] != 0d & cStrat.StratTD[total, soft].StratSurrEV[upcard] >= maxev)
                        {
                            if (maxev == 0d | cStrat.StratTD[total, soft].Strat[upcard] == (int)BJCAGlobalsClass.Strat.H | cStrat.StratTD[total, soft].Strat[upcard] == (int)BJCAGlobalsClass.Strat.D | SAN & SAS)
                            {
                                cStrat.StratTD[total, soft].Strat[upcard] = (int)BJCAGlobalsClass.Strat.R;
                            }
                            else
                            {
                                cStrat.StratTD[total, soft].Strat[upcard] = (int)BJCAGlobalsClass.Strat.RS;
                            }
                            maxev = cStrat.StratTD[total, soft].StratSurrEV[upcard];
                        }
                    }
                }
            }
            else
            {
                // Hands are availabe for proper strategy determination so continue

                cStrat.StratTD[total, soft].NetProb[upcard] = 0d;
                cStrat.StratTD[total, soft].NetSProb[upcard] = 0d;
                cStrat.StratTD[total, soft].NetHProb[upcard] = 0d;
                cStrat.StratTD[total, soft].NetDProb[upcard] = 0d;
                cStrat.StratTD[total, soft].NetSurrProb[upcard] = 0d;

                cStrat.StratTD[total, soft].StratStandEV[upcard] = 0d;
                cStrat.StratTD[total, soft].StratHitEV[upcard] = 0d;
                cStrat.StratTD[total, soft].StratDEV[upcard] = 0d;
                cStrat.StratTD[total, soft].StratSurrEV[upcard] = 0d;

                // Fill in the strategy using all used hands to start
                // First look at hands where both double and surrender are allowed
                index = PlayerHandTotal[total, soft];
                while (index != 0)
                {
                    if (cStrat.HandEVs[index].HandUsed[upcard] == 1 & cStrat.HandEVs[index].RPreallowed[upcard] > 0 & cStrat.HandEVs[index].DPreallowed[upcard])
                    {
                        prob = PlayerHands[index].HandEVs.Prob[upcard] * cStrat.HandEVs[index].Multiplier[upcard];

                        cStrat.StratTD[total, soft].NetProb[upcard] += prob;
                        cStrat.StratTD[total, soft].SStandEV[upcard] += prob * PlayerHands[index].HandEVs.StandEV[upcard];
                        cStrat.StratTD[total, soft].SDEV[upcard] += prob * PlayerHands[index].HandEVs.DEV[upcard];
                        cStrat.StratTD[total, soft].SHitEV[upcard] += prob * Opt.HandEVs[index].EVs.HitEV[upcard];
                        cStrat.StratTD[total, soft].SSurrEV[upcard] += prob * PlayerHands[index].HandEVs.SurrEV[upcard];
                    }
                    index = PlayerHands[index].NextHand;
                }

                // If the probability of a strategy option is 0 then prevent it from being the strategy
                if (cStrat.StratTD[total, soft].NetProb[upcard] != 0d)
                {
                    if (cStrat.StratTD[total, soft].SStandEV[upcard] == 0d)
                        cStrat.StratTD[total, soft].SStandEV[upcard] = -2;
                    if (cStrat.StratTD[total, soft].SDEV[upcard] == 0d)
                        cStrat.StratTD[total, soft].SDEV[upcard] = -2;
                    if (cStrat.StratTD[total, soft].SHitEV[upcard] == 0d)
                        cStrat.StratTD[total, soft].SHitEV[upcard] = -2;
                    if (cStrat.StratTD[total, soft].SSurrEV[upcard] == 0d)
                        cStrat.StratTD[total, soft].SSurrEV[upcard] = -2;
                }

                // Compare double/surrender to hit/stand
                if (cStrat.StratTD[total, soft].NetProb[upcard] != 0d)
                {
                    cStrat.StratTD[total, soft].Strat[upcard] = (int)BJCAGlobalsClass.Strat.S;
                    maxev = cStrat.StratTD[total, soft].SStandEV[upcard];
                    if (cStrat.StratTD[total, soft].SHitEV[upcard] > maxev)
                    {
                        cStrat.StratTD[total, soft].Strat[upcard] = (int)BJCAGlobalsClass.Strat.H;
                        maxev = cStrat.StratTD[total, soft].SHitEV[upcard];
                    }
                    if (cStrat.StratTD[total, soft].SDEV[upcard] > maxev)
                    {
                        if (cStrat.StratTD[total, soft].Strat[upcard] == (int)BJCAGlobalsClass.Strat.H)
                        {
                            cStrat.StratTD[total, soft].Strat[upcard] = (int)BJCAGlobalsClass.Strat.D;
                        }
                        else
                        {
                            cStrat.StratTD[total, soft].Strat[upcard] = (int)BJCAGlobalsClass.Strat.DS;
                        }
                        maxev = cStrat.StratTD[total, soft].SDEV[upcard];
                    }
                    if (cStrat.StratTD[total, soft].SSurrEV[upcard] >= maxev)
                    {
                        if (cStrat.StratTD[total, soft].Strat[upcard] == (int)BJCAGlobalsClass.Strat.H | cStrat.StratTD[total, soft].Strat[upcard] == (int)BJCAGlobalsClass.Strat.D)
                        {
                            cStrat.StratTD[total, soft].Strat[upcard] = (int)BJCAGlobalsClass.Strat.R;
                        }
                        else
                        {
                            cStrat.StratTD[total, soft].Strat[upcard] = (int)BJCAGlobalsClass.Strat.RS;
                        }
                        maxev = cStrat.StratTD[total, soft].SSurrEV[upcard];
                    }
                    if (cStrat.StratTD[total, soft].Strat[upcard] == (int)BJCAGlobalsClass.Strat.DS & DAN & DAS)
                    {
                        cStrat.StratTD[total, soft].Strat[upcard] = (int)BJCAGlobalsClass.Strat.D;
                    }
                    else if (cStrat.StratTD[total, soft].Strat[upcard] == (int)BJCAGlobalsClass.Strat.RS & SAN & SAS)
                    {
                        cStrat.StratTD[total, soft].Strat[upcard] = (int)BJCAGlobalsClass.Strat.R;
                    }
                }

                // Now check values where only double is allowed and the strategy hasn't been set to surrender/split
                cStrat.StratTD[total, soft].NetProb[upcard] = 0d;

                cStrat.StratTD[total, soft].SStandEV[upcard] = 0d;
                cStrat.StratTD[total, soft].SHitEV[upcard] = 0d;
                cStrat.StratTD[total, soft].SDEV[upcard] = 0d;
                cStrat.StratTD[total, soft].SSurrEV[upcard] = 0d;

                if (cStrat.StratTD[total, soft].Strat[upcard] != (int)BJCAGlobalsClass.Strat.R & cStrat.StratTD[total, soft].Strat[upcard] != (int)BJCAGlobalsClass.Strat.RS)
                {
                    index = PlayerHandTotal[total, soft];
                    while (index != 0)
                    {
                        if (cStrat.HandEVs[index].HandUsed[upcard] == 1 & cStrat.HandEVs[index].DPreallowed[upcard])
                        {
                            prob = PlayerHands[index].HandEVs.Prob[upcard] * cStrat.HandEVs[index].Multiplier[upcard];
                            cStrat.StratTD[total, soft].NetProb[upcard] += prob;
                            cStrat.StratTD[total, soft].SStandEV[upcard] += prob * PlayerHands[index].HandEVs.StandEV[upcard];
                            cStrat.StratTD[total, soft].SDEV[upcard] += prob * PlayerHands[index].HandEVs.DEV[upcard];
                            cStrat.StratTD[total, soft].SHitEV[upcard] += prob * cStrat.HandEVs[index].EVs.HitEV[upcard];
                        }
                        index = PlayerHands[index].NextHand;
                    }
                }

                // If the probability of a strategy option is 0 then prevent it from being the strategy
                if (cStrat.StratTD[total, soft].NetProb[upcard] != 0d)
                {
                    if (cStrat.StratTD[total, soft].SStandEV[upcard] == 0d)
                        cStrat.StratTD[total, soft].SStandEV[upcard] = -2;
                    if (cStrat.StratTD[total, soft].SDEV[upcard] == 0d)
                        cStrat.StratTD[total, soft].SDEV[upcard] = -2;
                    if (cStrat.StratTD[total, soft].SHitEV[upcard] == 0d)
                        cStrat.StratTD[total, soft].SHitEV[upcard] = -2;
                    if (cStrat.StratTD[total, soft].SSurrEV[upcard] == 0d)
                        cStrat.StratTD[total, soft].SSurrEV[upcard] = -2;
                }

                // Compare double to hit/stand
                if (cStrat.StratTD[total, soft].NetProb[upcard] != 0d)
                {
                    cStrat.StratTD[total, soft].Strat[upcard] = (int)BJCAGlobalsClass.Strat.S;
                    maxev = cStrat.StratTD[total, soft].SStandEV[upcard];
                    if (cStrat.StratTD[total, soft].SHitEV[upcard] > maxev)
                    {
                        cStrat.StratTD[total, soft].Strat[upcard] = (int)BJCAGlobalsClass.Strat.H;
                        maxev = cStrat.StratTD[total, soft].SHitEV[upcard];
                    }
                    if (cStrat.StratTD[total, soft].SDEV[upcard] > maxev)
                    {
                        if (cStrat.StratTD[total, soft].Strat[upcard] == (int)BJCAGlobalsClass.Strat.H | DAN & DAS)
                        {
                            cStrat.StratTD[total, soft].Strat[upcard] = (int)BJCAGlobalsClass.Strat.D;
                        }
                        else
                        {
                            cStrat.StratTD[total, soft].Strat[upcard] = (int)BJCAGlobalsClass.Strat.DS;
                        }
                        maxev = cStrat.StratTD[total, soft].SDEV[upcard];
                    }
                }

                // Now check values where only surrender is allowed and the strategy hasn't been set to double/split
                cStrat.StratTD[total, soft].NetProb[upcard] = 0d;

                cStrat.StratTD[total, soft].SStandEV[upcard] = 0d;
                cStrat.StratTD[total, soft].SHitEV[upcard] = 0d;
                cStrat.StratTD[total, soft].SDEV[upcard] = 0d;
                cStrat.StratTD[total, soft].SSurrEV[upcard] = 0d;

                if (cStrat.StratTD[total, soft].Strat[upcard] != (int)BJCAGlobalsClass.Strat.D & cStrat.StratTD[total, soft].Strat[upcard] != (int)BJCAGlobalsClass.Strat.DS)
                {
                    index = PlayerHandTotal[total, soft];
                    while (index != 0)
                    {
                        if (cStrat.HandEVs[index].HandUsed[upcard] == 1 & cStrat.HandEVs[index].RPreallowed[upcard] > 0)
                        {
                            prob = PlayerHands[index].HandEVs.Prob[upcard] * cStrat.HandEVs[index].Multiplier[upcard];
                            cStrat.StratTD[total, soft].NetProb[upcard] += prob;
                            cStrat.StratTD[total, soft].SStandEV[upcard] += prob * PlayerHands[index].HandEVs.StandEV[upcard];
                            cStrat.StratTD[total, soft].SHitEV[upcard] += prob * cStrat.HandEVs[index].EVs.HitEV[upcard];
                            cStrat.StratTD[total, soft].SSurrEV[upcard] += prob * PlayerHands[index].HandEVs.SurrEV[upcard];
                        }
                        index = PlayerHands[index].NextHand;
                    }
                }

                // If the probability of a strategy option is 0 then prevent it from being the strategy
                if (cStrat.StratTD[total, soft].NetProb[upcard] != 0d)
                {
                    if (cStrat.StratTD[total, soft].SStandEV[upcard] == 0d)
                        cStrat.StratTD[total, soft].SStandEV[upcard] = -2;
                    if (cStrat.StratTD[total, soft].SHitEV[upcard] == 0d)
                        cStrat.StratTD[total, soft].SHitEV[upcard] = -2;
                    if (cStrat.StratTD[total, soft].SSurrEV[upcard] == 0d)
                        cStrat.StratTD[total, soft].SSurrEV[upcard] = -2;
                }

                // Compare surrender to hit/stand
                if (cStrat.StratTD[total, soft].NetProb[upcard] != 0d)
                {
                    cStrat.StratTD[total, soft].Strat[upcard] = (int)BJCAGlobalsClass.Strat.S;
                    maxev = cStrat.StratTD[total, soft].SStandEV[upcard];
                    if (cStrat.StratTD[total, soft].SHitEV[upcard] > maxev)
                    {
                        cStrat.StratTD[total, soft].Strat[upcard] = (int)BJCAGlobalsClass.Strat.H;
                        maxev = cStrat.StratTD[total, soft].SHitEV[upcard];
                    }
                    if (cStrat.StratTD[total, soft].SSurrEV[upcard] > maxev)
                    {
                        if (cStrat.StratTD[total, soft].Strat[upcard] == (int)BJCAGlobalsClass.Strat.H | SAN & SAS)
                        {
                            cStrat.StratTD[total, soft].Strat[upcard] = (int)BJCAGlobalsClass.Strat.R;
                        }
                        else
                        {
                            cStrat.StratTD[total, soft].Strat[upcard] = (int)BJCAGlobalsClass.Strat.RS;
                        }
                        maxev = cStrat.StratTD[total, soft].SSurrEV[upcard];
                    }
                }

                // Now check values where neither surrender nor double is the strategy and the strategy hasn't been set to double/split
                cStrat.StratTD[total, soft].NetProb[upcard] = 0d;

                cStrat.StratTD[total, soft].SStandEV[upcard] = 0d;
                cStrat.StratTD[total, soft].SHitEV[upcard] = 0d;

                if (cStrat.StratTD[total, soft].Strat[upcard] != (int)BJCAGlobalsClass.Strat.D & cStrat.StratTD[total, soft].Strat[upcard] != (int)BJCAGlobalsClass.Strat.DS & cStrat.StratTD[total, soft].Strat[upcard] != (int)BJCAGlobalsClass.Strat.R & cStrat.StratTD[total, soft].Strat[upcard] != (int)BJCAGlobalsClass.Strat.RS)
                {
                    index = PlayerHandTotal[total, soft];
                    while (index != 0)
                    {
                        if (cStrat.HandEVs[index].HandUsed[upcard] == 1)
                        {
                            prob = PlayerHands[index].HandEVs.Prob[upcard] * cStrat.HandEVs[index].Multiplier[upcard];
                            cStrat.StratTD[total, soft].NetProb[upcard] += prob;
                            cStrat.StratTD[total, soft].SStandEV[upcard] += prob * PlayerHands[index].HandEVs.StandEV[upcard];
                            cStrat.StratTD[total, soft].SHitEV[upcard] += prob * cStrat.HandEVs[index].EVs.HitEV[upcard];
                        }
                        index = PlayerHands[index].NextHand;
                    }
                }

                // If the probability of a strategy option is 0 then prevent it from being the strategy
                if (cStrat.StratTD[total, soft].NetProb[upcard] != 0d)
                {
                    if (cStrat.StratTD[total, soft].SStandEV[upcard] == 0d)
                        cStrat.StratTD[total, soft].SStandEV[upcard] = -2;
                    if (cStrat.StratTD[total, soft].SHitEV[upcard] == 0d)
                        cStrat.StratTD[total, soft].SHitEV[upcard] = -2;
                }

                // Compare hit to stand
                if (cStrat.StratTD[total, soft].NetProb[upcard] != 0d)
                {
                    cStrat.StratTD[total, soft].Strat[upcard] = (int)BJCAGlobalsClass.Strat.S;
                    maxev = cStrat.StratTD[total, soft].SStandEV[upcard];
                    if (cStrat.StratTD[total, soft].SHitEV[upcard] > maxev)
                    {
                        cStrat.StratTD[total, soft].Strat[upcard] = (int)BJCAGlobalsClass.Strat.H;
                        maxev = cStrat.StratTD[total, soft].SHitEV[upcard];
                    }
                }

            }

            UndealDCard(upcard);

        }

        private void ComputeStrategyMaxEVMinus(ref BJCAStrategyClass cStrat, int upcard)
        {
            int total;
            int soft;
            double prob;
            int card;
            int index;
            int card2;
            int pairMultiplier;
            var newEvs = new BJCAHandStrategyEVsClass();

            for (total = 21; total >= 11; total -= 1)
                ComputeStrategyMaxEVTotalMinus(ref cStrat, total, Conversions.ToInteger(false) + 1, upcard);
            for (total = 21; total >= 12; total -= 1)
                ComputeStrategyMaxEVTotalMinus(ref cStrat, total, Conversions.ToInteger(true) + 1, upcard);
            for (total = 10; total >= 4; total -= 1)
                ComputeStrategyMaxEVTotalMinus(ref cStrat, total, Conversions.ToInteger(false) + 1, upcard);

            // Now that all the preliminary strategies are determined we need to
            // check to see if any strategies changed.
            // This must be with all the strategies available so is done now.

            DealDCard(upcard);

            // Calculate the new overall hitting values using the current strategy
            ComputeStratHit(ref cStrat, upcard);

            // Figure out which hands are actually used using the strategy when hitting
            // The next step plays out the strategy and increases the HandUsed index
            GetHandsUsed(ref cStrat, upcard, 1, true);

            // Cycle through the hands and remove all forced, double, surrendered and CD hands
            prob = 0d;
            var loopTo = NumPHands;
            for (index = 1; index <= loopTo; index++)
            {
                if (PlayerHands[index].Hand.NumCards > 1)
                {
                    if (cStrat.NCardsCD != 0 & PlayerHands[index].Hand.NumCards <= cStrat.NCardsCD | cStrat.HandEVs[index].PreForced[upcard])
                    {
                        cStrat.HandEVs[index].HandUsed[upcard] = -1;
                    }
                    else if (cStrat.HandEVs[index].DPreallowed[upcard] & (cStrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].Strat[upcard] == (int)BJCAGlobalsClass.Strat.D | cStrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].Strat[upcard] == (int)BJCAGlobalsClass.Strat.DS))
                    {
                        cStrat.HandEVs[index].HandUsed[upcard] = -1;
                    }
                    else if (cStrat.HandEVs[index].RPreallowed[upcard] > 0 & (cStrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].Strat[upcard] == (int)BJCAGlobalsClass.Strat.R | cStrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].Strat[upcard] == (int)BJCAGlobalsClass.Strat.RS))
                    {
                        cStrat.HandEVs[index].HandUsed[upcard] = -1;
                    }
                    if (cStrat.HandEVs[index].HandUsed[upcard] == 1)
                    {
                        prob += 1d;
                    }
                }
            }

            // Only change the strategy if there are non-forced/split hands.
            if (prob > 0d)
            {
                for (total = 4; total <= 21; total++)
                {
                    for (soft = 0; soft <= 1; soft++)
                    {
                        // Look at all hands where the strategy included hitting
                        if (cStrat.StratTD[total, soft] is not null)
                        {
                            if (cStrat.StratTD[total, soft].Strat[upcard] == (int)BJCAGlobalsClass.Strat.H | cStrat.StratTD[total, soft].Strat[upcard] == (int)BJCAGlobalsClass.Strat.D | cStrat.StratTD[total, soft].Strat[upcard] == (int)BJCAGlobalsClass.Strat.R)
                            {
                                cStrat.StratTD[total, soft].NetProb[upcard] = 0d;
                                cStrat.StratTD[total, soft].SStandEV[upcard] = 0d;
                                cStrat.StratTD[total, soft].SHitEV[upcard] = 0d;

                                index = PlayerHandTotal[total, soft];
                                while (index != 0)
                                {
                                    if (cStrat.HandEVs[index].HandUsed[upcard] == 1)
                                    {
                                        prob = PlayerHands[index].HandEVs.Prob[upcard] * cStrat.HandEVs[index].Multiplier[upcard];
                                        cStrat.StratTD[total, soft].NetProb[upcard] += prob;
                                        cStrat.StratTD[total, soft].SStandEV[upcard] += prob * PlayerHands[index].HandEVs.StandEV[upcard];
                                        cStrat.StratTD[total, soft].SHitEV[upcard] += prob * cStrat.HandEVs[index].EVs.HitEV[upcard];
                                    }
                                    index = PlayerHands[index].NextHand;
                                }

                                // If the probability of a strategy option is 0 then prevent it from being the strategy
                                if (cStrat.StratTD[total, soft].NetProb[upcard] != 0d)
                                {
                                    if (cStrat.StratTD[total, soft].SStandEV[upcard] == 0d)
                                        cStrat.StratTD[total, soft].SStandEV[upcard] = -2;
                                    if (cStrat.StratTD[total, soft].SHitEV[upcard] == 0d)
                                        cStrat.StratTD[total, soft].SHitEV[upcard] = -2;
                                }

                                // Compare hit to stand and adjust the strategy as needed
                                if (cStrat.StratTD[total, soft].SHitEV[upcard] < cStrat.StratTD[total, soft].SStandEV[upcard])
                                {
                                    if (cStrat.StratTD[total, soft].Strat[upcard] == (int)BJCAGlobalsClass.Strat.H)
                                    {
                                        cStrat.StratTD[total, soft].Strat[upcard] = (int)BJCAGlobalsClass.Strat.S;
                                    }
                                    else if (cStrat.StratTD[total, soft].Strat[upcard] == (int)BJCAGlobalsClass.Strat.D & !(DAN & DAS))
                                    {
                                        cStrat.StratTD[total, soft].Strat[upcard] = (int)BJCAGlobalsClass.Strat.DS;
                                    }
                                    else if (cStrat.StratTD[total, soft].Strat[upcard] == (int)BJCAGlobalsClass.Strat.R & !(SAN & SAS))
                                    {
                                        cStrat.StratTD[total, soft].Strat[upcard] = (int)BJCAGlobalsClass.Strat.RS;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // Now calculate the final Total/Soft evs
            // Determine the whether a given hand is used
            GetHandsUsed(ref cStrat, upcard, 1, true, true);

            // Calculate the final overall hitting values using the current strategy
            ComputeStratHit(ref cStrat, upcard);

            // Fill in the final TD values for each total
            for (total = 4; total <= 21; total++)
            {
                for (soft = 0; soft <= 1; soft++)
                {
                    if (cStrat.StratTD[total, soft] is not null)
                    {
                        cStrat.StratTD[total, soft].NetProb[upcard] = 0d;
                        cStrat.StratTD[total, soft].NetSProb[upcard] = 0d;
                        cStrat.StratTD[total, soft].NetHProb[upcard] = 0d;
                        cStrat.StratTD[total, soft].NetDProb[upcard] = 0d;
                        cStrat.StratTD[total, soft].NetSurrProb[upcard] = 0d;

                        cStrat.StratTD[total, soft].StratStandEV[upcard] = 0d;
                        cStrat.StratTD[total, soft].StratHitEV[upcard] = 0d;
                        cStrat.StratTD[total, soft].StratDEV[upcard] = 0d;
                        cStrat.StratTD[total, soft].StratSurrEV[upcard] = 0d;
                    }
                }
            }

            var loopTo1 = NumPHands;
            for (index = 1; index <= loopTo1; index++)
            {
                if (cStrat.HandEVs[index].HandUsed[upcard] == 1 & !PlayerHands[index].Hand.IsBJ() & (cStrat.NCardsCD == 0 | PlayerHands[index].Hand.NumCards > cStrat.NCardsCD))
                {
                    prob = PlayerHands[index].HandEVs.Prob[upcard] * cStrat.HandEVs[index].Multiplier[upcard];
                    cStrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].NetProb[upcard] += prob;
                    if (cStrat.HandEVs[index].SPreallowed[upcard])
                    {
                        cStrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].NetSProb[upcard] += prob;
                        cStrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].StratStandEV[upcard] += prob * PlayerHands[index].HandEVs.StandEV[upcard];
                    }
                    if (cStrat.HandEVs[index].HPreallowed[upcard])
                    {
                        cStrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].NetHProb[upcard] += prob;
                        cStrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].StratHitEV[upcard] += prob * cStrat.HandEVs[index].EVs.HitEV[upcard];
                    }
                    if (cStrat.HandEVs[index].DPreallowed[upcard])
                    {
                        cStrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].NetDProb[upcard] += prob;
                        cStrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].StratDEV[upcard] += prob * PlayerHands[index].HandEVs.DEV[upcard];
                    }
                    if (Conversions.ToBoolean(cStrat.HandEVs[index].RPreallowed[upcard]))
                    {
                        cStrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].NetSurrProb[upcard] += prob;
                        cStrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].StratSurrEV[upcard] += prob * PlayerHands[index].HandEVs.SurrEV[upcard];
                    }
                }
            }

            // Now we need to normalize the ev's
            for (total = 4; total <= 21; total++)
            {
                for (soft = 0; soft <= 1; soft++)
                {
                    if (cStrat.StratTD[total, soft] is not null)
                    {
                        if (cStrat.StratTD[total, soft].NetSProb[upcard] != 0d)
                        {
                            cStrat.StratTD[total, soft].StratStandEV[upcard] /= cStrat.StratTD[total, soft].NetSProb[upcard];
                            cStrat.StratTD[total, soft].NetSProb[upcard] /= cStrat.StratTD[total, soft].NetProb[upcard];
                        }
                        if (cStrat.StratTD[total, soft].NetHProb[upcard] != 0d)
                        {
                            cStrat.StratTD[total, soft].StratHitEV[upcard] /= cStrat.StratTD[total, soft].NetHProb[upcard];
                            cStrat.StratTD[total, soft].NetHProb[upcard] /= cStrat.StratTD[total, soft].NetProb[upcard];
                        }
                        if (cStrat.StratTD[total, soft].NetDProb[upcard] != 0d)
                        {
                            cStrat.StratTD[total, soft].StratDEV[upcard] /= cStrat.StratTD[total, soft].NetDProb[upcard];
                            cStrat.StratTD[total, soft].NetDProb[upcard] /= cStrat.StratTD[total, soft].NetProb[upcard];
                        }
                        if (cStrat.StratTD[total, soft].NetSurrProb[upcard] != 0d)
                        {
                            cStrat.StratTD[total, soft].StratSurrEV[upcard] /= cStrat.StratTD[total, soft].NetSurrProb[upcard];
                            cStrat.StratTD[total, soft].NetSurrProb[upcard] /= cStrat.StratTD[total, soft].NetProb[upcard];
                        }
                    }
                }
            }


            // Finally fill in the strategies for each hand except for splits which are already determined
            var loopTo2 = NumPHands;
            for (index = 1; index <= loopTo2; index++)
            {
                if (PlayerHands[index].Hand.NumCards > 1 & !cStrat.HandEVs[index].PreForced[upcard])
                {
                    if (cStrat.HandEVs[index].EVs.Strat[upcard] != (int)BJCAGlobalsClass.Strat.P & cStrat.HandEVs[index].EVs.Strat[upcard] != (int)BJCAGlobalsClass.Strat.PS & cStrat.HandEVs[index].EVs.Strat[upcard] != (int)BJCAGlobalsClass.Strat.PH & cStrat.HandEVs[index].EVs.Strat[upcard] != (int)BJCAGlobalsClass.Strat.PD & cStrat.HandEVs[index].EVs.Strat[upcard] != (int)BJCAGlobalsClass.Strat.PR)
                    {
                        if (cStrat.NCardsCD != 0 & PlayerHands[index].Hand.NumCards <= cStrat.NCardsCD)
                        {
                            newEvs = GetStratMaxEVHand(index, upcard, ref cStrat, ref cStrat, true, true);
                            cStrat.HandEVs[index].EVs.Strat[upcard] = newEvs.Strat[upcard];
                            cStrat.HandEVs[index].EVs.StratEV[upcard] = newEvs.StratEV[upcard];
                            cStrat.HandEVs[index].EVs.StratPushEV[upcard] = newEvs.StratPushEV[upcard];
                        }
                        else if (PlayerHands[index].Hand.IsBJ())
                        {
                            // Always use the optimal strategy for BJ
                            cStrat.HandEVs[index].EVs.Strat[upcard] = Opt.HandEVs[index].EVs.Strat[upcard];
                            cStrat.HandEVs[index].EVs.StratEV[upcard] = Opt.HandEVs[index].EVs.StratEV[upcard];
                            cStrat.HandEVs[index].EVs.StratPushEV[upcard] = newEvs.StratPushEV[upcard];
                        }
                        else
                        {
                            // Hand is total dependent
                            cStrat.HandEVs[index].EVs.Strat[upcard] = cStrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].Strat[upcard];
                            if (cStrat.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.D & !cStrat.HandEVs[index].DPreallowed[upcard])
                            {
                                cStrat.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.H;
                            }
                            else if (cStrat.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.DS & !cStrat.HandEVs[index].DPreallowed[upcard])
                            {
                                cStrat.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.S;
                            }
                            else if (cStrat.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.R & cStrat.HandEVs[index].RPreallowed[upcard] == 0)
                            {
                                cStrat.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.H;
                            }
                            else if (cStrat.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.RS & cStrat.HandEVs[index].RPreallowed[upcard] == 0)
                            {
                                cStrat.HandEVs[index].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.S;
                            }
                        }
                        switch (cStrat.HandEVs[index].EVs.Strat[upcard])
                        {
                            case (int)BJCAGlobalsClass.Strat.S:
                                {
                                    cStrat.HandEVs[index].EVs.StratEV[upcard] = PlayerHands[index].HandEVs.StandEV[upcard];
                                    break;
                                }
                            case (int)BJCAGlobalsClass.Strat.H:
                                {
                                    cStrat.HandEVs[index].EVs.StratEV[upcard] = cStrat.HandEVs[index].EVs.HitEV[upcard];
                                    break;
                                }
                            case (int)BJCAGlobalsClass.Strat.D:
                            case (int)BJCAGlobalsClass.Strat.DS:
                                {
                                    cStrat.HandEVs[index].EVs.StratEV[upcard] = PlayerHands[index].HandEVs.DEV[upcard];
                                    break;
                                }
                            case (int)BJCAGlobalsClass.Strat.R:
                            case (int)BJCAGlobalsClass.Strat.RS:
                                {
                                    cStrat.HandEVs[index].EVs.StratEV[upcard] = PlayerHands[index].HandEVs.SurrEV[upcard];
                                    break;
                                }

                            default:
                                {
                                    cStrat.HandEVs[index].EVs.StratEV[upcard] = 0d;
                                    break;
                                }
                                // Case BJCAGlobalsClass.Strat.P, BJCAGlobalsClass.Strat.PS, BJCAGlobalsClass.Strat.PH, BJCAGlobalsClass.Strat.PD, BJCAGlobalsClass.Strat.PR
                                // cStrat.HandEVs(index).EVs.StratEV(upcard) = cStrat.HandEVs(index).SplitEV(upcard)
                        }
                    }
                }
            }

            UndealDCard(upcard);

            // Now calculate splits 
            if (SPL > 0)
            {
                for (card = 1; card <= 10; card++)
                {
                    if (SplitIndex[card, upcard] > 0)
                    {
                        index = SplitIndex[card, upcard];
                        ComputeSplit(ref cStrat, card, upcard);

                        // Now double check the strategies vs splitting
                        if (!cStrat.HandEVs[index].PreForced[upcard])
                        {
                            // CD Hands
                            newEvs = GetStratMaxEVHand(index, upcard, ref cStrat, ref cStrat, true, true);
                            if (cStrat.NCardsCD != 0 & PlayerHands[index].Hand.NumCards <= cStrat.NCardsCD)
                            {
                                cStrat.HandEVs[index].EVs.Strat[upcard] = newEvs.Strat[upcard];
                                cStrat.HandEVs[index].EVs.StratEV[upcard] = newEvs.StratEV[upcard];
                            }
                            else
                            {
                                // Total Dependent Hands
                                switch (newEvs.Strat[upcard])
                                {
                                    case (int)BJCAGlobalsClass.Strat.P:
                                    case (int)BJCAGlobalsClass.Strat.PS:
                                    case (int)BJCAGlobalsClass.Strat.PH:
                                    case (int)BJCAGlobalsClass.Strat.PD:
                                    case (int)BJCAGlobalsClass.Strat.PR:
                                        {
                                            cStrat.HandEVs[index].EVs.Strat[upcard] = newEvs.Strat[upcard];
                                            cStrat.HandEVs[index].EVs.StratEV[upcard] = newEvs.StratEV[upcard];
                                            break;
                                        }
                                }
                            }
                        }
                    }
                }
            }

            // Remove the second strategy for TD pairs
            for (card = 1; card <= 10; card++)
            {
                if (SplitIndex[card, upcard] > 0)
                {
                    if (!cStrat.HandEVs[SplitIndex[card, upcard]].PreForced[upcard])
                    {
                        switch (cStrat.HandEVs[SplitIndex[card, upcard]].EVs.Strat[upcard])
                        {
                            case (int)BJCAGlobalsClass.Strat.P:
                            case (int)BJCAGlobalsClass.Strat.PS:
                            case (int)BJCAGlobalsClass.Strat.PH:
                            case (int)BJCAGlobalsClass.Strat.PD:
                            case (int)BJCAGlobalsClass.Strat.PR:
                                {
                                    // Fix the Soft 12 Strat while we're at it
                                    if (card == 1 & (HSA | DSA | SSA))
                                    {
                                        if (cStrat.StratTD[12, Conversions.ToInteger(true) + 1].Strat[upcard] == (int)BJCAGlobalsClass.Strat.H & !HSA)
                                        {
                                            cStrat.StratTD[12, Conversions.ToInteger(true) + 1].Strat[upcard] = (int)BJCAGlobalsClass.Strat.None;
                                        }
                                        else if (cStrat.StratTD[12, Conversions.ToInteger(true) + 1].Strat[upcard] == (int)BJCAGlobalsClass.Strat.D & !DSA)
                                        {
                                            cStrat.StratTD[12, Conversions.ToInteger(true) + 1].Strat[upcard] = (int)BJCAGlobalsClass.Strat.None;
                                        }
                                        else if (cStrat.StratTD[12, Conversions.ToInteger(true) + 1].Strat[upcard] == (int)BJCAGlobalsClass.Strat.R & !SSA)
                                        {
                                            cStrat.StratTD[12, Conversions.ToInteger(true) + 1].Strat[upcard] = (int)BJCAGlobalsClass.Strat.None;
                                        }
                                    }
                                    else if (card == 1)
                                    {
                                        cStrat.StratTD[12, Conversions.ToInteger(true) + 1].Strat[upcard] = (int)BJCAGlobalsClass.Strat.None;
                                    }
                                    if (cStrat.NCardsCD == 0)
                                    {
                                        cStrat.HandEVs[SplitIndex[card, upcard]].EVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.P;
                                    }

                                    break;
                                }
                        }
                    }
                }
            }


        }

        #endregion

        #region  Game EV Methods 

        public void ComputeGameEVsStrat(ref BJCAStrategyClass cStrat)
        {
            int card;
            int card2;
            int upcard;
            double prob;
            double bjadjprob;
            double cev;
            double bjev;
            int index;

            CurrentPHand.Empty();
            CurrentDHand.Hand.Empty();
            CurrentShoe.Reset(OriginalShoe);

            cStrat.GameEVs.NetGameEV = 0d;
            for (card = 1; card <= 10; card++)
            {
                cStrat.GameEVs.CardProbs[card] = CardProb(card, 0);
                cStrat.GameEVs.UpcardEVs[card] = 0d;
                cStrat.GameEVs.FirstCardEVs[card] = 0d;
            }

            // Cycle through all 2 card hands to figure out net game ev's
            for (card = 1; card <= 10; card++)
            {
                if (CardProb(card, 0) > 0d)
                {
                    prob = CardProb(card, 0);
                    DealPCard(card);
                    for (card2 = card; card2 <= 10; card2++)
                    {
                        if (CardProb(card2, 0) > 0d)
                        {
                            prob = prob * CardProb(card2, 0);
                            DealPCard(card2);
                            if (card != card2)
                                prob = prob * 2d;
                            for (upcard = 1; upcard <= 10; upcard++)
                            {
                                if (UCAllowed[upcard] & CardProb(upcard, 0) > 0d)
                                {
                                    prob = prob * CardProb(upcard, 0);
                                    DealDCard(upcard);
                                    // Non-dealer Checking BJ's already accounted for
                                    if (upcard == 1 & CheckAce)
                                    {
                                        bjadjprob = CardProb(10, 0);
                                    }
                                    else if (upcard == 10 & CheckTen)
                                    {
                                        bjadjprob = CardProb(1, 0);
                                    }
                                    else
                                    {
                                        bjadjprob = 0d;
                                    }
                                    index = FindPlayerHand(CurrentPHand);

                                    if (PlayerHands[index].SuitedBonusEVs is null)
                                    {
                                        bjev = PlayerHands[index].HandEVs.BJStandEV[upcard];

                                        switch (cStrat.HandEVs[index].EVs.Strat[upcard])
                                        {
                                            case (int)BJCAGlobalsClass.Strat.S:
                                                {
                                                    cev = PlayerHands[index].HandEVs.StandEV[upcard];
                                                    break;
                                                }
                                            case (int)BJCAGlobalsClass.Strat.D:
                                            case (int)BJCAGlobalsClass.Strat.DS:
                                                {
                                                    cev = PlayerHands[index].HandEVs.DEV[upcard];
                                                    break;
                                                }
                                            case (int)BJCAGlobalsClass.Strat.R:
                                            case (int)BJCAGlobalsClass.Strat.RS:
                                                {
                                                    cev = PlayerHands[index].HandEVs.SurrEV[upcard];
                                                    break;
                                                }
                                            case (int)BJCAGlobalsClass.Strat.H:
                                                {
                                                    cev = cStrat.HandEVs[index].EVs.HitEV[upcard];
                                                    break;
                                                }
                                            case (int)BJCAGlobalsClass.Strat.P:
                                            case (int)BJCAGlobalsClass.Strat.PS:
                                            case (int)BJCAGlobalsClass.Strat.PD:
                                            case (int)BJCAGlobalsClass.Strat.PH:
                                            case (int)BJCAGlobalsClass.Strat.PR:
                                                {
                                                    cev = cStrat.HandEVs[index].SplitEV[upcard];
                                                    break;
                                                }

                                            default:
                                                {
                                                    cev = 0d;
                                                    break;
                                                }
                                        }
                                        // Bonus EVs of 2 card hands need to be added here
                                        cev += PlayerHands[index].HandEVs.BonusEV[upcard];
                                    }
                                    else
                                    {
                                        // Bonus EVs are already included in the SuitedNetEV
                                        bjev = PlayerHands[index].SuitedBonusEVs.SuitedNetBJEV[upcard];
                                        cev = PlayerHands[index].SuitedBonusEVs.SuitedNetEV[upcard];
                                    }

                                    cStrat.GameEVs.NetGameEV += prob * ((1d - bjadjprob) * cev + bjadjprob * bjev);
                                    cStrat.GameEVs.UpcardEVs[upcard] += prob * ((1d - bjadjprob) * cev + bjadjprob * bjev);
                                    if (card == card2)
                                    {
                                        cStrat.GameEVs.FirstCardEVs[card] += prob * ((1d - bjadjprob) * cev + bjadjprob * bjev);
                                    }
                                    else
                                    {
                                        cStrat.GameEVs.FirstCardEVs[card] += prob / 2d * ((1d - bjadjprob) * cev + bjadjprob * bjev);
                                        cStrat.GameEVs.FirstCardEVs[card2] += prob / 2d * ((1d - bjadjprob) * cev + bjadjprob * bjev);
                                    }

                                    UndealDCard(upcard);
                                    prob = prob / CardProb(upcard, 0);
                                }
                            }
                            UndealPCard(card2);
                            if (card != card2)
                                prob = prob / 2d;
                            prob = prob / CardProb(card2, 0);
                        }
                    }
                    UndealPCard(card);
                }
            }

            for (card = 1; card <= 10; card++)
            {
                if (cStrat.GameEVs.CardProbs[card] > 0d)
                {
                    cStrat.GameEVs.UpcardEVs[card] /= cStrat.GameEVs.CardProbs[card];
                    cStrat.GameEVs.FirstCardEVs[card] /= cStrat.GameEVs.CardProbs[card];
                }
            }
        }

        private void ComputeGameEVs()
        {
            ComputeGameEVsStrat(ref Opt);
            if (TD.ComputeStrat)
                ComputeGameEVsStrat(ref TD);
            if (TC.ComputeStrat)
                ComputeGameEVsStrat(ref TC);
            if (Forced.ComputeStrat)
                ComputeGameEVsStrat(ref Forced);

        }

        #endregion

        #endregion

        #region  Exceptions Methods 

        private void ComputeExceptions()
        {
            int index;
            int upcard;
            int tdstrat;
            int strat2;
            int Total;
            int Soft;
            int paircard;
            int hands;
            var newException = new BJCAExceptionClass();

            // CD-TD Pre-split Exceptions
            if (TD.ComputeStrat)
            {
                for (upcard = 1; upcard <= 10; upcard++)
                {
                    if (UCAllowed[upcard])
                    {
                        DealDCard(upcard);
                        for (Total = 4; Total <= 21; Total++)
                        {
                            for (Soft = 1; Soft >= 0; Soft -= 1)
                            {
                                index = PlayerHandTotal[Total, Soft];
                                while (index != 0)
                                {
                                    if (PlayerHands[index].HandEVs.Prob[upcard] > 0d & PlayerHands[index].Hand.NumCards >= 2)
                                    {
                                        tdstrat = 0;
                                        if (PlayerHands[index].Hand.NumCards == 2 & (TD.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.P | TD.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.PS | TD.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.PH | TD.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.PD | TD.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.PR))
                                        {
                                            if (PlayerHands[index].Hand.Total == 12 & PlayerHands[index].Hand.Soft)
                                            {
                                                if (HSA == false)
                                                {
                                                    tdstrat = (int)BJCAGlobalsClass.Strat.P;
                                                }
                                            }
                                            else
                                            {
                                                switch (TD.StratTD[Total, Soft].Strat[upcard])
                                                {
                                                    case (int)BJCAGlobalsClass.Strat.S:
                                                        {
                                                            tdstrat = (int)BJCAGlobalsClass.Strat.PS;
                                                            break;
                                                        }
                                                    case (int)BJCAGlobalsClass.Strat.D:
                                                    case (int)BJCAGlobalsClass.Strat.DS:
                                                        {
                                                            tdstrat = (int)BJCAGlobalsClass.Strat.PD;
                                                            break;
                                                        }
                                                    case (int)BJCAGlobalsClass.Strat.H:
                                                        {
                                                            tdstrat = (int)BJCAGlobalsClass.Strat.PH;
                                                            break;
                                                        }
                                                    case (int)BJCAGlobalsClass.Strat.R:
                                                    case (int)BJCAGlobalsClass.Strat.RS:
                                                        {
                                                            tdstrat = (int)BJCAGlobalsClass.Strat.PR;
                                                            break;
                                                        }

                                                    default:
                                                        {
                                                            tdstrat = TD.StratTD[Total, Soft].Strat[upcard];
                                                            break;
                                                        }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            tdstrat = TD.StratTD[Total, Soft].Strat[upcard];
                                            if (!TD.HandEVs[index].DPreallowed[upcard])
                                            {
                                                switch (tdstrat)
                                                {
                                                    case (int)BJCAGlobalsClass.Strat.D:
                                                        {
                                                            tdstrat = (int)BJCAGlobalsClass.Strat.H;
                                                            break;
                                                        }
                                                    case (int)BJCAGlobalsClass.Strat.DS:
                                                        {
                                                            tdstrat = (int)BJCAGlobalsClass.Strat.S;
                                                            break;
                                                        }
                                                }
                                            }
                                            if (Conversions.ToBoolean(~TD.HandEVs[index].RPreallowed[upcard]))
                                            {
                                                switch (tdstrat)
                                                {
                                                    case (int)BJCAGlobalsClass.Strat.R:
                                                        {
                                                            tdstrat = (int)BJCAGlobalsClass.Strat.H;
                                                            break;
                                                        }
                                                    case (int)BJCAGlobalsClass.Strat.RS:
                                                        {
                                                            tdstrat = (int)BJCAGlobalsClass.Strat.S;
                                                            break;
                                                        }
                                                }
                                            }
                                        }

                                        if (Opt.HandEVs[index].EVs.Strat[upcard] != tdstrat & Opt.HandEVs[index].EVs.Strat[upcard] != 0)
                                        {
                                            newException.Empty();
                                            newException.Index = index;
                                            newException.Upcard = upcard;
                                            newException.Paircard = 0;
                                            newException.ExceptionType = (int)BJCAGlobalsClass.ExType.CDTDPre;
                                            newException.SplitHand = 0;
                                            newException.ShoeState = "Pre-Split";
                                            newException.ExceptionName = GetHandString(PlayerHands[index].Hand) + " v " + upcard.ToString() + " " + C.StratShortText[Opt.HandEVs[index].EVs.Strat[upcard]] + " Pre-Split";
                                            ExceptionsList.AddException(newException);
                                        }
                                    }
                                    index = PlayerHands[index].NextHand;
                                }
                            }
                        }
                        UndealDCard(upcard);
                    }
                }
            }

            // CD-Forced Pre-Split Exceptions
            if (Forced.ComputeStrat)
            {
                for (upcard = 1; upcard <= 10; upcard++)
                {
                    if (UCAllowed[upcard])
                    {
                        DealDCard(upcard);
                        for (Total = 4; Total <= 21; Total++)
                        {
                            for (Soft = 1; Soft >= 0; Soft -= 1)
                            {
                                index = PlayerHandTotal[Total, Soft];
                                while (index != 0)
                                {
                                    if (PlayerHands[index].HandEVs.Prob[upcard] > 0d & PlayerHands[index].Hand.NumCards >= 2)
                                    {
                                        if (PlayerHands[index].Hand.NumCards > Forced.NCardsCD)
                                        {
                                            tdstrat = 0;
                                            if (PlayerHands[index].Hand.NumCards == 2 & (Forced.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.P | Forced.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.PS | Forced.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.PH | Forced.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.PD | Forced.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.PR))
                                            {
                                                if (PlayerHands[index].Hand.Total == 12 & PlayerHands[index].Hand.Soft)
                                                {
                                                    if (HSA == false)
                                                    {
                                                        tdstrat = (int)BJCAGlobalsClass.Strat.P;
                                                    }
                                                }
                                                else
                                                {
                                                    switch (Forced.StratTD[Total, Soft].Strat[upcard])
                                                    {
                                                        case (int)BJCAGlobalsClass.Strat.S:
                                                            {
                                                                tdstrat = (int)BJCAGlobalsClass.Strat.PS;
                                                                break;
                                                            }
                                                        case (int)BJCAGlobalsClass.Strat.D:
                                                        case (int)BJCAGlobalsClass.Strat.DS:
                                                            {
                                                                tdstrat = (int)BJCAGlobalsClass.Strat.PD;
                                                                break;
                                                            }
                                                        case (int)BJCAGlobalsClass.Strat.H:
                                                            {
                                                                tdstrat = (int)BJCAGlobalsClass.Strat.PH;
                                                                break;
                                                            }
                                                        case (int)BJCAGlobalsClass.Strat.R:
                                                        case (int)BJCAGlobalsClass.Strat.RS:
                                                            {
                                                                tdstrat = (int)BJCAGlobalsClass.Strat.PR;
                                                                break;
                                                            }

                                                        default:
                                                            {
                                                                tdstrat = Forced.StratTD[Total, Soft].Strat[upcard];
                                                                break;
                                                            }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                tdstrat = Forced.StratTD[Total, Soft].Strat[upcard];
                                                if (!Forced.HandEVs[index].DPreallowed[upcard])
                                                {
                                                    switch (tdstrat)
                                                    {
                                                        case (int)BJCAGlobalsClass.Strat.D:
                                                            {
                                                                tdstrat = (int)BJCAGlobalsClass.Strat.H;
                                                                break;
                                                            }
                                                        case (int)BJCAGlobalsClass.Strat.DS:
                                                            {
                                                                tdstrat = (int)BJCAGlobalsClass.Strat.S;
                                                                break;
                                                            }
                                                    }
                                                }
                                                if (Conversions.ToBoolean(~Forced.HandEVs[index].RPreallowed[upcard]))
                                                {
                                                    switch (tdstrat)
                                                    {
                                                        case (int)BJCAGlobalsClass.Strat.R:
                                                            {
                                                                tdstrat = (int)BJCAGlobalsClass.Strat.H;
                                                                break;
                                                            }
                                                        case (int)BJCAGlobalsClass.Strat.RS:
                                                            {
                                                                tdstrat = (int)BJCAGlobalsClass.Strat.S;
                                                                break;
                                                            }
                                                    }
                                                }
                                            }

                                            if (Opt.HandEVs[index].EVs.Strat[upcard] != tdstrat & Opt.HandEVs[index].EVs.Strat[upcard] != 0)
                                            {
                                                newException.Empty();
                                                newException.Index = index;
                                                newException.Upcard = upcard;
                                                newException.Paircard = 0;
                                                newException.ExceptionType = (int)BJCAGlobalsClass.ExType.CDForcedPre;
                                                newException.SplitHand = 0;
                                                newException.ShoeState = "Pre-Split";
                                                newException.ExceptionName = GetHandString(PlayerHands[index].Hand) + " v " + upcard.ToString() + " " + C.StratShortText[Opt.HandEVs[index].EVs.Strat[upcard]] + " Pre-Split";
                                                ExceptionsList.AddException(newException);
                                            }
                                        }
                                        else if (Opt.HandEVs[index].EVs.Strat[upcard] != Forced.HandEVs[index].EVs.Strat[upcard] & Opt.HandEVs[index].EVs.Strat[upcard] != 0)
                                        {
                                            newException.Empty();
                                            newException.Index = index;
                                            newException.Upcard = upcard;
                                            newException.Paircard = 0;
                                            newException.ExceptionType = (int)BJCAGlobalsClass.ExType.CDForcedPre;
                                            newException.SplitHand = 0;
                                            newException.ShoeState = "Pre-Split";
                                            newException.ExceptionName = GetHandString(PlayerHands[index].Hand) + " v " + upcard.ToString() + " " + C.StratShortText[Opt.HandEVs[index].EVs.Strat[upcard]] + " Pre-Split";
                                            ExceptionsList.AddException(newException);
                                        }
                                    }
                                    index = PlayerHands[index].NextHand;
                                }
                            }
                        }
                        UndealDCard(upcard);
                    }
                }
            }

            // Now look for post-split exceptions
            if (CDP | CDPN)
            {
                // CDP-TD Exceptions
                if (TD.ComputeStrat)
                {
                    for (upcard = 1; upcard <= 10; upcard++)
                    {
                        if (UCAllowed[upcard])
                        {
                            DealDCard(upcard);
                            for (Total = 4; Total <= 21; Total++)
                            {
                                for (Soft = 1; Soft >= 0; Soft -= 1)
                                {
                                    for (paircard = 1; paircard <= 10; paircard++)
                                    {
                                        if (SplitIndex[paircard, upcard] > 0)
                                        {
                                            var loopTo = NSplitHands;
                                            for (hands = 1; hands <= loopTo; hands++)
                                            {
                                                if (NPxHands[hands].Used[SPL] & (NPxHands[hands].NN == 0 | CDPN))
                                                {
                                                    index = PlayerHandTotal[Total, Soft];
                                                    while (index != 0)
                                                    {
                                                        if (PlayerHands[index].HandEVs.Prob[upcard] > 0d & PlayerHands[index].PairIndex[paircard] > 0)
                                                        {
                                                            if (Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands] is not null)
                                                            {
                                                                if (Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].Strat[upcard] != 0 & PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].StandEV[upcard] != 0d)
                                                                {
                                                                    tdstrat = 0;
                                                                    if (PlayerHands[index].Hand.NumCards == 2)
                                                                    {
                                                                        switch (TD.StratTD[Total, Soft].Strat[upcard])
                                                                        {
                                                                            case (int)BJCAGlobalsClass.Strat.PS:
                                                                                {
                                                                                    tdstrat = (int)BJCAGlobalsClass.Strat.S;
                                                                                    break;
                                                                                }
                                                                            case (int)BJCAGlobalsClass.Strat.PD:
                                                                                {
                                                                                    tdstrat = (int)BJCAGlobalsClass.Strat.D;
                                                                                    break;
                                                                                }
                                                                            case (int)BJCAGlobalsClass.Strat.PH:
                                                                                {
                                                                                    tdstrat = (int)BJCAGlobalsClass.Strat.H;
                                                                                    break;
                                                                                }
                                                                            case (int)BJCAGlobalsClass.Strat.PR:
                                                                                {
                                                                                    tdstrat = (int)BJCAGlobalsClass.Strat.R;
                                                                                    break;
                                                                                }

                                                                            default:
                                                                                {
                                                                                    tdstrat = TD.StratTD[Total, Soft].Strat[upcard];
                                                                                    break;
                                                                                }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        tdstrat = TD.StratTD[Total, Soft].Strat[upcard];
                                                                    }
                                                                    if (!TD.HandEVs[index].DPostallowed[upcard])
                                                                    {
                                                                        switch (tdstrat)
                                                                        {
                                                                            case (int)BJCAGlobalsClass.Strat.D:
                                                                                {
                                                                                    tdstrat = (int)BJCAGlobalsClass.Strat.H;
                                                                                    break;
                                                                                }
                                                                            case (int)BJCAGlobalsClass.Strat.DS:
                                                                                {
                                                                                    tdstrat = (int)BJCAGlobalsClass.Strat.S;
                                                                                    break;
                                                                                }
                                                                        }
                                                                    }
                                                                    if (Conversions.ToBoolean(~TD.HandEVs[index].RPostallowed[upcard]))
                                                                    {
                                                                        switch (tdstrat)
                                                                        {
                                                                            case (int)BJCAGlobalsClass.Strat.R:
                                                                                {
                                                                                    tdstrat = (int)BJCAGlobalsClass.Strat.H;
                                                                                    break;
                                                                                }
                                                                            case (int)BJCAGlobalsClass.Strat.RS:
                                                                                {
                                                                                    tdstrat = (int)BJCAGlobalsClass.Strat.S;
                                                                                    break;
                                                                                }
                                                                        }
                                                                    }

                                                                    switch (Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].Strat[upcard])
                                                                    {
                                                                        case (int)BJCAGlobalsClass.Strat.PS:
                                                                            {
                                                                                strat2 = (int)BJCAGlobalsClass.Strat.S;
                                                                                break;
                                                                            }
                                                                        case (int)BJCAGlobalsClass.Strat.PD:
                                                                            {
                                                                                strat2 = (int)BJCAGlobalsClass.Strat.D;
                                                                                break;
                                                                            }
                                                                        case (int)BJCAGlobalsClass.Strat.PH:
                                                                            {
                                                                                strat2 = (int)BJCAGlobalsClass.Strat.H;
                                                                                break;
                                                                            }
                                                                        case (int)BJCAGlobalsClass.Strat.PR:
                                                                            {
                                                                                strat2 = (int)BJCAGlobalsClass.Strat.R;
                                                                                break;
                                                                            }

                                                                        default:
                                                                            {
                                                                                strat2 = Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].Strat[upcard];
                                                                                break;
                                                                            }
                                                                    }
                                                                    if (strat2 != tdstrat)
                                                                    {
                                                                        newException.Empty();
                                                                        newException.Index = index;
                                                                        newException.Upcard = upcard;
                                                                        newException.Paircard = paircard;
                                                                        newException.ExceptionType = (int)BJCAGlobalsClass.ExType.CDTDPost;
                                                                        newException.SplitHand = hands;
                                                                        newException.ShoeState = paircard.ToString() + "  " + NPxHands[hands].Name;
                                                                        newException.ExceptionName = GetHandString(PlayerHands[index].Hand) + " v " + upcard.ToString() + " " + C.StratShortText[strat2] + " Post-Split " + paircard.ToString() + "  " + NPxHands[hands].Name;
                                                                        ExceptionsList.AddException(newException);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        index = PlayerHands[index].NextHand;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            UndealDCard(upcard);
                        }
                    }
                }

                // CDP-Forced Exceptions
                if (Forced.ComputeStrat)
                {
                    for (upcard = 1; upcard <= 10; upcard++)
                    {
                        if (UCAllowed[upcard])
                        {
                            DealDCard(upcard);
                            for (Total = 4; Total <= 21; Total++)
                            {
                                for (Soft = 1; Soft >= 0; Soft -= 1)
                                {
                                    for (paircard = 1; paircard <= 10; paircard++)
                                    {
                                        if (SplitIndex[paircard, upcard] > 0)
                                        {
                                            var loopTo1 = NSplitHands;
                                            for (hands = 1; hands <= loopTo1; hands++)
                                            {
                                                if (NPxHands[hands].Used[SPL] & (NPxHands[hands].NN == 0 | CDPN))
                                                {
                                                    index = PlayerHandTotal[Total, Soft];
                                                    while (index != 0)
                                                    {
                                                        if (PlayerHands[index].HandEVs.Prob[upcard] > 0d & PlayerHands[index].PairIndex[paircard] > 0)
                                                        {
                                                            if (Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands] is not null)
                                                            {
                                                                if (Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].Strat[upcard] != 0 & PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].StandEV[upcard] != 0d)
                                                                {
                                                                    if (PlayerHands[index].Hand.NumCards > Forced.NCardsCD)
                                                                    {
                                                                        tdstrat = 0;
                                                                        if (PlayerHands[index].Hand.NumCards == 2)
                                                                        {
                                                                            switch (Forced.StratTD[Total, Soft].Strat[upcard])
                                                                            {
                                                                                case (int)BJCAGlobalsClass.Strat.PS:
                                                                                    {
                                                                                        tdstrat = (int)BJCAGlobalsClass.Strat.S;
                                                                                        break;
                                                                                    }
                                                                                case (int)BJCAGlobalsClass.Strat.PD:
                                                                                    {
                                                                                        tdstrat = (int)BJCAGlobalsClass.Strat.D;
                                                                                        break;
                                                                                    }
                                                                                case (int)BJCAGlobalsClass.Strat.PH:
                                                                                    {
                                                                                        tdstrat = (int)BJCAGlobalsClass.Strat.H;
                                                                                        break;
                                                                                    }
                                                                                case (int)BJCAGlobalsClass.Strat.PR:
                                                                                    {
                                                                                        tdstrat = (int)BJCAGlobalsClass.Strat.R;
                                                                                        break;
                                                                                    }

                                                                                default:
                                                                                    {
                                                                                        tdstrat = Forced.StratTD[Total, Soft].Strat[upcard];
                                                                                        break;
                                                                                    }
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            tdstrat = Forced.StratTD[Total, Soft].Strat[upcard];
                                                                        }
                                                                        if (!Forced.HandEVs[index].DPostallowed[upcard])
                                                                        {
                                                                            switch (tdstrat)
                                                                            {
                                                                                case (int)BJCAGlobalsClass.Strat.D:
                                                                                    {
                                                                                        tdstrat = (int)BJCAGlobalsClass.Strat.H;
                                                                                        break;
                                                                                    }
                                                                                case (int)BJCAGlobalsClass.Strat.DS:
                                                                                    {
                                                                                        tdstrat = (int)BJCAGlobalsClass.Strat.S;
                                                                                        break;
                                                                                    }
                                                                            }
                                                                        }
                                                                        if (Conversions.ToBoolean(~Forced.HandEVs[index].RPostallowed[upcard]))
                                                                        {
                                                                            switch (tdstrat)
                                                                            {
                                                                                case (int)BJCAGlobalsClass.Strat.R:
                                                                                    {
                                                                                        tdstrat = (int)BJCAGlobalsClass.Strat.H;
                                                                                        break;
                                                                                    }
                                                                                case (int)BJCAGlobalsClass.Strat.RS:
                                                                                    {
                                                                                        tdstrat = (int)BJCAGlobalsClass.Strat.S;
                                                                                        break;
                                                                                    }
                                                                            }
                                                                        }

                                                                        switch (Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].Strat[upcard])
                                                                        {
                                                                            case (int)BJCAGlobalsClass.Strat.PS:
                                                                                {
                                                                                    strat2 = (int)BJCAGlobalsClass.Strat.S;
                                                                                    break;
                                                                                }
                                                                            case (int)BJCAGlobalsClass.Strat.PD:
                                                                                {
                                                                                    strat2 = (int)BJCAGlobalsClass.Strat.D;
                                                                                    break;
                                                                                }
                                                                            case (int)BJCAGlobalsClass.Strat.PH:
                                                                                {
                                                                                    strat2 = (int)BJCAGlobalsClass.Strat.H;
                                                                                    break;
                                                                                }
                                                                            case (int)BJCAGlobalsClass.Strat.PR:
                                                                                {
                                                                                    strat2 = (int)BJCAGlobalsClass.Strat.R;
                                                                                    break;
                                                                                }

                                                                            default:
                                                                                {
                                                                                    strat2 = Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].Strat[upcard];
                                                                                    break;
                                                                                }
                                                                        }
                                                                        if (strat2 != tdstrat)
                                                                        {
                                                                            newException.Empty();
                                                                            newException.Index = index;
                                                                            newException.Upcard = upcard;
                                                                            newException.Paircard = paircard;
                                                                            newException.ExceptionType = (int)BJCAGlobalsClass.ExType.CDTDPost;
                                                                            newException.SplitHand = hands;
                                                                            newException.ShoeState = paircard.ToString() + "  " + NPxHands[hands].Name;
                                                                            newException.ExceptionName = GetHandString(PlayerHands[index].Hand) + " v " + upcard.ToString() + " " + C.StratShortText[strat2] + " Post-Split " + paircard.ToString() + "  " + NPxHands[hands].Name;
                                                                            ExceptionsList.AddException(newException);
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        switch (Forced.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].Strat[upcard])
                                                                        {
                                                                            case (int)BJCAGlobalsClass.Strat.PS:
                                                                                {
                                                                                    tdstrat = (int)BJCAGlobalsClass.Strat.S;
                                                                                    break;
                                                                                }
                                                                            case (int)BJCAGlobalsClass.Strat.PD:
                                                                                {
                                                                                    tdstrat = (int)BJCAGlobalsClass.Strat.D;
                                                                                    break;
                                                                                }
                                                                            case (int)BJCAGlobalsClass.Strat.PH:
                                                                                {
                                                                                    tdstrat = (int)BJCAGlobalsClass.Strat.H;
                                                                                    break;
                                                                                }
                                                                            case (int)BJCAGlobalsClass.Strat.PR:
                                                                                {
                                                                                    tdstrat = (int)BJCAGlobalsClass.Strat.R;
                                                                                    break;
                                                                                }

                                                                            default:
                                                                                {
                                                                                    tdstrat = Forced.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].Strat[upcard];
                                                                                    break;
                                                                                }
                                                                        }
                                                                        switch (Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].Strat[upcard])
                                                                        {
                                                                            case (int)BJCAGlobalsClass.Strat.PS:
                                                                                {
                                                                                    strat2 = (int)BJCAGlobalsClass.Strat.S;
                                                                                    break;
                                                                                }
                                                                            case (int)BJCAGlobalsClass.Strat.PD:
                                                                                {
                                                                                    strat2 = (int)BJCAGlobalsClass.Strat.D;
                                                                                    break;
                                                                                }
                                                                            case (int)BJCAGlobalsClass.Strat.PH:
                                                                                {
                                                                                    strat2 = (int)BJCAGlobalsClass.Strat.H;
                                                                                    break;
                                                                                }
                                                                            case (int)BJCAGlobalsClass.Strat.PR:
                                                                                {
                                                                                    strat2 = (int)BJCAGlobalsClass.Strat.R;
                                                                                    break;
                                                                                }

                                                                            default:
                                                                                {
                                                                                    strat2 = Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].Strat[upcard];
                                                                                    break;
                                                                                }
                                                                        }
                                                                        if (strat2 != tdstrat)
                                                                        {
                                                                            newException.Empty();
                                                                            newException.Index = index;
                                                                            newException.Upcard = upcard;
                                                                            newException.Paircard = paircard;
                                                                            newException.ExceptionType = (int)BJCAGlobalsClass.ExType.CDForcedPost;
                                                                            newException.SplitHand = hands;
                                                                            newException.ShoeState = paircard.ToString() + "  " + NPxHands[hands].Name;
                                                                            newException.ExceptionName = GetHandString(PlayerHands[index].Hand) + " v " + upcard.ToString() + " " + C.StratShortText[strat2] + " Post-Split " + paircard.ToString() + "  " + NPxHands[hands].Name;
                                                                            ExceptionsList.AddException(newException);
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        index = PlayerHands[index].NextHand;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            UndealDCard(upcard);
                        }
                    }
                }

                // CDP-CD Exceptions
                for (upcard = 1; upcard <= 10; upcard++)
                {
                    if (UCAllowed[upcard])
                    {
                        DealDCard(upcard);
                        for (Total = 4; Total <= 21; Total++)
                        {
                            for (Soft = 1; Soft >= 0; Soft -= 1)
                            {
                                for (paircard = 1; paircard <= 10; paircard++)
                                {
                                    if (SplitIndex[paircard, upcard] > 0)
                                    {
                                        var loopTo2 = NSplitHands;
                                        for (hands = 1; hands <= loopTo2; hands++)
                                        {
                                            if (NPxHands[hands].Used[SPL] & (NPxHands[hands].NN == 0 | CDPN))
                                            {
                                                index = PlayerHandTotal[Total, Soft];
                                                while (index != 0)
                                                {
                                                    if (PlayerHands[index].HandEVs.Prob[upcard] > 0d & PlayerHands[index].PairIndex[paircard] > 0)
                                                    {
                                                        if (Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands] is not null)
                                                        {
                                                            if (Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].Strat[upcard] != 0 & PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].StandEV[upcard] != 0d)
                                                            {
                                                                if (Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].Strat[upcard] != Opt.HandEVs[index].EVs.Strat[upcard])
                                                                {
                                                                    newException.Empty();
                                                                    newException.Index = index;
                                                                    newException.Upcard = upcard;
                                                                    newException.Paircard = paircard;
                                                                    newException.ExceptionType = (int)BJCAGlobalsClass.ExType.CDCDPost;
                                                                    newException.SplitHand = hands;
                                                                    newException.ShoeState = paircard.ToString() + "  " + NPxHands[hands].Name;
                                                                    newException.ExceptionName = GetHandString(PlayerHands[index].Hand) + " v " + upcard.ToString() + " " + C.StratShortText[Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].Strat[upcard]] + " Post-Split " + paircard.ToString() + "  " + NPxHands[hands].Name;
                                                                    ExceptionsList.AddException(newException);
                                                                }
                                                            }
                                                        }
                                                    }
                                                    index = PlayerHands[index].NextHand;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        UndealDCard(upcard);
                    }
                }
            }

        }

        private void ComputeNCardExceptions()
        {
            int total;
            int soft;
            int upcard;
            int nCards;
            bool stratSame;
            var strat = new BJCAStrategyClass();
            var newException = new BJCANCardExceptionClass();

            if (TD.ComputeStrat)
            {
                for (total = 4; total <= 21; total++)
                {
                    for (soft = 0; soft <= 1; soft++)
                    {
                        for (upcard = 1; upcard <= 10; upcard++)
                        {
                            for (nCards = 2; nCards <= 21; nCards++)
                            {
                                if (TD.StratTD[total, soft] is not null)
                                {
                                    if (TD.StratTD[total, soft].NetProb[upcard] > 0d & TD.StratTD[total, soft].Strat[upcard] != (int)BJCAGlobalsClass.Strat.None)
                                    {
                                        var newEvs = new BJCATDStratClass();

                                        newEvs = ComputeNCardStratEVs(ref TD, total, soft, upcard, nCards, false, false, true);

                                        switch (TD.StratTD[total, soft].Strat[upcard])
                                        {
                                            case (int)BJCAGlobalsClass.Strat.D:
                                                {
                                                    if (newEvs.NetDProb[upcard] == 0d)
                                                    {
                                                        stratSame = newEvs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.H;
                                                    }
                                                    else
                                                    {
                                                        stratSame = newEvs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.D;
                                                    }

                                                    break;
                                                }
                                            case (int)BJCAGlobalsClass.Strat.DS:
                                                {
                                                    if (newEvs.NetDProb[upcard] == 0d)
                                                    {
                                                        stratSame = newEvs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.S;
                                                    }
                                                    else
                                                    {
                                                        stratSame = newEvs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.D;
                                                    }

                                                    break;
                                                }
                                            case (int)BJCAGlobalsClass.Strat.R:
                                                {
                                                    if (newEvs.NetSurrProb[upcard] == 0d)
                                                    {
                                                        stratSame = newEvs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.H;
                                                    }
                                                    else
                                                    {
                                                        stratSame = newEvs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.R;
                                                    }

                                                    break;
                                                }
                                            case (int)BJCAGlobalsClass.Strat.RS:
                                                {
                                                    if (newEvs.NetSurrProb[upcard] == 0d)
                                                    {
                                                        stratSame = newEvs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.S;
                                                    }
                                                    else
                                                    {
                                                        stratSame = newEvs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.R;
                                                    }

                                                    break;
                                                }

                                            default:
                                                {
                                                    stratSame = newEvs.Strat[upcard] == TD.StratTD[total, soft].Strat[upcard];
                                                    break;
                                                }
                                        }
                                        if (newEvs.NetProb[upcard] != 0d & !stratSame)
                                        {
                                            newException.Total = total;
                                            newException.Soft = soft == 0;
                                            newException.Upcard = upcard;
                                            newException.NCards = nCards;

                                            newException.Strat = newEvs.Strat[upcard];
                                            newException.SEV = newEvs.StratStandEV[upcard];
                                            newException.HEV = newEvs.StratHitEV[upcard];
                                            newException.DEV = newEvs.StratDEV[upcard];
                                            newException.SurrEV = newEvs.StratSurrEV[upcard];
                                            newException.ExceptionType = (int)BJCAGlobalsClass.ExType.TDTD;
                                            newException.ExceptionName = nCards.ToString() + "-Card ";
                                            if (soft == 0)
                                            {
                                                newException.ExceptionName += "S";
                                            }
                                            else
                                            {
                                                newException.ExceptionName += "H";
                                            }
                                            newException.ExceptionName += total.ToString() + " v " + upcard.ToString() + " " + C.StratShortText[newEvs.Strat[upcard]];

                                            NCardExceptionsList.AddException(newException);
                                        }

                                        newEvs = null;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (TC.ComputeStrat)
            {
                for (total = 4; total <= 21; total++)
                {
                    for (soft = 0; soft <= 1; soft++)
                    {
                        for (upcard = 1; upcard <= 10; upcard++)
                        {
                            for (nCards = 2; nCards <= 21; nCards++)
                            {
                                if (TC.StratTD[total, soft] is not null)
                                {
                                    if (TC.StratTD[total, soft].NetProb[upcard] > 0d & TC.StratTD[total, soft].Strat[upcard] != (int)BJCAGlobalsClass.Strat.None)
                                    {
                                        var newEvs = new BJCATDStratClass();

                                        newEvs = ComputeNCardStratEVs(ref TC, total, soft, upcard, nCards, false, false, true);
                                        switch (TC.StratTD[total, soft].Strat[upcard])
                                        {
                                            case (int)BJCAGlobalsClass.Strat.D:
                                                {
                                                    if (newEvs.NetDProb[upcard] == 0d)
                                                    {
                                                        stratSame = newEvs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.H;
                                                    }
                                                    else
                                                    {
                                                        stratSame = newEvs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.D;
                                                    }

                                                    break;
                                                }
                                            case (int)BJCAGlobalsClass.Strat.DS:
                                                {
                                                    if (newEvs.NetDProb[upcard] == 0d)
                                                    {
                                                        stratSame = newEvs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.S;
                                                    }
                                                    else
                                                    {
                                                        stratSame = newEvs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.D;
                                                    }

                                                    break;
                                                }
                                            case (int)BJCAGlobalsClass.Strat.R:
                                                {
                                                    if (newEvs.NetSurrProb[upcard] == 0d)
                                                    {
                                                        stratSame = newEvs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.H;
                                                    }
                                                    else
                                                    {
                                                        stratSame = newEvs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.R;
                                                    }

                                                    break;
                                                }
                                            case (int)BJCAGlobalsClass.Strat.RS:
                                                {
                                                    if (newEvs.NetSurrProb[upcard] == 0d)
                                                    {
                                                        stratSame = newEvs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.S;
                                                    }
                                                    else
                                                    {
                                                        stratSame = newEvs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.R;
                                                    }

                                                    break;
                                                }

                                            default:
                                                {
                                                    stratSame = newEvs.Strat[upcard] == TC.StratTD[total, soft].Strat[upcard];
                                                    break;
                                                }
                                        }
                                        if (newEvs.NetProb[upcard] != 0d & !stratSame)
                                        {
                                            newException.Total = total;
                                            newException.Soft = soft == 0;
                                            newException.Upcard = upcard;
                                            newException.NCards = nCards;

                                            newException.Strat = newEvs.Strat[upcard];
                                            newException.SEV = newEvs.StratStandEV[upcard];
                                            newException.HEV = newEvs.StratHitEV[upcard];
                                            newException.DEV = newEvs.StratDEV[upcard];
                                            newException.SurrEV = newEvs.StratSurrEV[upcard];
                                            newException.ExceptionType = (int)BJCAGlobalsClass.ExType.TCTC;
                                            newException.ExceptionName = nCards.ToString() + "-Card ";
                                            if (soft == 0)
                                            {
                                                newException.ExceptionName += "S";
                                            }
                                            else
                                            {
                                                newException.ExceptionName += "H";
                                            }
                                            newException.ExceptionName += total.ToString() + " v " + upcard.ToString() + " " + C.StratShortText[newEvs.Strat[upcard]];

                                            NCardExceptionsList.AddException(newException);
                                        }

                                        newEvs = null;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (Forced.ComputeStrat)
            {
                for (total = 4; total <= 21; total++)
                {
                    for (soft = 0; soft <= 1; soft++)
                    {
                        for (upcard = 1; upcard <= 10; upcard++)
                        {
                            for (nCards = 2; nCards <= 21; nCards++)
                            {
                                if (Forced.StratTD[total, soft] is not null)
                                {
                                    if (Forced.StratTD[total, soft].NetProb[upcard] > 0d & Forced.StratTD[total, soft].Strat[upcard] != (int)BJCAGlobalsClass.Strat.None)
                                    {
                                        var newEvs = new BJCATDStratClass();

                                        newEvs = ComputeNCardStratEVs(ref Forced, total, soft, upcard, nCards, false, false, true);
                                        switch (Forced.StratTD[total, soft].Strat[upcard])
                                        {
                                            case (int)BJCAGlobalsClass.Strat.D:
                                                {
                                                    if (newEvs.NetDProb[upcard] == 0d)
                                                    {
                                                        stratSame = newEvs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.H;
                                                    }
                                                    else
                                                    {
                                                        stratSame = newEvs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.D;
                                                    }

                                                    break;
                                                }
                                            case (int)BJCAGlobalsClass.Strat.DS:
                                                {
                                                    if (newEvs.NetDProb[upcard] == 0d)
                                                    {
                                                        stratSame = newEvs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.S;
                                                    }
                                                    else
                                                    {
                                                        stratSame = newEvs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.D;
                                                    }

                                                    break;
                                                }
                                            case (int)BJCAGlobalsClass.Strat.R:
                                                {
                                                    if (newEvs.NetSurrProb[upcard] == 0d)
                                                    {
                                                        stratSame = newEvs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.H;
                                                    }
                                                    else
                                                    {
                                                        stratSame = newEvs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.R;
                                                    }

                                                    break;
                                                }
                                            case (int)BJCAGlobalsClass.Strat.RS:
                                                {
                                                    if (newEvs.NetSurrProb[upcard] == 0d)
                                                    {
                                                        stratSame = newEvs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.S;
                                                    }
                                                    else
                                                    {
                                                        stratSame = newEvs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.R;
                                                    }

                                                    break;
                                                }

                                            default:
                                                {
                                                    stratSame = newEvs.Strat[upcard] == Forced.StratTD[total, soft].Strat[upcard];
                                                    break;
                                                }
                                        }
                                        if (newEvs.NetProb[upcard] != 0d & !stratSame)
                                        {
                                            newException.Total = total;
                                            newException.Soft = soft == 0;
                                            newException.Upcard = upcard;
                                            newException.NCards = nCards;

                                            newException.Strat = newEvs.Strat[upcard];
                                            newException.SEV = newEvs.StratStandEV[upcard];
                                            newException.HEV = newEvs.StratHitEV[upcard];
                                            newException.DEV = newEvs.StratDEV[upcard];
                                            newException.SurrEV = newEvs.StratSurrEV[upcard];
                                            newException.ExceptionType = (int)BJCAGlobalsClass.ExType.ForcedForced;
                                            newException.ExceptionName = nCards.ToString() + "-Card ";
                                            if (soft == 0)
                                            {
                                                newException.ExceptionName += "S";
                                            }
                                            else
                                            {
                                                newException.ExceptionName += "H";
                                            }
                                            newException.ExceptionName += total.ToString() + " v " + upcard.ToString() + " " + C.StratShortText[newEvs.Strat[upcard]];

                                            NCardExceptionsList.AddException(newException);
                                        }

                                        newEvs = null;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        #endregion

        #region  Output Methods 

        // Fills in a copy of the results workbook template (ExcelFilePath) and saves it as outputFile.
        public void PrintToExcel(string outputFile)
        {
            using (var oexcelbook = new XLWorkbook(ExcelFilePath))
            {
                PrintStrategiesExcel(oexcelbook);
                PrintSplitEVsExcel(oexcelbook);
                PrintGameEVsExcel(oexcelbook);
                PrintStrategyEVsExcel(oexcelbook);
                PrintExceptionsExcel(oexcelbook);
                PrintRulesExcel(oexcelbook);

                // Open on the Strategy Table, and have Excel recalculate the template's own formulas.
                foreach (var sheet in oexcelbook.Worksheets)
                    sheet.TabSelected = false;
                oexcelbook.Worksheet("Strategy Table").SetTabActive().TabSelected = true;
                oexcelbook.FullCalculationOnLoad = true;

                oexcelbook.SaveAs(outputFile);
            }
        }

        private void PrintStrategiesExcel(XLWorkbook workBook)
        {
            IXLWorksheet worksheet;
            int Total;
            int upcard;
            int card;
            int card2;
            int index;
            int column;
            int row;

            worksheet = workBook.Worksheet("Strategy Table");
            worksheet.Range("C4:L21").ClearContents();
            worksheet.Range("C4:L21").Style.Fill.BackgroundColor = XLColor.FromArgb(255, 255, 255);
            worksheet.Range("C25:L34").ClearContents();
            worksheet.Range("C25:L34").Style.Fill.BackgroundColor = XLColor.FromArgb(255, 255, 255);
            worksheet.Range("C38:L47").ClearContents();
            worksheet.Range("C38:L47").Style.Fill.BackgroundColor = XLColor.FromArgb(255, 255, 255);
            worksheet.Range("C51:L86").ClearContents();
            worksheet.Range("C51:L86").Style.Fill.BackgroundColor = XLColor.FromArgb(255, 255, 255);
            worksheet.Range("C90:L98").ClearContents();
            worksheet.Range("C90:L98").Style.Fill.BackgroundColor = XLColor.FromArgb(255, 255, 255);
            worksheet.Range("C102:L111").ClearContents();
            worksheet.Range("C102:L111").Style.Fill.BackgroundColor = XLColor.FromArgb(255, 255, 255);
            worksheet.Range("C115:L132").ClearContents();
            worksheet.Range("C115:L132").Style.Fill.BackgroundColor = XLColor.FromArgb(255, 255, 255);
            worksheet.Range("C136:L145").ClearContents();
            worksheet.Range("C136:L145").Style.Fill.BackgroundColor = XLColor.FromArgb(255, 255, 255);
            worksheet.Range("C149:L184").ClearContents();
            worksheet.Range("C149:L184").Style.Fill.BackgroundColor = XLColor.FromArgb(255, 255, 255);
            worksheet.Range("C188:L196").ClearContents();
            worksheet.Range("C188:L196").Style.Fill.BackgroundColor = XLColor.FromArgb(255, 255, 255);
            worksheet.Range("C200:L209").ClearContents();
            worksheet.Range("C200:L209").Style.Fill.BackgroundColor = XLColor.FromArgb(255, 255, 255);

            worksheet.Range("C213:L248").ClearContents();
            worksheet.Range("C213:L248").Style.Fill.BackgroundColor = XLColor.FromArgb(255, 255, 255);
            worksheet.Range("C252:L260").ClearContents();
            worksheet.Range("C252:L260").Style.Fill.BackgroundColor = XLColor.FromArgb(255, 255, 255);
            worksheet.Range("C264:L273").ClearContents();
            worksheet.Range("C264:L273").Style.Fill.BackgroundColor = XLColor.FromArgb(255, 255, 255);
            worksheet.Range("C277:L294").ClearContents();
            worksheet.Range("C277:L294").Style.Fill.BackgroundColor = XLColor.FromArgb(255, 255, 255);
            worksheet.Range("C298:L307").ClearContents();
            worksheet.Range("C298:L307").Style.Fill.BackgroundColor = XLColor.FromArgb(255, 255, 255);
            worksheet.Range("A1").SelectOnly();

            // Fill in color table in worksheet
            worksheet.Range("O4").Style.Fill.BackgroundColor = XLColor.FromArgb(ColorTable.C[(int)BJCAGlobalsClass.Strat.None].R, ColorTable.C[(int)BJCAGlobalsClass.Strat.None].G, ColorTable.C[(int)BJCAGlobalsClass.Strat.None].B);
            worksheet.Range("O5").Style.Fill.BackgroundColor = XLColor.FromArgb(ColorTable.C[(int)BJCAGlobalsClass.Strat.S].R, ColorTable.C[(int)BJCAGlobalsClass.Strat.S].G, ColorTable.C[(int)BJCAGlobalsClass.Strat.S].B);
            worksheet.Range("O6").Style.Fill.BackgroundColor = XLColor.FromArgb(ColorTable.C[(int)BJCAGlobalsClass.Strat.H].R, ColorTable.C[(int)BJCAGlobalsClass.Strat.H].G, ColorTable.C[(int)BJCAGlobalsClass.Strat.H].B);
            worksheet.Range("O7").Style.Fill.BackgroundColor = XLColor.FromArgb(ColorTable.C[(int)BJCAGlobalsClass.Strat.D].R, ColorTable.C[(int)BJCAGlobalsClass.Strat.D].G, ColorTable.C[(int)BJCAGlobalsClass.Strat.D].B);
            worksheet.Range("O8").Style.Fill.BackgroundColor = XLColor.FromArgb(ColorTable.C[(int)BJCAGlobalsClass.Strat.DS].R, ColorTable.C[(int)BJCAGlobalsClass.Strat.DS].G, ColorTable.C[(int)BJCAGlobalsClass.Strat.DS].B);
            worksheet.Range("O9").Style.Fill.BackgroundColor = XLColor.FromArgb(ColorTable.C[(int)BJCAGlobalsClass.Strat.R].R, ColorTable.C[(int)BJCAGlobalsClass.Strat.R].G, ColorTable.C[(int)BJCAGlobalsClass.Strat.R].B);
            worksheet.Range("O10").Style.Fill.BackgroundColor = XLColor.FromArgb(ColorTable.C[(int)BJCAGlobalsClass.Strat.RS].R, ColorTable.C[(int)BJCAGlobalsClass.Strat.RS].G, ColorTable.C[(int)BJCAGlobalsClass.Strat.RS].B);
            worksheet.Range("O11").Style.Fill.BackgroundColor = XLColor.FromArgb(ColorTable.C[(int)BJCAGlobalsClass.Strat.P].R, ColorTable.C[(int)BJCAGlobalsClass.Strat.P].G, ColorTable.C[(int)BJCAGlobalsClass.Strat.P].B);
            worksheet.Range("O12").Style.Fill.BackgroundColor = XLColor.FromArgb(ColorTable.C[(int)BJCAGlobalsClass.Strat.PS].R, ColorTable.C[(int)BJCAGlobalsClass.Strat.PS].G, ColorTable.C[(int)BJCAGlobalsClass.Strat.PS].B);
            worksheet.Range("O13").Style.Fill.BackgroundColor = XLColor.FromArgb(ColorTable.C[(int)BJCAGlobalsClass.Strat.PH].R, ColorTable.C[(int)BJCAGlobalsClass.Strat.PH].G, ColorTable.C[(int)BJCAGlobalsClass.Strat.PH].B);
            worksheet.Range("O14").Style.Fill.BackgroundColor = XLColor.FromArgb(ColorTable.C[(int)BJCAGlobalsClass.Strat.PD].R, ColorTable.C[(int)BJCAGlobalsClass.Strat.PD].G, ColorTable.C[(int)BJCAGlobalsClass.Strat.PD].B);
            worksheet.Range("O15").Style.Fill.BackgroundColor = XLColor.FromArgb(ColorTable.C[(int)BJCAGlobalsClass.Strat.PR].R, ColorTable.C[(int)BJCAGlobalsClass.Strat.PR].G, ColorTable.C[(int)BJCAGlobalsClass.Strat.PR].B);

            CurrentShoe.Reset(OriginalShoe);
            CurrentPHand.Empty();

            // Print Total Dependent Hard Strategies
            if (TD.ComputeStrat)
            {
                for (Total = 4; Total <= 21; Total++)
                {
                    for (upcard = 1; upcard <= 10; upcard++)
                    {
                        if (UCAllowed[upcard])
                        {
                            if (upcard == 1)
                            {
                                column = 9;
                            }
                            else
                            {
                                column = upcard - 2;
                            }
                            worksheet.Range("C4").Offset(Total - 4, column).SetExcelValue(C.StratLongText[TD.StratTD[Total, Conversions.ToInteger(false) + 1].Strat[upcard]]);
                            worksheet.Range("C4").Offset(Total - 4, column).Style.Fill.BackgroundColor = XLColor.FromArgb(ColorTable.C[TD.StratTD[Total, Conversions.ToInteger(false) + 1].Strat[upcard]].R, ColorTable.C[TD.StratTD[Total, Conversions.ToInteger(false) + 1].Strat[upcard]].G, ColorTable.C[TD.StratTD[Total, Conversions.ToInteger(false) + 1].Strat[upcard]].B);
                        }
                    }
                }

                // Print Total Dependent Soft Hands
                for (Total = 12; Total <= 21; Total++)
                {
                    for (upcard = 1; upcard <= 10; upcard++)
                    {
                        if (UCAllowed[upcard])
                        {
                            if (upcard == 1)
                            {
                                column = 9;
                            }
                            else
                            {
                                column = upcard - 2;
                            }
                            worksheet.Range("C25").Offset(Total - 12, column).SetExcelValue(C.StratLongText[TD.StratTD[Total, Conversions.ToInteger(true) + 1].Strat[upcard]]);
                            worksheet.Range("C25").Offset(Total - 12, column).Style.Fill.BackgroundColor = XLColor.FromArgb(ColorTable.C[TD.StratTD[Total, Conversions.ToInteger(true) + 1].Strat[upcard]].R, ColorTable.C[TD.StratTD[Total, Conversions.ToInteger(true) + 1].Strat[upcard]].G, ColorTable.C[TD.StratTD[Total, Conversions.ToInteger(true) + 1].Strat[upcard]].B);
                        }
                    }
                }

                // Print Total Dependent Splits
                if (SPL > 0)
                {
                    for (card = 1; card <= 10; card++)
                    {
                        for (upcard = 1; upcard <= 10; upcard++)
                        {
                            if (CurrentShoe.Cards[card] >= 2 & UCAllowed[upcard])
                            {
                                DealPCard(card);
                                DealPCard(card);
                                index = FindPlayerHand(CurrentPHand);
                                UndealPCard(card);
                                UndealPCard(card);
                                if (upcard == 1)
                                {
                                    column = 9;
                                }
                                else
                                {
                                    column = upcard - 2;
                                }
                                if (TD.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.P | TD.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.PS | TD.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.PH | TD.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.PD | TD.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.PR)
                                {
                                    worksheet.Range("C38").Offset(card - 1, column).SetExcelValue(C.StratLongText[TD.HandEVs[index].EVs.Strat[upcard]]);
                                    worksheet.Range("C38").Offset(card - 1, column).Style.Fill.BackgroundColor = XLColor.FromArgb(ColorTable.C[TD.HandEVs[index].EVs.Strat[upcard]].R, ColorTable.C[TD.HandEVs[index].EVs.Strat[upcard]].G, ColorTable.C[TD.HandEVs[index].EVs.Strat[upcard]].B);
                                }
                                else
                                {
                                    worksheet.Range("C38").Offset(card - 1, column).SetExcelValue(C.StratLongText[0]);
                                    worksheet.Range("C38").Offset(card - 1, column).Style.Fill.BackgroundColor = XLColor.FromArgb(ColorTable.C[0].R, ColorTable.C[0].G, ColorTable.C[0].B);
                                }
                            }
                        }
                    }
                }
            }

            // Print 2 Card Dependent Hard Strategies
            if (TC.ComputeStrat)
            {
                row = 0;
                for (Total = 5; Total <= 19; Total++)
                {
                    if (Total < 13)
                    {
                        card = 2;
                    }
                    else
                    {
                        card = Total - 10;
                    }
                    card2 = Total - card;
                    do
                    {
                        if (CardProb(card, 0) > 0d)
                        {
                            DealPCard(card);
                            if (CardProb(card2, 0) > 0d)
                            {
                                DealPCard(card2);
                                index = FindPlayerHand(CurrentPHand);
                                for (upcard = 1; upcard <= 10; upcard++)
                                {
                                    if (UCAllowed[upcard])
                                    {
                                        if (upcard == 1)
                                        {
                                            column = 9;
                                        }
                                        else
                                        {
                                            column = upcard - 2;
                                        }
                                        worksheet.Range("C51").Offset(row, column).SetExcelValue(C.StratLongText[TC.HandEVs[index].EVs.Strat[upcard]]);
                                        worksheet.Range("C51").Offset(row, column).Style.Fill.BackgroundColor = XLColor.FromArgb(ColorTable.C[TC.HandEVs[index].EVs.Strat[upcard]].R, ColorTable.C[TC.HandEVs[index].EVs.Strat[upcard]].G, ColorTable.C[TC.HandEVs[index].EVs.Strat[upcard]].B);
                                    }
                                }
                                UndealPCard(card2);
                            }
                            UndealPCard(card);
                        }
                        row = row + 1;
                        card = card + 1;
                        card2 = card2 - 1;
                    }
                    while (card < card2);
                }

                // Print 2 Card Dependent Soft Hands
                if (CardProb(1, 0) > 0d)
                {
                    DealPCard(1);
                    index = FindPlayerHand(CurrentPHand);
                    for (card = 2; card <= 10; card++)
                    {
                        if (CardProb(card, 0) > 0d)
                        {
                            DealPCard(card);
                            for (upcard = 1; upcard <= 10; upcard++)
                            {
                                if (UCAllowed[upcard])
                                {
                                    if (upcard == 1)
                                    {
                                        column = 9;
                                    }
                                    else
                                    {
                                        column = upcard - 2;
                                    }
                                    worksheet.Range("C90").Offset(card - 2, column).SetExcelValue(C.StratLongText[TC.HandEVs[PlayerHands[index].HitHand[card]].EVs.Strat[upcard]]);
                                    worksheet.Range("C90").Offset(card - 2, column).Style.Fill.BackgroundColor = XLColor.FromArgb(ColorTable.C[TC.HandEVs[PlayerHands[index].HitHand[card]].EVs.Strat[upcard]].R, ColorTable.C[TC.HandEVs[PlayerHands[index].HitHand[card]].EVs.Strat[upcard]].G, ColorTable.C[TC.HandEVs[PlayerHands[index].HitHand[card]].EVs.Strat[upcard]].B);
                                }
                            }
                            UndealPCard(card);
                        }
                    }
                    UndealPCard(1);
                }

                // Print 2 Card Dependent Splits
                for (card = 1; card <= 10; card++)
                {
                    for (upcard = 1; upcard <= 10; upcard++)
                    {
                        if (CurrentShoe.Cards[card] >= 2 & UCAllowed[upcard])
                        {
                            DealPCard(card);
                            DealPCard(card);
                            index = FindPlayerHand(CurrentPHand);
                            UndealPCard(card);
                            UndealPCard(card);
                            if (upcard == 1)
                            {
                                column = 9;
                            }
                            else
                            {
                                column = upcard - 2;
                            }
                            worksheet.Range("C102").Offset(card - 1, column).SetExcelValue(C.StratLongText[TC.HandEVs[index].EVs.Strat[upcard]]);
                            worksheet.Range("C102").Offset(card - 1, column).Style.Fill.BackgroundColor = XLColor.FromArgb(ColorTable.C[TC.HandEVs[index].EVs.Strat[upcard]].R, ColorTable.C[TC.HandEVs[index].EVs.Strat[upcard]].G, ColorTable.C[TC.HandEVs[index].EVs.Strat[upcard]].B);
                        }
                    }
                }

                // Print 2 Card Dependent Hard Strategies
                for (Total = 4; Total <= 21; Total++)
                {
                    for (upcard = 1; upcard <= 10; upcard++)
                    {
                        if (UCAllowed[upcard])
                        {
                            if (upcard == 1)
                            {
                                column = 9;
                            }
                            else
                            {
                                column = upcard - 2;
                            }
                            worksheet.Range("C115").Offset(Total - 4, column).SetExcelValue(C.StratLongText[TC.StratTD[Total, Conversions.ToInteger(false) + 1].Strat[upcard]]);
                            worksheet.Range("C115").Offset(Total - 4, column).Style.Fill.BackgroundColor = XLColor.FromArgb(ColorTable.C[TC.StratTD[Total, Conversions.ToInteger(false) + 1].Strat[upcard]].R, ColorTable.C[TC.StratTD[Total, Conversions.ToInteger(false) + 1].Strat[upcard]].G, ColorTable.C[TC.StratTD[Total, Conversions.ToInteger(false) + 1].Strat[upcard]].B);
                        }
                    }
                }

                // Print 2 Card Dependent Soft Hands
                for (Total = 12; Total <= 21; Total++)
                {
                    for (upcard = 1; upcard <= 10; upcard++)
                    {
                        if (UCAllowed[upcard])
                        {
                            if (upcard == 1)
                            {
                                column = 9;
                            }
                            else
                            {
                                column = upcard - 2;
                            }
                            worksheet.Range("C136").Offset(Total - 12, column).SetExcelValue(C.StratLongText[TC.StratTD[Total, Conversions.ToInteger(true) + 1].Strat[upcard]]);
                            worksheet.Range("C136").Offset(Total - 12, column).Style.Fill.BackgroundColor = XLColor.FromArgb(ColorTable.C[TC.StratTD[Total, Conversions.ToInteger(true) + 1].Strat[upcard]].R, ColorTable.C[TC.StratTD[Total, Conversions.ToInteger(true) + 1].Strat[upcard]].G, ColorTable.C[TC.StratTD[Total, Conversions.ToInteger(true) + 1].Strat[upcard]].B);
                        }
                    }
                }
            }

            // Print Optimal Play Hard Strategies
            row = 0;
            for (Total = 5; Total <= 19; Total++)
            {
                if (Total < 13)
                {
                    card = 2;
                }
                else
                {
                    card = Total - 10;
                }
                card2 = Total - card;
                do
                {
                    if (CardProb(card, 0) > 0d)
                    {
                        DealPCard(card);
                        if (CardProb(card2, 0) > 0d)
                        {
                            DealPCard(card2);
                            index = FindPlayerHand(CurrentPHand);
                            for (upcard = 1; upcard <= 10; upcard++)
                            {
                                if (UCAllowed[upcard])
                                {
                                    if (upcard == 1)
                                    {
                                        column = 9;
                                    }
                                    else
                                    {
                                        column = upcard - 2;
                                    }
                                    worksheet.Range("C149").Offset(row, column).SetExcelValue(C.StratLongText[Opt.HandEVs[index].EVs.Strat[upcard]]);
                                    worksheet.Range("C149").Offset(row, column).Style.Fill.BackgroundColor = XLColor.FromArgb(ColorTable.C[Opt.HandEVs[index].EVs.Strat[upcard]].R, ColorTable.C[Opt.HandEVs[index].EVs.Strat[upcard]].G, ColorTable.C[Opt.HandEVs[index].EVs.Strat[upcard]].B);
                                }
                            }
                            UndealPCard(card2);
                        }
                        UndealPCard(card);
                    }
                    row = row + 1;
                    card = card + 1;
                    card2 = card2 - 1;
                }
                while (card < card2);
            }

            // Print Optimal Play Soft Hands
            if (CardProb(1, 0) > 0d)
            {
                DealPCard(1);
                index = FindPlayerHand(CurrentPHand);
                for (card = 2; card <= 10; card++)
                {
                    if (CardProb(card, 0) > 0d)
                    {
                        DealPCard(card);
                        for (upcard = 1; upcard <= 10; upcard++)
                        {
                            if (UCAllowed[upcard])
                            {
                                if (upcard == 1)
                                {
                                    column = 9;
                                }
                                else
                                {
                                    column = upcard - 2;
                                }
                                worksheet.Range("C188").Offset(card - 2, column).SetExcelValue(C.StratLongText[Opt.HandEVs[PlayerHands[index].HitHand[card]].EVs.Strat[upcard]]);
                                worksheet.Range("C188").Offset(card - 2, column).Style.Fill.BackgroundColor = XLColor.FromArgb(ColorTable.C[Opt.HandEVs[PlayerHands[index].HitHand[card]].EVs.Strat[upcard]].R, ColorTable.C[Opt.HandEVs[PlayerHands[index].HitHand[card]].EVs.Strat[upcard]].G, ColorTable.C[Opt.HandEVs[PlayerHands[index].HitHand[card]].EVs.Strat[upcard]].B);
                            }
                        }
                        UndealPCard(card);
                    }
                }
                UndealPCard(1);
            }

            // Print Optimal Play Splits
            for (card = 1; card <= 10; card++)
            {
                for (upcard = 1; upcard <= 10; upcard++)
                {
                    if (CurrentShoe.Cards[card] >= 2 & UCAllowed[upcard])
                    {
                        DealPCard(card);
                        DealPCard(card);
                        index = FindPlayerHand(CurrentPHand);
                        UndealPCard(card);
                        UndealPCard(card);
                        if (upcard == 1)
                        {
                            column = 9;
                        }
                        else
                        {
                            column = upcard - 2;
                        }
                        worksheet.Range("C200").Offset(card - 1, column).SetExcelValue(C.StratLongText[Opt.HandEVs[index].EVs.Strat[upcard]]);
                        worksheet.Range("C200").Offset(card - 1, column).Style.Fill.BackgroundColor = XLColor.FromArgb(ColorTable.C[Opt.HandEVs[index].EVs.Strat[upcard]].R, ColorTable.C[Opt.HandEVs[index].EVs.Strat[upcard]].G, ColorTable.C[Opt.HandEVs[index].EVs.Strat[upcard]].B);
                    }
                }
            }

            // Print Forced Dependent Hard Strategies
            if (Forced.ComputeStrat)
            {
                row = 0;
                for (Total = 5; Total <= 19; Total++)
                {
                    if (Total < 13)
                    {
                        card = 2;
                    }
                    else
                    {
                        card = Total - 10;
                    }
                    card2 = Total - card;
                    do
                    {
                        if (CardProb(card, 0) > 0d)
                        {
                            DealPCard(card);
                            if (CardProb(card2, 0) > 0d)
                            {
                                DealPCard(card2);
                                index = FindPlayerHand(CurrentPHand);
                                for (upcard = 1; upcard <= 10; upcard++)
                                {
                                    if (UCAllowed[upcard])
                                    {
                                        if (upcard == 1)
                                        {
                                            column = 9;
                                        }
                                        else
                                        {
                                            column = upcard - 2;
                                        }
                                        worksheet.Range("C213").Offset(row, column).SetExcelValue(C.StratLongText[Forced.HandEVs[index].EVs.Strat[upcard]]);
                                        worksheet.Range("C213").Offset(row, column).Style.Fill.BackgroundColor = XLColor.FromArgb(ColorTable.C[Forced.HandEVs[index].EVs.Strat[upcard]].R, ColorTable.C[Forced.HandEVs[index].EVs.Strat[upcard]].G, ColorTable.C[Forced.HandEVs[index].EVs.Strat[upcard]].B);
                                    }
                                }
                                UndealPCard(card2);
                            }
                            UndealPCard(card);
                        }
                        row = row + 1;
                        card = card + 1;
                        card2 = card2 - 1;
                    }
                    while (card < card2);
                }

                // Print Forced Dependent Soft Hands
                if (CardProb(1, 0) > 0d)
                {
                    DealPCard(1);
                    index = FindPlayerHand(CurrentPHand);
                    for (card = 2; card <= 10; card++)
                    {
                        if (CardProb(card, 0) > 0d)
                        {
                            DealPCard(card);
                            for (upcard = 1; upcard <= 10; upcard++)
                            {
                                if (UCAllowed[upcard])
                                {
                                    if (upcard == 1)
                                    {
                                        column = 9;
                                    }
                                    else
                                    {
                                        column = upcard - 2;
                                    }
                                    worksheet.Range("C252").Offset(card - 2, column).SetExcelValue(C.StratLongText[Forced.HandEVs[PlayerHands[index].HitHand[card]].EVs.Strat[upcard]]);
                                    worksheet.Range("C252").Offset(card - 2, column).Style.Fill.BackgroundColor = XLColor.FromArgb(ColorTable.C[Forced.HandEVs[PlayerHands[index].HitHand[card]].EVs.Strat[upcard]].R, ColorTable.C[Forced.HandEVs[PlayerHands[index].HitHand[card]].EVs.Strat[upcard]].G, ColorTable.C[Forced.HandEVs[PlayerHands[index].HitHand[card]].EVs.Strat[upcard]].B);
                                }
                            }
                            UndealPCard(card);
                        }
                    }
                    UndealPCard(1);
                }

                // Print Forced Dependent Splits
                for (card = 1; card <= 10; card++)
                {
                    for (upcard = 1; upcard <= 10; upcard++)
                    {
                        if (CurrentShoe.Cards[card] >= 2 & UCAllowed[upcard])
                        {
                            DealPCard(card);
                            DealPCard(card);
                            index = FindPlayerHand(CurrentPHand);
                            UndealPCard(card);
                            UndealPCard(card);
                            if (upcard == 1)
                            {
                                column = 9;
                            }
                            else
                            {
                                column = upcard - 2;
                            }
                            worksheet.Range("C264").Offset(card - 1, column).SetExcelValue(C.StratLongText[Forced.HandEVs[index].EVs.Strat[upcard]]);
                            worksheet.Range("C264").Offset(card - 1, column).Style.Fill.BackgroundColor = XLColor.FromArgb(ColorTable.C[Forced.HandEVs[index].EVs.Strat[upcard]].R, ColorTable.C[Forced.HandEVs[index].EVs.Strat[upcard]].G, ColorTable.C[Forced.HandEVs[index].EVs.Strat[upcard]].B);
                        }
                    }
                }

                // Print Forced Dependent Hard Strategies
                for (Total = 4; Total <= 21; Total++)
                {
                    for (upcard = 1; upcard <= 10; upcard++)
                    {
                        if (UCAllowed[upcard])
                        {
                            if (upcard == 1)
                            {
                                column = 9;
                            }
                            else
                            {
                                column = upcard - 2;
                            }
                            worksheet.Range("C277").Offset(Total - 4, column).SetExcelValue(C.StratLongText[Forced.StratTD[Total, Conversions.ToInteger(false) + 1].Strat[upcard]]);
                            worksheet.Range("C277").Offset(Total - 4, column).Style.Fill.BackgroundColor = XLColor.FromArgb(ColorTable.C[Forced.StratTD[Total, Conversions.ToInteger(false) + 1].Strat[upcard]].R, ColorTable.C[Forced.StratTD[Total, Conversions.ToInteger(false) + 1].Strat[upcard]].G, ColorTable.C[Forced.StratTD[Total, Conversions.ToInteger(false) + 1].Strat[upcard]].B);
                        }
                    }
                }

                // Print Forced Dependent Soft Hands
                for (Total = 12; Total <= 21; Total++)
                {
                    for (upcard = 1; upcard <= 10; upcard++)
                    {
                        if (UCAllowed[upcard])
                        {
                            if (upcard == 1)
                            {
                                column = 9;
                            }
                            else
                            {
                                column = upcard - 2;
                            }
                            worksheet.Range("C298").Offset(Total - 12, column).SetExcelValue(C.StratLongText[Forced.StratTD[Total, Conversions.ToInteger(true) + 1].Strat[upcard]]);
                            worksheet.Range("C298").Offset(Total - 12, column).Style.Fill.BackgroundColor = XLColor.FromArgb(ColorTable.C[Forced.StratTD[Total, Conversions.ToInteger(true) + 1].Strat[upcard]].R, ColorTable.C[Forced.StratTD[Total, Conversions.ToInteger(true) + 1].Strat[upcard]].G, ColorTable.C[Forced.StratTD[Total, Conversions.ToInteger(true) + 1].Strat[upcard]].B);
                        }
                    }
                }
            }

            worksheet = null;
        }

        private void PrintStrategyEVsExcel(XLWorkbook workBook)
        {
            IXLWorksheet worksheet;
            int Total;
            int upcard;
            int card;
            int card2;
            int index;
            int column;
            int row;
            double dprob;
            double prob;
            double p2;

            worksheet = workBook.Worksheet("Strategy EVs");

            worksheet.Range("D3:E3").ClearContents();
            worksheet.Range("D8:M241").ClearContents();
            worksheet.Range("D246:M375").ClearContents();
            worksheet.Range("D380:M499").ClearContents();
            worksheet.Range("D504:M791").ClearContents();
            worksheet.Range("D796:M867").ClearContents();
            worksheet.Range("A1").SelectOnly();

            // Print Blackjack EVs

            dprob = CardProb(1, 0);
            prob = CardProb(1, 0);
            DealDCard(1);
            dprob = dprob * CardProb(10, 0);
            prob = prob * CardProb(10, 0);
            DealDCard(10);
            prob = prob * CardProb(1, 0);
            DealPCard(1);
            prob = prob * CardProb(10, 0);
            UndealDCard(1);
            UndealDCard(10);
            UndealPCard(1);
            worksheet.Range("D3").SetExcelValue(2d * (dprob - prob));
            worksheet.Range("E3").SetExcelValue(2d * prob);
            worksheet.Range("F3").SetExcelValue(2d * dprob);

            // Print the remaining EVs
            for (upcard = 1; upcard <= 10; upcard++)
            {
                if (UCAllowed[upcard] & CardProb(upcard, 0) > 0d)
                {
                    if (upcard == 1)
                    {
                        column = 9;
                    }
                    else
                    {
                        column = upcard - 2;
                    }
                    dprob = CardProb(upcard, 0);
                    DealDCard(upcard);

                    // Print Total Dependent Hard Strategies
                    worksheet.Range("D8").SelectOnly();
                    for (Total = 4; Total <= 21; Total++)
                    {
                        row = Total - 4;
                        if (TD.ComputeStrat)
                        {
                            worksheet.Range("D8").Offset(row * 13, column).SetExcelValue(dprob * TD.StratTD[Total, Conversions.ToInteger(false) + 1].NetProb[upcard]);
                            worksheet.Range("D8").Offset(row * 13 + 1, column).SetExcelValue(TD.StratTD[Total, Conversions.ToInteger(false) + 1].StratStandEV[upcard]);
                            worksheet.Range("D8").Offset(row * 13 + 2, column).SetExcelValue(TD.StratTD[Total, Conversions.ToInteger(false) + 1].StratHitEV[upcard]);
                            worksheet.Range("D8").Offset(row * 13 + 3, column).SetExcelValue(TD.StratTD[Total, Conversions.ToInteger(false) + 1].StratDEV[upcard]);
                            worksheet.Range("D8").Offset(row * 13 + 4, column).SetExcelValue(TD.StratTD[Total, Conversions.ToInteger(false) + 1].StratSurrEV[upcard]);
                        }
                        if (TC.ComputeStrat)
                        {
                            worksheet.Range("D8").Offset(row * 13 + 5, column).SetExcelValue(TC.StratTD[Total, Conversions.ToInteger(false) + 1].StratStandEV[upcard]);
                            worksheet.Range("D8").Offset(row * 13 + 6, column).SetExcelValue(TC.StratTD[Total, Conversions.ToInteger(false) + 1].StratHitEV[upcard]);
                            worksheet.Range("D8").Offset(row * 13 + 7, column).SetExcelValue(TC.StratTD[Total, Conversions.ToInteger(false) + 1].StratDEV[upcard]);
                            worksheet.Range("D8").Offset(row * 13 + 8, column).SetExcelValue(TC.StratTD[Total, Conversions.ToInteger(false) + 1].StratSurrEV[upcard]);
                        }
                        if (Forced.ComputeStrat)
                        {
                            worksheet.Range("D8").Offset(row * 13 + 9, column).SetExcelValue(Forced.StratTD[Total, Conversions.ToInteger(false) + 1].StratStandEV[upcard]);
                            worksheet.Range("D8").Offset(row * 13 + 10, column).SetExcelValue(Forced.StratTD[Total, Conversions.ToInteger(false) + 1].StratHitEV[upcard]);
                            worksheet.Range("D8").Offset(row * 13 + 11, column).SetExcelValue(Forced.StratTD[Total, Conversions.ToInteger(false) + 1].StratDEV[upcard]);
                            worksheet.Range("D8").Offset(row * 13 + 12, column).SetExcelValue(Forced.StratTD[Total, Conversions.ToInteger(false) + 1].StratSurrEV[upcard]);
                        }
                    }

                    // Print Total Dependent Soft Hands
                    for (Total = 12; Total <= 21; Total++)
                    {
                        row = Total - 12;
                        if (TD.ComputeStrat)
                        {
                            worksheet.Range("D246").Offset(row * 13, column).SetExcelValue(dprob * TD.StratTD[Total, Conversions.ToInteger(true) + 1].NetProb[upcard]);
                            worksheet.Range("D246").Offset(row * 13 + 1, column).SetExcelValue(TD.StratTD[Total, Conversions.ToInteger(true) + 1].StratStandEV[upcard]);
                            worksheet.Range("D246").Offset(row * 13 + 2, column).SetExcelValue(TD.StratTD[Total, Conversions.ToInteger(true) + 1].StratHitEV[upcard]);
                            worksheet.Range("D246").Offset(row * 13 + 3, column).SetExcelValue(TD.StratTD[Total, Conversions.ToInteger(true) + 1].StratDEV[upcard]);
                            worksheet.Range("D246").Offset(row * 13 + 4, column).SetExcelValue(TD.StratTD[Total, Conversions.ToInteger(true) + 1].StratSurrEV[upcard]);
                        }
                        if (TC.ComputeStrat)
                        {
                            worksheet.Range("D246").Offset(row * 13 + 5, column).SetExcelValue(TC.StratTD[Total, Conversions.ToInteger(true) + 1].StratStandEV[upcard]);
                            worksheet.Range("D246").Offset(row * 13 + 6, column).SetExcelValue(TC.StratTD[Total, Conversions.ToInteger(true) + 1].StratHitEV[upcard]);
                            worksheet.Range("D246").Offset(row * 13 + 7, column).SetExcelValue(TC.StratTD[Total, Conversions.ToInteger(true) + 1].StratDEV[upcard]);
                            worksheet.Range("D246").Offset(row * 13 + 8, column).SetExcelValue(TC.StratTD[Total, Conversions.ToInteger(true) + 1].StratSurrEV[upcard]);
                        }
                        if (Forced.ComputeStrat)
                        {
                            worksheet.Range("D246").Offset(row * 13 + 9, column).SetExcelValue(Forced.StratTD[Total, Conversions.ToInteger(true) + 1].StratStandEV[upcard]);
                            worksheet.Range("D246").Offset(row * 13 + 10, column).SetExcelValue(Forced.StratTD[Total, Conversions.ToInteger(true) + 1].StratHitEV[upcard]);
                            worksheet.Range("D246").Offset(row * 13 + 11, column).SetExcelValue(Forced.StratTD[Total, Conversions.ToInteger(true) + 1].StratDEV[upcard]);
                            worksheet.Range("D246").Offset(row * 13 + 12, column).SetExcelValue(Forced.StratTD[Total, Conversions.ToInteger(true) + 1].StratSurrEV[upcard]);
                        }
                    }

                    // Print Split EVs
                    CurrentPHand.Empty();
                    for (card = 1; card <= 10; card++)
                    {
                        if (CardProb(card, 0) > 0d)
                        {
                            prob = dprob * CardProb(card, upcard);
                            DealPCard(card);
                            if (CardProb(card, 0) > 0d)
                            {
                                prob = prob * CardProb(card, upcard);
                                DealPCard(card);
                                index = FindPlayerHand(CurrentPHand);
                                row = card - 1;
                                worksheet.Range("D380").Offset(row * 12, column).SetExcelValue(prob);
                                if (SPL > 0)
                                {
                                    if (SplitAllowed[card])
                                    {
                                        if (TD.ComputeStrat)
                                            worksheet.Range("D380").Offset(row * 12 + 1, column).SetExcelValue(TD.HandEVs[index].SplitEV[upcard]);
                                        if (TC.ComputeStrat)
                                            worksheet.Range("D380").Offset(row * 12 + 2, column).SetExcelValue(TC.HandEVs[index].SplitEV[upcard]);
                                        worksheet.Range("D380").Offset(row * 12 + 3, column).SetExcelValue(Opt.HandEVs[index].SplitEV[upcard]);
                                        if (Forced.ComputeStrat)
                                            worksheet.Range("D380").Offset(row * 12 + 4, column).SetExcelValue(Forced.HandEVs[index].SplitEV[upcard]);
                                    }
                                }
                                worksheet.Range("D380").Offset(row * 12 + 5, column).SetExcelValue(PlayerHands[index].HandEVs.StandEV[upcard]);
                                worksheet.Range("D380").Offset(row * 12 + 6, column).SetExcelValue(PlayerHands[index].HandEVs.DEV[upcard]);
                                worksheet.Range("D380").Offset(row * 12 + 7, column).SetExcelValue(PlayerHands[index].HandEVs.SurrEV[upcard]);
                                if (TD.ComputeStrat)
                                    worksheet.Range("D380").Offset(row * 12 + 8, column).SetExcelValue(TD.HandEVs[index].EVs.HitEV[upcard]);
                                if (TC.ComputeStrat)
                                    worksheet.Range("D380").Offset(row * 12 + 9, column).SetExcelValue(TC.HandEVs[index].EVs.HitEV[upcard]);
                                worksheet.Range("D380").Offset(row * 12 + 10, column).SetExcelValue(Opt.HandEVs[index].EVs.HitEV[upcard]);
                                if (Forced.ComputeStrat)
                                    worksheet.Range("D380").Offset(row * 12 + 11, column).SetExcelValue(Forced.HandEVs[index].EVs.HitEV[upcard]);
                                UndealPCard(card);
                            }
                            UndealPCard(card);
                        }
                    }

                    // Print 2 card and Optimal Play Hard EVs
                    CurrentPHand.Empty();
                    row = 0;
                    for (Total = 5; Total <= 19; Total++)
                    {
                        if (Total < 13)
                        {
                            card = 2;
                        }
                        else
                        {
                            card = Total - 10;
                        }
                        card2 = Total - card;
                        do
                        {
                            if (CardProb(card, 0) > 0d)
                            {
                                prob = dprob * CardProb(card, upcard);
                                DealPCard(card);
                                if (CardProb(card2, 0) > 0d)
                                {
                                    prob = prob * CardProb(card2, upcard);
                                    UndealPCard(card);
                                    p2 = dprob * CardProb(card2, upcard);
                                    DealPCard(card2);
                                    p2 = p2 * CardProb(card, upcard);
                                    DealPCard(card);
                                    index = FindPlayerHand(CurrentPHand);
                                    worksheet.Range("D504").Offset(row * 8, column).SetExcelValue(prob + p2);
                                    worksheet.Range("D504").Offset(row * 8 + 1, column).SetExcelValue(PlayerHands[index].HandEVs.StandEV[upcard]);
                                    worksheet.Range("D504").Offset(row * 8 + 2, column).SetExcelValue(PlayerHands[index].HandEVs.DEV[upcard]);
                                    worksheet.Range("D504").Offset(row * 8 + 3, column).SetExcelValue(PlayerHands[index].HandEVs.SurrEV[upcard]);
                                    if (TD.ComputeStrat)
                                        worksheet.Range("D504").Offset(row * 8 + 4, column).SetExcelValue(TD.HandEVs[index].EVs.HitEV[upcard]);
                                    if (TC.ComputeStrat)
                                        worksheet.Range("D504").Offset(row * 8 + 5, column).SetExcelValue(TC.HandEVs[index].EVs.HitEV[upcard]);
                                    worksheet.Range("D504").Offset(row * 8 + 6, column).SetExcelValue(Opt.HandEVs[index].EVs.HitEV[upcard]);
                                    if (Forced.ComputeStrat)
                                        worksheet.Range("D504").Offset(row * 8 + 7, column).SetExcelValue(Forced.HandEVs[index].EVs.HitEV[upcard]);
                                    UndealPCard(card2);
                                }
                                UndealPCard(card);
                            }
                            row = row + 1;
                            card = card + 1;
                            card2 = card2 - 1;
                        }
                        while (card < card2);
                    }

                    // Print 2 Card and Optimal Play Soft Hand EVs
                    CurrentPHand.Empty();
                    if (CardProb(1, 0) > 0d)
                    {
                        prob = dprob * CardProb(1, upcard);
                        DealPCard(1);
                        for (card = 2; card <= 10; card++)
                        {
                            if (CardProb(card, 0) > 0d)
                            {
                                prob = prob * CardProb(card, upcard);
                                UndealPCard(1);
                                p2 = dprob * CardProb(card, upcard);
                                DealPCard(card);
                                p2 = p2 * CardProb(1, upcard);
                                DealPCard(1);
                                index = FindPlayerHand(CurrentPHand);
                                row = card - 2;
                                worksheet.Range("D796").Offset(row * 8, column).SetExcelValue(prob + p2);
                                worksheet.Range("D796").Offset(row * 8 + 1, column).SetExcelValue(PlayerHands[index].HandEVs.StandEV[upcard]);
                                worksheet.Range("D796").Offset(row * 8 + 2, column).SetExcelValue(PlayerHands[index].HandEVs.DEV[upcard]);
                                worksheet.Range("D796").Offset(row * 8 + 3, column).SetExcelValue(PlayerHands[index].HandEVs.SurrEV[upcard]);
                                if (TD.ComputeStrat)
                                    worksheet.Range("D796").Offset(row * 8 + 4, column).SetExcelValue(TD.HandEVs[index].EVs.HitEV[upcard]);
                                if (TC.ComputeStrat)
                                    worksheet.Range("D796").Offset(row * 8 + 5, column).SetExcelValue(TC.HandEVs[index].EVs.HitEV[upcard]);
                                worksheet.Range("D796").Offset(row * 8 + 6, column).SetExcelValue(Opt.HandEVs[index].EVs.HitEV[upcard]);
                                if (Forced.ComputeStrat)
                                    worksheet.Range("D796").Offset(row * 8 + 7, column).SetExcelValue(Forced.HandEVs[index].EVs.HitEV[upcard]);
                                UndealPCard(card);
                                prob = prob / CardProb(card, upcard);
                            }
                        }
                        UndealPCard(1);
                    }
                    UndealDCard(upcard);
                }
            }

            worksheet = null;
        }

        private void PrintSplitEVsExcel(XLWorkbook workBook)
        {
            IXLWorksheet worksheet;
            int paircard;
            int upcard;
            int splits;
            int column;
            int row;
            int index;

            worksheet = workBook.Worksheet("Split EVs");

            worksheet.Range("C3:L32").ClearContents();
            worksheet.Range("C36:L65").ClearContents();
            worksheet.Range("C69:L98").ClearContents();
            worksheet.Range("C102:L131").ClearContents();
            worksheet.Range("A1").SelectOnly();

            // Print Split EVs
            if (SPL > 0)
            {
                CurrentPHand.Empty();
                for (paircard = 1; paircard <= 10; paircard++)
                {
                    if (SplitAllowed[paircard] & CardProb(paircard, 0) > 0d)
                    {
                        DealPCard(paircard);
                        if (CardProb(paircard, 0) > 0d)
                        {
                            DealPCard(paircard);
                            index = FindPlayerHand(CurrentPHand);
                            row = (paircard - 1) * 3;
                            for (upcard = 1; upcard <= 10; upcard++)
                            {
                                if (UCAllowed[upcard])
                                {
                                    if (upcard == 1)
                                    {
                                        column = 9;
                                    }
                                    else
                                    {
                                        column = upcard - 2;
                                    }
                                    var loopTo = SPL;
                                    for (splits = 1; splits <= loopTo; splits++)
                                    {
                                        if (TD.ComputeStrat)
                                            worksheet.Range("C3").Offset(row + splits - 1, column).SetExcelValue(TD.HandEVs[index].SPLEV[upcard, splits]);
                                        worksheet.Range("C3").Offset(row + 33 + splits - 1, column).SetExcelValue(Opt.HandEVs[index].SPLEV[upcard, splits]);
                                        if (TC.ComputeStrat)
                                            worksheet.Range("C3").Offset(row + 66 + splits - 1, column).SetExcelValue(TC.HandEVs[index].SPLEV[upcard, splits]);
                                        if (Forced.ComputeStrat)
                                            worksheet.Range("C3").Offset(row + 99 + splits - 1, column).SetExcelValue(Forced.HandEVs[index].SPLEV[upcard, splits]);
                                    }
                                }
                            }
                            UndealPCard(paircard);
                        }
                        UndealPCard(paircard);
                    }
                }
            }

            worksheet = null;
        }

        private void PrintGameEVsExcel(XLWorkbook workBook)
        {
            IXLWorksheet worksheet;
            int column;
            int card;
            int upcard;

            worksheet = workBook.Worksheet("Summary");

            worksheet.Range("C2:C5").ClearContents();
            worksheet.Range("C8:L12").ClearContents();
            worksheet.Range("C15:L19").ClearContents();
            worksheet.Range("A1").SelectOnly();

            if (TD.ComputeStrat)
                worksheet.Range("C2").SetExcelValue(TD.GameEVs.NetGameEV);
            if (TC.ComputeStrat)
                worksheet.Range("C3").SetExcelValue(TC.GameEVs.NetGameEV);
            worksheet.Range("C4").SetExcelValue(Opt.GameEVs.NetGameEV);
            if (Forced.ComputeStrat)
                worksheet.Range("C5").SetExcelValue(Forced.GameEVs.NetGameEV);

            for (upcard = 1; upcard <= 10; upcard++)
            {
                if (UCAllowed[upcard] & CardProb(upcard, 0) > 0d)
                {
                    if (upcard == 1)
                    {
                        column = 9;
                    }
                    else
                    {
                        column = upcard - 2;
                    }
                    worksheet.Range("C8").Offset(0, column).SetExcelValue(Opt.GameEVs.CardProbs[upcard]);
                    if (TD.ComputeStrat)
                        worksheet.Range("C8").Offset(1, column).SetExcelValue(TD.GameEVs.UpcardEVs[upcard]);
                    if (TC.ComputeStrat)
                        worksheet.Range("C8").Offset(2, column).SetExcelValue(TC.GameEVs.UpcardEVs[upcard]);
                    worksheet.Range("C8").Offset(3, column).SetExcelValue(Opt.GameEVs.UpcardEVs[upcard]);
                    if (Forced.ComputeStrat)
                        worksheet.Range("C8").Offset(4, column).SetExcelValue(Forced.GameEVs.UpcardEVs[upcard]);
                }
            }

            for (card = 1; card <= 10; card++)
            {
                if (CardProb(card, 0) > 0d)
                {
                    if (card == 1)
                    {
                        column = 9;
                    }
                    else
                    {
                        column = card - 2;
                    }
                    worksheet.Range("C15").Offset(0, column).SetExcelValue(Opt.GameEVs.CardProbs[card]);
                    if (TD.ComputeStrat)
                        worksheet.Range("C15").Offset(1, column).SetExcelValue(TD.GameEVs.FirstCardEVs[card]);
                    if (TC.ComputeStrat)
                        worksheet.Range("C15").Offset(2, column).SetExcelValue(TC.GameEVs.FirstCardEVs[card]);
                    worksheet.Range("C15").Offset(3, column).SetExcelValue(Opt.GameEVs.FirstCardEVs[card]);
                    if (Forced.ComputeStrat)
                        worksheet.Range("C15").Offset(4, column).SetExcelValue(Forced.GameEVs.FirstCardEVs[card]);
                }
            }

            worksheet = null;
        }

        private void PrintExceptionsExcel(XLWorkbook workBook)
        {
            IXLWorksheet worksheet;
            int index;
            int upcard;
            int card;
            string handStr;
            int n;
            int n2;
            int n3;
            int i;
            int tdstrat;
            int strat2;
            int Total;
            int Soft;
            int paircard;
            int hands;

            worksheet = workBook.Worksheet("Exceptions");
            worksheet.Range("A6:R6").EndDown().ClearContents();

            if (TD.ComputeStrat)
            {
                n = 0;
                n2 = 0;
                n3 = 0;

                for (upcard = 1; upcard <= 10; upcard++)
                {
                    if (UCAllowed[upcard])
                    {
                        DealDCard(upcard);
                        for (Total = 4; Total <= 21; Total++)
                        {
                            for (Soft = 1; Soft >= 0; Soft -= 1)
                            {
                                index = PlayerHandTotal[Total, Soft];
                                while (index != 0)
                                {
                                    if (HandPossible(PlayerHands[index].Hand) & PlayerHands[index].Hand.NumCards >= 2)
                                    {
                                        tdstrat = 0;
                                        if (PlayerHands[index].Hand.NumCards == 2 & (TD.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.P | TD.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.PS | TD.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.PH | TD.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.PD | TD.HandEVs[index].EVs.Strat[upcard] == (int)BJCAGlobalsClass.Strat.PR))
                                        {
                                            switch (TD.StratTD[Total, Soft].Strat[upcard])
                                            {
                                                case (int)BJCAGlobalsClass.Strat.S:
                                                    {
                                                        tdstrat = (int)BJCAGlobalsClass.Strat.PS;
                                                        break;
                                                    }
                                                case (int)BJCAGlobalsClass.Strat.D:
                                                case (int)BJCAGlobalsClass.Strat.DS:
                                                    {
                                                        tdstrat = (int)BJCAGlobalsClass.Strat.PD;
                                                        break;
                                                    }
                                                case (int)BJCAGlobalsClass.Strat.H:
                                                    {
                                                        tdstrat = (int)BJCAGlobalsClass.Strat.PH;
                                                        break;
                                                    }
                                                case (int)BJCAGlobalsClass.Strat.R:
                                                case (int)BJCAGlobalsClass.Strat.RS:
                                                    {
                                                        tdstrat = (int)BJCAGlobalsClass.Strat.PR;
                                                        break;
                                                    }

                                                default:
                                                    {
                                                        tdstrat = TD.StratTD[Total, Soft].Strat[upcard];
                                                        break;
                                                    }
                                            }
                                        }
                                        else
                                        {
                                            tdstrat = TD.StratTD[Total, Soft].Strat[upcard];
                                            if (!TD.HandEVs[index].DPreallowed[upcard])
                                            {
                                                switch (tdstrat)
                                                {
                                                    case (int)BJCAGlobalsClass.Strat.D:
                                                        {
                                                            tdstrat = (int)BJCAGlobalsClass.Strat.H;
                                                            break;
                                                        }
                                                    case (int)BJCAGlobalsClass.Strat.DS:
                                                        {
                                                            tdstrat = (int)BJCAGlobalsClass.Strat.S;
                                                            break;
                                                        }
                                                }
                                            }
                                            if (Conversions.ToBoolean(~TD.HandEVs[index].RPreallowed[upcard]))
                                            {
                                                switch (tdstrat)
                                                {
                                                    case (int)BJCAGlobalsClass.Strat.R:
                                                        {
                                                            tdstrat = (int)BJCAGlobalsClass.Strat.H;
                                                            break;
                                                        }
                                                    case (int)BJCAGlobalsClass.Strat.RS:
                                                        {
                                                            tdstrat = (int)BJCAGlobalsClass.Strat.S;
                                                            break;
                                                        }
                                                }
                                            }
                                        }

                                        if (Opt.HandEVs[index].EVs.Strat[upcard] != tdstrat & Opt.HandEVs[index].EVs.Strat[upcard] != 0)
                                        {
                                            handStr = "";
                                            for (card = 1; card <= 10; card++)
                                            {
                                                var loopTo = PlayerHands[index].Hand.Cards[card];
                                                for (i = 1; i <= loopTo; i++)
                                                {
                                                    if (card == 1)
                                                    {
                                                        handStr = handStr + "A";
                                                    }
                                                    else if (card == 10)
                                                    {
                                                        handStr = handStr + "T";
                                                    }
                                                    else
                                                    {
                                                        handStr = handStr + Strings.Format(card);
                                                    }
                                                }
                                            }

                                            worksheet.Range("A7").Offset(n, 0).SetExcelValue(handStr);
                                            worksheet.Range("A7").Offset(n, 1).SetExcelValue(upcard);
                                            worksheet.Range("A7").Offset(n, 2).SetExcelValue(Total);
                                            worksheet.Range("A7").Offset(n, 3).SetExcelValue(Soft);
                                            worksheet.Range("A7").Offset(n, 4).SetExcelValue(PlayerHands[index].Hand.NumCards);
                                            worksheet.Range("A7").Offset(n, 5).SetExcelValue("PreSplit");
                                            worksheet.Range("A7").Offset(n, 6).SetExcelValue("CD");
                                            worksheet.Range("A7").Offset(n, 7).SetExcelValue("TD");

                                            worksheet.Range("A7").Offset(n, 8).SetExcelValue(C.StratShortText[Opt.HandEVs[index].EVs.Strat[upcard]]);
                                            worksheet.Range("A7").Offset(n, 9).SetExcelValue(C.StratShortText[TD.StratTD[Total, Soft].Strat[upcard]]);
                                            worksheet.Range("A7").Offset(n, 10).SetExcelValue(PlayerHands[index].HandEVs.StandEV[upcard]);
                                            worksheet.Range("A7").Offset(n, 11).SetExcelValue(PlayerHands[index].HandEVs.StandEV[upcard]);
                                            worksheet.Range("A7").Offset(n, 12).SetExcelValue(PlayerHands[index].HandEVs.DEV[upcard]);
                                            worksheet.Range("A7").Offset(n, 13).SetExcelValue(PlayerHands[index].HandEVs.DEV[upcard]);
                                            worksheet.Range("A7").Offset(n, 14).SetExcelValue(Opt.HandEVs[index].EVs.HitEV[upcard]);
                                            worksheet.Range("A7").Offset(n, 15).SetExcelValue(TD.HandEVs[index].EVs.HitEV[upcard]);
                                            worksheet.Range("A7").Offset(n, 16).SetExcelValue(Opt.HandEVs[index].HandUsed[upcard] != 0);
                                            worksheet.Range("A7").Offset(n, 17).SetExcelValue(TD.HandEVs[index].HandUsed[upcard] != 0);

                                            n += 1;
                                        }
                                    }
                                    index = PlayerHands[index].NextHand;
                                }
                            }
                        }
                        UndealDCard(upcard);
                    }
                }

                // Now look for post-split exceptions
                if (PrintPSExceptions & (CDP | CDPN))
                {
                    for (upcard = 1; upcard <= 10; upcard++)
                    {
                        if (UCAllowed[upcard])
                        {
                            DealDCard(upcard);
                            for (Total = 4; Total <= 21; Total++)
                            {
                                for (Soft = 1; Soft >= 0; Soft -= 1)
                                {
                                    for (paircard = 1; paircard <= 10; paircard++)
                                    {
                                        if (SplitIndex[paircard, upcard] > 0)
                                        {
                                            var loopTo1 = NSplitHands;
                                            for (hands = 1; hands <= loopTo1; hands++)
                                            {
                                                if (NPxHands[hands].Used[SPL] & (NPxHands[hands].NN == 0 | CDPN))
                                                {
                                                    index = PlayerHandTotal[Total, Soft];
                                                    while (index != 0)
                                                    {
                                                        if (PlayerHands[index].PairIndex[paircard] > 0)
                                                        {
                                                            if (Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands] is not null)
                                                            {
                                                                if (Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].Strat[upcard] != 0)
                                                                {
                                                                    tdstrat = 0;
                                                                    if (PlayerHands[index].Hand.NumCards == 2)
                                                                    {
                                                                        switch (TD.StratTD[Total, Soft].Strat[upcard])
                                                                        {
                                                                            case (int)BJCAGlobalsClass.Strat.PS:
                                                                                {
                                                                                    tdstrat = (int)BJCAGlobalsClass.Strat.S;
                                                                                    break;
                                                                                }
                                                                            case (int)BJCAGlobalsClass.Strat.PD:
                                                                                {
                                                                                    tdstrat = (int)BJCAGlobalsClass.Strat.D;
                                                                                    break;
                                                                                }
                                                                            case (int)BJCAGlobalsClass.Strat.PH:
                                                                                {
                                                                                    tdstrat = (int)BJCAGlobalsClass.Strat.H;
                                                                                    break;
                                                                                }
                                                                            case (int)BJCAGlobalsClass.Strat.PR:
                                                                                {
                                                                                    tdstrat = (int)BJCAGlobalsClass.Strat.R;
                                                                                    break;
                                                                                }

                                                                            default:
                                                                                {
                                                                                    tdstrat = TD.StratTD[Total, Soft].Strat[upcard];
                                                                                    break;
                                                                                }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        tdstrat = TD.StratTD[Total, Soft].Strat[upcard];
                                                                    }
                                                                    if (!TD.HandEVs[index].DPostallowed[upcard])
                                                                    {
                                                                        switch (tdstrat)
                                                                        {
                                                                            case (int)BJCAGlobalsClass.Strat.D:
                                                                                {
                                                                                    tdstrat = (int)BJCAGlobalsClass.Strat.H;
                                                                                    break;
                                                                                }
                                                                            case (int)BJCAGlobalsClass.Strat.DS:
                                                                                {
                                                                                    tdstrat = (int)BJCAGlobalsClass.Strat.S;
                                                                                    break;
                                                                                }
                                                                        }
                                                                    }
                                                                    if (Conversions.ToBoolean(~TD.HandEVs[index].RPostallowed[upcard]))
                                                                    {
                                                                        switch (tdstrat)
                                                                        {
                                                                            case (int)BJCAGlobalsClass.Strat.R:
                                                                                {
                                                                                    tdstrat = (int)BJCAGlobalsClass.Strat.H;
                                                                                    break;
                                                                                }
                                                                            case (int)BJCAGlobalsClass.Strat.RS:
                                                                                {
                                                                                    tdstrat = (int)BJCAGlobalsClass.Strat.S;
                                                                                    break;
                                                                                }
                                                                        }
                                                                    }

                                                                    switch (Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].Strat[upcard])
                                                                    {
                                                                        case (int)BJCAGlobalsClass.Strat.PS:
                                                                            {
                                                                                strat2 = (int)BJCAGlobalsClass.Strat.S;
                                                                                break;
                                                                            }
                                                                        case (int)BJCAGlobalsClass.Strat.PD:
                                                                            {
                                                                                strat2 = (int)BJCAGlobalsClass.Strat.D;
                                                                                break;
                                                                            }
                                                                        case (int)BJCAGlobalsClass.Strat.PH:
                                                                            {
                                                                                strat2 = (int)BJCAGlobalsClass.Strat.H;
                                                                                break;
                                                                            }
                                                                        case (int)BJCAGlobalsClass.Strat.PR:
                                                                            {
                                                                                strat2 = (int)BJCAGlobalsClass.Strat.R;
                                                                                break;
                                                                            }

                                                                        default:
                                                                            {
                                                                                strat2 = Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].Strat[upcard];
                                                                                break;
                                                                            }
                                                                    }
                                                                    if (strat2 != tdstrat)
                                                                    {
                                                                        handStr = "";
                                                                        for (card = 1; card <= 10; card++)
                                                                        {
                                                                            var loopTo2 = PlayerHands[index].Hand.Cards[card];
                                                                            for (i = 1; i <= loopTo2; i++)
                                                                            {
                                                                                if (card == 1)
                                                                                {
                                                                                    handStr = handStr + "A";
                                                                                }
                                                                                else if (card == 10)
                                                                                {
                                                                                    handStr = handStr + "T";
                                                                                }
                                                                                else
                                                                                {
                                                                                    handStr = handStr + Strings.Format(card);
                                                                                }
                                                                            }
                                                                        }

                                                                        worksheet.Range("A7").Offset(n + n2, 0).SetExcelValue(handStr);
                                                                        worksheet.Range("A7").Offset(n + n2, 1).SetExcelValue(upcard);
                                                                        worksheet.Range("A7").Offset(n + n2, 2).SetExcelValue(Total);
                                                                        worksheet.Range("A7").Offset(n + n2, 3).SetExcelValue(Soft);
                                                                        worksheet.Range("A7").Offset(n + n2, 4).SetExcelValue(PlayerHands[index].Hand.NumCards);
                                                                        worksheet.Range("A7").Offset(n + n2, 5).SetExcelValue(Strings.Format(paircard) + "  " + NPxHands[hands].Name);
                                                                        worksheet.Range("A7").Offset(n + n2, 6).SetExcelValue("Post CD");
                                                                        worksheet.Range("A7").Offset(n + n2, 7).SetExcelValue("TD");

                                                                        worksheet.Range("A7").Offset(n + n2, 8).SetExcelValue(C.StratShortText[Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].Strat[upcard]]);
                                                                        worksheet.Range("A7").Offset(n + n2, 9).SetExcelValue(C.StratShortText[TD.StratTD[Total, Soft].Strat[upcard]]);
                                                                        worksheet.Range("A7").Offset(n + n2, 10).SetExcelValue(PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].StandEV[upcard]);
                                                                        worksheet.Range("A7").Offset(n + n2, 11).SetExcelValue(PlayerHands[index].HandEVs.StandEV[upcard]);
                                                                        worksheet.Range("A7").Offset(n + n2, 12).SetExcelValue(PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].DEV[upcard]);
                                                                        worksheet.Range("A7").Offset(n + n2, 13).SetExcelValue(PlayerHands[index].HandEVs.DEV[upcard]);
                                                                        worksheet.Range("A7").Offset(n + n2, 14).SetExcelValue(Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].HitEV[upcard]);
                                                                        worksheet.Range("A7").Offset(n + n2, 15).SetExcelValue(TD.HandEVs[index].EVs.HitEV[upcard]);
                                                                        worksheet.Range("A7").Offset(n + n2, 16).SetExcelValue(Opt.HandEVs[index].HandUsed[upcard] != 0);
                                                                        worksheet.Range("A7").Offset(n + n2, 17).SetExcelValue(TD.HandEVs[index].HandUsed[upcard] != 0);

                                                                        n2 += 1;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        index = PlayerHands[index].NextHand;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            UndealDCard(upcard);
                        }
                    }

                    for (upcard = 1; upcard <= 10; upcard++)
                    {
                        if (UCAllowed[upcard])
                        {
                            DealDCard(upcard);
                            for (Total = 4; Total <= 21; Total++)
                            {
                                for (Soft = 1; Soft >= 0; Soft -= 1)
                                {
                                    for (paircard = 1; paircard <= 10; paircard++)
                                    {
                                        if (SplitIndex[paircard, upcard] > 0)
                                        {
                                            var loopTo3 = NSplitHands;
                                            for (hands = 1; hands <= loopTo3; hands++)
                                            {
                                                if (NPxHands[hands].Used[SPL] & (NPxHands[hands].NN == 0 | CDPN))
                                                {
                                                    index = PlayerHandTotal[Total, Soft];
                                                    while (index != 0)
                                                    {
                                                        if (PlayerHands[index].PairIndex[paircard] > 0)
                                                        {
                                                            if (Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands] is not null)
                                                            {
                                                                if (Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].Strat[upcard] != 0)
                                                                {
                                                                    if (Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].Strat[upcard] != Opt.HandEVs[index].EVs.Strat[upcard])
                                                                    {
                                                                        handStr = "";
                                                                        for (card = 1; card <= 10; card++)
                                                                        {
                                                                            var loopTo4 = PlayerHands[index].Hand.Cards[card];
                                                                            for (i = 1; i <= loopTo4; i++)
                                                                            {
                                                                                if (card == 1)
                                                                                {
                                                                                    handStr = handStr + "A";
                                                                                }
                                                                                else if (card == 10)
                                                                                {
                                                                                    handStr = handStr + "T";
                                                                                }
                                                                                else
                                                                                {
                                                                                    handStr = handStr + Strings.Format(card);
                                                                                }
                                                                            }
                                                                        }

                                                                        worksheet.Range("A7").Offset(n + n2 + n3, 0).SetExcelValue(handStr);
                                                                        worksheet.Range("A7").Offset(n + n2 + n3, 1).SetExcelValue(upcard);
                                                                        worksheet.Range("A7").Offset(n + n2 + n3, 2).SetExcelValue(PlayerHands[index].Hand.Total);
                                                                        worksheet.Range("A7").Offset(n + n2 + n3, 3).SetExcelValue(PlayerHands[index].Hand.Soft);
                                                                        worksheet.Range("A7").Offset(n + n2 + n3, 4).SetExcelValue(PlayerHands[index].Hand.NumCards);
                                                                        worksheet.Range("A7").Offset(n + n2 + n3, 5).SetExcelValue(Strings.Format(paircard) + "  " + NPxHands[hands].Name);
                                                                        worksheet.Range("A7").Offset(n + n2 + n3, 6).SetExcelValue("Post CD");
                                                                        worksheet.Range("A7").Offset(n + n2 + n3, 7).SetExcelValue("CD");

                                                                        worksheet.Range("A7").Offset(n + n2 + n3, 8).SetExcelValue(C.StratShortText[Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].Strat[upcard]]);
                                                                        worksheet.Range("A7").Offset(n + n2 + n3, 9).SetExcelValue(C.StratShortText[Opt.HandEVs[index].EVs.Strat[upcard]]);
                                                                        worksheet.Range("A7").Offset(n + n2 + n3, 10).SetExcelValue(PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].StandEV[upcard]);
                                                                        worksheet.Range("A7").Offset(n + n2 + n3, 11).SetExcelValue(PlayerHands[index].HandEVs.StandEV[upcard]);
                                                                        worksheet.Range("A7").Offset(n + n2 + n3, 12).SetExcelValue(PlayerHands[index].SplitEVs[PlayerHands[index].PairIndex[paircard], hands].DEV[upcard]);
                                                                        worksheet.Range("A7").Offset(n + n2 + n3, 13).SetExcelValue(PlayerHands[index].HandEVs.DEV[upcard]);
                                                                        worksheet.Range("A7").Offset(n + n2 + n3, 14).SetExcelValue(Opt.HandEVs[index].SplitData[PlayerHands[index].PairIndex[paircard], hands].HitEV[upcard]);
                                                                        worksheet.Range("A7").Offset(n + n2 + n3, 15).SetExcelValue(Opt.HandEVs[index].EVs.HitEV[upcard]);
                                                                        worksheet.Range("A7").Offset(n + n2 + n3, 16).SetExcelValue(Opt.HandEVs[index].HandUsed[upcard] != 0);
                                                                        worksheet.Range("A7").Offset(n + n2 + n3, 17).SetExcelValue(TD.HandEVs[index].HandUsed[upcard] != 0);

                                                                        n3 += 1;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        index = PlayerHands[index].NextHand;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            UndealDCard(upcard);
                        }
                    }
                }

                worksheet.Range("B1").SetExcelValue(n);
                worksheet.Range("B2").SetExcelValue(n2);
                worksheet.Range("B3").SetExcelValue(n3);
                if (n == 0 & n2 == 0 & n3 == 0)
                    worksheet.Range("A7").SetExcelValue("No Exceptions Found");

                // worksheet.Range("A6:R6").End(Excel.XlDirection.xlDown). _
                // Sort(Key1:=worksheet.Range("R6"), Order1:=Excel.XlSortOrder.xlDescending, _
                // Key2:=worksheet.Range("H6"), Type:=Excel.XlSortType.xlSortValues, _
                // Order2:=Excel.XlSortOrder.xlDescending, _
                // Header:=Excel.XlYesNoGuess.xlGuess, OrderCustom:=1, MatchCase:=False, _
                // Orientation:=Excel.XlSortOrientation.xlSortRows)

                worksheet.Range("A1").SelectOnly();

            }

            worksheet = null;
        }

        private void PrintRulesExcel(XLWorkbook workBook)
        {
            IXLWorksheet worksheet;
            int card;
            int row;

            worksheet = workBook.Worksheet("Rules");

            worksheet.Range("B1:B29").ClearContents();
            worksheet.Range("E2:N6").ClearContents();
            worksheet.Range("E11:N11").ClearContents();
            worksheet.Range("E16:E21").ClearContents();
            worksheet.Range("B1").SelectOnly();

            worksheet.Range("B1").SetExcelValue(DeckType);

            for (card = 1; card <= 10; card++)
            {
                worksheet.Range("E2").Offset(0, card - 1).SetExcelValue(OriginalShoe.Cards[card]);
                worksheet.Range("E2").Offset(1, card - 1).SetExcelValue(OriginalShoe.Suits[card, 0]);
                worksheet.Range("E2").Offset(2, card - 1).SetExcelValue(OriginalShoe.Suits[card, 1]);
                worksheet.Range("E2").Offset(3, card - 1).SetExcelValue(OriginalShoe.Suits[card, 2]);
                worksheet.Range("E2").Offset(4, card - 1).SetExcelValue(OriginalShoe.Suits[card, 3]);
            }

            if (StandOnSoft == 17)
            {
                worksheet.Range("B2").SetExcelValue("S17");
            }
            else
            {
                worksheet.Range("B2").SetExcelValue("H17");
            }

            if (ENHC)
            {
                worksheet.Range("B3").SetExcelValue("ENHC");
            }
            else if (BBO)
            {
                worksheet.Range("B3").SetExcelValue("BBO");
            }
            else if (OBBO)
            {
                worksheet.Range("B3").SetExcelValue("OBBO");
            }
            else if (AOBBO)
            {
                worksheet.Range("B3").SetExcelValue("AOBBO");
            }
            else
            {
                worksheet.Range("B3").SetExcelValue("OBO");
            }

            worksheet.Range("B4").SetExcelValue(DoubleType);
            worksheet.Range("B14").SetExcelValue(DAN);

            worksheet.Range("B5").SetExcelValue(DAS);

            worksheet.Range("B6").SetExcelValue(SurrType);
            worksheet.Range("B19").SetExcelValue(SAN);

            worksheet.Range("B7").SetExcelValue("SPL" + SPL.ToString());
            worksheet.Range("B8").SetExcelValue(BJPays);

            worksheet.Range("B10").SetExcelValue(SMA);
            worksheet.Range("B11").SetExcelValue(HSA);
            worksheet.Range("B12").SetExcelValue(DSA);
            worksheet.Range("B13").SetExcelValue(SSA);

            if (DSoftAllHard)
            {
                worksheet.Range("B16").SetExcelValue("All");
            }
            else if (DSoft19Hard)
            {
                worksheet.Range("B16").SetExcelValue("19 Only");
            }
            else
            {
                worksheet.Range("B16").SetExcelValue("False");
            }

            worksheet.Range("B18").SetExcelValue(SurrPays);
            worksheet.Range("B20").SetExcelValue(SurrDBJPays);
            worksheet.Range("B21").SetExcelValue(MacauType);
            worksheet.Range("B22").SetExcelValue(SAS);

            if (CDP)
            {
                worksheet.Range("B24").SetExcelValue("CDP");
            }
            else if (CDPN)
            {
                worksheet.Range("B24").SetExcelValue("CDPN");
            }
            else
            {
                worksheet.Range("B24").SetExcelValue("CDZ-");
            }

            worksheet.Range("B25").SetExcelValue(BJSplitAces);
            worksheet.Range("B26").SetExcelValue(BJSplitTens);

            worksheet.Range("B28").SetExcelValue(CheckTen);
            worksheet.Range("B29").SetExcelValue(CheckAce);

            for (card = 1; card <= 10; card++)
                worksheet.Range("E11").Offset(0, card - 1).SetExcelValue(SplitAllowed[card]);

            for (card = 17; card <= 22; card++)
                worksheet.Range("E16").Offset(card - 17, 0).SetExcelValue(PDTies[card]);

            worksheet = null;

            worksheet = workBook.Worksheet("Special Rules");

            worksheet.Range("A2").EndDown().ClearContents();
            worksheet.Range("C2").EndDown().ClearContents();
            worksheet.Range("A1").SelectOnly();

            row = 0;
            var loopTo = BonusRulesList.NumRules - 1;
            for (card = 0; card <= loopTo; card++)
            {
                if (BonusRulesList.L[card].RuleOn)
                {
                    worksheet.Range("A2").Offset(row, 0).SetExcelValue(BonusRulesList.L[card].Name);
                    row += 1;
                }
            }
            if (row == 0)
            {
                worksheet.Range("A2").SetExcelValue("None");
            }

            row = 0;
            var loopTo1 = ForcedTableRulesList.NumRules - 1;
            for (card = 0; card <= loopTo1; card++)
            {
                if (ForcedTableRulesList.L[card].RuleOn)
                {
                    worksheet.Range("C2").Offset(row, 0).SetExcelValue(ForcedTableRulesList.L[card].Name);
                    row += 1;
                }
            }
            var loopTo2 = ForcedRulesList.NumRules - 1;
            for (card = 0; card <= loopTo2; card++)
            {
                if (ForcedRulesList.L[card].RuleOn)
                {
                    worksheet.Range("C2").Offset(row, 0).SetExcelValue(ForcedRulesList.L[card].Name);
                    row += 1;
                }
            }
            if (row == 0)
            {
                worksheet.Range("C2").SetExcelValue("None");
            }

            worksheet = null;
        }

        #endregion

        #region  EOR Methods 

        public void CopyEOREVs(ref BJCAEORsClass newEVs, ref BJCA oldCA)
        {
            int upcard;
            int total;
            int soft;
            int oldIndex;
            int index;

            newEVs.ForcedNetGameEV = Forced.GameEVs.NetGameEV;
            newEVs.CDNetGameEV = Opt.GameEVs.NetGameEV;
            newEVs.TDNetGameEV = TD.GameEVs.NetGameEV;

            for (total = 4; total <= 21; total++)
            {
                for (soft = 0; soft <= 1; soft++)
                {
                    if (total > 12 | soft == Conversions.ToInteger(false) + 1)
                    {
                        if (Forced.StratTD[total, soft] is not null)
                        {
                            if (newEVs.ForcedStratTD[total, soft] is null)
                                newEVs.ForcedStratTD[total, soft] = new BJCATDStratClass();
                            for (upcard = 1; upcard <= 10; upcard++)
                            {
                                if (UCAllowed[upcard])
                                {
                                    newEVs.ForcedStratTD[total, soft].Strat[upcard] = Forced.StratTD[total, soft].Strat[upcard];
                                    newEVs.ForcedStratTD[total, soft].StratEV[upcard] = Forced.StratTD[total, soft].StratEV[upcard];
                                    newEVs.ForcedStratTD[total, soft].StratStandEV[upcard] = Forced.StratTD[total, soft].StratStandEV[upcard];
                                    newEVs.ForcedStratTD[total, soft].StratDEV[upcard] = Forced.StratTD[total, soft].StratDEV[upcard];
                                    newEVs.ForcedStratTD[total, soft].StratSurrEV[upcard] = Forced.StratTD[total, soft].StratSurrEV[upcard];
                                    newEVs.ForcedStratTD[total, soft].StratHitEV[upcard] = Forced.StratTD[total, soft].StratHitEV[upcard];
                                }
                            }
                        }

                        if (TD.StratTD[total, soft] is not null)
                        {
                            if (newEVs.TDStratTD[total, soft] is null)
                                newEVs.TDStratTD[total, soft] = new BJCATDStratClass();
                            for (upcard = 1; upcard <= 10; upcard++)
                            {
                                if (UCAllowed[upcard])
                                {
                                    newEVs.TDStratTD[total, soft].Strat[upcard] = TD.StratTD[total, soft].Strat[upcard];
                                    newEVs.TDStratTD[total, soft].StratEV[upcard] = TD.StratTD[total, soft].StratEV[upcard];
                                    newEVs.TDStratTD[total, soft].StratStandEV[upcard] = TD.StratTD[total, soft].StratStandEV[upcard];
                                    newEVs.TDStratTD[total, soft].StratDEV[upcard] = TD.StratTD[total, soft].StratDEV[upcard];
                                    newEVs.TDStratTD[total, soft].StratSurrEV[upcard] = TD.StratTD[total, soft].StratSurrEV[upcard];
                                    newEVs.TDStratTD[total, soft].StratHitEV[upcard] = TD.StratTD[total, soft].StratHitEV[upcard];
                                }
                            }
                        }
                    }
                }
            }

            var loopTo = NumPHands;
            for (index = 1; index <= loopTo; index++)
            {
                if (PlayerHands[index].Hand.NumCards > 1)
                {
                    oldIndex = oldCA.FindPlayerHand(PlayerHands[index].Hand);
                    if (newEVs.EVs[oldIndex] is null)
                        newEVs.EVs[oldIndex] = new BJCAEOREVsClass();
                    for (upcard = 1; upcard <= 10; upcard++)
                    {
                        if (UCAllowed[upcard])
                        {
                            newEVs.EVs[oldIndex].StandEV[upcard] = PlayerHands[index].HandEVs.StandEV[upcard];
                            newEVs.EVs[oldIndex].StandPushEV[upcard] = PlayerHands[index].HandEVs.StandPushEV[upcard];
                            newEVs.EVs[oldIndex].DEV[upcard] = PlayerHands[index].HandEVs.DEV[upcard];
                            newEVs.EVs[oldIndex].DPushEV[upcard] = PlayerHands[index].HandEVs.DPushEV[upcard];
                            newEVs.EVs[oldIndex].SurrEV[upcard] = PlayerHands[index].HandEVs.SurrEV[upcard];

                            newEVs.EVs[oldIndex].ForcedStrat[upcard] = Forced.HandEVs[index].EVs.Strat[upcard];
                            newEVs.EVs[oldIndex].ForcedHitEV[upcard] = Forced.HandEVs[index].EVs.HitEV[upcard];
                            newEVs.EVs[oldIndex].ForcedHitPushEV[upcard] = Forced.HandEVs[index].EVs.HitPushEV[upcard];
                            newEVs.EVs[oldIndex].ForcedSplitEV[upcard] = Forced.HandEVs[index].SplitEV[upcard];

                            newEVs.EVs[oldIndex].CDStrat[upcard] = Opt.HandEVs[index].EVs.Strat[upcard];
                            newEVs.EVs[oldIndex].CDHitEV[upcard] = Opt.HandEVs[index].EVs.HitEV[upcard];
                            newEVs.EVs[oldIndex].CDHitPushEV[upcard] = Opt.HandEVs[index].EVs.HitPushEV[upcard];
                            newEVs.EVs[oldIndex].CDSplitEV[upcard] = Opt.HandEVs[index].SplitEV[upcard];

                            newEVs.EVs[oldIndex].TDStrat[upcard] = TD.HandEVs[index].EVs.Strat[upcard];
                            newEVs.EVs[oldIndex].TDHitEV[upcard] = TD.HandEVs[index].EVs.HitEV[upcard];
                            newEVs.EVs[oldIndex].TDHitPushEV[upcard] = TD.HandEVs[index].EVs.HitPushEV[upcard];
                            newEVs.EVs[oldIndex].TDSplitEV[upcard] = TD.HandEVs[index].SplitEV[upcard];
                        }
                    }
                }
            }

        }

        public void CopyEORForcedStrat(ref BJCA oldCA)
        {
            int upcard;
            int total;
            int soft;
            int oldIndex;
            int index;

            ResetForcedRulesHands(ref Forced);
            for (total = 4; total <= 21; total++)
            {
                for (soft = 0; soft <= 1; soft++)
                {
                    Forced.StratTD[total, soft] = null;
                    if (total > 12 | soft == Conversions.ToInteger(false) + 1)
                    {
                        if (oldCA.Forced.StratTD[total, soft] is not null)
                        {
                            Forced.StratTD[total, soft] = new BJCATDStratClass();
                            for (upcard = 1; upcard <= 10; upcard++)
                            {
                                if (UCAllowed[upcard])
                                {
                                    Forced.StratTD[total, soft].Strat[upcard] = oldCA.Forced.StratTD[total, soft].Strat[upcard];
                                }
                            }
                        }
                    }
                }
            }

            var loopTo = NumPHands;
            for (index = 1; index <= loopTo; index++)
            {
                if (PlayerHands[index].Hand.NumCards > 1)
                {
                    oldIndex = oldCA.FindPlayerHand(PlayerHands[index].Hand);
                    for (upcard = 1; upcard <= 10; upcard++)
                    {
                        if (UCAllowed[upcard])
                        {
                            Forced.HandEVs[index].PreForced[upcard] = true;
                            Forced.HandEVs[index].PostForced[upcard] = true;
                            Forced.HandEVs[index].EVs.Strat[upcard] = oldCA.Forced.HandEVs[oldIndex].EVs.Strat[upcard];
                            Forced.HandEVs[index].EVs.ForcedPostStrat[upcard] = oldCA.Forced.HandEVs[oldIndex].EVs.ForcedPostStrat[upcard];
                        }
                    }
                }
            }

        }

        public void FixForcedStrat(ref BJCAStrategyClass cstrat)
        {
            int index;
            int upcard;

            var loopTo = NumPHands;
            for (index = 0; index <= loopTo; index++)
            {
                if (PlayerHands[index].Hand.NumCards > 1)
                {
                    for (upcard = 1; upcard <= 10; upcard++)
                    {
                        if (UCAllowed[upcard])
                        {
                            cstrat.HandEVs[index].PreForced[upcard] = true;
                            cstrat.HandEVs[index].PostForced[upcard] = true;
                        }
                    }
                }
            }
        }

        public void ComputeEORForcedStrat(ref BJCAStrategyClass cstrat)
        {
            int total;
            int soft;
            double prob;
            int card;
            int index;
            int upcard;

            for (upcard = 1; upcard <= 10; upcard++)
            {
                if (UCAllowed[upcard] & CardProb(upcard, 0) > 0d)
                {
                    if (SPL > 0)
                    {
                        for (card = 1; card <= 10; card++)
                        {
                            if (SplitIndex[card, upcard] > 0)
                            {
                                index = SplitIndex[card, upcard];
                                ComputeSplit(ref cstrat, card, upcard);
                            }
                        }
                    }

                    DealDCard(upcard);

                    GetHandsUsed(ref cstrat, upcard, 1, true);

                    // Calculate the final overall hitting values using the current strategy
                    ComputeStratHit(ref cstrat, upcard);

                    for (total = 4; total <= 21; total++)
                    {
                        for (soft = 0; soft <= 1; soft++)
                        {
                            if (cstrat.StratTD[total, soft] is not null)
                            {
                                // First empty the strategy
                                cstrat.StratTD[total, soft].StratEV[upcard] = 0d;
                                cstrat.StratTD[total, soft].StratStandEV[upcard] = 0d;
                                cstrat.StratTD[total, soft].StratHitEV[upcard] = 0d;
                                cstrat.StratTD[total, soft].StratDEV[upcard] = 0d;
                                cstrat.StratTD[total, soft].StratSurrEV[upcard] = 0d;

                                cstrat.StratTD[total, soft].NetProb[upcard] = 0d;
                                cstrat.StratTD[total, soft].NetSProb[upcard] = 0d;
                                cstrat.StratTD[total, soft].NetHProb[upcard] = 0d;
                                cstrat.StratTD[total, soft].NetDProb[upcard] = 0d;
                                cstrat.StratTD[total, soft].NetSurrProb[upcard] = 0d;

                                cstrat.StratTD[total, soft].SStandEV[upcard] = 0d;
                                cstrat.StratTD[total, soft].SHitEV[upcard] = 0d;
                                cstrat.StratTD[total, soft].SDEV[upcard] = 0d;
                                cstrat.StratTD[total, soft].SSurrEV[upcard] = 0d;

                                // Begin by removing hands that are CD dependent including split hands
                                prob = 0d;
                                index = PlayerHandTotal[total, soft];
                                while (index != 0)
                                {
                                    if (PlayerHands[index].Hand.NumCards < 2 | cstrat.NCardsCD != 0 & PlayerHands[index].Hand.NumCards <= cstrat.NCardsCD)
                                    {
                                        cstrat.HandEVs[index].HandUsed[upcard] = -1;
                                    }
                                    // Don't include blackjack in the strategy determination
                                    if (PlayerHands[index].Hand.IsBJ())
                                    {
                                        cstrat.HandEVs[index].HandUsed[upcard] = -1;
                                    }
                                    switch (cstrat.HandEVs[index].EVs.Strat[upcard])
                                    {
                                        case (int)BJCAGlobalsClass.Strat.P:
                                        case (int)BJCAGlobalsClass.Strat.PS:
                                        case (int)BJCAGlobalsClass.Strat.PD:
                                        case (int)BJCAGlobalsClass.Strat.PH:
                                        case (int)BJCAGlobalsClass.Strat.PR:
                                            {
                                                cstrat.HandEVs[index].HandUsed[upcard] = -1;
                                                break;
                                            }
                                    }
                                    if (cstrat.HandEVs[index].HandUsed[upcard] == 1)
                                    {
                                        prob += 1d;
                                    }
                                    index = PlayerHands[index].NextHand;
                                }

                                // Now fill in all the evs
                                index = PlayerHandTotal[total, soft];
                                while (index != 0)
                                {
                                    if (PlayerHands[index].Hand.NumCards > 1 & PlayerHands[index].Hand.NumCards > cstrat.NCardsCD & cstrat.HandEVs[index].HandUsed[upcard] > 0)
                                    {
                                        prob = PlayerHands[index].HandEVs.Prob[upcard] * cstrat.HandEVs[index].Multiplier[upcard];
                                        cstrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].NetProb[upcard] += prob;
                                        if (cstrat.HandEVs[index].SPreallowed[upcard])
                                        {
                                            cstrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].NetSProb[upcard] += prob;
                                            cstrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].StratStandEV[upcard] += prob * PlayerHands[index].HandEVs.StandEV[upcard];
                                        }
                                        if (cstrat.HandEVs[index].HPreallowed[upcard])
                                        {
                                            cstrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].NetHProb[upcard] += prob;
                                            cstrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].StratHitEV[upcard] += prob * cstrat.HandEVs[index].EVs.HitEV[upcard];
                                        }
                                        if (cstrat.HandEVs[index].DPreallowed[upcard])
                                        {
                                            cstrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].NetDProb[upcard] += prob;
                                            cstrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].StratDEV[upcard] += prob * PlayerHands[index].HandEVs.DEV[upcard];
                                        }
                                        if (cstrat.HandEVs[index].RPreallowed[upcard] > 0)
                                        {
                                            cstrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].NetSurrProb[upcard] += prob;
                                            cstrat.StratTD[PlayerHands[index].Hand.Total, Conversions.ToInteger(PlayerHands[index].Hand.Soft) + 1].StratSurrEV[upcard] += prob * PlayerHands[index].HandEVs.SurrEV[upcard];
                                        }
                                    }
                                    index = PlayerHands[index].NextHand;
                                }

                                // Now we need to normalize the ev's
                                if (cstrat.StratTD[total, soft].NetSProb[upcard] != 0d)
                                {
                                    cstrat.StratTD[total, soft].StratStandEV[upcard] = cstrat.StratTD[total, soft].StratStandEV[upcard] / cstrat.StratTD[total, soft].NetSProb[upcard];
                                }
                                if (cstrat.StratTD[total, soft].NetHProb[upcard] != 0d)
                                {
                                    cstrat.StratTD[total, soft].StratHitEV[upcard] = cstrat.StratTD[total, soft].StratHitEV[upcard] / cstrat.StratTD[total, soft].NetHProb[upcard];
                                }
                                if (cstrat.StratTD[total, soft].NetDProb[upcard] != 0d)
                                {
                                    cstrat.StratTD[total, soft].StratDEV[upcard] = cstrat.StratTD[total, soft].StratDEV[upcard] / cstrat.StratTD[total, soft].NetDProb[upcard];
                                }
                                if (cstrat.StratTD[total, soft].NetSurrProb[upcard] != 0d)
                                {
                                    cstrat.StratTD[total, soft].StratSurrEV[upcard] = cstrat.StratTD[total, soft].StratSurrEV[upcard] / cstrat.StratTD[total, soft].NetSurrProb[upcard];
                                }

                            }
                        }
                    }
                    UndealDCard(upcard);
                }
            }


            ComputeGameEVsStrat(ref cstrat);
        }

        #endregion

        #endregion

        #region  Real Time Methods 

        public BJCARealtimeHandClass BJCART(BJCAHandClass hand, int upcard, bool postsplit, int paircard, BJCARulesClass newRules, [Optional] ref BJCADealerProbsDictionary dpDict)
        {
            int card;
            int index;
            int suit;
            var tempEVs = new BJCAStratHandEVsClass();
            var newEVs = new BJCARealtimeHandClass();

            GetRules(newRules);
            Initialize(newRules);

            if (dpDict is not null)
                DealerProbs = dpDict;
            ApplyRulesStrat(newRules, postsplit);

            ComputeHandProbsPreSplit();
            ComputeStand();
            ComputeBlackjack();
            ComputeSurrender();
            ComputeDouble();
            ApplyBonusRulesPreSuited();
            ComputeOptInitialStrat();
            ComputeOptHit();

            if (SPL > 0)
            {
                InitializeSplits();
                ComputeOptSplit();
            }

            EnumSuitedBonusHandList();
            EnumSuitedHandList();
            ComputeSuitedHandNetEVs(ref Opt);

            index = FindPlayerHand(hand);

            newEVs.Hand.StandEV[upcard] = PlayerHands[index].HandEVs.StandEV[upcard];
            newEVs.Hand.DEV[upcard] = PlayerHands[index].HandEVs.DEV[upcard];
            newEVs.Hand.SurrEV[upcard] = PlayerHands[index].HandEVs.SurrEV[upcard];
            newEVs.Hand.StratEV[upcard] = Opt.HandEVs[index].EVs.StratEV[upcard];
            newEVs.Hand.HitEV[upcard] = Opt.HandEVs[index].EVs.HitEV[upcard];
            newEVs.Hand.SplitEV[upcard] = Opt.HandEVs[index].SplitEV[upcard];

            // DealerProbs will hold the suited probs
            for (suit = 0; suit <= 3; suit++)
                newEVs.Hand.DealerProbs[upcard, suit] = PlayerHands[index].HandEVs.ProbSuited[upcard, suit];

            if (PlayerHands[index].SuitedBonusEVs is not null)
            {
                newEVs.SuitedEVs = PlayerHands[index].SuitedBonusEVs;
            }

            if (RDA | DDR)
            {
                newEVs.Hand.DAllowed[upcard] = DoubleNeeded[index, upcard];
                newEVs.Hand.RAllowed[upcard] = Conversions.ToInteger(SurrenderNeeded[index, upcard]);
            }
            else
            {
                newEVs.Hand.DAllowed[upcard] = Opt.HandEVs[index].DPreallowed[upcard];
                newEVs.Hand.RAllowed[upcard] = Opt.HandEVs[index].RPreallowed[upcard];
            }
            newEVs.Hand.PAllowed[upcard] = Opt.HandEVs[index].PAllowed[upcard];

            switch (Opt.HandEVs[index].EVs.Strat[upcard])
            {
                case (int)BJCAGlobalsClass.Strat.PS:
                case (int)BJCAGlobalsClass.Strat.PR:
                case (int)BJCAGlobalsClass.Strat.PH:
                case (int)BJCAGlobalsClass.Strat.PD:
                    {
                        newEVs.Hand.Strat[upcard] = (int)BJCAGlobalsClass.Strat.P;
                        break;
                    }
                case (int)BJCAGlobalsClass.Strat.DS:
                    {
                        newEVs.Hand.Strat[upcard] = (int)BJCAGlobalsClass.Strat.D;
                        break;
                    }
                case (int)BJCAGlobalsClass.Strat.RS:
                    {
                        newEVs.Hand.Strat[upcard] = (int)BJCAGlobalsClass.Strat.R;
                        break;
                    }

                default:
                    {
                        newEVs.Hand.Strat[upcard] = Opt.HandEVs[index].EVs.Strat[upcard];
                        break;
                    }
            }

            if (paircard == 1 & postsplit & (!(newEVs.Hand.StratEV[upcard] == (double)BJCAGlobalsClass.Strat.P) | !SMA))
            {
                tempEVs = ComputePostSplitAcesStratRT(index, upcard);
                newEVs.Hand.DEV[upcard] = tempEVs.DEV[upcard];
                newEVs.Hand.SurrEV[upcard] = tempEVs.SurrEV[upcard];
                newEVs.Hand.Strat[upcard] = tempEVs.Strat[upcard];
                newEVs.Hand.StratEV[upcard] = tempEVs.StratEV[upcard];
                newEVs.Hand.HitEV[upcard] = tempEVs.HitEV[upcard];
                newEVs.Hand.DAllowed[upcard] = tempEVs.DAllowed[upcard];
                newEVs.Hand.RAllowed[upcard] = tempEVs.RAllowed[upcard];
                newEVs.Hand.SplitEV[upcard] = tempEVs.SplitEV[upcard];
                newEVs.Hand.PAllowed[upcard] = false;
            }

            return newEVs;

        }

        private BJCAStratHandEVsClass ComputePostSplitAcesStratRT(int index, int upcard)
        {
            var newHandEVs = new BJCAStratHandEVsClass();

            // Now get the strategy and strategy EV
            newHandEVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.S;
            newHandEVs.StratEV[upcard] = PlayerHands[index].HandEVs.StandEV[upcard];

            if (HSA)
            {
                newHandEVs.HitEV[upcard] = Opt.HandEVs[index].EVs.HitEV[upcard];
                if (Opt.HandEVs[index].EVs.HitEV[upcard] > newHandEVs.StratEV[upcard])
                {
                    newHandEVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.H;
                    newHandEVs.StratEV[upcard] = Opt.HandEVs[index].EVs.HitEV[upcard];
                }
            }
            if (DSA)
            {
                newHandEVs.DEV[upcard] = PlayerHands[index].HandEVs.DEV[upcard];
                if (PlayerHands[index].HandEVs.DEV[upcard] > newHandEVs.StratEV[upcard])
                {
                    newHandEVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.D;
                    newHandEVs.StratEV[upcard] = PlayerHands[index].HandEVs.DEV[upcard];
                }
            }
            else
            {
                newHandEVs.DAllowed[upcard] = false;
            }
            if (SSA)
            {
                newHandEVs.SurrEV[upcard] = PlayerHands[index].HandEVs.SurrEV[upcard];
                if (PlayerHands[index].HandEVs.SurrEV[upcard] > newHandEVs.StratEV[upcard])
                {
                    newHandEVs.Strat[upcard] = (int)BJCAGlobalsClass.Strat.R;
                    newHandEVs.StratEV[upcard] = PlayerHands[index].HandEVs.SurrEV[upcard];
                }
            }
            else
            {
                newHandEVs.RAllowed[upcard] = 0;
            }

            return newHandEVs;
        }

        #endregion

        #region  N Card Strategy Methods 

        public BJCATDStratClass ComputeNCardStratEVs(ref BJCAStrategyClass cStrat, int total, int soft, int upcard, int nCards, bool orMore, bool orLess, bool handsUsed)
        {
            // Soft is passed as the Boolean+1 value
            int index;
            double prob;
            double maxev;
            bool handIncluded;

            double NetProb;
            double NetSProb;
            double NetHProb;
            double NetDProb;
            double NetSurrProb;

            double SStandEV;
            double SHitEV;
            double SDEV;
            double SSurrEV;
            double SSplitEV;
            var Strat = default(int);

            var newEvs = new BJCATDStratClass();

            // The following procedure is based on the fact that the only values that change with
            // strategy changes are hit/split
            // The only thing these values can do is decrease compared to optimal play
            // Only a single pass is performed

            // First empty the strategy
            NetProb = 0d;
            NetSProb = 0d;
            NetHProb = 0d;
            NetDProb = 0d;
            NetSurrProb = 0d;

            SStandEV = 0d;
            SHitEV = 0d;
            SDEV = 0d;
            SSurrEV = 0d;
            SSplitEV = 0d;

            // Now begin by seeing if any hands are included in the requirements and get the 
            // split ev if there is one
            prob = 0d;
            index = PlayerHandTotal[total, soft];
            while (index != 0)
            {
                if (cStrat.HandEVs[index].SplitEV[upcard] != 0d)
                {
                    SSplitEV = cStrat.HandEVs[index].SplitEV[upcard];
                }
                handIncluded = (!handsUsed | cStrat.HandEVs[index].HandUsed[upcard] == 1) & PlayerHands[index].Hand.NumCards == nCards;
                if (handIncluded)
                {
                    prob += 1d;
                    break;
                }
                index = PlayerHands[index].NextHand;
            }

            if (prob > 0d)
            {
                // Fill in the strategy using all used hands to start
                // First look at hands where both double and surrender are allowed
                index = PlayerHandTotal[total, soft];
                while (index != 0)
                {
                    handIncluded = (!handsUsed | cStrat.HandEVs[index].HandUsed[upcard] == 1) & (PlayerHands[index].Hand.NumCards == nCards | orMore & PlayerHands[index].Hand.NumCards >= nCards | orLess & PlayerHands[index].Hand.NumCards <= nCards & PlayerHands[index].Hand.NumCards > 1);
                    if (Conversions.ToBoolean(Conversions.ToInteger(handIncluded) & cStrat.HandEVs[index].RPreallowed[upcard] & Conversions.ToInteger(cStrat.HandEVs[index].DPreallowed[upcard])))
                    {
                        if (handsUsed)
                        {
                            prob = PlayerHands[index].HandEVs.Prob[upcard] * cStrat.HandEVs[index].Multiplier[upcard];
                        }
                        else
                        {
                            prob = PlayerHands[index].HandEVs.Prob[upcard];
                        }
                        NetProb += prob;
                        SStandEV += prob * PlayerHands[index].HandEVs.StandEV[upcard];
                        SDEV += prob * PlayerHands[index].HandEVs.DEV[upcard];
                        SHitEV += prob * Opt.HandEVs[index].EVs.HitEV[upcard];
                        SSurrEV += prob * PlayerHands[index].HandEVs.SurrEV[upcard];
                    }
                    index = PlayerHands[index].NextHand;
                }

                // If the probability of a strategy option is 0 then prevent it from being the strategy
                if (NetProb != 0d)
                {
                    if (SStandEV == 0d)
                        SStandEV = -2;
                    if (SDEV == 0d)
                        SDEV = -2;
                    if (SHitEV == 0d)
                        SHitEV = -2;
                    if (SSurrEV == 0d)
                        SSurrEV = -2;
                }

                // Compare double/surrender to hit/stand
                if (NetProb != 0d)
                {
                    Strat = (int)BJCAGlobalsClass.Strat.S;
                    maxev = SStandEV;
                    if (SHitEV > maxev)
                    {
                        Strat = (int)BJCAGlobalsClass.Strat.H;
                        maxev = SHitEV;
                    }
                    if (SDEV > maxev)
                    {
                        Strat = (int)BJCAGlobalsClass.Strat.D;
                        maxev = SDEV;
                    }
                    if (SSurrEV >= maxev)
                    {
                        Strat = (int)BJCAGlobalsClass.Strat.R;
                    }
                }

                // Now check values where only double is allowed and the strategy hasn't been set to surrender/split
                NetProb = 0d;

                SStandEV = 0d;
                SHitEV = 0d;
                SDEV = 0d;
                SSurrEV = 0d;

                if (Strat != (int)BJCAGlobalsClass.Strat.R & Strat != (int)BJCAGlobalsClass.Strat.RS)
                {
                    index = PlayerHandTotal[total, soft];
                    while (index != 0)
                    {
                        handIncluded = (!handsUsed | cStrat.HandEVs[index].HandUsed[upcard] == 1) & (PlayerHands[index].Hand.NumCards == nCards | orMore & PlayerHands[index].Hand.NumCards >= nCards | orLess & PlayerHands[index].Hand.NumCards <= nCards & PlayerHands[index].Hand.NumCards > 1);
                        if (handIncluded & cStrat.HandEVs[index].DPreallowed[upcard])
                        {
                            if (handsUsed)
                            {
                                prob = PlayerHands[index].HandEVs.Prob[upcard] * cStrat.HandEVs[index].Multiplier[upcard];
                            }
                            else
                            {
                                prob = PlayerHands[index].HandEVs.Prob[upcard];
                            }
                            NetProb += prob;
                            SStandEV += prob * PlayerHands[index].HandEVs.StandEV[upcard];
                            SDEV += prob * PlayerHands[index].HandEVs.DEV[upcard];
                            SHitEV += prob * cStrat.HandEVs[index].EVs.HitEV[upcard];
                        }
                        index = PlayerHands[index].NextHand;
                    }
                }

                // If the probability of a strategy option is 0 then prevent it from being the strategy
                if (NetProb != 0d)
                {
                    if (SStandEV == 0d)
                        SStandEV = -2;
                    if (SDEV == 0d)
                        SDEV = -2;
                    if (SHitEV == 0d)
                        SHitEV = -2;
                    if (SSurrEV == 0d)
                        SSurrEV = -2;
                }

                // Compare double to hit/stand
                if (NetProb != 0d)
                {
                    Strat = (int)BJCAGlobalsClass.Strat.S;
                    maxev = SStandEV;
                    if (SHitEV > maxev)
                    {
                        Strat = (int)BJCAGlobalsClass.Strat.H;
                        maxev = SHitEV;
                    }
                    if (SDEV > maxev)
                    {
                        Strat = (int)BJCAGlobalsClass.Strat.D;
                    }
                }

                // Now check values where only surrender is allowed and the strategy hasn't been set to double/split
                NetProb = 0d;

                SStandEV = 0d;
                SHitEV = 0d;
                SDEV = 0d;
                SSurrEV = 0d;

                if (Strat != (int)BJCAGlobalsClass.Strat.D & Strat != (int)BJCAGlobalsClass.Strat.DS)
                {
                    index = PlayerHandTotal[total, soft];
                    while (index != 0)
                    {
                        handIncluded = (!handsUsed | cStrat.HandEVs[index].HandUsed[upcard] == 1) & (PlayerHands[index].Hand.NumCards == nCards | orMore & PlayerHands[index].Hand.NumCards >= nCards | orLess & PlayerHands[index].Hand.NumCards <= nCards & PlayerHands[index].Hand.NumCards > 1);
                        if (handIncluded & cStrat.HandEVs[index].RPreallowed[upcard] > 0)
                        {
                            if (handsUsed)
                            {
                                prob = PlayerHands[index].HandEVs.Prob[upcard] * cStrat.HandEVs[index].Multiplier[upcard];
                            }
                            else
                            {
                                prob = PlayerHands[index].HandEVs.Prob[upcard];
                            }
                            NetProb += prob;
                            SStandEV += prob * PlayerHands[index].HandEVs.StandEV[upcard];
                            SHitEV += prob * cStrat.HandEVs[index].EVs.HitEV[upcard];
                            SSurrEV += prob * PlayerHands[index].HandEVs.SurrEV[upcard];
                        }
                        index = PlayerHands[index].NextHand;
                    }
                }

                // If the probability of a strategy option is 0 then prevent it from being the strategy
                if (NetProb != 0d)
                {
                    if (SStandEV == 0d)
                        SStandEV = -2;
                    if (SHitEV == 0d)
                        SHitEV = -2;
                    if (SSurrEV == 0d)
                        SSurrEV = -2;
                }

                // Compare surrender to hit/stand
                if (NetProb != 0d)
                {
                    Strat = (int)BJCAGlobalsClass.Strat.S;
                    maxev = SStandEV;
                    if (SHitEV > maxev)
                    {
                        Strat = (int)BJCAGlobalsClass.Strat.H;
                        maxev = SHitEV;
                    }
                    if (SSurrEV > maxev)
                    {
                        Strat = (int)BJCAGlobalsClass.Strat.R;
                    }
                }

                // Now check values where neither surrender nor double is the strategy and the strategy hasn't been set to double/split
                NetProb = 0d;

                SStandEV = 0d;
                SHitEV = 0d;

                if (Strat != (int)BJCAGlobalsClass.Strat.D & Strat != (int)BJCAGlobalsClass.Strat.R)
                {
                    index = PlayerHandTotal[total, soft];
                    while (index != 0)
                    {
                        handIncluded = (!handsUsed | cStrat.HandEVs[index].HandUsed[upcard] == 1) & (PlayerHands[index].Hand.NumCards == nCards | orMore & PlayerHands[index].Hand.NumCards >= nCards | orLess & PlayerHands[index].Hand.NumCards <= nCards & PlayerHands[index].Hand.NumCards > 1);
                        if (handIncluded)
                        {
                            if (handsUsed)
                            {
                                prob = PlayerHands[index].HandEVs.Prob[upcard] * cStrat.HandEVs[index].Multiplier[upcard];
                            }
                            else
                            {
                                prob = PlayerHands[index].HandEVs.Prob[upcard];
                            }
                            NetProb += prob;
                            SStandEV += prob * PlayerHands[index].HandEVs.StandEV[upcard];
                            SHitEV += prob * cStrat.HandEVs[index].EVs.HitEV[upcard];
                        }
                        index = PlayerHands[index].NextHand;
                    }
                }

                // If the probability of a strategy option is 0 then prevent it from being the strategy
                if (NetProb != 0d)
                {
                    if (SStandEV == 0d)
                        SStandEV = -2;
                    if (SHitEV == 0d)
                        SHitEV = -2;
                }

                // Get the final strategy
                handIncluded = false;
                if ((total == 12 & soft == Conversions.ToInteger(true) + 1 | total == 4) & SplitTotalIndex[total, soft] > 0)
                {
                    switch (cStrat.HandEVs[SplitTotalIndex[total, soft]].EVs.Strat[upcard])
                    {
                        case (int)BJCAGlobalsClass.Strat.P:
                        case (int)BJCAGlobalsClass.Strat.PS:
                        case (int)BJCAGlobalsClass.Strat.PH:
                        case (int)BJCAGlobalsClass.Strat.PD:
                        case (int)BJCAGlobalsClass.Strat.PR:
                            {
                                // Use handincluded to determine if splitting is the strategy
                                handIncluded = true;
                                break;
                            }
                    }
                }
                if (handIncluded)
                {
                    if (Strat == (int)BJCAGlobalsClass.Strat.D & cStrat.HandEVs[SplitTotalIndex[total, soft]].DPostallowed[upcard])
                    {
                        Strat = (int)BJCAGlobalsClass.Strat.PD;
                    }
                    else if (Strat == (int)BJCAGlobalsClass.Strat.R & cStrat.HandEVs[SplitTotalIndex[total, soft]].RPostallowed[upcard] > 0)
                    {
                        Strat = (int)BJCAGlobalsClass.Strat.PR;
                    }
                    else if (SHitEV > SStandEV & cStrat.HandEVs[SplitTotalIndex[total, soft]].HPostallowed[upcard])
                    {
                        Strat = (int)BJCAGlobalsClass.Strat.PH;
                    }
                    else
                    {
                        Strat = (int)BJCAGlobalsClass.Strat.PS;
                    }
                }
                else if (Strat == (int)BJCAGlobalsClass.Strat.D)
                {
                    if (SStandEV > SHitEV & !DAN)
                    {
                        Strat = (int)BJCAGlobalsClass.Strat.DS;
                    }
                }
                else if (Strat == (int)BJCAGlobalsClass.Strat.R)
                {
                    if (SStandEV > SHitEV & !SAN)
                    {
                        Strat = (int)BJCAGlobalsClass.Strat.RS;
                    }
                }
                else
                {
                    Strat = (int)BJCAGlobalsClass.Strat.S;
                    maxev = SStandEV;
                    if (SHitEV > maxev)
                    {
                        Strat = (int)BJCAGlobalsClass.Strat.H;
                    }
                }

                // Now get the final EV's
                NetProb = 0d;
                NetSProb = 0d;
                NetHProb = 0d;
                NetDProb = 0d;
                NetSurrProb = 0d;

                SStandEV = 0d;
                SHitEV = 0d;
                SDEV = 0d;
                SSurrEV = 0d;

                index = PlayerHandTotal[total, soft];
                while (index != 0)
                {
                    handIncluded = (!handsUsed | cStrat.HandEVs[index].HandUsed[upcard] == 1) & (PlayerHands[index].Hand.NumCards == nCards | orMore & PlayerHands[index].Hand.NumCards >= nCards | orLess & PlayerHands[index].Hand.NumCards <= nCards & PlayerHands[index].Hand.NumCards > 1);
                    if (handIncluded)
                    {
                        if (handsUsed)
                        {
                            prob = PlayerHands[index].HandEVs.Prob[upcard] * cStrat.HandEVs[index].Multiplier[upcard];
                        }
                        else
                        {
                            prob = PlayerHands[index].HandEVs.Prob[upcard];
                        }
                        NetProb += prob;
                        if (cStrat.HandEVs[index].SPreallowed[upcard])
                        {
                            NetSProb += prob;
                            SStandEV += prob * PlayerHands[index].HandEVs.StandEV[upcard];
                        }
                        if (cStrat.HandEVs[index].HPreallowed[upcard])
                        {
                            NetHProb += prob;
                            SHitEV += prob * cStrat.HandEVs[index].EVs.HitEV[upcard];
                        }
                        if (cStrat.HandEVs[index].DPreallowed[upcard])
                        {
                            NetDProb += prob;
                            SDEV += prob * PlayerHands[index].HandEVs.DEV[upcard];
                        }
                        if (cStrat.HandEVs[index].RPreallowed[upcard] > 0)
                        {
                            NetSurrProb += prob;
                            SSurrEV += prob * PlayerHands[index].HandEVs.SurrEV[upcard];
                        }
                    }
                    index = PlayerHands[index].NextHand;
                }

                // Now we need to normalize the ev's
                if (NetSProb != 0d)
                {
                    SStandEV /= NetSProb;
                    NetSProb /= NetProb;
                }
                if (NetHProb != 0d)
                {
                    SHitEV /= NetHProb;
                    NetHProb /= NetProb;
                }
                if (NetDProb != 0d)
                {
                    SDEV /= NetDProb;
                    NetDProb /= NetProb;
                }
                if (NetSurrProb != 0d)
                {
                    SSurrEV /= NetSurrProb;
                    NetSurrProb /= NetProb;
                }

                // StratEV will hold the SplitEV
                newEvs.Strat[upcard] = Strat;
                newEvs.StratStandEV[upcard] = SStandEV;
                newEvs.StratHitEV[upcard] = SHitEV;
                newEvs.StratDEV[upcard] = SDEV;
                newEvs.StratSurrEV[upcard] = SSurrEV;
                newEvs.StratEV[upcard] = SSplitEV;
                newEvs.NetProb[upcard] = NetProb;
                newEvs.NetSProb[upcard] = NetSProb;
                newEvs.NetHProb[upcard] = NetHProb;
                newEvs.NetDProb[upcard] = NetDProb;
                newEvs.NetSurrProb[upcard] = NetSurrProb;
            }

            return newEvs;

        }

        public void ComputeNCardStrat()
        {
            int index;
            int upcard;
            int total;
            int soft;
            int ncards;
            string UCStr;

            ResetForcedRulesHands(ref Forced);
            Forced.NCardOn = true;
            Forced.NCardsCD = 2;
            Forced.ComputeStrat = true;
            ForcedRulesList.Empty();
            ForcedTableRulesList.Empty();

            // For each total/upcard do the following:
            // 1) First determine the 3 (or minimum) card strat based on CD play and add it to the forced table list
            // 2) See if/when the strategy changes.
            // 3) Confirm that it's still changed with an "or more" strategy"
            // 4) Add the change and recalculate the ev's

            for (upcard = 1; upcard <= 10; upcard++)
            {
                if (UCAllowed[upcard] & CardProb(upcard, 0) > 0d)
                {
                    for (total = 21; total >= 11; total -= 1)
                    {
                        Forced.StratTD[total, Conversions.ToInteger(false) + 1].NCardDeviation[upcard] = 0;
                        var twoCardStrat = new BJCATDStratClass();
                        var forcedTableRule = new BJCAForcedRulesClass();

                        for (index = Forced.NCardsCD + 1; index <= 21; index++)
                        {
                            twoCardStrat = ComputeNCardStratEVs(ref Opt, total, Conversions.ToInteger(false) + 1, upcard, index, false, false, true);
                            if (twoCardStrat.NetProb[upcard] > 0d)
                            {
                                forcedTableRule.Upcard = upcard;
                                switch (upcard)
                                {
                                    case 0:
                                        {
                                            UCStr = "A";
                                            break;
                                        }
                                    case 9:
                                        {
                                            UCStr = "T";
                                            break;
                                        }

                                    default:
                                        {
                                            UCStr = upcard.ToString();
                                            break;
                                        }
                                }
                                forcedTableRule.Hand.Total = total;
                                forcedTableRule.Hand.Soft = false;
                                forcedTableRule.Strat = twoCardStrat.Strat[upcard];
                                forcedTableRule.UseSpecificHand = false;
                                forcedTableRule.Name = "H" + forcedTableRule.Hand.Total.ToString() + " vs " + UCStr + " " + C.StratLongText[forcedTableRule.Strat];
                                forcedTableRule.RuleOn = true;
                                ForcedTableRulesList.AddForcedRule(forcedTableRule);
                                break;
                            }
                        }

                        if (index < 21)
                        {
                            for (ncards = index + 1; ncards <= 21; ncards++)
                            {
                                var nCardStrat = new BJCATDStratClass();

                                nCardStrat = ComputeNCardStratEVs(ref Opt, total, Conversions.ToInteger(false) + 1, upcard, ncards, false, false, true);

                                if (twoCardStrat.Strat[upcard] != (int)BJCAGlobalsClass.Strat.None & nCardStrat.Strat[upcard] != (int)BJCAGlobalsClass.Strat.None & nCardStrat.Strat[upcard] != twoCardStrat.Strat[upcard])
                                {
                                    var ncardOrMoreStrat = new BJCATDStratClass();

                                    ncardOrMoreStrat = ComputeNCardStratEVs(ref Opt, total, Conversions.ToInteger(false) + 1, upcard, ncards, true, false, true);
                                    if (ncardOrMoreStrat.Strat[upcard] == nCardStrat.Strat[upcard])
                                    {
                                        var ForcedRule = new BJCAForcedRulesClass();

                                        Forced.StratTD[total, Conversions.ToInteger(false) + 1].NCardStrat[upcard] = ncardOrMoreStrat.Strat[upcard];
                                        Forced.StratTD[total, Conversions.ToInteger(false) + 1].NCardDeviation[upcard] = ncards;

                                        ForcedRule.Name = ncards.ToString() + "-Card ";
                                        ForcedRule.Name += "H";
                                        ForcedRule.Name += total.ToString() + " v " + upcard.ToString() + " " + C.StratShortText[ncardOrMoreStrat.Strat[upcard]];
                                        ForcedRule.RuleOn = true;
                                        ForcedRule.UseSpecificHand = false;

                                        ForcedRule.Hand.Empty();
                                        ForcedRule.Hand.Total = total;
                                        ForcedRule.Hand.NumCards = ncards;
                                        ForcedRule.Hand.Soft = false;
                                        ForcedRule.ExactMatch = false;

                                        ForcedRule.OrMore = true;
                                        ForcedRule.OrLess = false;

                                        ForcedRule.PreSplit = true;
                                        ForcedRule.PostSplit = true;

                                        ForcedRule.Upcard = upcard;
                                        ForcedRule.Strat = ncardOrMoreStrat.Strat[upcard];
                                        ForcedRulesList.AddForcedRule(ForcedRule);
                                        break;
                                    }
                                }
                            }
                            // If the strategy never changed then see if it's different than the n-card CD or less strategy
                            if (ncards > 21)
                            {
                                var ncardOrMoreStrat = new BJCATDStratClass();

                                twoCardStrat = ComputeNCardStratEVs(ref Opt, total, Conversions.ToInteger(false) + 1, upcard, Forced.NCardsCD, false, true, true);
                                ncardOrMoreStrat = ComputeNCardStratEVs(ref Opt, total, Conversions.ToInteger(false) + 1, upcard, Forced.NCardsCD + 1, true, false, true);

                                if (twoCardStrat.Strat[upcard] != (int)BJCAGlobalsClass.Strat.None & ncardOrMoreStrat.Strat[upcard] != (int)BJCAGlobalsClass.Strat.None & ncardOrMoreStrat.Strat[upcard] != twoCardStrat.Strat[upcard])
                                {
                                    var ForcedRule = new BJCAForcedRulesClass();

                                    Forced.StratTD[total, Conversions.ToInteger(false) + 1].NCardStrat[upcard] = ncardOrMoreStrat.Strat[upcard];
                                    Forced.StratTD[total, Conversions.ToInteger(false) + 1].NCardDeviation[upcard] = Forced.NCardsCD + 1;

                                    // The below rules must be added to fool the CA into listing the Ncard strat that it would do normally anyways.
                                    forcedTableRule.Upcard = upcard;
                                    switch (upcard)
                                    {
                                        case 0:
                                            {
                                                UCStr = "A";
                                                break;
                                            }
                                        case 9:
                                            {
                                                UCStr = "T";
                                                break;
                                            }

                                        default:
                                            {
                                                UCStr = upcard.ToString();
                                                break;
                                            }
                                    }
                                    forcedTableRule.Hand.Total = total;
                                    forcedTableRule.Hand.Soft = false;
                                    forcedTableRule.Strat = twoCardStrat.Strat[upcard];
                                    forcedTableRule.UseSpecificHand = false;
                                    forcedTableRule.Name = "H" + forcedTableRule.Hand.Total.ToString() + " vs " + UCStr + " " + C.StratLongText[forcedTableRule.Strat];
                                    forcedTableRule.RuleOn = true;
                                    ForcedTableRulesList.AddForcedRule(forcedTableRule);

                                    ForcedRule.Name = (Forced.NCardsCD + 1).ToString() + "-Card ";
                                    ForcedRule.Name += "H";
                                    ForcedRule.Name += total.ToString() + " v " + upcard.ToString() + " " + C.StratShortText[ncardOrMoreStrat.Strat[upcard]];
                                    ForcedRule.RuleOn = true;
                                    ForcedRule.UseSpecificHand = false;

                                    ForcedRule.Hand.Empty();
                                    ForcedRule.Hand.Total = total;
                                    ForcedRule.Hand.NumCards = Forced.NCardsCD + 1;
                                    ForcedRule.Hand.Soft = false;
                                    ForcedRule.ExactMatch = false;

                                    ForcedRule.OrMore = true;
                                    ForcedRule.OrLess = false;

                                    ForcedRule.PreSplit = true;
                                    ForcedRule.PostSplit = true;

                                    ForcedRule.Upcard = upcard;
                                    ForcedRule.Strat = ncardOrMoreStrat.Strat[upcard];
                                    ForcedRulesList.AddForcedRule(ForcedRule);
                                }
                            }
                        }
                    }

                    for (total = 21; total >= 13; total -= 1)
                    {
                        Forced.StratTD[total, Conversions.ToInteger(true) + 1].NCardDeviation[upcard] = 0;
                        var twoCardStrat = new BJCATDStratClass();
                        var forcedTableRule = new BJCAForcedRulesClass();

                        for (index = Forced.NCardsCD + 1; index <= 21; index++)
                        {
                            twoCardStrat = ComputeNCardStratEVs(ref Opt, total, Conversions.ToInteger(true) + 1, upcard, index, false, false, true);
                            if (twoCardStrat.NetProb[upcard] > 0d)
                            {
                                forcedTableRule.Upcard = upcard;
                                switch (upcard)
                                {
                                    case 0:
                                        {
                                            UCStr = "A";
                                            break;
                                        }
                                    case 9:
                                        {
                                            UCStr = "T";
                                            break;
                                        }

                                    default:
                                        {
                                            UCStr = upcard.ToString();
                                            break;
                                        }
                                }
                                forcedTableRule.Hand.Total = total;
                                forcedTableRule.Hand.Soft = true;
                                forcedTableRule.Strat = twoCardStrat.Strat[upcard];
                                forcedTableRule.UseSpecificHand = false;
                                forcedTableRule.Name = "S" + forcedTableRule.Hand.Total.ToString() + " vs " + UCStr + " " + C.StratLongText[forcedTableRule.Strat];
                                forcedTableRule.RuleOn = true;
                                ForcedTableRulesList.AddForcedRule(forcedTableRule);
                                break;
                            }
                        }

                        if (index < 21)
                        {
                            for (ncards = index + 1; ncards <= 21; ncards++)
                            {
                                var nCardStrat = new BJCATDStratClass();

                                nCardStrat = ComputeNCardStratEVs(ref Opt, total, Conversions.ToInteger(true) + 1, upcard, ncards, false, false, true);

                                if (twoCardStrat.Strat[upcard] != (int)BJCAGlobalsClass.Strat.None & nCardStrat.Strat[upcard] != (int)BJCAGlobalsClass.Strat.None & nCardStrat.Strat[upcard] != twoCardStrat.Strat[upcard])
                                {
                                    var ncardOrMoreStrat = new BJCATDStratClass();

                                    ncardOrMoreStrat = ComputeNCardStratEVs(ref Opt, total, Conversions.ToInteger(true) + 1, upcard, ncards, true, false, true);
                                    if (ncardOrMoreStrat.Strat[upcard] == nCardStrat.Strat[upcard])
                                    {
                                        var ForcedRule = new BJCAForcedRulesClass();

                                        Forced.StratTD[total, Conversions.ToInteger(true) + 1].NCardStrat[upcard] = ncardOrMoreStrat.Strat[upcard];
                                        Forced.StratTD[total, Conversions.ToInteger(true) + 1].NCardDeviation[upcard] = ncards;

                                        ForcedRule.Name = ncards.ToString() + "-Card ";
                                        ForcedRule.Name += "S";
                                        ForcedRule.Name += total.ToString() + " v " + upcard.ToString() + " " + C.StratShortText[ncardOrMoreStrat.Strat[upcard]];
                                        ForcedRule.RuleOn = true;
                                        ForcedRule.UseSpecificHand = false;

                                        ForcedRule.Hand.Empty();
                                        ForcedRule.Hand.Total = total;
                                        ForcedRule.Hand.NumCards = ncards;
                                        ForcedRule.Hand.Soft = true;
                                        ForcedRule.ExactMatch = false;

                                        ForcedRule.OrMore = true;
                                        ForcedRule.OrLess = false;

                                        ForcedRule.PreSplit = true;
                                        ForcedRule.PostSplit = true;

                                        ForcedRule.Upcard = upcard;
                                        ForcedRule.Strat = ncardOrMoreStrat.Strat[upcard];
                                        ForcedRulesList.AddForcedRule(ForcedRule);
                                        break;
                                    }
                                }
                            }
                            // If the strategy never changed then see if it's different than the n-card CD or less strategy
                            if (ncards > 21)
                            {
                                var ncardOrMoreStrat = new BJCATDStratClass();

                                twoCardStrat = ComputeNCardStratEVs(ref Opt, total, Conversions.ToInteger(true) + 1, upcard, Forced.NCardsCD, false, true, true);
                                ncardOrMoreStrat = ComputeNCardStratEVs(ref Opt, total, Conversions.ToInteger(true) + 1, upcard, Forced.NCardsCD + 1, true, false, true);

                                if (twoCardStrat.Strat[upcard] != (int)BJCAGlobalsClass.Strat.None & ncardOrMoreStrat.Strat[upcard] != (int)BJCAGlobalsClass.Strat.None & ncardOrMoreStrat.Strat[upcard] != twoCardStrat.Strat[upcard])
                                {
                                    var ForcedRule = new BJCAForcedRulesClass();

                                    Forced.StratTD[total, Conversions.ToInteger(true) + 1].NCardStrat[upcard] = ncardOrMoreStrat.Strat[upcard];
                                    Forced.StratTD[total, Conversions.ToInteger(true) + 1].NCardDeviation[upcard] = Forced.NCardsCD + 1;

                                    // The below rules must be added to fool the CA into listing the Ncard strat that it would do normally anyways.
                                    forcedTableRule.Upcard = upcard;
                                    switch (upcard)
                                    {
                                        case 0:
                                            {
                                                UCStr = "A";
                                                break;
                                            }
                                        case 9:
                                            {
                                                UCStr = "T";
                                                break;
                                            }

                                        default:
                                            {
                                                UCStr = upcard.ToString();
                                                break;
                                            }
                                    }
                                    forcedTableRule.Hand.Total = total;
                                    forcedTableRule.Hand.Soft = true;
                                    forcedTableRule.Strat = twoCardStrat.Strat[upcard];
                                    forcedTableRule.UseSpecificHand = false;
                                    forcedTableRule.Name = "S" + forcedTableRule.Hand.Total.ToString() + " vs " + UCStr + " " + C.StratLongText[forcedTableRule.Strat];
                                    forcedTableRule.RuleOn = true;
                                    ForcedTableRulesList.AddForcedRule(forcedTableRule);

                                    ForcedRule.Name = (Forced.NCardsCD + 1).ToString() + "-Card ";
                                    ForcedRule.Name += "S";
                                    ForcedRule.Name += total.ToString() + " v " + upcard.ToString() + " " + C.StratShortText[ncardOrMoreStrat.Strat[upcard]];
                                    ForcedRule.RuleOn = true;
                                    ForcedRule.UseSpecificHand = false;

                                    ForcedRule.Hand.Empty();
                                    ForcedRule.Hand.Total = total;
                                    ForcedRule.Hand.NumCards = Forced.NCardsCD + 1;
                                    ForcedRule.Hand.Soft = true;
                                    ForcedRule.ExactMatch = false;

                                    ForcedRule.OrMore = true;
                                    ForcedRule.OrLess = false;

                                    ForcedRule.PreSplit = true;
                                    ForcedRule.PostSplit = true;

                                    ForcedRule.Upcard = upcard;
                                    ForcedRule.Strat = ncardOrMoreStrat.Strat[upcard];
                                    ForcedRulesList.AddForcedRule(ForcedRule);
                                }
                            }
                        }
                    }

                    for (total = 10; total >= 5; total -= 1)
                    {
                        Forced.StratTD[total, Conversions.ToInteger(false) + 1].NCardDeviation[upcard] = 0;
                        var twoCardStrat = new BJCATDStratClass();
                        var forcedTableRule = new BJCAForcedRulesClass();

                        for (index = Forced.NCardsCD + 1; index <= 21; index++)
                        {
                            twoCardStrat = ComputeNCardStratEVs(ref Opt, total, Conversions.ToInteger(false) + 1, upcard, index, false, false, true);
                            if (twoCardStrat.NetProb[upcard] > 0d)
                            {
                                forcedTableRule.Upcard = upcard;
                                switch (upcard)
                                {
                                    case 0:
                                        {
                                            UCStr = "A";
                                            break;
                                        }
                                    case 9:
                                        {
                                            UCStr = "T";
                                            break;
                                        }

                                    default:
                                        {
                                            UCStr = upcard.ToString();
                                            break;
                                        }
                                }
                                forcedTableRule.Hand.Total = total;
                                forcedTableRule.Hand.Soft = false;
                                forcedTableRule.Strat = twoCardStrat.Strat[upcard];
                                forcedTableRule.UseSpecificHand = false;
                                forcedTableRule.Name = "H" + forcedTableRule.Hand.Total.ToString() + " vs " + UCStr + " " + C.StratLongText[forcedTableRule.Strat];
                                forcedTableRule.RuleOn = true;
                                ForcedTableRulesList.AddForcedRule(forcedTableRule);
                                break;
                            }
                        }

                        if (index < 21)
                        {
                            for (ncards = index + 1; ncards <= 21; ncards++)
                            {
                                var nCardStrat = new BJCATDStratClass();

                                nCardStrat = ComputeNCardStratEVs(ref Opt, total, Conversions.ToInteger(false) + 1, upcard, ncards, false, false, true);

                                if (twoCardStrat.Strat[upcard] != (int)BJCAGlobalsClass.Strat.None & nCardStrat.Strat[upcard] != (int)BJCAGlobalsClass.Strat.None & nCardStrat.Strat[upcard] != twoCardStrat.Strat[upcard])
                                {
                                    var ncardOrMoreStrat = new BJCATDStratClass();

                                    ncardOrMoreStrat = ComputeNCardStratEVs(ref Opt, total, Conversions.ToInteger(false) + 1, upcard, ncards, true, false, true);
                                    if (ncardOrMoreStrat.Strat[upcard] == nCardStrat.Strat[upcard])
                                    {
                                        var ForcedRule = new BJCAForcedRulesClass();

                                        Forced.StratTD[total, Conversions.ToInteger(false) + 1].NCardStrat[upcard] = ncardOrMoreStrat.Strat[upcard];
                                        Forced.StratTD[total, Conversions.ToInteger(false) + 1].NCardDeviation[upcard] = ncards;

                                        ForcedRule.Name = ncards.ToString() + "-Card ";
                                        ForcedRule.Name += "H";
                                        ForcedRule.Name += total.ToString() + " v " + upcard.ToString() + " " + C.StratShortText[ncardOrMoreStrat.Strat[upcard]];
                                        ForcedRule.RuleOn = true;
                                        ForcedRule.UseSpecificHand = false;

                                        ForcedRule.Hand.Empty();
                                        ForcedRule.Hand.Total = total;
                                        ForcedRule.Hand.NumCards = ncards;
                                        ForcedRule.Hand.Soft = false;
                                        ForcedRule.ExactMatch = false;

                                        ForcedRule.OrMore = true;
                                        ForcedRule.OrLess = false;

                                        ForcedRule.PreSplit = true;
                                        ForcedRule.PostSplit = true;

                                        ForcedRule.Upcard = upcard;
                                        ForcedRule.Strat = ncardOrMoreStrat.Strat[upcard];
                                        ForcedRulesList.AddForcedRule(ForcedRule);
                                        break;
                                    }
                                }
                            }
                            // If the strategy never changed then see if it's different than the n-card CD or less strategy
                            if (ncards > 21)
                            {
                                var ncardOrMoreStrat = new BJCATDStratClass();

                                twoCardStrat = ComputeNCardStratEVs(ref Opt, total, Conversions.ToInteger(false) + 1, upcard, Forced.NCardsCD, false, true, true);
                                ncardOrMoreStrat = ComputeNCardStratEVs(ref Opt, total, Conversions.ToInteger(false) + 1, upcard, Forced.NCardsCD + 1, true, false, true);

                                if (twoCardStrat.Strat[upcard] != (int)BJCAGlobalsClass.Strat.None & ncardOrMoreStrat.Strat[upcard] != (int)BJCAGlobalsClass.Strat.None & ncardOrMoreStrat.Strat[upcard] != twoCardStrat.Strat[upcard])
                                {
                                    var ForcedRule = new BJCAForcedRulesClass();

                                    Forced.StratTD[total, Conversions.ToInteger(false) + 1].NCardStrat[upcard] = ncardOrMoreStrat.Strat[upcard];
                                    Forced.StratTD[total, Conversions.ToInteger(false) + 1].NCardDeviation[upcard] = Forced.NCardsCD + 1;

                                    // The below rules must be added to fool the CA into listing the Ncard strat that it would do normally anyways.
                                    forcedTableRule.Upcard = upcard;
                                    switch (upcard)
                                    {
                                        case 0:
                                            {
                                                UCStr = "A";
                                                break;
                                            }
                                        case 9:
                                            {
                                                UCStr = "T";
                                                break;
                                            }

                                        default:
                                            {
                                                UCStr = upcard.ToString();
                                                break;
                                            }
                                    }
                                    forcedTableRule.Hand.Total = total;
                                    forcedTableRule.Hand.Soft = false;
                                    forcedTableRule.Strat = twoCardStrat.Strat[upcard];
                                    forcedTableRule.UseSpecificHand = false;
                                    forcedTableRule.Name = "H" + forcedTableRule.Hand.Total.ToString() + " vs " + UCStr + " " + C.StratLongText[forcedTableRule.Strat];
                                    forcedTableRule.RuleOn = true;
                                    ForcedTableRulesList.AddForcedRule(forcedTableRule);

                                    ForcedRule.Name = (Forced.NCardsCD + 1).ToString() + "-Card ";
                                    ForcedRule.Name += "H";
                                    ForcedRule.Name += total.ToString() + " v " + upcard.ToString() + " " + C.StratShortText[ncardOrMoreStrat.Strat[upcard]];
                                    ForcedRule.RuleOn = true;
                                    ForcedRule.UseSpecificHand = false;

                                    ForcedRule.Hand.Empty();
                                    ForcedRule.Hand.Total = total;
                                    ForcedRule.Hand.NumCards = Forced.NCardsCD + 1;
                                    ForcedRule.Hand.Soft = false;
                                    ForcedRule.ExactMatch = false;

                                    ForcedRule.OrMore = true;
                                    ForcedRule.OrLess = false;

                                    ForcedRule.PreSplit = true;
                                    ForcedRule.PostSplit = true;

                                    ForcedRule.Upcard = upcard;
                                    ForcedRule.Strat = ncardOrMoreStrat.Strat[upcard];
                                    ForcedRulesList.AddForcedRule(ForcedRule);
                                }
                            }
                        }
                    }
                }
            }

        }

        #endregion







        #region  Methods Under Construction

        #endregion

    }
}