using System.Drawing;
using System.Drawing.Imaging;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using MetadataExtractor.Formats.Jpeg;


public class ImageAnalyzer
{
    public ImageMetadata Analyse(string? filePath)
    {
        var fileInfo = new FileInfo(filePath);
        using var image = Image.FromFile(filePath);

        var metaData = new ImageMetadata
        {
            FileName = fileInfo.Name,
            FileSizeInBytes = fileInfo.Length,
            Width = image.Width,
            Height = image.Height,
            Format = image.RawFormat.ToString()
        };

        var directories = ImageMetadataReader.ReadMetadata(filePath);

        var subIfdDirectory = directories.OfType<ExifSubIfdDirectory>().FirstOrDefault();
        var ifd0 = directories.OfType<ExifIfd0Directory>().FirstOrDefault();
        var GPS = directories.OfType<GpsDirectory>().FirstOrDefault();

        metaData.CameraMake = ifd0?.GetDescription(ExifDirectoryBase.TagMake);
        metaData.CameraModel = ifd0?.GetDescription(ExifDirectoryBase.TagModel);
        // var dateTime = subIfdDirectory.GetDescription(ExifDirectoryBase.TagDateTime);

        metaData.DateTaken = ifd0?.GetDescription(ExifDirectoryBase.TagDateTime);
        // if (string.IsNullOrWhiteSpace(dateTime))
        //     throw new Exception("An error occured!");

        // var parseDateTime = DateTime.Parse(dateTime);

        // metaData.DateTaken = parseDateTime.ToLocalTime();


        var location = GPS?.GetGeoLocation();

        if (GPS != null)
        {
            metaData.GPSLongitude = location.Latitude.ToString();
            metaData.GPSLatitude = location.Longitude.ToString();
        }
        else if (GPS != null && GPS.GetGeoLocation() == null)
        {
            metaData.GPSLatitude = "0";
            metaData.GPSLongitude = "0";
        }

        return metaData;
    }
}