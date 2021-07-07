// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open Amazon.DynamoDBv2
open Amazon.DynamoDBv2.Model
open Amazon.Runtime

[<EntryPoint>]
let main _ =
    let localAmazonDynamoDB = "http://localhost:8000"
    
    let accessKey = Environment.GetEnvironmentVariable("AWS_ACCESS_KEY_ID")
    let secretAccessKey = Environment.GetEnvironmentVariable("AWS_SECRET_ACCESS_KEY")
    let credentials = BasicAWSCredentials(accessKey, secretAccessKey)
    
    let clientConfig = AmazonDynamoDBConfig()
    clientConfig.ServiceURL <- localAmazonDynamoDB
    let client = new AmazonDynamoDBClient(credentials, clientConfig)

    printfn "Describing table"
    client.DescribeTableAsync("TestName")
        |> Async.AwaitTask
        |> Async.Ignore
        |> Async.RunSynchronously
    printfn "Described table"
    0 // return an integer exit code