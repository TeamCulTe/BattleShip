using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Database.DTO
{
    public class ShipDTO : AbstractEntityDTO
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributes
        private String name;
        private int damages;
        private String locations = "";
        private ShipSetupDTO setup;
        #endregion

        #region Properties
        public string Name { get => name; set => name = value; }
        public int Damages { get => damages; set => damages = value; }
        public String Locations { get => locations; set => locations = value; }
        public ShipSetupDTO Setup { get => setup; set => setup = value; }
        #endregion

        #region Constructors
        public ShipDTO()
        {
        }

        public ShipDTO(string name, String locations, ShipSetupDTO setup)
        {
            this.CreatedAt = DateTime.Now;
            this.name = name;
            this.locations = locations;
            this.setup = setup;
        }

        public ShipDTO(long id, DateTime createdAt, string name, String locations, ShipSetupDTO setup) : base(id, createdAt)
        {
            this.name = name;
            this.locations = locations;
            this.setup = setup;
        }

        public ShipDTO(ShipModel ship)
        {
            this.CreatedAt = DateTime.Now;
            this.name = ship.Name;

            for (int i = 0; i < ship.Locations.Length; i++)
            {
                this.locations += String.Format("[{0};{1}]", ship.Locations[i][0], ship.Locations[i][1]);
            }

            this.setup = new ShipSetupDTO(ship.Setup);
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        override public String ToString()
        {
            String repr = String.Format("[Ship]\nid : {0} - name = {1} - damages : {2} - setup : {3} - locations : {4}", 
                this.Id, 
                this.Name, 
                this.Damages, 
                this.Setup, 
                this.Locations);

            return repr;
        }
        #endregion

        #region Events
        #endregion
    }
}
