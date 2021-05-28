using SDRSharp.Common;
using SDRSharp.Radio;
using System.Windows.Forms;

namespace SDRSharp.Plugin.FrequencyManager
{
    public class FrequencyManagerPlugin : ISharpPlugin, ICanLazyLoadGui, IMustLoadGui, ISupportStatus
    {
        private const string _displayName = "Frequency Manager";
        private ISharpControl _controlInterface;
        private FrequencyManagerPanel _configGui;

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
            get { return _displayName; }
        }

        public bool IsActive => _configGui != null && _configGui.IsActive;

        public bool LoadNeeded => Utils.GetBooleanSetting("showBookmarks");

        public void Close()
        {
        }

        public void Initialize(ISharpControl control)
        {
            _controlInterface = control;
        }

        public void LoadGui()
        {
            if (_configGui == null)
            {
                _configGui = new FrequencyManagerPanel(_controlInterface);
            }
        }
    }
}
