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
        #endregion

        #region Variables
        #endregion

        #region Attributes
        private ShipModel currentShip;
        private MapModel playerMap;
        #endregion

        #region Properties
        public ShipModel CurrentShip { get => currentShip; set => currentShip = value; }
        public MapModel PlayerMap { get => playerMap; set => playerMap = value; }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public PlacementPage()
        {
            InitializeComponent();
        }

        public PlacementPage(MapModel map)
        {
            InitializeComponent();

            this.PlayerMap = map;

            this.GenerateViewMap();
            this.PopulateMap();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        private void GenerateViewMap()
        {
            this.field.ShowGridLines = true;

            for (int i = 0; i < this.PlayerMap.Field.Length; i++)
            {
                this.field.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int j = 0; j < this.PlayerMap.Field[0].Length; j++)
            {
                this.field.RowDefinitions.Add(new RowDefinition());
            }
        }

        private void PopulateMap()
        {
            for (int row = 0; row < this.PlayerMap.Field.Length; row++)
            {
                for (int col = 0; col < this.PlayerMap.Field[0].Length; col++)
                {
                    Button button = new Button();

                    button.Name = String.Format("btnRow{0}Col{1}", row, col);
                    button.Click += new RoutedEventHandler(NewButton_Click);

                    this.field.Children.Add(button);

                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);
                }
            } 
        }
        #endregion

        #region Events
        private void NewButton_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
