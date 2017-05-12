using UnityEngine;
using System.Collections;

public class characterController : MonoBehaviour {
    public float maxSpeed = 10f;
    public float jumpspeed;
    float movevelocity;
    bool grounded = true;
    int cptgrounded = 0;
    float moveglitch;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>();

    if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (grounded)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpspeed);
                grounded = false;
                cptgrounded++;
            }
            else if(!grounded && cptgrounded < 2)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpspeed);
                cptgrounded++;
            }

        }
        movevelocity = Input.GetAxis("Horizontal") * Time.deltaTime;
        if (movevelocity > 0)
        {
            movevelocity = (movevelocity/2);
            
        }
       else if(movevelocity < 0)
        {
            movevelocity = (movevelocity / 2);
        }
            

        GetComponent<Rigidbody2D>().velocity = new Vector2(movevelocity*maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }
    void OnCollisionEnter2D()
    {
        grounded = true;
        if (cptgrounded != 0 )
        {
            cptgrounded = 0;
        }
    }
}
