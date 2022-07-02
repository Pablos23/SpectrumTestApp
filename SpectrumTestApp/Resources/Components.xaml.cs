using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpectrumTestApp.Resources
{
    /// <summary>
    /// Components
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ResourceDictionary" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Components : ResourceDictionary
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Components"/> class.
        /// </summary>
        public Components()
        {
            InitializeComponent();
        }
    }
}