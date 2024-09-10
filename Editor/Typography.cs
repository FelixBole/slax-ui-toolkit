using UnityEngine;
using UnityEngine.UIElements;

namespace Slax.UIToolkit.Editor
{
    public class Typography : Label
    {
        public new class UxmlFactory : UxmlFactory<Label, UxmlTraits> { }

        public Typography()
        {
            style.unityFontStyleAndWeight = FontStyle.Bold;
        }

        public Typography Center()
        {
            style.unityTextAlign = TextAnchor.MiddleCenter;
            return this;
        }

        public Typography Right()
        {
            style.unityTextAlign = TextAnchor.MiddleRight;
            return this;
        }

        public Typography Left()
        {
            style.unityTextAlign = TextAnchor.MiddleLeft;
            return this;
        }

        public static Typography H1(string text)
        {
            var h1 = new Typography();
            h1.text = text;
            h1.style.fontSize = 24;
            return h1;
        }

        public static Typography H2(string text)
        {
            var h2 = new Typography();
            h2.text = text;
            h2.style.fontSize = 20;
            return h2;
        }

        public static Typography H3(string text)
        {
            var h3 = new Typography();
            h3.text = text;
            h3.style.fontSize = 18;
            return h3;
        }

        public static Typography H4(string text)
        {
            var h4 = new Typography();
            h4.text = text;
            h4.style.fontSize = 16;
            return h4;
        }

        public static Typography H5(string text)
        {
            var h5 = new Typography();
            h5.text = text;
            h5.style.fontSize = 14;
            return h5;
        }

        public static Typography H6(string text)
        {
            var h6 = new Typography();
            h6.text = text;
            h6.style.fontSize = 12;
            return h6;
        }

        public static Typography Paragraph(string text)
        {
            var p = new Typography();
            p.text = text;
            p.style.unityFontStyleAndWeight = FontStyle.Normal;
            p.style.fontSize = 12;
            return p;
        }

        public static Typography Small(string text)
        {
            var small = new Typography();
            small.text = text;
            small.style.fontSize = 10;
            return small;
        }
    }
}
