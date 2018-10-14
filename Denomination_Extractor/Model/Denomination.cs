namespace Denomination_Extractor.Model
{
    public class Denomination
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public Orientation Orientation { get; set; }
        public Polity Polity { get; set; }
        public Classification Classification { get; set; }
        public string Theology { get; set; }
        public string Region { get; set; }
        public string Founder { get; set; }
        public string Founded_Location { get; set; }
        public string Founded_Year { get; set; }
        public string Number_Of_Congregations { get; set; }
        public string Number_Of_Members { get; set; }
    }
}
