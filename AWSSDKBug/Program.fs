// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open Amazon.DynamoDBv2

[<EntryPoint>]
let main _ =
    let localAmazonDynamoDB = Environment.GetEnvironmentVariable("AWS_DEVELOPMENTURL")
    let clientConfig = AmazonDynamoDBConfig()
    clientConfig.ServiceURL <- localAmazonDynamoDB
    let client = new AmazonDynamoDBClient(clientConfig)

    printfn "Describing table"
    client.DescribeTableAsync("TestName")
        |> Async.AwaitTask
        |> Async.Ignore
        |> Async.RunSynchronously
    printfn "Described table"
    0 // return an integer exit code