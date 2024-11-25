using System;
using System.Numerics;

namespace Game10003;
public class Game
{
    // Setting Up Colors
    Color buildingColor = new Color(0x46, 0x47, 0x4c);
    Color GameOverColor = new Color(254, 129, 129);
    int Coins = 0;
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
    void GameOverLose()
    {

        Text.Size = 100;
        Window.ClearBackground(GameOverColor);
        Text.Color = Color.White;
        Text.Draw("GAME OVER :(", 50, 200);
        

    }
    void GameOverWin()
    {
        Text.Size = 100;
        Window.ClearBackground(GameOverColor);
        Text.Color = Color.White;
        Text.Draw("YOU WIN", 50, 200);
    }
    public void Update()
    {
        Window.ClearBackground(Color.OffWhite);

        // Draw Temporary Ground 
        Draw.LineSize = 0;
        Draw.FillColor = Color.Green;
        Draw.Rectangle(0, 500, 800, 100);

        // Draw the buildings 5 times
        for (int i = 0; i < buildings.Length; i++)
        {
            
            bool doesBuildingHitPlayer = player.DoesPlayerHitBuildings(buildings[i]);
            if (doesBuildingHitPlayer)
            {
                
                GameOverLose();
                Console.WriteLine("Hit");
                return;
            }

            // Draw and move buildings
            buildings[i].DrawBuildings();
            buildings[i].Move(buildings);

            Vector2 playerPosition1 = player.position;
            Vector2 playerSize1 = player.size;
           
        }
        if (Coins == 50)
        {
            GameOverWin();
            return;
        }



        //render player 
        player.Render();
        player.UpdatePosition();

    }


}
