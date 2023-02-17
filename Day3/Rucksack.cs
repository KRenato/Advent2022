namespace Day3;

public class Rucksack
{
    public Rucksack(string items)
    {
        Items = items;
    }

    public string Items { get; }

    public char GetIntersectingItem()
    {
        var compartment1 = GetCompartment1();
        var compartment2 = GetCompartment2();

        var item = compartment1.Intersect(compartment2).FirstOrDefault();

        return item;
    }

    public static int ConvertItemToPriority(char item)
    {
        int priority = item;
        return priority >= 97 ? priority - 96 : priority - 38;
    }

    private string GetCompartment1()
    {
        return Items[..(Items.Length / 2)];
    }

    private string GetCompartment2()
    {
        return Items[(Items.Length / 2)..];
    }
}
