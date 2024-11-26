using System;
using System.Numerics;

namespace Game10003;
public class Game
{
    // Setting Up Colors
    Color buildingColor = new Color(0x46, 0x47, 0x4c);
    Color GameOverColor = new Color(254, 129, 129);
 
    // Calling classes 
    Buildings[] buildings = new Buildings[5];
    Player player;

    Color coinColor = Color.Yellow; 
    Coins coin; 

    // Track player score 
    int score = 0;

    bool isGameOverLose = false;
    bool isGameOverWin = false;

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

        // Initialize coin
        coin = new Coins(new Vector2(700, 350), 20, coinColor, -200);
    }
    
    public void Update()
    {
        Window.ClearBackground(Color.OffWhite);

        if (isGameOverLose == true)
        {
            GameOverLose();
            return; // Stop any further code from running in update
        }


        if (isGameOverWin == true)
        {
            GameOverWin();
            return; // Stop any further code from running in update
        }

        // Draw Ground
        Draw.LineSize = 0;
        Draw.FillColor = Color.Green;
        Draw.Rectangle(0, 500, 800, 100);

        // Draw and move buildings
        for (int i = 0; i < buildings.Length; i++)
        {
            if (player.DoesPlayerHitBuildings(buildings[i]))
            {
                isGameOverLose = true;
                return;
            }

            buildings[i].DrawBuildings();
            buildings[i].Move(buildings);
        }

        // Draw and move coin
        coin.DrawCoins();
        coin.Move();

        // Check for coin collision
        if (coin.DoesPlayerHitCoins(player))
        {
            score++;   
        }

        // Check win condition
        if (score >= 200)
        {
            isGameOverWin = true;
            return;
        }

        // Draw Score
        Text.Color = Color.Black;
        Text.Draw($"Current score: {score}", 300, 500);

        // Render player
        player.Render();
        player.UpdatePosition();

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
}
