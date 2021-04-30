using System;
using System.Runtime.Serialization;

namespace XmlConverter.entity
{
    [DataContract(Name = "ColorMap")]
    [Serializable]
    public struct ColorMap
    {

        public ColorMap(
            string type,
            string name,
            string ID,
            Byte[] redChannel,
            Byte[] greenChannel,
            Byte[] blueChannel
        )
        {
            this.type = type;
            this.name = name;
            this.ID = ID;
            this.greenChannel = greenChannel;
            this.blueChannel = blueChannel;
            this.redChannel = redChannel;
        }
        [DataMember(Name = "colormap_type")] public string type;

        [DataMember(Name = "colormap_name")] public string name;

        [DataMember(Name = "colormap_ID")] public string ID;

        [DataMember(Name = "RedChannel")] public Byte[] redChannel;

        [DataMember(Name = "GreenChannel")] public Byte[] greenChannel;

        [DataMember(Name = "BlueChannel")] public Byte[] blueChannel;
    }
}