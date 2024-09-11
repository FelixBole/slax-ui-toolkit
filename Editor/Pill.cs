using UnityEngine;
using UnityEngine.UIElements;

namespace Slax.UIToolkit.Editor
{
    public class Pill : VisualElement
    {
        public new class UxmlFactory : UxmlFactory<Pill, UxmlTraits> { }
        public new class UxmlTraits : VisualElement.UxmlTraits 
        { 
            UxmlStringAttributeDescription _labelText = new UxmlStringAttributeDescription { name = "label-text", defaultValue = "Pill" };

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);

                Pill pill = (Pill)ve;
                pill.labelText = _labelText.GetValueFromBag(bag, cc);
            }
        }

        public static readonly string ussClassName = "pill";

        public string labelText
        {
            get => _label.text;
            set => _label.text = value;
        }

        Label _label = new Label();

        Variables.AlertType _alertType = Variables.AlertType.None;

        public Pill()
        {
            SetInlineStyles();
            AddToClassList(ussClassName);
            _label.text = labelText;
            Add(_label);
        }

        public Pill SetText(string text)
        {
            labelText = text;
            return this;
        }

        public Pill SetFontSize(int size)
        {
            _label.style.fontSize = size;
            return this;
        }

        public Pill ToDanger()
        {
            _alertType = Variables.AlertType.Danger;
            style.backgroundColor = new StyleColor(Variables.DANGER_COLOR_BACKGROUND);
            style.color = new StyleColor(Variables.DANGER_COLOR_TEXT);
            style.borderTopColor = new StyleColor(Variables.DANGER_COLOR_BORDER);
            style.borderRightColor = new StyleColor(Variables.DANGER_COLOR_BORDER);
            style.borderBottomColor = new StyleColor(Variables.DANGER_COLOR_BORDER);
            style.borderLeftColor = new StyleColor(Variables.DANGER_COLOR_BORDER);
            return this;
        }

        public Pill ToWarning()
        {
            _alertType = Variables.AlertType.Warning;
            style.backgroundColor = new StyleColor(Variables.WARNING_COLOR_BACKGROUND);
            style.color = new StyleColor(Variables.WARNING_COLOR_TEXT);
            style.borderTopColor = new StyleColor(Variables.WARNING_COLOR_BORDER);
            style.borderRightColor = new StyleColor(Variables.WARNING_COLOR_BORDER);
            style.borderBottomColor = new StyleColor(Variables.WARNING_COLOR_BORDER);
            style.borderLeftColor = new StyleColor(Variables.WARNING_COLOR_BORDER);
            return this;
        }

        public Pill ToSuccess()
        {
            _alertType = Variables.AlertType.Success;
            style.backgroundColor = new StyleColor(Variables.SUCCESS_COLOR_BACKGROUND);
            style.color = new StyleColor(Variables.SUCCESS_COLOR_TEXT);
            style.borderTopColor = new StyleColor(Variables.SUCCESS_COLOR_BORDER);
            style.borderRightColor = new StyleColor(Variables.SUCCESS_COLOR_BORDER);
            style.borderBottomColor = new StyleColor(Variables.SUCCESS_COLOR_BORDER);
            style.borderLeftColor = new StyleColor(Variables.SUCCESS_COLOR_BORDER);
            return this;
        }

        public Pill ToInfo()
        {
            _alertType = Variables.AlertType.Info;
            style.backgroundColor = new StyleColor(Variables.INFO_COLOR_BACKGROUND);
            style.color = new StyleColor(Variables.INFO_COLOR_TEXT);
            style.borderTopColor = new StyleColor(Variables.INFO_COLOR_BORDER);
            style.borderRightColor = new StyleColor(Variables.INFO_COLOR_BORDER);
            style.borderBottomColor = new StyleColor(Variables.INFO_COLOR_BORDER);
            style.borderLeftColor = new StyleColor(Variables.INFO_COLOR_BORDER);
            return this;
        }

        public Pill WithAlertIcon()
        {
            Texture2D icon = Variables.GetIconForType(_alertType);
            style.flexDirection = FlexDirection.Row;
            style.alignItems = Align.Center;
            style.justifyContent = Justify.Center;

            // Remove label, and icon and add them back in the correct order
            Remove(_label);
            var iconElement = new VisualElement();
            iconElement.style.backgroundImage = icon;
            iconElement.style.backgroundSize = new StyleBackgroundSize(new BackgroundSize(BackgroundSizeType.Contain));
            iconElement.style.width = 16;
            iconElement.style.height = 16;
            iconElement.style.marginRight = 4;
            Add(iconElement);
            Add(_label);
            return this;
        }

        void SetInlineStyles()
        {
            style.marginTop = 2;
            style.marginRight = 2;
            style.marginBottom = 2;
            style.marginLeft = 2;

            style.paddingTop = 2;
            style.paddingRight = 4;
            style.paddingBottom = 2;
            style.paddingLeft = 4;

            style.borderTopLeftRadius = 3;
            style.borderTopRightRadius = 3;
            style.borderBottomLeftRadius = 3;
            style.borderBottomRightRadius = 3;

            style.backgroundColor = new StyleColor(new Color(0.8f, 0.8f, 0.8f));
            style.color = new StyleColor(new Color(0.2f, 0.2f, 0.2f));

            style.justifyContent = Justify.Center;

            style.flexShrink = 1;
            style.flexGrow = 0;

            style.unityFontStyleAndWeight = FontStyle.Normal;
            style.unityTextAlign = TextAnchor.MiddleCenter;
            style.alignSelf = Align.FlexStart;
        }
    }
}
