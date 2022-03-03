using DevExpress.XamarinForms.Charts;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsDemo.ViewModels;

namespace XamarinFormsDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChartPage : ContentPage {
        ChartViewModel viewModel;
        public ChartPage() {
            DevExpress.XamarinForms.Charts.Initializer.Init();
            InitializeComponent();
            BindingContext = viewModel = new ChartViewModel();
        }

        //private void Button_Click(object sender, System.EventArgs e)
        //{
        //    PointSeries pointSeries = (PointSeries)chart.Series[0];
        //    CustomDataAdapter dataAdapter = (CustomDataAdapter)pointSeries.Data;
        //    dataAdapter.Next();
        //}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.StockPrices?.Count == 0) 
                await viewModel.LoadItemsAsync(); 
            else 
                viewModel.UpdateItems(); 
        }
    }
}
