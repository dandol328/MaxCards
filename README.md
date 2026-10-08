# MaxCards
A rounds mod that limits the maximum amount of cards a player can have. The oldest cards are removed first.

## Configuration
Requires BepInEx, UnboundLib and ModdingUtils. Config option `MaxCards` (section `General`, default `5`) sets the card limit; after each pick, a player's oldest cards are removed so they hold at most that many (e.g. picking a 6th card removes the 1st).

Build: `dotnet build MaxCards/MaxCards.csproj -p:RoundsDir=<path to ROUNDS>`.
