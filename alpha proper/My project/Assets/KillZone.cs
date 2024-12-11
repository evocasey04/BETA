using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Destroy any object that enters the Kill Zone
        Destroy(collision.gameObject);
    }
}
