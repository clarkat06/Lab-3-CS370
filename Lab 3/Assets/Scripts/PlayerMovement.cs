using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    float horizontal;
    float vertical;
    public TextMeshProUGUI carrotText;  // UI Text to display the score
    public int carrotCount = 0;

    public TextMeshProUGUI cabbageText;
    public int cabbageCount = 0;

    public float runSpeed = 5f;
    private bool m_Grounded;

    public UnityEvent OnLandEvent;

    private int jumpCount = 0;






    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        carrotText.text = "x" + carrotCount.ToString();
        cabbageText.text = "x" + cabbageCount.ToString();
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        if (OnLandEvent == null) {
		    OnLandEvent = new UnityEvent();
        }
        OnLandEvent.AddListener(Landed);
    }

    // Update is called once per frame
    void Update()
    {
        cabbageText.text = "x" + cabbageCount.ToString();
        carrotText.text = "x" + carrotCount.ToString();
        horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal < 0) {
            spriteRenderer.flipX = true;
        } else {
            spriteRenderer.flipX = false;
        }
        animator.SetFloat("horizontal", horizontal);
        if (Input.GetKeyDown("space") && jumpCount < carrotCount + 1)
        {
            rigidbody2D.AddForce(Vector2.up * 2000);
            jumpCount += 1;
            if (carrotCount > 0 && jumpCount > 1) {
            carrotCount -= 1;
            }
            animator.SetBool("jump",true);
            Debug.Log("space key was pressed");
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && cabbageCount > 0){
            Debug.Log("Left Shift key was pressed");
            if(horizontal < 0){
                rigidbody2D.AddForce(Vector2.left * 30000);
                cabbageCount -= 1;
            } else {
                rigidbody2D.AddForce(Vector2.right * 30000);
                cabbageCount -= 1;
            }
        }

        
    }

    void FixedUpdate()
    {
        rigidbody2D.linearVelocity = new Vector2(horizontal * runSpeed, rigidbody2D.linearVelocity.y);
    
		bool wasGrounded = m_Grounded;
;
        m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
                m_Grounded = true;
                
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}

    public void Landed() {
        animator.SetBool("jump", false);
        jumpCount = 0;
    }

}