using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ride
{

    public readonly int maxCapacity;
    public readonly int maxRideTime;
    public readonly int minRideTime;
    public readonly Line ridesLine;
    public int LinesLength
    {
        get {return ridesLine.Members.Length;}
    }

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
    public int onRide { get{ return current.Count;}}
    private bool running = false;
    public bool Running {get {return running;}}
    private bool lockedGates = true;
    public bool LockedGates {get {return lockedGates;}}

    private int lastTask = Task.NONE;


    public int StartRide()
    {
        if (lastTask != Task.LOCK_GATES) {return Error.WRONG_NEXT_TASK;}
        running = true;
        lastTask = Task.START_RIDE;
        return Error.NONE;
    }

    public int EndRide()
    {
        if (lastTask != Task.START_RIDE) {return Error.WRONG_NEXT_TASK;}

        running = false;
        lastTask = Task.END_RIDE;
        return Error.NONE;
    }

    public int LockGates()
    {   
        if (lastTask != Task.UNLOCK_GATES) {return Error.WRONG_NEXT_TASK;}
        lockedGates = true;
        lastTask = Task.LOCK_GATES;
        return Error.NONE;
    }

    public int UnlockGates()
    {
        if (lastTask != Task.NONE && lastTask != Task.END_RIDE) {return Error.WRONG_NEXT_TASK;}
        lockedGates = false;
        current.Clear();
        lastTask = Task.UNLOCK_GATES;
        return Error.NONE;
    }

    public int AddRider()
    {
        if (lastTask != Task.UNLOCK_GATES) {return Error.WRONG_NEXT_TASK;}
        (int error, Member m) = ridesLine.RemoveMember();
        if (m != null) {current.Add(m);}
        if(onRide > maxCapacity) {return Error.OVERFLOWING_RIDE;}
        return error;
    }
}
