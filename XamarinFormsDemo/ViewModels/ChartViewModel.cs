 using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFormsDemo.Models;

namespace XamarinFormsDemo.ViewModels
{
    public class ChartViewModel : BaseViewModel
    {
        public ObservableCollection<StockPrice> StockPrices { get; set; }
        public Command LoadItemsCommand { get; set; }

        //public StockPrices StockPrices { get; }
        public DevExpress.XamarinForms.Charts.DateTimeRange VisualRange { get; set; }
        public ChartViewModel()
        {
            //StockPrices = StockData.GetStockPrices();
            StockPrices = new ObservableCollection<StockPrice>();
            LoadItemsCommand = new Xamarin.Forms.Command(async () => 
            {
                await ExecuteLoadItemsCommand(); 
            });
        }
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            await LoadItemsAsync();
            IsBusy = false;
        }
        public void UpdateItems()
        {
            //OnPropertyChanged(nameof(StockPrices));
            LoadItemsCommand.Execute(this);
        }
        public async Task LoadItemsAsync()
        {
            try
            {
                StockPrices.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items) 
                    StockPrices.Add(item); 

                VisualRange = new DevExpress.XamarinForms.Charts.DateTimeRange()
                {
                    VisualMin = StockPrices.Max(d => d.Date),
                    VisualMax = StockPrices.Min(d => d.Date),
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
