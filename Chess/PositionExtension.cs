namespace Chess
{
    public static class PositionExtension
    {
        public static bool IsValidPosition(this Position position, int dimensions)
        {
            return position.x >= 0 && position.y >= 0 && position.x <= dimensions - 1 && position.y <= dimensions - 1;
        }
    }
}