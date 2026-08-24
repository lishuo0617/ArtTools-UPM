# Art Tools UPM

Art Tools is a compact Unity Editor toolkit for common art-production tasks.

Version 1.2 adds a Missing Script checker with folder-scoped Prefab scanning,
missing-node details, and one-click Prefab/node location from the unified hub.

This repository is the maintained Unity Package Manager edition. The original
`lishuo0617/ArtTools` repository remains an independent snapshot and is not used
as the development remote for this package.

## Compatibility

- Unity Package Manager Git installation: Unity 2018.4 through Unity 2022.3.
- The source retains Unity 2017 API fallbacks, but Unity 2017 users should use
  the original manually imported ArtTools package because Git-based UPM
  installation is not part of this package's supported Unity 2017 workflow.
- Built-in Render Pipeline, URP, and HDRP projects are supported by the editor
  tools. Pipeline-specific conversion requires the destination shaders to be
  installed in the target project.

## Install with Package Manager

In Unity, open `Window > Package Manager`, choose `Add package from git URL`,
and enter one of these URLs:

Latest maintained version:

```text
https://github.com/lishuo0617/ArtTools-UPM.git
```

Pinned stable version:

```text
https://github.com/lishuo0617/ArtTools-UPM.git#v1.2.0
```

You can also add the dependency directly to `Packages/manifest.json`:

```json
{
  "dependencies": {
    "com.lishuo.arttools": "https://github.com/lishuo0617/ArtTools-UPM.git#v1.2.0"
  }
}
```

After installation, open `Art Tools > 美术工具中心`.

## Updating

- Use a version tag such as `v1.2.0` for reproducible projects.
- Use the untagged Git URL to follow the latest `main` branch.
- Package releases follow semantic versioning. Breaking changes increment the
  major version; new compatible tools increment the minor version; fixes
  increment the patch version.

## Safety

Back up or commit project assets before running batch operations. Material and
texture conversion tools can modify selected project assets.
