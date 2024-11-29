using System;
using System.Numerics;

namespace Game10003;

public class Coins
{

    public Vector2 position;
    public float radius;
    public Color color;
    private float speed;
    public Coins(Vector2 startPosition, float coinRadius, Color coinColor, float movementSpeed)
    {
        position = startPosition;
        radius = coinRadius;
        color = coinColor;
        speed = movementSpeed;
    }
    public void DrawCoins()
    {
        Draw.LineSize = 0;
        Draw.FillColor = color;
        Draw.Circle(position, radius);
    }
    public void Move()
    {
        position.X += Time.DeltaTime * speed;
        // Reset position if it moves off-screen
        if (position.X < -100)
        {
            position.X = 800; // Reset X position
            position.Y = Random.Float(300, 500); // Randomize Y position
        }
    }
    public bool DoesPlayerHitCoins(Player player)
    {
        // Define coin edges
        float coinLeftEdge = position.X - radius;
        float coinRightEdge = position.X + radius;
        float coinTopEdge = position.Y - radius;
        float coinBottomEdge = position.Y + radius;
        // Define player edges
        float playerLeft = player.position.X;
        float playerRight = player.position.X + player.size.X;
        float playerTop = player.position.Y;
        float playerBottom = player.position.Y + player.size.Y;
        // Check for collision
        bool horizontalCollision = playerRight >= coinLeftEdge && coinRightEdge >= playerLeft;
        bool verticalCollision = playerBottom >= coinTopEdge && playerTop <= coinBottomEdge;
        return horizontalCollision && verticalCollision;
    }
}