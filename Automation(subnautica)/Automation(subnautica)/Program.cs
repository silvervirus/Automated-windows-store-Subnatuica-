using System;
using System.Threading;
using System.Security.Permissions;
using System.Security.Principal;
using System.Diagnostics;

using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Management;

class ProcessDemo
{
    
    

    public static void Main()
    {
       
        Process notePad = Process.Start("ms-xbl-38616e6e:\\");
        Console.WriteLine("Started Subnautica process Id = " + notePad.Id);
        Console.WriteLine(notePad.MainModule.FileName);
        System.Threading.Thread.Sleep(3000);
        if (notePad.MainModule.FileName.Contains("WindowsApps"))
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("c:\\users\\pred1\\Desktop\\UWPInjector.exe");
            startInfo.CreateNoWindow = true;
             startInfo.Arguments = "-p " + notePad.Id;
            Process.Start(startInfo);

            FileSystemWatcher watcher;

            void watch()
            {
                watcher = new FileSystemWatcher();
                watcher.Path = @"%AppData%\Local\Packages\UnknownWorldsEntertainmen.GAMEPREVIEWSubnautica_bh1f6rvenfkm2\TempState\DUMP";
                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                       | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                watcher.Filter = "*.*";
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.EnableRaisingEvents = true;
            }

            void OnChanged(object source, FileSystemEventArgs e)
            {
                string sourceFile = @"%AppData%\Local\Packages\UnknownWorldsEntertainmen.GAMEPREVIEWSubnautica_bh1f6rvenfkm2\TempState\DUMP";
                string destinationFile = @"C:\Games\Subnautica";

                // To move a file or folder to a new location:
                System.IO.File.Move(sourceFile, destinationFile);

                // To move an entire directory. To programmatically modify or combine
                // path strings, use the System.IO.Path class.
                System.IO.Directory.Move(@"%AppData%\Local\Packages\UnknownWorldsEntertainmen.GAMEPREVIEWSubnautica_bh1f6rvenfkm2\TempState\DUMP", @"C:\Games\Subnautica");
            }








        }
    }
}

