namespace JDR.Models
{
    public class Map
    {
        public int RowCount { get; set; }
        public int ColCount { get; set; }
        public List<Monster> Monsters { get; private set; } = new();
        public List<LifeFountain> Fountains { get; private set; } = new();
        
        private Random random = new();
        private Hero hero;
        
        public Map(
            int rowCount,
            int colCount,
            Hero hero
        )
        {
            RowCount = rowCount;
            ColCount = colCount;
            this.hero = hero;
            GenerateEntities();
        }

        // Generates entities at random location on the map
        public void GenerateEntities()
        {
            Monsters.Clear(); // Clears monsters list
            Fountains.Clear(); // Clears fountains list

            // Generates 5 monsters at random location
            for (int i = 0; i < 5; i++)
            {
                (int x, int y) = GetRandomPosition();
                Monsters.Add(new MonsterGoblin(x, y, hero.Level));
            }

            // Generates 4 fountains at random location
            for (int i = 0; i < 4; i++)
            {
                (int x, int y) = GetRandomPosition();
                Fountains.Add(new LifeFountain(x, y));
            }
            
            // Generates 1 boss at random location
            for (int i = 0; i < 1; i++)
            {
                (int x, int y) = GetRandomPosition();
                Monsters.Add(new Boss(x, y, hero.Level+2));
            }
        }
        
        private (int X, int Y) GetRandomPosition()
        {
            (int X, int Y) position;
            do
            {
                position = (random.Next(0, ColCount), random.Next(0, RowCount));
            } while (
                Monsters.Any(m => m.X == position.X && m.Y == position.Y) ||
                Fountains.Any(f => f.X == position.X && f.Y == position.Y)
            );
            return position;
        }

        public string RenderCell(int x, int y)
        {
            if (hero.X == x && hero.Y == y)
                return $"sprite {hero.FacingDirection}";
            else if (Monsters.Any(m => m.X == x && m.Y == y))
            {
                var monster = Monsters.First(m => m.X == x && m.Y == y); // Finds the right type of monster
                if (monster.Name == "Dragon")
                {
                    return "boss";
                }
                else
                {
                    return "monster";
                }
            }
            else if (Fountains.Any(f => f.X == x && f.Y == y))
                return "fountain";
            return "";
        }
        
        public bool IsInsideMap(int x, int y)
        {
            return x >= 0 && x < ColCount && y >= 0 && y < RowCount;
        }
    }
}