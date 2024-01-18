using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gs.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gs
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(TypeAddingPage), typeof(TypeAddingPage));

            Routing.RegisterRoute(nameof(AmmoAddingPage), typeof(AmmoAddingPage));

            Routing.RegisterRoute(nameof(GunAddingPage), typeof(GunAddingPage));
        }
    }
}