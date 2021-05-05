using System;
using System.IO;
using System.Xml.Serialization;
using NUnit.Framework;
using XmlConverter.xml_formating_with_only_attr;

namespace XmlConverter.test
{
    [TestFixture]
    public class XmlFormatingWithAttrTest
    {
        [Test]
        public void SerDesTestWithAttributes()
        {
            Image primaryImage = new Image(
                "test_title",
                "test_source",
                new DateTime(2000, 01, 01, 23, 23, 1), 
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
            
            
            var xmlSer = new XmlSerializer(primaryImage.GetType());

            using (Stream s = File.Create("int_xml_2.xml"))
            {
                xmlSer.Serialize(s, primaryImage);
            }

            Image resultedImage;
            using (Stream s = File.OpenRead("int_xml_2.xml"))
            {
                resultedImage = (Image) xmlSer.Deserialize(s);
            }
            
            Assert.IsTrue(primaryImage == resultedImage);
            Assert.IsFalse(primaryImage != resultedImage);
        }
        
    }
}