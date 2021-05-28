using SDRSharp.Radio;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Serialization;

namespace SDRSharp.Plugin.BandPlan
{
    public class RangeEntry
    {
        private List<RangeEntry> _subRanges = new List<RangeEntry>();

        public RangeEntry()
        {
        }

        public RangeEntry(long minFrequency, long maxFrequency)
        {
            MinFrequency = minFrequency;
            MaxFrequency = maxFrequency;
        }

        [XmlAttribute("minFrequency")]
        public long MinFrequency { get; set; }

        [XmlAttribute("maxFrequency")]
        public long MaxFrequency { get; set; }

        [XmlIgnore]
        public Color Color { get; set; }

        [XmlAttribute("color")]
        public string ColorCode
        {
            get
            {
                return Utils.ColorToString(Color);
            }
            set
            {
                Color = Utils.StringToColor(value, 0x90);
            }
        }

        [XmlAttribute("mode")]
        public DetectorType DetectorType { get; set; }


        [XmlAttribute("step")]
        public int StepSize { get; set; }

        [XmlText]
        public string Description { get; set; }

        [XmlIgnore]
        public List<RangeEntry> SubRanges { get { return _subRanges; } }

        [XmlIgnore]
        public RangeEntry Parent { get; set; }

        public static bool operator >(RangeEntry a, RangeEntry b)
        {
            return a.MinFrequency < b.MinFrequency && a.MaxFrequency > b.MaxFrequency;
        }

        public static bool operator <(RangeEntry a, RangeEntry b)
        {
            return a.MinFrequency > b.MinFrequency && a.MaxFrequency < b.MaxFrequency;
        }

        public static bool operator >=(RangeEntry a, RangeEntry b)
        {
            return a.MinFrequency <= b.MinFrequency && a.MaxFrequency >= b.MaxFrequency;
        }

        public static bool operator <=(RangeEntry a, RangeEntry b)
        {
            return a.MinFrequency >= b.MinFrequency && a.MaxFrequency <= b.MaxFrequency;
        }

        public static bool operator ==(RangeEntry a, RangeEntry b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }
            return a.MinFrequency == b.MinFrequency && a.MaxFrequency == b.MaxFrequency;
        }

        public static bool operator !=(RangeEntry a, RangeEntry b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            var other = obj as RangeEntry;
            if (other == null)
            {
                return false;
            }
            return MinFrequency == other.MinFrequency && MaxFrequency == other.MaxFrequency;
        }

        public override int GetHashCode()
        {
            return MinFrequency.GetHashCode() ^ (MaxFrequency.GetHashCode() * 31);
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", MinFrequency, MaxFrequency);
        }
    }
}
