using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace DependancyServiceDemo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        
        private void GetOrientationClicked(object sender, EventArgs e)
        {
            IDeviceOrientationService service = DependencyService.Get<IDeviceOrientationService>();
            DeviceOrientation orientation = service.GetOrientation();
            if (orientation == DeviceOrientation.Landscape)
            {
                DisplayAlert("Alert", "Its Landscape", "OK");
            }
            else if (orientation == DeviceOrientation.Portrait)
            {
                DisplayAlert("Alert", "Its Portrait", "OK");
            }
        }
    }
}
