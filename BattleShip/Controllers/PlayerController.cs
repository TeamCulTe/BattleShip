
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

        foreach (var ship in computer.Ships)
        {
            ShipController.PlaceShipRandomly(ship); 
        }

        return computer;
    }
    #endregion

    #region Events
    #endregion
}