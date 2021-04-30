using System;
using System.Text;
using System.Xml.Serialization;

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
        private Byte[] _redChannel;
        private Byte[] _greenChannel;
        private Byte[] _blueChannel;

        private string _redChannelStr;
        private string _greenChannelStr;
        private string _blueChannelStr;

        [XmlElement("RedChannel")]
        public string RedChannelStr
        {
            get => _redChannelStr;
            set
            {
                byte[] newRCh = new byte[value.Length / 4];
                for (int i = 0; i < value.Length - 4; i += 4)
                {
                    newRCh[i / 4] = Convert.ToByte(value.Substring(i, 4), 16);
                }

                _redChannel = newRCh;
            }
        }

        [XmlElement("GreenChannel")]
        public string GreenChannelStr
        {
            get => _greenChannelStr;
            set
            {
                byte[] newGCh = new byte[value.Length / 4];
                for (int i = 0; i < value.Length - 4; i += 4)
                {
                    newGCh[i / 4] = Convert.ToByte(value.Substring(i, 4), 16);
                }

                _greenChannel = newGCh;
            }
        }

        [XmlElement("BlueChannel")]
        public string BlueChannelStr
        {
            get => _blueChannelStr;
            set
            {
                byte[] newBCh = new byte[value.Length / 4];
                for (int i = 0; i < value.Length - 4; i += 4)
                {
                    newBCh[i / 4] = Convert.ToByte(value.Substring(i, 4), 16);
                }

                _blueChannel = newBCh;
            }
        }
        
        [XmlElement("colormap_type")] 
        public string Type
        {
            get => _type;
            set => _type = value;
        }
        [XmlElement("colormap_name")] 
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        [XmlElement("colormap_ID")] 
        public string Id
        {
            get => _ID;
            set => _ID = value;
        }

        [XmlIgnore]
        public byte[] RedChannel
        {
            get => _redChannel;
            set
            {
                _redChannel = value;
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < value.Length; i++)
                {
                    sb.Append(value[i].ToString("X4"));
                }

                _redChannelStr = sb.ToString();
            }
        }

        [XmlIgnore]
        public byte[] GreenChannel
        {
            get => _greenChannel;
            set
            {
                _greenChannel = value;
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < value.Length; i++)
                {
                    sb.Append(value[i].ToString("X4"));
                }

                _greenChannelStr = sb.ToString();
            }
        }

        [XmlIgnore]
        public byte[] BlueChannel
        {
            get => _blueChannel;
            set
            {
                _blueChannel = value;
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < value.Length; i++)
                {
                    sb.Append(value[i].ToString("X4"));
                }
                _blueChannelStr = sb.ToString();
            }
        }
    }
}