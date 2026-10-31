# MGPs-BJ-CA
MGPs Blackjack Combinatorial Analysis.  Exact calculations including splits and insurance.

Help file: BJ CA\MGP's BJ CA Help.pdf (also available from Help in the application)

MGP

## Building and running

The application is a C# Windows Forms project targeting .NET 10 (Windows only). It was converted from the
original VB.NET (.NET Framework 3.5) source, which is in the git history before this change.

Requirements: the .NET 10 SDK. Microsoft Excel is not needed: "Send Results to Excel" writes an `.xlsx` file with
[ClosedXML](https://github.com/ClosedXML/ClosedXML) and opens it in whatever program handles `.xlsx` files.

```
dotnet build "BJ CA.sln"
dotnet run --project "BJ CA\BJ CA.csproj"
```

Or open `BJ CA.sln` in Visual Studio 2026 and run the `BJ CA` project.

The build copies the files the application uses into the output folder (`BJ CA\bin\<Configuration>\net10.0-windows`):

- `BJCA.ini` – the default rule settings (Options > Set Defaults rewrites it)
- `DealerProbs *.dat` – cached dealer probabilities (Options > Update Dealer Probs File adds to them)
- `MGPs BJ CA Results.xlsx` – the template "Send Results to Excel" fills in and saves under the name you choose
- `MGP's BJ CA Help.pdf`

These start from the copies in `BJ CA\Data` and the project folder. Once the application has changed them in the
output folder, later builds leave them alone.

Rule set (`.rs`), strategy, bonus rule and other files saved by earlier versions, including the samples in
`BJ CA\Sample MGP BJCA v2 Files.zip`, still load.

The `BJCA Setup` installer project was built for the .NET Framework 3.5 version and has not been updated.
