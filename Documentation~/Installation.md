# Installation

## Git URL

Open Unity Package Manager and select **Add package from git URL**.

Use the rolling stable channel when you want future verified releases to be
available through Package Manager's **Update** button without changing the URL:

```text
https://github.com/lishuo0617/ArtTools-UPM.git#stable
```

For projects that must remain on one exact release, use an immutable version
tag such as `#v1.2.0`. The legacy video URL ending in `#v1.1.0` remains a
supported rolling update channel and is promoted together with `stable`.

## Project manifest

Add this entry to the project's `Packages/manifest.json` dependencies:

```json
"com.lishuo.arttools": "https://github.com/lishuo0617/ArtTools-UPM.git#stable"
```

## Updating

Select **Art Tools** in Package Manager and click **Update**. Unity re-resolves
the rolling channel and updates the package lock to the latest verified commit.
Pinned version URLs do not jump between immutable version tags.

## Removing

Remove **Art Tools** from Package Manager. UPM-installed package source is
read-only from the project and does not place source files under `Assets`.
