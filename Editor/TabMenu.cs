using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Slax.UIToolkit.Editor
{
    public class TabMenu : VisualElement
    {
        public struct TabAndContainer
        {
            public string TabName;
            public VisualElement TabContent;

            public TabAndContainer(string tabName, VisualElement tabContent)
            {
                TabName = tabName;
                TabContent = tabContent;
            }
        }

        public Color activeTabBorderColor { get; set; } = Variables.INFO_COLOR_BORDER;
        public Color activeTabBgColor { get; set; } = Variables.INFO_COLOR_BACKGROUND;
        public Color activeTabTextColor { get; set; } = Variables.INFO_COLOR_TEXT;
        public Color inactiveTabBorderColor { get; set; } = new Color(0.62f, 0.62f, 0.62f);
        public Color inactiveTabBgColor { get; set; } = new Color(0.62f, 0.62f, 0.62f);
        public Color inactiveTabTextColor { get; set; } = new Color(0.37f, 0.37f, 0.37f);
        public int activeTabIndex { get; set; }

        VisualElement _tabContainer = new VisualElement();
        VisualElement _tabContentContainer = new VisualElement();
        List<TabAndContainer> _tabs = new List<TabAndContainer>();

        public TabMenu()
        {
            style.flexGrow = 1;

            _tabContainer.style.flexDirection = FlexDirection.Row;
            _tabContainer.style.flexGrow = 1;
            _tabContainer.style.borderTopWidth = 0;
            _tabContainer.style.borderLeftWidth = 0;
            _tabContainer.style.borderRightWidth = 0;
            _tabContainer.style.borderBottomWidth = 0;
            _tabContainer.style.height = 24;

            _tabContainer.style.borderTopColor = inactiveTabBgColor;
            _tabContainer.style.borderLeftColor = inactiveTabBgColor;
            _tabContainer.style.borderRightColor = inactiveTabBgColor;

            _tabContentContainer.style.backgroundColor = activeTabBgColor;

            _tabContentContainer.style.paddingBottom = 4;
            _tabContentContainer.style.paddingTop = 4;
            _tabContentContainer.style.paddingLeft = 4;
            _tabContentContainer.style.paddingRight = 4;

            Add(_tabContainer);
            Add(_tabContentContainer);
        }

        public TabMenu SetTabs(List<TabAndContainer> tabs)
        {
            _tabs = tabs;

            int tabIndex = 0;
            foreach (var tab in tabs)
            {
                var tabElement = MakeTab(tab.TabName);
                _tabContainer.Add(tabElement);
                tab.TabContent.style.display = DisplayStyle.None;
                _tabContentContainer.Add(tab.TabContent);
                tabIndex++;
            }

            SetActiveTab(0);

            return this;
        }

        public TabMenu SetActiveBorderColor(Color color)
        {
            activeTabBorderColor = color;
            SetActiveTab(activeTabIndex);
            return this;
        }

        public TabMenu SetActiveTabBackgroundColor(Color color)
        {
            activeTabBgColor = color;
            _tabContentContainer.style.backgroundColor = color;
            SetActiveTab(activeTabIndex);
            return this;
        }

        public TabMenu SetActiveTabTextColor(Color color)
        {
            activeTabTextColor = color;
            SetActiveTab(activeTabIndex);
            return this;
        }

        public TabMenu SetInactiveBorderColor(Color color)
        {
            inactiveTabBorderColor = color;
            SetActiveTab(activeTabIndex);
            return this;
        }

        public TabMenu SetInactiveTabBackgroundColor(Color color)
        {
            inactiveTabBgColor = color;
            SetActiveTab(activeTabIndex);
            return this;
        }

        public TabMenu SetInactiveTabTextColor(Color color)
        {
            inactiveTabTextColor = color;
            SetActiveTab(activeTabIndex);
            return this;
        }

        public TabMenu SetActiveTab(int tabIndex)
        {
            if (tabIndex < 0 || tabIndex >= _tabs.Count) return this;

            activeTabIndex = tabIndex;

            for (int i = 0; i < _tabs.Count; i++)
            {
                var tab = _tabs[i];
                if (i == tabIndex)
                {
                    SetActiveStyle(_tabContainer[i]);
                    tab.TabContent.style.display = DisplayStyle.Flex;
                }
                else
                {
                    SetInactiveStyle(_tabContainer[i]);
                    tab.TabContent.style.display = DisplayStyle.None;
                }
            }

            return this;
        }

        Button MakeTab(string tabName)
        {
            var tab = new Button();
            tab.RemoveFromClassList("unity-button");
            tab.RemoveFromClassList("unity-text-element");
            tab.style.unityTextAlign = TextAnchor.MiddleLeft;
            tab.style.flexGrow = 1;
            tab.style.alignContent = Align.Center;
            tab.style.justifyContent = Justify.Center;

            tab.style.color = Color.black;

            tab.style.borderTopLeftRadius = 8;
            tab.style.borderTopRightRadius = 8;

            TimeValue duration = new TimeValue(0.2f, TimeUnit.Second);
            StyleList<TimeValue> transition = new StyleList<TimeValue>(new List<TimeValue> { duration });
            tab.style.transitionDuration = transition;

            var label = new Label();
            label.text = tabName;
            label.style.paddingLeft = 4;
            label.style.fontSize = 12;
            tab.Add(label);

            SetInactiveStyle(tab);

            tab.RegisterCallback<ClickEvent>(evt =>
            {
                int index = _tabContainer.IndexOf(tab);
                SetActiveTab(index);
            });

            tab.RegisterCallback<MouseEnterEvent>(evt => { SetHoverStyle(tab); });
            tab.RegisterCallback<MouseLeaveEvent>(evt => { SetInactiveStyle(tab); });

            return tab;
        }

        void SetInactiveStyle(VisualElement tab)
        {
            if (_tabContainer.IndexOf(tab) == activeTabIndex)
            {
                return;
            }

            tab.style.borderBottomColor = activeTabBorderColor;
            tab.style.borderTopColor = inactiveTabBorderColor;
            tab.style.borderLeftColor = inactiveTabBorderColor;
            tab.style.borderRightColor = Color.clear;

            tab.style.borderBottomWidth = 2;
            tab.style.borderRightWidth = 1;
            tab.style.borderTopWidth = 1;
            tab.style.borderLeftWidth = 1;

            tab.style.backgroundColor = inactiveTabBgColor;
            tab.style.color = inactiveTabTextColor;

        }

        void SetHoverStyle(VisualElement tab)
        {
            if (_tabContainer.IndexOf(tab) == activeTabIndex)
            {
                return;
            }

            tab.style.backgroundColor = activeTabBgColor;
            tab.style.color = activeTabTextColor;
        }

        void SetActiveStyle(VisualElement tab)
        {
            tab.style.borderTopColor = activeTabBorderColor;
            tab.style.borderLeftColor = activeTabBorderColor;
            tab.style.borderRightColor = activeTabBorderColor;

            tab.style.borderTopWidth = 2;
            tab.style.borderLeftWidth = 2;
            tab.style.borderRightWidth = 2;
            tab.style.borderBottomWidth = 0;

            tab.style.backgroundColor = activeTabBgColor;
            tab.style.color = activeTabTextColor;

        }

        #region UXML Factory
        public new class UxmlFactory : UxmlFactory<TabMenu, UxmlTraits> { }
        public new class UxmlTraits : Button.UxmlTraits
        {
            UxmlColorAttributeDescription _activeTabBorderColor = new UxmlColorAttributeDescription { name = "active-tab-border-color", defaultValue = Variables.INFO_COLOR_BORDER };
            UxmlColorAttributeDescription _activeTabBgColor = new UxmlColorAttributeDescription { name = "active-tab-bg-color", defaultValue = Variables.INFO_COLOR_BACKGROUND };
            UxmlColorAttributeDescription _activeTabTextColor = new UxmlColorAttributeDescription { name = "active-tab-text-color", defaultValue = Variables.INFO_COLOR_TEXT };
            UxmlColorAttributeDescription _inactiveTabBorderColor = new UxmlColorAttributeDescription { name = "inactive-tab-border-color", defaultValue = new Color(0.62f, 0.62f, 0.62f) };
            UxmlColorAttributeDescription _inactiveTabBgColor = new UxmlColorAttributeDescription { name = "inactive-tab-bg-color", defaultValue = new Color(0.62f, 0.62f, 0.62f) };
            UxmlColorAttributeDescription _inactiveTabTextColor = new UxmlColorAttributeDescription { name = "inactive-tab-text-color", defaultValue = new Color(0.37f, 0.37f, 0.37f) };

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);

                TabMenu tabMenu = (TabMenu)ve;
                tabMenu.activeTabBorderColor = _activeTabBorderColor.GetValueFromBag(bag, cc);
                tabMenu.activeTabBgColor = _activeTabBgColor.GetValueFromBag(bag, cc);
                tabMenu.activeTabTextColor = _activeTabTextColor.GetValueFromBag(bag, cc);
                tabMenu.inactiveTabBorderColor = _inactiveTabBorderColor.GetValueFromBag(bag, cc);
                tabMenu.inactiveTabBgColor = _inactiveTabBgColor.GetValueFromBag(bag, cc);
                tabMenu.inactiveTabTextColor = _inactiveTabTextColor.GetValueFromBag(bag, cc);
            }
        }
        #endregion
    }
}
