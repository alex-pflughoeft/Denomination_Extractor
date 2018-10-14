using System;

namespace Denomination_Extractor.Model.Wiki
{
    public class Revision
    {
        public int ParentId { get; set; }
        public DateTime Timestamp { get; set; }
        public Contributor Contributor { get; set; }
        public string Comment { get; set; }
        public string Model { get; set; }
        public string Format { get; set; }
    }
}
