using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using WmiParser;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            OpenBrowser(@"https://skylum.com/");
            Parser p = new Parser();
            p.Parse("", 1);
            Console.WriteLine("Hello World!");
        }

        public static void OpenBrowser(string url)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true }); // Works ok on windows
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("xdg-open", url);  // Works ok on linux
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", url); // Not tested
            }
            else
            {
            }
        }
    }
}
