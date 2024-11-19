namespace Game10003;

public class Game
{
    // Setting Up Colors
    Color buildingColor = new Color(0x46, 0x47, 0x4c);

    // Calling classes 
    Buildings[] buildings = new Buildings[5];

    Player player;

    public void Setup()
    {
        player = new Player();

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

        // Draw Temporary Ground 
        Draw.LineSize = 0;
        Draw.FillColor = Color.Black;
        Draw.Rectangle(0, 500, 800, 100);

        // Draw Temporary Player 
        Draw.LineSize = 0;
        Draw.FillColor = Color.Red;
        Draw.Rectangle(150, 400, 50, 100);

        // Draw the buildings 5 times
        for (int i = 0; i < buildings.Length; i++)
        {
            // Draw and move buildings
            buildings[i].DrawBuildings();
            buildings[i].Move(buildings);

            Vector2 playerPosition1 = player.position;

            float playerSize1 = player.size;


        }
        //render player 
        player.Render();
        player.UpdatePosition();

    }


}
