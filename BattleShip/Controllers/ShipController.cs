
using BattleShip.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ShipController
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
    public ShipController()
    {

    }
    #endregion

    #region StaticFunctions
    #endregion

    #region Functions
    /// <summary>
    /// @param ship The ship to damage.
    /// </summary>
    public void DamageShip(ShipModel ship)
    {
        // TODO implement here
    }

    /// <summary>
    /// @param pos The positions from which getting the ship.
    /// @return
    /// </summary>
    public ShipModel GetShipAtLocation(int[] pos)
    {
        // TODO See where to store the list of ships.
        return null;
    }

    /// <summary>
    /// @param ship The ship to save into the database.
    /// </summary>
    public void DbSave(ShipModel ship)
    {
        using (var dbContext = new ApplicationDbContext())
        {
            dbContext.ShipModels.Add(ship);
            dbContext.SaveChanges();
        }
    }
    #endregion

    #region Events
    #endregion
}