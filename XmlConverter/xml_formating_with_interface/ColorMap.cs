using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using XmlConverter.utils;

namespace XmlConverter.xml_formating_with_interface
{
    public class ColorMap : IXmlSerializable
    {
        public ColorMap()
        {}

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

        public string Type
        {
            get => _type;
            set => _type = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Id
        {
            get => _ID;
            set => _ID = value;
        }

        public byte[] RedChannel
        {
            get => _redChannel;
            set => _redChannel = value;
        }

        public byte[] GreenChannel
        {
            get => _greenChannel;
            set => _greenChannel = value;
        }

        public byte[] BlueChannel
        {
            get => _blueChannel;
            set => _blueChannel = value;
        }


        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "type")
                {
                    _type = reader.ReadString();
                }

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "name")
                {
                    _name = reader.ReadString();
                }
                
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "id")
                {
                    _ID = reader.ReadString();
                }
                
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "RedChannel")
                {
                    _redChannel = reader.ReadString().ToByteArrayExt();
                }
                
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "GreenChannel")
                {
                    _greenChannel = reader.ReadString().ToByteArrayExt();
                }
                
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "BlueChannel")
                {
                    _blueChannel = reader.ReadString().ToByteArrayExt();
                }
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("type", _type);
            writer.WriteElementString("name", _name);
            writer.WriteElementString("id", _ID);
            writer.WriteElementString("RedChannel", _redChannel.ToHexString());
            writer.WriteElementString("GreenChannel", _greenChannel.ToHexString());
            writer.WriteElementString("BlueChannel", _blueChannel.ToHexString());
        }
        
        public static bool operator ==(ColorMap c1, ColorMap c2)
        {
            if (object.Equals(c1, c2))
            {
                return true;
            }

            if (object.Equals(c1, null) || object.Equals(c2, null))
            {
                return false;
            }
            bool channelsEq = true;
            if (c1.RedChannel.Length != c2.RedChannel.Length ||
                c1.GreenChannel.Length != c2.GreenChannel.Length ||
                c1.BlueChannel.Length != c2.BlueChannel.Length)
            {
                return false;
            }

            for (int i = 0; i < c1.RedChannel.Length; i++)
            {
                channelsEq &= c1.RedChannel[i] == c2.RedChannel[i];
            }
            for (int i = 0; i < c1.BlueChannel.Length; i++)
            {
                channelsEq &= c1.BlueChannel[i] == c2.BlueChannel[i];
            }
            for (int i = 0; i < c1.GreenChannel.Length; i++)
            {
                channelsEq &= c1.GreenChannel[i] == c2.GreenChannel[i];
            }

            return c1.Id == c2.Id &&
                   c1.Name == c2.Name &&
                   c1.Type == c2.Type &&
                   channelsEq;
        }
        
        public static bool operator !=(ColorMap c1, ColorMap c2)
        {
            if (object.Equals(c1, c2))
            {
                return false;
            }

            if (object.Equals(c1, null) || object.Equals(c2, null))
            {
                return true;
            }

            bool channelsEq = true;
            if (c1.RedChannel.Length != c2.RedChannel.Length ||
                c1.GreenChannel.Length != c2.GreenChannel.Length ||
                c1.BlueChannel.Length != c2.BlueChannel.Length)
            {
                return true;
            }

            for (int i = 0; i < c1.RedChannel.Length; i++)
            {
                channelsEq &= c1.RedChannel[i] == c2.RedChannel[i];
            }
            for (int i = 0; i < c1.BlueChannel.Length; i++)
            {
                channelsEq &= c1.BlueChannel[i] == c2.BlueChannel[i];
            }
            for (int i = 0; i < c1.GreenChannel.Length; i++)
            {
                channelsEq &= c1.GreenChannel[i] == c2.GreenChannel[i];
            }

            return !(c1.Id == c2.Id &&
                    c1.Name == c2.Name &&
                    c1.Type == c2.Type &&
                    channelsEq);
        }
    }
}