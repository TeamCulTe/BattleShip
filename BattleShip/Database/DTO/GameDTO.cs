using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Database.DTO
{
    public class GameDTO : AbstractEntityDTO
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributes
        private int turn;
        private PlayerDTO player;
        private PlayerDTO computer;
        #endregion

        #region Properties
        public int Turn { get => turn; set => turn = value; }
        public PlayerDTO Player { get => player; set => player = value; }
        public PlayerDTO Computer { get => computer; set => computer = value; }
        #endregion

        #region Constructors
        public GameDTO()
        {
                    
        }

        public GameDTO(int turn, PlayerDTO player, PlayerDTO computer)
        {
            this.CreatedAt = DateTime.Now;
            this.turn = turn;
            this.player = player;
            this.computer = computer;
        }

        public GameDTO(long id, DateTime createdAt, int turn, PlayerDTO player, PlayerDTO computer) : base(id, createdAt)
        {
            this.turn = turn;
            this.player = player;
            this.computer = computer;
        }

        public GameDTO(GameModel game)
        {
            this.CreatedAt = DateTime.Now;
            this.turn = game.Turn;
            this.player = new PlayerDTO(game.Players[0]);
            this.computer = new PlayerDTO(game.Players[1]);
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public override string ToString()
        {
            String repr = String.Format("[Game]\nid : {0} - turn : {1}", this.Id, this.Turn);

            if (this.Player != null)
            {
                repr += " - player : " + this.Player.ToString();
            }

            if (this.Computer != null)
            {
                repr += " - computer : " + this.Computer.ToString();
            }

            return repr;
        }
        #endregion

        #region Events
        #endregion


    }
}
