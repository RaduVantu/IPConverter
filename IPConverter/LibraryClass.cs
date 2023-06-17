using System;
using System.Linq;

namespace IPConverter
{
    class LibraryClass
    {
		//converts octet value to binary
		public static string TransformToBinary(string value)
		{
			//array containing the reference values
			int[] reference = { 128, 64, 32, 16, 8, 4, 2, 1 };
			//parse the string containing the octet to int
			int number = int.Parse(value);
			//string that will contain the the binary value
			string binaries = "";

			//the method will try to subtract the reference value from the octet value
			for (int i = 0; i < reference.Length; i++)
			{
				int n = number - reference[i];
				//if the subtraction result is a negative number, add a 0 to the binaries string
				//and try subtracting the next reference value
				if (n < 0)
				{
					binaries = binaries + "0";
				}
				//if the result is a positive number, add 1 to the binaries string and replace
				//the octet value with the result
				else
				{
					binaries = binaries + "1";

					number = n;
				}
			}
			//return the string containing the binary value
			return binaries;
		}
		//checks if textbox input values are in the correct format and range
		public static bool OctetIsNumberAndInRange(string value)
		{
			//if there is input and if all input characters are numbers
			if (value.Length != 0 && value.All(Char.IsDigit))
			{
				//convert the string containing the input to int
				int octet = int.Parse(value);
				//check if input is within accepted IP value range
				if (0 <= octet && octet <= 255)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		//checks if forst octet is 0 (IP addresses can not start with zero)
		public static bool FirstOctetOrBinaryNotZero(string value)
		{
			int check = int.Parse(value);
			if (check != 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		//validates octet input if it passed all previous checks 
		public static bool OctetIPValidation(string firstOctet, string secondOctet,
			string thirdOctet, string fourthOctet)
		{
			//returns true if input is in correct format and range, and does not start with zero
			if (OctetIsNumberAndInRange(firstOctet) == true &&
				FirstOctetOrBinaryNotZero(firstOctet) == true &&
				OctetIsNumberAndInRange(secondOctet) == true &&
				OctetIsNumberAndInRange(thirdOctet) == true &&
				OctetIsNumberAndInRange(fourthOctet) == true)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		//converts binary value to octet
		public static string TransformToOctet(string value)
		{
			int[] reference = { 128, 64, 32, 16, 8, 4, 2, 1 };
			//integer that will contain the octet value
			int octet = 0;

			//matches the value found in the 'value' string at index 'i' with the value
			//found at index 'i' in the 'reference' array
			for (int i = 0; i < value.Length; i++)
			{
				//if the value at index 'i' in the 'value' string is 1
				if (value[i] == '1')
				{
					//add the value at index 'i' in the 'reference' array to 'octet'
					octet = octet + reference[i];
				}
			}
			//returns a string containing the value of the integer 'octet'
			return octet.ToString();
		}

		//checks if binary input is eight characters long and if the are numbers
		public static bool BinaryIsNumberOfCorrectLength(string value)
		{
			if (value.Length == 8 && value.All(Char.IsDigit))
			{
				return true;
			}
			else
			{
				return false;
			}

		}

		//checks if binary input is a binary number (made up of 0's and 1's)
		public static bool BinaryIsInRange(string value)
		{
			bool isBinary = true;
			for (int i = 0; i < value.Length; i++)
			{
				if (value[i] != '0' && value[i] != '1')
				{
					isBinary = false;
				}
			}
			if (isBinary == true)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		//validates binary input if it passed all previous checks
		public static bool BinaryIPValidation(string firstOctet, string secondOctet,
			string thirdOctet, string fourthOctet)
		{
			if (BinaryIsNumberOfCorrectLength(firstOctet) == true &&
				BinaryIsInRange(firstOctet) == true &&
				FirstOctetOrBinaryNotZero(firstOctet) == true &&
				BinaryIsNumberOfCorrectLength(secondOctet) == true &&
				BinaryIsInRange(secondOctet) == true &&
				BinaryIsNumberOfCorrectLength(thirdOctet) == true &&
				BinaryIsInRange(thirdOctet) == true &&
				BinaryIsNumberOfCorrectLength(fourthOctet) == true &&
				BinaryIsInRange(fourthOctet) == true)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
