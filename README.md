<img align="left" src="pozitronlogo.png" width="120" height="120">

# PozitronDev DIConfiguration

Nuget package providing extension methods to `IServiceCollection`, .NET Core's built-in DI infrastructure. The extensions provide the ability for dynamic/runtime DI configuration, through external config files.

## Usage

In order to simplify the usage, all bindings can be provided in the default configuration file "appsetting.json", within `Bindings` section. A sample console application can be found under `sample` folder within this repository.

Example configuration:

```
{
  "Logging": {
    "IncludeScopes": true,
    "LogLevel": {
      "Default": "Information",
      "System": "Information",
      "Microsoft": "Information"
    }
  },
  "AllowedHosts": "*",

  "Bindings": {
    "binding1": {
      "service": "SampleLibrary.ISimpleService, SampleLibrary",
      "implementation": "SampleLibrary.SimpleService, SampleLibrary",
      "scope": "transient"
    },
    "binding2": {
      "service": "SampleLibrary.IGenericService`1, SampleLibrary",
      "implementation": "SampleLibrary.GenericService`1, SampleLibrary",
      "scope": "scoped"
    }
  }
}
```

The services and implementation should be provided as fully qualified type names. The scope options are `scoped`, `transient`, and `singleton`.

The configuration is being registers through the `AddBindings` extension method to `IServiceCollection`.

Example usage:

```
class Program
{
    static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddBindings(context.Configuration);
                })
                .Build();


        using (var scope = host.Services.CreateScope())
        {
            var simpleService = scope.ServiceProvider.GetRequiredService<ISimpleService>();
            Console.WriteLine(simpleService.GetMessage());

            var genericService = scope.ServiceProvider.GetRequiredService<IGenericService<Object>>();
            Console.WriteLine(genericService.GetMessage());
        }
    }
}
```

## Give a Star! :star:
If you like or are using this project please give it a star. Thanks!
