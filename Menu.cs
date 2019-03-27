namespace DiskMenuCore
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;

    public class Menu
    {
        private readonly List<string> menuItemList = new List<string>();

        public Menu()
        {
            this.LoadAssetFolder();

            if (this.CheckIfEmpty(this.menuItemList))
            {
                this.DrawMenu();
            }
        }

        private void LoadAssetFolder()
        {
            try
            {
                foreach (string file in Directory.EnumerateFiles(Constants.FolderPath))
                {
                    this.menuItemList.Add(file);
                }
            }
            catch (IOException ex)
            {
                const string FileMissing = "Assets directory does not exist. Exiting... ";
                Console.WriteLine(FileMissing);
                Console.WriteLine(ex.Message);
                Console.Write("Press any key...");
                Console.ReadKey(intercept: true);
                Console.Clear();
                throw;
            }
        }

        private bool CheckIfEmpty(List<string> neededFiles)
        {
            if (neededFiles.Count == 0)
            {
                const string FileMissing = "No bat files exist. Try adding a few scripts. " +
                    "\nThe program will now exit... ";
                Console.WriteLine(FileMissing);
                Console.Write("Press any key...");
                Console.ReadKey(intercept: true);
                Console.Clear();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void DrawMenu()
        {
            Console.Clear();
            Console.WriteLine("Type number to pick options:\n");

            // populate menu with items
            int menuIndex = this.menuItemList.Count;
            for (int i = 0; i < menuIndex; i++)
            {
                string menuListText = i + 1 + ": " + this.menuItemList[i].Remove(0, 7) /* hides the asset path, i+1 for zero based  */;
                Console.WriteLine(menuListText);
            }

            string settingsText = menuIndex + 1 + ": Exit";
            Console.WriteLine(settingsText);

            Console.Write("Your choice: ");
            string selectedMenuItem = Console.ReadLine();

            Console.Write("You selected: ");
            Console.WriteLine(selectedMenuItem);

            for (int i = 0; i < menuIndex; i++)
            {
                if (selectedMenuItem.ToString() == (i + 1).ToString()) // + 1 for zero based indexing
                {
                    string command = "/k " + this.menuItemList[i].ToString();
                    Process.Start("cmd.exe", command);
                    
                }
            }

            if (selectedMenuItem.ToString() == (menuIndex + 1).ToString()) // last item is exit
            {                
                this.ShowExitString();
            } else {               
                System.Console.WriteLine("new menu"); 
                this.DrawMenu();
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
