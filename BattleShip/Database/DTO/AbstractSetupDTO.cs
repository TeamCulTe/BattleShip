using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Database.DTO
{
    public abstract class AbstractSetupDTO : AbstractEntityDTO
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributes
        private String name;
        private string size = "";
        #endregion

        #region Properties
        public string Name { get => name; set => name = value; }
        public string Size { get => size; set => size = value; }
        #endregion

        #region Constructors
        protected AbstractSetupDTO()
        {

        }

        protected AbstractSetupDTO(string name, String size)
        {
            this.name = name;
            this.size = size;
        }

        protected AbstractSetupDTO(long id, DateTime createdAt, string name, String size) : base(id, createdAt)
        {
            this.name = name;
            this.size = size;
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        #endregion

        #region Events
        #endregion
    }
}