using System;
using Xamarin.Forms;

namespace HandyApp.Fitness.Views
{
    public partial class RunTrackerPage : ContentPage
    {
        public RunTrackerPage()
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
