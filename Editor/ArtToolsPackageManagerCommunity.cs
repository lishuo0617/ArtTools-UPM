#if UNITY_2019_4_OR_NEWER
using UnityEditor;
using PackageInfo = UnityEditor.PackageManager.PackageInfo;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UIElements;

namespace ArtTools.EditorTools
{
    // Keep the built-in Description section above this package's community panel.
    [InitializeOnLoad]
    internal sealed class ArtToolsPackageManagerCommunity : IPackageManagerExtension
    {
        private const string PackageName = "com.lishuo.arttools";
        private const string QrAssetPath = "Packages/com.lishuo.arttools/QQ群二维码.png";
        private VisualElement panel;
        private VisualElement content;
        private bool isArtToolsSelected;

        static ArtToolsPackageManagerCommunity()
        {
            PackageManagerExtensions.RegisterExtension(new ArtToolsPackageManagerCommunity());
        }

        public VisualElement CreateExtensionUI()
        {
            panel = new VisualElement();
            panel.style.display = DisplayStyle.None;
            panel.style.marginTop = 8;
            panel.style.marginBottom = 8;
            panel.style.paddingLeft = 14;
            panel.style.paddingRight = 14;
            panel.style.paddingTop = 12;
            panel.style.paddingBottom = 12;
            panel.style.backgroundColor = new Color(0.10f, 0.19f, 0.33f, 1f);

            var title = new Label("加入 ArtTools QQ 交流群");
            title.style.fontSize = 18;
            title.style.unityFontStyleAndWeight = FontStyle.Bold;
            title.style.color = Color.white;
            title.style.marginBottom = 8;
            panel.Add(title);

            content = new VisualElement();
            content.style.flexDirection = FlexDirection.Row;
            content.style.alignItems = Align.FlexStart;
            panel.Add(content);

            var copy = new VisualElement();
            copy.style.width = 220;
            copy.style.flexGrow = 0;
            copy.style.flexShrink = 1;
            copy.style.minWidth = 180;
            copy.style.marginRight = 8;
            content.Add(copy);

            AddLine(copy, "扫码加入交流群", 15, true);
            AddLine(copy, "交流工具用法 · 反馈问题 · 提出功能建议", 13, false);
            AddLine(copy, "QQ群号：1124864329", 15, true);
            AddLine(copy, "也可以在 QQ 中搜索群号加入。", 12, false);

            var qr = AssetDatabase.LoadAssetAtPath<Texture2D>(QrAssetPath);
            if (qr != null)
            {
                var image = new Image { image = qr, scaleMode = ScaleMode.ScaleToFit };
                image.style.width = 270;
                image.style.height = 300;
                image.style.flexShrink = 0;
                image.style.position = Position.Relative;
                image.style.left = 40;
                image.style.top = -40;
                image.tooltip = "ArtTools QQ 交流群二维码，群号 1124864329";
                content.Add(image);
            }
            else
            {
                AddLine(content, "二维码见仓库首页 README", 12, false);
            }

            panel.RegisterCallback<GeometryChangedEvent>(OnPanelGeometryChanged);
            panel.RegisterCallback<AttachToPanelEvent>(evt => UpdateHostOrder());
            panel.style.display = isArtToolsSelected ? DisplayStyle.Flex : DisplayStyle.None;
            return panel;
        }

        public void OnPackageSelectionChange(PackageInfo packageInfo)
        {
            isArtToolsSelected = packageInfo != null && packageInfo.name == PackageName;
            RefreshVisibility();
        }

        public void OnPackageAddedOrUpdated(PackageInfo packageInfo)
        {
            if (packageInfo != null && packageInfo.name == PackageName)
            {
                RefreshVisibility();
            }
        }

        public void OnPackageRemoved(PackageInfo packageInfo)
        {
            if (packageInfo != null && packageInfo.name == PackageName)
            {
                isArtToolsSelected = false;
                RefreshVisibility();
            }
        }

        private void RefreshVisibility()
        {
            if (panel != null)
            {
                panel.style.display = isArtToolsSelected ? DisplayStyle.Flex : DisplayStyle.None;
                UpdateHostOrder();
            }
        }

        private void UpdateHostOrder()
        {
            if (panel == null || panel.parent == null)
            {
                return;
            }

            // The custom and built-in details are siblings in Unity's Package Manager.
            // Check their names before changing the order so other layouts remain untouched.
            var host = panel.parent;
            var details = host.parent;
            if (host.name != "detailCustomContainer" || details == null || details.name != "detail")
            {
                return;
            }

            VisualElement body = null;
            VisualElement extension = null;
            for (var i = 0; i < details.childCount; ++i)
            {
                if (details[i].name == "detailsBody") body = details[i];
                if (details[i].name == "detailExtensionContainer") extension = details[i];
            }

            if (isArtToolsSelected && body != null)
            {
                host.PlaceInFront(body);
            }
            else if (!isArtToolsSelected && extension != null)
            {
                host.PlaceBehind(extension);
            }
        }

        private void OnPanelGeometryChanged(GeometryChangedEvent evt)
        {
            if (content != null)
            {
                content.style.flexDirection = evt.newRect.width < 540 ? FlexDirection.Column : FlexDirection.Row;
            }
        }

        private static void AddLine(VisualElement parent, string text, int size, bool emphasized)
        {
            var label = new Label(text);
            label.style.fontSize = size;
            label.style.color = Color.white;
            label.style.whiteSpace = WhiteSpace.Normal;
            label.style.marginBottom = 8;
            if (emphasized)
            {
                label.style.unityFontStyleAndWeight = FontStyle.Bold;
            }

            parent.Add(label);
        }
    }
}
#endif
