
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ShipFactory
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
    public ShipFactory()
    {
    }
    #endregion

    #region StaticFunctions
    #endregion

    #region Functions
    /// <summary>
    /// @return A list of initialized ships depending on the configuration for the IA player.
    /// </summary>
    public ShipModel[] GenerateShips()
    {
        // TODO implement here
        return null;
    }

    /// <summary>
    /// @param pos The array of positions of the ship to generate.
    /// @param shipType The type of ship to generate.
    /// @return The generated ship.
    /// </summary>
    public ShipModel GenerateShip(int[][] pos, ShipType shipType)
    {
        ShipSetupModel setup;
        // TODO Load the parameters depending on the ship category
        String name;

        switch (shipType)
        {
            case ShipType.CARRIER:
                name = "Carrier";

                break;
            case ShipType.SUBMARINE:
                name = "Carrier";

                break;
            case ShipType.DESTROYER:
                name = "Destroyer";

                break;
            case ShipType.BATTLESHIP:
                name = "Battleship";

                break;
            default:
                return null;
        }

        return new ShipModel(name, pos, null);
    }
    #endregion

    #region Events
    #endregion
}