using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05._Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<FileInfo>> filesByExtension = new Dictionary<string, List<FileInfo>>();
            string path = Console.ReadLine();
            string[] files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                FileInfo info = new FileInfo(file);
                string extension = info.Extension;
                if (!filesByExtension.ContainsKey(extension))
                {
                    filesByExtension[extension] = new List<FileInfo>(); 
                }

                filesByExtension[extension].Add(info);
            }

            using (StreamWriter writer = new StreamWriter(Environment
                .GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt"))
            {
                foreach (var kvp in filesByExtension.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
                {
                    writer.WriteLine(kvp.Key);
                    foreach (var fileInfo in kvp.Value.OrderBy(x => Math.Ceiling((double)x.Length / 1024)))
                    {
                        writer.WriteLine($"--{fileInfo.Name} - {Math.Ceiling((double)fileInfo.Length / 1024)}kb");
                    }
                }
            }
        }
    }
}
