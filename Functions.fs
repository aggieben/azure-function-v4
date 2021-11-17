module azure_function_v4.Functions

open System.Net
open Microsoft.Azure.Functions.Worker
open Microsoft.Azure.Functions.Worker.Http
open Microsoft.Azure.WebJobs
open Microsoft.Extensions.Logging
open Azure.Storage.Blobs

[<Function("Index")>]
let run ([<HttpTrigger(AuthorizationLevel.Function, "get", Route = null)>]req: HttpRequestData)
        (context:FunctionContext)
        ([<Blob("test-blobs")>] containerClient:BlobContainerClient)
    =
    async {
        let log = context.GetLogger("azure_function_v4.Functions.Index")
        log.LogInformation("F♯ Http trigger function received a request.")

        log.LogDebug("Container client: {0}", containerClient)

        let response = req.CreateResponse(HttpStatusCode.OK)
        do! response.WriteStringAsync("function executed successfully") |> Async.AwaitTask
        return response
    } |> Async.StartAsTask
