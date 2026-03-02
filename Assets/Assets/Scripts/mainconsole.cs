using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainconsole : MonoBehaviour
{
    Ride ride;
    void Start()
    {
        ride = new Ride();
        for(int i = 0; i < 100; i++)
        {
            ride.ridesLine.RandomlyAddMembers();
        }
        Debug.Log("riders: " + ride.OnRide);
    }

    public void startRide() {
        Debug.Log("startRide");
        Debug.Log(ride.StartRide());
    }

    public void endRide() {
        Debug.Log("endRide");
        Debug.Log(ride.EndRide());
    }

    public void lockGates() {
        Debug.Log("lockGates");
        Debug.Log(ride.LockGates());

    }

    public void unlockGates() {
        Debug.Log("unlockGates");
        Debug.Log(ride.UnlockGates());

    }

    public void allowToEnter()
    {
       Debug.Log(ride.AddRider()); 
       Debug.Log("riders: " + ride.OnRide);
    }

    public void disallowToEnter()
    {
        
    }
    
}
