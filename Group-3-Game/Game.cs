// Include code libraries you need below (use the namespace).
using System;
using System.Numerics;

// The namespace your code is in.
namespace Game10003
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:

    public void Setup()
    {
        // Set Window Size
        Window.SetSize(800, 600);

        player = new Player();

        }

        // Initialize coin
        coin = new Coins(new Vector2(700, 350), 20, coinColor, -200);
    }
    public void Update()
    {
        Window.ClearBackground(Color.Clear);
        sky.Update();

        // Draw Temporary Ground 
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

        // Draw the buildings 5 times
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
        } // Draw Score
        Text.Color = Color.Black;
        Text.Draw($"Current score: {score}", 300, 500);
        // Render player
        player.Render();
        player.UpdatePosition();

        }
    }
}
