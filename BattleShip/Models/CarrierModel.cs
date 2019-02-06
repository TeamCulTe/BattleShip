
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CarrierModel : AbstractShip
{
    #region StaticVariables
    private static ShipSetupModel setup;
    #endregion

    #region Constants
    #endregion

    #region Variables
    #endregion

    #region Attributes
    #endregion

    #region Properties
    public static ShipSetupModel Setup { get => setup; set => setup = value; }
    #endregion

    #region Constructors
    /// <summary>
    /// Default constructor.
    /// </summary>
    public CarrierModel()
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