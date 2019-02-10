
using BattleShip.Database;
using BattleShip.Database.DTO;
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
    public static void DbSave(AbstractSetup setup)
    {
        using (var db = new ApplicationDbContext())
        {
            if (setup.GetType() == typeof(ShipSetupModel))
            {
                db.ShipSetups.Add(new ShipSetupDTO(setup as ShipSetupModel));
            }
            else if (setup.GetType() == typeof(MapSetupModel))
            {
                db.MapSetups.Add(new MapSetupDTO(setup as MapSetupModel));
            }

            db.SaveChanges();
        }
    }

    public static ShipSetupModel[] DbLoadLastShipsSetup()
    {
        using (var db = new ApplicationDbContext())
        {
            int setupNumber = 4;

            ShipSetupDTO[] setup = db.ShipSetups.OrderByDescending(s => s.CreatedAt)
                       .Take(setupNumber).ToArray();

            if (setup == null || setup.Length == 0)
            {
                return null;
            }

            String[] strSize;
            int[] size;
            ShipSetupModel[] setupModels = new ShipSetupModel[setupNumber];

            for (int i = 0; i < setupNumber; i++)
            {
                strSize = setup[i].Size.Split(';');
                size = new int[] { int.Parse(strSize[0]), int.Parse(strSize[1]) };
                setupModels[i] = new ShipSetupModel(setup[i].Name, size, setup[i].ShipNumber);
            }
            
            return setupModels;
        }
    }

    public static MapSetupModel DbLoadLastMapSetup()
    {
        using (var db = new ApplicationDbContext())
        {
            MapSetupDTO[] setup = db.MapSetups.OrderByDescending(s => s.CreatedAt)
                       .Take(1).ToArray();

            if (setup == null || setup.Length == 0)
            {
                return null;
            }

            String[] strSize = setup[0].Size.Split(';');
            int[] size = new int[] { int.Parse(strSize[0]), int.Parse(strSize[1]) };

            MapSetupModel.Dimensions = setup[0].Dimensions;

            return new MapSetupModel(setup[0].Name, size);
        }
    }
    #endregion

    #region Events
    #endregion
}