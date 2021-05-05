using System;
using System.Xml.Serialization;

namespace XmlConverter.xml_formating_with_only_attr
{
    [Serializable]
    [XmlRoot]
    public class ImageProcessing
    {
        public ImageProcessing(
            int imageTransparentPseudocolors,
            int imagePseudocolorPhase,
            int imagePseudocolorWindowOffset,
            int imagePseudocolorWindowWidth,
            int imagePseudocolor,
            int imageDrawingsVisible,
            int imageMeasurementsVisible,
            int imageImplantsVisible,
            int imageMarkersVisible,
            int imageRoisVisible,
            int imageOrientation,
            string colorMapType,
            string colorMapName,
            string colorMapId,
            Byte[] colorMapRedChannel,
            Byte[] colorMapGreenChannel,
            Byte[] colorMapBlueChannel
        )
        {
            this.imageElement = new ImageElement(
                imageTransparentPseudocolors,
                imagePseudocolorPhase,
                imagePseudocolorWindowOffset,
                imagePseudocolorWindowWidth,
                imagePseudocolor,
                imageDrawingsVisible,
                imageMeasurementsVisible,
                imageImplantsVisible,
                imageMarkersVisible,
                imageRoisVisible,
                imageOrientation,
                colorMapType,
                colorMapName,
                colorMapId,
                colorMapRedChannel,
                colorMapGreenChannel,
                colorMapBlueChannel
            );
        }

        public ImageProcessing()
        {
            imageElement = new ImageElement();
        }
        
        [XmlElement("image_element", typeof(ImageElement))]
        public ImageElement imageElement;

        public static bool operator ==(ImageProcessing ip1, ImageProcessing ip2)
        {
            if (object.Equals(ip1, ip2))
            {
                return true;
            }

            if (object.Equals(ip1, null) || object.Equals(ip2, null))
            {
                return false;
            }

            return ip1.imageElement == ip2.imageElement;
        }
        
        public static bool operator !=(ImageProcessing ip1, ImageProcessing ip2)
        {
            if (object.Equals(ip1, ip2))
            {
                return false;
            }

            if (object.Equals(ip1, null) || object.Equals(ip2, null))
            {
                return true;
            }
            
            return ip1.imageElement != ip2.imageElement;
        }


    }
}