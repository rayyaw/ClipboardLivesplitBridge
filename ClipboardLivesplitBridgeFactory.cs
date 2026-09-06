using LiveSplit.Model;
using System;
using LiveSplit.UI.Components;

[assembly: ComponentFactory(typeof(ClipboardLivesplitBridge.ClipboardLivesplitBridgeFactory))]

namespace ClipboardLivesplitBridge
{
    public class ClipboardLivesplitBridgeFactory : IComponentFactory
    {
        public string ComponentName
        {
            get
            {
                return "Clipboard Livesplit Bridge";
            }
        }

        public string Description
        {
            get
            {
                return "Controls the LiveSplit timer using clipboard commands.";
            }
        }

        public ComponentCategory Category
        {
            get
            {
                return ComponentCategory.Control;
            }
        }

        public IComponent Create(LiveSplitState state)
        {
            return new ClipboardLivesplitBridgeComponent(state);
        }

        public string UpdateName
        {
            get
            {
                return ComponentName;
            }
        }

        public string UpdateURL
        {
            get
            {
                return "";
            }
        }

        public string XMLURL
        {
            get
            {
                return "";
            }
        }

        public Version Version
        {
            get
            {
                return new Version(1, 0, 0);
            }
        }
    }
}
