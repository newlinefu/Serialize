using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace XmlConverter.xml_formating_with_only_attr
{
    [Serializable]
    [XmlRoot("general")]
    public class GeneralImageInfo
    {
        [XmlElement("Attribute", typeof(Attribute))]
        public List<Attribute> attributes;
            
        public GeneralImageInfo()
        {
            attributes = new List<Attribute>();
        }

        public GeneralImageInfo(string title, string modality, string source, DateTime dt)
        {
            attributes = new List<Attribute>();
            attributes.Add(new Attribute(title, "title"));
            attributes.Add(new Attribute(modality, "modality"));
            attributes.Add(new Attribute(source, "source"));
            attributes.Add(new Attribute(dt.ToString("yyyy-MM-dd"), "date_of_image"));
            attributes.Add(new Attribute(dt.ToString(@"HH\:mm\:ss"), "time_of_image"));
        }

        public string this[string fieldName]
        {
            get => attributes.Where(a => a.Name == fieldName).FirstOrDefault()?.Value;
        }
    }
}