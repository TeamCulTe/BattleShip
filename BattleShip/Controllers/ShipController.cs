
using BattleShip.Database;
using BattleShip.Database.DTO;
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

    public static void DamageShip(ShipModel ship)
    {
        ship.Damages += 1;
    }

    public static ShipModel GetShipAtLocation(int[] pos, List<ShipModel> ships)
    {
        foreach (var ship in ships)
        {
            for (int i = 0; i < ship.Locations.Length; i++)
            {
                if (ship.Locations[i][0] == pos[0] && ship.Locations[i][1] == pos[1])
                {
                    return ship;
                }
            }
        }

        return null;
    }

    public static void DbSave(ShipModel ship)
    {
        using (var db = new ApplicationDbContext())
        {
            db.Ships.Add(new ShipDTO(ship));
            db.SaveChanges();
        }
    }
    #endregion

    #region Events
    #endregion
}