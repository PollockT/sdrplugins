using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SDRSharp.Plugin.BandPlan
{
    public class SettingsPersister
    {
        private const string BandPlanFilename = "BandPlan.xml";

        private readonly string _settingsFolder;

        public SettingsPersister()
        {
            //_settingsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SDRSharp");
            _settingsFolder = Path.GetDirectoryName(Application.ExecutablePath);
        }

        private static List<RangeEntry> NestEntries(List<RangeEntry> flatList)
        {
            var result = new List<RangeEntry>();

            foreach (var e1 in flatList)
            {
                foreach (var e2 in flatList)
                {
                    if (e1 != e2 && e1 >= e2)
                    {
                        var foundIntermediate = false;
                        foreach (var e3 in flatList)
                        {
                            if (e1 >= e3 && e3 >= e2 && e3 != e1 && e3 != e2)
                            {
                                foundIntermediate = true;
                            }
                        }

                        if (!foundIntermediate)
                        {
                            e1.SubRanges.Add(e2);
                            e2.Parent = e1;
                        }
                    }
                }
            }

            foreach (var e in flatList)
            {
                if (e.Parent == null)
                {
                    result.Add(e);
                }
            }

            return result;
        }

        public List<RangeEntry> ReadStoredFrequencies()
        {
            var result = new List<RangeEntry>();
            var flatList = ReadObject<List<RangeEntry>>(BandPlanFilename);
            if (flatList != null)
            {
                return NestEntries(flatList);
            }
            return new List<RangeEntry>();
        }

        public void PersistStoredFrequencies(List<RangeEntry> entries)
        {
            WriteObject(entries, BandPlanFilename);
        }

        private T ReadObject<T>(string fileName)
        {
            var filePath = Path.Combine(_settingsFolder, fileName);
            if (File.Exists(filePath))
            {
                using (var fileStream = new FileStream(filePath, FileMode.Open))
                {
                    var ser = new XmlSerializer(typeof(T));
                    return (T)ser.Deserialize(fileStream);
                }
            }
            return default(T);
        }

        private void WriteObject<T>(T obj, string fileName)
        {
            var filePath = Path.Combine(_settingsFolder, fileName);
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                var ser = new XmlSerializer(obj.GetType());
                ser.Serialize(fileStream, obj);
            }
        }
    }
}
