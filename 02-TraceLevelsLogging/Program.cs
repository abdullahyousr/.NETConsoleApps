using System.Diagnostics;
using Microsoft.Extensions.Configuration;

Debug.WriteLine("Debug says, I am watching.");
Trace.WriteLine("Trace says, I am watching.");

ConfigurationBuilder builder = new();
builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json",optional:true,reloadOnChange:true);

IConfigurationRoot configuration = builder.Build();

TraceSwitch TS = new("MySwitch", "This switch is set via a JSON config");

configuration.GetSection("MySwitch").Bind(TS);

Trace.WriteLineIf(TS.TraceError,"Trace error");
Trace.WriteLineIf(TS.TraceInfo,"Trace information");
Trace.WriteLineIf(TS.TraceVerbose,"Trace verbose");
Trace.WriteLineIf(TS.TraceWarning,"Trace warning");
