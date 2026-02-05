using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ride
{
    public const int MAX_CAPACITY = 20;
    public const int MAX_RIDE_LENGTH = 300;
    public const int MIN_RIDE_LENGTH = 60;

    private int current = 0;
    public int OnRide {get {return (current > MAX_CAPACITY)? MAX_CAPACITY : current;}}
    public int OutsideRide { get {return (current > MAX_CAPACITY)? current - MAX_CAPACITY : 0;}}

    private bool running = false;
    public bool Running {get {return running;}}
    private bool lockedGates = true;
    public bool LockedGates {get {return lockedGates;}}

    public int StartRide()
    {
        running = true;
        return RideError.NONE;
    }

    public int EndRide()
    {
        running = false;
        return RideError.NONE;
    }

    public int LockRide()
    {
        lockedGates = true;
        return RideError.NONE;
    }

    public int UnlockRide()
    {
        lockedGates = false;
        return RideError.NONE;
    }

    public int AddRider()
    {
        if (lockedGates) {return RideError.ADD_WITH_LOCKED_GATES;}
        
        current++;
        return RideError.NONE;
        

    }

    public int UnlockGates()
    {
        lockedGates = false;
        return RideError.NONE;
    }

    public int LockGates()
    {
        lockedGates = true;
        return RideError.NONE;
    }
}
