using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public GameManager gameManager;
    public float slowDownFactor = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            player.ApplySlowdown(slowDownFactor);
        }
    }
}

//ERROR IN CODE: Assosiate PlayerController with movements of player/s when colliding with the enemy