using UnityEditor;
using UnityEngine.UIElements;

namespace Slax.UIToolkit.Editor
{
    /// <summary>
    /// A button that displays a title and an info text.
    /// </summary>
    public class ContentInfoButton : Button
    {
        const string UXML_ASSET_PATH = "Packages/com.slax.uitoolkit/Uxml/ContentInfoButton.uxml";
        public static readonly string titleLabelName = "contentInfoButton__title";
        public static readonly string infoLabelName = "contentInfoButton__info";

        #region Public Properties

        public string titleText
        {
            get => GetTitleText();
            set => SetTitleText(value);
        }

        public string infoText
        {
            get => GetInfoText();
            set => SetInfoText(value);
        }

        #endregion

        string GetTitleText()
        {
            var title = this.Q<Label>(titleLabelName);
            if (title == null)
            {
                return "";
            }
            return title.text;
        }

        void SetTitleText(string value)
        {
            var title = this.Q<Label>(titleLabelName);
            if (title == null)
            {
                return;
            }
            title.text = value;
        }

        string GetInfoText()
        {
            var info = this.Q<Label>(infoLabelName);
            if (info == null)
            {
                return "";
            }
            return info.text;
        }

        void SetInfoText(string value)
        {
            var info = this.Q<Label>(infoLabelName);
            if (info == null)
            {
                return;
            }
            info.text = value;
        }

        public ContentInfoButton()
        {
            RemoveFromClassList(ussClassName);
            VisualTreeAsset uxml = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(UXML_ASSET_PATH);
            uxml.CloneTree(this);
        }

        #region UXML Factory
        public new class UxmlFactory : UxmlFactory<ContentInfoButton, UxmlTraits> { }
        public new class UxmlTraits : Button.UxmlTraits
        {
            UxmlStringAttributeDescription _titleText = new UxmlStringAttributeDescription { name = "title-text", defaultValue = "Title" };
            UxmlStringAttributeDescription _infoText = new UxmlStringAttributeDescription { name = "info-text", defaultValue = "Info" };

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);

                ContentInfoButton button = (ContentInfoButton)ve;
                button.titleText = _titleText.GetValueFromBag(bag, cc);
                button.infoText = _infoText.GetValueFromBag(bag, cc);
            }
        }
        #endregion
    }
}