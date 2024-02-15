using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterBack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Entered Teleporter");
            other.enabled = false;
            other.transform.position = new Vector3(0, 1, 0);
            other.enabled = true;
        }

    }
}
