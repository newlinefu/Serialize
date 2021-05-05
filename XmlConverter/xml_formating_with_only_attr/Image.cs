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
            this.GeneralImageInfo = new GeneralImageInfo(
                title,
                modality,
                source,
                timeOfImage
            );
            this.ImageElement = new ImageProcessing(
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
        
        [XmlElement(typeof(GeneralImageInfo))]
        public GeneralImageInfo GeneralImageInfo;
        
        [XmlElement(typeof(ImageProcessing))]
        public ImageProcessing ImageElement;
    }
}