
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ShipSetupModel : AbstractSetup
{
    #region StaticVariables
    #endregion

    #region Constants
    #endregion

    #region Variables
    #endregion

    #region Attributes
    private int shipNumber;
    #endregion

    #region Properties
    public int ShipNumber { get => shipNumber; set => shipNumber = value; }
    #endregion

    #region Constructors
    /// <summary>
    /// Default constructor.
    /// </summary>
    public ShipSetupModel()
    {

    }
    public ShipSetupModel(int[] size, int shipNumber) : base("ShipSetup", size)
    {
        this.shipNumber = shipNumber;
    }

    public ShipSetupModel(string name, int[] size, int shipNumber) : base(name, size)
    {
        this.shipNumber = shipNumber;
    }
    #endregion

    #region StaticFunctions
    #endregion

    #region Functions
    #endregion

    #region Events
    #endregion
}