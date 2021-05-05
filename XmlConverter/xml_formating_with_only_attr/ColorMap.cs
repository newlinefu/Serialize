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

        [XmlElement("RedChannel")]
        public string RedChannelStr
        {
            get => _redChannelStr;
            set
            {
                _redChannelStr = value;
            }
        }

        [XmlElement("GreenChannel")]
        public string GreenChannelStr
        {
            get => _greenChannelStr;
            set
            {
                _greenChannelStr = value;
            }
        }

        [XmlElement("BlueChannel")]
        public string BlueChannelStr
        {
            get => _blueChannelStr;
            set
            {
                _blueChannelStr = value;
            }
        }
        
        [XmlElement("type")] 
        public string Type
        {
            get => _type;
            set => _type = value;
        }
        
        [XmlElement("name")] 
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        [XmlElement("id")] 
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

        public static bool operator ==(ColorMap cm1, ColorMap cm2)
        {
            if (object.Equals(cm1, cm2))
            {
                return true;
            }

            if (object.Equals(cm1, null) || object.Equals(cm2, null))
            {
                return false;
            }
            
            bool channelsEq = true;
            if (cm1.RedChannel.Length != cm2.RedChannel.Length ||
                cm1.GreenChannel.Length != cm2.GreenChannel.Length ||
                cm1.BlueChannel.Length != cm2.BlueChannel.Length)
            {
                return false;
            }

            for (int i = 0; i < cm1.RedChannel.Length; i++)
            {
                channelsEq &= cm1.RedChannel[i] == cm2.RedChannel[i];
            }
            for (int i = 0; i < cm1.BlueChannel.Length; i++)
            {
                channelsEq &= cm1.BlueChannel[i] == cm2.BlueChannel[i];
            }
            for (int i = 0; i < cm1.GreenChannel.Length; i++)
            {
                channelsEq &= cm1.GreenChannel[i] == cm2.GreenChannel[i];
            }

            return cm1.Id == cm2.Id &&
                   cm1.Name == cm2.Name &&
                   cm1.Type == cm2.Type &&
                   channelsEq;
        }
        
        public static bool operator !=(ColorMap cm1, ColorMap cm2)
        {
            if (object.Equals(cm1, cm2))
            {
                return false;
            }

            if (object.Equals(cm1, null) || object.Equals(cm2, null))
            {
                return true;
            }

            bool channelsEq = true;
            if (cm1.RedChannel.Length != cm2.RedChannel.Length ||
                cm1.GreenChannel.Length != cm2.GreenChannel.Length ||
                cm1.BlueChannel.Length != cm2.BlueChannel.Length)
            {
                return true;
            }

            for (int i = 0; i < cm1.RedChannel.Length; i++)
            {
                channelsEq &= cm1.RedChannel[i] == cm2.RedChannel[i];
            }
            for (int i = 0; i < cm1.BlueChannel.Length; i++)
            {
                channelsEq &= cm1.BlueChannel[i] == cm2.BlueChannel[i];
            }
            for (int i = 0; i < cm1.GreenChannel.Length; i++)
            {
                channelsEq &= cm1.GreenChannel[i] == cm2.GreenChannel[i];
            }

            return !(cm1.Id == cm2.Id &&
                     cm1.Name == cm2.Name &&
                     cm1.Type == cm2.Type &&
                     channelsEq);
        }
    }
}