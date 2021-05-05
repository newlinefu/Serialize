using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace XmlConverter.xml_formating_with_interface
{
    public class ImageProcessing : IXmlSerializable
    {
        public ImageProcessing()
        {
        }

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

        public int ImageTransparentPseudocolors
        {
            get => _imageTransparentPseudocolors;
            set => _imageTransparentPseudocolors = value;
        }

        public int ImagePseudocolorPhase
        {
            get => _imagePseudocolorPhase;
            set => _imagePseudocolorPhase = value;
        }

        public int ImagePseudocolorWindowOffset
        {
            get => _imagePseudocolorWindowOffset;
            set => _imagePseudocolorWindowOffset = value;
        }

        public int ImagePseudocolorWindowWidth
        {
            get => _imagePseudocolorWindowWidth;
            set => _imagePseudocolorWindowWidth = value;
        }

        public int ImagePseudocolor
        {
            get => _imagePseudocolor;
            set => _imagePseudocolor = value;
        }

        public int ImageDrawingsVisible
        {
            get => _imageDrawingsVisible;
            set => _imageDrawingsVisible = value;
        }

        public int ImageMeasurementsVisible
        {
            get => _imageMeasurementsVisible;
            set => _imageMeasurementsVisible = value;
        }

        public int ImageImplantsVisible
        {
            get => _imageImplantsVisible;
            set => _imageImplantsVisible = value;
        }

        public int ImageMarkersVisible
        {
            get => _imageMarkersVisible;
            set => _imageMarkersVisible = value;
        }

        public int ImageRoisVisible
        {
            get => _imageRoisVisible;
            set => _imageRoisVisible = value;
        }

        public int ImageOrientation
        {
            get => _imageOrientation;
            set => _imageOrientation = value;
        }

        public ColorMap ColorMap
        {
            get => colorMap;
            set => colorMap = value;
        }

        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "color_map")
                {
                    reader.MoveToContent();
                    ColorMap cm = new ColorMap();
                    cm.ReadXml(reader);
                    colorMap = cm;
                    reader.MoveToElement();
                }

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Attribute")
                {
                    if (reader["name"] != null)
                    {
                        switch (reader["name"])
                        {
                            case "image_transparent_pseudocolors":
                                reader.MoveToContent();
                                _imageTransparentPseudocolors = int.Parse(reader.ReadString());
                                reader.MoveToElement();
                                break;
                            case "image_pseudocolor_phase":
                                reader.MoveToContent();
                                _imagePseudocolorPhase = int.Parse(reader.ReadString());
                                reader.MoveToElement();
                                break;
                            case "image_pseudocolor_window_offset":
                                reader.MoveToContent();
                                _imagePseudocolorWindowOffset = int.Parse(reader.ReadString());
                                reader.MoveToElement();
                                break;
                            case "image_pseudocolor_window_width":
                                reader.MoveToContent();
                                _imagePseudocolorWindowWidth = int.Parse(reader.ReadString());
                                reader.MoveToElement();
                                break;
                            case "image_pseudo_color":
                                reader.MoveToContent();
                                _imagePseudocolor = int.Parse(reader.ReadString());
                                reader.MoveToElement();
                                break;
                            case "image_drawings_visible":
                                reader.MoveToContent();
                                _imageDrawingsVisible = int.Parse(reader.ReadString());
                                reader.MoveToElement();
                                break;
                            case "image_measurements_visible":
                                reader.MoveToContent();
                                _imageMeasurementsVisible = int.Parse(reader.ReadString());
                                reader.MoveToElement();
                                break;
                            case "image_implants_visible":
                                reader.MoveToContent();
                                _imageImplantsVisible = int.Parse(reader.ReadString());
                                reader.MoveToElement();
                                break;
                            case "image_markers_visible":
                                reader.MoveToContent();
                                _imageMarkersVisible = int.Parse(reader.ReadString());
                                reader.MoveToElement();
                                break;
                            case "image_rois_visible":
                                reader.MoveToContent();
                                _imageRoisVisible = int.Parse(reader.ReadString());
                                reader.MoveToElement();
                                break;
                            case "image_orientation":
                                reader.MoveToContent();
                                _imageOrientation = int.Parse(reader.ReadString());
                                reader.MoveToElement();
                                break;
                        }
                    }
                }
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Attribute");
            writer.WriteAttributeString("name", "image_transparent_pseudocolors");
            writer.WriteValue(_imageTransparentPseudocolors.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("Attribute");
            writer.WriteAttributeString("name", "image_pseudocolor_phase");
            writer.WriteValue(_imagePseudocolorPhase.ToString());
            writer.WriteEndElement();


            writer.WriteStartElement("Attribute");
            writer.WriteAttributeString("name", "image_pseudocolor_window_offset");
            writer.WriteValue(_imagePseudocolorWindowOffset.ToString());
            writer.WriteEndElement();


            writer.WriteStartElement("Attribute");
            writer.WriteAttributeString("name", "image_pseudocolor_window_width");
            writer.WriteValue(_imagePseudocolorWindowWidth.ToString());
            writer.WriteEndElement();


            writer.WriteStartElement("Attribute");
            writer.WriteAttributeString("name", "image_pseudo_color");
            writer.WriteValue(_imagePseudocolor.ToString());
            writer.WriteEndElement();


            writer.WriteStartElement("Attribute");
            writer.WriteAttributeString("name", "image_drawings_visible");
            writer.WriteValue(_imageDrawingsVisible.ToString());
            writer.WriteEndElement();


            writer.WriteStartElement("Attribute");
            writer.WriteAttributeString("name", "image_measurements_visible");
            writer.WriteValue(_imageMeasurementsVisible.ToString());
            writer.WriteEndElement();


            writer.WriteStartElement("Attribute");
            writer.WriteAttributeString("name", "image_implants_visible");
            writer.WriteValue(_imageImplantsVisible.ToString());
            writer.WriteEndElement();


            writer.WriteStartElement("Attribute");
            writer.WriteAttributeString("name", "image_markers_visible");
            writer.WriteValue(_imageMarkersVisible.ToString());
            writer.WriteEndElement();


            writer.WriteStartElement("Attribute");
            writer.WriteAttributeString("name", "image_rois_visible");
            writer.WriteValue(_imageRoisVisible.ToString());
            writer.WriteEndElement();


            writer.WriteStartElement("Attribute");
            writer.WriteAttributeString("name", "image_orientation");
            writer.WriteValue(_imageOrientation.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("color_map");
            colorMap.WriteXml(writer);
            writer.WriteEndElement();
        }

        public static bool operator ==(ImageProcessing i1, ImageProcessing i2)
        {
            if (object.Equals(i1, i2))
            {
                return true;
            }

            if (object.Equals(i1, null) || object.Equals(i2, null))
            {
                return false;
            }

            return i1._imageOrientation == i2._imageOrientation &&
                   i1._imagePseudocolor == i2._imagePseudocolor &&
                   i1._imageDrawingsVisible == i2._imageDrawingsVisible &&
                   i1._imageImplantsVisible == i2._imageImplantsVisible &&
                   i1._imageMarkersVisible == i2._imageMarkersVisible &&
                   i1._imageMeasurementsVisible == i2._imageMeasurementsVisible &&
                   i1._imagePseudocolorPhase == i2._imagePseudocolorPhase &&
                   i1._imageRoisVisible == i2._imageRoisVisible &&
                   i1._imageTransparentPseudocolors == i2._imageTransparentPseudocolors &&
                   i1._imagePseudocolorWindowOffset == i2._imagePseudocolorWindowOffset &&
                   i1._imagePseudocolorWindowWidth == i2._imagePseudocolorWindowWidth &&
                   i1.colorMap == i2.colorMap;

        }
        
        public static bool operator !=(ImageProcessing i1, ImageProcessing i2)
        {
            if (object.Equals(i1, i2))
            {
                return false;
            }

            if (object.Equals(i1, null) || object.Equals(i2, null))
            {
                return true;
            }
            
            return !(i1._imageOrientation == i2._imageOrientation &&
                    i1._imagePseudocolor == i2._imageOrientation &&
                    i1._imageDrawingsVisible == i2._imageDrawingsVisible &&
                    i1._imageImplantsVisible == i2._imageImplantsVisible &&
                    i1._imageMarkersVisible == i2._imageMarkersVisible &&
                    i1._imageMeasurementsVisible == i2._imageMeasurementsVisible &&
                    i1._imagePseudocolorPhase == i2._imagePseudocolorPhase &&
                    i1._imageRoisVisible == i2._imageRoisVisible &&
                    i1._imageTransparentPseudocolors == i2._imageTransparentPseudocolors &&
                    i1._imagePseudocolorWindowOffset == i2._imagePseudocolorWindowOffset &&
                    i1._imagePseudocolorWindowWidth == i2._imagePseudocolorWindowWidth &&
                    i1.colorMap == i2.colorMap);
        }
    }
}