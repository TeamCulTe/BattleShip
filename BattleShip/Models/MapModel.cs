
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
    public Boolean[][] Field { get => field; set => field = value; }
    public static MapSetupModel Setup { get => setup; set => setup = value; }
    #endregion

    #region Constructors
    /// <summary>
    /// Default constructor.
    /// </summary>
    public MapModel()
    {
        if (MapModel.Setup != null)
        {
            this.field = new Boolean[MapModel.Setup.Size[0]][];

            for (int j = 0; j < MapModel.Setup.Size[0]; j++)
            {
                this.field[j] = new Boolean[MapModel.Setup.Size[1]];
            }
        }
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
        String repr = String.Format("[MapModel] id : {0}", this.Id);

        if (this.Field != null)
        {
            repr += " - field : \n[";

            for (var i = 0; i < this.Field.Length; i++)
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
        }

        return repr;
    }
    #endregion

    #region Events
    #endregion
}