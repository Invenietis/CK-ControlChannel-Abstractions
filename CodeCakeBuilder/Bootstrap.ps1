$ErrorActionPreference = "Stop"
Set-StrictMode -Version Latest

dotnet run --project "$PSScriptRoot/CodeCakeBuilder.csproj" @args
