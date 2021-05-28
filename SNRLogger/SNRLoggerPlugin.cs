using SDRSharp.Common;
using System.Windows.Forms;

namespace SDRSharp.Plugin.SNRLogger
{
    public class SNRLoggerPlugin : ISharpPlugin, ICanLazyLoadGui, ISupportStatus
    {
        private const string _displayName = "SNR Logger";
        private ISharpControl _control;

        private PluginPanel _configGui;

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

        public bool IsActive => _configGui != null && _configGui.IsActive;

        public void Initialize(ISharpControl control)
        {
            _control = control;
        }

        public void Close()
        {
        }

        public void LoadGui()
        {
            if (_configGui == null)
            {
                _configGui = new PluginPanel(_control);
            }
        }
    }
}
