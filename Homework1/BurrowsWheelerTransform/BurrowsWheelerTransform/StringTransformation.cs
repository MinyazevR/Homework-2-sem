using System;

namespace BurrowsWheelerTransform
{
    public class StringTransformation
    {
        public string DirectBurrowsWheelerTransformation(string stringToConvert, ref int number)
        {
            string[] arrayOfString = new string[stringToConvert.Length];
            string convertString = "";
            for (int i = 0; i < stringToConvert.Length; i++)
            {
                arrayOfString[i] = stringToConvert;
                char symbol = stringToConvert[stringToConvert.Length - 1];
                stringToConvert = stringToConvert.Remove(stringToConvert.Length - 1, 1);
                stringToConvert = symbol + stringToConvert;
            }
            Array.Sort(arrayOfString);
            for(int i  = 0; i < stringToConvert.Length; i++)
            {
                convertString += arrayOfString[i][stringToConvert.Length - 1];
            }
            number = Array.IndexOf(arrayOfString, stringToConvert);
            return convertString;
        }
        public string InverseBurrowsWheelerTransformation(string convertString, int index)
        {
            if (Array.Equals(convertString, ""))
            {
                return "";
            }
            int[] count = new int[1104];
            for (int i = 0; i < 1104; i++)
            {
                count[i] = 0;
            }
            for (int i = 0; i < convertString.Length; i++)
            {
                count[convertString[i]]++;
            }
            int sum = 0;
            for (int i = 0; i < 1104; i++)
            {
                sum += count[i];
                count[i] = sum - count[i];
            }
            int[] vector = new int[convertString.Length];
            for (int i = 0; i < convertString.Length; i++)
            {
                vector[count[convertString[i]]] = i;
                count[convertString[i]]++;
            }
            char[] newString = new char[convertString.Length];
            int currentIndex = vector[index];
            for(int i  = 0; i < convertString.Length; i++)
            {
                newString[i] = convertString[currentIndex];
                currentIndex = vector[currentIndex];
            }
            return string.Join("", newString);
        }
        static void Main(string[] args)
        {
            StringTransformation program = new StringTransformation();
            int number = 0;
            Console.WriteLine("please enter the line");
            string inputString = Console.ReadLine();
            string newString = program.DirectBurrowsWheelerTransformation(inputString, ref number);
            Console.WriteLine("Direct conversion and index line in a table : {0}, {1}", newString, number);
            string answer = program.InverseBurrowsWheelerTransformation(newString, number);
            Console.WriteLine("reverse transformation : {0}", answer);
        }
    }
}
