using System;
using static BJ_CA.BJCAShared;

namespace BJ_CA
{

    [Serializable()]
    public class BJCAExceptionClass
    {
        public int Index;
        public int Upcard;
        public int Paircard;
        public int ExceptionType;
        public int SplitHand;
        public string ShoeState;
        public string ExceptionName;

        public BJCAExceptionClass()
        {
            Index = 0;
            Upcard = 0;
            Paircard = 0;
            ExceptionType = (int)BJCAGlobalsClass.ExType.None;
            SplitHand = 0;
            ShoeState = "Pre-Split";
            ExceptionName = "";
        }

        public void Empty()
        {
            Index = 0;
            Upcard = 0;
            Paircard = 0;
            ExceptionType = (int)BJCAGlobalsClass.ExType.None;
            SplitHand = 0;
            ShoeState = "Pre-Split";
            ExceptionName = "";
        }

    }

    [Serializable()]
    public class BJCAExceptionListClass
    {
        public int NumExceptions;
        public BJCAExceptionClass[] L;

        public void AddException(BJCAExceptionClass newException)
        {
            NumExceptions += 1;
            Array.Resize(ref L, NumExceptions);
            L[NumExceptions - 1] = new BJCAExceptionClass();
            L[NumExceptions - 1] = (BJCAExceptionClass)CloneObject(newException);
        }

    }

    [Serializable()]
    public class BJCANCardExceptionClass
    {
        public int NCards;
        public int Total;
        public bool Soft;
        public int Upcard;
        public int Strat;
        public double SEV;
        public double HEV;
        public double DEV;
        public double SurrEV;
        public int ExceptionType;
        public string ExceptionName;

        public BJCANCardExceptionClass()
        {
            NCards = 0;
            Total = 0;
            Soft = false;
            Upcard = 0;
            Strat = 0;
            SEV = 0d;
            HEV = 0d;
            DEV = 0d;
            SurrEV = 0d;
            ExceptionType = (int)BJCAGlobalsClass.ExType.None;
            ExceptionName = "";
        }

        public void Empty()
        {
            NCards = 0;
            Total = 0;
            Soft = false;
            Upcard = 0;
            Strat = 0;
            SEV = 0d;
            HEV = 0d;
            DEV = 0d;
            SurrEV = 0d;
            ExceptionType = (int)BJCAGlobalsClass.ExType.None;
            ExceptionName = "";
        }

    }

    [Serializable()]
    public class BJCANCardExceptionListClass
    {
        public int NumExceptions;
        public BJCANCardExceptionClass[] L;

        public void AddException(BJCANCardExceptionClass newException)
        {
            NumExceptions += 1;
            Array.Resize(ref L, NumExceptions);
            L[NumExceptions - 1] = new BJCANCardExceptionClass();
            L[NumExceptions - 1] = (BJCANCardExceptionClass)CloneObject(newException);
        }

    }
}