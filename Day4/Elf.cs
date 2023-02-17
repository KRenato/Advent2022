namespace Day4;

public class Elf
{
    public Elf(string assignment)
    {
        var sections = assignment
            .Split('-')
            .Select(int.Parse)
            .ToArray();

        BeginSection = sections[0] < sections[1] ? sections[0] : sections[1];
        EndSection = sections[0] > sections[1] ? sections[0] : sections[1];
    }

    public int BeginSection { get; }

    public int EndSection { get; }

    public bool HasFullOverlap(Elf otherElf)
    {
        if ((BeginSection <= otherElf.BeginSection && EndSection >= otherElf.EndSection)
            || (otherElf.BeginSection <= BeginSection && otherElf.EndSection >= EndSection))
        {
            return true;
        }

        return false;
    }

    public bool HasPartialOverlap(Elf otherElf)
    {
        if ((BeginSection <= otherElf.BeginSection && EndSection >= otherElf.BeginSection)
            || (BeginSection <= otherElf.EndSection && EndSection >= otherElf.EndSection)
            || (otherElf.BeginSection <= BeginSection && otherElf.EndSection >= BeginSection)
            || (otherElf.BeginSection <= EndSection && otherElf.EndSection >= EndSection))
        {
            return true;
        }

        return false;
    }
}
