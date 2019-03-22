
using UnityEngine;

public class WaypointMove : MonoBehaviour
{
    public GameObject player;
    public bool teleport;
    public float speedMovement = 6f;
    public float heightAboveWaypoint = 1f;

    public void Move(GameObject waypoint)
    {
        var waypointPos = waypoint.transform.position;
        var newPosition = new Vector3(waypointPos.x, waypointPos.y + heightAboveWaypoint, waypointPos.z);

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
