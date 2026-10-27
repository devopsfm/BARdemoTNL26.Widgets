# BARdemoTNL26.Widgets

Demo repository for the Techorama NL 2026 session **Your Pipeline Is the Target: A DevOps Field Guide to Modern Supply Chain Security** by Brian Randell (Tuesday October 27, 2026, 14:30).

This is the corrected .NET pipeline. The deliberately broken one is in [BARdemoTNL26.Widgets.Legacy](https://github.com/devopsfm/BARdemoTNL26.Widgets.Legacy). The library itself is a toy; nobody should read the C#.

## What each demo shows and where it lives

| Demo | What you see | Files |
|---|---|---|
| D2 Dependency review, NuGetAudit, cooldown, Trusted Publishing | The `add-newtonsoft` pull request fails twice, independently: the dependency review check names the advisory, and the build fails because NU1903 (a high severity advisory) is promoted to an error. Dependabot waits out a cooldown before proposing updates. The release workflow gets a one-hour nuget.org key from an OIDC token instead of a stored secret. | `.github/workflows/dependency-review.yml`, `Directory.Build.props`, `.github/dependabot.yml`, `.github/workflows/release.yml` |
| D3 Pinning and Dependabot | Every action is pinned to a full commit SHA with the version in a comment. Dependabot keeps the SHAs current and rewrites the comment. | `.github/workflows/*.yml`, the open Dependabot pull request |
| D4 Attestations | The package from the release run carries SLSA provenance. `gh attestation verify` passes on the original and fails on a copy with one byte appended. | `.github/workflows/release.yml`, `scripts/tamper.sh` |

Other controls in this repository: `permissions: contents: read` on every workflow, `persist-credentials: false` on checkout, `dotnet restore --locked-mode` against a committed `packages.lock.json`, package versions kept on each `PackageReference` so the dependency graph can see them, a `nuget.config` that clears inherited sources and maps every package to nuget.org, a `nuget-release` environment with a required reviewer, and a ruleset on `main` that requires the `build` and `review` checks and blocks merges while a secret scanning alert is open.

## Try D4 yourself

```bash
gh run download <release run id> --repo devopsfm/BARdemoTNL26.Widgets -n nupkg -D ./artifact
gh attestation verify ./artifact/*.nupkg --owner devopsfm
scripts/tamper.sh ./artifact/BrianRandell.Demo.TechoramaNL26.Widgets.1.0.0.nupkg
gh attestation verify ./artifact/*.tampered.nupkg --owner devopsfm   # fails
```

## Tooling

Actions were pinned with [pinact](https://github.com/suzuki-shunsuke/pinact) 5.0.2 (`pinact run`).

## Slides

Slides: link to follow after the session.

## Credits

Case studies and the five-pillar framing from *Threats from the Shadows* (2026) by Ken Muse and Mickey Gousset, used with permission.
