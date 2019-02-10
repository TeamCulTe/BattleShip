using BattleShip.UserControls;
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
using static BattleShip.UserControls.CustomMapGrid;
using static BattleShip.UserControls.CustomShipButton;

namespace BattleShip.Views
{
    /// <summary>
    /// Logique d'interaction pour PlacementPage.xaml
    /// </summary>
    public partial class PlacementPage : Page, ICustomMapGridListener, ICustomShipButtonListener
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributes
        private ShipModel currentShip;
        private PlayerModel player;
        private ShipModel[] ships;
        #endregion

        #region Properties
        public ShipModel CurrentShip { get => currentShip; set => currentShip = value; }
        public PlayerModel Player { get => player; set => player = value; }
        public ShipModel[] Ships { get => ships; set => ships = value; }
        #endregion

        #region Constructors
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

            this.field.Listener = this;
            this.field.Map = this.player.Map;

            this.field.PopulateMap();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public void NotifyButtonClicked(object sender, EventArgs e)
        {
            CustomMapButton current = sender as CustomMapButton;

            if (this.CurrentShip == null)
            {
                return;
            }

            int[] pos = new int[] { current.X, current.Y};

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
                current.SetShipImage();
                current.mapButton.IsEnabled = false;

                if (this.currentShip.IsPlaced())
                {
                    this.OnShipPlaced();
                }
            }
        }

        public void ShipButtonClicked(CustomShipButton button)
        {            
            this.CurrentShip = button.Model;
        }

        private void InitShipItems()
        {
            this.firstShipButton.Listener = this;
            this.secondShipButton.Listener = this;
            this.thirdShipButton.Listener = this;
            this.fourthShipButton.Listener = this;

            this.firstShipButton.Model = this.Ships[0];
            this.secondShipButton.Model = this.Ships[1];
            this.thirdShipButton.Model = this.Ships[2];
            this.fourthShipButton.Model = this.Ships[3];

            this.firstShipButton.ShipNumberLabel = this.fisrtShipNumberLeft;
            this.secondShipButton.ShipNumberLabel = this.secondShipNumberLeft;
            this.thirdShipButton.ShipNumberLabel = this.thirdShipNumberLeft;
            this.fourthShipButton.ShipNumberLabel = this.fourthShipNumberLeft;
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
            if (this.CurrentShip != null)
            {
                CustomShipButton button;

                if (CurrentShip.Name == this.firstShipButton.Model.Name)
                {
                    button = this.firstShipButton;
                }
                else if (CurrentShip.Name == this.secondShipButton.Model.Name)
                {
                    button = this.secondShipButton;
                }
                else if (CurrentShip.Name == this.thirdShipButton.Model.Name)
                {
                    button = this.thirdShipButton;
                }
                else if (CurrentShip.Name == this.fourthShipButton.Model.Name)
                {
                    button = this.fourthShipButton;
                }
                else
                {
                    return;
                }

                button.ShipsToPlace = button.ShipsToPlace - 1;

                this.Player.Ships.Add(this.CurrentShip);

                this.currentShip = (button.ShipsToPlace == 0) ? null : this.currentShip = ShipFactory.GenerateUnplacedCopy(this.currentShip);


                if (this.AllShipPlaced())
                {
                    PlayerController.PlaceShipsOnMap(this.player);
                    MessageBox.Show("All ship have been placed, you can now click on validate to start the game.", "Info", System.Windows.MessageBoxButton.OK);
                }
            }
        }

        #endregion

        #region Events
        private void ValidateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!this.AllShipPlaced())
            {
                MessageBox.Show("All ships should be placed to start the game.", "Error", System.Windows.MessageBoxButton.OK);
            }
            else
            {
                PlayerModel computer = PlayerController.GenerateIAPlayer(this.player);

                MapController.DbSave(this.player.Map);
                MapController.DbSave(computer.Map);
                PlayerController.DbSave(this.Player);
                PlayerController.DbSave(computer);

                MainPage page = new MainPage(this.Player, computer);

                (this.Parent as Window).Content = page;
            }
        }
        #endregion
    }
}
