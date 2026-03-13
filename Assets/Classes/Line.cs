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

    public Line(int maxCapacity, int chanceOutOf, int newMemberChance, int childChance, int withoutParentChance, int startingCapacity)
    {
        this.maxCapacity = maxCapacity;
        this.chanceOutOf = chanceOutOf;
        this.newMemberChance = newMemberChance;
        this.childChance = childChance;
        this.withoutParentChance = withoutParentChance;
        for(int i = 0; i < startingCapacity; i++)
        {
            AddMember();
        }
    }

    public Line()
    {
        this.maxCapacity = 50;
        this.chanceOutOf = 100;
        this.newMemberChance = 100;
        this.childChance = 50;
        this.withoutParentChance = 10;
        for(int i = 0; i < 30; i++)
        {
            AddMember();
        }
    }

    
    public (int, Member) RemoveMember()
    {
        if (members.Count <= 0) {return (Error.EMPTY_LINE, null);}
        Member m = members[0];
        members.RemoveAt(0);
        return (Error.NONE, m);
    }


    public void PossiblyAddMember()
    {
        if (members.Count + 1 > maxCapacity) {return;}

        int r = Random.Range(0, chanceOutOf);
        if (r > newMemberChance){return;}
        AddMember();
        
        
    }

    public void AddMember()
    {
        if (members.Count + 1 > maxCapacity) {return;}
        int r = Random.Range(0, chanceOutOf);
        if (r > childChance){members.Add(new Member(false, false));}
        r = Random.Range(0, chanceOutOf);
        if (r > withoutParentChance){members.Add(new Member(true, false));}
        
        members.Add(new Member(false, false));
    }
}
