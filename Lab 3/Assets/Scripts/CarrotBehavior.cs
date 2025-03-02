using UnityEngine;


public class TriggerZone : MonoBehaviour
{
    public PlayerMovement PlayerMovement;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger");
            audioSource.Play();
            // Destroy the object
            Destroy(gameObject, 0.25f);


            PlayerMovement.carrotCount += 1;
        }
    }
}
