using SDRSharp.Common;
using System.Windows.Forms;

namespace SDRSharp.Plugin.WavRecorder
{
    public class WavRecorderPlugin : ISharpPlugin, ICanLazyLoadGui, ISupportStatus
    {
        private const string DefaultDisplayName = "Recording";

        private ISharpControl _control;
        private RecordingPanel _configGui;

        public UserControl Gui
        {
            get
            {
                LoadGui();
                return _configGui;
            }
        }

        public string DisplayName
        {
            get { return DefaultDisplayName; }
        }

        public bool IsActive => _configGui != null && _configGui.IsActive;

        public void Initialize(ISharpControl control)
        {
            _control = control;
        }

        public void Close()
        {
            if (_configGui != null)
            {
                _configGui.AbortRecording();
            }
        }

        public void LoadGui()
        {
            if (_configGui == null)
            {
                _configGui = new RecordingPanel(_control);
            }
        }
    }
}
