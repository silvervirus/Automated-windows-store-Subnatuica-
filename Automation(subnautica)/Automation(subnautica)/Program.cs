using System;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using System.IO.Compression;



class ProcessDemo
{
    

    public static void Main()
    {

        Process notePad = Process.Start("ms-xbl-38616e6e:\\");
        Console.WriteLine("Started Subnautica process Id = " + notePad.Id);
        Console.WriteLine(notePad.MainModule.FileName);
        System.Threading.Thread.Sleep(10000);

        if (notePad.MainModule.FileName.Contains("WindowsApps"))
        {
           
            ProcessStartInfo startInfo = new ProcessStartInfo("c:\\users\\pred1\\Desktop\\UWPInjector.exe");
            startInfo.CreateNoWindow = true;
            startInfo.Arguments = "-p " + notePad.Id;
            Process.Start(startInfo);


            var perfCounter = new PerformanceCounter("Process", "% Processor Time", "UWPInjector");

            // Initialize to start capturing
            perfCounter.NextValue();

            for (int i = 0; i < 200; i++)
            {
                // give some time to accumulate data
                Thread.Sleep(1000);

                float cpu = perfCounter.NextValue() / Environment.ProcessorCount;
              
                Console.WriteLine("UWPInjector CPU: " + cpu);
                Thread.Sleep(3000);
                if (cpu == 0)
                {
                    try
                    {
                        foreach (Process proc in Process.GetProcessesByName("UWPInjector.exe"))
                        {
                            proc.Kill();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                } 
                    



            }

                       




        }


    }
}
