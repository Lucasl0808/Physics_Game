using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Vector3 location;
    private float moveTimer = 0f;
    private float interval = 3f;
    private bool startMoving = false;
    private Rigidbody rb;
    private bool detected = false;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        RandomPosition();
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * 10, Color.blue);

        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, 10F))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                Debug.Log("Detected Player");
                detected = true;

            }
        }

        transform.Rotate(0f, 20 * Time.deltaTime, 0f, Space.Self);

        moveTimer += Time.deltaTime;
        if(moveTimer >= interval && rb != null && !detected)
        {
            RandomPosition();
            moveTimer = 0f;
            Debug.Log("RandomMove");
            startMoving = true;

        }
        if (startMoving && rb != null && !detected)
        {
            Debug.Log(location.x + " " + location.y + " " + location.z);

            //transform.position = location;
            transform.position = location;
        }

        if (detected)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            transform.LookAt(player.transform.position);
        }
    }
    void RandomPosition()
    {
        float randomX = Random.Range(-6f, 5f);
        float randomZ = Random.Range(14f, 25f);

        location = new Vector3(randomX, 1f, randomZ);
    }
}
