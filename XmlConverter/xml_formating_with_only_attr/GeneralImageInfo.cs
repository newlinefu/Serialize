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
            attributes.Add(new Attribute(dt.ToString("yyyy-MM-dd"), "date_of_image", "exposure"));
            attributes.Add(new Attribute(dt.ToString(@"HH\:mm\:ss"), "time_of_image", "exposure"));
        }

        public string this[string fieldName]
        {
            get => attributes.Where(a => a.Name == fieldName).FirstOrDefault()?.Value;
            set
            {
                Attribute target = attributes.Where(a => a.Name == fieldName).FirstOrDefault();
                if (target == null)
                    return;

                target.Value = value;
            }
        }

        [XmlIgnore]
        public string Title
        {
            get => this["title"];
            set
            {
                this["title"] = value;
            }
        }
        
        [XmlIgnore]
        public string Source
        {
            get => this["source"];
            set
            {
                this["source"] = value;
            }
        }
        
        [XmlIgnore]
        public string Modality
        {
            get => this["modality"];
            set
            {
                this["modality"] = value;
            }
        }
        
        [XmlIgnore]
        public DateTime TimeOfImage
        {
            get
            {
                return DateTime.Parse(this["date_of_image"]) + TimeSpan.Parse(this["time_of_image"]);
            }
            set
            {
                this["date_of_image"] = value.ToString("yyyy-MM-dd");
                this["time_of_image"] = value.ToString(@"HH\:mm\:ss");
            }
        }

        public static bool operator ==(GeneralImageInfo gi1, GeneralImageInfo gi2)
        {
            if (object.Equals(gi1, gi2))
            {
                return true;
            }

            if (object.Equals(gi1, null) || object.Equals(gi2, null))
            {
                return false;
            }

            return gi1.Title == gi2.Title &&
                   gi1.Modality == gi2.Modality &&
                   gi1.TimeOfImage == gi2.TimeOfImage &&
                   gi1.Source == gi2.Source;
        }
        
        public static bool operator !=(GeneralImageInfo gi1, GeneralImageInfo gi2)
        {
            if (object.Equals(gi1, gi2))
            {
                return false;
            }

            if (object.Equals(gi1, null) || object.Equals(gi2, null))
            {
                return true;
            }
            
            return !(gi1.Title == gi2.Title &&
                    gi1.Modality == gi2.Modality &&
                    gi1.TimeOfImage == gi2.TimeOfImage &&
                    gi1.Source == gi2.Source);
        }
    }
}