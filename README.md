# MaxCards
A rounds mod that limits the maximum amount of cards a player can have. The oldest cards are removed first.

## Configuration
Requires BepInEx, UnboundLib and ModdingUtils. Config option `MaxCards` (section `General`, default `5`) sets the card limit; after each pick, a player's oldest cards are removed so they hold at most that many (e.g. picking a 6th card removes the 1st).

## Building

The project targets .NET Framework 4.8 and references DLLs from a ROUNDS install with BepInEx, UnboundLib and ModdingUtils (installed e.g. via a mod manager like Thunderstore/r2modman). Point `RoundsDir` at the game folder (the one containing `Rounds_Data` and `BepInEx`). Output: `MaxCards/bin/Debug/net48/MaxCards.dll`; copy it to `<ROUNDS>/BepInEx/plugins/`.

### Windows
1. Install the [.NET SDK](https://dotnet.microsoft.com/download) (6.0 or newer) or Visual Studio with the ".NET desktop development" workload.
2. In PowerShell:
   ```powershell
   dotnet build MaxCards/MaxCards.csproj -c Release -p:RoundsDir="C:\Program Files (x86)\Steam\steamapps\common\ROUNDS"
   ```
   The default `RoundsDir` is the standard Steam path, so the `-p:` option can be omitted if you use it.

### Linux
1. Install the .NET SDK (e.g. `sudo apt install dotnet-sdk-8.0`, or see the Microsoft install docs). Building net48 on Linux uses reference assemblies pulled automatically from NuGet (`Microsoft.NETFramework.ReferenceAssemblies`); if you get a missing-reference-assemblies error, add that package to the project or install `mono-devel`.
2. Locate the ROUNDS install (Steam/Proton), typically `~/.steam/steam/steamapps/common/ROUNDS`, then:
   ```bash
   dotnet build MaxCards/MaxCards.csproj -c Release -p:RoundsDir="$HOME/.steam/steam/steamapps/common/ROUNDS"
   ```
   Note the project uses backslashes in HintPaths; MSBuild normalizes these on Linux.
