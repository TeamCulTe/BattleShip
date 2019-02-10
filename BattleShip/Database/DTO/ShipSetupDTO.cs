using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Database.DTO
{
    public class ShipSetupDTO : AbstractSetupDTO
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributes
        private int shipNumber;
        #endregion

        #region Properties
        public int ShipNumber { get => shipNumber; set => shipNumber = value; }
        #endregion

        #region Constructors
        public ShipSetupDTO()
        {

        }

        public ShipSetupDTO(String name, String size, int shipNumber) : base(name, size)
        {
            this.CreatedAt = DateTime.Now;
            this.ShipNumber = shipNumber;
        }

        public ShipSetupDTO(long id, DateTime createdAt, String name, String size, int shipNumber) : base(id, createdAt, name, size)
        {
            this.ShipNumber = shipNumber;
        }

        public ShipSetupDTO(ShipSetupModel setup)
        {
            this.CreatedAt = DateTime.Now;
            this.Name = setup.Name;
            this.Size = String.Format("{0};{1}", setup.Size[0], setup.Size[1]);
            this.shipNumber = setup.ShipNumber;
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        override public String ToString()
        {
            String repr = String.Format("[ShipSetup]\nid : {0} - name : {1} - size : {2} - shipNumber : {3}", this.Id, this.Name, this.Size, this.ShipNumber);

            return repr;
        }
        #endregion

        #region Events
        #endregion


    }
}
