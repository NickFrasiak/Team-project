using System;
using System.Numerics;

namespace Game10003;
public class Buildings
{
    // Setting up variables
    public Vector2 buildingPosition;
    public Vector2 buildingSize;
    public Color color;
    public Vector2 buildingSpeed = new Vector2(200, 0);

    public void DrawBuildings()
    {
        // Draw building onto screen
        Draw.FillColor = color;
        Draw.LineSize = 0;
        Draw.Rectangle(buildingPosition, buildingSize);
    }

    public void Move(Buildings[] buildingsArray)
    {
        // Move building left 
        buildingPosition.X -= buildingSpeed.X * Time.DeltaTime;

        // Reset the building's position if it goes past -100 pixels
        if (buildingPosition.X < -100)
        {
            // Randomize the building's height between 50 and 130 pixels
            buildingSize.Y = Random.Float(50, 130);
            
            // Set initial position for the newer building to 800 pixels
            float originalPosition = 800;

            // Distingush a refercnes to the building being processed 
            Buildings movingBuilding = this;

            // Loop through all buildings to making sure there is playable spacing for player to jump
            for (int i = 0; i < buildingsArray.Length; i++)
            {
                // Call another building inside of the array
                Buildings anotherBuilding = buildingsArray[i];

                // Dont comparing the other building with itself
                if (anotherBuilding != movingBuilding)
                {
                    // Add up the position of the other building that is dislpayed then a random gap from 300 to 400 pixels
                    float nextBuildingEndPosition = anotherBuilding.buildingPosition.X + anotherBuilding.buildingSize.X + Random.Float(300, 400);

                    // Make sure there is enough space between the nextBuilding and the origianlPosition
                    if (nextBuildingEndPosition > originalPosition)
                    {
                        // Update last building's end position
                        originalPosition = nextBuildingEndPosition;
                    }
                }
            }

            // Set the new position for the next building
            buildingPosition.X = originalPosition;

            // Draw position upwards instead of draawing downwards 
            buildingPosition.Y = 500 - buildingSize.Y;
        }
    }
}

