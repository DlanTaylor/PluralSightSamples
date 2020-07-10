using System;


public enum Player { Noone = 0, Circles, Crosses }

public struct Square
{
    public Player Owner { get; }

    public Square(Player owner)
    {
        this.Owner = owner;
    }

    public override string ToString()
    {
        switch (Owner)
        {
            case Player.Noone:
                return ".";
            case Player.Crosses:
                return "X";
            case Player.Circles:
                return "O";
            default:
                throw new Exception("Invalid State");
        }
    }
}
