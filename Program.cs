using System.Runtime.CompilerServices;

namespace Jørgen_3;

class Program
{
    static void Main(string[] args)
    {
        ImageController controller = new ImageController();
        Console.WriteLine("Image file path:");

        string? path = Console.ReadLine();

        controller.AnalysAndDisplayImageInformation(path);
        Console.WriteLine($"{path} image uuid: {Guid.NewGuid()}");
        /*
        Console.WriteLine("If the metadata is unavaiable, you can run a hexdump to see if the metadata exists in any given image or not.\nDo you want to run a hexdump? y/N");

        string? userInput = Console.ReadLine();
        if (userInput.ToLower() == "y")
        {
            HexDump.DumpHexData(path);
        }
        */
    }
}
