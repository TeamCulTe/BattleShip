
using BattleShip.Database;
using BattleShip.Database.DTO;
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
    public static void DbSave(GameModel game)
    {
        using (var db = new ApplicationDbContext())
        {
            db.Games.Add(new GameDTO(game));
            db.SaveChanges();
        }
    }
    #endregion

    #region Events
    #endregion
}