
using BattleShip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class AbstractSetup : AbstractEntity
{
    #region StaticVariables
    #endregion

    #region Constants
    #endregion

    #region Variables
    #endregion

    #region Attributes
    private String name;
    private int[] size;
    #endregion

    #region Properties
    public string Name { get => name; set => name = value; }
    public int[] Size { get => size; set => size = value; }
    #endregion

    #region Constructors
    /// <summary>
    /// Default constructor.
    /// </summary>
    public AbstractSetup()
    {
            
    }

    protected AbstractSetup(string name, int[] size)
    {
        this.name = name;
        this.size = size;
    }

    protected AbstractSetup(long id, string name, int[] size) : base(id)
    {
        this.name = name;
        this.size = size;
    }
    #endregion

    #region StaticFunctions
    #endregion

    #region Functions
    #endregion

    #region Events
    #endregion
}