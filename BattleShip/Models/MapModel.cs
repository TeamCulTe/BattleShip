
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
    public Boolean[][] Field { get => field; set => field = value; }
    public static MapSetupModel Setup { get => setup; set => setup = value; }
    #endregion

    #region Constructors
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
    #endregion

    #region StaticFunctions
    #endregion

    #region Functions
    public static int[] GetRandomPoints()
    {
        if (MapModel.Setup == null)
        {
            return null;
        }
        else
        {
            Random rdm = new Random();

            return new int[] { rdm.Next(MapModel.Setup.Size[0]), rdm.Next(MapModel.Setup.Size[1]) };
        }
    }
    #endregion

    #region Events
    #endregion
}