using SDRSharp.Common;
using SDRSharp.Radio;
using System.Windows.Forms;

namespace SDRSharp.Plugin.BandPlan
{
    public class BandPlanPlugin : ISharpPlugin, ICanLazyLoadGui, IMustLoadGui, ISupportStatus
    {
        private const string _displayName = "Band Plan";
        private ISharpControl _controlInterface;
        private BandPlanPanel _configGui;

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

        public bool LoadNeeded =>
            Utils.GetBooleanSetting("plugin.bandPlan.enabled", true) ||
            Utils.GetBooleanSetting("plugin.bandPlan.autoUpdateSettings", true);

        public void Close()
        {
            if (_configGui != null)
            {
                _configGui.SaveEntries();
            }
        }

        public void Initialize(ISharpControl control)
        {
            _controlInterface = control;
        }

        public void LoadGui()
        {
            if (_configGui == null)
            {
                _configGui = new BandPlanPanel(_controlInterface);
            }
        }
    }
}
