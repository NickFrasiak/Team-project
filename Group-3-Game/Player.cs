using System;
using System.Drawing;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace Game10003;
public class Player
{
    public Vector2 position;
    Vector2 velocity;
    public float size;
    int maxSpeed = 200;
    int jumpHeight = 450;   
    Color color;
    Vector2 gravity = new Vector2(0, 10);

   
    //Setup Player
    public Player()
    {
        size = 60;
        position = new Vector2(150, 400);
        velocity = new Vector2();
        color = Color.Red;

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
        //gravity
        position += velocity * Time.DeltaTime;

        if(position.Y > 500 - size)
        {
            velocity.Y = 0;
            position.Y = 500 - size;
        }
        // spacebar input to jump
        if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
        {
            velocity.Y -= velocity.Y + jumpHeight;
        }
    }

    //Draw Player
    public void Render()
    {
        Draw.FillColor = color;
        Draw.Rectangle(position.X, position.Y, size / 2, size);
    }

}

