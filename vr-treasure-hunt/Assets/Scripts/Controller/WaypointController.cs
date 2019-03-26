using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    private Waypoint[] waypoints;

    public Waypoint waypointStart;

    public Waypoint waypointExit;

    public Waypoint waypointKey;

    public bool waypointExitActive = false;

    public bool waypointKeyActive = false;

    private void Start()
    {
        waypoints = FindObjectsOfType<Waypoint>();
        waypointKey.gameObject.SetActive(false);
        waypointExit.gameObject.SetActive(false);
        waypointStart.gameObject.SetActive(false);
    }

    public void ActiveWaypointKey()
    {
        waypointKeyActive = true;
        waypointKey.gameObject.SetActive(true);
    }

    public void InactiveClickedWaypoint(Waypoint waypointClicked)
    {
        foreach (var waypoint in waypoints)
        {
            waypoint.gameObject.SetActive(true);
        }

        if (!waypointExitActive)
        {
            waypointExit.gameObject.SetActive(false);
        }

        if (!waypointKeyActive)
        {
            waypointKey.gameObject.SetActive(false);
        }

        waypointClicked.gameObject.SetActive(false);
    }
}
