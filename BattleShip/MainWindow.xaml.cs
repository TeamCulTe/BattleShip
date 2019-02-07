using BattleShip.Database;
using BattleShip.Views;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            this.AddData();
            //this.getData();
            this.Content = new StartUpPage();
        }

        private void getData()
        {
            using (var dbContext = new ApplicationDbContext())
            {

                dbContext.Configuration.LazyLoadingEnabled = false;

                DbSet<GameModel> games = dbContext.GameModels;
                DbSet<ShipModel> ships = dbContext.ShipModels;
                DbSet<PlayerModel> players = dbContext.PlayerModels;
                DbSet<AbstractSetup> setups = dbContext.AbstractSetups;
                DbSet<MapModel> maps = dbContext.MapModels;

                foreach (var elt in games.Include(g => g.Players))
                {
                    Console.WriteLine(elt.ToString());
                }

                foreach (var elt in ships.Include(s => s.Locations).Include(s => s.Setup))
                {
                    Console.WriteLine(elt.ToString());
                }

                foreach (var elt in players.Include(p => p.Map).Include(p => p.Ships).Include(p => p.TargettedLocations))
                {
                    Console.WriteLine(elt.ToString());
                }

                foreach (var elt in setups)
                {
                    Console.WriteLine(elt.ToString());
                }

                foreach (var elt in maps.Include(m => m.Field))
                {
                    Console.WriteLine(elt.ToString());
                }
            }
        }

        private void AddData()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                Boolean[][] field = new Boolean[2][];
                field[0] = new Boolean[] { true, false };
                field[1] = new Boolean[] { false, false };

                int[] size = new int[] { 2, 3 };
                ShipSetupModel setup = new ShipSetupModel("setupShip", size, 3);

                int[][] pos = new int[2][];

                pos[0] = new int[] { 2, 1 };
                pos[1] = new int[] { 3, 2 };

                dbContext.AbstractSetups.Add(setup);

                ShipModel[] ships = new ShipModel[2];

                for (int i = 0; i < 2; i++)
                {
                    ships[i] = new ShipModel("ship" + i, pos, setup);
                }

                MapModel map = new MapModel(field);
                PlayerModel p = new PlayerModel("player", map, ships);
                GameModel game = new GameModel(8, new PlayerModel[1] { p });


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
}
