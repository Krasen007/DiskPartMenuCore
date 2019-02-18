namespace DiskMenuCore
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;

    public class Menu
    {
        private readonly List<string> menuList = new List<string>();

        public Menu()
        {
            try
            {
                foreach (string file in Directory.EnumerateFiles(Constants.FolderPath))
                {
                    this.menuList.Add(file);
                }
            }
            catch (IOException ex)
            {
                const string FileMissing = "Game Assets directory does not exist. Exiting... ";
                Console.WriteLine(FileMissing);
                Console.WriteLine(ex.Message);
                Console.Write("Press any key...");
                Console.ReadKey(intercept: true);
                Console.Clear();
                throw;
            }

            this.LoadAllNeededFiles(this.menuList);
        }

        private void LoadAllNeededFiles(List<string> neededFiles)
        {
            if (neededFiles.Count == 0)
            {
                const string FileMissing = "No bat files exist. Try adding a few scripts. " +
                    "\nThe program will now exit... ";
                Console.WriteLine(FileMissing);
                Console.Write("Press any key...");
                Console.ReadKey(intercept: true);
                Console.Clear();
            }
            else
            {
                this.DrawMenu();
            }
        }

        private void DrawMenu()
        {
            Console.Clear();
            Console.WriteLine("Type number to pick options:\n");

            int menuIndex = this.menuList.Count;

            for (int i = 0; i < menuIndex; i++)
            {
                string menuListText = i + 1 + ": " + this.menuList[i].Remove(0, 7) /* hides the asset path */;
                Console.WriteLine(menuListText);
            }

            string settingsText = menuIndex + 1 + ": Exit";
            Console.WriteLine(settingsText);

            Console.Write("Your choice: ");
            string selectedMenuItem = Console.ReadLine();

            Console.Write("You selected: ");
            Console.WriteLine(selectedMenuItem);

            bool wantToExit = false;

            for (int i = 1; i < menuIndex + 1; i++)
            {
                if (selectedMenuItem.ToString() == i.ToString())
                {
                    string command = "/c bin\\debug\\netcoreapp2.1\\diskpartmenu\\MAP_Server\\mount_drive.bat";

                    Process.Start("cmd.exe", command);
                }
                else if (selectedMenuItem.ToString() == (i + 1).ToString())
                {
                    string command = "/c bin\\debug\\netcoreapp2.1\\diskpartmenu\\DiskPart\\ListDisk.bat";

                    Process.Start("cmd.exe", command);
                }
                else
                {
                    wantToExit = true;
                    break;
                }
            }

            if (wantToExit)
            {
                this.ShowExitString();
            } else
            {
                DrawMenu();
            }
        }

        /// <summary>
        /// Displays exit text.
        /// </summary>
        private void ShowExitString()
        {
            Console.Clear();
            const string ExitString = "Thank you!\n\nPress any key to exit... ";
            Console.Write(ExitString);
            Console.ReadKey(intercept: true);
            Console.Clear();
        }
    }
}
