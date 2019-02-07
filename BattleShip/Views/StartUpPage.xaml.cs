using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BattleShip.Views
{
    /// <summary>
    /// Logique d'interaction pour StartUpWindow.xaml
    /// </summary>
    public partial class StartUpPage : Page
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributes
        #endregion

        #region Properties
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public StartUpPage()
        {
            InitializeComponent();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        private Boolean IsNumberField(TextBox textBox)
        {
            if (!int.TryParse(textBox.Text, out int nb))
            {
                return true;
            }

            return false;
        }
        private Boolean ValidateShipFields()
        {
            Boolean valid = this.IsNumberField(this.firstShipNumberValue) &&
                this.IsNumberField(this.secondShipNumberValue) &&
                this.IsNumberField(this.thirdShipNumberValue) &&
                this.IsNumberField(this.fourthShipNumberValue) &&
                this.IsNumberField(this.firstShipXSizeValue) &&
                this.IsNumberField(this.secondShipXSizeValue) &&
                this.IsNumberField(this.thirdShipXSizeValue) &&
                this.IsNumberField(this.fourthShipXSizeValue) &&
                this.IsNumberField(this.firstShipYSizeValue) &&
                this.IsNumberField(this.secondShipYSizeValue) &&
                this.IsNumberField(this.thirdShipYSizeValue) &&
                this.IsNumberField(this.fourthShipYSizeValue);

            return valid;
        }

        private Boolean ValidateMapFields()
        {
            Boolean valid = this.IsNumberField(this.mapXSizeValue) && this.IsNumberField(this.mapYSizeValue);

            return valid;
        }

        private Boolean ValidateSizes()
        {
            int.TryParse(this.mapXSizeValue.Text, out int mapX);
            int.TryParse(this.mapYSizeValue.Text, out int mapY);

            int.TryParse(this.firstShipNumberValue.Text, out int firstShipNb);
            int.TryParse(this.secondShipNumberValue.Text, out int secondShipNb);
            int.TryParse(this.thirdShipNumberValue.Text, out int thirdShipNb);
            int.TryParse(this.fourthShipNumberValue.Text, out int fourthShipNb);

            int.TryParse(this.firstShipXSizeValue.Text, out int firstShipX);
            int.TryParse(this.secondShipXSizeValue.Text, out int secondShipX);
            int.TryParse(this.thirdShipXSizeValue.Text, out int thirdShipX);
            int.TryParse(this.fourthShipXSizeValue.Text, out int fourthShipX);

            int.TryParse(this.firstShipYSizeValue.Text, out int firstShipY);
            int.TryParse(this.secondShipYSizeValue.Text, out int secondShipY);
            int.TryParse(this.thirdShipYSizeValue.Text, out int thirdShipY);
            int.TryParse(this.fourthShipYSizeValue.Text, out int fourthShipY);

            return false;
        }

        private void HideErrorMessages()
        {
            this.shipInputErrorMessage.Visibility = Visibility.Hidden;
            this.mapInputErrorMessage.Visibility = Visibility.Hidden;
        }
        #endregion

        #region Events
        private void FirstTypeValue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SecondTypeValue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ThirdTypeValue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FourthTypeValue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FirstShipNumberValue_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void ValidateButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.ValidateShipFields() && this.ValidateMapFields())
            {
                this.HideErrorMessages();
            }
            else
            {
                if (this.ValidateShipFields())
                {
                    (this.FindName("shipInputErrorMessage") as TextBlock).Visibility = Visibility.Visible;
                }
                if (this.ValidateMapFields())
                {
                    (this.FindName("mapInputErrorMessage") as TextBlock).Visibility = Visibility.Visible;
                }
            }
        }
    }
    #endregion


}
