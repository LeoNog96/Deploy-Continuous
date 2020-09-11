
using System;
using System.Diagnostics;
using System.IO;
using deploy.core.Providers.Interfaces;
using deploy.core.Services.Interfaces;

namespace deploy.core.Services
{
    public class DeployService : IDeployService
    {
        private readonly IPathProvider _pathProvider;

        public DeployService(IPathProvider pathProvider)
        {
            _pathProvider = pathProvider;
        }

        public void RunUpdate()
        {
            try
            {
                var path = _pathProvider.MapPath(Path.Combine("Scripts", "update.sh"));
                string command = "sh " + path;
                var escapedArgs = command.Replace("\"", "\\\"");

                var process = new Process()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "/bin/bash",
                        Arguments = $"-c \"{escapedArgs}\"",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    }
                };

                process.Start();
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}