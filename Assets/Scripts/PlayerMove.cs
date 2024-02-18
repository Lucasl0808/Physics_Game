using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float speed = 3.0F;
    public float rotateSpeed = 1.0F;
    public float jumpForce = 2;
    public float gravity = 1F;
    private CharacterController controller;
    public bool collided = false;
    public Slider hp;
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    void Update()
    {
        if (transform.position.y < -5)
        {
            hp.value = 0;
        }

        collided = false;
        if (Input.GetButton("Fire3"))
        {
            Debug.Log("Sprinting");
            speed = 10.0F;
        }
        else
        {
            speed = 3.0F;
        }
        Debug.Log(collided);
        // Rotate around y - axis
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

        // Move forward / backward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);

    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Enemy"))
        {

            Debug.Log("enemy collided");
            collided = true;
            Debug.Log(collided);
        }
    }
}
