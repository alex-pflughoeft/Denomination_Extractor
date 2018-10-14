using System.Collections.Generic;

namespace Denomination_Extractor.Model.Wiki
{
    public class MediaWiki
    {
        public SiteInfo SiteInfo { get; set; }
        public List<Page> Pages { get; set; }
    }
}
