using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ride
{
    public readonly int maxCapacity;
    public readonly int maxRideTime;
    public readonly int minRideTime;
    public Line ridesLine;

    public Ride(int maxCapacity, int maxRideTime, int minRideTime, Line ridesLine) 
    {
        this.maxCapacity = maxCapacity;
        this.maxRideTime = maxRideTime;
        this.minRideTime = minRideTime;
        this.ridesLine = ridesLine;
    }
    public Ride() 
    {
        this.maxCapacity = 20;
        this.maxRideTime = 300;
        this.minRideTime = 60;
        this.ridesLine = new Line();
    }

    private List<Member> current = new List<Member>();
    public int OnRide {get {return (current.Count > maxCapacity)? maxCapacity : current.Count;}}
    public int OutsideRide { get {return (current.Count > maxCapacity)? current.Count - maxCapacity : 0;}}

    private bool running = false;
    public bool Running {get {return running;}}
    private bool lockedGates = true;
    public bool LockedGates {get {return lockedGates;}}

    public int StartRide()
    {
        running = true;
        if(!lockedGates){return Error.START_WITH_UNLOCKED_GATES;}
        return Error.NONE;
    }

    public int EndRide()
    {
        running = false;
        return Error.NONE;
    }

    public int LockRide()
    {
        lockedGates = true;
        return Error.NONE;
    }

    public int UnlockRide()
    {
        lockedGates = false;
        return Error.NONE;
    }

    public int AddRider()
    {
        if (lockedGates) {return Error.ADD_WITH_LOCKED_GATES;}
        (int error, Member m) = ridesLine.RemoveMember();
        if (m != null) {current.Add(m);}
        return error;
    }

    public int UnlockGates()
    {
        lockedGates = false;
        return Error.NONE;
    }

    public int LockGates()
    {
        lockedGates = true;
        return Error.NONE;
    }
}
