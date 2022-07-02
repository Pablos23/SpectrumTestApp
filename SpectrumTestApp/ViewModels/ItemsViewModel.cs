using SpectrumTestApp.Models;
using SpectrumTestApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SpectrumTestApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Service _selectedItem;
        private ObservableCollection<Service> items;
        private readonly Command<string> searchCommand;
        private readonly Command loadItemsCommand;
        private readonly Command addItemCommand;
        private readonly Command<Service> itemTapped;

        public ItemsViewModel()
        {
            Title = "Services";
            this.items = new ObservableCollection<Service>();
            this.Items = new ObservableCollection<Service>();
        }

        /// <summary>
        /// Gets the search command.
        /// </summary>
        /// <value>
        /// The search command.
        /// </value>
        public ICommand SearchCommand => searchCommand ?? new Command<string>(Search);

        /// <summary>
        /// Gets the add item command.
        /// </summary>
        /// <value>
        /// The add item command.
        /// </value>
        public ICommand SupportCommand => addItemCommand ?? new Command(OnSupport);

        /// <summary>
        /// Gets the item tapped.
        /// </summary>
        /// <value>
        /// The item tapped.
        /// </value>
        public ICommand ItemTapped => itemTapped ?? new Command<Service>(OnItemSelected);

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public ObservableCollection<Service> Items { get; set; }

        /// <summary>
        /// Executes the load items command.
        /// </summary>
        async Task LoadItems()
        {
            IsBusy = true;

            try
            {
                this.items.Clear();
                this.Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    this.Items.Add(item);
                    this.items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        /// <summary>
        /// Called when [appearing].
        /// </summary>
        public async void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
            await LoadItems();
        }

        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        /// <value>
        /// The selected item.
        /// </value>
        public Service SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        /// <summary>
        /// Called when [add item].
        /// </summary>
        /// <param name="obj">The object.</param>
        private async void OnSupport(object obj)
        {
            await Browser.OpenAsync(new Uri("https://www.spectrum.net/support"), BrowserLaunchMode.SystemPreferred);
        }

        /// <summary>
        /// Called when [item selected].
        /// </summary>
        /// <param name="item">The item.</param>
        async void OnItemSelected(Service item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }

        /// <summary>
        /// Searches the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        private async void Search(string text)
        {
            this.IsBusy = true;
            this.Items.Clear();
            await Task.Delay(1000); // Simulates a long task to get data
            if (!string.IsNullOrEmpty(text))
            {                             
                this.items.Where(x => x.Text.ToLowerInvariant().Contains(text)).ToList().ForEach(x => this.Items.Add(x));
            }
            else
            {
                this.items.ToList().ForEach(x=> this.Items.Add(x));
            }
            this.IsBusy = false;
        }
    }
}