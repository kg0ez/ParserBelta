using System;
using System.Collections;
using System.Text;
using HtmlAgilityPack;

namespace Pars
{
    class Program
    {
        static void Main(string[] args)
        { 
            HtmlWeb web = new HtmlWeb();
            web.OverrideEncoding = Encoding.UTF8;
            HtmlDocument document = web.Load("https://www.belta.by/all_news");
            ArrayList list = new ArrayList();
            int count = 0;
            foreach (HtmlNode node in document.DocumentNode.SelectNodes("//div[contains(@class, 'lenta_inner')]//a[@href]"))
            {
                count++;
                Console.WriteLine(node.GetAttributeValue("href", null));
                if(count>2)
                    list.Add(node.GetAttributeValue("href", null));
                if (count == 12) break;
            }
            foreach (string item in list)
            {
                document = web.Load(item);

                Console.ForegroundColor = ConsoleColor.Green;
                foreach (HtmlNode link in document.DocumentNode.SelectNodes("//div[contains(@class, 'content_margin')]//h1"))
                    Console.WriteLine(link.InnerText);

                Console.ForegroundColor = ConsoleColor.White;
                foreach (HtmlNode link in document.DocumentNode.SelectNodes("//div[contains(@class, 'js-mediator-article')]//p"))
                    Console.WriteLine(link.InnerText);
            }
        }
    }
}

