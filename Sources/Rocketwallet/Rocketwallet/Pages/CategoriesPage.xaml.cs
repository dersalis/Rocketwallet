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
using System.Collections.ObjectModel;
using System.Reflection;

namespace Rocketwallet.Pages
{
    public partial class CategoriesPage : PhoneApplicationPage
    {
        // Instancja rocketwallet
        private RocketwalletManager _rocketwallet = RocketwalletManager.Instance;

        public CategoriesPage()
        {
            InitializeComponent();

            // Ustaw data context
            this.DataContext = _rocketwallet;
        }


        //
        // Naciśnięcie czyszczenia w kontrolce tekstowej
        //
        private void txtCategoryName_ActionIconTapped(object sender, EventArgs e)
        {
            // Wyczyść pole
            txtCategoryName.Text = string.Empty;
        }


        //
        //aktualizuje źródło danych
        //
        private void UpdateSourceData(object mySender)
        {
            /*
             * CEL:
             *	Aktualizowanie zródła danych za pomocą danych wprowadzonych do pola TextBox
             *	
             * WARTOŚCI WEJŚCIOWE:
             *	mySender:object - komponent z którego dane będą wysyłane do źródła
             */

            var textBox = mySender as TextBox;
            textBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }


        //
        // Zachodzi podczas wprowadzania tekstu w polu tekstowym
        //
        private void txtCategoryName_TextChanged(object sender, TextChangedEventArgs e)
        {
            //aktualizuje właściwość podczas wpisywania
            UpdateSourceData(sender);
            // Sprawdź czy można pokazać przycisk
            _rocketwallet.CheckCanAddCategory();
        }

        private void btnCategoryColor_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/SelectColorPage.xaml", UriKind.Relative));
        }
    }
}