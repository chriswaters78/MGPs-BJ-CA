using System;

namespace BJ_CA
{
    [Serializable()]
    public class BJCANPxClass
    {
        public string Name;
        public int NP;             // Number of Paircards removed after the initial pair
        public int NN;             // Number of Non-paircards removed after the initial pair
        public int Nx;             // Number of cards removed after reaching the maximum number of hands in a split
        public int UCH;            // Unconditional split hand that the current split hand is based on
        public int CH;             // Conditional split hand that the current split hand is based on
        public bool[] Used = new bool[4];        // The hand is actually used during play and not just for calculations
    }

    [Serializable()]
    public class BJCASplitRoundsClass
    {
        public string[,] Name = new string[4, 9];
        public int[,,,] Hands = new int[4, 9, 11, 2];   // SPL, Rounds, Hand, x/N   The number of times each hand is used in a round
        public int NP;             // Number of Paircards removed after the initial pair
        public int NN;             // Number of Non-paircards removed after the initial pair
        public int Nx;             // Number of cards removed after reaching the maximum number of hands in a split
    }

    [Serializable()]
    public class BJCASplitRoundProbsClass
    {
        public double[,] RoundProbs = new double[4, 9];        // SPL, Rounds       The prob of each round occuring
        public double[,,] NetHandProbs = new double[4, 11, 1];  // SPL, Hands, x/N   The net prob of each hand type during the entire calc 
    }

    [Serializable()]
    public class BJCASplitProbsClass
    {
        // Probabilties for N hands occuring are simply 1-p(x)
        public double[,] PxCards = new double[11, 11];       // Shoe state, card     Probability of receiving an x

        // These are used in OBBO to store the Conditional EV's given that the dealer doesn't have BJ
        // These are the same as the usual EV's when not using OBBO or ENHC
        public double[,] PBJ = new double[11, 11];           // Shoe state, card     Probability of getting blackjack - needed for paircard
        public double[,] PCEVxCards = new double[11, 11];    // Shoe state, card     Conditional probability of receiving an x
        public double[,] PBJxCards = new double[11, 11];     // Shoe state, card     Probability of receiving an x given dealer BJ

        // This is only used to compute split probs for the prob of BJ given a card drawn
        public double[,] PPairBJCards = new double[11, 11];  // Shoe state, card     Conditional probability of receiving an x
    }

    [Serializable()]
    public class BJCASplitStateStrategyClass
    {
        // EVs for each second card and net evs
        public double[] EVx = new double[11];               // Shoe state           Overall EV for an x
        public double[] EVN = new double[11];               // Shoe state           Overall EV for an N
        public double[,] EVCards = new double[11, 11];       // Shoe state, card     EV of the individual 2-card hand
        public double[] SPL = new double[4];                // Split EVs
        public double[] SPL2 = new double[4];               // Split EV's using removal hands
        public double[] SPL3 = new double[4];               // Split EV's using removal hands

        // These are used in OBBO to store the Conditional EV's given that the dealer doesn't have BJ
        // These are the same as the usual EV's when not using OBBO or ENHC
        public double[] CEVx = new double[11];             // Shoe state           Overall CEV for an x
        public double[] CEVN = new double[11];             // Shoe state           Overall CEV for an N
        public double[,] CEVCards = new double[11, 11];     // Shoe state, card     Conditional EV of the individual 2-card hand

        // Thesed are only used in OBBO for determining the Bust Probabilities give a dealer BJ
        public double[] PResx = new double[11];               // Shoe state          Overall Probability of Busting for an x
        public double[] PResN = new double[11];               // Shoe state          Overall Probability of Busting for an N
        public double[] PResEVx = new double[11];             // Shoe state          Overall Probability of Busting for an x
        public double[] PResEVN = new double[11];             // Shoe state          Overall Probability of Busting for an N
        public double[,] PResCards = new double[11, 11];       // Shoe State, card    Probability of Busting given dealer BJ
        public double[,] PResEVCards = new double[11, 11];     // Shoe state, card     Net pEV of resolved hands

        // Thesed are only used in OBBO and hold the values when the player loses 0 to dealer BJ
        public double[] BBOx = new double[11];               // Shoe state           Overall EV for a BBO x
        public double[] BBON = new double[11];               // Shoe state           Overall EV for a BBO N
        public double[,] BBOCards = new double[11, 11];       // Shoe State, card     EV of the individual BBO 2-card hand

        // Thesed are only used in OBBO and hold the values when the player loses 1 to dealer BJ
        public double[] OBBOx = new double[11];               // Shoe state          Overall EV for a OBBO x
        public double[] OBBON = new double[11];               // Shoe state          Overall EV for a OBBO N
        public double[,] OBBOCards = new double[11, 11];       // Shoe State, card    EV of the individual OBBO 2-card hand

        public void Empty()
        {
            int i;
            int hands;
            int card;

            for (hands = 0; hands <= 10; hands++)
            {
                EVx[hands] = 0d;
                EVN[hands] = 0d;
                CEVx[hands] = 0d;
                CEVN[hands] = 0d;
                PResx[hands] = 0d;
                PResN[hands] = 0d;
                PResEVx[hands] = 0d;
                PResEVN[hands] = 0d;
                BBOx[hands] = 0d;
                BBON[hands] = 0d;
                OBBOx[hands] = 0d;
                OBBON[hands] = 0d;
                for (card = 0; card <= 10; card++)
                {
                    EVCards[hands, card] = 0d;
                    CEVCards[hands, card] = 0d;
                    PResCards[hands, card] = 0d;
                    PResEVCards[hands, card] = 0d;
                    BBOCards[hands, card] = 0d;
                    OBBOCards[hands, card] = 0d;
                }
            }

            for (i = 0; i <= 3; i++)
            {
                SPL[i] = 0d;
                SPL2[i] = 0d;
                SPL3[i] = 0d;
            }
        }
    }
}