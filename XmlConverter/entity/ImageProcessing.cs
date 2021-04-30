using System;
using System.Runtime.Serialization;

namespace XmlConverter.entity
{
    [DataContract(Name = "image_processing")]
    [Serializable]
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
            this._imageOrientation = imageOrientation;
            this._imagePseudocolor = imagePseudocolor;
            this._imageDrawingsVisible = imageDrawingsVisible;
            this._imageRoisVisible = imageRoisVisible;
            this._imagePseudocolorPhase = imagePseudocolorPhase;
            this._imageMarkersVisible = imageMarkersVisible;
            this._imageMeasurementsVisible = imageMeasurementsVisible;
            this._imageImplantsVisible = imageImplantsVisible;
            this._imagePseudocolorWindowWidth = imagePseudocolorWindowWidth;
            this._imagePseudocolorWindowOffset = imagePseudocolorWindowOffset;
            this._imageTransparentPseudocolors = imageTransparentPseudocolors;
            this.colorMap = new ColorMap(
                colorMapType,
                colorMapName,
                colorMapId,
                colorMapRedChannel,
                colorMapGreenChannel,
                colorMapBlueChannel  
            );
        }
        
        [DataMember(Name = "image_transparent_pseudocolors")]
        public int _imageTransparentPseudocolors;

        [DataMember(Name = "image_pseudocolor_phase")]
        public int _imagePseudocolorPhase;

        [DataMember(Name = "image_pseudocolor_window_offset")]
        public int _imagePseudocolorWindowOffset;

        [DataMember(Name = "image_pseudocolor_window_width")]
        public int _imagePseudocolorWindowWidth;

        [DataMember(Name = "image_pseudo_color")]
        public int _imagePseudocolor;

        [DataMember(Name = "image_drawings_visible")]
        public int _imageDrawingsVisible;

        [DataMember(Name = "image_measurements_visible")]
        public int _imageMeasurementsVisible;

        [DataMember(Name = "image_implants_visible")]
        public int _imageImplantsVisible;

        [DataMember(Name = "image_markers_visible")]
        public int _imageMarkersVisible;

        [DataMember(Name = "image_rois_visible")]
        public int _imageRoisVisible;

        [DataMember(Name = "image_orientation")]
        public int _imageOrientation;

        [DataMember(Name = "color_map")] public ColorMap colorMap;
    }
}