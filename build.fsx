#r @"paket:
source https://nuget.org/api/v2
framework netstandard2.0
nuget Fake.Core.Target
nuget Fake.Core.Trace
nuget Fake.DotNet.Cli
nuget Fake.DotNet.Fsi //"

#if !FAKE
#load "./.fake/build.fsx/intellisense.fsx"
#r "netstandard" // Temp fix for https://github.com/fsharp/FAKE/issues/1985
#endif

open Fake.Core.TargetOperators
open Fake.Core 

//Target.initEnvironment()

Target.create "Run" (fun _ -> 
    CreateProcess.fromRawCommandLine "dotnet" "fsi ./script.fsx"
    |> (Proc.start >> ignore)
)

Target.create "All" ignore

"Run" ==> "All"

Target.runOrDefault "All"