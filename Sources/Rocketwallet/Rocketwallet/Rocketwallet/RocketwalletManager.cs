using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Windows.Media;

namespace Rocketwallet.Rocketwallet
{
    public class RocketwalletManager : INotifyPropertyChanged
    {
        //
        // Konstruktor
        //
        public RocketwalletManager()
        {
            // Ustaw kategorie tymczasowe
            ClearTempCategory();

        }


        #region Kategorie

        // Tymczasowa nazwa kategorii - służy do dodawania nowej kategorii
        private string _tempCategoryName;
        public string TempCategoryName
        {
            get { return _tempCategoryName; }
            set
            {
                if (_tempCategoryName != value)
                {
                    _tempCategoryName = value;
                    RaisePropertyChanged("TempCategoryName");
                }
            }
        }


        // Tymczasowy kolor kategorii - służy do dodawania nowej kategorii
        private SolidColorBrush _tempCategoryColor;
        public SolidColorBrush TempCategoryColor
        {
            get { return _tempCategoryColor; }
            set
            {
                if (_tempCategoryColor != value)
                {
                    _tempCategoryColor = value;
                    RaisePropertyChanged("TempCategoryColor");
                }
            }
        }


        // Określa czy można dodać nową kategorię
        private bool _canAddCategory;
        public bool CanAddCategory
        {
            get { return _canAddCategory; }
            private set
            {
                if (_canAddCategory != value)
                {
                    _canAddCategory = value;
                    RaisePropertyChanged("CanAddCategory");
                }
            }
        }


        //
        // Sprawdźa czy można dodać nową kategorię
        //
        public void CheckCanAddCategory()
        { 
            // Jeśli TempCategoryName zawiera tekst to można dodać kategorię
            if (TempCategoryName.Length > 0)
                CanAddCategory = true;
            else
                CanAddCategory = false;
        }


        //
        // Wyczyść kategorię tymczasową
        //
        public void ClearTempCategory()
        { 
            // Wyczyść wszystkie pozycje
            TempCategoryName = string.Empty;
            TempCategoryColor = new SolidColorBrush(Colors.Gray);
            CanAddCategory = false;
        }


        //
        // Dodaje kategorię
        //
        public void AddCategory()
        { 
            // Dodaj kategorię

            //Wyczyść pola/ właściwości
            ClearTempCategory();
        }

        #endregion


        #region Singleton

        private static RocketwalletManager _instance = null;
        public static RocketwalletManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new RocketwalletManager();
                return _instance;
            }
        }

        #endregion


        #region INotifyPropertyChanged

        // Deklaracja ReisePropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        #endregion
    }
}
