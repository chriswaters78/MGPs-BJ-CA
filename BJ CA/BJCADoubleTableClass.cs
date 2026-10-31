using System;

namespace BJ_CA
{
    [Serializable()]
    public class BJCADoubleTableClass
    {
        public bool[,] T = new bool[18, 4];

        public BJCADoubleTableClass()
        {
            int row;
            int column;

            for (row = 0; row <= 17; row++)
            {
                for (column = 0; column <= 3; column++)
                    T[row, column] = false;
            }
        }

        public void Empty()
        {
            int row;
            int column;

            for (row = 0; row <= 17; row++)
            {
                for (column = 0; column <= 3; column++)
                    T[row, column] = false;
            }
        }

    }
}