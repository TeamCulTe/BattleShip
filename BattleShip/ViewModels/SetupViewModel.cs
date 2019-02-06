
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SetupViewModel
{

    public SetupViewModel() {
    }

    /// <summary>
    /// @param name The name of the setup
    /// @param size The x and y sizes.
    /// @param number The number of ship.
    /// @return The setup associated to the inputs.
    /// </summary>
    public ShipSetupModel GetShipSetup(String name, int[] size, int number) {
        // TODO implement here
        return null;
    }

    /// <summary>
    /// @param name The name of the setup
    /// @param size The x and y sizes.
    /// @param dimensions The number of dimensions of the game.
    /// @return The setup associated.
    /// </summary>
    public MapSetupModel GetMapSetups(String name, int[] size, int dimensions) {
        // TODO implement here
        return null;
    }

}