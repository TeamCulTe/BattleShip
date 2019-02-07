
using BattleShip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GameModel : AbstractEntity
{
    #region StaticVariables
    #endregion

    #region Constants
    #endregion

    #region Variables
    #endregion

    #region Attributes
    private int turn;
    private PlayerModel[] players;
    #endregion

    #region Properties
    public int Turn { get => turn; set => turn = value; }
    public PlayerModel[] Players { get => players; set => players = value; }
    #endregion

    #region Constructors
    /// <summary>
    /// Default constructor.
    /// </summary>
    public GameModel()
    {

    }

    public GameModel(PlayerModel[] players)
    {
        this.Players = players;
    }

    public GameModel(int turn, PlayerModel[] players)
    {
        this.Turn = turn;
        this.Players = players;
    }

    public GameModel(long id, int turn, PlayerModel[] players) : base(id)
    {
        this.Turn = turn;
        this.Players = players;
    }
    #endregion

    #region StaticFunctions
    #endregion

    #region Functions
    public override string ToString()
    {
        String repr = String.Format("id : {0} - turn : {1}", this.Id, this.Turn);

        if (this.Players != null)
        {
            repr += "-players : [";

            for (var i = 0; i < this.Players.Length; i++)
            {
                repr += this.Players[i].ToString();

                if (i == this.Players.Length - 1)
                {
                    repr += "]";
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