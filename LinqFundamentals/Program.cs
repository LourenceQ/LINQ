using static System.Console;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace LinqFundamentals
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\windows";
            ShowLargeFilesWithoutLinq(path);
            ln();
            WriteLine("|----------/<><><><||><><><>\\----------|");
            ln();
            ShowLargeFilesWithLinq(path);
        }

        private static void ShowLargeFilesWithLinq(string path)
        {
            /*var query = from f in new DirectoryInfo(path).GetFiles()
                        orderby f.Length descending
                        select f;
            foreach (var f in query.Take(5))
            {
                WriteLine($"{f.Name,-20} : {f.Length,10:N0}");
            }*/

            var query = new DirectoryInfo(path).GetFiles()
                .OrderByDescending(f => f.Length)
                .Take(5);
            foreach (var f in query)
            {
                WriteLine($"{f.Name,-20} : {f.Length, 10:N0}");
            }
        }

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files =  dir.GetFiles();
            Array.Sort(files, new FileInfoComparer());

            for(int x = 0; x < 5; x++)
            {
                FileInfo f = files[x];
                WriteLine($"{f.Name, -20} : {f.Length, 10:N0}");
            }
        }

        public static void ln()
        {
            WriteLine();
        }
    }

    public class FileInfoComparer : IComparer<FileInfo>
    {
        public int Compare([AllowNull] FileInfo x, [AllowNull] FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}
