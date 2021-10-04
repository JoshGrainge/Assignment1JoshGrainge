using System;
using System.Collections.Generic;

namespace A1
{
	public class Program
	{
		static Random random = new Random(1);
		static void Main(string[] args)
		{

// Toggle card picker and particle mover logic
#if (false)
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

#else
			
            ParticleMovement particleMover = new ParticleMovement(GetMovementRange());
            while (true)
            {
                Console.Write("0 for base movement only\n1 if a magnetic field is present\n" +
                              "2 if a gravitational field is present\n3 for both fields\n");
                char key = Console.ReadKey().KeyChar;
                if (key != '0' && key != '1' && key != '2' && key != '3') return;

				// Set magnetic field value
				particleMover.MagneticField = (key == '1' || key == '3') ? 1.75M : 1M;

				// Set gravitational field value 
				particleMover.GravitationalField = (key == '2' || key == '3');

                Console.WriteLine($"\nParticle with a movement range of {particleMover.MovementRange} units" +
                                  $" moved a total distance of {particleMover.DistanceMoved} units.\n");
            }
#endif

        }

        /// <summary>
        /// Get random range between 1-6 and returns the value as an integer
        /// </summary>
        /// <returns></returns>
        public static int GetMovementRange()
        {
            return random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
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
        public enum Cards { Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King};

        private static string RandomValue()
		{
            // Get random face value for card in range of card values
            int faceValueMin = 1;
			int faceValueMax = 14;
			int cardValue = random.Next(faceValueMin, faceValueMax);

			// Return card name when the card has unique keyword associated with value
			Cards c = (Cards)cardValue;

            switch (c)
			{
				// Switch OR statement for all unique card names
				case Cards.Ace:
				case Cards.Jack:
				case Cards.Queen:
				case Cards.King:
                    return c.ToString();

				// When there isnt a unique card name just return the integer value

				// Would usually return the cardValue here but wanted to use an enum for fun and to learn how to return the
				// integer value of the current enum
				default:
                    return ((int)c).ToString();
			}
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

    public class ParticleMovement
    {
        public const int BASE_MOVEMENT = 3;
        public const int GRAVITY_MOVEMENT = 2;

		private int movementRange;
        public int MovementRange
		{
			get { return movementRange; }
			set
			{ 
				movementRange = value;
				CalculateDistance();	
			}
		}

		private bool gravitationalField;
		public bool GravitationalField
        {
			get { return gravitationalField; }
			set 
			{
				gravitationalField = value;
				CalculateDistance();
			}
        }

		private decimal magneticField;
		public decimal MagneticField
        {
			get { return magneticField; }
            set {
					magneticField = value;
					CalculateDistance();
				}
        }

        private int distance;
        public int Distance { get => distance; set => distance = value; }

        public int DistanceMoved;

		public ParticleMovement(int _movementRange)
        {
			MovementRange = _movementRange;
        }

		/// <summary>
		/// Calculate distance particle has moved based on base movement speed, the movement range, current magnetic field, and current gravitational field
		/// </summary>
        private void CalculateDistance()
        {
			DistanceMoved = (int)(MovementRange * MagneticField) + BASE_MOVEMENT;

			// Add gravity movement when gravity field is present
			if (GravitationalField)
				DistanceMoved += GRAVITY_MOVEMENT;
        }
		
    }
}
