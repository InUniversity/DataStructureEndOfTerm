using System;
namespace SalesManagementApp.DataStructure
{
    public class StringCustom : IComparable
    {

        private char[] data;
        private int iSize;

        public StringCustom(string str)
        {
            this.data = str.ToCharArray();
            iSize = str.Length;
        }

        public StringCustom(char[] data)
        {
            iSize = data.Length;
            this.data = new char[iSize];
            for (int i = 0; i < iSize; i++)
                this.data[i] = data[i];
        }

        public int Size
        {
            get { return iSize; }
            set { iSize = value; }
        }

        // methods
        public StringCustom Trim()
        {
            if (iSize == 0) return this;
            int start = 0, end = iSize - 1;

            while (this.CharAt(start) == ' ')
                start++;
            while (this.CharAt(end) == ' ')
                end--;
            return Substring(start, end);
        }

        public StringCustom Substring(int start, int end)
        {
            if (iSize == 0 && start < 0 && end > iSize) return this;
            StringCustom result = "";
            for (int i = start; i <= end; i++)
                result = result.Concat(this.CharAt(i));
            return result;
        }

        public LinkedLst<StringCustom> Split(char sign)
        {
            LinkedLst<StringCustom> result = new LinkedLst<StringCustom>();
            StringCustom temp;
            int i = 0;
            while (i < this.iSize)
            {
                temp = "";
                while (i < this.iSize && CharAt(i) != sign)
                    temp = temp.Concat(CharAt(i++));
                result.AddLast(temp);
                i++;
            }
            return result;
        }

        public int ToInt()
        {
            int number = 0;
            for (int i = 0; i < iSize; i++)
                number = number * 10 + (CharAt(i) - '0');
            return number;
        }

        public int CompareTo(object? obj)
        {
            StringCustom str = (StringCustom)obj;
            if (iSize > str.Size) return 1;
            if (iSize < str.Size) return -1;

            for (int i = 0; i < iSize; i++)
            {
                if (this.CharAt(i) > str.CharAt(i))
                    return 1;
                if (this.CharAt(i) < str.CharAt(i))
                    return -1;
            }
            return 0;
        }

        public bool IsEquals(StringCustom strCustom)
        {
            if (iSize != strCustom.Size)
                return false;

            for (int i = 0; i < this.iSize; i++)
                if (this.CharAt(i) != strCustom.CharAt(i))
                    return false;
            return true;
        }

        public StringCustom Concat(StringCustom str)
        {
            int curSize = this.iSize;
            int newSize = curSize + str.Size;
            char[] result = new char[newSize];
            for (int i = 0; i < curSize; i++)
                result[i] = this.data[i];
            for (int i = curSize; i < newSize; i++)
                result[i] = str.CharAt(i - curSize);
            return new StringCustom(result);
        }

        public static char[] CharArrayOf(string data)
        {
            int size = data.Length;
            char[] result = new char[size];
            for (int i = 0; i < size; i++)
                result[i] = data[i];
            return result;
        }

        public static StringCustom StringCustomOf(char[] data)
        {
            return new StringCustom(data);
        }

        public char CharAt(int index)
        {
            return data[index];
        }

        public static implicit operator StringCustom(string str)
        {
            int size = str.Length;
            char[] result = new char[size];
            for (int i = 0; i < size; i++)
                result[i] = str[i];
            return new StringCustom(result);
        }

        public static implicit operator StringCustom(char chr)
        {
            return new StringCustom(chr.ToString());
        }

        public static implicit operator string(StringCustom strCustom)
        {
            string result = "";
            for (int i = 0; i < strCustom.Size; i++)
                result += strCustom.CharAt(i);
            return result;
        }

        public override string ToString()
        {
            return this;
        }
    }
}