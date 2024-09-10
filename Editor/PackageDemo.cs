using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Slax.UIToolkit.Editor
{
    public class PackageDemo : EditorWindow
    {
        static PackageDemo _window;

        [MenuItem("Slax/UI Toolkit Demo")]
        public static void ShowWindow()
        {
            _window = GetWindow<PackageDemo>("Slax UI Toolkit Demo");
            _window.titleContent = new GUIContent("Slax UI Toolkit Demo");
            _window.minSize = new Vector2(400, 200);
            _window.Show();
        }

        public void CreateGUI()
        {
            var root = rootVisualElement;

            var scrollView = new ScrollView() { viewDataKey = "slax-uitoolkit-demo-scrollview" };

            root.Add(Typography.H1("Slax UI Toolkit Demo").Center());

            root.Add(scrollView);

            scrollView.Add(DemoActionButtons());
            scrollView.Add(DemoAlertBoxes());
            scrollView.Add(DemoContentInfoButtons());
            scrollView.Add(DemoPills());
        }

        public VisualElement DemoActionButtons()
        {
            var actionBtnsContainer = new VisualElement();
            actionBtnsContainer.style.paddingBottom = 10;
            actionBtnsContainer.style.paddingTop = 10;
            actionBtnsContainer.style.paddingLeft = 10;
            actionBtnsContainer.style.paddingRight = 10;
            var label = Typography.H3("Action Buttons");
            label.style.unityFontStyleAndWeight = FontStyle.Bold;
            actionBtnsContainer.Add(label);

            var row = new Row();
            actionBtnsContainer.Add(Typography.Small("new ActionButton() or ActionButton.PlusButton() etc."));
            actionBtnsContainer.Add(row);

            row.Add(ActionButton.PlusButton());
            row.Add(ActionButton.MinusButton());
            row.Add(ActionButton.SearchButton());
            row.Add(ActionButton.InfoButton());
            row.Add(ActionButton.EditButton());
            row.Add(ActionButton.DeleteButton());
            row.Add(ActionButton.CloseButton());
            row.Add(ActionButton.SaveButton());

            var roundedRow = new Row();
            roundedRow.style.flexDirection = FlexDirection.Row;

            roundedRow.Add(ActionButton.PlusButton().Rounded());
            roundedRow.Add(ActionButton.MinusButton().Rounded());
            roundedRow.Add(ActionButton.SearchButton().Rounded());
            roundedRow.Add(ActionButton.InfoButton().Rounded());
            roundedRow.Add(ActionButton.EditButton().Rounded());
            roundedRow.Add(ActionButton.DeleteButton().Rounded());
            roundedRow.Add(ActionButton.CloseButton().Rounded());
            roundedRow.Add(ActionButton.SaveButton().Rounded());

            actionBtnsContainer.Add(roundedRow);

            return actionBtnsContainer;
        }

        public VisualElement DemoAlertBoxes()
        {
            var alertBoxesContainer = new VisualElement();
            alertBoxesContainer.style.paddingBottom = 10;
            alertBoxesContainer.style.paddingTop = 10;
            alertBoxesContainer.style.paddingLeft = 10;
            alertBoxesContainer.style.paddingRight = 10;
            var label = Typography.H3("Alert Boxes");
            alertBoxesContainer.Add(label);
            alertBoxesContainer.Add(Typography.Small("new AlertBox() or AlertBox.Info() / AlertBox.Warning() etc."));

            alertBoxesContainer.Add(AlertBox.Info("This is an information message"));
            alertBoxesContainer.Add(AlertBox.Warning("This is a warning message"));
            alertBoxesContainer.Add(AlertBox.Danger("This is a danger message"));
            alertBoxesContainer.Add(AlertBox.Success("This is a success message"));
            alertBoxesContainer.Add(AlertBox.Info("This is an information message with no icon").RemoveIcon());
            return alertBoxesContainer;
        }

        public VisualElement DemoContentInfoButtons()
        {
            var contentInfoBtnsContainer = new VisualElement();
            contentInfoBtnsContainer.style.paddingBottom = 10;
            contentInfoBtnsContainer.style.paddingTop = 10;
            contentInfoBtnsContainer.style.paddingLeft = 10;
            contentInfoBtnsContainer.style.paddingRight = 10;
            var heading = Typography.H3("Content Info Buttons");
            contentInfoBtnsContainer.Add(heading);
            contentInfoBtnsContainer.Add(Typography.Small("new ContentInfoButton()"));

            var row = new Row();

            contentInfoBtnsContainer.Add(row);

            for (int i = 0; i < 4; i++)
            {
                ContentInfoButton btn = new ContentInfoButton();
                btn.titleText = "Title " + i;
                btn.infoText = "Info " + i;
                row.Add(btn);
            }

            return contentInfoBtnsContainer;
        }

        public VisualElement DemoPills()
        {
            var pillsContainer = new VisualElement();
            pillsContainer.style.paddingBottom = 10;
            pillsContainer.style.paddingTop = 10;
            pillsContainer.style.paddingLeft = 10;
            pillsContainer.style.paddingRight = 10;
            var heading = Typography.H3("Pills");
            pillsContainer.Add(heading);
            pillsContainer.Add(Typography.Small("new Pill()"));

            var row = new Row();

            pillsContainer.Add(row);

            for (int i = 1; i <= 16; i++)
            {
                Pill pill = new Pill();
                pill.labelText = "Pill " + i;
                row.Add(pill);
            }

            return pillsContainer;
        }
    }
}
