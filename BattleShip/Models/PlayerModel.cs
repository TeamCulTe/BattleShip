
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
    private String name;
    private MapModel map;
    private List<ShipModel> ships;
    private List<int[]> targettedLocations;
    #endregion

    #region Properties
    public string Name { get => name; set => name = value; }
    public MapModel Map { get => map; set => map = value; }
    public List<ShipModel> Ships { get => ships; set => ships = value; }
    public List<int[]> TargettedLocations { get => targettedLocations; set => targettedLocations = value; }
    #endregion

    #region Constructors
    public PlayerModel()
    {
    }

    public PlayerModel(string name, MapModel map)
    {
        this.name = name;
        this.map = map;
        this.ships = new List<ShipModel>();
        this.targettedLocations = new List<int[]>();
    }

    public PlayerModel(string name, MapModel map, List<ShipModel> ships)
    {
        this.name = name;
        this.map = map;
        this.ships = ships;
        this.targettedLocations = new List<int[]>();
    }

    public PlayerModel(string name, MapModel map, List<ShipModel> ships, List<int[]> targettedLocations)
    {
        this.name = name;
        this.map = map;
        this.ships = ships;
        this.targettedLocations = targettedLocations;
    }
    #endregion

    #region StaticFunctions
    #endregion

    #region Functions
    public Boolean IsAlive()
    {
        for (var i = 0; i < this.Ships.Count; i++)
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