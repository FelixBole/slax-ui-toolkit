using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Slax.UIToolkit.Editor
{
    public class ActionButton : Button
    {
        public new class UxmlFactory : UxmlFactory<ActionButton, UxmlTraits> { }

        public ActionButton()
        {
            style.width = Variables.ACTION_BUTTON_SIZE;
            style.height = Variables.ACTION_BUTTON_SIZE;
            style.unityTextAlign = TextAnchor.MiddleCenter;
            style.color = Color.black;
            style.backgroundColor = Color.white;
            style.alignSelf = Align.FlexEnd;

            style.paddingBottom = 0;
            style.paddingTop = 0;
            style.paddingLeft = 0;
            style.paddingRight = 0;
        }

        public ActionButton Rounded()
        {
            style.borderTopLeftRadius = Variables.ROUNDED_BORDER_RADIUS;
            style.borderTopRightRadius = Variables.ROUNDED_BORDER_RADIUS;
            style.borderBottomLeftRadius = Variables.ROUNDED_BORDER_RADIUS;
            style.borderBottomRightRadius = Variables.ROUNDED_BORDER_RADIUS;

            return this;
        }

        public ActionButton SetIcon(Texture2D icon)
        {
            style.justifyContent = Justify.Center;
            style.alignItems = Align.Center;

            VisualElement ve = new VisualElement();
            ve.name = "icon";
            ve.style.alignSelf = Align.Center;
            ve.style.backgroundImage = icon;
            ve.style.width = Variables.ACTION_BUTTON_SIZE - 4;
            ve.style.height = Variables.ACTION_BUTTON_SIZE - 4;
            var bgSize = new BackgroundSize(BackgroundSizeType.Contain);
            var styleBgSize = new StyleBackgroundSize(bgSize);
            ve.style.backgroundSize = styleBgSize;

            Add(ve);

            return this;
        }

        public static ActionButton PlusButton()
        {
            ActionButton button = new ActionButton();
            button.text = "+";
            return button;
        }

        public static ActionButton MinusButton()
        {
            ActionButton button = new ActionButton();
            button.text = "-";
            return button;
        }

        public static ActionButton EditButton()
        {
            ActionButton button = new ActionButton();
            button.SetIcon(AssetDatabase.LoadAssetAtPath<Texture2D>(Variables.EDIT_ICON_PATH));
            return button;
        }

        public static ActionButton DeleteButton()
        {
            ActionButton button = new ActionButton();
            button.SetIcon(AssetDatabase.LoadAssetAtPath<Texture2D>(Variables.DELETE_ICON_PATH));
            return button;
        }

        public static ActionButton InfoButton()
        {
            ActionButton button = new ActionButton();
            button.SetIcon(AssetDatabase.LoadAssetAtPath<Texture2D>(Variables.INFO_ICON_PATH));
            return button;
        }

        public static ActionButton CloseButton()
        {
            ActionButton button = new ActionButton();
            button.SetIcon(AssetDatabase.LoadAssetAtPath<Texture2D>(Variables.DANGER_ICON_PATH));
            return button;
        }

        public static ActionButton SearchButton()
        {
            ActionButton button = new ActionButton();
            button.SetIcon(AssetDatabase.LoadAssetAtPath<Texture2D>(Variables.SEARCH_ICON_PATH));
            return button;
        }

        public static ActionButton SaveButton()
        {
            ActionButton button = new ActionButton();
            button.SetIcon(AssetDatabase.LoadAssetAtPath<Texture2D>(Variables.SAVE_ICON_PATH));
            return button;
        }
    }
}
