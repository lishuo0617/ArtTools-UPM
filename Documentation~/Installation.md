# Installation

## Git URL

Open Unity Package Manager and select **Add package from git URL**.

Use the stable version for production projects:

```text
https://github.com/lishuo0617/ArtTools-UPM.git#v1.1.0
```

Use the URL without a tag only when you intentionally want the latest changes
from `main`.

## Project manifest

Add this entry to the project's `Packages/manifest.json` dependencies:

```json
"com.lishuo.arttools": "https://github.com/lishuo0617/ArtTools-UPM.git#v1.1.0"
```

## Removing

Remove **Art Tools** from Package Manager. UPM-installed package source is
read-only from the project and does not place source files under `Assets`.
