
using BattleShip.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GameController
{
    #region StaticVariables
    #endregion

    #region Constants
    #endregion

    #region Variables
    #endregion

    #region Attributes
    #endregion

    #region Properties
    #endregion

    #region Constructors
    /// <summary>
    /// Default constructor.
    /// </summary>
    public GameController()
    {
            
    }
    #endregion

    #region StaticFunctions
    #endregion

    #region Functions
    /// <summary>
    /// @param game
    /// </summary>
    public void DbSave(GameModel game)
    {
        using (var dbContext = new ApplicationDbContext())
        {
            dbContext.GameModels.Add(game);
            dbContext.SaveChanges();
        }
    }
    #endregion

    #region Events
    #endregion
}