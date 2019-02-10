using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logique d'interaction pour CustomMapButton.xaml
    /// </summary>
    public partial class CustomMapButton : UserControl, INotifyPropertyChanged
    {

        #region StaticVariables
        public static String SHIP_IMAGE = "ship.jpg";
        public static String WATER_IMAGE = "water.jpg";
        public static String FIRE_IMAGE = "fire.png";
        public static String MISSED_IMAGE = "redCross.png";
        public static String RESOURCES_URI = "pack://application:,,,/BattleShip;component/Resources/";
        public static String SOUND = "denis_ha.wav";
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributes
        private int x;
        private int y;
        private BitmapImage image;
        #endregion

        #region Properties
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public BitmapImage Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged("Image");
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public CustomMapButton()
        {
            InitializeComponent();

            this.DataContext = this;
            this.Image = new BitmapImage(new Uri(RESOURCES_URI + WATER_IMAGE));
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public void SetShipImage()
        {
            this.Image = new BitmapImage(new Uri(RESOURCES_URI + SHIP_IMAGE));

            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri(RESOURCES_URI + SOUND));
            player.Play();
        }

        public void SetFireImage()
        {
            this.Image = new BitmapImage(new Uri(RESOURCES_URI + FIRE_IMAGE));

            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri(RESOURCES_URI + SOUND));
            player.Play();
        }

        public void SetMissedImage()
        {
            this.Image = new BitmapImage(new Uri(RESOURCES_URI + MISSED_IMAGE));

            //MediaPlayer player = new MediaPlayer();
            //player.Open(new Uri(RESOURCES_URI + SOUND));
            //player.Play();
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
