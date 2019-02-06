
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class AbstractShip
{
    #region StaticVariables
    #endregion

    #region Constants
    #endregion

    #region Variables
    #endregion

    #region Attributes
    private int id;
    private String name;
    private int damages;
    private int[][] locations;
    #endregion

    #region Properties
    public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public int Damages { get => damages; set => damages = value; }
    public int[][] Locations { get => locations; set => locations = value; }
    #endregion

    #region Constructors
    /// <summary>
    /// Default constructor.
    /// </summary>
    public AbstractShip()
    {

    }
    #endregion

    #region StaticFunctions
    #endregion

    #region Functions
    /// <summary>
    /// @return True if the ship isn't destroyed else false.
    /// </summary>
    public Boolean IsAlive()
    {
        return this.Damages > this.Locations.Length;
    }
    #endregion

    #region Events
    #endregion
}