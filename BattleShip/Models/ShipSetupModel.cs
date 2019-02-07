
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ShipSetupModel : AbstractSetup
{
    #region StaticVariables
    #endregion

    #region Constants
    #endregion

    #region Variables
    #endregion

    #region Attributes
    private int shipNumber;
    #endregion

    #region Properties
    public int ShipNumber { get => shipNumber; set => shipNumber = value; }
    #endregion

    #region Constructors
    /// <summary>
    /// Default constructor.
    /// </summary>
    public ShipSetupModel()
    {

    }
    public ShipSetupModel(string name, int[] size, int shipNumber) : base(name, size)
    {
        this.shipNumber = shipNumber;
    }
    #endregion

    #region StaticFunctions
    #endregion

    #region Functions
    override public String ToString()
    {
        String repr = String.Format("[ShipSetupModel] id : {0} - name : {1} - shipNumber : {2}", this.Id, this.Name, this.ShipNumber);

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