using UnityEngine;

namespace Slax.UIToolkit
{
    /// <summary>
    /// Provides variables for the different classes used in this package.
    /// </summary>
    public static class Variables
    {
        public static readonly string EDIT_ICON_PATH = "Packages/com.slax.uitoolkit/Sprites/Icons/icon-edit-48.png";
        public static readonly string DELETE_ICON_PATH = "Packages/com.slax.uitoolkit/Sprites/Icons/icon-delete-48.png";
        public static readonly string SAVE_ICON_PATH = "Packages/com.slax.uitoolkit/Sprites/Icons/icon-save-48.png";
        public static readonly string SEARCH_ICON_PATH = "Packages/com.slax.uitoolkit/Sprites/Icons/icon-search-48.png";
        public static readonly string LOADING_ICON_PATH = "Packages/com.slax.uitoolkit/Sprites/Icons/icon-loading-48.png";
        public static readonly string TYPING_ICON_PATH = "Packages/com.slax.uitoolkit/Sprites/Icons/icon-typing-48.png";
        public static readonly string BACK_ICON_PATH = "Packages/com.slax.uitoolkit/Sprites/Icons/icon-back-48.png";
        public static readonly string INFO_ICON_PATH = "Packages/com.slax.uitoolkit/Sprites/Icons/icon-info-48.png";
        public static readonly string DANGER_ICON_PATH = "Packages/com.slax.uitoolkit/Sprites/Icons/icon-cross-48.png";
        public static readonly string SUCCESS_ICON_PATH = "Packages/com.slax.uitoolkit/Sprites/Icons/icon-success-48.png";
        public static readonly string WARNING_ICON_PATH = "Packages/com.slax.uitoolkit/Sprites/Icons/icon-warning-48.png";

        public static readonly float ACTION_BUTTON_SIZE = 20;
        public static readonly float BASE_PADDING = 4;
        public static readonly float BASE_MARGIN = 2;
        public static readonly float BASE_BORDER_RADIUS = 4;
        public static readonly float ROUNDED_BORDER_RADIUS = 50;

        const float ALPHA = .8f;

        #region Info
        public static readonly Color INFO_COLOR_BACKGROUND = new Color(0.9f, 0.9f, 1.0f, ALPHA);
        public static readonly Color INFO_COLOR_TEXT = Color.black;
        public static readonly Color INFO_COLOR_BORDER = new Color(0.4f, 0.6f, 1.0f, ALPHA);
        public static readonly string INFO_CLASS_NAME = "info";

        public static VarTypeGroup GetInfoVars()
        {
            return new VarTypeGroup(INFO_ICON_PATH, INFO_COLOR_BACKGROUND, INFO_COLOR_TEXT, INFO_COLOR_BORDER, INFO_CLASS_NAME);
        }
        #endregion

        #region Danger
        public static readonly Color DANGER_COLOR_BACKGROUND = new Color(1.0f, 0.8f, 0.8f, ALPHA);
        public static readonly Color DANGER_COLOR_TEXT = Color.black;
        public static readonly Color DANGER_COLOR_BORDER = new Color(1.0f, 0.4f, 0.4f, ALPHA);
        public static readonly string DANGER_CLASS_NAME = "danger";

        public static VarTypeGroup GetDangerVars()
        {
            return new VarTypeGroup(DANGER_ICON_PATH, DANGER_COLOR_BACKGROUND, DANGER_COLOR_TEXT, DANGER_COLOR_BORDER, DANGER_CLASS_NAME);
        }
        #endregion

        #region Success
        public static readonly Color SUCCESS_COLOR_BACKGROUND = new Color(0.8f, 1.0f, 0.8f, ALPHA);
        public static readonly Color SUCCESS_COLOR_TEXT = Color.black;
        public static readonly Color SUCCESS_COLOR_BORDER = new Color(0.4f, 1.0f, 0.4f, ALPHA);
        public static readonly string SUCCESS_CLASS_NAME = "success";

        public static VarTypeGroup GetSuccessVars()
        {
            return new VarTypeGroup(SUCCESS_ICON_PATH, SUCCESS_COLOR_BACKGROUND, SUCCESS_COLOR_TEXT, SUCCESS_COLOR_BORDER, SUCCESS_CLASS_NAME);
        }
        #endregion

        #region Warning
        public static readonly Color WARNING_COLOR_BACKGROUND = new Color(1.0f, 1.0f, 0.8f, ALPHA);
        public static readonly Color WARNING_COLOR_TEXT = Color.black;
        public static readonly Color WARNING_COLOR_BORDER = new Color(1.0f, 1.0f, 0.4f, ALPHA);
        public static readonly string WARNING_CLASS_NAME = "warning";

        public static VarTypeGroup GetWarningVars()
        {
            return new VarTypeGroup(WARNING_ICON_PATH, WARNING_COLOR_BACKGROUND, WARNING_COLOR_TEXT, WARNING_COLOR_BORDER, WARNING_CLASS_NAME);
        }
        #endregion

        public struct VarTypeGroup
        {
            public string IconPath;
            public Color ColorBackground;
            public Color ColorText;
            public Color ColorBorder;
            public string ClassName;

            public VarTypeGroup(string iconPath, Color colorBackground, Color colorText, Color colorBorder, string className)
            {
                IconPath = iconPath;
                ColorBackground = colorBackground;
                ColorText = colorText;
                ColorBorder = colorBorder;
                ClassName = className;
            }
        }
    }
}