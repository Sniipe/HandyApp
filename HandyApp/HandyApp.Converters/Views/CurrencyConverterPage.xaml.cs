using System;
using Xamarin.Forms;

namespace HandyApp.Converters.Views
{
    public partial class CurrencyConverterPage : ContentPage
    {
        public CurrencyConverterPage()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw;
            }
            
        }
    }
}
