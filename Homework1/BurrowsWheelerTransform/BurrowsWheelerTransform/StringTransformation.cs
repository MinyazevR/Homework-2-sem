using System;

namespace BurrowsWheelerTransform
{
    public class StringTransformation
    {
        public string DirectBurrowsWheelerTransformation(string stringToConvert, ref int index)
        {
            string[] arrayOfString = new string[stringToConvert.Length];
            string convertedString = "";
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
                convertedString += arrayOfString[i][stringToConvert.Length - 1];
            }
            index = Array.IndexOf(arrayOfString, stringToConvert);
            return convertedString;
        }
        public string InverseBurrowsWheelerTransformation(string stringToConvert, int index)
        {
            if (Array.Equals(stringToConvert, ""))
            {
                return "";
            }
            int[] arrayForCharacterCounter = new int[1104];
            for (int i = 0; i < 1104; i++)
            {
                arrayForCharacterCounter[i] = 0;
            }
            for (int i = 0; i < stringToConvert.Length; i++)
            {
                arrayForCharacterCounter[stringToConvert[i]]++;
            }
            int variableForRestoringSortedColumn = 0;
            for (int i = 0; i < 1104; i++)
            {
                variableForRestoringSortedColumn += arrayForCharacterCounter[i];
                arrayForCharacterCounter[i] = variableForRestoringSortedColumn - arrayForCharacterCounter[i];
            }
            int[] inverseTransformationVector = new int[stringToConvert.Length];
            for (int i = 0; i < stringToConvert.Length; i++)
            {
                inverseTransformationVector[arrayForCharacterCounter[stringToConvert[i]]] = i;
                arrayForCharacterCounter[stringToConvert[i]]++;
            }
            char[] convertedString = new char[stringToConvert.Length];
            int currentIndex = inverseTransformationVector[index];
            for(int i  = 0; i < stringToConvert.Length; i++)
            {
                convertedString[i] = stringToConvert[currentIndex];
                currentIndex = inverseTransformationVector[currentIndex];
            }
            return string.Join("", convertedString);
        }
        static void Main(string[] args)
        {
            StringTransformation transformation = new StringTransformation();
            int number = 0;
            Console.WriteLine("please enter the line");
            string inputString = Console.ReadLine();
            string newString = transformation.DirectBurrowsWheelerTransformation(inputString, ref number);
            Console.WriteLine("Direct conversion and index line in a table : {0}, {1}", newString, number);
            string answer = transformation.InverseBurrowsWheelerTransformation(newString, number);
            Console.WriteLine("reverse transformation : {0}", answer);
        }
    }
}
