 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speedDown = 5.0f;
    private Rigidbody objectRb;
    private float zBoudnries = -10;
    // Start is called before the first frame update
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        objectRb.AddForce(Vector3.forward * -speedDown);

        Boundries();
    }


    void Boundries()
    {
        if(transform.position.z < zBoudnries)
        {
            Destroy(gameObject); // if less then destroy it 
        }
    }
}
