using UnityEngine;


public class TriggerZone1 : MonoBehaviour
{
    public PlayerMovement PlayerMovement;
    public AudioSource audioSource;

    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger");
            audioSource.Play();
            // Destroy the object
            Destroy(gameObject, 0.25f);


            PlayerMovement.cabbageCount++;
        }
    }
}
