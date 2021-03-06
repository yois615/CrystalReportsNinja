﻿using System;

namespace CrystalReportsNinja
{
    public class Program
    {
        static int Main(string[] args)
        {
            try
            {
                // read program arguments into Argument Container
                ArgumentContainer argContainer = new ArgumentContainer();
                argContainer.ReadArguments(args);

                if (argContainer.GetHelp)
                    Helper.ShowHelpMessage();
                else
                {
                    string _logFilename = string.Empty;

                    if (argContainer.EnableLog)
                        argContainer.LogFileName = "ninja-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".log";

                    ReportProcessor reportNinja = new ReportProcessor();
                    reportNinja.ReportArguments = argContainer;
                    reportNinja.Run();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Exception: {0}",ex.Message));
                Console.WriteLine(string.Format("Inner Exception: {0}", ex.InnerException));

                return 1;
            }

            return 0;
        }
    }
}