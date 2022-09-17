using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ABSTRACTION
public abstract class AbstractExample : MonoBehaviour
{
    protected abstract void Move();
}

// INHERITANCE - MonoBehaviour
public class PlayerManager : AbstractExample
{
    [SerializeField]
    private float speed = 25;
    [SerializeField]
    private float turningSpeed = 25;
    [SerializeField]
    private Vector3 centerOfMass;

    private Rigidbody playerRb;    

    // Start is called before the first frame update
    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();

        //playerRb.centerOfMass = playerRb.gameObject.transform.Find("CenterOfMass").transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    protected override void Move()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move forward
        playerRb.AddRelativeForce(Vector3.forward * verticalInput * speed);

        // Rotate
        playerRb.transform.Rotate(Vector3.up, Time.fixedDeltaTime * verticalInput * horizontalInput * turningSpeed);
    }
}
