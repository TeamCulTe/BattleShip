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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BattleShip.Views
{
    /// <summary>
    /// Logique d'interaction pour PlacementPage.xaml
    /// </summary>
    public partial class PlacementPage : Page
    {

        #region StaticVariables
        #endregion

        #region Constants
        private const String FORMAT = "{0}";
        #endregion

        #region Variables
        #endregion

        #region Attributes
        private ShipModel currentShip;
        private Button clicked;
        private PlayerModel player;
        private ShipModel[] ships;
        #endregion

        #region Properties
        public ShipModel CurrentShip { get => currentShip; set => currentShip = value; }
        public PlayerModel Player { get => player; set => player = value; }
        public ShipModel[] Ships { get => ships; set => ships = value; }
        public Button Clicked { get => clicked; set => clicked = value; }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public PlacementPage()
        {
            InitializeComponent();
        }

        public PlacementPage(PlayerModel player, ShipModel[] ships)
        {
            InitializeComponent();

            this.Player = player;
            this.Ships = ships;

            this.InitShipItems();
            this.GenerateViewMap();
            this.PopulateMap();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        private void InitShipItems()
        {
            this.firstShipName.Text = this.Ships[0].Name;
            this.secondShipName.Text = this.Ships[1].Name;
            this.thirdShipName.Text = this.Ships[2].Name;
            this.fourthShipName.Text = this.Ships[3].Name;

            this.fisrtShipNumberLeft.Text = String.Format(FORMAT, this.Ships[0].Setup.ShipNumber);
            this.secondShipNumberLeft.Text = String.Format(FORMAT, this.Ships[1].Setup.ShipNumber);
            this.thirdShipNumberLeft.Text = String.Format(FORMAT, this.Ships[2].Setup.ShipNumber);
            this.fourthShipNumberLeft.Text = String.Format(FORMAT, this.Ships[3].Setup.ShipNumber);
        }

        private Boolean AllShipPlaced()
        {
            int shipToBePlaced = 0;

            for (int i = 0; i < this.ships.Length; i++)
            {
                shipToBePlaced += this.ships[i].Setup.ShipNumber;
            }

            return this.player.Ships.Count == shipToBePlaced;
        }

        private void OnShipPlaced()
        {
            if (currentShip != null)
            {
                int i;

                for (i = 0; i < this.ships.Length; i++)
                {
                    if (this.ships[i].Name == this.currentShip.Name)
                    {
                        break;
                    }
                }

                int left;

                switch (i)
                {
                    case 0:
                        left = int.Parse(this.fisrtShipNumberLeft.Text) - 1;
                        this.fisrtShipNumberLeft.Text = String.Format(FORMAT, left);

                        break;
                    case 1:
                        left = int.Parse(this.secondShipNumberLeft.Text) - 1;
                        this.secondShipNumberLeft.Text = String.Format(FORMAT, left);

                        break;
                    case 2:
                        left = int.Parse(this.thirdShipNumberLeft.Text) - 1;
                        this.thirdShipNumberLeft.Text = String.Format(FORMAT, left);

                        break;
                    case 3:
                        left = int.Parse(this.fourthShipNumberLeft.Text) - 1;
                        this.fourthShipNumberLeft.Text = String.Format(FORMAT, left);

                        break;
                    default:
                        return;
                }
                
                this.Player.Ships.Add(this.CurrentShip);

                if (left == 0)
                {
                    this.clicked.IsEnabled = false;
                    this.clicked.Background = Brushes.Red;
                    this.currentShip = null;
                }
                else
                {
                    this.currentShip = ShipFactory.GenerateUnplacedCopy(this.currentShip);
                }

                if (this.AllShipPlaced())
                {
                    PlayerController.PlaceShipsOnMap(this.player);
                    MessageBox.Show("All ship have been placed, you can now click on validate to start the game.", "Info", System.Windows.MessageBoxButton.OK);
                }
            }
        }

        private void GenerateViewMap()
        {
            this.field.ShowGridLines = true;

            for (int i = 0; i < this.Player.Map.Field.Length; i++)
            {
                this.field.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int j = 0; j < this.Player.Map.Field[0].Length; j++)
            {
                this.field.RowDefinitions.Add(new RowDefinition());
            }
        }

        private void PopulateMap()
        {
            for (int row = 0; row < this.Player.Map.Field.Length; row++)
            {
                for (int col = 0; col < this.Player.Map.Field[0].Length; col++)
                {
                    Button button = new Button();

                    button.Name = String.Format("btnRow{0}Col{1}", row, col);
                    button.Click += new RoutedEventHandler(MapButton_Click);
                    button.Background = Brushes.Aqua;

                    this.field.Children.Add(button);

                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);
                }
            } 
        }

        private int getShipIndex(Button shipButton)
        {
            int shipIndex;

            switch (shipButton.Name)
            {
                case "firstShipButton":
                    shipIndex = 0;

                    break;
                case "secondShipButton":
                    shipIndex = 1;

                    break;
                case "thirdShipButton":
                    shipIndex = 2;

                    break;
                case "fourthShipButton":
                    shipIndex = 3;

                    break;
                default:
                    return -1;
            }

            return shipIndex;
        }

        private int[] GetButtonPosition(Button btn)
        {
            return new int[] { Grid.GetColumn(btn), Grid.GetRow(btn) };
        }
        #endregion

        #region Events
        private void ShipName_Click(object sender, RoutedEventArgs e)
        {
            Button current = (sender as Button);
            int shipIndex = this.getShipIndex(current);

            if (this.clicked != null && this.currentShip != null && !this.currentShip.IsPlaced())
            {
                this.clicked.IsEnabled = true;
                this.clicked.Background = Brushes.Aqua;
            }

            this.clicked = current;
            this.clicked.IsEnabled = false;
            this.clicked.Background = Brushes.Green;
            this.CurrentShip = this.Ships[shipIndex];
        }

        private void MapButton_Click(object sender, EventArgs e)
        {
            Button current = sender as Button;

            if (this.CurrentShip == null)
            {
                return;
            }

            int[] pos = this.GetButtonPosition(current);

            if (!ShipController.PlaceShip(this.currentShip, pos))
            {
                String errorMessage = "The ship cannot be placed here.\n";

                if (this.currentShip.IsPlaced())
                {
                    errorMessage += "The ship positions are all defined for this ship.\n";
                }

                MessageBox.Show(errorMessage, "Error", System.Windows.MessageBoxButton.OK);
            }
            else
            {
                current.IsEnabled = false;
                current.Background = Brushes.Red;

                if (this.currentShip.IsPlaced())
                {
                    this.OnShipPlaced();
                }
            }
        }

        private void ValidateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!this.AllShipPlaced())
            {
                MessageBox.Show("All ships should be placed to start the game.", "Error", System.Windows.MessageBoxButton.OK);
            }
            else
            {
                PlayerModel computer = PlayerController.GenerateIAPlayer(this.player);
            }
        }
        #endregion
    }
}
