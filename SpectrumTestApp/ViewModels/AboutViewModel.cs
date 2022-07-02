using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SpectrumTestApp.ViewModels
{
    /// <summary>
    /// AboutViewModel
    /// </summary>
    /// <seealso cref="SpectrumTestApp.ViewModels.BaseViewModel" />
    public class AboutViewModel : BaseViewModel
    {
        private Command openLinkedInCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="AboutViewModel"/> class.
        /// </summary>
        public AboutViewModel()
        {
            Title = "About";           
        }
        /// <summary>
        /// Gets the open linked in command.
        /// </summary>
        /// <value>
        /// The open linked in command.
        /// </value>
        public ICommand OpenLinkedInCommand => openLinkedInCommand ?? (openLinkedInCommand = new Command(OpenLinkedIn));

        /// <summary>
        /// Opens the linked in.
        /// </summary>
        public async void OpenLinkedIn() 
        {
            await Browser.OpenAsync(new Uri("https://www.linkedin.com/in/pablo-c-2056b9133/"), BrowserLaunchMode.SystemPreferred);
        }
    }
}