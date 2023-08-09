using System.Timers;

System.Timers.Timer aTimer;

SetTimer();

Console.WriteLine("\nPress the Enter key to exit the application...\n");
await WriteToFile("Service is started at " + DateTime.Now);

await Task.Delay(5000);

aTimer.Stop();
aTimer.Dispose();
await WriteToFile("Service is stopped at " + DateTime.Now);
Console.WriteLine("Terminating the application...");

void SetTimer()
{
    aTimer = new System.Timers.Timer(1000);
    aTimer.Elapsed += OnTimedEvent;
    aTimer.AutoReset = true;
    aTimer.Enabled = true;
}

static void OnTimedEvent(object? source, ElapsedEventArgs e)
{
    try
    {
        WriteToFile("Service is recall at " + DateTime.Now);
    }
    catch (Exception ex)
    {
#if DEBUG
        Console.WriteLine(ex);
#else
        Console.WriteLine(ex.Message);
#endif
    }
}

static Task WriteToFile(string message)
{
    var path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
    if (!Directory.Exists(path))
        Directory.CreateDirectory(path);

    var filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" +
                   DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";

    var writerMethod = File.Exists(filepath) ? File.AppendText(filepath) : File.CreateText(filepath);

    using var sw = writerMethod;
    sw.WriteLine(message);

    return Task.CompletedTask;
}