using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using XamarinFormsDemo.Models;

namespace XamarinFormsDemo.Data
{
    [XmlRoot(ElementName = "StockPrices")]
    public class StockPrices : List<StockPrice> { } 
    public class StockData
    {
        public static StockPrices GetStockPrices()
        {
            StockPrices stockPrices;
            var assembly = typeof(StockData).Assembly; 
            using (Stream stream = assembly.GetManifestResourceStream("GoogleStock.xml"))
            {
                var serializer = new XmlSerializer(typeof(StockPrices));
                stockPrices = (StockPrices)serializer.Deserialize(stream);
            }
            return stockPrices;
        }
    }
}
