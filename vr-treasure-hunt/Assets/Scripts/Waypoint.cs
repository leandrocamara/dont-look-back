
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public GameObject player;
    public bool teleport;
    public float speedMovement = 2f;
    public float heightAboveWaypoint = 0.2f;

    public WaypointController waypointController;

    public void Move()
    {
        var waypointPos = gameObject.transform.position;
        var newPosition = new Vector3(waypointPos.x, waypointPos.y + heightAboveWaypoint, waypointPos.z);

        waypointController.InactiveClickedWaypoint(this);

        if (!teleport)
        {
            iTween.MoveTo(player,
                iTween.Hash(
                    "position", newPosition,
                    "speed", speedMovement,
                    "easetype", "linear"
                )
            );
        }
        else
        {
            player.transform.position = newPosition;
        }
    }
}
