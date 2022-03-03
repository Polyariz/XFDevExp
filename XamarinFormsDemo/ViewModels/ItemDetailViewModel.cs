using System;

using XamarinFormsDemo.Models;

namespace XamarinFormsDemo.ViewModels {
    public class ItemDetailViewModel : BaseViewModel {
        public StockPrice Item { get; set; }
        public ItemDetailViewModel(StockPrice item = null) { 
            Title = String.Format("{0:dddd, MMMM d, yyyy}", item.Date);
            Item = item;
        }
    }
}
