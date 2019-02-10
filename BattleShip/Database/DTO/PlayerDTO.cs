using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Database.DTO
{
    public class PlayerDTO : AbstractEntityDTO
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributes
        private String name;
        private MapDTO map;
        private List<ShipDTO> ships;
        private String targettedLocations = "";
        #endregion

        #region Properties
        public string Name { get => name; set => name = value; }
        public MapDTO Map { get => map; set => map = value; }
        public List<ShipDTO> Ships { get => ships; set => ships = value; }
        public String TargettedLocations { get => targettedLocations; set => targettedLocations = value; }
        #endregion

        #region Constructors
        public PlayerDTO()
        {
        }

        public PlayerDTO(string name, MapDTO map, List<ShipDTO> ships, String targettedLocations)
        {
            this.CreatedAt = DateTime.Now;
            this.name = name;
            this.map = map;
            this.ships = ships;
            this.targettedLocations = targettedLocations;
        }

        public PlayerDTO(long id, DateTime  createdAt, string name, MapDTO map, List<ShipDTO> ships, String targettedLocations) : base(id, createdAt)
        {
            this.name = name;
            this.map = map;
            this.ships = ships;
            this.targettedLocations = targettedLocations;
        }

        public PlayerDTO(PlayerModel player)
        {
            this.CreatedAt = DateTime.Now;
            this.name = player.Name;
            this.map = new MapDTO(player.Map);
            this.ships = new List<ShipDTO>();

            foreach (ShipModel ship in player.Ships)
            {
                this.ships.Add(new ShipDTO(ship));
            }

            for (int i = 0; i < player.TargettedLocations.Count; i++)
            {
                this.targettedLocations += String.Format("[{0};{1}]", player.TargettedLocations[i][0], player.TargettedLocations[i][1]);
            }
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        override public String ToString()
        {
            String repr = String.Format("[Player]\nid : {0} - name = {1}", this.Id, this.Name);

            if (this.Ships != null)
            {
                repr += " - ships : [";

                for (var i = 0; i < this.Ships.Count; i++)
                {
                    repr += this.Ships[i].ToString();

                    if (i == this.Ships.Count - 1)
                    {
                        repr += "] - targettedLocations : " + this.TargettedLocations;
                    }
                    else
                    {
                        repr += ", ";
                    }
                }
            }

            return repr;
        }
        #endregion

        #region Events
        #endregion
    }
}
