using AOC_Day14;
using Raylib_cs;

Raylib.InitWindow(700, 575, "AOC-Day14");
Raylib.SetTargetFPS(60);

float frameCount = 7488;

List<Robot> robots = File.ReadAllLines("Assets/input.txt").Select(Robot.Parse).ToList();
foreach (var robot in robots) robot.Update(frameCount);

while (!Raylib.WindowShouldClose())
{
    float dt = Raylib.GetFrameTime();
    
    if (frameCount < 7492)
    {
        frameCount += dt;
        robots.ForEach(robot => robot.Updated(frameCount));
    }
    else
    {
        robots.ForEach(robot => robot.Updated(7492));
    }
    
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.RayWhite);
    Raylib.DrawText($"{frameCount:N1}", 20, 40, 20, Color.Black);

    foreach (var robot in robots)
    {
        robot.Draw();
    }
    
    Raylib.DrawRectangleLines(100, 25, 5*102, 5*104, Color.Black);
    
    Raylib.DrawFPS(20, 20);
    Raylib.EndDrawing();
}

Raylib.CloseWindow();