
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
    public AbstractShip[] GenerateShips()
    {
        // TODO implement here
        return null;
    }

    /// <summary>
    /// @param pos The array of positions of the ship to generate.
    /// @param shipType The type of ship to generate.
    /// @return The generated ship.
    /// </summary>
    public AbstractShip GenerateShip(int[] pos, ShipType shipType)
    {
        // TODO implement here
        return null;
    }
    #endregion

    #region Events
    #endregion
}