public class ImageController
{
    private readonly ImageAnalyzer imageAnalyzer = new();

    private readonly View view = new();

    public void AnalysAndDisplayImageInformation(string? filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"The file path: {filePath} does not lead to a usable image.");
            return;
        }

        var metaData = imageAnalyzer.Analyse(filePath);
        view.ShowImageInfo(metaData);
    }
}