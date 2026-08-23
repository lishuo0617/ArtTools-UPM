# Maintenance policy

- `main` contains the next maintained release.
- Stable releases use annotated tags in the form `vMAJOR.MINOR.PATCH`.
- Every release updates `package.json`, `CHANGELOG.md`, and the pinned URL in
  the installation documentation.
- Changes must pass package validation and compile in the supported Unity test
  matrix before a release tag is created.
- The original `lishuo0617/ArtTools` repository is intentionally independent
  and must not be force-pushed, replaced, or used as this repository's remote.
