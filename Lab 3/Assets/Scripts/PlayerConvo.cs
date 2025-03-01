using NUnit.Framework.Constraints;
using Unity.Multiplayer.Center.Common.Analytics;
using UnityEngine;

public class PlayerConvo : MonoBehaviour
{
    [SerializeField] float talkDistance = 2;
    public bool inConversation;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            Debug.Log("E Pressed");
            Interact();
        }    
    }

    void Interact() {
        if (inConversation) {
            GameManager.Instance.SkipLine();
        }
        else {
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, talkDistance, Vector2.up, 0, LayerMask.GetMask("NPC"));
            if (hit){
                if (hit.collider.gameObject.TryGetComponent(out NPC npc))
                {
                    GameManager.Instance.StartDialogue(npc.dialogueAsset.dialogue, npc.StartPosition, npc.npcName);

                }
            } 
        }
    }

    void JoinConversation()
    {
    inConversation = true;
    Debug.Log("Started Conversation");  // Check if this is triggered
    }

void LeaveConversation()
    {
    inConversation = false;
    Debug.Log("Ended Conversation");  // Check if this is triggered
    }
    private void OnEnable()
    {
        GameManager.OnDialogueStarted += JoinConversation;
        GameManager.OnDialogueEnded += LeaveConversation;
    }

    private void OnDisable()
    {
        GameManager.OnDialogueStarted -= JoinConversation;
        GameManager.OnDialogueEnded -= LeaveConversation;
    }
}
