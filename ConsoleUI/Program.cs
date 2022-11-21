using BattleShipLiteLibrary;
using BattleShipLiteLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipLite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WelcomeMessage();
            PlayerInfoModel activePlayer = CreatePlayer("Player 1");
            PlayerInfoModel opponent = CreatePlayer("Player 2");
            PlayerInfoModel winner = null;

            do
            {
                // Display grid activePlayer grid showing where they fired
                DisplayShotGrid(activePlayer);

                // Ask activePlayer for a shot
                // Determine if shot is valid
                // Determine shot results
                RecordPlayerShot(activePlayer, opponent);

                // Determine if game should continue
                bool doesGameContinue = GameLogic.PlayerStillActive(opponent);

                // else, swapt positions (activePlayer becomes opponent)
                if (doesGameContinue == true)
                {

                }
                else
                {
                    winner = activePlayer;
                }

            } while (winner == null);

        }

        private static void RecordPlayerShot(PlayerInfoModel activePlayer, PlayerInfoModel opponent)
        {
            // Asks for a shot ("B2" not "B" then "2")
            // Determine row and column
            // Determine if that is a valid shot
            // Go back to beginning if it's invalid

            // Determine results of shot
            // Record results
        }

        private static void DisplayShotGrid(PlayerInfoModel activePlayer)
        {
            string currentRow = activePlayer.ShotGrid[0].SpotLetter;

            foreach (var gridSpot in activePlayer.ShotGrid)
            {
                if (gridSpot.SpotLetter != currentRow)
                {
                    Console.WriteLine();
                    currentRow = gridSpot.SpotLetter;
                }

                if (gridSpot.Status == GridSpotStatus.Empty)
                {
                    Console.Write($" {gridSpot.SpotLetter}{gridSpot.SpotNumber} ");
                }
                else if (gridSpot.Status == GridSpotStatus.Hit)
                {
                    Console.Write(" X ");
                }
                else if (gridSpot.Status == GridSpotStatus.Miss)
                {
                    Console.Write(" O ");
                }
                else
                {
                    Console.Write(" ? ");
                }

            }
        }

        private static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Battleship Lite!");
            Console.WriteLine("By birdcoffee");
            Console.WriteLine();
        }

        private static PlayerInfoModel CreatePlayer(string playerTitle)
        {
            PlayerInfoModel output = new PlayerInfoModel();

            Console.WriteLine($"Player information for { playerTitle }.");

            // Ask user for their name
            output.PlayerName = AskForPlayersName();
            
            // Load up grid
            GameLogic.InitialiazeGrid(output);

            // Ask user for their ship placement
            PlaceShips(output);

            // Clear screen
            Console.Clear();

            return output;
        }

        private static string AskForPlayersName()
        {
            Console.Write("What is your name: ");
            string output = Console.ReadLine();

            return output;
        }

        private static void PlaceShips(PlayerInfoModel model)
        {
            do
            {
                Console.Write($"Where do you want to place ship number {model.ShipLocation.Count + 1}: ");
                string location = Console.ReadLine();

                bool isValidLocation = GameLogic.PlaceShip(model, location);

                if (isValidLocation == false)
                {
                    Console.WriteLine("That was not a valid location. Please try again.");
                }

            } while (model.ShipLocation.Count < 5);
        }
    }
}
