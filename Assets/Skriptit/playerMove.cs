using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {

    public float speed;

    private Rigidbody rb;

    //jumping
    bool grounded = true;
    //jumpforce
    public float jumpForce = 10.0f;
    public float gravity = 20.0f;

    public GameObject pausedmenu, spawnpoint;

    void Load()
    {
        if(GameControl.control.load == true)
        {

            transform.position = GameControl.control.charpos;
            GameControl.control.load = false;

        }
    }

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {


        if (Input.GetButtonDown("Escape"))
        {

            Cursor.visible = true;
            pausedmenu.SetActive(true);
            Time.timeScale = 0;
           
        }



        // horizontal movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        // vertical movement
        float moveVertical = Input.GetAxis("Vertical");

        // counts the movement
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // jumping
        Vector3 jump = new Vector3(0, jumpForce, 0);


        // grounded check to see if y axis of player hits ground
        // might become problem if it's hitting something that's not on y axis
        if (rb.velocity.y == 0)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        if (Input.GetButton("Jump") && grounded == true)
        {
            rb.AddForce(jump);
        }


        rb.AddForce(movement * speed);
	}





}
