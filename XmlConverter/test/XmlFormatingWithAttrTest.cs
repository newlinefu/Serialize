using System;
using System.Xml;
using NUnit.Framework;
using XmlConverter.xml_formating_with_only_attr;

namespace XmlConverter.test
{
    [TestFixture]
    public class XmlFormatingWithAttrTest
    {
        [Test]
        public void SerDesTest()
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
            
        }
        
    }
}