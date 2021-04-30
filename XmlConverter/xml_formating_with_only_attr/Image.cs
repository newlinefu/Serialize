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
        [XmlIgnore]
        public Dictionary<string, Attribute> _serializedAttributes;

        public Image()
        {
            _serializedAttributes = new Dictionary<string, Attribute>()
            {
                {"title", new Attribute(null, "title", null)},
                {"source", new Attribute(null, "source", null)},
                {"time_of_image", new Attribute(null, "time_of_image", "exposure")},
                {"date_of_image", new Attribute(null, "date_of_image", "exposure")},
                {"modality", new Attribute(null, "modality", null)}
            };
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
            _serializedAttributes = new Dictionary<string, Attribute>()
            {
                {"title", new Attribute(null, "title", null)},
                {"source", new Attribute(null, "source", null)},
                {"time_of_image", new Attribute(null, "time_of_image", "exposure")},
                {"date_of_image", new Attribute(null, "date_of_image", "exposure")},
                {"modality", new Attribute(null, "modality", null)}
            };
            
            Title = title;
            Modality = modality;
            Source = source;
            TimeOfImage = timeOfImage;
            this._imageElement = new ImageProcessing(
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

        [XmlArray("general")]
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
        public string Title
        {
            get => _serializedAttributes["title"].Value;
            set { _serializedAttributes["title"].Value = value; }
        }

        [XmlIgnore]
        public string Source
        {
            get => _serializedAttributes["source"].Value;
            set { _serializedAttributes["source"].Value = value; }
        }

        [XmlIgnore]
        public DateTime TimeOfImage
        {
            get
            {
                string time = _serializedAttributes["time_of_image"].Value;
                string date = _serializedAttributes["date_of_image"].Value;
                return DateTime.Parse($"{date} {time}");
            }
            set
            {
                _serializedAttributes["time_of_image"].Value = value.ToString(@"hh\:mm\:ss");
                _serializedAttributes["date_of_image"].Value = value.ToString("yyyy-MM-dd");
            }
        }

        [XmlIgnore]
        public string Modality
        {
            get => _serializedAttributes["modality"].Value;
            set { _serializedAttributes["time_of_image"].Value = value; }
        }

        [XmlElement("image_processing")]
        public ImageProcessing ImageElement
        {
            get => _imageElement;
            set => _imageElement = value;
        }

        private ImageProcessing _imageElement;
    }
}