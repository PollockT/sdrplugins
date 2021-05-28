using SDRSharp.Common;
using SDRSharp.Radio;
using System.Windows.Forms;

namespace SDRSharp.Plugin.NoiseBlanker
{
    public class BBNoiseBlankerPlugin : ISharpPlugin, ICanLazyLoadGui, ISupportStatus
    {
        private const string _displayName = "BB Noise Blanker";
        private ISharpControl _control;
        private NoiseBlankerProcessor _processor;

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

            _processor = new NoiseBlankerProcessor();
            _processor.Enabled = Utils.GetBooleanSetting("plugin.nb.bb.enabled");
            _processor.NoiseThreshold = Utils.GetDoubleSetting("plugin.nb.bb.threshold", 5);
            _processor.PulseWidth = Utils.GetDoubleSetting("plugin.nb.bb.pulseWidth", 10);
            _processor.LookupWindow = Utils.GetDoubleSetting("plugin.nb.bb.lookupWindow", 20);

            _control.RegisterStreamHook(_processor, ProcessorType.RawIQ);
            _control.RegisterStreamHook(_processor, ProcessorType.RawReal);
        }

        public void Close()
        {
            Utils.SaveSetting("plugin.nb.bb.enabled", _processor.Enabled);
            Utils.SaveSetting("plugin.nb.bb.threshold", _processor.NoiseThreshold);
            Utils.SaveSetting("plugin.nb.bb.pulseWidth", _processor.PulseWidth);
            Utils.SaveSetting("plugin.nb.bb.lookupWindow", _processor.LookupWindow);
        }

        public void LoadGui()
        {
            if (_configGui == null)
            {
                _configGui = new ProcessorPanel(_processor);
            }
        }
    }
    public class IFNoiseBlankerPlugin : ISharpPlugin, ICanLazyLoadGui, ISupportStatus
    {
        private const string _displayName = "IF Noise Blanker";
        private ISharpControl _control;
        private NoiseBlankerProcessor _processor;

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

            _processor = new NoiseBlankerProcessor();
            _processor.Enabled = Utils.GetBooleanSetting("plugin.nb.if.enabled");
            _processor.NoiseThreshold = Utils.GetDoubleSetting("plugin.nb.if.threshold", 5);
            _processor.PulseWidth = Utils.GetDoubleSetting("plugin.nb.if.pulseWidth", 30);
            _processor.LookupWindow = Utils.GetDoubleSetting("plugin.nb.if.lookupWindow", 50);

            _control.RegisterStreamHook(_processor, ProcessorType.DecimatedAndFilteredIQ);
        }

        public void Close()
        {
            Utils.SaveSetting("plugin.nb.if.enabled", _processor.Enabled);
            Utils.SaveSetting("plugin.nb.if.threshold", _processor.NoiseThreshold);
            Utils.SaveSetting("plugin.nb.if.pulseWidth", _processor.PulseWidth);
            Utils.SaveSetting("plugin.nb.if.lookupWindow", _processor.LookupWindow);
        }

        public void LoadGui()
        {
            if (_configGui == null)
            {
                _configGui = new ProcessorPanel(_processor);
            }
        }
    }

    public class AFNoiseBlankerPlugin : ISharpPlugin, ICanLazyLoadGui, ISupportStatus
    {
        private const string _displayName = "AF Noise Blanker";
        private ISharpControl _control;
        private NoiseBlankerProcessor _processor;

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

            _processor = new NoiseBlankerProcessor();
            _processor.Enabled = Utils.GetBooleanSetting("plugin.nb.af.enabled");
            _processor.NoiseThreshold = Utils.GetDoubleSetting("plugin.nb.af.threshold", 5);
            _processor.PulseWidth = Utils.GetDoubleSetting("plugin.nb.af.pulseWidth", 50);
            _processor.LookupWindow = Utils.GetDoubleSetting("plugin.nb.af.lookupWindow", 30);

            _control.RegisterStreamHook(_processor, ProcessorType.DemodulatorOutput);
        }

        public void Close()
        {
            Utils.SaveSetting("plugin.nb.af.enabled", _processor.Enabled);
            Utils.SaveSetting("plugin.nb.af.threshold", _processor.NoiseThreshold);
            Utils.SaveSetting("plugin.nb.af.pulseWidth", _processor.PulseWidth);
            Utils.SaveSetting("plugin.nb.af.lookupWindow", _processor.LookupWindow);
        }

        public void LoadGui()
        {
            if (_configGui == null)
            {
                _configGui = new ProcessorPanel(_processor);
            }
        }
    }
}
