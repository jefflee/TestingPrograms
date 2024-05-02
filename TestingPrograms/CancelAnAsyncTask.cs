using System.Diagnostics;

namespace TestingPrograms;

/// <summary>
///     Refer to
///     https://learn.microsoft.com/zh-tw/dotnet/csharp/asynchronous-programming/cancel-async-tasks-after-a-period-of-time
///     Cancel an async task after a period of time.
/// </summary>
[TestFixture]
internal class CancelAnAsyncTask
{
    private static readonly HttpClient s_client = new()
    {
        MaxResponseContentBufferSize = 1_000_000
    };

    private static readonly IEnumerable<string> s_urlList = new[]
    {
        "https://learn.microsoft.com",
        "https://learn.microsoft.com/aspnet/core",
        "https://learn.microsoft.com/azure",
        "https://learn.microsoft.com/azure/devops",
        "https://learn.microsoft.com/dotnet",
        "https://learn.microsoft.com/dynamics365",
        "https://learn.microsoft.com/education",
        "https://learn.microsoft.com/enterprise-mobility-security",
        "https://learn.microsoft.com/gaming",
        "https://learn.microsoft.com/graph",
        "https://learn.microsoft.com/microsoft-365",
        "https://learn.microsoft.com/office",
        "https://learn.microsoft.com/powershell",
        "https://learn.microsoft.com/sql",
        "https://learn.microsoft.com/surface",
        "https://learn.microsoft.com/system-center",
        "https://learn.microsoft.com/visualstudio",
        "https://learn.microsoft.com/windows",
        "https://learn.microsoft.com/xamarin"
    };

    [Test]
    public async Task Main()
    {
        CancellationTokenSource s_cts = new();
        Console.WriteLine("Application started.");

        try
        {
            s_cts.CancelAfter(3500);

            await SumPageSizesAsync(s_cts.Token);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("\nTasks cancelled: timed out.\n");
        }
        finally
        {
            s_cts.Dispose();
        }

        Console.WriteLine("Application ending.");
    }

    private static async Task SumPageSizesAsync(CancellationToken token)
    {
        var stopwatch = Stopwatch.StartNew();

        var total = 0;
        foreach (var url in s_urlList)
        {
            var contentLength = await ProcessUrlAsync(url, s_client, token);
            total += contentLength;
        }

        stopwatch.Stop();

        Console.WriteLine($"\nTotal bytes returned:  {total:#,#}");
        Console.WriteLine($"Elapsed time:          {stopwatch.Elapsed}\n");
    }

    private static async Task<int> ProcessUrlAsync(string url, HttpClient client, CancellationToken token)
    {
        var response = await client.GetAsync(url, token);
        var content = await response.Content.ReadAsByteArrayAsync(token);
        Console.WriteLine($"{url,-60} {content.Length,10:#,#}");

        return content.Length;
    }
}