# Installation

## Git URL

Open Unity Package Manager and select **Add package from git URL**.

Use the original rolling update URL:

```text
https://github.com/lishuo0617/ArtTools-UPM.git#v1.1.0
```

Keep this URL unchanged. The `v1.1.0` compatibility tag is promoted to every
validated package release, allowing existing installations to use Package
Manager's **Update** button without replacing the Git URL.

## Project manifest

Add this entry to the project's `Packages/manifest.json` dependencies:

```json
"com.lishuo.arttools": "https://github.com/lishuo0617/ArtTools-UPM.git#v1.1.0"
```

## Updating

Select **Art Tools** in Package Manager and click **Update**. Unity re-resolves
the rolling channel and updates the package lock to the latest verified commit.
Do not replace the installed Git URL with a newer version tag.

## Removing

Remove **Art Tools** from Package Manager. UPM-installed package source is
read-only from the project and does not place source files under `Assets`.
