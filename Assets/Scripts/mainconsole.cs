using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class mainconsole : MonoBehaviour
{
    public TMP_Text errorText;
    Ride ride;
    void Start()
    {
        ride = new Ride();
        Debug.Log("riders: " + ride.LinesLength);
    }

    public void startRide() {
        Debug.Log("startRide");
        textOutput(ride.StartRide());
    }

    public void endRide() {
        Debug.Log("endRide");
        textOutput(ride.EndRide());
    }

    public void lockGates() {
        Debug.Log("lockGates");
        textOutput(ride.LockGates());

    }

    public void unlockGates() {
        Debug.Log("unlockGates");
        textOutput(ride.UnlockGates());

    }

    public void allowToEnter()
    {
       textOutput(ride.AddRider()); 
       Debug.Log("riders: " + ride.onRide);
    }

    public void disallowToEnter()
    {
        
    }

    private void textOutput(int error)
    {
        switch (error) {
            case Error.NONE:
                errorText.text = "No error";
                break;
            case Error.WRONG_NEXT_TASK:
                errorText.text = "wrong next task";
                break;
            case Error.EMPTY_LINE:
                errorText.text = "the line is empty";
                break;
            case Error.OVERFLOWING_RIDE:
                errorText.text = "overflowing the ride";
                break;
        }

    }
    
}
