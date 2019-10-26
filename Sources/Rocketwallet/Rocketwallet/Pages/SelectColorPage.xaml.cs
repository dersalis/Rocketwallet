using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using Rocketwallet.Rocketwallet;
using System.Windows.Media;
using Rocketwallet.Resources;

namespace Rocketwallet.Pages
{
    public partial class SelectColorPage : PhoneApplicationPage
    {
        // Instancja rocketwallet
        private RocketwalletManager _rocketwallet = RocketwalletManager.Instance;

        public SelectColorPage()
        {
            InitializeComponent();

            // Utwórz appBar
            ApplicationBar = CreateSelectColorPageAppBar();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Ustaw kolor
            colSelectColor.Color = _rocketwallet.TempCategoryColor.Color;
        }


        //
        // Tworzy ApplicationBar dla strony Widok cytatu
        //
        private ApplicationBar CreateSelectColorPageAppBar()
        {
            // Nowy AppBar
            ApplicationBar newAppBar = new ApplicationBar();

            //ustawienia paska
            newAppBar.Mode = ApplicationBarMode.Default;
            newAppBar.Opacity = 0.75;
            newAppBar.IsVisible = true;
            newAppBar.IsMenuEnabled = true;
            newAppBar.ForegroundColor = Colors.White;
            newAppBar.BackgroundColor = Colors.Black;


            // Przycisk dodawania do ulubionych
            ApplicationBarIconButton btnOk = new ApplicationBarIconButton();
            btnOk.IconUri = new Uri("/Toolkit.Content/ApplicationBar.Check.png", UriKind.Relative);
            btnOk.Text = AppResources.ButtonOk;
            btnOk.Click += new EventHandler(btnOk_Click);
            newAppBar.Buttons.Add(btnOk);

            // Przycisk dzielenia się cytatem
            ApplicationBarIconButton btnCancel = new ApplicationBarIconButton();
            btnCancel.IconUri = new Uri("/Toolkit.Content/ApplicationBar.Cancel.png", UriKind.Relative);
            btnCancel.Text = AppResources.ButtonAnuluj;
            btnCancel.Click += new EventHandler(btnCancel_Click);
            newAppBar.Buttons.Add(btnCancel);

            // Zwróć AppBar
            return newAppBar;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Opuść stronę
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // Dodaj kolor
            _rocketwallet.TempCategoryColor = new SolidColorBrush(colSelectColor.Color);
            // Opuść stronę
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }
    }
}