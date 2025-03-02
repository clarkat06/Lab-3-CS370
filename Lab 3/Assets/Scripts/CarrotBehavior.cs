using UnityEngine;


public class TriggerZone : MonoBehaviour
{
    public PlayerMovement PlayerMovement;

    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger");
            // Destroy the object
            Destroy(gameObject);


            PlayerMovement.carrotCount++;
        }
    }
}
