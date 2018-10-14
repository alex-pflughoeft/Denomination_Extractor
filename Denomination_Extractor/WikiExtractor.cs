using Denomination_Extractor.Model.Wiki;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Denomination_Extractor
{
    public class WikiExtractor
    {
        public MediaWiki ParseMediaWikiFromXML(string xmlFilePath)
        {
            MediaWiki mediaWiki = new MediaWiki();
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilePath);
            mediaWiki.Pages = new List<Page>();

            foreach (XmlNode node in doc.DocumentElement)
            {
                if (node.Name == "page")
                {
                    Page page = new Page();

                    foreach (XmlNode child in node.ChildNodes)
                    {
                        switch (child.Name)
                        {
                            case "title":
                                page.Title = child.InnerText;
                                break;
                            case "revision":
                                Revision revision = new Revision();

                                foreach (XmlNode revisionNode in child.ChildNodes)
                                {
                                    switch (revisionNode.Name)
                                    {
                                        case "text":
                                            revision.Text = revisionNode.InnerText;
                                            break;
                                    }
                                }

                                page.Revision = revision;
                                break;
                            default:
                                break;
                        }
                    }
                    mediaWiki.Pages.Add(page);
                }
            }

            return mediaWiki;
        }
    }
}
