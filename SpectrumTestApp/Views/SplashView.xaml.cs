using SpectrumTestApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpectrumTestApp.Views
{
    /// <summary>
    /// SplashView
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashView : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SplashView"/> class.
        /// </summary>
        public SplashView()
        {
            InitializeComponent();
        }
    }
}