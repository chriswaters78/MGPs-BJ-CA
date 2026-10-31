using System;
using System.Collections;

namespace BJ_CA
{

    [Serializable()]
    public class BJCADealerProbsClass
    {
        public double[,] p = new double[11, 5];           // Upcard, Dealer Total
        public double[] bjadj = new double[11];          // Prob of dealer BJ given shoe

        public BJCADealerProbsClass()
        {
        }
    }

    [Serializable()]
    public class BJCADealerProbsDictionary : DictionaryBase, System.Runtime.Serialization.ISerializable, System.Runtime.Serialization.IDeserializationCallback
    {

        // DictionaryBase is not serializable on .NET Core, so the inner table is saved by hand under
        // the member name .NET Framework used, keeping existing DealerProbs files readable.
        private const string HashtableMemberName = "DictionaryBase+hashtable";
        private Hashtable loadedTable;

        public BJCADealerProbsDictionary()
        {
            var dprobs = new BJCADealerProbsClass();

            Dictionary.Add("None-S17-0-0-0-0-0-0-0-0-0-0", dprobs);
            Dictionary.Add("None-H17-0-0-0-0-0-0-0-0-0-0", dprobs);

        }

        protected BJCADealerProbsDictionary(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            loadedTable = (Hashtable)info.GetValue(HashtableMemberName, typeof(Hashtable));
        }

        public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            info.AddValue(HashtableMemberName, new Hashtable(InnerHashtable));
        }

        public void OnDeserialization(object sender)
        {
            if (loadedTable is null)
                return;
            loadedTable.OnDeserialization(sender);
            foreach (DictionaryEntry entry in loadedTable)
                InnerHashtable[entry.Key] = entry.Value;
            loadedTable = null;
        }

        public BJCADealerProbsClass this[string key]
        {
            get
            {
                return (BJCADealerProbsClass)Dictionary[key];
            }
            set
            {
                Dictionary[key] = value;
            }
        }

        public void Add(string key, BJCADealerProbsClass dprobs)
        {
            Dictionary.Add(key, dprobs);
        } // Add

        public bool Contains(string key)
        {
            return Dictionary.Contains(key);
        } // Contains

        public void Remove(string key)
        {
            Dictionary.Remove(key);
        } // Remove

        public void Replace(string key, BJCADealerProbsClass dprobs)
        {
            Dictionary.Remove(key);
            Dictionary.Add(key, dprobs);
        } // Replace

        public string GetHashKey(int standonsoft, int ndecks, BJCAHandClass hand, string countName = "None")
        {
            string keystr;

            if (hand.Cards[1] > ndecks * 4 | hand.Cards[2] > ndecks * 4 | hand.Cards[3] > ndecks * 4 | hand.Cards[4] > ndecks * 4 | hand.Cards[5] > ndecks * 4 | hand.Cards[6] > ndecks * 4 | hand.Cards[7] > ndecks * 4 | hand.Cards[8] > ndecks * 4 | hand.Cards[9] > ndecks * 4 | hand.Cards[10] > ndecks * 16)








            {

                keystr = "None-S17-0-0-0-0-0-0-0-0-0-0";
            }

            keystr = countName + "-" + "S" + standonsoft.ToString();
            keystr += (ndecks * 4 - hand.Cards[1]).ToString() + "-";
            keystr += (ndecks * 4 - hand.Cards[2]).ToString() + "-";
            keystr += (ndecks * 4 - hand.Cards[3]).ToString() + "-";
            keystr += (ndecks * 4 - hand.Cards[4]).ToString() + "-";
            keystr += (ndecks * 4 - hand.Cards[5]).ToString() + "-";
            keystr += (ndecks * 4 - hand.Cards[6]).ToString() + "-";
            keystr += (ndecks * 4 - hand.Cards[7]).ToString() + "-";
            keystr += (ndecks * 4 - hand.Cards[8]).ToString() + "-";
            keystr += (ndecks * 4 - hand.Cards[9]).ToString() + "-";
            keystr += (ndecks * 16 - hand.Cards[10]).ToString();


            return keystr;

        }

        public string GetHashKey(int standonsoft, BJCAShoeClass shoe, BJCAHandClass hand, string countName = "None")
        {
            string keystr;

            if (hand.Cards[1] > shoe.Cards[1] | hand.Cards[2] > shoe.Cards[2] | hand.Cards[3] > shoe.Cards[3] | hand.Cards[4] > shoe.Cards[4] | hand.Cards[5] > shoe.Cards[5] | hand.Cards[6] > shoe.Cards[6] | hand.Cards[7] > shoe.Cards[7] | hand.Cards[8] > shoe.Cards[8] | hand.Cards[9] > shoe.Cards[9] | hand.Cards[10] > shoe.Cards[10])








            {

                keystr = "None-S17-0-0-0-0-0-0-0-0-0-0";
            }

            keystr = countName + "-" + "S" + standonsoft.ToString();
            keystr += (shoe.Cards[1] - hand.Cards[1]).ToString() + "-";
            keystr += (shoe.Cards[2] - hand.Cards[2]).ToString() + "-";
            keystr += (shoe.Cards[3] - hand.Cards[3]).ToString() + "-";
            keystr += (shoe.Cards[4] - hand.Cards[4]).ToString() + "-";
            keystr += (shoe.Cards[5] - hand.Cards[5]).ToString() + "-";
            keystr += (shoe.Cards[6] - hand.Cards[6]).ToString() + "-";
            keystr += (shoe.Cards[7] - hand.Cards[7]).ToString() + "-";
            keystr += (shoe.Cards[8] - hand.Cards[8]).ToString() + "-";
            keystr += (shoe.Cards[9] - hand.Cards[9]).ToString() + "-";
            keystr += (shoe.Cards[10] - hand.Cards[10]).ToString();

            return keystr;

        }

        public string GetHashKey(int standonsoft, BJCAShoeClass shoe, string countName = "None")
        {
            string keystr;

            keystr = countName + "-" + "S" + standonsoft.ToString();
            keystr += shoe.Cards[1].ToString() + "-";
            keystr += shoe.Cards[2].ToString() + "-";
            keystr += shoe.Cards[3].ToString() + "-";
            keystr += shoe.Cards[4].ToString() + "-";
            keystr += shoe.Cards[5].ToString() + "-";
            keystr += shoe.Cards[6].ToString() + "-";
            keystr += shoe.Cards[7].ToString() + "-";
            keystr += shoe.Cards[8].ToString() + "-";
            keystr += shoe.Cards[9].ToString() + "-";
            keystr += shoe.Cards[10].ToString();

            return keystr;

        }

    }
}