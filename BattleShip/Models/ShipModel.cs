
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
    private const int WIDTH = 0;
    private const int HEIGHT = 1;
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

    public int GetSize(int dimension)
    {
        if (dimension != 1 && dimension != 0)
        {
            throw new Exception("ValueError : The parameter should be an int between 0 and 1.");
        }

        return this.setup.Size[dimension];
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

        if (currentLocation == -1)
        {
            return valid;
        }

        int[] pos = new int[] { x, y };

        for (int i = 0; i < currentLocation; i++)
        {
            if (this.locations[i][0] - 1 == x || this.locations[i][0] + 1 == x)
            {
                if (this.locations[i][1] == y)
                {
                    if (!this.IsReachingMax(WIDTH, pos))
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
                    if (!this.IsReachingMax(HEIGHT, pos))
                    {
                        valid = true;

                        break;
                    }
                }
            }
        }

        return valid;
    }

    public Boolean ContainsLocation(int[] location)
    {
        for (int i = 0; i < this.locations.Length; i++)
        {
            if (this.locations[i][0] == -1)
            {
                continue;
            }

            if (location.SequenceEqual(this.locations[i]))
            {
                return true;
            }
        }

        return false;
    }

    public List<int[]> GetValidPositions()
    {
        List<int[]> positions = new List<int[]>();
        Random rdm = new Random();
        int[] rdmPos = MapModel.GetRandomPoints();
        int firstAxisRdmDirection = (rdm.Next(2) == 0) ? -1 : 1;
        int secondAxisRdmDirecton = (rdm.Next(2) == 0) ? -1 : 1;
        int rdmAxis = rdm.Next(2);
        int otherAxis = (rdmAxis == 0) ? 1 : 0;
        int iStop = rdmPos[rdmAxis] + (this.Setup.Size[rdmAxis] * firstAxisRdmDirection);
        int jStop = rdmPos[otherAxis] + (this.Setup.Size[otherAxis] * secondAxisRdmDirecton);

        if (iStop - firstAxisRdmDirection >= MapModel.Setup.Size[0] || iStop - firstAxisRdmDirection < 0 || 
            jStop - secondAxisRdmDirecton >= MapModel.Setup.Size[1] || jStop - secondAxisRdmDirecton < 0)
        {
            return null;
        }
        //Test here that rdm pos +/- size * offset > 0 && < map.size
        for (int i = rdmPos[rdmAxis]; i != iStop; i += firstAxisRdmDirection)
        {
            for (int j = rdmPos[otherAxis]; j != jStop; j += secondAxisRdmDirecton)
            {
                positions.Add(new int[] { i, j });
            }
        }

        return positions;
    }

    private int LocationsSet()
    {
        int result = 0;

        for (int i = 0; i < this.locations.Length; i++)
        {
            if (this.locations[i][0] != -1)
            {
                result += 1;
            }
        }

        return result;
    }

    private Boolean IsReachingMax(int dimension, int[] position)
    {
        if (dimension != 1 && dimension != 0)
        {
            throw new Exception("ValueError : The parameter should be an int between 0 and 1.");
        }

        int maxLocNumber = this.LocationsSet() + 1;
        int[] sameDimensionPoints = new int[maxLocNumber];
        int i;

        for (i = 0; i < maxLocNumber - 1; i ++)
        {
            sameDimensionPoints[i] = this.locations[i][dimension];
        }

        sameDimensionPoints[i] = position[dimension];

        int max = this.GetSize(dimension);

        return sameDimensionPoints.Distinct().Count() > max;
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