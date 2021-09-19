using System;
using System.Collections.Generic;

namespace A1
{
	public class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter the number of cards to pick: ");
			string line = Console.ReadLine();
			if (int.TryParse(line, out int numCards))
			{
				foreach (var card in CardPicker.PickSomeCards(numCards))
				{
					Console.WriteLine(card);
				}
			}
			else
			{
				Console.WriteLine("Please enter a valid number.");
			}
		}
	}

	public static class SubsequenceFinder
	{
		/// <summary>
		/// Determines whether a list of integers is a subsequence of another list of integers
		/// </summary>
		/// <param name="seq">The main sequence of integers.</param>
		/// <param name="subseq">The potential subsequence.</param>
		/// <returns>True if subseq is a subsequence of seq and false otherise.</returns>
		public static bool IsValidSubsequeuce(List<int> seq, List<int> subseq)
		{
			// Iterates through every element in subsequence and if the element is not found
			// in the main sequence then it is not a subsequence of the main sequence
            foreach (var sequenceElement in subseq)
            {
				if (!seq.Contains(sequenceElement))
					return false;
            }

			// Return true if all elements in subsequence were found in sequence
			return true;
		}
	}

	public class CardPicker
	{
		static Random random = new Random(1);
		/// <summary>
		/// Picks a random (with replacement) number of cards.
		/// </summary>
		/// <param name="numCards">The number of cards to choose at random.</param>
		/// <returns>An array of strings where each string represents a card.</returns>
		public static string[] PickSomeCards(int numCards)
		{
			string[] cards = new string[numCards];

            // Get random value and suit for specified number of cards then return the array of randomized cards
            for (int i = 0; i < numCards; i++)
            {
				string cardString = $"{RandomValue()} of {RandomSuit()}";

				cards[i] = cardString;
            }

			return cards;
		}
		/// <summary>
		/// Chooses a random value for a card (Ace, 2, 3, ... , Queen, King)
		/// </summary>
		/// <returns>A string that represents the value of a card</returns>
		private static string RandomValue()
		{
            // Get random face value for card in range of card values
            int faceValueMin = 1;
			int faceValueMax = 14;
			int cardValue = random.Next(faceValueMin, faceValueMax);

			// Return card name when the card has unique keyword associated with value
			switch (cardValue)
			{
				case 1:
                    return "Ace";
				case 11:
					return "Jack";
				case 12:
					return "Queen";
				case 13:
					return "King";
			}

			// When value should be kept numerical just return number value as string
			return cardValue.ToString();
		}

		/// <summary>
		/// Chooses a random suit for a card (Clubs, Diamonds, Hearts, Spades)
		/// </summary>
		/// <returns>A string that represents the suit of a card.</returns>
		private static string RandomSuit()
		{
			// Get random suit index and returns suit name as a string
			int suitIndexMin = 0;
            int suitIndexMax = 4;
            int suitIndex = random.Next(suitIndexMin, suitIndexMax);

            switch (suitIndex)
            {
				case 0:
					return "Clubs";
                case 1:
					return "Diamonds";
                case 2:
					return "Hearts";
                case 3:
					return "Spades";
				// Return error string if suit index is out of range of suits
				default:
					return "RandomSuit is returning value out of the range of number of suits";
            }
		}
	}
}
