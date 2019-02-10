
using BattleShip.Database;
using BattleShip.Database.DTO;
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
    private Boolean flag; 
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
    public static void DbSave(MapModel map) 
    {
        using (var db = new ApplicationDbContext())
        {
            db.Maps.Add(new MapDTO(map));
            db.SaveChanges();
        }
    }
    #endregion

    #region Events
    #endregion
}