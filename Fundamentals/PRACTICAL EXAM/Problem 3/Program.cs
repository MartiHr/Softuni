using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> likesByFollowers = new Dictionary<string, int>();
            Dictionary<string, int> commentsByFollowers = new Dictionary<string, int>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Log out")
                {
                    break;
                }

                string[] elements = 
                    command.Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);

                if (elements[0] == "New")
                {
                    string username = elements[2];

                    if (likesByFollowers.ContainsKey(username))
                    {
                        continue;
                    }
                    else
                    {
                        likesByFollowers.Add(username, 0);
                        commentsByFollowers.Add(username, 0);
                    }
                }
                else if (elements[0] == "Like")
                {
                    string username = elements[1];
                    int likes = int.Parse(elements[2]);

                    if (likesByFollowers.ContainsKey(username))
                    {
                        likesByFollowers[username] += likes; 
                    }
                    else
                    {
                        likesByFollowers.Add(username, likes);
                        commentsByFollowers.Add(username, 0);
                    }
                }
                else if (elements[0] == "Comment")
                {
                    string username = elements[1];

                    if (likesByFollowers.ContainsKey(username))
                    {
                        commentsByFollowers[username] += 1;
                    }
                    else
                    {
                        likesByFollowers.Add(username, 0);
                        commentsByFollowers.Add(username, 1);
                    }
                }
                else if(elements[0] == "Blocked")
                {
                    string username = elements[1];

                    if (likesByFollowers.ContainsKey(username))
                    {
                        likesByFollowers.Remove(username);
                        commentsByFollowers.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} doesn't exist.");
                    }
                }
            }

            Dictionary<string, int> final = new Dictionary<string, int>();

            foreach (var kvp in likesByFollowers)
            {
                string key = kvp.Key;
                int currentLikes = likesByFollowers[key];
                int currentComment = commentsByFollowers[key];

                int sum = currentComment + currentLikes;

                final.Add(key, sum);
            }

            final = final
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"{final.Count} followers");

            foreach (var kvp in final)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
