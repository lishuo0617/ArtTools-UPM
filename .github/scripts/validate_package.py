import json
import re
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]


def fail(message):
    raise SystemExit("ERROR: " + message)


manifest_path = ROOT / "package.json"
manifest = json.loads(manifest_path.read_text(encoding="utf-8"))

required = ("name", "version", "displayName", "description", "unity")
for field in required:
    if not manifest.get(field):
        fail("package.json is missing " + field)

if manifest["name"] != "com.lishuo.arttools":
    fail("unexpected package name")

if not re.fullmatch(r"\d+\.\d+\.\d+", manifest["version"]):
    fail("version must use MAJOR.MINOR.PATCH")

for folder_name in ("Editor", "Runtime"):
    folder = ROOT / folder_name
    if not folder.is_dir():
        fail("missing " + folder_name + " folder")
    if not (ROOT / (folder_name + ".meta")).is_file():
        fail("missing " + folder_name + ".meta")
    for asset in folder.rglob("*"):
        if asset.is_file() and asset.suffix != ".meta":
            meta = Path(str(asset) + ".meta")
            if not meta.is_file():
                fail("missing meta file for " + str(asset.relative_to(ROOT)))

for forbidden in ("Assets", "Library", "Temp", "ProjectSettings"):
    if (ROOT / forbidden).exists():
        fail("repository must not contain " + forbidden)

source_text = "\n".join(
    path.read_text(encoding="utf-8", errors="replace")
    for path in list((ROOT / "Editor").rglob("*.cs"))
    + list((ROOT / "Editor").rglob("*.shader"))
)

if "Packages/com.unity.render-pipelines.universal" in source_text:
    fail("hard URP package include detected")

menu_entries = re.findall(r'MenuItem\("Art Tools/', source_text)
if len(menu_entries) != 1:
    fail("expected exactly one Art Tools menu entry, found " + str(len(menu_entries)))

print("Art Tools package validation passed")
