using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace WorkingWithGeoLocator
{
    public partial class GeoLocatorPage : ContentPage
    {
        public GeoLocatorPage()
        {
            InitializeComponent();
            this.BindingContext = new GeoLocatorViewModel();
        }
    }
}
