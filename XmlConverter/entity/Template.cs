using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Xml.Serialization;

namespace XmlConverter.entity
{
    [DataContract(Name = "original")]
    [Serializable]
    public sealed class Template
    {
        public Template(
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
            this._title = title;
            this._modality = modality;
            this._source = source;
            this._dateOfImage = timeOfImage.Date;
            this._timeOfImage = timeOfImage.TimeOfDay;
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
        [DataMember(Name = "title")] private string _title = "a";

        [DataMember(Name = "source")] private string _source = "s";

        [DataMember(Name = "date_of_image")] private DateTime _dateOfImage = DateTime.Now;

        [DataMember(Name = "time_of_image")] private TimeSpan _timeOfImage = TimeSpan.MaxValue;

        [DataMember(Name = "modality")] 
        private string _modality = "m";

        [DataMember(Name = "image_processing")]
        private ImageProcessing imageProcessing;
    }
}