
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
    public static Boolean PlaceShip(ShipModel ship, int[] pos)
    {
        int indexToDefine = ship.GetLocationIndexToDefine();
        Boolean placed = false;

        if (indexToDefine != -1)
        {
            if (ship.LocationIsValid(pos[0], pos[1]))
            {
                ship.Locations[indexToDefine] = pos;
                placed = true;
            }
        }

        return placed;
    }

    public static void PlaceShipRandomly(ShipModel ship)
    {
        List<int[]> positions = null;

        while (positions == null)
        {
            positions = ship.GetValidPositions();

            if (positions != null)
            {
                foreach (var position in positions)
                {
                    ShipController.PlaceShip(ship, position);
                }
            }
        }

        //return ship;
    }

    public static void PlaceAllShipsRandomly(List<ShipModel> ships)
    {
        foreach (var ship in ships)
        {
            List<int[]> positions = null;

            while (!ship.IsPlaced())
            {
                positions = ship.GetValidPositions();

                if (positions == null || !ShipController.PositionsAreNotTaken(positions, ships))
                {
                    continue;
                }

                foreach (var position in positions)
                {
                    ship.Locations[ship.GetLocationIndexToDefine()] = position;
                }
            }
        }
    }

    public static Boolean PositionsAreNotTaken(List<int[]> positions, List<ShipModel> ships)
    {
        foreach (var ship in ships)
        {
            foreach (var position in positions)
            {
                if (ship.ContainsLocation(position))
                {
                    return false;
                }
            }
        }

        return true;
    }

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