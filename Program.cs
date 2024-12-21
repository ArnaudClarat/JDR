using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System;
using System.Text;
using System.Net.Http;
using JDR;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Embedded Console

builder.Services.AddSingleton<LogService>();

var host = builder.Build();

var logService = host.Services.GetRequiredService<LogService>();
Console.SetOut(new LogWriter(logService));

await host.RunAsync();

public class LogWriter : System.IO.TextWriter
{
    private readonly LogService _logService;
    public override Encoding Encoding => null;

    public LogWriter(LogService logService)
    {
        _logService = logService;
    }

    public override void WriteLine(string message)
    {
        _logService.Log(message);
    }

    public override void Write(char value) { }
}