
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MapSetupModel : AbstractSetup
{
    #region StaticVariables
    private static int dimensions = 2;
    #endregion

    #region Constants
    #endregion

    #region Variables
    #endregion

    #region Attributes
    #endregion

    #region Properties
    public static int Dimensions { get => dimensions; set => dimensions = value; }
    #endregion

    #region Constructors
    public MapSetupModel()
    {

    }

    public MapSetupModel(int[] size) : base("MapSetup", size)
    {
    }

    public MapSetupModel(string name, int[] size) : base (name, size)
    {
    }
    #endregion

    #region StaticFunctions
    #endregion

    #region Functions
    #endregion

    #region Events
    #endregion
}