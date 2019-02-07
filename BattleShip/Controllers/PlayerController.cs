
using BattleShip.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PlayerController
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
    public PlayerController()
    {
            
    }
    #endregion

    #region StaticFunctions
    #endregion

    #region Functions
    /// <summary>
    /// @param player
    /// </summary>
    public void DbSave(PlayerModel player)
    {
        using (var dbContext = new ApplicationDbContext())
        {
            dbContext.PlayerModels.Add(player);
            dbContext.SaveChanges();
        }
    }
    #endregion

    #region Events
    #endregion
}