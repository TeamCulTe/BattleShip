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

        private Boolean IsPositiveNumberField(TextBox textBox)
        {
            if (!int.TryParse(textBox.Text, out int nb))
            {
                return false;
            }

            return nb > 0;
        }

        private Boolean ValidateShipFields()
        {
            Boolean valid = this.IsPositiveNumberField(this.firstShipNumberValue) &&
                this.IsPositiveNumberField(this.secondShipNumberValue) &&
                this.IsPositiveNumberField(this.thirdShipNumberValue) &&
                this.IsPositiveNumberField(this.fourthShipNumberValue) &&
                this.IsPositiveNumberField(this.firstShipXSizeValue) &&
                this.IsPositiveNumberField(this.secondShipXSizeValue) &&
                this.IsPositiveNumberField(this.thirdShipXSizeValue) &&
                this.IsPositiveNumberField(this.fourthShipXSizeValue) &&
                this.IsPositiveNumberField(this.firstShipYSizeValue) &&
                this.IsPositiveNumberField(this.secondShipYSizeValue) &&
                this.IsPositiveNumberField(this.thirdShipYSizeValue) &&
                this.IsPositiveNumberField(this.fourthShipYSizeValue);

            return valid;
        }

        private Boolean ValidateShipTypes()
        {
            String[] types = new String[4];

            types[0] = (this.firstTypeValue.SelectedItem != null) ? this.firstTypeValue.SelectedItem.ToString() : "";
            types[1] = (this.secondTypeValue.SelectedItem != null) ? this.secondTypeValue.SelectedItem.ToString() : "";
            types[2] = (this.thirdTypeValue.SelectedItem != null) ? this.thirdTypeValue.SelectedItem.ToString() : "";
            types[3] = (this.fourthTypeValue.SelectedItem != null) ? this.fourthTypeValue.SelectedItem.ToString() : "";

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
            return this.IsPositiveNumberField(this.mapXSizeValue) && this.IsPositiveNumberField(this.mapYSizeValue);
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

        private Boolean ValidatePlayerName()
        {
            return this.playerNameValue.Text != "";
        }

        private ShipSetupModel InitShipSetupFromInput(int setupNumber)
        {
            int[] size;
            int shipNumber;
            String name = "Ship setup ";

            switch (setupNumber)
            {
                case 1:
                    name = this.firstTypeValue.SelectedItem.ToString();
                    size = new int[] { int.Parse(this.firstShipXSizeValue.Text), int.Parse(this.firstShipYSizeValue.Text) };
                    shipNumber = int.Parse(this.firstShipNumberValue.Text);

                    break;
                case 2:
                    name = this.secondTypeValue.SelectedItem.ToString();
                    size = new int[] { int.Parse(this.secondShipXSizeValue.Text), int.Parse(this.secondShipYSizeValue.Text) };
                    shipNumber = int.Parse(this.secondShipNumberValue.Text);

                    break;
                case 3:
                    name = this.thirdTypeValue.SelectedItem.ToString();
                    size = new int[] { int.Parse(this.thirdShipXSizeValue.Text), int.Parse(this.thirdShipYSizeValue.Text) };
                    shipNumber = int.Parse(this.thirdShipNumberValue.Text);

                    break;
                case 4:
                    name = this.fourthTypeValue.SelectedItem.ToString();
                    size = new int[] { int.Parse(this.fourthShipXSizeValue.Text), int.Parse(this.fourthShipYSizeValue.Text) };
                    shipNumber = int.Parse(this.fourthShipNumberValue.Text);

                    break;
                default:
                    return null;
            }

            return new ShipSetupModel(name, size, shipNumber);
        }

        private MapSetupModel InitMapSetupFromInput()
        {
            int[] size = new int[] { int.Parse(this.mapXSizeValue.Text), int.Parse(this.mapYSizeValue.Text) };

            return new MapSetupModel("Map setup", size);
        }

        private MapModel InitMapModelFromInput()
        {
            MapModel.Setup = this.InitMapSetupFromInput();

            return new MapModel();
        }

        private PlayerModel InitPlayerFromInput()
        {
            return new PlayerModel(this.playerNameValue.Text, this.InitMapModelFromInput());
        }

        private ShipModel InitShipFromInput(int shipNumber)
        {
            String type;

            switch(shipNumber)
            {
                case 1:
                    type = this.firstTypeValue.Text;

                    break;
                case 2:
                    type = this.secondTypeValue.Text;

                    break;
                case 3:
                    type = this.thirdTypeValue.Text;

                    break;
                case 4:
                    type = this.fourthTypeValue.Text;

                    break;
                default:
                    return null;
            }

            if (!Enum.TryParse(type, out ShipType ship))
            {
                return null;
            }

            return ShipFactory.GenerateShip(ship, this.InitShipSetupFromInput(shipNumber));
        }
        #endregion

        #region Events
        private void ValidateButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.ValidateShipFields() && this.ValidateMapFields() && this.ValidateShipTypes() && this.ValidateSizes() && this.ValidatePlayerName())
            {
                PlayerModel player = this.InitPlayerFromInput();
                ShipModel[] ships = new ShipModel[4];

                for (int i = 0; i < ships.Length; i++)
                {
                    ships[i] = this.InitShipFromInput(i + 1);
                }

                PlacementPage page = new PlacementPage(player, ships);

                (this.Parent as Window).Content = page;
            }
            else
            {
                String errorMessage = "The form contains the error above :\n";

                if (!this.ValidateShipFields())
                {
                    errorMessage += "The ship fields must only contains numbers above 0.\n";
                }
                if (!this.ValidateMapFields())
                {
                    errorMessage += "The map fields must only contains numbers above 0.\n";
                }
                if (!this.ValidateShipTypes())
                {
                    errorMessage += "The ship types must be set and unique (one of each).\n";
                }
                if (!this.ValidateSizes())
                {
                    errorMessage += "The total ship sizes cannot be bigger than the map ones.\n";
                }
                if (!this.ValidatePlayerName())
                {
                    errorMessage += "The player name should be filled.\n";
                }

                MessageBox.Show(errorMessage, "Error", System.Windows.MessageBoxButton.OK);
            }
        }
    }
    #endregion


}
