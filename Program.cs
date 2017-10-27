using System.IO;
using System.IO.Compression;

namespace ImagesToZip
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles(@"D:\Drive\000", "*.jpg");
            if (files.Length == 0)
                return;

            using (var fs = File.Create(@"D:\Drive\000\Фото.zip"))
            using (var zip = new ZipArchive(fs, ZipArchiveMode.Create))
            {
                foreach (var file in files)
                {
                    var entry = zip.CreateEntry(Path.GetFileName(file));

                    using (var stream = entry.Open())
                    using (var image = ImageHelper.GetCompressed(file))
                    {
                        image.CopyTo(stream);
                    }
                }
            }
        }
    }
}
