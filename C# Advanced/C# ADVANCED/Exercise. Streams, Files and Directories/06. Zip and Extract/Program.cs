using System;
using System.IO.Compression;

namespace _06._Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"D:\Test1", @"D:\Test2\TestArchive.zip");
            ZipFile.ExtractToDirectory(@"D:\Test2\TestArchive.zip", @"D:\Test2");
        }
    }
}
