using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var swfilelist = System.IO.Directory.GetFiles(@"C:\CODE\guitarcrawler\music").Where((v) => v.Contains(".swf"));

            foreach (var file in swfilelist)
            {
                var inputfile = new FileInfo(file);
                var imgfile = inputfile.Name.Split('.')[0] + ".png";
                var imgfullpath = System.IO.Path.Combine(@"C:\music\png", imgfile);
                //Console.WriteLine(imgfullpath);
                Console.WriteLine($"start to convert {inputfile} ");
                //var ouputpath = @"C:\music\가거라.png";
                ConvertSWFToPng(inputfile.FullName, imgfullpath);
            }

        }

        public static void ConvertSWFToPng(string _inputPath, string _otputPath, int width = 1500, int height = 1000)
        {
            if (string.IsNullOrEmpty(_inputPath) || string.IsNullOrEmpty(_otputPath))
            {
                throw new ArgumentNullException("ConvertSWFToJpg(string _inputPath,string _otputPath)");
            }
            if (!System.IO.File.Exists(_inputPath))
                throw new Exception("Файл для конвертации в формат jpg не найден: " + _inputPath);

            SWFToImage.SWFToImageObject obj = new SWFToImage.SWFToImageObject();
            obj.InitLibrary("demo", "demo");
            obj.ImageOutputType = SWFToImage.TImageOutputType.iotPNG;
            obj.JPEGQuality = 100;
            obj.ImageWidth = width;
            obj.ImageHeight = height;

            obj.InputSWFFileName = _inputPath;

            try
            {
                obj.Execute_Begin();

                obj.FrameIndex = 0;
                obj.Execute_GetImage();
                obj.SaveToFile(_otputPath);
                obj.Execute_End();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка конвертации из формата swf в формат png: " + ex.Message);
            }
        }
    }
}
