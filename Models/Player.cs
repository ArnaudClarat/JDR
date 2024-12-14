namespace JDR.Models
{
    public class Player
    {
        public int X { get; private set; } = 0;
        public int Y { get; private set; } = 0;
        public Direction FacingDirection { get; private set; } = Direction.Right;

        public void Move(string direction, int gridSize)
        {
            switch (direction)
            {
                case "Up":
                    if (Y > 0) Y--;
                    break;
                case "Down":
                    if (Y < gridSize - 1) Y++;
                    break;
                case "Left":
                    if (X > 0) X--;
                    FacingDirection = Direction.Left;
                    break;
                case "Right":
                    if (X < gridSize - 1) X++;
                    FacingDirection = Direction.Right;
                    break;
            }
        }
    }

    public enum Direction { Left, Right}
}
