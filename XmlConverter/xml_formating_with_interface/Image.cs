using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace XmlConverter.xml_formating_with_interface
{
    public class Image : IXmlSerializable
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

            Title = title;
            Modality = modality;
            Source = source;
            TimeOfImage = timeOfImage;
            this._imageProcessing = new ImageProcessing(
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
        
        private ImageProcessing _imageProcessing;
        private string _title;
        private string _modality;
        private string _source;
        private DateTime _timeOfImage;

        public ImageProcessing ImageProcessing
        {
            get => _imageProcessing;
            set => _imageProcessing = value;
        }

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public string Modality
        {
            get => _modality;
            set => _modality = value;
        }

        public string Source
        {
            get => _source;
            set => _source = value;
        }

        public DateTime TimeOfImage
        {
            get => _timeOfImage;
            set => _timeOfImage = value;
        }
        
        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadToDescendant("general");
            
            DateTime imageParsedDate = default(DateTime);
            TimeSpan imageParsedTime = default(TimeSpan);
            
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "image_processing")
                {
                    reader.MoveToContent();
                    _imageProcessing = new ImageProcessing();
                    _imageProcessing.ReadXml(reader);
                    reader.MoveToElement();
                }
                
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Attribute")
                {
                    switch (reader["name"])
                    {
                        case "title":
                            reader.MoveToContent();
                            _title = reader.ReadString();
                            reader.MoveToElement();
                            break;
                        case "source":
                            reader.MoveToContent();
                            _source = reader.ReadString();
                            reader.MoveToElement();
                            break;
                        case "modality":
                            reader.MoveToContent();
                            _modality = reader.ReadString();
                            reader.MoveToElement();
                            break;
                        case "time_of_image":
                            reader.MoveToContent();
                            imageParsedTime = TimeSpan.Parse(reader.ReadString());
                            reader.MoveToElement();
                            break;
                        case "date_of_image":
                            reader.MoveToContent();
                            imageParsedDate = DateTime.Parse(reader.ReadString());
                            reader.MoveToElement();
                            break;
                    }
                }
                
            }
            if (imageParsedTime != default(TimeSpan) && imageParsedDate != default(DateTime))
            {
                _timeOfImage = imageParsedDate + imageParsedTime;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("image");
            writer.WriteStartElement("general");
            writer.WriteStartElement("Attribute");
            writer.WriteAttributeString("name","title");
            writer.WriteValue(_title);
            writer.WriteEndElement();
            
            writer.WriteStartElement("Attribute");
            writer.WriteAttributeString("name","source");
            writer.WriteValue(_source);
            writer.WriteEndElement();
            
            writer.WriteStartElement("Attribute");
            writer.WriteAttributeString("name","modality");
            writer.WriteValue(_modality);
            writer.WriteEndElement();
            
            writer.WriteStartElement("Attribute");
            writer.WriteAttributeString("name","date_of_image");
            writer.WriteAttributeString("type","exposure");
            writer.WriteValue(_timeOfImage.ToString("yyyy-MM-dd"));
            writer.WriteEndElement();
            
            writer.WriteStartElement("Attribute");
            writer.WriteAttributeString("name","time_of_image");
            writer.WriteAttributeString("type","exposure");
            writer.WriteValue(_timeOfImage.ToString(@"HH\:mm\:ss"));
            writer.WriteEndElement();
            writer.WriteEndElement();
            
            writer.WriteStartElement("image_processing");
            writer.WriteStartElement("image_element");
            ImageProcessing.WriteXml(writer);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

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

            return i1._title == i2._title &&
                   i1._modality == i2._modality &&
                   i1._source == i2._source &&
                   i1._timeOfImage == i2._timeOfImage &&
                   i1._imageProcessing == i2._imageProcessing;
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

            return !(i1._title == i2._title &&
                    i1._modality == i2._modality &&
                    i1._source == i2._source &&
                    i1._timeOfImage == i2._timeOfImage &&
                    i1._imageProcessing == i2._imageProcessing);
        }
    }
}