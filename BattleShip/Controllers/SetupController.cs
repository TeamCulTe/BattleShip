
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SetupController
{
    #region StaticVariables
    #endregion

    #region Constants
    #endregion

    #region Variables
    #endregion

    #region Attributes
    #endregion

    #region Properties
    #endregion

    #region Constructors
    /// <summary>
    /// Default constructor.
    /// </summary>
    public SetupController()
    {

    }
    #endregion

    #region StaticFunctions
    #endregion

    #region Functions
    /// <summary>
    /// @param setup The setup to save into the database.
    /// </summary>
    public void DbSave(AbstractSetup setup)
    {
        // TODO implement here
    }

    /// <summary>
    /// @param id The id of the setup to load from database.
    /// @return The loaded setup.
    /// </summary>
    public AbstractSetup DbLoad(int id)
    {
        // TODO implement here
        return null;
    }

    /// <summary>
    /// @param name The name of the last setup to load from the database.
    /// @return The loaded setup.
    /// </summary>
    public AbstractSetup DbLoadLast(String name)
    {
        // TODO implement here
        return null;
    }
    #endregion

    #region Events
    #endregion
}