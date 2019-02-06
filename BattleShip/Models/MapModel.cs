
using BattleShip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MapModel : AbstractEntity
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
        // TODO Associate the setup.
    }

    public MapModel(bool[][] field)
    {
        this.field = field;
    }

    public MapModel(long id, bool[][] field) : base(id)
    {
        this.field = field;
    }
    #endregion

    #region StaticFunctions
    #endregion

    #region Functions
    public override string ToString()
    {
        String repr = String.Format("id : {0} - field : \n[", this.Id);

        for (var i = 0; i < this.field.Length; i++)
        {
            for (var j = 0; j < this.field[i].Length; j++)
            {
                repr += this.field[i][j];

                if (j != this.field[i].Length)
                {
                    repr += " ";
                }
            }

            repr += "\n";
        }

        return repr;
    }
    #endregion

    #region Events
    #endregion
}