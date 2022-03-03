using DevExpress.Xpo;
using System;

namespace XamarinFormsDemo.Models
{ 
    //POCO XPO entity
    [Persistent]
    public class StockPrice
    {
        [Key]
        public string Id { get; set; }  
        public DateTime Date { get; set; } 
        public double High { get; set; }
        public double Low { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
        public double Volume { get; set; }
    }
}
