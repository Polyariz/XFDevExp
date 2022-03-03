using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinFormsDemo.Models;
using XamarinFormsDemo.Services;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinFormsDemo.XpoDataStore))]
namespace XamarinFormsDemo {
    public class XpoDataStore : IDataStore<StockPrice> {
        public async Task<bool> AddItemAsync(StockPrice item) {
            try {
                using(var uow = XpoHelper.CreateUnitOfWork()) {
                    item.Id = Guid.NewGuid().ToString();
                    uow.Save(item);
                    await uow.CommitChangesAsync();
                    return true;
                }
            } catch(Exception) {
                return false;
            }
        }

        public async Task<bool> DeleteItemAsync(string id) {
            try {
                using(var uow = XpoHelper.CreateUnitOfWork()) {
                    var itemToDelete = uow.GetObjectByKey<StockPrice>(id);
                    if(itemToDelete != null) {
                        uow.Delete(itemToDelete);
                        await uow.CommitChangesAsync();
                    }
                    return true;
                }
            } catch(Exception) {
                return false;
            }
        } 
        public Task<StockPrice> GetItemAsync(string id) {
            using(var uow = XpoHelper.CreateUnitOfWork()) {
                return uow.GetObjectByKeyAsync<StockPrice>(id);
            }
        }
         
        public async Task<IEnumerable<StockPrice>> GetItemsAsync(bool forceRefresh = false) {
            using(var uow = XpoHelper.CreateUnitOfWork()) { 
               return await uow.Query<StockPrice>().OrderBy(i => i.Date).ToListAsync();
            }
        }

        public async Task<bool> UpdateItemAsync(StockPrice item) {
            try {
                using(var uow = XpoHelper.CreateUnitOfWork()) {
                    var itemToUpdate = await uow.GetObjectByKeyAsync<StockPrice>(item.Id);
                    if(itemToUpdate == null) {
                        return false;
                    }
                    itemToUpdate.Date = item.Date;
                    itemToUpdate.Open = item.Open;
                    itemToUpdate.High = item.High;
                    itemToUpdate.Low = item.Low;
                    itemToUpdate.Close = item.Close;
                    itemToUpdate.Volume = item.Volume;
                    uow.Save(itemToUpdate);
                    await uow.CommitChangesAsync();
                    return true;
                }
            } catch(Exception) {
                return false;
            }
        }
    }
}
