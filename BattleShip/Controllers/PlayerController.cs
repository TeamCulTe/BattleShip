
using BattleShip.Database;
using BattleShip.Database.DTO;
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
    public static void DbSave(PlayerModel player)
    {
        using (var db = new ApplicationDbContext())
        {
            db.Players.Add(new PlayerDTO(player));
            db.SaveChanges();
        }
    }

    public static void PlaceShipsOnMap(PlayerModel player)
    {
        foreach (var ship in player.Ships)
        {
            for (int i = 0; i < ship.Locations.Length; i++)
            {
                int x = ship.Locations[i][0];
                int y = ship.Locations[i][1];

                player.Map.Field[x][y] = true;
            }
        }
    }

    public static PlayerModel GenerateIAPlayer(PlayerModel model)
    {
        PlayerModel computer = new PlayerModel("Computer", new MapModel());

        foreach (var ship in model.Ships)
        {
            computer.Ships.Add(ShipFactory.GenerateUnplacedCopy(ship));
        }
 
        ShipController.PlaceAllShipsRandomly(computer.Ships);
        PlayerController.PlaceShipsOnMap(computer);

        return computer;
    }

    public static int[] HitPlayerRandomly(PlayerModel player)
    {
        Random rdm = new Random();
        int[] targetLocation;

        do
        {
            targetLocation = new int[] { rdm.Next(MapModel.Setup.Size[0]), rdm.Next(MapModel.Setup.Size[1]) };
        } while (PlayerController.PositionAlreadyShot(targetLocation, player));

        PlayerController.HitAtPosition(targetLocation, player);

        return targetLocation;
    } 

    public static ShipModel HitAtPosition(int[] position, PlayerModel player)
    {
        foreach (var ship in player.Ships)
        {
            if (ship.ContainsLocation(position))
            {
                ShipController.DamageShip(ship);

                return ship;
            }
        }

        return null;
    }

    public static Boolean PositionAlreadyShot(int[] position, PlayerModel player)
    {
        foreach (var loc in player.TargettedLocations)
        {
            if (loc.SequenceEqual(position))
            {
                return true;
            }
        }

        return false;
    }

    public static void SaveShotPosition(int[] position, PlayerModel player)
    {
        player.TargettedLocations.Add(position);
    }
    #endregion

    #region Events
    #endregion
}