using System;

using Xamarin.Forms;
using XamarinFormsDemo.Models;

namespace XamarinFormsDemo.Views {
    public partial class NewItemPage : ContentPage {
        public StockPrice Item { get; set; }

        public NewItemPage() {
            InitializeComponent();

            Random gen = new Random();
            int range = 30;// 5 * 365; //5 years          
            DateTime randomDate = DateTime.Today.AddDays(-gen.Next(range));

             
       double rDouble = gen.NextDouble() * 100; //for doubles

            var open = gen.Next(1200, 1300);

            Item = new StockPrice {
                Id = Guid.NewGuid().ToString(),
               Date = randomDate,
               Open = open,
               High = open + 10,
               Low = open - 10,
               Volume = gen.Next(1000000, 3000000)
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e) {
            MessagingCenter.Send(this, "AddPrice", Item);
            await Navigation.PopToRootAsync();
        }
    }
}
