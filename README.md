# roguelike-csharp-samples

roguelike-csharp-samples is a historical comparison of C# roguelike implementations across generations of SadConsole and related libraries. It preserves a legacy SadConsole 2.5/RogueSharp sample, a partial SadConsole 8.99 port, and a partial GoRogue-based tutorial sample.

## Technical stack

- C#
- Sample 1: .NET Framework 4.7.2, SadConsole 2.5, RogueSharp 4.2
- Sample 2: .NET Core 3.1, SadConsole 8.99, RogueSharp 4.2
- Sample 3: .NET Core 3.1, SadConsole 8.99, GoRogue 2.6
- MonoGame backends and bundled bitmap fonts

## Build

Open `RoguelikeSamples.sln` in a compatible Visual Studio installation and restore NuGet packages. Modern .NET SDKs do not necessarily support every historical target or Windows-specific backend.

## Status

Archived/incomplete samples. Sample 1 represents the legacy baseline; Samples 2 and 3 remain unfinished migrations.

## Known limitations

- .NET Core 3.1 and several game libraries are obsolete.
- Sample 1 depends on legacy project format and Windows/MonoGame packages.
- Samples 2 and 3 are not complete.
- There are no automated tests or CI builds.
- A direct major dependency upgrade would require substantial API and rendering rewrites.

## Next steps

Decide whether preservation or modernization is the priority. For preservation, pin reproducible toolchains and add build notes. For modernization, create a new supported-.NET sample using current SadConsole/GoRogue APIs, port behavior incrementally, and add headless domain tests.

## License

MIT. See `LICENSE` for the full text and project attribution.
