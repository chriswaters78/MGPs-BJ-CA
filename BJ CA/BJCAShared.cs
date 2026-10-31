using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace BJ_CA
{

    public class BJCAShared
    {

        public class IndexedTextBox : TextBox
        {
            public double Index;
            public double Index2;
            public BJCAHandClass Hand = new BJCAHandClass();
        }

        public class IndexedCheckBox : CheckBox
        {
            public double Index;
            public double Index2;
        }

        public class IndexedComboBox : ComboBox
        {
            public double Index;
            public double Index2;
        }

        public class IndexedLabel : Label
        {
            public double Index;
            public double Index2;
        }

        public class IndexedButton : Button
        {
            public double Index;
            public double Index2;
        }

        public static Color GetBackColor(double num, bool usegray = false)
        {
            Color GetBackColorRet = default;
            if (usegray)
            {
                GetBackColorRet = Color.FromArgb(192, 192, 192);
            }
            else if (num < 0d)
            {
                GetBackColorRet = Color.FromArgb(255, 192, 192);
            }
            else if (num > 0d)
            {
                GetBackColorRet = Color.FromArgb(192, 255, 192);
            }
            else
            {
                GetBackColorRet = default;
            }

            return GetBackColorRet;
        }

        public static void FillStratTextBox(ref TextBox box, int strat, bool fulltext, BJCAColorTableClass colortable)
        {
            var constants = new BJCAGlobalsClass();

            if (box is not null)
            {
                if (fulltext)
                {
                    box.Text = constants.StratFullText[strat];
                }
                else
                {
                    box.Text = constants.StratShortText[strat];
                }
                box.BackColor = colortable.C[strat];
            }
        }

        public static void FillNumberTextBox(ref TextBox box, double val, int nfixed, bool percent, bool useval = true, bool usegray = false)
        {
            if (box is not null)
            {
                if (val != 0d & useval)
                {
                    if (percent)
                    {
                        box.Text = Math.Round(val * 100d, nfixed).ToString() + "%";
                    }
                    else
                    {
                        box.Text = Math.Round(val, nfixed).ToString();
                    }
                    box.BackColor = GetBackColor(val, usegray);
                }
                else
                {
                    box.Text = "";
                    box.BackColor = default;
                }
            }
        }

        public static string GetHandString(BJCAHandClass hand)
        {
            string GetHandStringRet = default;
            int card;
            int i;
            string handStr;

            handStr = "";
            for (card = 1; card <= 10; card++)
            {
                var loopTo = hand.Cards[card];
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

            GetHandStringRet = handStr;
            return GetHandStringRet;
        }

        public static string GetCardString(int card)
        {
            string GetCardStringRet = default;
            int i;
            string cardStr;

            if (card == 1)
            {
                cardStr = "A";
            }
            else if (card == 10)
            {
                cardStr = "T";
            }
            else
            {
                cardStr = card.ToString();
            }

            GetCardStringRet = cardStr;
            return GetCardStringRet;
        }

        public static BJCAHandClass GetStringHand(string handstr)
        {
            BJCAHandClass GetStringHandRet = default;
            int i;
            string card;
            var hand = new BJCAHandClass();

            var loopTo = handstr.Length - 1;
            for (i = 0; i <= loopTo; i++)
            {
                card = Conversions.ToString(handstr[i]);
                switch (card ?? "")
                {
                    case "A":
                    case "a":
                    case "1":
                        {
                            hand.Deal(1);
                            break;
                        }
                    case "T":
                    case "t":
                    case "0":
                        {
                            hand.Deal(10);
                            break;
                        }
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                        {
                            hand.Deal(Conversions.ToInteger(card));
                            break;
                        }

                    default:
                        {
                            break;
                        }
                }
            }

            GetStringHandRet = hand;
            return GetStringHandRet;
        }

        public static void PopulateUpcardLabels(object sender, int coord1, int coord2, int spacing)
        {
            int i;

            for (i = 0; i <= 9; i++)
            {
                var box = new Label();

                box.TextAlign = (ContentAlignment)HorizontalAlignment.Center;
                box.Size = new Size(24, 16);
                box.Location = new Point(coord1 + i * spacing, coord2);
                if (i == 8)
                {
                    box.Text = "T";
                }
                else if (i == 9)
                {
                    box.Text = "A";
                }
                else
                {
                    box.Text = (i + 2).ToString();
                } ((dynamic)sender).Controls.Add(box);
            }
        }

        public static string GetUpcardLabelString(int nSpaces, bool aceFirst)
        {
            int i;
            var textString = default(string);

            for (i = 1; i <= 10; i++)
            {
                if (aceFirst)
                {
                    if (i == 10)
                    {
                        textString += SetStringSize("T", nSpaces, nSpaces, StringAlignment.Center);
                    }
                    else if (i == 1)
                    {
                        textString += SetStringSize("A", nSpaces, nSpaces, StringAlignment.Center);
                    }
                    else
                    {
                        textString += SetStringSize(i.ToString(), nSpaces, nSpaces, StringAlignment.Center);
                    }
                }
                else if (i == 9)
                {
                    textString += SetStringSize("T", nSpaces, nSpaces, StringAlignment.Center);
                }
                else if (i == 10)
                {
                    textString += SetStringSize("A", nSpaces, nSpaces, StringAlignment.Center);
                }
                else
                {
                    textString += SetStringSize((i + 1).ToString(), nSpaces, nSpaces, StringAlignment.Center);
                }
            }

            return textString;
        }

        public static void CopyIndexedTextBoxContents(ref IndexedTextBox originalBox, IndexedTextBox destinationBox)
        {
            destinationBox.Index = originalBox.Index;
            destinationBox.Index2 = originalBox.Index2;
            destinationBox.Text = originalBox.Text;
            destinationBox.BackColor = originalBox.BackColor;
            destinationBox.Hand.Copy(originalBox.Hand);
        }

        public static bool CheckValidInteger(string entry, int minnum, int maxnum, bool showMessage)
        {
            bool CheckValidIntegerRet = default;
            bool valid;

            valid = true;
            if (Information.IsNumeric(entry))
            {
                if (!(Conversions.ToDouble(entry) >= minnum & Conversions.ToDouble(entry) <= maxnum))
                {
                    valid = false;
                }
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(entry, Conversion.Int(entry), false)))
                {
                    valid = false;
                }
            }
            else
            {
                valid = false;
            }
            if (!valid & showMessage)
            {
                Interaction.MsgBox("Please enter an integer between " + minnum.ToString() + " and " + maxnum.ToString() + ".", MsgBoxStyle.OkOnly);
            }
            CheckValidIntegerRet = valid;
            return CheckValidIntegerRet;
        }

        public static bool CheckValidDecimal(string entry, double minnum, double maxnum, bool showMessage)
        {
            bool CheckValidDecimalRet = default;
            bool valid;

            valid = true;
            if (Information.IsNumeric(entry))
            {
                if (!(Conversions.ToDouble(entry) >= minnum & Conversions.ToDouble(entry) <= maxnum))
                {
                    valid = false;
                }
            }
            else
            {
                valid = false;
            }
            if (!valid & showMessage)
            {
                Interaction.MsgBox("Please enter an value between " + minnum.ToString() + " and " + maxnum.ToString() + ".", MsgBoxStyle.OkOnly);
            }
            CheckValidDecimalRet = valid;
            return CheckValidDecimalRet;
        }

        public static bool ValidCardString(string cardString)
        {
            bool handValid;
            int i;
            string card;

            handValid = true;
            var loopTo = cardString.Length - 1;
            for (i = 0; i <= loopTo; i++)
            {
                card = Conversions.ToString(cardString[i]);
                switch (card ?? "")
                {
                    case "A":
                    case "a":
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case "T":
                    case "t":
                    case "0":
                        {
                            break;
                        }

                    default:
                        {
                            handValid = false;
                            break;
                        }
                }
            }

            return handValid;

        }

        // Maps types in files saved by any earlier build of BJ CA onto this build, and refuses any type
        // that is not one of BJ CA's own classes or a primitive/array/collection those classes use.
        public class BJCASerializationBinder : System.Runtime.Serialization.SerializationBinder
        {

            private static readonly Type[] AllowedTypes = new[] { typeof(string), typeof(decimal), typeof(DateTime), typeof(object), typeof(Hashtable), typeof(IComparer), typeof(IHashCodeProvider), typeof(IEqualityComparer), typeof(Color), typeof(KnownColor) };


            public override Type BindToType(string assemblyName, string typeName)
            {
                var thisAssembly = typeof(BJCAShared).Assembly;
                Type boundType;
                Type elementType;

                if ((new System.Reflection.AssemblyName(assemblyName).Name ?? "") == (thisAssembly.GetName().Name ?? ""))
                {
                    boundType = thisAssembly.GetType(typeName);
                }
                else
                {
                    boundType = Type.GetType(typeName + ", " + new System.Reflection.AssemblyName(assemblyName).Name);
                    if (boundType is null)
                        boundType = Type.GetType(typeName);
                }
                if (boundType is null)
                    throw new System.Runtime.Serialization.SerializationException("Unknown type in file: " + typeName);

                elementType = boundType;
                while (elementType.IsArray)
                    elementType = elementType.GetElementType();
                if (!(ReferenceEquals(elementType.Assembly, thisAssembly) || elementType.IsPrimitive || Array.IndexOf(AllowedTypes, elementType) >= 0))
                {
                    throw new System.Runtime.Serialization.SerializationException("Type not allowed in file: " + typeName);
                }

                return boundType;
            }
        }

        private static BinaryFormatter NewFormatter()
        {
            var formatter = new BinaryFormatter();
            formatter.Binder = new BJCASerializationBinder();
            return formatter;
        }

        public static object CloneObject(object originalObject)
        {
            object CloneObjectRet = default;
            var BinFormatter = NewFormatter();
            var memStream = new MemoryStream();
            BinFormatter.Serialize(memStream, originalObject);
            memStream.Position = 0L;
            CloneObjectRet = BinFormatter.Deserialize(memStream);
            memStream.Close();
            return CloneObjectRet;
        }

        public static void SaveObjectFile(string fileName, object saveObject)
        {
            var fileStream = new FileStream(fileName, FileMode.Create);
            var fileFormatter = NewFormatter();
            try
            {
                fileFormatter.Serialize(fileStream, saveObject);
            }
            finally
            {
                fileStream.Close();
            }
        }

        public static object LoadObjectFile(string fileName)
        {
            object LoadObjectFileRet = default;
            var fileStream = new FileStream(fileName, FileMode.Open);
            var fileFormatter = NewFormatter();
            try
            {
                LoadObjectFileRet = fileFormatter.Deserialize(fileStream);
            }
            finally
            {
                fileStream.Close();
            }

            return LoadObjectFileRet;
        }

        public static string GetPath(string Full)
        {
            if (!string.IsNullOrEmpty(Full))
            {
                for (int i = Full.Length - 1; i >= 0; i -= 1)
                {
                    if (Full.Substring(i, 1) == @"\" || Full.Substring(i, 1) == "/") // Find the rightmost \ or /, which should be cut off the file part
                    {
                        return Full.Substring(0, i) + @"\";
                    }
                }
            }
            else
            {
                return "";
            }

            return default;
        }

        public static string GetFileName(string Full)
        {
            if (string.IsNullOrEmpty(GetPath(Full)))
            {
                return Full;
            }
            else
            {
                return Full.Substring(GetPath(Full).Length);
            } // Cut off everything up to the path
        }

        public static void SortListBox(ref ListBox listBox, string ignoreFirstChar = "")
        {
            int i;
            int j;
            string maxString;
            string nextString;
            string tempString;

            // Now sort the codes by value which should keep values sorted throughout
            if (!string.IsNullOrEmpty(ignoreFirstChar))
                ignoreFirstChar = ignoreFirstChar.Substring(0, 1);
            i = 0;
            while (i < listBox.Items.Count)
            {
                if (string.IsNullOrEmpty(ignoreFirstChar))
                {
                    maxString = Conversions.ToString(listBox.Items[i]);
                }
                else
                {
                    tempString = Conversions.ToString(listBox.Items[i]);
                    if ((tempString.Substring(0, 1) ?? "") == (ignoreFirstChar ?? ""))
                    {
                        maxString = tempString.Substring(1);
                    }
                    else
                    {
                        maxString = Conversions.ToString(listBox.Items[i]);
                    }
                }
                var loopTo = listBox.Items.Count - 1;
                for (j = i + 1; j <= loopTo; j++)
                {
                    if (string.IsNullOrEmpty(ignoreFirstChar))
                    {
                        nextString = Conversions.ToString(listBox.Items[j]);
                    }
                    else
                    {
                        tempString = Conversions.ToString(listBox.Items[j]);
                        if ((tempString.Substring(0, 1) ?? "") == (ignoreFirstChar ?? ""))
                        {
                            nextString = tempString.Substring(1);
                        }
                        else
                        {
                            nextString = Conversions.ToString(listBox.Items[j]);
                        }
                    }
                    if (nextString.CompareTo(maxString) < 0)
                    {
                        maxString = nextString;
                        tempString = Conversions.ToString(listBox.Items[j]);
                        listBox.Items[j] = listBox.Items[i];
                        listBox.Items[i] = tempString;
                    }
                }
                i += 1;
            }
        }

        public static string SetStringSize(string oldString, int minLength = 0, int maxLength = 0, StringAlignment alignType = StringAlignment.Far)
        {
            int i;
            int halfLength;
            string newString;

            if (string.IsNullOrEmpty(oldString))
            {
                newString = "";
                var loopTo = minLength;
                for (i = 1; i <= loopTo; i++)
                    newString += " ";
            }
            else if (oldString.Length > maxLength & maxLength != 0)
            {
                newString = oldString.Substring(0, maxLength);
            }
            else if (oldString.Length < minLength)
            {
                newString = oldString;
                if (alignType == StringAlignment.Center)
                {
                    halfLength = (int)Math.Round(Conversion.Int((minLength - oldString.Length) / 2d));
                    var loopTo1 = halfLength;
                    for (i = 1; i <= loopTo1; i++)
                        newString = " " + newString;
                    var loopTo2 = minLength - oldString.Length - halfLength;
                    for (i = 1; i <= loopTo2; i++)
                        newString += " ";
                }
                else
                {
                    var loopTo3 = minLength - oldString.Length;
                    for (i = 1; i <= loopTo3; i++)
                    {
                        if (alignType == StringAlignment.Far)
                        {
                            newString = " " + newString;
                        }
                        else
                        {
                            // alignType=StringAlignment.Near 
                            newString += " ";
                        }
                    }
                }
            }
            else
            {
                newString = oldString;
            }

            return newString;
        }

    }
}