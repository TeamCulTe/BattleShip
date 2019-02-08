
using BattleShip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PlayerModel : AbstractEntity
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
    /// <summary>
    /// Default constructor.
    /// </summary>
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

    public PlayerModel(long id, string name, MapModel map, List<ShipModel> ships, List<int[]> targettedLocations) : base(id)
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
    /// <summary>
    /// @return True if the player have no ships left.
    /// </summary>
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

    override public String ToString()
    {
        String repr = String.Format("[PlayerModel] id : {0} - name = {1}", this.Id, this.Name);

        if (this.Ships != null)
        {
            repr += " - ships : [";

            for (var i = 0; i < this.Ships.Count; i++)
            {
                repr += this.Ships[i].ToString();

                if (i == this.Ships.Count - 1)
                {
                    repr += "] - targettedLocations : [";
                }
                else
                {
                    repr += ", ";
                }
            }

            for (var i = 0; i < this.TargettedLocations.Count; i++)
            {
                for (var j = 0; j < this.TargettedLocations[i].Length; j++)
                {
                    repr += "[" + this.TargettedLocations[i][j];

                    if (j == this.TargettedLocations[i].Length - 1)
                    {
                        repr += "]";
                    }
                    else
                    {
                        repr += " ; ";
                    }
                }

                if (i == this.TargettedLocations.Count - 1)
                {
                    repr += "]";
                }
                else
                {
                    repr += ", ";
                }
            }
        }

        return repr;
    }
    #endregion

    #region Events
    #endregion
}