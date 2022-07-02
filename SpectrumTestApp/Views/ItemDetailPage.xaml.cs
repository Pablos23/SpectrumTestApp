using SpectrumTestApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SpectrumTestApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}