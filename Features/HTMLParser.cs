using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSharpGround.Features
{
    class HTMLParser : Feature
    {
        public override int Id => 2;

        public override string Name => "HTML Parser";

        public override void Show()
        {
            Console.Write("Enter URL: ");
            string url = Console.ReadLine();

            if(url != string.Empty)
            {
                ParseHTML(url);
            }
        }

        private async void ParseHTML(string url)
        {
            Console.WriteLine("Processing...");

            using (var client = new HttpClient())
            {
                string result = await client.GetStringAsync(url);
                await Task.Delay(2000);
                Console.WriteLine(result.Substring(0, 50));

                return;
            }
        }
    }
}
