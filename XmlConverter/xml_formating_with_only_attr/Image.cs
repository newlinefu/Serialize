using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace XmlConverter.xml_formating_with_only_attr
{
    [Serializable]
    [XmlRoot("image")]
    public class Image
    {

        public Image()
        {
            this.generalImageInfo = new GeneralImageInfo();
            this.imageProcessing = new ImageProcessing();
        }

        public Image(
            string title,
            string source,
            DateTime timeOfImage,
            string modality,
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
            this.generalImageInfo = new GeneralImageInfo(
                title,
                modality,
                source,
                timeOfImage
            );
            this.imageProcessing = new ImageProcessing(
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
        
        [XmlElement("general", typeof(GeneralImageInfo))]
        public GeneralImageInfo generalImageInfo;
        
        [XmlElement("image_processing", typeof(ImageProcessing))]
        public ImageProcessing imageProcessing;

        public static bool operator ==(Image i1, Image i2)
        {
            if (object.Equals(i1, i2))
            {
                return true;
            }

            if (object.Equals(i1, null) || object.Equals(i2, null))
            {
                return false;
            }

            return i1.imageProcessing == i2.imageProcessing &&
                   i1.generalImageInfo == i2.generalImageInfo;
        }
        
        public static bool operator !=(Image i1, Image i2)
        {
            if (object.Equals(i1, i2))
            {
                return false;
            }

            if (object.Equals(i1, null) || object.Equals(i2, null))
            {
                return true;
            }
            
            return !(i1.imageProcessing == i2.imageProcessing &&
                    i1.generalImageInfo == i2.generalImageInfo);
        }
    }
}