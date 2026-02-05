using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainconsole : MonoBehaviour
{
    Ride ride;
    void Start()
    {
        ride = new Ride();
    }

    public void startRide() {
        Debug.Log("startRide");
    }

    public void endRide() {
        Debug.Log("endRide");

    }

    public void lockGates() {
        Debug.Log("lockGates");

    }

    public void unlockGates() {
        Debug.Log("unlockGates");

    }
    
}
