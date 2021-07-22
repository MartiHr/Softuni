using _07.MilitaryElite.Enumerations;
using _07.MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, MissionStateEnum missionState)
        {
            CodeName = codeName;
            MissionState = missionState;
        }

        public string CodeName { get; set; }

        public MissionStateEnum MissionState { get; set; }

        public void CompleteMission()
        {
            MissionState = MissionStateEnum.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {MissionState}";
        }
    }
}
