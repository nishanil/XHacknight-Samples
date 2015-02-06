using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingWithCamera.ViewModel;
using Xamarin.Forms;

namespace WorkingWithCamera
{
    public partial class CameraPage : ContentPage
    {
        public CameraPage()
        {
            InitializeComponent();
            this.BindingContext = new CameraViewModel();
        }
    }
}
