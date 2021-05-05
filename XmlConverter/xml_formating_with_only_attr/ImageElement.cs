using System;
using System.Collections.Generic;
using System.Linq;
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
        
        [XmlIgnore]
        public string this[string fieldName]
        {
            get => attributes.Where(a => a.Name == fieldName).FirstOrDefault()?.Value;
            set
            {
                Attribute target = attributes.Where(a => a.Name == fieldName).FirstOrDefault();
                if (target == null)
                    return;

                target.Value = value;
            }
        }
        
        [XmlIgnore]
        public int ImageOrientation
        {
            get => int.Parse(this["image_orientation"]);
            set
            {
                this["image_orientation"] = value.ToString();
            }
        }
        
        [XmlIgnore]
        public int ImageRoisVisible
        {
            get => int.Parse(this["image_rois_visible"]);
            set
            {
                this["image_rois_visible"] = value.ToString();
            }
        }
        
        [XmlIgnore]
        public int ImageDrawingsVisible
        {
            get => int.Parse(this["image_orientation"]);
            set
            {
                this["image_orientation"] = value.ToString();
            }
        }
        
        [XmlIgnore]
        public int ImagePseudoColor
        {
            get => int.Parse(this["image_pseudo_color"]);
            set
            {
                this["image_pseudo_color"] = value.ToString();
            }
        }
        
        [XmlIgnore]
        public int ImagePseudocolorPhase
        {
            get => int.Parse(this["image_pseudocolor_phase"]);
            set
            {
                this["image_pseudocolor_phase"] = value.ToString();
            }
        }
        
        [XmlIgnore]
        public int ImageMarkersVisible
        {
            get => int.Parse(this["image_markers_visible"]);
            set
            {
                this["image_markers_visible"] = value.ToString();
            }
        }
        
        [XmlIgnore]
        public int ImageMeasurementsVisible
        {
            get => int.Parse(this["image_measurements_visible"]);
            set
            {
                this["image_measurements_visible"] = value.ToString();
            }
        }
        
        [XmlIgnore]
        public int ImageImplantsVisible
        {
            get => int.Parse(this["image_implants_visible"]);
            set
            {
                this["image_implants_visible"] = value.ToString();
            }
        }
        
        [XmlIgnore]
        public int ImagePseudocolorWindowWidth
        {
            get => int.Parse(this["image_pseudocolor_window_width"]);
            set
            {
                this["image_pseudocolor_window_width"] = value.ToString();
            }
        }
        
        [XmlIgnore]
        public int ImagePseudocolorWindowOffset
        {
            get => int.Parse(this["image_pseudocolor_window_offset"]);
            set
            {
                this["image_pseudocolor_window_offset"] = value.ToString();
            }
        }
        
        [XmlIgnore]
        public int ImageTransparentPseudocolors
        {
            get => int.Parse(this["image_transparent_pseudocolors"]);
            set
            {
                this["image_transparent_pseudocolors"] = value.ToString();
            }
        }
        
        public static bool operator ==(ImageElement ie1, ImageElement ie2)
        {
            if (object.Equals(ie1, ie2))
            {
                return true;
            }

            if (object.Equals(ie1, null) || object.Equals(ie2, null))
            {
                return false;
            }

            return ie1.ImageOrientation == ie2.ImageOrientation &&
                   ie1.ImageDrawingsVisible == ie2.ImageDrawingsVisible &&
                   ie1.ImageImplantsVisible == ie2.ImageImplantsVisible &&
                   ie1.ImageMarkersVisible == ie2.ImageMarkersVisible &&
                   ie1.ImageMeasurementsVisible == ie2.ImageMeasurementsVisible &&
                   ie1.ImagePseudoColor == ie2.ImagePseudoColor &&
                   ie1.ImagePseudocolorPhase == ie2.ImagePseudocolorPhase &&
                   ie1.ImageRoisVisible == ie2.ImageRoisVisible &&
                   ie1.ImageTransparentPseudocolors == ie2.ImageTransparentPseudocolors &&
                   ie1.ImagePseudocolorWindowOffset == ie2.ImagePseudocolorWindowOffset &&
                   ie1.ImagePseudocolorWindowWidth == ie2.ImagePseudocolorWindowWidth &&
                   ie1.colorMap == ie2.colorMap;
        }
        
        public static bool operator !=(ImageElement ie1, ImageElement ie2)
        {
            if (object.Equals(ie1, ie2))
            {
                return false;
            }

            if (object.Equals(ie1, null) || object.Equals(ie2, null))
            {
                return true;
            }
            
            return !(ie1.ImageOrientation == ie2.ImageOrientation &&
                    ie1.ImageDrawingsVisible == ie2.ImageDrawingsVisible &&
                    ie1.ImageImplantsVisible == ie2.ImageImplantsVisible &&
                    ie1.ImageMarkersVisible == ie2.ImageMarkersVisible &&
                    ie1.ImageMeasurementsVisible == ie2.ImageMeasurementsVisible &&
                    ie1.ImagePseudoColor == ie2.ImagePseudoColor &&
                    ie1.ImagePseudocolorPhase == ie2.ImagePseudocolorPhase &&
                    ie1.ImageRoisVisible == ie2.ImageRoisVisible &&
                    ie1.ImageTransparentPseudocolors == ie2.ImageTransparentPseudocolors &&
                    ie1.ImagePseudocolorWindowOffset == ie2.ImagePseudocolorWindowOffset &&
                    ie1.ImagePseudocolorWindowWidth == ie2.ImagePseudocolorWindowWidth &&
                    ie1.colorMap == ie2.colorMap);
        }
    }
}