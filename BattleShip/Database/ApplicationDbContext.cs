using BattleShip.Database.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Database
{
    public class ApplicationDbContext  : DbContext
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributes
        private DbSet<ShipDTO> ships;
        private DbSet<ShipSetupDTO> shipSetups;
        private DbSet<MapSetupDTO> mapSetups;
        private DbSet<GameDTO> games;
        private DbSet<MapDTO> maps;
        private DbSet<PlayerDTO> players;
        #endregion

        #region Properties
        public DbSet<ShipDTO> Ships { get => ships; set => ships = value; }
        public DbSet<ShipSetupDTO> ShipSetups { get => shipSetups; set => shipSetups = value; }
        public DbSet<MapSetupDTO> MapSetups { get => mapSetups; set => mapSetups = value; }
        public DbSet<GameDTO> Games { get => games; set => games = value; }
        public DbSet<MapDTO> Maps { get => maps; set => maps = value; }
        public DbSet<PlayerDTO> Players { get => players; set => players = value; }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ApplicationDbContext()
        {
            this.CheckDatabase();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        private void CheckDatabase()
        {
            if (!this.Database.CompatibleWithModel(false))
            {
                this.Database.Delete();
                this.Database.Create();
            }
        }
        #endregion

        #region Events
        #endregion


    }
}
