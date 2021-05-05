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

        [XmlAttribute("name")]
        public string Name
        {
            get => _name;
            set { _name = value; }
        }

        [XmlAttribute("type")]
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
        
        public static bool operator==(Attribute attr1, Attribute attr2)
        {
            if (object.Equals(attr1, attr2))
            {
                return true;
            }

            if (object.Equals(attr1, null) || object.Equals(attr2, null))
            {
                return false;
            }

            return attr1._name == attr2._name &&
                   attr1._type == attr2._type &&
                   attr1._value == attr2._value;
        }
        
        public static bool operator!=(Attribute attr1, Attribute attr2)
        {
            if (object.Equals(attr1, attr2))
            {
                return false;
            }

            if (object.Equals(attr1, null) || object.Equals(attr2, null))
            {
                return true;
            }
            
            return !(attr1._name == attr2._name &&
                    attr1._type == attr2._type &&
                    attr1._value == attr2._value);
        }
    }
}