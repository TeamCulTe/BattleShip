
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

    public Boolean CheckPlacement(MapModel map, int[] location, ShipModel ship)
    {
        //  int direction = 
        //   if ( direction ==  vertical)
        

        for (int i = 0; i < ship.Setup.Size[0]; i++)
        {
            if (!((location[0] + 1) < ship.Setup.Size[0]))
            {
                flag = false; 
            }
        }
     //   else if direction == horizontale 
        for( int i = 0; i < ship.Setup.Size[1]; i++)
        {
            if (!((location[1] + 1) < ship.Setup.Size[1]))
            {
                flag = false;
            }
        }
        return flag;
    } 
            #endregion

            #region Events
            #endregion
        }