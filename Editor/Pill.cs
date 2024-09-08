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

        public Pill()
        {
            SetInlineStyles();
            AddToClassList(ussClassName);
            _label.text = labelText;
            Add(_label);
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
