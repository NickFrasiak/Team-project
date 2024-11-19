using System;

namespace Game10003;

public class Game
{
    // Setting Up Colors
    Color buildingColor = new Color(0x46, 0x47, 0x4c);

    // Calling classes 
    Buildings[] buildings = new Buildings[5];

    public void Setup()
    {
        // Set Window Size
        Window.SetSize(800, 600);

        // Set up initial buildings
        for (int i = 0; i < buildings.Length; i++)
        {
            Buildings building = new Buildings();
            building.color = buildingColor;
            building.buildingSize.X = 50;
            buildings[i] = building;
        }
    }

    public void Update()
    {
        Window.ClearBackground(Color.OffWhite);

        // Draw the buildings 5 times
        for (int i = 0; i < buildings.Length; i++)
        {
            // Draw and move buildings
            buildings[i].DrawBuildings();
            buildings[i].Move(buildings);
        }
    }


}
