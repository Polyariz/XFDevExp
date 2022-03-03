using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;

using XamarinFormsDemo.Models;
using XamarinFormsDemo.Views;

namespace XamarinFormsDemo.ViewModels {
    public class ItemsViewModel : BaseViewModel {
        public ObservableCollection<StockPrice> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel() {
            Title = "Browse";
            Items = new ObservableCollection<StockPrice>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, StockPrice>(this, "AddPrice", async (obj, item) => {
                var _item = item as StockPrice;
                Items.Add(_item);
                await DataStore.AddItemAsync(_item);
            });
            MessagingCenter.Subscribe<ItemsPage, StockPrice>(this, "DeletePrice", async (obj, item) => {
                var _item = item as StockPrice;
                Items.Remove(_item);
                await DataStore.DeleteItemAsync(_item.Id);
            });
            MessagingCenter.Subscribe<ItemDetailPage, StockPrice>(this, "UpdateAddPrice", async (obj, item) => {
                var _item = item as StockPrice;
                Items.Remove(Items.Single(i => i.Id == _item.Id));
                Items.Add(_item);
                await DataStore.UpdateItemAsync(_item);
            });
        }

        async Task ExecuteLoadItemsCommand() {
            if(IsBusy)
                return;

            IsBusy = true;
            await LoadItemsAsync();
            IsBusy = false;
        }

        public void UpdateItems() {
            OnPropertyChanged(nameof(Items));  
        }

        public async Task LoadItemsAsync() {
            try {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach(var item in items) {
                    Items.Add(item);
                }
            } catch(Exception ex) {
                Debug.WriteLine(ex);
            }
        }
    }
}