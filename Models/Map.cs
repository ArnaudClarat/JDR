namespace JDR.Models
{
    public class Map
    {
        public int RowCount { get; set; }
        public int ColCount { get; set; }
        public List<Monster> Monsters { get; private set; } = [];
        public List<LifeFountain> Fountains { get; private set; } = [];
        public List<Treasure> Treasures {get; private set; } = [];
        
        private readonly Random Random = new();
        private readonly Hero Hero;
        
        public Map(
            int rowCount,
            int colCount,
            Hero hero
        )
        {
            RowCount = rowCount;
            ColCount = colCount;
            this.Hero = hero;
            GenerateEntities();
        }

        // Generates entities at random location on the map
        public void GenerateEntities()
        {
            Monsters.Clear(); // Clears monsters list
            Fountains.Clear(); // Clears fountains list
            Treasures.Clear(); // Clears treasures list

            // Generates 11 monsters at random location
            for (int i = 0; i < 11; i++)
            {
                (int x, int y) = GetRandomPosition();
                Monsters.Add(new MonsterGoblin(x, y, Hero.Level));
            }

            // Generates 5 fountains at random location
            for (int i = 0; i < 5; i++)
            {
                (int x, int y) = GetRandomPosition();
                Fountains.Add(new LifeFountain(x, y));
            }
            
            // Generates 3 chests at random location
            for (int i = 0; i < 3; i++)
            {
                (int x, int y) = GetRandomPosition();
                Treasures.Add(new Treasure(x, y));
            }
            
            // Generates 1 boss at random location
            for (int i = 0; i < 1; i++)
            {
                (int x, int y) = GetRandomPosition();
                Monsters.Add(new Boss(x, y, Hero.Level+2, "Skelletor"));
            }
        }
        
        private (int X, int Y) GetRandomPosition()
        {
            (int X, int Y) position;
            do
            {
                position = (Random.Next(0, ColCount), Random.Next(0, RowCount));
            } while (
                Monsters.Any(m => m.X == position.X && m.Y == position.Y) ||
                Fountains.Any(f => f.X == position.X && f.Y == position.Y) ||
                Treasures.Any(t => t.X == position.X && t.Y == position.Y)
            );
            return position;
        }

        public string RenderCell(int x, int y)
        {
            if (Hero.X == x && Hero.Y == y)
                return $"heroSprite {Hero.FacingDirection}";
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
            else if (Treasures.Any(t => t.X == x && t.Y == y))
                return "treasureSprite";
            return "";
        }
        
        public bool IsInsideMap(int x, int y)
        {
            return x >= 0 && x < ColCount && y >= 0 && y < RowCount;
        }
    }
}
