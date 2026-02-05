using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Line
{
    private readonly int maxCapacity;
    private readonly int chanceOutOf;
    private readonly int childChance;
    private readonly int withoutParentChance;


    private int currentCapacity = 0;

    public Line(int maxCapacity, int chanceOutOf, int childChance, int withoutParentChance)
    {
        this.maxCapacity = maxCapacity;
        this.chanceOutOf = chanceOutOf;
        this.childChance = childChance;
        this.withoutParentChance = withoutParentChance;
    }

    
    public int RemoveMember()
    {
        if (currentCapacity <= 0) {return LineError.EMPTY_LINE;}
        currentCapacity--;
        return LineError.NONE;
    }

    public void RandomlyAddMembers()
    {
        
    }
}
