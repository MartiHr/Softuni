using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable() == false)
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }

            if (racerTwo.IsAvailable() == false)
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }

            if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == false)
            {
                return OutputMessages.RaceCannotBeCompleted;
            }

            racerOne.Race();
            racerTwo.Race();

            double chanceOfWinningFirst = racerOne.Car.HorsePower * racerOne.DrivingExperience;
            double chanceOfWinningSecond = racerTwo.Car.HorsePower * racerTwo.DrivingExperience;

            if (racerOne.RacingBehavior == "strict")
            {
                chanceOfWinningFirst *= 1.2;
            }
            else if (racerOne.RacingBehavior == "aggressive")
            {
                chanceOfWinningFirst *= 1.1;
            }

            if (racerTwo.RacingBehavior == "strict")
            {
                chanceOfWinningSecond *= 1.2;
            }
            else if (racerTwo.RacingBehavior == "aggressive")
            {
                chanceOfWinningSecond *= 1.1;
            }

            string winnerUsername = string.Empty;

            if (chanceOfWinningFirst > chanceOfWinningSecond)
            {
                winnerUsername = racerOne.Username;
            }
            else
            {
                winnerUsername = racerTwo.Username;
            }

            return $"{racerOne.Username} has just raced against {racerTwo.Username}! {winnerUsername} is the winner!";
        }
    }
}
