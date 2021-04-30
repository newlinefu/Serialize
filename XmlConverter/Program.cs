using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using XmlConverter.entity;
using XmlConverter.xml_formating_with_only_attr;

namespace XmlConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Image t = new Image(
                "test_title",
                "test_source",
                DateTime.Now, 
                "test_modality",
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10,
                11,
                "test_color_map_type",
                "test_color_map_name",
                "test_color_map_id",
                new byte[] {1, 1, 2, 3, 4},
                new byte[] {5, 6, 7, 8, 9},
                new byte[] {10, 11, 12, 13, 14}
            );
            var xmlSer = new XmlSerializer(t.GetType());

            using (Stream s = File.OpenRead("xml_template2.xml"))
            {
                Image newT = (Image) xmlSer.Deserialize(s);
            }
        }
    }
}