
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MapModel
{
    #region StaticVariables
    private static MapSetupModel setup;
    #endregion

    #region Constants
    #endregion

    #region Variables
    #endregion

    #region Attributes
    private Boolean[][] field;
    #endregion

    #region Properties
    public bool[][] Field { get => field; set => field = value; }
    public static MapSetupModel Setup { get => setup; set => setup = value; }
    #endregion

    #region Constructors
    /// <summary>
    /// Default constructor.
    /// </summary>
    public MapModel()
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