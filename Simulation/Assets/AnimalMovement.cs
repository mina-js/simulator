using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 lastFrameVelocity;
    public int minSpeed = 10;

    private Simulate mySimulate;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * minSpeed;
        mySimulate = gameObject.GetComponent<Simulate>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        lastFrameVelocity = rb.velocity;
    }

    private void FullBounce(Collision collision)
    {
        var contact = collision.contacts;
        float speed = lastFrameVelocity.magnitude;
        Vector3 direction = Vector3.Reflect(lastFrameVelocity.normalized, contact[0].normal);
        rb.velocity = direction * Mathf.Max(speed, minSpeed);
    }

    private void SimulateInteraction(Simulate other)
    {
        //Debug.Log("OTHER " + other.beingType + " MINE: " + mySimulate.beingType);
        mySimulate.Interact(other);
    }

    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("COLLISION " + collision.collider.tag + " " + (collision.collider.tag == "Barrier"));

        if (collision.collider.CompareTag("Barrier"))
        {
            FullBounce(collision);
        } else
        {
            SimulateInteraction(collision.gameObject.GetComponent<Simulate>());
            //TODO: Interact accoding to specific rules
            FullBounce(collision);
        }

    }

}
