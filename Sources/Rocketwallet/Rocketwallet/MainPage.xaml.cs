using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Rocketwallet.Resources;

using System.Windows.Media;

namespace Rocketwallet
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;

            // Utwórz AppBar
            ApplicationBar = CreateStartPageAppBar();
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }


        #region AppBar

        private ApplicationBar CreateStartPageAppBar()
        {
            // Nowy AppBar
            ApplicationBar newAppBar = new ApplicationBar();

            //ustawienia paska
            newAppBar.Mode = ApplicationBarMode.Minimized;
            newAppBar.Opacity = 0.85;
            newAppBar.IsVisible = true;
            newAppBar.IsMenuEnabled = true;
            newAppBar.ForegroundColor = Colors.White;
            newAppBar.BackgroundColor = Colors.Black;


            // Pozycja menu kategorie
            ApplicationBarMenuItem mnuCategories = new ApplicationBarMenuItem();
            mnuCategories.Text = AppResources.MenuCategories;
            mnuCategories.Click += new EventHandler(mnuCategories_click);
            newAppBar.MenuItems.Add(mnuCategories);

            // Pozycja menu ustawienia
            ApplicationBarMenuItem mnuSettings = new ApplicationBarMenuItem();
            mnuSettings.Text = AppResources.MenuSettings;
            mnuSettings.Click += new EventHandler(mnuSettings_click);
            newAppBar.MenuItems.Add(mnuSettings);

            // Pozycja menu o programie
            ApplicationBarMenuItem mnuAbout = new ApplicationBarMenuItem();
            mnuAbout.Text = AppResources.MenuAbout;
            mnuAbout.Click += new EventHandler(mnuAbout_click);
            newAppBar.MenuItems.Add(mnuAbout);

            // Zwróć AppBar
            return newAppBar;
        }


        //
        // Przejdz na stronę O programie
        //
        private void mnuAbout_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/AboutPage.xaml", UriKind.Relative));
        }


        //
        // Przejdź na stronę Ustawienia
        //
        private void mnuSettings_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/SettingsPage.xaml", UriKind.Relative));
        }

        //
        // Przejdź na stronę Kategorię
        //
        private void mnuCategories_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/CategoriesPage.xaml", UriKind.Relative));
        }
        #endregion


       
    }
}