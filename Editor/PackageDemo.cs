using System.Collections.Generic;
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
            root.Add(Typography.H6("Some elements have tooltips with code snippets").Center());

            root.Add(scrollView);

            scrollView.Add(DemoActionButtons());
            scrollView.Add(DemoAlertBoxes());
            scrollView.Add(DemoPills());
            scrollView.Add(DemoContentInfoButtons());
            scrollView.Add(DemoTabMenu());
        }

        public VisualElement DemoActionButtons()
        {
            var actionBtnsContainer = new GroupBox();
            var label = Typography.H3("Action Buttons");
            label.style.unityFontStyleAndWeight = FontStyle.Bold;
            actionBtnsContainer.Add(label);

            var row = new Row();
            actionBtnsContainer.Add(Typography.Small("new ActionButton() or ActionButton.PlusButton() etc."));
            actionBtnsContainer.Add(row);

            Dictionary<ActionButton, string> actionButtons = new Dictionary<ActionButton, string>() {
                { ActionButton.PlusButton(), "ActionButton.PlusButton()" },
                { ActionButton.MinusButton(), "ActionButton.MinusButton()" },
                { ActionButton.SearchButton(), "ActionButton.SearchButton()" },
                { ActionButton.InfoButton(), "ActionButton.InfoButton()" },
                { ActionButton.EditButton(), "ActionButton.EditButton()" },
                { ActionButton.DeleteButton(), "ActionButton.DeleteButton()" },
                { ActionButton.CloseButton(), "ActionButton.CloseButton()" },
                { ActionButton.SaveButton(), "ActionButton.SaveButton()" }
            };

            foreach (var button in actionButtons)
            {
                button.Key.tooltip = button.Value;
                row.Add(button.Key);
            }

            var roundedRow = new Row();
            roundedRow.style.flexDirection = FlexDirection.Row;

            Dictionary<ActionButton, string> roundedButtons = new Dictionary<ActionButton, string>() {
                { ActionButton.PlusButton().Rounded(), "ActionButton.PlusButton().Rounded()" },
                { ActionButton.MinusButton().Rounded(), "ActionButton.MinusButton().Rounded()" },
                { ActionButton.SearchButton().Rounded(), "ActionButton.SearchButton().Rounded()" },
                { ActionButton.InfoButton().Rounded(), "ActionButton.InfoButton().Rounded()" },
                { ActionButton.EditButton().Rounded(), "ActionButton.EditButton().Rounded()" },
                { ActionButton.DeleteButton().Rounded(), "ActionButton.DeleteButton().Rounded()" },
                { ActionButton.CloseButton().Rounded(), "ActionButton.CloseButton().Rounded()" },
                { ActionButton.SaveButton().Rounded(), "ActionButton.SaveButton().Rounded()" }
            };

            foreach (var button in roundedButtons)
            {
                button.Key.tooltip = button.Value;
                roundedRow.Add(button.Key);
            }

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

            Dictionary<AlertBox, string> alertBoxes = new Dictionary<AlertBox, string>() {
                { AlertBox.Info("This is an information message"), "AlertBox.Info()" },
                { AlertBox.Warning("This is a warning message"), "AlertBox.Warning()" },
                { AlertBox.Danger("This is a danger message"), "AlertBox.Danger()" },
                { AlertBox.Success("This is a success message"), "AlertBox.Success()" },
                { AlertBox.Info("This is an information message with no icon").RemoveIcon(), "AlertBox.Info().RemoveIcon()" }
            };

            foreach (var alertBox in alertBoxes)
            {
                alertBox.Key.tooltip = alertBox.Value;
                alertBoxesContainer.Add(alertBox.Key);
            }

            return alertBoxesContainer;
        }

        public VisualElement DemoContentInfoButtons()
        {
            var contentInfoBtnsContainer = new GroupBox();
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
            var pillsContainer = new GroupBox();
            var heading = Typography.H3("Pills");
            pillsContainer.Add(heading);
            pillsContainer.Add(Typography.Small("new Pill()"));

            var row = new Row();

            pillsContainer.Add(row);

            for (int i = 1; i <= 8; i++)
            {
                Pill pill = new Pill();
                pill.labelText = "Pill " + i;
                row.Add(pill);
            }

            var row2 = new Row();

            pillsContainer.Add(row2);

            List<Pill> pills = new List<Pill>() {
                new Pill().SetText("Info").ToInfo(),
                new Pill().SetText("Warning").ToWarning(),
                new Pill().SetText("Danger").ToDanger(),
                new Pill().SetText("Success").ToSuccess()
            };

            foreach (var pill in pills)
            {
                pill.tooltip = $"new Pill().SetText(\"{pill.labelText}\").To{pill.labelText}()";
                row2.Add(pill);
            }

            var row3 = new Row();
            pillsContainer.Add(row3);

            List<Pill> iconPills = new List<Pill>() {
                new Pill().SetText("Info").ToInfo().WithAlertIcon(),
                new Pill().SetText("Warning").ToWarning().WithAlertIcon(),
                new Pill().SetText("Danger").ToDanger().WithAlertIcon(),
                new Pill().SetText("Success").ToSuccess().WithAlertIcon()
            };

            foreach (var pill in iconPills)
            {
                pill.tooltip = $"new Pill().SetText(\"{pill.labelText}\").To{pill.labelText}().WithAlertIcon()";
                row3.Add(pill);
            }

            return pillsContainer;
        }

        public VisualElement DemoTabMenu()
        {
            var tabMenuContainer = new GroupBox();
            tabMenuContainer.Add(Typography.H3("Tab Menu"));
            tabMenuContainer.Add(Typography.Small("new TabMenu().SetTabs()"));

            List<TabMenu.TabAndContainer> tabs = new List<TabMenu.TabAndContainer>() {
                new TabMenu.TabAndContainer("Info", AlertBox.Info("Content 1")),
                new TabMenu.TabAndContainer("Warning", AlertBox.Warning("Content 2")),
                new TabMenu.TabAndContainer("Danger", AlertBox.Danger("Content 3")),
                new TabMenu.TabAndContainer("Success", AlertBox.Success("Content 4"))
            };

            var tabMenu = new TabMenu()
                .SetTabs(tabs);

            tabMenuContainer.Add(tabMenu);

            return tabMenuContainer;
        }
    }
}
