using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Database.DTO
{
    public class MapSetupDTO : AbstractSetupDTO
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributes
        private int dimensions;
        #endregion

        #region Properties
        public int Dimensions { get => dimensions; set => dimensions = value; }
        #endregion

        #region Constructors
        public MapSetupDTO()
        {

        }

        public MapSetupDTO(String name, String size, int dimensions) : base(name, size)
        {
            this.CreatedAt = DateTime.Now;
            this.dimensions = dimensions;
        }

        public MapSetupDTO(long id, DateTime createdAt, String name, String size, int dimensions) : base(id, createdAt, name, size)
        {
            this.dimensions = dimensions;
        }

        public MapSetupDTO(MapSetupModel setup)
        {
            this.CreatedAt = DateTime.Now;
            this.Name = setup.Name;
            this.Size = String.Format("{0};{1}", setup.Size[0], setup.Size[1]);
            this.dimensions = MapSetupModel.Dimensions;
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        override public String ToString()
        {
            String repr = String.Format("[MapSetup]\nid : {0} - name : {1} - size : {2} - dimensions : {3}", this.Id, this.Name, this.Size, this.Dimensions);

            return repr;
        }
        #endregion

        #region Events
        #endregion
    }
}
