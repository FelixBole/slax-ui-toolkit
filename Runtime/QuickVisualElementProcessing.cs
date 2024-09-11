using UnityEditor;
using UnityEngine;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Slax.UIToolkit
{
    public static class QuickVisualElementProcessing
    {
        public static VisualElement SetColorToBorders(VisualElement el, Color color)
        {
            el.style.borderBottomColor = color;
            el.style.borderLeftColor = color;
            el.style.borderRightColor = color;
            el.style.borderTopColor = color;

            return el;
        }

        public static VisualElement SetColorToBorders(VisualElement el, Color top, Color right, Color bottom, Color left)
        {
            el.style.borderTopColor = top;
            el.style.borderRightColor = right;
            el.style.borderBottomColor = bottom;
            el.style.borderLeftColor = left;

            return el;
        }

        public static VisualElement SetBorderWidth(VisualElement el, float width)
        {
            el.style.borderBottomWidth = width;
            el.style.borderLeftWidth = width;
            el.style.borderRightWidth = width;
            el.style.borderTopWidth = width;

            return el;
        }

        public static VisualElement SetBorderWidth(VisualElement el, float top, float right, float bottom, float left)
        {
            el.style.borderTopWidth = top;
            el.style.borderRightWidth = right;
            el.style.borderBottomWidth = bottom;
            el.style.borderLeftWidth = left;

            return el;
        }

        public static VisualElement SetBorderRadius(VisualElement el, float radius)
        {
            el.style.borderBottomLeftRadius = radius;
            el.style.borderBottomRightRadius = radius;
            el.style.borderTopLeftRadius = radius;
            el.style.borderTopRightRadius = radius;

            return el;
        }

        public static VisualElement SetBorderRadius(VisualElement el, float topLeft, float topRight, float bottomRight, float bottomLeft)
        {
            el.style.borderTopLeftRadius = topLeft;
            el.style.borderTopRightRadius = topRight;
            el.style.borderBottomRightRadius = bottomRight;
            el.style.borderBottomLeftRadius = bottomLeft;

            return el;
        }

        public static VisualElement SetPadding(VisualElement el, float padding)
        {
            el.style.paddingBottom = padding;
            el.style.paddingLeft = padding;
            el.style.paddingRight = padding;
            el.style.paddingTop = padding;

            return el;
        }

        public static VisualElement SetPadding(VisualElement el, float top, float right, float bottom, float left)
        {
            el.style.paddingTop = top;
            el.style.paddingRight = right;
            el.style.paddingBottom = bottom;
            el.style.paddingLeft = left;

            return el;
        }

        public static VisualElement SetMargin(VisualElement el, float margin)
        {
            el.style.marginBottom = margin;
            el.style.marginLeft = margin;
            el.style.marginRight = margin;
            el.style.marginTop = margin;

            return el;
        }

        public static VisualElement SetMargin(VisualElement el, float top, float right, float bottom, float left)
        {
            el.style.marginTop = top;
            el.style.marginRight = right;
            el.style.marginBottom = bottom;
            el.style.marginLeft = left;

            return el;
        }

        public static VisualElement SetSize(VisualElement el, float width, float height)
        {
            el.style.width = width;
            el.style.height = height;

            return el;
        }

        public static VisualElement SetSize(VisualElement el, Vector2 size)
        {
            el.style.width = size.x;
            el.style.height = size.y;

            return el;
        }

        public static VisualElement SetClassNames(VisualElement el, params string[] classNames)
        {
            foreach (string className in classNames)
            {
                el.AddToClassList(className);
            }

            return el;
        }

        public static VisualElement RemoveClassNames(VisualElement el, params string[] classNames)
        {
            foreach (string className in classNames)
            {
                if (el.ClassListContains(className)) el.RemoveFromClassList(className);
            }

            return el;
        }
    }
}