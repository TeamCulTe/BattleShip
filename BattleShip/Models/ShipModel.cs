
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
    public ShipSetupModel Setup { get => setup; set => setup = value; }
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

    public ShipModel(string name, ShipSetupModel setup)
    {
        this.name = name;
        this.setup = setup;

        this.InitLocations();
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

    public ShipModel(ShipModel model)
    {
        this.name = model.Name;
        this.locations = model.Locations;
        this.setup = model.Setup;
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

    public Boolean IsPlaced()
    {
        for (int i = 0; i < this.locations.Length; i++)
        {
            for (int j = 0; j < this.locations[0].Length; j++)
            {
                if (this.locations[i][j] == -1)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public int GetWidth()
    {
        return this.setup.Size[0];
    }

    public int GetHeigh()
    {
        return this.setup.Size[1];
    }

    public int GetLocationIndexToDefine()
    {
        for (int i = 0; i < this.Locations.Length; i++)
        {
            if (this.Locations[i][0] == -1)
            {
                return i;
            }
        }

        return -1;
    }

    public Boolean LocationIsValid(int x, int y)
    {
        int currentLocation = this.GetLocationIndexToDefine();

        if (currentLocation == 0)
        {
            return true;
        }

        Boolean valid = false;

        if (currentLocation == -1 || x < 0 || y < 0)
        {
            return valid;
        }

        for (int i = 0; i < currentLocation; i++)
        {
            if (this.locations[i][0] - 1 == x || this.locations[i][0] + 1 == x)
            {
                if (this.locations[i][1] == y)
                {
                    if (!this.ReachedMaxWidth())
                    {
                        valid = true;

                        break;
                    }
                }
            }
            else if (this.locations[i][1] - 1 == y || this.locations[i][1] + 1 == y)
            {
                if (this.locations[i][0] == x)
                {
                    if (!this.ReachedMaxWidth())
                    {
                        valid = true;

                        break;
                    }
                }
            }
        }

        return valid;
    }

    private Boolean ReachedMaxWidth()
    {
        int i;

        for (i = 0; i < this.locations.Length; i++)
        {
            if (this.locations[i][0] != (this.locations[i + 1][0] - 1) && this.locations[i][0] != (this.locations[i + 1][0] + 1))
            {
                break;
            }
        }

        return i + 2 > this.GetWidth();
    }

    private Boolean ReachedMaxHeight()
    {
        int i;

        for (i = 0; i < this.locations.Length; i++)
        {
            if (this.locations[i][1] != (this.locations[i + 1][1] - 1) && this.locations[i][1] != (this.locations[i + 1][1] + 1))
            {
                break;
            }
        }

        return i + 2 > this.GetHeigh();
    }

    private void InitLocations()
    {
        int cellNumber = 1;

        for (int i = 0; i < this.setup.Size.Length; i++)
        {
            cellNumber *= this.setup.Size[i];
        }

        this.locations = new int[cellNumber][];

        for (int i = 0; i < this.locations.Length; i++)
        {
            this.locations[i] = new int[MapSetupModel.Dimensions];
        }

        for (int i = 0; i < this.locations.Length; i++)
        {
            for (int j = 0; j < this.locations[0].Length; j++)
            {
                this.locations[i][j] = -1;
            }
        }
    }

    override public String ToString()
    {
        String repr = String.Format("[ShipModel] id : {0} - name = {1} - damages : {2} - setups : {3}", this.Id, this.Name, this.Damages, this.Setup);

        if (this.Locations != null)
        {
            repr += "locations : [";

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
        }

        return repr;
    }
    #endregion

    #region Events
    #endregion
}