﻿using BattleShipLiteLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipLiteLibrary
{
    public static class GameLogic
    {
        public static void InitialiazeGrid(PlayerInfoModel model)
        {
            List<string> letters = new List<string>
            {
                "A",
                "B",
                "C",
                "D",
                "E"
            };

            List<int> numbers = new List<int>
            {
                1,
                2,
                3,
                4,
                5
            };

            foreach (string letter in letters)
            {
                foreach (int number in numbers)
                {
                    AddGridSpot(model, letter, number);
                }
            }
        }

        private static void AddGridSpot(PlayerInfoModel model, string letter, int number)
        {
            GridSpotModel spot = new GridSpotModel
            {
                SpotLetter = letter,
                SpotNumber = number,
                Status = GridSpotStatus.Empty
            };

            model.ShotGrid.Add(spot);
        }

        public static bool PlaceShip(PlayerInfoModel model, string location)
        {
            throw new NotImplementedException();
        }

        public static bool PlayerStillActive(PlayerInfoModel player)
        {
            bool isActive = true;

            foreach (var ship in player.ShipLocation)
            {
                if (ship.Status != GridSpotStatus.Sunk)
                {
                    isActive = true;
                }
            }

            return isActive;

        }

        public static int GetShotCount(PlayerInfoModel winner)
        {
            throw new NotImplementedException();
        }

        public static (string row, int column) SplitShotIntoRowAndColumn(string shot)
        {
            shot = shot.Trim();
            string row = shot[0].ToString();
            int column = shot[1];

            return (row, column);
        }

        public static bool ValidateShot(PlayerInfoModel activePlayer, string row, int column)
        {
            throw new NotImplementedException();
        }

        public static bool IdentifyShotResult(PlayerInfoModel opponent, string row, int column)
        {
            throw new NotImplementedException();
        }

        public static void MarkShotResult(PlayerInfoModel activePlayer, string row, int column, bool isAHit)
        {
            throw new NotImplementedException();
        }
    }
}
