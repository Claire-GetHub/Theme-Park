using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Member
{
    private const int maxHeight = 100;
    private const int minHeight = 50;
    private const int childMinHeight = 10;
    public readonly Member child;
    public readonly bool isChild;
    public readonly int height;

    public Member(bool hasChild, bool isChild)
    {
        if (hasChild) {child = new Member(false, true);}
        this.isChild = isChild;

        if(isChild)
        {
            height = Random.Range(childMinHeight, minHeight);
        } else
        {
            height = Random.Range(minHeight, maxHeight);
        }
    }
}
