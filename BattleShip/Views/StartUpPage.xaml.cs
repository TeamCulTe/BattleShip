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
            this.InitShipLists();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        private void InitShipLists()
        {
            foreach (var elt in Enum.GetValues(typeof(ShipType)))
            {
                this.firstTypeValue.Items.Add(elt);
                this.secondTypeValue.Items.Add(elt);
                this.thirdTypeValue.Items.Add(elt);
                this.fourthTypeValue.Items.Add(elt);
            }
        }

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

        private Boolean ValidateShipTypes()
        {
            String[] types = new String[4];

            types[0] = (this.firstTypeValue.SelectedItem != null) ? this.firstTypeValue.SelectedItem.ToString() : "";
            types[1] = (this.secondTypeValue.SelectedItem != null) ? this.firstTypeValue.SelectedItem.ToString() : "";
            types[2] = (this.thirdTypeValue.SelectedItem != null) ? this.firstTypeValue.SelectedItem.ToString() : "";
            types[3] = (this.fourthTypeValue.SelectedItem != null) ? this.firstTypeValue.SelectedItem.ToString() : "";

            for (int i = 0; i < types.Length; i++)
            {
                if (types[i] == "")
                {
                    return false;
                }

                for (int j = 0; j != i && j < types.Length; j++)
                {
                    if (types[i] == types[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private Boolean ValidateMapFields()
        {
            return this.IsNumberField(this.mapXSizeValue) && this.IsNumberField(this.mapYSizeValue);
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

            int shipTotalSize = firstShipNb * firstShipX * firstShipY +
                secondShipNb * secondShipX * secondShipY +
                thirdShipNb * thirdShipX * thirdShipY +
                fourthShipNb * fourthShipX * fourthShipY;

            return (mapX * mapY > shipTotalSize);
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
            if (this.ValidateShipFields() && this.ValidateMapFields() && this.ValidateShipTypes())
            {
                if (!this.ValidateSizes())
                {
                    MessageBox.Show("The total ship sizes cannot be bigger than the map ones.", "Error", System.Windows.MessageBoxButton.OK);

                    return;
                }

                ShipSetupModel shipSetup = new ShipSetupModel();
            }
            else
            {
                String errorMessage = "";

                if (!this.ValidateShipFields())
                {
                    errorMessage = "The ship fields must only contains numbers.";
                }
                if (!this.ValidateMapFields())
                {
                    errorMessage = "The map fields must only contains numbers.";
                }
                if (!this.ValidateShipTypes())
                {
                    errorMessage = "The ship types must be set and unique (one of each).";
                }

                MessageBox.Show(errorMessage, "Error", System.Windows.MessageBoxButton.OK);
            }
        }
    }
    #endregion


}
