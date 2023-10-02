public class InventoryItem {
    public double Weight { get; set; }
    public double Volume { get; set; }

    public InventoryItem(double weight, double volume) {
        Weight = weight;
        Volume = volume;
    }
}
public class Arrow : InventoryItem {
    public Arrow() : base(0.1, 0.05) {

    }
}
public class Bow : InventoryItem {
    public Bow() : base(1.0, 4.0) {

    }
}
public class Rope : InventoryItem {
    public Rope() : base(1.0, 1.5) {

    }
}
public class Water : InventoryItem {
    public Water() : base(2.0, 3.0) {

    }
}
public class Food : InventoryItem {
    public Food() : base(1.0, 0.5) {

    }
}
public class Sword : InventoryItem {
    public Sword() : base(5.0, 3.0) {

    }
}