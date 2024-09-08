using UnityEngine;
using UnityEngine.UIElements;

namespace Slax.UIToolkit.Editor
{
    public class AlertBox : VisualElement
    {
        public enum AlertType
        {
            Info,
            Danger,
            Success,
            Warning
        }

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
            _label.text = labelText;
            Add(_label);
            ApplyAlertStyles(); // Apply initial styles based on default alert type
        }

        public static AlertBox Warning(string message)
        {
            AlertBox alertBox = new AlertBox();
            alertBox.alertType = AlertType.Warning;
            alertBox.labelText = message;
            return alertBox;
        }

        public static AlertBox Info(string message)
        {
            AlertBox alertBox = new AlertBox();
            alertBox.alertType = AlertType.Info;
            alertBox.labelText = message;
            return alertBox;
        }

        public static AlertBox Danger(string message)
        {
            AlertBox alertBox = new AlertBox();
            alertBox.alertType = AlertType.Danger;
            alertBox.labelText = message;
            return alertBox;
        }

        public static AlertBox Success(string message)
        {
            AlertBox alertBox = new AlertBox();
            alertBox.alertType = AlertType.Success;
            alertBox.labelText = message;
            return alertBox;
        }

        void ApplyAlertStyles()
        {
            ResetStyles();

            float a = 0.8f;

            switch (_alertType)
            {
                case AlertType.Info:
                    SetStyles(new Color(0.9f, 0.9f, 1.0f, a), new Color(0.4f, 0.6f, 1.0f, a));
                    AddToClassList(ussInfoClassName);
                    break;
                case AlertType.Danger:
                    AddToClassList(ussDangerClassName);
                    SetStyles(new Color(1.0f, 0.8f, 0.8f, a), new Color(1.0f, 0.4f, 0.4f, a));
                    break;
                case AlertType.Success:
                    AddToClassList(ussSuccessClassName);
                    SetStyles(new Color(0.8f, 1.0f, 0.8f, a), new Color(0.4f, 1.0f, 0.4f, a));
                    break;
                case AlertType.Warning:
                    AddToClassList(ussWarningClassName);
                    SetStyles(new Color(1.0f, 0.9f, 0.6f, a), new Color(1.0f, 0.6f, 0.0f, a));
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
