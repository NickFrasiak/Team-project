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
    bool isTouchingGround = false;
    Vector2 gravity = new Vector2(0, 10);
    


   
    //Setup Player
    public Player()
    {
        size = 60;
        position = new Vector2(150, 400);
        velocity = new Vector2();
        color = Color.Red;

    }

    //Gravity and Position update
    public void UpdatePosition()
    {
        //gravity
        if (velocity.Y <= maxSpeed)
        {
            velocity += gravity;
        }
        else
        {
            velocity.Y = maxSpeed;
        }
       
        //ground check
        if(position.Y > 500 - size)
        {
            velocity.Y = 0;
            position.Y = 500 - size;
            isTouchingGround = true;
            
        }
        // spacebar input to jump
        if (Input.IsKeyboardKeyPressed(KeyboardInput.Space) && isTouchingGround )
        {
            velocity.Y -= velocity.Y + jumpHeight;
            isTouchingGround = false;
        }
        //Update position
        position += velocity * Time.DeltaTime;
    }

    //Draw Player
    public void Render()
    {
        Draw.FillColor = color;
        Draw.Rectangle(position.X, position.Y, size / 2, size);
    }

}

