<img align="left" src="pozitronlogo.png" width="120" height="120">

&nbsp; [![NuGet](https://img.shields.io/nuget/v/PozitronDev.DIConfiguration.svg)](https://www.nuget.org/packages/PozitronDev.DIConfiguration)[![NuGet](https://img.shields.io/nuget/dt/PozitronDev.DIConfiguration.svg)](https://www.nuget.org/packages/PozitronDev.DIConfiguration)

&nbsp; [![Build Status](https://dev.azure.com/pozitrondev/PozitronDev.DIConfiguration/_apis/build/status/DIConfiguration_BuildPackage?branchName=master)](https://dev.azure.com/pozitrondev/PozitronDev.DIConfiguration/_build/latest?definitionId=13&branchName=master)

&nbsp; [![Azure DevOps coverage](https://img.shields.io/azure-devops/coverage/pozitrondev/PozitronDev.DIConfiguration/13)](https://dev.azure.com/pozitrondev/PozitronDev.DIConfiguration/_build/latest?definitionId=13&branchName=master&view=codecoverage-tab)

&nbsp;

# PozitronDev DIConfiguration

Nuget package providing extension methods to `IServiceCollection` (.NET Core's built-in DI infrastructure). The extensions provide the ability for dynamic/runtime DI configuration, through external config files.

I described the motivation and the use cases in the following blog post.

https://fiseni.com/posts/open-close-principle-and-runtime-di-configuration/

## Usage

In order to simplify the usage, all bindings can be provided in the default configuration file "appsetting.json", within `Bindings` section. A sample console application can be found under `sample` folder within this repository.

Example configuration:

```json
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

The services and implementations should be provided as fully qualified type names, e.g. "Namespace.Type, AssemblyName".

The generic types can be provided through the standard notation, by adding \`n suffix, where `n` is the number of generic paremeters (refer to the above example).

The scope options are `scoped`, `transient`, and `singleton`.

The configuration is being registered through the `AddBindings` extension method to `IServiceCollection`.

Example usage:

```c#
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

Example ASP.NET Core usage:

```c#
public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddBindings(Configuration);
    }
}
```

## Give a Star! :star:
If you like or are using this project please give it a star. Thanks!
