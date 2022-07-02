using System.Windows.Input;
using Xamarin.Forms;

namespace SpectrumTestApp.ViewModels
{
    /// <summary>
    ///  SplasViewModel.
    /// </summary>
    public class SplasViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SplasViewModel"/> class.
        /// </summary>
        public SplasViewModel()
        {
        }

        private Command onFinishedAnimationCommand;
        public ICommand OnFinishedAnimationCommand => onFinishedAnimationCommand ?? (onFinishedAnimationCommand = new Command(OnFinishedAnimation));

        private void OnFinishedAnimation()
        {
            Application.Current.MainPage = new AppShell();
        }
    }
}
