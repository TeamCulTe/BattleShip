
using BattleShip.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MapController
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
    public MapController()
    {
            
    }
    #endregion

    #region StaticFunctions
    #endregion

    #region Functions
    /// <summary>
    /// @param map The map to save into database.
    /// </summary>
    public void DbSave(MapModel map)
    {
        using (var dbContext = new ApplicationDbContext())
        {
            dbContext.MapModels.Add(map);
            dbContext.SaveChanges();
        }
    }
    #endregion

    #region Events
    #endregion
}