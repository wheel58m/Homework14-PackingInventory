Console.Clear();
Console.WriteLine("Hello, prepare for your journey by building your pack and selecting your items.");

// Build Pack
Console.Write("How many items can your pack carry: ");
int maxItems = Convert.ToInt32(Console.ReadLine());
Console.Write("How much weight can your pack carry: ");
double maxWeight = Convert.ToDouble(Console.ReadLine());
Console.Write("How much volume can your pack carry: ");
double maxVolume = Convert.ToDouble(Console.ReadLine());

Pack pack = new Pack(maxItems, maxWeight, maxVolume);


// Select Items
while (true) {
    Console.Clear();
    Console.WriteLine($"Your pack can carry {pack.MaxItems} items, {pack.MaxWeight} weight, and {pack.MaxVolume} volume.");
    Console.WriteLine($"Your pack currently has {pack.ItemCount} items, {pack.Weight} weight, and {pack.Volume} volume.");
    if (pack.ItemCount == pack.MaxItems || pack.Weight == pack.MaxWeight || pack.Volume == pack.MaxVolume) {
        Console.WriteLine("Your pack is full.");
        break;
    } else {
        Console.WriteLine();
        Console.WriteLine("Select an item to add to your pack:");
        Console.WriteLine("(1) Arrow: 0.1 weight, 0.05 volume");
        Console.WriteLine("(2) Bow: 1.0 weight, 4.0 volume");
        Console.WriteLine("(3) Rope: 1.0 weight, 1.5 volume");
        Console.WriteLine("(4) Water: 2.0 weight, 3.0 volume");
        Console.WriteLine("(5) Food: 1.0 weight, 0.5 volume");
        Console.WriteLine("(6) Sword: 5.0 weight, 3.0 volume");
        Console.Write("Input the number for the item you'd like to add: ");

        int choice = Convert.ToInt32(Console.ReadLine());
        InventoryItem? item = choice switch
        {
            1 => new Arrow(),
            2 => new Bow(),
            3 => new Rope(),
            4 => new Water(),
            5 => new Food(),
            6 => new Sword(),
            _ => null,
        };
        
        if (item != null) {
            if (pack.Add(item)) {
                Console.WriteLine();
                Console.WriteLine($"Added {item.GetType().Name} to pack.");
            } else {
                Console.WriteLine();
                Console.WriteLine($"Could not add {item.GetType().Name} to pack.");
            }
        } else {
            Console.WriteLine();
            Console.WriteLine("Invalid choice.");
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }
}



public class Pack {
    public InventoryItem[] Items { get; set; }
    public int MaxItems { get; set; }
    public double MaxWeight { get; set; }
    public double MaxVolume { get; set; }
    public int ItemCount { get; set; }
    public double Weight { get; set; }
    public double Volume { get; set; }

    public Pack(int maxItems, double maxWeight, double maxVolume) {
        MaxItems = maxItems;
        MaxWeight = maxWeight;
        MaxVolume = maxVolume;
        Items = new InventoryItem[MaxItems];
    }

    public bool Add(InventoryItem item) {
        // Check if there is room
        if (ItemCount < MaxItems) {
            // Find the first empty slot
            int index = 0;
            while (index < MaxItems && Items[index] != null) {
                index++;
            }
            if (index < MaxItems) {
                // Check if the item fits
                if (Weight + item.Weight <= MaxWeight && Volume + item.Volume <= MaxVolume) {
                    Items[index] = item;
                    Weight += item.Weight;
                    Volume += item.Volume;
                    ItemCount++;
                    return true;
                }
            }
        }
        return false;
    }
}