using UnityEngine.UIElements;

namespace Slax.UIToolkit.Editor
{
    public class Row : VisualElement
    {
        public new class UxmlFactory : UxmlFactory<Row, UxmlTraits> { }

        public Row()
        {
            style.flexDirection = FlexDirection.Row;
            style.flexWrap = Wrap.Wrap;
            
            style.paddingBottom = Variables.BASE_PADDING;
            style.paddingTop = Variables.BASE_PADDING;
            style.paddingLeft = Variables.BASE_PADDING;
            style.paddingRight = Variables.BASE_PADDING;
        }
    }
}
