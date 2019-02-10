using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Database.DTO
{
    public abstract class AbstractEntityDTO
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributes
        [Key]
        private long id;
        [Column(TypeName = "date")]
        private DateTime createdAt;
        #endregion

        #region Properties
        public long Id { get => id; set => id = value; }
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }
        #endregion

        #region Constructors
        protected AbstractEntityDTO()
        {

        }

        protected AbstractEntityDTO(long id)
        {
            this.Id = id;
            this.CreatedAt = DateTime.Now;
        }

        protected AbstractEntityDTO(long id, DateTime createdAt)
        {
            this.id = id;
            this.createdAt = createdAt;
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
