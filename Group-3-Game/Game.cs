using System;
﻿using System.Numerics;

namespace Game10003;

public class Game
{
    // Setting Up Colors
    Color buildingColor = new Color(0x46, 0x47, 0x4c);

    // Calling classes 
    Buildings[] buildings = new Buildings[5];

    // Call player
    Player player;

    //Call sky (GRAPHIC)
    Sky sky;

    public void Setup()
    {
        // Set Window Size
        Window.SetSize(800, 600);

        player = new Player();

        //run sky graphic
        sky = new Sky();
        sky.Setup();

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
        Window.ClearBackground(Color.Clear);
        sky.Update();

        // Draw Ground 
        Draw.LineSize = 0;
        Draw.FillColor = Color.Green;
        Draw.Rectangle(0, 500, 800, 100);


        // Draw the buildings 5 times
        for (int i = 0; i < buildings.Length; i++)
        {

            bool doesBuildingHitPlayer = player.DoesPlayerHitBuildings(buildings[i]);
            if (doesBuildingHitPlayer)
            {
                Console.WriteLine("Hit");
            }

            // Draw and move buildings
            buildings[i].DrawBuildings();
            buildings[i].Move(buildings);

            Vector2 playerPosition1 = player.position;
            Vector2 playerSize1 = player.size;
        }

        

        //render player 
        player.Render();
        player.UpdatePosition();

    }


}
