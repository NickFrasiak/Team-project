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

    //Coins[] coins = new Coins[]
    public float coinLeftEdge;
    public float coinRightEdge;
    public float coinTopEdge;
    public float coinBottomEdge;
    bool hasCollidedCoinRight;
    bool hasCollidedCoinBottom;
    bool hasCollidedCoin = false;

    float playerLeft;
    float playerRight;
    float playerTop;
    float playerBottom;

    bool hasCollided = false;
    bool hasCollidedright;
    bool hasCollidedbottom;
    public int score;

    float radius = 20;
    float speed = -200;
    public Vector2 coinPosition = new Vector2(900, 350);

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

        //Draw Score

        Text.Draw($"Current score: {score}", 300, 500);
        //Draw coins 

        coinLeftEdge = coinPosition.X - 75;
        coinRightEdge = coinPosition.X + 75;
        coinTopEdge = coinPosition.Y - 75;
        coinBottomEdge = coinPosition.Y + 100;
        coinPosition.X += Time.DeltaTime * speed;
        Draw.LineSize = 3;
        Draw.LineColor = Color.Yellow;
        Draw.Circle(coinPosition, radius);

        //Collision script
        //check horizontally
        bool hasCollidedCoinRight = playerRight >= coinLeftEdge && coinRightEdge >= playerLeft;
        //check vertically
        bool hasCollidedCoinBottom = playerBottom >= coinTopEdge;

        //checks if both bools are active
        hasCollidedCoin = hasCollidedCoinRight && hasCollidedCoinBottom;
        if (hasCollidedCoin)
        {
            Console.WriteLine("Collected");

        }

        //resets the orb's position and sets a random position
        if (coinPosition.X <= 0)
        {
            coinPosition.X = 700;
            coinPosition.Y = Random.Float(500, 300);

        }

        //render player 
        player.Render();
        player.UpdatePosition();

    }


}
