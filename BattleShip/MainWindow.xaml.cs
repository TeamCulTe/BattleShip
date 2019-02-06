using BattleShip.Database;
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

namespace BattleShip
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ApplicationDbContext dbContext = new ApplicationDbContext();
            Boolean[][] field = new Boolean[2][];
            field[0] = new Boolean[] { true, false };
            field[1] = new Boolean[] { false, false };

            int[] size = new int[] { 2, 3 };
            ShipSetupModel setup = new ShipSetupModel("setupShip", size, 3);

            int[][] pos = new int[2][];

            pos[0] = new int[] { 2, 1 };
            pos[1] = new int[] { 3, 2 };

            ShipModel[] ships = new ShipModel[2];
            for (int i = 0; i < 2; i++)
            {
                ships[i] = new ShipModel("ship" + i, pos, setup);
            }
        
            MapModel map = new MapModel(field);
            PlayerModel p = new PlayerModel("player", map, ships);
            GameModel game = new GameModel(new PlayerModel[] {p});

            dbContext.AbstractSetups.Add(setup);
            for (int i = 0; i < 2; i++)
            {
                dbContext.ShipModels.Add(ships[i]);
            }
            dbContext.MapModels.Add(map);
            dbContext.PlayerModels.Add(p);
            dbContext.GameModels.Add(game);

            dbContext.SaveChanges();
        }
    }
}
