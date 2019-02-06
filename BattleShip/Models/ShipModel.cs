
using BattleShip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ShipModel : AbstractEntity
{
    #region StaticVariables
    #endregion

    #region Constants
    #endregion

    #region Variables
    #endregion

    #region Attributes
    private String name;
    private int damages;
    private int[][] locations;
    private ShipSetupModel setup;
    #endregion

    #region Properties
    public string Name { get => name; set => name = value; }
    public int Damages { get => damages; set => damages = value; }
    public int[][] Locations { get => locations; set => locations = value; }
    public ShipSetupModel Setup { get => setup; }
    #endregion

    #region Constructors
    /// <summary>
    /// Default constructor.
    /// </summary>
    public ShipModel()
    {
    }

    public ShipModel(string name, int[][] locations, ShipSetupModel setup)
    {
        this.name = name;
        this.locations = locations;
        this.setup = setup;
    }

    public ShipModel(long id, string name, int[][] locations, ShipSetupModel setup) : base(id)
    {
        this.name = name;
        this.locations = locations;
        this.setup = setup;
    }

    public ShipModel(long id, string name, int damages, int[][] locations, ShipSetupModel setup) : base(id)
    {
        this.name = name;
        this.locations = locations;
        this.setup = setup;
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

    override public String ToString()
    {
        String repr = String.Format("id : {0} - name = {1} - damages : {2} - setups : {3} locations : [", this.Id, this.Name, this.Damages, this.Setup);

        for (var i = 0; i < this.Locations.Length; i++)
        {
            for (var j = 0; j < this.Locations[i].Length; j++)
            {
                repr += "[" + this.Locations[i][j];

                if (j == this.Locations[i].Length - 1)
                {
                    repr += "]";
                }
                else
                {
                    repr += " ; ";
                }
            }

            if (i == this.Locations.Length - 1)
            {
                repr += "]";
            }
            else
            {
                repr += ", ";
            }
        }

        return repr;
    }
    #endregion

    #region Events
    #endregion
}