
using UnityEngine;

/**
 * Classe responsável pelas características e ações do Waypoint.
 */
public class Waypoint : MonoBehaviour
{
    public bool teleport;
    public GameObject player;
    public float speedMovement = 2f;
    public float heightAboveWaypoint = 0.2f;
    public WaypointController waypointController;

    /**
     * Posiciona o Jogador até à posição do Waypoint acionado.
     */
    public void Move()
    {
        waypointController.InactiveClickedWaypoint(this);

        // Caso o "teleport" não esteja ativado.
        if (!teleport)
        {
            iTween.MoveTo(player,
                iTween.Hash(
                    "position", GetNewPositionToPlayer(),
                    "speed", speedMovement,
                    "easetype", "linear"
                )
            );
        }
        else
        {
            player.transform.position = GetNewPositionToPlayer();
        }
    }

    /**
     * Retorna a nova posição do Jogador, baseado na posição do Waypoint.
     */
    private Vector3 GetNewPositionToPlayer()
    {
        var waypointPos = gameObject.transform.position;
        return new Vector3(
            waypointPos.x,
            waypointPos.y + heightAboveWaypoint,
            waypointPos.z
        );
    }
}
