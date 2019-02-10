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

namespace BattleShip.Views
{
    /// <summary>
    /// Logique d'interaction pour MainPage.xaml
    /// </summary>
    public partial class MainPage : Page, ICustomMapGridListener
    {

        #region StaticVariables
        #endregion

        #region Constants
        private const String LOG_FORMAT = "{0} hit on [{1}, {2}].\n";
        #endregion

        #region Variables
        #endregion

        #region Attributes
        private PlayerModel player;
        private PlayerModel computer;
        private int turn = 1;
        #endregion

        #region Properties
        public PlayerModel Player { get => player; set => player = value; }
        public PlayerModel Computer { get => computer; set => computer = value; }
        public int Turn { get => turn; set => turn = value; }
        #endregion

        #region Constructors
        public MainPage(PlayerModel player, PlayerModel computer)
        {
            InitializeComponent();

            this.Player = player;
            this.Computer = computer;

            this.playerField.Listener = this;
            this.computerField.Listener = this;

            this.InitView();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public void NotifyButtonClicked(object sender, EventArgs e)
        {
            CustomMapButton clicked = sender as CustomMapButton;
            CustomMapGrid field = clicked.Parent as CustomMapGrid;
            int[] position = new int[] { clicked.X, clicked.Y } ;

            clicked.IsEnabled = false;

            this.PlayTurn(position);
        }

        private Boolean CheckPlayers()
        {
            if (!this.Player.IsAlive())
            {
                this.EndGame(this.computer);

                return false;
            }
            else if (!this.Computer.IsAlive())
            {
                this.EndGame(this.Player);

                return false;
            }

            return true;
        }

        private void DisplayPlayerTurn()
        {
            if (this.turn % 2 == 0)
            {
                this.playerName.Background = Brushes.White;
                this.computerName.Background = Brushes.Green;
            }
            else
            {
                this.computerName.Background = Brushes.White;
                this.playerName.Background = Brushes.Green;
            }
        }

        private void PlayTurn(int[] pos)
        {
            String message = String.Format(LOG_FORMAT, this.player.Name, pos[0], pos[1]);
            ShipModel shot = PlayerController.HitAtPosition(pos, this.Computer);

            if (shot != null)
            {
                message += "Ship has been shot.\n";

                if (!shot.IsAlive())
                {
                    message += "The ship is down.";
                }
            }
            
            this.playerLog.Text = message;

            PlayerController.SaveShotPosition(pos, this.Player);
            this.Turn++;
            this.DisplayPlayerTurn();
            if (this.CheckPlayers())
            {
                int[] targetted = PlayerController.HitPlayerRandomly(this.Player);
                message = String.Format(LOG_FORMAT, this.computer.Name, targetted[0], targetted[1]);
                shot = PlayerController.HitAtPosition(targetted, this.Player);

                if (shot != null)
                {
                    message += "Ship has been shot.\n";

                    // SEE: Why this is not working...
                    (this.playerField.GetItemAtPosition(targetted) as CustomMapButton).SetFireImage();

                    if (!shot.IsAlive())
                    {
                        message += "The ship is down.";
                    }
                }

                this.computerLog.Text = message;

                PlayerController.SaveShotPosition(pos, this.Computer);
                this.Turn++;
                this.DisplayPlayerTurn();
                this.CheckPlayers();
            }
        }


        private void InitView()
        {
            this.playerName.Text = this.Player.Name;
            this.playerField.Map = this.Player.Map;

            this.playerField.PopulateGameMap(false);

            this.computerName.Text = this.Computer.Name;
            this.computerField.Map = this.Computer.Map;

            this.computerField.PopulateGameMap(true);
            this.DisplayPlayerTurn();
        }

        private void EndGame(PlayerModel winner)
        {
            GameController.DbSave(new GameModel(this.Turn/2, new PlayerModel[] { this.Player, this.Computer }));

            MessageBoxResult result = MessageBox.Show(String.Format("{0} won the game in {1} turns.\n Would you like to play aggain ?", winner.Name, this.Turn/2), 
                "Info", 
                System.Windows.MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                (this.Parent as Window).Content = new StartUpPage();
            } 
            else
            {
                System.Windows.Application.Current.Shutdown();
            }
        }
        #endregion

        #region Events
        #endregion
    }
}
