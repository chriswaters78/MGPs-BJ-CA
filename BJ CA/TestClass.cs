using static BJ_CA.BJCAShared;

namespace BJ_CA
{

    public class TestClass
    {
        public BJCAHandClass emptytesthand = new BJCAHandClass();
        public BJCAHandClass[] testhand = new BJCAHandClass[1000001];

        public TestClass()
        {
            long i;

            for (i = 1L; i <= 100000L; i++)
            {
                testhand[(int)i] = new BJCAHandClass();
                testhand[(int)i].Cards[1] = 5;
            }
        }

        public void BruteForceEmpty()
        {
            long i;

            for (i = 1L; i <= 100000L; i++)
                testhand[(int)i].Empty();
        }

        public void CloneEmpty()
        {
            long i;

            for (i = 1L; i <= 100000L; i++)
                testhand[(int)i] = (BJCAHandClass)CloneObject(emptytesthand);
        }

    }
}