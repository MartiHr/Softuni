using _07.MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Interfaces
{
    public interface IMission
    {
        string CodeName { get; set; }

        MissionStateEnum MissionState { get; set; }

        void CompleteMission();
    }
}
