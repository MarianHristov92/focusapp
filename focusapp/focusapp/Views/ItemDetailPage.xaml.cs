using System.ComponentModel;
using Xamarin.Forms;
using focusapp.ViewModels;

namespace focusapp.Views
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
