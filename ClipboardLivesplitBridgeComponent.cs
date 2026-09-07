using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace ClipboardLivesplitBridge
{
    public class ClipboardLivesplitBridgeComponent : IComponent
    {
        private readonly LiveSplitState state;
        private readonly TimerModel timerModel;
        private readonly Timer clipboardTimer;

        private string lastCommand;

        public ClipboardLivesplitBridgeComponent(LiveSplitState state)
        {
            this.state = state;

            timerModel = new TimerModel
            {
                CurrentState = state
            };

            clipboardTimer = new Timer();
            clipboardTimer.Interval = 10;
            clipboardTimer.Tick += ClipboardTimer_Tick;
            clipboardTimer.Start();

            lastCommand = null;
        }

        private void ClipboardTimer_Tick(object sender, EventArgs e)
        {
            string text;

            try
            {
                if (!Clipboard.ContainsText())
                    return;

                text = Clipboard.GetText();
            }
            catch
            {
                // Clipboard may temporarily be locked by another process.
                return;
            }

            if (String.IsNullOrEmpty(text))
                return;

            text = text.Trim();

            // Only accept the commands we care about.
            if (!String.Equals(text, "start", StringComparison.OrdinalIgnoreCase) &&
                !String.Equals(text, "split", StringComparison.OrdinalIgnoreCase) &&
                !String.Equals(text, "reset", StringComparison.OrdinalIgnoreCase))
            {
                lastCommand = text;
                return;
            }

            // Don't process the same clipboard value repeatedly.
            if (String.Equals(text, lastCommand, StringComparison.OrdinalIgnoreCase))
                return;

            lastCommand = text;
            ProcessCommand(text);
        }

        private void ProcessCommand(string command)
        {
            command = command.Trim().ToLowerInvariant();

            switch (command)
            {
                case "start":
                    timerModel.Start();
                    break;

                case "split":
                    timerModel.Split();
                    break;

                case "reset":
                    timerModel.Reset();
                    break;
            }
        }

        public string ComponentName
        {
            get
            {
                return "Clipboard Livesplit Bridge";
            }
        }

        public float HorizontalWidth
        {
            get { return 0; }
        }

        public float MinimumWidth
        {
            get { return 0; }
        }

        public float VerticalHeight
        {
            get { return 0; }
        }

        public float MinimumHeight
        {
            get { return 0; }
        }

        public float PaddingTop
        {
            get { return 0; }
        }

        public float PaddingLeft
        {
            get { return 0; }
        }

        public float PaddingBottom
        {
            get { return 0; }
        }

        public float PaddingRight
        {
            get { return 0; }
        }

        public IDictionary<string, Action> ContextMenuControls
        {
            get { return null; }
        }

        public void DrawHorizontal(
            Graphics g,
            LiveSplitState state,
            float height,
            Region clipRegion)
        {
        }

        public void DrawVertical(
            Graphics g,
            LiveSplitState state,
            float width,
            Region clipRegion)
        {
        }

        public Control GetSettingsControl(LayoutMode mode)
        {
            return null;
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            return document.CreateElement("Settings");
        }

        public void SetSettings(XmlNode settings)
        {
        }

        public int GetSettingsHashCode()
        {
            return 0;
        }

        public void Update(
            IInvalidator invalidator,
            LiveSplitState state,
            float width,
            float height,
            LayoutMode mode)
        {
        }

        public void Dispose()
        {
            if (clipboardTimer != null)
            {
                clipboardTimer.Stop();
                clipboardTimer.Tick -= ClipboardTimer_Tick;
                clipboardTimer.Dispose();
            }
        }
    }
}