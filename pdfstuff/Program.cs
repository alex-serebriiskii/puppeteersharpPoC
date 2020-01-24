using PuppeteerSharp;
using System;
using System.IO;
using System.Threading.Tasks;

namespace pdfstuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            PrintPDF(@"desired\pdf\file").GetAwaiter().GetResult();

        }
        public static async Task PrintPDF(string fpath)
        {
            var options = new LaunchOptions
            {
                Headless = true,
                ExecutablePath = @"path to chromium install"
            };
            Console.WriteLine("Got the executable path");
            using (var browser = await Puppeteer.LaunchAsync(options))
            
            using (var page = await browser.NewPageAsync())
                {
                    //can be also taken from live web pages
                    await page.GoToAsync(@"path\to\html\template");

                    Console.WriteLine("Generating PDF");
                    await page.PdfAsync(fpath);
                    await browser.CloseAsync();

                }
            
        }
    }
}
