using Denomination_Extractor.Model;
using Denomination_Extractor.Model.Wiki;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denomination_Extractor
{
    public class Program
    {
        static void Main(string[] args)
        {
            WikiExtractor wiki = new WikiExtractor();
            MediaWiki mediaWiki = wiki.ParseMediaWikiFromXML(@"C:\Users\Alexander\Downloads\Wikipedia-20181014182236.xml");
            Extractor extractor = new Extractor();
            List<Denomination> denominations = new List<Denomination>();

            foreach (Page page in mediaWiki.Pages)
            {
                Denomination denomination = extractor.GetDenominationFromPage(page);

                denominations.Add(denomination);
            }

            Console.WriteLine("Done");
        }
    }
}
