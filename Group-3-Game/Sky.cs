using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Game10003;

public class Sky
{
    Vector2 Position;

    Texture2D Texture;
    public Sky()
    {
        //Sky image position
        Position = new Vector2(0, 0);
    }
    
    public void Setup()
    {
        Console.WriteLine(System.IO.Directory.GetCurrentDirectory());

        //
        Texture = Graphics.LoadTexture("../../../Assets/SkyBackground.png");
    }

    public void Update()
    {
        //
        Graphics.Draw(Texture, 0, 0);
        Position.X -= 10;
       
        //if (Position.X < -800)
        {
            Position.X = 0;
        }
;
    }

}
