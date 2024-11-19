using System;
using System.Drawing;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace Game10003;
public class Player
{
    public Vector2 position;
    public Vector2 velocity;
    public Vector2 size;
    public int maxSpeed = 200;
    public int jumpHeight = 450;   
    public Color color;
    public Vector2 gravity = new Vector2(0, 10);
    bool isTouchingGround = false;


    //Setup Player
    public Player()
    {
        size = Vector2.One * 60;
        position = new Vector2(150, 400);
        velocity = new Vector2();
        color = Color.Red;
    }

    // Does Player Collide with Buildings
    public bool DoesPlayerHitBuildings(Buildings buildings)
    {
        float playerLeft = position.X;
        float playerRight = position.X + size.X;
        float playerTop = position.Y;
        float playerBottom = position.Y + size.Y;

        float buildingsLeft = buildings.buildingPosition.X;
        float buildingsRight = buildings.buildingPosition.X + buildings.buildingSize.X;
        float buildingsTop = buildings.buildingPosition.Y;
        float buildingsBottom = buildings.buildingPosition.Y + buildings.buildingSize.Y;

        bool isWithinBuildingsLeftEdge = playerRight > buildingsLeft;
        bool isWithinBuildingsRightEdge = playerLeft < buildingsRight;
        bool isWithinBuildingsTopEdge = playerBottom > buildingsTop;
        bool isWithinBuildingsBottomEdge = playerTop < buildingsBottom;
        bool isColliding = isWithinBuildingsLeftEdge && isWithinBuildingsRightEdge && isWithinBuildingsTopEdge && isWithinBuildingsBottomEdge;

        return isColliding;
    }

    public void UpdatePosition()
    {
        if (velocity.Y <= maxSpeed)
        {
            velocity += gravity;
        }
        else
        {
            velocity.Y = maxSpeed;
        }

        if(position.Y > 440)
        {
            velocity.Y = 0;
            position.Y = 440;
            isTouchingGround = true;
        }
        // spacebar input to jump
        if (Input.IsKeyboardKeyPressed(KeyboardInput.Space) && isTouchingGround)
        {
            velocity.Y -= velocity.Y + jumpHeight;
            isTouchingGround = false;
        }
        //gravity
        position += velocity * Time.DeltaTime;
    }

    //Draw Player
    public void Render()
    {
        Draw.FillColor = color;
        Draw.Rectangle(position.X, position.Y, 30, 60);
    }

}

