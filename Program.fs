module azure_function_v4.Program

open System.Threading.Tasks
open Microsoft.Azure.Functions.Worker.Configuration
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.Hosting

let host =
    HostBuilder()
        .ConfigureFunctionsWorkerDefaults()
        .Build()

host.Run()