using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XmlConverter.xml_formating_with_only_attr
{
    [Serializable]
    [XmlRoot("image_element")]
    public class ImageElement
    {
        [XmlElement("Attribute", typeof(Attribute))]
        public List<Attribute> attributes;

        [XmlElement("color_map", typeof(ColorMap))]
        public ColorMap colorMap;
        public ImageElement()
        {
            attributes = new List<Attribute>();
        }

        public ImageElement(
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
            attributes = new List<Attribute>();
            attributes.Add(new Attribute(imageOrientation.ToString(), "image_orientation"));
            attributes.Add(new Attribute(imagePseudocolor.ToString(), "image_pseudo_color"));
            attributes.Add(new Attribute(imageDrawingsVisible.ToString(), "image_drawings_visible"));
            attributes.Add(new Attribute(imageRoisVisible.ToString(), "image_rois_visible"));
            attributes.Add(new Attribute(imagePseudocolorPhase.ToString(), "image_pseudocolor_phase"));
            attributes.Add(new Attribute(imageMarkersVisible.ToString(), "image_markers_visible"));
            attributes.Add(new Attribute(imageMeasurementsVisible.ToString(), "image_measurements_visible"));
            attributes.Add(new Attribute(imageImplantsVisible.ToString(), "image_implants_visible"));
            attributes.Add(new Attribute(imagePseudocolorWindowWidth.ToString(), "image_pseudocolor_window_width"));
            attributes.Add(new Attribute(imagePseudocolorWindowOffset.ToString(), "image_pseudocolor_window_offset"));
            attributes.Add(new Attribute(imageTransparentPseudocolors.ToString(), "image_transparent_pseudocolors"));
            colorMap = new ColorMap(
                colorMapType,
                colorMapName,
                colorMapId,
                colorMapRedChannel,
                colorMapGreenChannel,
                colorMapBlueChannel
            );
        }
    }
}