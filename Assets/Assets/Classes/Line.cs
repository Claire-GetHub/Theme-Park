using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Line
{
    private readonly int maxCapacity;
    private readonly int chanceOutOf;
    private readonly int newMemberChance;
    private readonly int childChance;
    private readonly int withoutParentChance;


    private List<Member> members = new List<Member>();
    public Member[] Members
    {
        get{return members.ToArray();}
    }

    public Line(int maxCapacity, int chanceOutOf, int newMemberChance, int childChance, int withoutParentChance)
    {
        this.maxCapacity = maxCapacity;
        this.chanceOutOf = chanceOutOf;
        this.newMemberChance = newMemberChance;
        this.childChance = childChance;
        this.withoutParentChance = withoutParentChance;
    }

    public Line()
    {
        this.maxCapacity = 50;
        this.chanceOutOf = 100;
        this.newMemberChance = 100;
        this.childChance = 50;
        this.withoutParentChance = 10;
    }

    
    public (int, Member) RemoveMember()
    {
        if (members.Count <= 0) {return (Error.EMPTY_LINE, null);}
        Member m = members[0];
        members.RemoveAt(0);
        return (Error.NONE, m);
    }

    //TEST IT IS BROKEN
    public void RandomlyAddMembers()
    {
        if (members.Count + 1 > maxCapacity) {return;}

        int r = Random.Range(0, chanceOutOf);
        

        if (r > newMemberChance){return;}
        r = Random.Range(0, chanceOutOf);
        if (r > childChance){members.Add(new Member(false, false));}
        r = Random.Range(0, chanceOutOf);
        if (r > withoutParentChance){members.Add(new Member(true, false));}
        
        members.Add(new Member(false, false));
        
    }
}
