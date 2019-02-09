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

namespace BattleShip.UserControls
{
    /// <summary>
    /// Logique d'interaction pour CustomMapGrid.xaml
    /// </summary>
    public partial class CustomMapGrid : UserControl
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributes
        private MapModel map;
        private ICustomMapGridListener listener;
        #endregion

        #region Properties
        public MapModel Map
        {
            get
            {
                return map;
            }
            set
            {
                map = value;
                this.GenerateViewMap();
                this.PopulateMap();
            }
        }

        public ICustomMapGridListener Listener { get => listener; set => listener = value; }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public CustomMapGrid()
        {
            InitializeComponent();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public void PopulateMap()
        {
            for (int row = 0; row < this.Map.Field.Length; row++)
            {
                for (int col = 0; col < this.Map.Field[0].Length; col++)
                {
                    CustomMapButton button = new CustomMapButton();

                    button.Name = String.Format("btnRow{0}Col{1}", row, col);
                    button.X = col;
                    button.Y = row;

                    button.mapButton.Click += new RoutedEventHandler(MapButton_Click);

                    this.field.Children.Add(button);

                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);
                }
            }
        }

        public void PopulateGameMap()
        {
            for (int row = 0; row < this.Map.Field.Length; row++)
            {
                for (int col = 0; col < this.Map.Field[0].Length; col++)
                {
                    CustomMapButton button = new CustomMapButton();

                    button.Name = String.Format("btnRow{0}Col{1}", row, col);
                    button.X = col;
                    button.Y = row;

                    button.mapButton.Click += new RoutedEventHandler(GameMapButton_Click);

                    this.field.Children.Add(button);

                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);
                }
            }
        }
        private void GenerateViewMap()
        {
            this.field.ShowGridLines = true;

            for (int i = 0; i < this.Map.Field.Length; i++)
            {
                this.field.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int j = 0; j < this.Map.Field[0].Length; j++)
            {
                this.field.RowDefinitions.Add(new RowDefinition());
            }
        }
        #endregion

        #region Events
        private void MapButton_Click(object sender, EventArgs e)
        {
            if (this.listener != null)
            {
                this.listener.NotifyButtonClicked((sender as Button).Parent, e);
            }
        }

        private void GameMapButton_Click(object sender, EventArgs e)
        {
            CustomMapButton button = (sender as Button).Parent as CustomMapButton;

            if (this.map.Field[button.X][button.Y] == true)
            {
                button.SetShipImage();
            }
        }
        #endregion

        public interface ICustomMapGridListener
        {
            void NotifyButtonClicked(object sender, EventArgs e);
        }
    }
}
