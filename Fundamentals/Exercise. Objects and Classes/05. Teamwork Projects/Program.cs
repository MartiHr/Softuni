using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Teamwork_Projects
{   
    public class Team
    {
        public Team()
        {
            Members = new List<string>();
        }

        public string Creator { get; set; }

        public string TeamName { get; set; }

        public List<string> Members { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 0; i < count; i++)
            {
                string[] teamData = Console.ReadLine()
                    .Split('-');

                string creator = teamData[0];
                string teamName = teamData[1];

                Team existingTeam = GetTeamByName(teams, teamName);

                if (existingTeam != null)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (IsCreator(teams, creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }

                Team currentTeam = new Team()
                {
                    Creator = creator,
                    TeamName = teamName 
                };

                teams.Add(currentTeam);

                Console.WriteLine($"Team {teamName} has been created by {creator}!");
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of assignment")
                {
                    break;
                }

                string[] data = input.Split("->");

                string user = data[0];
                string teamName = data[1];

                Team existingTeam = GetTeamByName(teams, teamName);

                if (existingTeam == null)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                if (IsMember(teams, user))
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                    continue;
                }

                existingTeam.Members.Add(user);
            }

            List<Team> sorted = teams
                .OrderByDescending(t => t.Members.Count)
                .ThenBy(t => t.TeamName)
                .ToList();

            foreach (var team in sorted)
            {
                if (team.Members.Count == 0)
                {
                    break;
                }

                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.Creator}");

                List<string> sortedMembers = team.Members
                    .OrderBy(m => m)
                    .ToList();

                foreach (var member in sortedMembers)
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            List<Team> disbandedTeams = teams
                .Where(t => t.Members.Count == 0)
                .OrderBy(t => t.TeamName)
                .ToList();

            Console.WriteLine("Teams to disband:");
            
            foreach (var team in disbandedTeams)
            {
                Console.WriteLine(team.TeamName);
            }
        }

        private static Team GetTeamByName(List<Team> teams, string teamName)
        {
            foreach (Team team in teams)
            {
                if (team.TeamName == teamName)
                {
                    return team;
                }
            }

            return null;
        }

        private static bool IsMember(List<Team> teams, string user)
        {
            foreach (var team in teams)
            {
                if (team.Creator == user ||
                    team.Members.Contains(user))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsCreator(List<Team> teams, string creator)
        {
            foreach (var team in teams)
            {
                if (team.Creator == creator)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
