# Maintenance policy

- `main` contains the next maintained release.
- Stable releases use annotated tags in the form `vMAJOR.MINOR.PATCH`.
- The public Unity Package Manager URL is permanently
  `https://github.com/lishuo0617/ArtTools-UPM.git#v1.1.0`; do not replace it in
  the README, installation documentation, or user-facing instructions.
- Every release updates `package.json` and `CHANGELOG.md`, then promotes the
  `v1.1.0` compatibility tag so existing users can click **Update** without
  changing their installed Git URL.
- Changes must pass package validation and compile in the supported Unity test
  matrix before a release tag is created.
- The original `lishuo0617/ArtTools` repository is intentionally independent
  and must not be force-pushed, replaced, or used as this repository's remote.
