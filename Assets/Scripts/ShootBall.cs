using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEditor.TextCore.Text;

public class ShootBall : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    public float velocity = 500F;
    public float launchPos = 0.5F;
    public Transform spawnPoint;
    public AudioSource Pop;
    public int Counter = 0;
    public TextMeshProUGUI text;
    public int poolSize = 6;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(spawnPoint.position, spawnPoint.forward * 6, Color.red);

        if (Input.GetButtonDown("Jump"))
        {
            Shoot();
            Pop.Play();
        }
        if(Counter == 2)
        {
            SceneManager.LoadScene("Winner", LoadSceneMode.Single);
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(spawnPoint.position, spawnPoint.forward, out hit, 6F))
        { 
            if(hit.collider.gameObject.tag == "Enemy")
            {
                Rigidbody rb = hit.collider.gameObject.GetComponent<Rigidbody>();
                rb.isKinematic = false;
                Destroy(hit.collider.gameObject, 2f);
            }
            if(hit.collider.gameObject.tag == "Block")
            {
                
                Debug.Log("Looking at Block");
                Renderer rend = hit.collider.gameObject.GetComponent<Renderer>();
                if(rend.material.color != Color.red)
                {
                    Counter += 1;
                    text.text = Counter.ToString();
                    Debug.Log("Counter = " + Counter);
                }
                rend.material.color = Color.red;

            }
        }
        GameObject newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        newBullet.GetComponent<Rigidbody>().AddRelativeForce(0, 0, velocity);
        Destroy(newBullet, 3F);
    }
}
