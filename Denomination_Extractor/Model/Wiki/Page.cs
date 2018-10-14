namespace Denomination_Extractor.Model.Wiki
{
    public class Page
    {
        public string Title { get; set; }
        public int Ns { get; set; }
        public int Id { get; set; }
        public Revision Revision { get; set; }
    }
}
