using Denomination_Extractor.Model;
using Denomination_Extractor.Model.Wiki;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denomination_Extractor
{
    public class Extractor
    {
        public const string NAME_KEY = "|_name =";
        public const string ABBRV_KEY = "|_abbreviation =";
        public const string CLASSIFICATION_KEY = "|_main_classification =";
        public const string POLITY_KEY = "|_polity =";
        public const string FOUNDED_DATE_KEY = "|_founded_date =";
        public const string FOUNDED_PLACE_KEY = "|_founded_place =";
        public const string NUMBER_CONGREGATIONS_KEY = "|_congregations =";
        public const string NUMBER_MEMBERS_KEY = "|_members =";

        public Denomination GetDenominationFromPage(Page page)
        {
            Denomination denomination = new Denomination();

            denomination.Name = page.Title;

            denomination.Founder = "";
            denomination.Founded_Location = GetValueFromKey(FOUNDED_PLACE_KEY, page.Revision.Text).Trim();
            denomination.Founded_Year = GetValueFromKey(FOUNDED_DATE_KEY, page.Revision.Text).Trim();
            denomination.Abbreviation = GetValueFromKey(ABBRV_KEY, page.Revision.Text).Trim();
            denomination.Classification = Classification.PROTESTANT;
            denomination.Number_Of_Members = GetValueFromKey(NUMBER_MEMBERS_KEY, page.Revision.Text).Trim();
            denomination.Polity = Polity.CONGREGATIONAL;
            denomination.Region = "";
            denomination.Theology = "";
            denomination.Orientation = Orientation.CONFESSIONAL_LUTHERAN;
            denomination.Number_Of_Congregations = GetValueFromKey(NUMBER_CONGREGATIONS_KEY, page.Revision.Text).Trim();

            return denomination;
        }

        public string GetValueFromKey(string key, string text)
        {
            if (text.Contains(key.Replace("_", "")))
            {
                int begin = text.LastIndexOf(key.Replace("_", "")) + key.Replace("_", "").Length;
                int i = begin + 1;
                int end = 0;
                bool loop = true;

                while (loop)
                {
                    if (text[i] == '|' || text[i] == '<')
                    {
                        end = i;
                        loop = false;
                    }

                    i++;
                }

                return text.Substring(begin, (end - begin));
            }
            else if (text.Contains(key.Replace("_", " ")))
            {
                int begin = text.LastIndexOf(key.Replace("_", " ")) + key.Replace("_", "").Length;
                int i = begin;
                int end = 0;
                bool loop = true;

                while (loop)
                {
                    if (text[i] == '|' || text[i] == '<')
                    {
                        end = i;
                        loop = false;
                    }

                    i++;
                }

                return text.Substring(begin, (end - begin));
            }

            return "";
        }
    }
}
