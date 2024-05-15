using System.Diagnostics;

var processName = Environment.GetCommandLineArgs()[1];
var maxLifetime = Convert.ToDouble(Environment.GetCommandLineArgs()[2]);
var interval = Convert.ToInt32(Environment.GetCommandLineArgs()[3]);



Task.Run(() => {
    while (true)
    {
        var processList = Process.GetProcesses();
        foreach (var process in processList)
        {
            if (process.ProcessName.Equals(processName))
            {
                if ((DateTime.Now - process.StartTime).TotalMinutes > maxLifetime)
                {
                    process.Kill();
                }
            }
        }
        
        Thread.Sleep(interval * 1000 * 60);
    }
});

while(true)
{
    var instantKey = Console.ReadKey();
    if (instantKey.KeyChar == 'q')
    {
        break;
    }
}