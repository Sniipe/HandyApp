using System;
using Xamarin.Forms;

namespace HandyApp.Views
{
    public partial class WelcomePage : CarouselPage
    {
        public WelcomePage()
        {
            InitializeComponent();
            initBtn.Clicked += InitBtnOnClicked;
        }

        private void InitBtnOnClicked(object sender, EventArgs e)
        {
            CurrentPage = continuePage;
        }
    }
}
