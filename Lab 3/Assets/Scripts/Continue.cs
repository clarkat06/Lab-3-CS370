using UnityEngine;

public class Continue : MonoBehaviour
{

    public void ReactToClick() {
        Debug.Log("I've been clicked");
        Initiate.Fade("Platformer", Color.black, 1.0f);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
