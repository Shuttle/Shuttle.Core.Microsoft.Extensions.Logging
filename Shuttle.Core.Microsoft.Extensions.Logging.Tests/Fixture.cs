using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using NUnit.Framework;

namespace Shuttle.Core.Microsoft.Extensions.Logging.Tests
{
    [TestFixture]
    public class Fixture
    {
        [Test]
        public void Should_be_able_to_log_from_console()
        {
            var output = new StringBuilder();
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                @"..\..\..\..\Shuttle.Core.Microsoft.Extensions.Logging.Client\bin\debug");
            var core = false;

#if (!NETCOREAPP && !NETSTANDARD)
            path = Path.Combine(path, @"net461\Shuttle.Core.Microsoft.Extensions.Logging.Client.exe");
#else
            path = Path.Combine(path, @"netcoreapp2.1\publish\Shuttle.Core.Microsoft.Extensions.Logging.Client.exe");
            core = true;
#endif

            path = Path.GetFullPath(path);

            Assert.IsTrue(File.Exists(path),
                $"Could not find '{path}'.{(core ? "  Please `publish` the client first before running the test." : string.Empty)}");

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = path,
                    CreateNoWindow = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                },
                EnableRaisingEvents = true
            };

            process.OutputDataReceived += (sender, args) => { output.AppendLine(args.Data); };

            process.Start();
            process.BeginOutputReadLine();

            while (!process.HasExited)
            {
                Thread.Sleep(250);
            }

            process.CancelOutputRead();

            Assert.That(output.ToString().Contains($"successful - .net {(core ? "core" : "framework")}"));
        }
    }
}