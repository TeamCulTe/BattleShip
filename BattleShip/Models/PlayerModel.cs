
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PlayerModel
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
    private MapModel map;
    private AbstractShip[] ships;
    private int[][] targettedLocations;
    #endregion

    #region Properties
    public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public MapModel Map { get => map; set => map = value; }
    public AbstractShip[] Ships { get => ships; set => ships = value; }
    public int[][] TargettedLocations { get => targettedLocations; set => targettedLocations = value; }
    #endregion

    #region Constructors
    /// <summary>
    /// Default constructor.
    /// </summary>
    public PlayerModel()
    {

    }
    #endregion

    #region StaticFunctions
    #endregion

    #region Functions
    /// <summary>
    /// @return True if the player have no ships left.
    /// </summary>
    public Boolean IsAlive()
    {
        for (var i = 0; i < this.Ships.Length; i++)
        {
            if (this.Ships[i].IsAlive())
            {
                return true;
            }
        }

        return false;
    }
    #endregion

    #region Events
    #endregion
}