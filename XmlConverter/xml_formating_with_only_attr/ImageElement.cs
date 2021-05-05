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
        
        private Dictionary<string, Attribute> _serializedAttributes;

        public ImageElement()
        {
            this._serializedAttributes = new Dictionary<string, Attribute>()
            {
                {"image_transparent_pseudocolors", new Attribute(null, "image_transparent_pseudocolors", null)},
                {"image_pseudocolor_phase", new Attribute(null, "image_pseudocolor_phase", null)},
                {"image_pseudocolor_window_offset", new Attribute(null, "image_pseudocolor_window_offset", null)},
                {"image_pseudocolor_window_width", new Attribute(null, "image_pseudocolor_window_width", null)},
                {"image_pseudo_color", new Attribute(null, "image_pseudo_color", null)},
                {"image_drawings_visible", new Attribute(null, "image_drawings_visible", null)},
                {"image_measurements_visible", new Attribute(null, "image_measurements_visible", null)},
                {"image_implants_visible", new Attribute(null, "image_implants_visible", null)},
                {"image_markers_visible", new Attribute(null, "image_markers_visible", null)},
                {"image_rois_visible", new Attribute(null, "image_rois_visible", null)},
                {"image_orientation", new Attribute(null, "image_orientation", null)},
            };
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
            this._serializedAttributes = new Dictionary<string, Attribute>()
            {
                {"image_transparent_pseudocolors", new Attribute(null, "image_transparent_pseudocolors", null)},
                {"image_pseudocolor_phase", new Attribute(null, "image_pseudocolor_phase", null)},
                {"image_pseudocolor_window_offset", new Attribute(null, "image_pseudocolor_window_offset", null)},
                {"image_pseudocolor_window_width", new Attribute(null, "image_pseudocolor_window_width", null)},
                {"image_pseudo_color", new Attribute(null, "image_pseudo_color", null)},
                {"image_drawings_visible", new Attribute(null, "image_drawings_visible", null)},
                {"image_measurements_visible", new Attribute(null, "image_measurements_visible", null)},
                {"image_implants_visible", new Attribute(null, "image_implants_visible", null)},
                {"image_markers_visible", new Attribute(null, "image_markers_visible", null)},
                {"image_rois_visible", new Attribute(null, "image_rois_visible", null)},
                {"image_orientation", new Attribute(null, "image_orientation", null)},
            };

            ImageOrientation = imageOrientation;
            ImagePseudocolor = imagePseudocolor;
            ImageDrawingsVisible = imageDrawingsVisible;
            ImageRoisVisible = imageRoisVisible;
            ImagePseudocolorPhase = imagePseudocolorPhase;
            ImageMarkersVisible = imageMarkersVisible;
            ImageMeasurementsVisible = imageMeasurementsVisible;
            ImageImplantsVisible = imageImplantsVisible;
            ImagePseudocolorWindowWidth = imagePseudocolorWindowWidth;
            ImagePseudocolorWindowOffset = imagePseudocolorWindowOffset;
            ImageTransparentPseudocolors = imageTransparentPseudocolors;
            ColorMap = new ColorMap(
                colorMapType,
                colorMapName,
                colorMapId,
                colorMapRedChannel,
                colorMapGreenChannel,
                colorMapBlueChannel
            );
        }

        [XmlElement("Attribute")] 
        public List<Attribute> SerializedAttributes
        {
            get => _serializedAttributes.Values.ToList();
            set
            {
                var newAttributes = new Dictionary<string, Attribute>();
                foreach (var attr in value)
                {
                    newAttributes.Add(attr.Name, attr);
                }

                _serializedAttributes = newAttributes;
            }
        }
        
        [XmlIgnore]
        public int ImageTransparentPseudocolors
        {
            get => _imageTransparentPseudocolors;
            set
            {
                _serializedAttributes["image_transparent_pseudocolors"].Value = value.ToString();
            }
        }

        [XmlIgnore]
        public int ImagePseudocolorPhase
        {
            get => int.Parse(_serializedAttributes["image_pseudocolor_phase"].Value);
            set
            {
                _serializedAttributes["image_pseudocolor_phase"].Value = value.ToString();
            }
        }

        [XmlIgnore]
        public int ImagePseudocolorWindowOffset
        {
            get => int.Parse(_serializedAttributes["image_pseudocolor_phase"].Value);
            set
            {
                _serializedAttributes["image_pseudocolor_window_offset"].Value = value.ToString();
            }
        }

        [XmlIgnore]
        public int ImagePseudocolorWindowWidth
        {
            get => int.Parse(_serializedAttributes["image_pseudocolor_window_width"].Value);
            set
            {
                _serializedAttributes["image_pseudocolor_window_width"].Value = value.ToString();
            }
        }

        [XmlIgnore]
        public int ImagePseudocolor
        {
            get => int.Parse(_serializedAttributes["image_pseudo_color"].Value);
            set
            {
                _serializedAttributes["image_pseudo_color"].Value = value.ToString();
            }
        }

        [XmlIgnore]
        public int ImageDrawingsVisible
        {
            get => int.Parse(_serializedAttributes["image_drawings_visible"].Value);
            set
            {
                _serializedAttributes["image_drawings_visible"].Value = value.ToString();
            }
        }

        [XmlIgnore]
        public int ImageMeasurementsVisible
        {
            get => int.Parse(_serializedAttributes["image_measurements_visible"].Value);
            set
            {
                _serializedAttributes["image_measurements_visible"].Value = value.ToString();
            }
        }

        [XmlIgnore]
        public int ImageImplantsVisible
        {
            get => int.Parse(_serializedAttributes["image_implants_visible"].Value);
            set
            {
                _serializedAttributes["image_implants_visible"].Value = value.ToString();
            }
        }

        [XmlIgnore]
        public int ImageMarkersVisible
        {
            get => int.Parse(_serializedAttributes["image_markers_visible"].Value);
            set
            {
                _serializedAttributes["image_markers_visible"].Value = value.ToString();
            }
        }

        [XmlIgnore]
        public int ImageRoisVisible
        {
            get => int.Parse(_serializedAttributes["image_rois_visible"].Value);
            set
            {
                _serializedAttributes["image_rois_visible"].Value = value.ToString();
            }
        }

        [XmlIgnore]
        public int ImageOrientation
        {
            get => int.Parse(_serializedAttributes["image_orientation"].Value);
            set
            {
                _serializedAttributes["image_orientation"].Value = value.ToString();
            }
        }

        [XmlElement("color_map")]
        public ColorMap ColorMap
        {
            get => colorMap;
            set => colorMap = value;
        }

        private int _imageTransparentPseudocolors;
        private int _imagePseudocolorPhase;
        private int _imagePseudocolorWindowOffset;
        private int _imagePseudocolorWindowWidth;
        private int _imagePseudocolor;
        private int _imageDrawingsVisible;
        private int _imageMeasurementsVisible;
        private int _imageImplantsVisible;
        private int _imageMarkersVisible;
        private int _imageRoisVisible;
        private int _imageOrientation;
        private ColorMap colorMap;
    }
}