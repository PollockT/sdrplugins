using SDRSharp.Common;
using System.Windows.Forms;

namespace SDRSharp.Plugin.Diagnostics
{
    public class DiagnosticsPlugin : ISharpPlugin, ICanLazyLoadGui, ISupportStatus
    {
        private const string _displayName = "Signal Diagnostics";
        private ISharpControl _control;
        private AmplitudeProcessor _processor;

        private ProcessorPanel _configGui;

        public string DisplayName
        {
            get { return _displayName; }
        }

        public UserControl Gui
        {
            get
            {
                LoadGui();
                return _configGui;
            }
        }

        public bool IsActive => _processor.Enabled;

        public void Initialize(ISharpControl control)
        {
            _control = control;
            _processor = new AmplitudeProcessor();
        }

        public void LoadGui()
        {
            if (_configGui == null)
            {
                _configGui = new ProcessorPanel(_processor, _control);
            }
        }

        public void Close()
        {
        }
    }
}
