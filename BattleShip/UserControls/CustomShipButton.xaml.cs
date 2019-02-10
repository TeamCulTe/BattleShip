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
    public partial class CustomShipButton : UserControl
    {
        #region StaticVariables
        #endregion

        #region Constants
        private const String FORMAT = "{0} left";
        #endregion

        #region Variables
        #endregion

        #region Attributes
        private ShipModel model;
        private int shipsToPlace;
        private TextBlock shipNumberLabel;
        private ICustomShipButtonListener listener;
        #endregion

        #region Properties
        public ShipModel Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;

                this.ShipsToPlace = model.Setup.ShipNumber;
                this.shipInfo.Text = String.Format("{0}\nx:{1} - y:{2}", model.Name, model.Setup.Size[0], model.Setup.Size[1]);
            }
        }
        public int ShipsToPlace
        {
            get
            {
                return shipsToPlace;
            }
            set
            {
                shipsToPlace = value;

                if (this.ShipNumberLabel != null)
                {
                    this.ShipNumberLabel.Text = String.Format(FORMAT, shipsToPlace);
                }

                if (shipsToPlace == 0)
                {
                    this.shipButton.IsEnabled = false;
                    this.shipButton.Background = Brushes.Red;
                }
            }
        }
        public ICustomShipButtonListener Listener { get => listener; set => listener = value; }
        public TextBlock ShipNumberLabel
        {
            get
            {
                return shipNumberLabel;
            }
            set
            {
                shipNumberLabel = value;

                shipNumberLabel.Text = String.Format(FORMAT, shipsToPlace);
            }
        }
        #endregion

            #region Constructors
        public CustomShipButton()
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

        private void ShipButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.Listener != null)
            {
                this.Listener.ShipButtonClicked(this);
            }
        }

        public interface ICustomShipButtonListener
        {
            void ShipButtonClicked(CustomShipButton sender);
        }
    }
}
