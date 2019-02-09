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
    /// Logique d'interaction pour MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributes
        private PlayerModel player;
        private PlayerModel computer;
        #endregion

        #region Properties
        public PlayerModel Player { get => player; set => player = value; }
        public PlayerModel Computer { get => computer; set => computer = value; }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public MainPage(PlayerModel player, PlayerModel computer)
        {
            InitializeComponent();

            this.Player = player;
            this.Computer = computer;

            this.InitView();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        private void InitView()
        {
            this.playerName.Text = this.Player.Name;
            this.playerField.Map = this.Player.Map;

            this.playerField.PopulateGameMap();

            this.computerName.Text = this.Computer.Name;
            this.computerField.Map = this.Computer.Map;

            this.computerField.PopulateGameMap();
        }
        #endregion

        #region Events
        #endregion
    }
}
