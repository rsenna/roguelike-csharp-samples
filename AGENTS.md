# AGENTS.md

## Repository

This repository is **roguelike-csharp-samples**, a collection of historical multi-generation C# roguelike samples. The repository slug is the canonical project name in documentation and release metadata.

## Working rules

- Read `README.md` and `SPEC.md` before changing behavior.
- Keep changes focused; do not bundle unrelated cleanup with a feature or fix.
- Do not commit secrets, generated dependency directories, build outputs, editor state, or local absolute paths.
- Preserve existing licenses and attribution.
- Update `README.md` and `SPEC.md` when user-visible behavior, support status, setup, or architecture changes.
- Prefer the smallest supported dependency upgrade. Major upgrades must include migration notes and validation.

## Setup

Restore with Visual Studio/toolchains compatible with each sample.

## Validation

Run the applicable commands before opening a pull request:

- `dotnet restore RoguelikeSamples.sln`
- `dotnet build RoguelikeSamples.sln`

If a tool or platform is unavailable, record exactly what was not run and why.

## Project-specific guidance

Preserve Sample 1 as a legacy baseline. Put modern ports in new or clearly versioned samples rather than silently changing the historical comparison. Keep game/domain changes separate from rendering migration.

## Pull requests

Explain the problem, the chosen approach, user/developer impact, tests run, and remaining limitations. Keep commits reviewable and never report a check as passing unless it was executed.
