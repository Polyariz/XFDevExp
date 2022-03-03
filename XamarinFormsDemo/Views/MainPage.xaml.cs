using Xamarin.Forms;

namespace XamarinFormsDemo.Views
{
    public partial class MainPage : TabbedPage {
        public MainPage() {
            Page itemsPage, chartPage, aboutPage = null;

            switch(Device.RuntimePlatform) {
                case Device.iOS:
                    itemsPage = new NavigationPage(new ItemsPage()) {
                        Title = "Browse"
                    };
                    chartPage = new NavigationPage(new ChartPage()) {
                        Title = "Chart"
                    };
                    aboutPage = new NavigationPage(new AboutPage()) {
                        Title = "About"
                    };
                    itemsPage.IconImageSource = "tab_feed.png";
                    aboutPage.IconImageSource = "tab_about.png";
                    break;
                default:
                    itemsPage = new ItemsPage() {
                        Title = "Browse"
                    };
                    chartPage = new ChartPage() {
                        Title = "Chart"
                    };
                    aboutPage = new AboutPage() {
                        Title = "About"
                    };
                    break;
            }

            Children.Add(itemsPage);
            Children.Add(chartPage);
            Children.Add(aboutPage);

            Title = Children[0].Title;
            CurrentPage = Children[1];
        }

        protected override void OnCurrentPageChanged() {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
