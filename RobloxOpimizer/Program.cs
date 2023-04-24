using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobloxOpimizer
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string username = Environment.UserName;
            string path = $@"C:\Users\{username}\AppData\Local\Roblox\Versions";
            string fileName = "RobloxPlayerBeta.exe";

            // Check if the root folder exists
            if (Directory.Exists(path))
            {
                // Search for the file in all subdirectories
                string[] files = Directory.GetFiles(path, fileName, SearchOption.AllDirectories);

                // Print the paths of all matching files and check for ClientSettings folder and ClientAppSettings.json file
                Console.WriteLine($"Found {files.Length} files matching '{fileName}':");

                Console.WriteLine(Resource1.Menu);
                var response = Console.ReadLine();

                if (response != null && response == "1")
                {

                    foreach (string file in files)
                    {

                        // Store the folder of the found file in a variable
                        string folder = Path.GetDirectoryName(file);
                        if (!Directory.Exists(folder + "/ClientSettings"))
                        {
                            Console.WriteLine("Making ClientSettings Folder");
                            Directory.CreateDirectory(folder + "/ClientSettings");

                        }
                        if (!File.Exists(folder + "/ClientSettings/ClientAppSettings.json"))
                        {
                            Console.WriteLine("Writing new FFlag config");
                            File.WriteAllText(folder + "/ClientSettings/ClientAppSettings.json", Resource1.Fflagconfig);
                        }

                    }
                    Console.WriteLine("Finished! Roblox will load these settings next time its started.");
                    Console.ReadLine();
                }
                else if(response == "2")
                {
                    foreach (string file in files)
                    {

                        // Store the folder of the found file in a variable
                        string folder = Path.GetDirectoryName(file);
                        
                        if (File.Exists(folder + "/ClientSettings/ClientAppSettings.json"))
                        {
                            Console.WriteLine("Removing FFlag config");
                            File.Delete(folder + "/ClientSettings/ClientAppSettings.json");
                        }
                        if (Directory.Exists(folder + "/ClientSettings"))
                        {
                            Console.WriteLine("Removing ClientSettings Folder");
                            Directory.Delete(folder + "/ClientSettings");

                        }

                    }
                    Console.WriteLine("Finished! Roblox will load these settings next time its started.");
                    Console.ReadLine();

                }
            }
           
        }
    }
}
