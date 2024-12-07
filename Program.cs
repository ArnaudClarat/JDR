using JDR;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();

Hero_Warrior Warrior1 = new Hero_Warrior("Ragnar", 1, 0, 20, 12, 5, 3);
Hero_Mage Mage1 = new Hero_Mage("Ariana", 1, 0, 16, 18, 7, 2);

Warrior1.Attack(Mage1);