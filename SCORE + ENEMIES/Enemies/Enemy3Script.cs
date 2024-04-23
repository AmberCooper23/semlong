
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public GameManager gameManager;
    public int penalty = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.scoreManager.SubtractScore(penalty);
        }
    }
}
