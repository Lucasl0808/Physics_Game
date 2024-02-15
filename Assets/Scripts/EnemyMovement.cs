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
    // Start is called before the first frame update
    void Start()
    {
        RandomPosition();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        moveTimer += Time.deltaTime;
        if(moveTimer >= interval && rb != null)
        {
            RandomPosition();
            moveTimer = 0f;
            Debug.Log("RandomMove");
            startMoving = true;

        }
        if (startMoving && rb != null)
        {
            Debug.Log(location.x + " " + location.y + " " + location.z);

            //transform.position = location;
            transform.position = location;
        }
    }
    void RandomPosition()
    {
        float randomX = Random.Range(-6f, 5f);
        float randomZ = Random.Range(14f, 25f);

        location = new Vector3(randomX, 1f, randomZ);
    }
}
