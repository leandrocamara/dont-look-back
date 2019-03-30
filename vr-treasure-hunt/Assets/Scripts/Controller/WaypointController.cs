using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Classe responsável por controlar os Waypoints.
 */
public class WaypointController : MonoBehaviour
{
    public Waypoint waypointKey;
    public Waypoint waypointExit;
    public Waypoint waypointStart;
    public bool waypointKeyActive = false;
    public bool waypointExitActive = false;

    private Waypoint[] waypoints;

    /**
     * Ativa o Waypoint que dá acesso à sala da Chave.
     */
    public void ActiveWaypointKey()
    {
        waypointKeyActive = true;
        waypointKey.gameObject.SetActive(true);
    }

    /**
     * Ativa o Waypoint que dá acesso à sala da Chave.
     */
    public void ActiveWaypointExit()
    {
        waypointExitActive = true;
        waypointExit.gameObject.SetActive(true);
    }

    /**
     * Inativa o Waypoint acionado e ativa os demais Waypoints.
     */
    public void InactiveClickedWaypoint(Waypoint waypointClicked)
    {
        foreach (var waypoint in waypoints)
        {
            waypoint.gameObject.SetActive(true);
        }

        InactiveWaypoint(waypointKeyActive, waypointKey);
        InactiveWaypoint(waypointExitActive, waypointExit);

        waypointClicked.gameObject.SetActive(false);
    }

    /**
     * Método Start.
     */
    private void Start()
    {
        waypoints = FindObjectsOfType<Waypoint>();
        waypointKey.gameObject.SetActive(false);
        waypointExit.gameObject.SetActive(false);
        waypointStart.gameObject.SetActive(false);
    }

    /**
     * Inativa o Waypoint informado caso o mesmo tenha que estar inativo.
     */
    private void InactiveWaypoint(bool stayActive, Waypoint waypoint)
    {
        if (!stayActive)
        {
            waypoint.gameObject.SetActive(false);
        }
    }
}
