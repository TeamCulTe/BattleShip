
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SubmarineModel : AbstractShip
{
    #region StaticVariables
    #endregion

    #region Constants
    #endregion

    #region Variables
    #endregion

    #region Attributes
    private static ShipSetupModel setup;
    #endregion

    #region Properties
    public static ShipSetupModel Setup { get => setup; set => setup = value; }
    #endregion

    #region Constructors
    /// <summary>
    /// Default constructor.
    /// </summary>
    public SubmarineModel()
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