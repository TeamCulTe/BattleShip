
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PlayerViewModel
{
    #region StaticVariables
    #endregion

    #region Constants
    #endregion

    #region Variables
    #endregion

    #region Attributes
    private PlayerModel player;
    #endregion

    #region Properties
    public PlayerModel Player { get => player; set => player = value; }
    #endregion

    #region Constructors
    /// <summary>
    /// Default constructor.
    /// </summary>
    public PlayerViewModel()
    {

    }
    #endregion

    #region StaticFunctions
    #endregion

    #region Functions
    public void DisplayShipsLeft()
    {
        // TODO implement here
    }
    #endregion

    #region Events
    #endregion
}