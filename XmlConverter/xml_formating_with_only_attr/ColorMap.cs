using System;
using System.Text;
using System.Xml.Serialization;
using XmlConverter.utils;

namespace XmlConverter.xml_formating_with_only_attr
{
    [Serializable]
    [XmlRoot]
    public class ColorMap
    {
        public ColorMap()
        {
        }

        public ColorMap(
            string type,
            string name,
            string ID,
            Byte[] redChannel,
            Byte[] greenChannel,
            Byte[] blueChannel
        )
        {
            Type = type;
            Name = name;
            Id = ID;
            GreenChannel = greenChannel;
            BlueChannel = blueChannel;
            RedChannel = redChannel;
        }
        
        
        private string _type;
        private string _name;
        private string _ID;

        private string _redChannelStr;
        private string _greenChannelStr;
        private string _blueChannelStr;

        [XmlElement("RedChannel", typeof(string))]
        public string RedChannelStr
        {
            get => _redChannelStr;
            set
            {
                _redChannelStr = value;
            }
        }

        [XmlElement("GreenChannel", typeof(string))]
        public string GreenChannelStr
        {
            get => _greenChannelStr;
            set
            {
                _greenChannelStr = value;
            }
        }

        [XmlElement("BlueChannel", typeof(string))]
        public string BlueChannelStr
        {
            get => _blueChannelStr;
            set
            {
                _blueChannelStr = value;
            }
        }
        
        [XmlElement("colormap_type", typeof(string))] 
        public string Type
        {
            get => _type;
            set => _type = value;
        }
        
        [XmlElement("colormap_name", typeof(string))] 
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        [XmlElement("colormap_ID", typeof(string))] 
        public string Id
        {
            get => _ID;
            set => _ID = value;
        }

        [XmlIgnore]
        public byte[] RedChannel
        {
            get
            {
                return _redChannelStr.ToByteArrayExt();
            }
            set
            {
                _redChannelStr = value.ToHexString();
            }
        }

        [XmlIgnore]
        public byte[] GreenChannel
        {
            get
            {
                return _greenChannelStr.ToByteArrayExt();
            }
            set
            {
                _greenChannelStr = value.ToHexString();
            }
        }

        [XmlIgnore]
        public byte[] BlueChannel
        {
            get
            {
                return _blueChannelStr.ToByteArrayExt();
            }
            set
            {
                _blueChannelStr = value.ToHexString();
            }
        }
    }
}