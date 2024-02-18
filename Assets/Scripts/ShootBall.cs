using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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
    public int enemiesKilled = 0;
    public TextMeshProUGUI text2;
    private bool onShootCD = false;
    private float shootcd = 1f;
    public TextMeshProUGUI text3;
    public int shotsFired = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(spawnPoint.position, spawnPoint.forward * 6, Color.red);

        if (Input.GetButtonDown("Jump") && !onShootCD)
        {
            Shoot();
            Pop.Play();
            shotsFired += 1;
            text3.text = shotsFired.ToString();
            StartCoroutine(ShootCD());
            
        }
        if(enemiesKilled == 5)
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
                Destroy(hit.collider.gameObject, 1f);
                enemiesKilled += 1;
                text2.text = enemiesKilled.ToString();
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

    IEnumerator ShootCD()
    {
        onShootCD = true;
        yield return new WaitForSeconds(shootcd);
        onShootCD = false;
    }
}
