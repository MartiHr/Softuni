using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    class ProfessionalRacer : Racer
    {
        public ProfessionalRacer(string username, ICar car)
            : base(username, "strict", 30, car)
        {
        }

        public override void Race()
        {
            base.Race();
            DrivingExperience += 10;
        }
    }
}
