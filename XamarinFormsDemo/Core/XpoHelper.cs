using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using System;
using System.Linq;
using XamarinFormsDemo.Models;

namespace XamarinFormsDemo {
    public static class XpoHelper {
        static readonly Type[] entityTypes = new Type[] {
            typeof(StockPrice)
        };
        public static void InitXpo(string connectionString) {
            var dictionary = PrepareDictionary();

            if(XpoDefault.DataLayer == null) {
                using(var updateDataLayer = XpoDefault.GetDataLayer(connectionString, dictionary, AutoCreateOption.DatabaseAndSchema)) {
                    updateDataLayer.UpdateSchema(false, dictionary.CollectClassInfos(entityTypes));
                }
            }

            var dataStore = XpoDefault.GetConnectionProvider(connectionString, AutoCreateOption.SchemaAlreadyExists);
            XpoDefault.DataLayer = new ThreadSafeDataLayer(dictionary, dataStore);
            XpoDefault.Session = null;

            CreateDemoData();
        }
        public static UnitOfWork CreateUnitOfWork() {
            return new UnitOfWork();
        }
        static XPDictionary PrepareDictionary() {
            var dict = new ReflectionDictionary();
            dict.GetDataStoreSchema(entityTypes);
            return dict;
        }
         
        static readonly StockPrice[] demoData = new StockPrice[] {
                new StockPrice { Id = Guid.NewGuid().ToString(), Date = new DateTime(2019,10,23), Open = 1240.209961, High = 1258.040039, Low = 1240.209961, Close = 1257.630005, Volume = 1064100}, 
                new StockPrice { Id = Guid.NewGuid().ToString(), Date = new DateTime(2019,10,24), Open = 1259.109985, High = 1262.900024, Low = 1252.349976, Close = 1259.109985, Volume = 1011200}, 
                new StockPrice { Id = Guid.NewGuid().ToString(), Date = new DateTime(2019,10,25), Open = 1252.000000, High = 1268.000000, Low = 1249.150024, Close = 1264.300049, Volume = 1355200}, 
                new StockPrice { Id = Guid.NewGuid().ToString(), Date = new DateTime(2019,10,28), Open = 1275.000000, High = 1299.239990, Low = 1272.310059, Close = 1288.979980, Volume = 3271400}, 
                new StockPrice { Id = Guid.NewGuid().ToString(), Date = new DateTime(2019,10,29), Open = 1276.000000, High = 1280.800049, Low = 1255.609985, Close = 1260.660034, Volume = 2632700}, 
        };
        static void CreateDemoData() {
            using (var uow = CreateUnitOfWork())
            {
                if (!uow.Query<StockPrice>().Any())
                {
                    foreach (var demoItem in demoData)
                    {
                        uow.Save(demoItem);
                    }
                    uow.CommitChanges();
                }
            }
        }
    }
}
