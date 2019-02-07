
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
    /// <summary>
    /// Default constructor.
    /// </summary>
    public MapSetupModel()
    {

    }

    public MapSetupModel(string name, int[] size) : base (name, size)
    {
    }
    #endregion

    #region StaticFunctions
    #endregion

    #region Functions
    override public String ToString()
    {
        String repr = String.Format("[MapSetupModel] id : {0} - name : {1} - dimensions : {2}", this.Id, this.Name, MapSetupModel.Dimensions);

        if (this.Size != null)
        {
            repr += " - size : [";

            for (var i = 0; i < this.Size.Length; i++)
            {
                repr += this.Size[i];

                if (i == this.Size.Length - 1)
                {
                    repr += "]";
                }
                else
                {
                    repr += ", ";
                }
            }
        }

        return repr;
    }
    #endregion

    #region Events
    #endregion
}