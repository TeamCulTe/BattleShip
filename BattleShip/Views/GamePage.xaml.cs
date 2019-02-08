using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace BattleShip.Views
{
    /// <summary>
    /// Logique d'interaction pour GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {// get by mapmodel 

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        #endregion

        #region Properties
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public GamePage()
        {
            InitializeComponent();

        }
     
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        #endregion

        #region Events
        #endregion
        /*    private void ResizeMap()
            {
                this.gameGrid.Children.Clear();
                this.gameGrid.ColumnDefinitions.Clear();
                this.gameGrid.RowDefinitions.Clear();

                for (int i = 0; i < this.MapHeight; i++)
                {
                    ColumnDefinition col = new ColumnDefinition();
                    this.gameGrid.ColumnDefinitions.Add(col);
                }

                for (int i = 0; i < this.MapWidth; i++)
                {
                    RowDefinition row = new RowDefinition();
                    this.gameGrid.RowDefinitions.Add(row);
                }

                Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < this.MapHeight; i++)
                    {
                        for (int j = 0; j < this.MapWidth; j++)
                        {
                            Application.Current.Dispatcher.Invoke(DispatcherPriority.Send, new ThreadStart(delegate
                            {
                                Button btn = new Button();
                                btn.Content = "H:" + i + "W:" + j;
                                Grid.SetColumn(btn, i);
                                Grid.SetRow(btn, j);

                                this.gameGrid.Children.Add(btn);
                            }));
                        }
                    }
                });
            }*/
    }
}
