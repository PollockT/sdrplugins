using SDRSharp.Common;
using SDRSharp.Radio;
using System.Windows.Forms;

namespace SDRSharp.Plugin.ZoomFFT
{
    public class ZoomFFTPlugin : ISharpPlugin, ICanLazyLoadGui, ISupportStatus
    {
        private const string _displayName = "Zoom FFT";

        private IFProcessor _ifProcessor;
        private MPXProcessor _mpxProcessor;
        private AFProcessor _afProcessor;
        private ZoomPanel _configGui;

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
            _ifProcessor = new IFProcessor(control);
            _ifProcessor.EnableFilter = Utils.GetBooleanSetting("plugin.zoomFFT.filter");
            _ifProcessor.Enabled = Utils.GetBooleanSetting("plugin.zoomFFT.if");

            _mpxProcessor = new MPXProcessor(control);
            _mpxProcessor.Enabled = Utils.GetBooleanSetting("plugin.zoomFFT.mpx");

            _afProcessor = new AFProcessor(control);
            _afProcessor.Enabled = Utils.GetBooleanSetting("plugin.zoomFFT.audio");
        }

        public void Close()
        {
            _ifProcessor.Stop();
            _mpxProcessor.Stop();
            _afProcessor.Stop();
            Utils.SaveSetting("plugin.zoomFFT.filter", _ifProcessor.EnableFilter);
            Utils.SaveSetting("plugin.zoomFFT.if", _ifProcessor.Enabled);
            Utils.SaveSetting("plugin.zoomFFT.mpx", _mpxProcessor.Enabled);
            Utils.SaveSetting("plugin.zoomFFT.audio", _afProcessor.Enabled);
        }

        public void LoadGui()
        {
            if (_configGui == null)
            {
                _configGui = new ZoomPanel(_ifProcessor, _mpxProcessor, _afProcessor);
            }
        }
    }
}
