using System;
using System.Diagnostics;

namespace DiskMenuCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            StartMenu();



            //ExecuteCommand("bin\\debug\\netcoreapp2.1\\diskpartmenu\\MAP_Server\\mount_drive.bat");
            //ExecuteCommand();
            Console.WriteLine("after bat3111132!");
           // Console.ReadLine();
        }

        private static void StartMenu()
        {
            Console.WriteLine("Type number to pick options:\n");

            Console.WriteLine("1. Mount drive");
            Console.WriteLine("2. (diskpart) List disk");
            System.Console.WriteLine();
            System.Console.Write("Your choice: ");

            string selectedMenuItem = Console.ReadLine();
            int num = int.Parse(selectedMenuItem);
            System.Console.Write("You selected: ");
            Console.WriteLine(num);
            checkSelection(selectedMenuItem);
            StartMenu();
        }

        private static void checkSelection(string selectedMenuItem)
        {
            if (selectedMenuItem == 1.ToString())
            {
                string command = "/c bin\\debug\\netcoreapp2.1\\diskpartmenu\\MAP_Server\\mount_drive.bat";

                Process.Start("cmd.exe", command);
            } else if (selectedMenuItem == 2.ToString())
            {
                string command = "/c bin\\debug\\netcoreapp2.1\\diskpartmenu\\DiskPart\\ListDisk.bat";

                Process.Start("cmd.exe", command);
            }
        }
    }
}
