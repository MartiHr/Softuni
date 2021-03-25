using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Songs
{
    class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numSongs = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 0; i < numSongs; i++)
            {
                string input = Console.ReadLine();
                string[] data = input.Split("_");

                string type = data[0];
                string name = data[1];
                string time = data[2];

                Song currentSong = new Song();

                currentSong.TypeList = type;
                currentSong.Name = name;
                currentSong.Time = time;

                songs.Add(currentSong);
            }

            string lastLine = Console.ReadLine();

            if (lastLine == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (Song song in songs)
                {
                    if (song.TypeList == lastLine)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }

        }
    }
}
