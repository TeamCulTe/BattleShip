
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GameModel
{
    #region StaticVariables
    #endregion

    #region Constants
    #endregion

    #region Variables
    #endregion

    #region Attributes
    private int turn = 0;
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
    #endregion

    #region StaticFunctions
    #endregion

    #region Functions
    #endregion

    #region Events
    #endregion
}