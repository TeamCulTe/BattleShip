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
        private DbSet<ShipModel> shipModels;
        private DbSet<AbstractSetup> abstractSetups;
        private DbSet<GameModel> gameModels;
        private DbSet<MapModel> mapModels;
        private DbSet<PlayerModel> playerModels;
        #endregion

        #region Properties
        public DbSet<ShipModel> ShipModels { get => shipModels; set => shipModels = value; }
        public DbSet<AbstractSetup> AbstractSetups { get => abstractSetups; set => abstractSetups = value; }
        public DbSet<GameModel> GameModels { get => gameModels; set => gameModels = value; }
        public DbSet<MapModel> MapModels { get => mapModels; set => mapModels = value; }
        public DbSet<PlayerModel> PlayerModels { get => playerModels; set => playerModels = value; }
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
