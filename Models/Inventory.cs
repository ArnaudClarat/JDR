namespace JDR.Models
{
    public class Inventory
    {
        public List<Item> WeaponItems { get; private set; }
        public List<Item> ArmorItems { get; private set; }
        public int InventoryLength { get; private set; } = 12;
        public Inventory()
        {
            WeaponItems = [];
            ArmorItems = [];
        }
        public void CheckGameOver(bool isGameOver)
        {
            if (isGameOver) ClearInventory();
        }
        public void ClearInventory()
        {
            WeaponItems.Clear();
            ArmorItems.Clear();
        }
        public void AddWeaponItem(Item item)
        {
            if (item != null && WeaponItems.Count < InventoryLength)
            {
                WeaponItems.Add(item);
            }
        }
        public void AddArmorItem(Item item)
        {
            if (item != null && ArmorItems.Count < InventoryLength)
            {
                ArmorItems.Add(item);
            }
        }
        public void RemoveItem(Item item)
        {
            if (item != null)
            {
                WeaponItems.Remove(item);
                ArmorItems.Remove(item);
            }
        }
        public void AfficherInventaire()
        {
            if (WeaponItems.Count == 0)
            {
                Console.WriteLine("L'inventaire est vide");
                return;
            }
            foreach (var item in WeaponItems)
            {
                Console.WriteLine(item);
            }
        }
    }
}