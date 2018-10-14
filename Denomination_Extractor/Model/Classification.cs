using System.Collections;
using System.Collections.Generic;

namespace Denomination_Extractor.Model
{
    public enum Classification
    {
        PROTESTANT
    }

    public static class Classification_Convertors
    {
        public static IDictionary<Classification, string> CLASSIFICATION_TO_DESCRIPTION = new Dictionary<Classification, string>()
        {
            { Classification.PROTESTANT, "Protestant" }
        };
    }
}
