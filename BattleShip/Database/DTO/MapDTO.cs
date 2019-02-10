using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Database.DTO
{
    public class MapDTO : AbstractEntityDTO
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributes
        private String field = "";
        private MapSetupDTO setup;
        #endregion

        #region Properties
        public string Field { get => field; set => field = value; }
        public MapSetupDTO Setup { get => setup; set => setup = value; }
        #endregion

        #region Constructors
        public MapDTO()
        {

        }

        public MapDTO(string field)
        {
            this.CreatedAt = DateTime.Now;
            this.field = field;
        }

        public MapDTO(long id, DateTime createdAt, string field, MapSetupDTO setup) : base(id, createdAt)
        {
            this.field = field;
            this.setup = setup;
        }

        public MapDTO(MapModel map)
        {
            this.CreatedAt = DateTime.Now;

            for (int i = 0; i < map.Field.Length; i++)
            {
                for (int j = 0; j < map.Field[0].Length; j++)
                {
                    this.field += map.Field[i][j].ToString();
                }

                this.field += "\n";
            }

            this.setup = new MapSetupDTO(MapModel.Setup);
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public override string ToString()
        {
            String repr = String.Format("[Map]\nid : {0} - field : {1} - setup : {2}", this.Id, this.Field, this.Setup);

            return repr;
        }
        #endregion

        #region Events
        #endregion
    }
}
