namespace DiskMenuCore
{
    using System;

    public class Start
    {
        protected Start()
        {
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DefineOs();
            StartMenu();

            ////ExecuteCommand("bin\\debug\\netcoreapp2.1\\diskpartmenu\\MAP_Server\\mount_drive.bat");
            ////ExecuteCommand();
            Console.WriteLine("after bat3111132!");
        }

        /// <summary>
        /// Start the game instance.
        /// </summary>
        private static void StartMenu() => new Menu();

        /// <summary>
        /// Detects the current OS.
        /// </summary>
        private static void DefineOs()
        {
            OperatingSystem os = Environment.OSVersion;
            PlatformID pid = os.Platform;
            switch (pid)
            {
                case PlatformID.Win32NT:
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:
                case PlatformID.WinCE:
                    {
                        const string WelcomeWindows = "Welcome to " + Constants.ProgramName + " for Windows";
                        Console.WriteLine(WelcomeWindows);
                        break;
                    }

                case PlatformID.Unix:
                    const string WelcomeLinux = "Welcome to " + Constants.ProgramName + " for Linux";
                    Console.WriteLine(WelcomeLinux);
                    break;
                case PlatformID.MacOSX:
                    const string WelcomeMac = "Welcome to " + Constants.ProgramName + " for Mac!";
                    Console.WriteLine(WelcomeMac);
                    break;
                default:
                    const string WelcomeAnyOS = "Welcome to " + Constants.ProgramName + " for any OS";
                    Console.WriteLine(WelcomeAnyOS);
                    break;
            }
        }
    }
}
