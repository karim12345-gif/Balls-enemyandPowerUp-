using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovment : MonoBehaviour
{

    public float speed = 0.5f;
    private Rigidbody playerRB;
    private float zBound = 9f;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();// reference 
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Bounds();

    }

    /// <summary>
    /// movement of the player 
    /// </summary>
    void MovePlayer()
    {
        float horiznotalInput = Input.GetAxis("Horizontal"); // to get the horizontal movemnt 
        float verticalInput = Input.GetAxis("Vertical"); // to get the vertical movement 

        playerRB.AddForce(Vector3.forward * speed * verticalInput, ForceMode.Impulse); // for up and down movement 
        playerRB.AddForce(Vector3.right * speed * horiznotalInput, ForceMode.Impulse); // for up and down movement  , impluse will make the speed way faster so thats why i made the speed  as 0.5


    }

    /// <summary>
    /// keeping bounds for the player
    /// </summary>
    void Bounds()
    {
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound); // applying new postion for the player to not pass
        }
        else if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound); // applying new postion for the player to not pass
        }
    }

    /// <summary>
    /// collison with other objects 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("player has collied with the enemy");
        }
    }



    /// <summary>
    /// when collide with an object that has a trigger turend on 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            Debug.Log("you have powerUp now ! ");
            Destroy(other.gameObject);
        }
    }
}
