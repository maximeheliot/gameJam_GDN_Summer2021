using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Class <c>PitFallController</c> is a Unity component script used to manage the pit tiles behaviour.
/// </summary>
public class PitFallController : MonoBehaviour
{
    /// <summary>
    /// Instance variable <c>pitfallTileMap</c> represents the tile map containing the different pit tiles the player could fall into.
    /// </summary>
    private Tilemap pitfallTileMap;

    [SerializeField]
    private GameObject CheckLocation;

    void Awake() {
        pitfallTileMap = GetComponent<Tilemap>();
    }

    /// <summary>
    /// This method is called each frame where another object is within a trigger collider attached to this object
    /// </summary>
    /// <param name="other">A <c>Collider2D</c> Unity component representing the collider of the object that it collides with.</param>
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player")) {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if(!playerController.isBouncing) {
                if (pitfallTileMap.HasTile(pitfallTileMap.WorldToCell(playerController.TilemapCollisionPoint.transform.position)))
                {
                    other.GetComponent<Animator>().SetTrigger("triggerFall");
                }
            }
        } else if(other.CompareTag("Ghost")) {
            GhostController ghostController = other.GetComponent<GhostController>();
            if(!ghostController.isBouncing) {
                if (pitfallTileMap.HasTile(pitfallTileMap.WorldToCell(ghostController.TilemapCollisionPoint.transform.position)))
                {
                    other.GetComponent<Animator>().SetTrigger("triggerFall");
                }
            }
        }
    }
}