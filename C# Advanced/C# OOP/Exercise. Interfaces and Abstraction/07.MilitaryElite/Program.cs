using _07.MilitaryElite.Enumerations;
using _07.MilitaryElite.Interfaces;
using _07.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<ISoldier> result = new List<ISoldier>();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] elements = command
                    .Split(" ");

                string soldierType = elements[0];
                string id = elements[1];
                string firstName = elements[2];
                string lastName = elements[3];

                if (soldierType == "Private")
                {
                    decimal salary = decimal.Parse(elements[4]);
                    Private privateSoldier = new Private(id, firstName, lastName, salary);
                    result.Add(privateSoldier);
                }
                else if (soldierType == "Spy")
                {
                    int codeNumer = int.Parse(elements[4]);
                    Spy spy = new Spy(id, firstName, lastName, codeNumer);
                    result.Add(spy);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(elements[4]);

                    List<Private> currentPrivates = new List<Private>();

                    foreach (var privateId in elements[5..])
                    {
                        Private currentPrivate = (Private)result.FirstOrDefault(x => x.Id == privateId);
                        currentPrivates.Add(currentPrivate);
                    }

                    LieutenantGeneral lieutenantGeneral =
                        new LieutenantGeneral(id, firstName, lastName, salary, currentPrivates.ToArray());
                    result.Add(lieutenantGeneral);
                }
                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(elements[4]);
                    string corpsType = elements[5];

                    SoldierCorpsEnum corps = default;

                    if (corpsType == "Airforces")
                    {
                        corps = SoldierCorpsEnum.Airforces;
                    }
                    else if (corpsType == "Marines")
                    {
                        corps = SoldierCorpsEnum.Marines;
                    }
                    else
                    {
                        continue;
                    }

                    string[] repairData = elements.Skip(6).ToArray();
                    List<Repair> repairs = new List<Repair>();

                    for (int i = 0; i < repairData.Length; i += 2)
                    {
                        string repairPart = repairData[i];
                        int repairHours = int.Parse(repairData[i + 1]);
                        repairs.Add(new Repair(repairPart, repairHours));
                    }

                    Engineer engineer = new Engineer(id, firstName, lastName, salary, corps, repairs.ToArray());
                    result.Add(engineer);
                }
                else
                {
                    decimal salary = decimal.Parse(elements[4]);
                    string corpsType = elements[5];

                    SoldierCorpsEnum corps = default;

                    if (corpsType == "Airforces")
                    {
                        corps = SoldierCorpsEnum.Airforces;
                    }
                    else if (corpsType == "Marines")
                    {
                        corps = SoldierCorpsEnum.Marines;
                    }
                    else
                    {
                        continue;
                    }
                    string[] missionData = elements.Skip(6).ToArray();
                    List<Mission> missions = new List<Mission>();

                    for (int i = 0; i < missionData.Length; i += 2)
                    {
                        string missionCodeName = missionData[i];
                        MissionStateEnum missionState = default;

                        if (missionData[i + 1] == "inProgress")
                        {
                            missionState = MissionStateEnum.inProgress;
                        }
                        else if (missionData[i + 1] == "Finished")
                        {
                            missionState = MissionStateEnum.Finished;
                        }
                        else
                        {
                            continue;
                        }

                        missions.Add(new Mission(missionCodeName, missionState));
                    }

                    Commando commando = new Commando(id, firstName, lastName, salary, corps, missions.ToArray());
                    result.Add(commando);
                }
            }

            foreach (var soldier in result)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
