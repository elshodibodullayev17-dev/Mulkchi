using System.Diagnostics;

namespace Mulkchi.Api.Infrastructure.Build;

public static class DependencyInjection
{
    public static void Build()
    {
        RunCommand("dotnet", "build ../Mulkchi.sln --configuration Release");
        RunCommand("dotnet", "test ../Mulkchi.Api.Tests.Unit --no-build --configuration Release");
    }

    private static void RunCommand(string command, string arguments)
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = command,
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };

        process.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
        process.ErrorDataReceived += (sender, e) => Console.Error.WriteLine(e.Data);

        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        process.WaitForExit();

        if (process.ExitCode != 0)
            throw new Exception($"Command failed: {command} {arguments}");
    }
}
