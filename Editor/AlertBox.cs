using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using static Slax.UIToolkit.Variables;

namespace Slax.UIToolkit.Editor
{
    public class AlertBox : VisualElement
    {
        public new class UxmlFactory : UxmlFactory<AlertBox, UxmlTraits> { }

        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            UxmlEnumAttributeDescription<AlertType> _alertType = new UxmlEnumAttributeDescription<AlertType> { name = "alert-type", defaultValue = AlertType.Info };
            UxmlStringAttributeDescription _labelText = new UxmlStringAttributeDescription { name = "label-text", defaultValue = "Alert" };

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);

                AlertBox alertBox = (AlertBox)ve;
                alertBox.alertType = _alertType.GetValueFromBag(bag, cc);
                alertBox.labelText = _labelText.GetValueFromBag(bag, cc);
            }
        }

        public static readonly string ussClassName = "alert-box";
        public static readonly string ussInfoClassName = "alert-box-info";
        public static readonly string ussDangerClassName = "alert-box-danger";
        public static readonly string ussSuccessClassName = "alert-box-success";
        public static readonly string ussWarningClassName = "alert-box-warning";

        public string labelText
        {
            get => _label.text;
            set => _label.text = value;
        }

        public AlertType alertType
        {
            get => _alertType;
            set
            {
                _alertType = value;
                ApplyAlertStyles();
            }
        }

        private AlertType _alertType = AlertType.Info;

        Label _label = new Label();

        public AlertBox()
        {
            AddToClassList(ussClassName);
            var icon = new VisualElement() { name = "img" };
            icon.style.width = 24;
            icon.style.height = 24;
            var bgSize = new BackgroundSize(BackgroundSizeType.Contain);
            var styleBackgroundSize = new StyleBackgroundSize(bgSize);
            icon.style.backgroundSize = styleBackgroundSize;
            Add(icon);
            _label.text = labelText;
            Add(_label);
            ApplyAlertStyles(); // Apply initial styles based on default alert type
        }

        public AlertBox RemoveIcon()
        {
            var icon = this.Q<VisualElement>("img");
            icon.style.display = DisplayStyle.None;
            return this;
        }

        public static AlertBox Warning(string message)
        {
            AlertBox alertBox = new AlertBox();
            var icon = alertBox.Q<VisualElement>("img");
            icon.style.backgroundImage = AssetDatabase.LoadAssetAtPath<Texture2D>(Variables.WARNING_ICON_PATH);
            alertBox.alertType = AlertType.Warning;
            alertBox.labelText = message;
            return alertBox;
        }

        public static AlertBox Info(string message)
        {
            AlertBox alertBox = new AlertBox();
            var icon = alertBox.Q<VisualElement>("img");
            icon.style.backgroundImage = AssetDatabase.LoadAssetAtPath<Texture2D>(Variables.INFO_ICON_PATH);
            alertBox.alertType = AlertType.Info;
            alertBox.labelText = message;
            return alertBox;
        }

        public static AlertBox Danger(string message)
        {
            AlertBox alertBox = new AlertBox();
            var icon = alertBox.Q<VisualElement>("img");
            icon.style.backgroundImage = AssetDatabase.LoadAssetAtPath<Texture2D>(Variables.DANGER_ICON_PATH);
            alertBox.alertType = AlertType.Danger;
            alertBox.labelText = message;
            return alertBox;
        }

        public static AlertBox Success(string message)
        {
            AlertBox alertBox = new AlertBox();
            var icon = alertBox.Q<VisualElement>("img");
            icon.style.backgroundImage = AssetDatabase.LoadAssetAtPath<Texture2D>(Variables.SUCCESS_ICON_PATH);
            alertBox.alertType = AlertType.Success;
            alertBox.labelText = message;
            return alertBox;
        }

        void ApplyAlertStyles()
        {
            ResetStyles();

            switch (_alertType)
            {
                case AlertType.Info:
                    SetStyles(Variables.INFO_COLOR_BACKGROUND, Variables.INFO_COLOR_BORDER);
                    AddToClassList(ussInfoClassName);
                    break;
                case AlertType.Danger:
                    AddToClassList(ussDangerClassName);
                    SetStyles(Variables.DANGER_COLOR_BACKGROUND, Variables.DANGER_COLOR_BORDER);
                    break;
                case AlertType.Success:
                    AddToClassList(ussSuccessClassName);
                    SetStyles(Variables.SUCCESS_COLOR_BACKGROUND, Variables.SUCCESS_COLOR_BORDER);
                    break;
                case AlertType.Warning:
                    AddToClassList(ussWarningClassName);
                    SetStyles(Variables.WARNING_COLOR_BACKGROUND, Variables.WARNING_COLOR_BORDER);
                    break;
            }
        }

        void SetStyles(Color backgroundColor, Color borderColor)
        {
            style.backgroundColor = new StyleColor(backgroundColor);
            style.borderTopColor = new StyleColor(borderColor);
            style.borderRightColor = new StyleColor(borderColor);
            style.borderBottomColor = new StyleColor(borderColor);
            style.borderLeftColor = new StyleColor(borderColor);
            style.borderTopWidth = 2;
            style.borderRightWidth = 2;
            style.borderBottomWidth = 2;
            style.borderLeftWidth = 2;

            // Border radius
            style.borderTopLeftRadius = 5;
            style.borderTopRightRadius = 5;
            style.borderBottomLeftRadius = 5;
            style.borderBottomRightRadius = 5;

            // Margins and paddings
            style.marginTop = 4;
            style.marginRight = 4;
            style.marginBottom = 4;
            style.marginLeft = 4;

            style.paddingTop = 6;
            style.paddingRight = 8;
            style.paddingBottom = 6;
            style.paddingLeft = 8;

            // Text alignment and color
            style.justifyContent = Justify.Center;
            style.alignItems = Align.Center;
            style.unityFontStyleAndWeight = FontStyle.Bold;
            style.unityTextAlign = TextAnchor.MiddleCenter;
            style.color = new StyleColor(new Color(0.2f, 0.2f, 0.2f)); // Dark text color
        }

        void ResetStyles()
        {
            style.backgroundColor = new StyleColor(new Color(1f, 1f, 1f)); // Default white background
            style.borderTopWidth = 0;
            style.borderRightWidth = 0;
            style.borderBottomWidth = 0;
            style.borderLeftWidth = 0;
        }
    }
}
