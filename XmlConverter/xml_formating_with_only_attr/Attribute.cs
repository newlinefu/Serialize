using System;
using System.Xml.Serialization;

namespace XmlConverter.xml_formating_with_only_attr
{
    [Serializable]
    [XmlRoot]
    public class Attribute
    {
        public Attribute()
        {}

        public Attribute(string value, string name, string type)
        {
            _value = value;
            _name = name;
            _type = type;
        }
        
        public Attribute(string value, string name) : this(value, name, null)
        {}

        [XmlAttribute("name", typeof(string))]
        public string Name
        {
            get => _name;
            set { _name = value; }
        }

        [XmlAttribute("type", typeof(string))]
        public string Type
        {
            get => _type;
            set { _type = value; }
        }
        
        [XmlText]
        public string Value
        {
            get => _value;
            set => _value = value;
        }

        private string _value;
        private string _name;
        private string _type;
        
        public bool ShouldSerializeType()
        {
            return !string.IsNullOrEmpty(Type);
        }
    }
}