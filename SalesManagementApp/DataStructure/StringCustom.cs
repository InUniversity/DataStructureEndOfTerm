﻿using System;
namespace SalesManagementApp.DataStructure
{
    public class StringCustom
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
        public StringCustomList Split(char sign)
        {
            StringCustomList result = new StringCustomList();
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

        public bool Contain(StringCustom sequence)
        {
            int curSize = this.iSize, subSize = sequence.Size;
            int i = 0, j = 1;
            bool flag;
            do
            {
                while (i < curSize && CharAt(i) != sequence.CharAt(0))
                    i++;
                i = 1;
                flag = true;
                while (i < curSize && j < subSize)
                    if (CharAt(i++) != sequence.CharAt(j++))
                    {
                        flag = false;
                        break;
                    }
                if (flag)
                    return true;
            } while (i < curSize);
            return false;
        }

        public bool IsEqual(StringCustom strCustom)
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