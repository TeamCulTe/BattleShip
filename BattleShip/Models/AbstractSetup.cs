
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class AbstractSetup
{
    #region StaticVariables
    #endregion

    #region Constants
    #endregion

    #region Variables
    #endregion

    #region Attributes
    private int[] size;
    private String name;
    private int id;
    #endregion

    #region Properties
    public int[] Size { get => size; set => size = value; }
    public string Name { get => name; set => name = value; }
    public int Id { get => id; set => id = value; }
    #endregion

    #region Constructors
    /// <summary>
    /// Default constructor.
    /// </summary>
    public AbstractSetup()
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