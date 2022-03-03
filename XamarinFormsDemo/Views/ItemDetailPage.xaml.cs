using System;
using Xamarin.Forms;

using XamarinFormsDemo.Models;
using XamarinFormsDemo.ViewModels;

namespace XamarinFormsDemo.Views {
    public partial class ItemDetailPage : ContentPage {
        ItemDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemDetailPage() {
            InitializeComponent();

            var item = new StockPrice
            {
                //Id = Guid.NewGuid().ToString(),
                //Date = randomDate,
                //Open = open,
                //High = open + 10,
                //Low = open - 10,
                //Volume = gen.Next(1000000, 3000000)
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        public ItemDetailPage(ItemDetailViewModel viewModel) {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
        async void Update_Clicked(object sender, EventArgs e) {
            MessagingCenter.Send(this, "UpdatePrice", viewModel.Item);
            await Navigation.PopToRootAsync();
        }
    }
}
