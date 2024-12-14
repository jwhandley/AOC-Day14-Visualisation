using System.Numerics;
using System.Text.RegularExpressions;
using Raylib_cs;

namespace AOC_Day14;

public partial class Robot(Vector2 position, Vector2 velocity)
{
    private readonly Vector2 initialPosition = position;
    private Vector2 Position { get; set; } = position;
    private Vector2 Velocity { get; } = velocity;

    public static Robot Parse(string lines)
    {
        string[] split = lines.Split(' ');

        var position = NumberRegex().Matches(split[0]) switch
        {
            [var a, var b] => new Vector2(int.Parse(a.Value), int.Parse(b.Value)),
            _ => throw new FormatException()
        };
        
        var velocity = NumberRegex().Matches(split[1]) switch
        {
            [var a, var b] => new Vector2(int.Parse(a.Value), int.Parse(b.Value)),
            _ => throw new FormatException()
        };
        
        return new Robot(position, velocity);
    }

    public void Update(float deltaTime)
    {
        float newX = (Position.X + Velocity.X * deltaTime) % 101;
        float newY = (Position.Y + Velocity.Y * deltaTime) % 103;
        if (newX < 0) newX += 101;
        if (newY < 0) newY += 103;
        Position = new Vector2(newX, newY);
    }

    public void Updated(float deltaTime)
    {
        float newX = (initialPosition.X + Velocity.X * deltaTime) % 101;
        float newY = (initialPosition.Y + Velocity.Y * deltaTime) % 103;
        if (newX < 0) newX += 101;
        if (newY < 0) newY += 103;
        
        Position = new Vector2(newX, newY);
    }
    public void Draw()
    {
        Raylib.DrawRectangleV(Position * 5 + new Vector2(100, 25), new Vector2(5,5), Color.Black);
    }

    [GeneratedRegex(@"-?\d+")]
    private static partial Regex NumberRegex();
}