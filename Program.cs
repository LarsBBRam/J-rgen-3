namespace Jørgen_3;

class Program
{
    static void Main(string[] args)
    {
        ImageController controller = new ImageController();
        Console.WriteLine("Image file path:");

        string? path = Console.ReadLine();

        controller.AnalysAndDisplayImageInformation(path);
    }
}
