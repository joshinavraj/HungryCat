using UnityEngine;
using System.Collections;

public class SimplePlatformController : MonoBehaviour {

	bool facingRight = true;
    bool jump = false; //set to true to make the player jump

	[SerializeField]
    float moveForce = 365f; //how much force added for horizental motion.
	[SerializeField]
	float maxSpeed = 5f; //maximum horizental speed set;
	[SerializeField]
    float jumpForce = 750f; //How much vertical force added .
    private Transform groundCheck; 
	Animator anim;
    public bool grounded = false;
    private Rigidbody2D myRigidbody;

    
    // Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
		groundCheck = transform.Find ("groundCheck");
	}
	
	// Update is called once per frame
	void Update () {

        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        //sees if any part of a line between the player and groundCheck is on the ground layer

		anim.SetInteger ("State", 1);

		if (Mathf.Abs (myRigidbody.velocity.x) > 0) {
			anim.SetInteger ("State", 2);
		}

		if (!grounded) {
			anim.SetInteger ("State", 4);
		}
			
		if (Input.GetKeyDown(KeyCode.Space)){
			if(grounded)
				jump = true;
			
		}


	}

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        if (h * myRigidbody.velocity.x < maxSpeed)
            myRigidbody.AddForce(Vector2.right * h * moveForce); //actually moves the player 

        if (Mathf.Abs(myRigidbody.velocity.x) > maxSpeed)
            myRigidbody.velocity = new Vector2(Mathf.Sign(myRigidbody.velocity.x) * maxSpeed, myRigidbody.velocity.y); //caps player speed

		//for fliping player
        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        if (jump)
        {
            myRigidbody.AddForce(new Vector2(0f, jumpForce));
			jump = false;
        }


	}
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
	// Reset the position of cat.
    public void Reset()
    {
        gameObject.transform.position = new Vector2(0, 0);
    }

    /**
     * This method is for use in the PlayerSounds script
     * 
     **/
    public bool isJumping()
    {
        if (jump) return true;
        else return false;
    }



}
