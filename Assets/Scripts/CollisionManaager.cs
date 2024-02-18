using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CollisionManaager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private CharacterController characterController;
    public bool collide;
    public Slider slider;
    private bool onBreak = false;
    private float delay = 2.0f;

    private bool wasCollideLastFrame = false;

    void Start()
    {
        collide = player.GetComponent <PlayerMove>().collided;
    }

    // Update is called once per frame

    void LateUpdate()
    {
        collide = player.GetComponent<PlayerMove>().collided;
    }

    void Update()
    {
        if (slider.value <= 0)
        {
            SceneManager.LoadScene("Loser", LoadSceneMode.Single);
        }
        if (collide && !onBreak && !wasCollideLastFrame)
        {
            slider.value -= 5;
            Debug.Log("health decreasing");
            StartCoroutine(StartBreak());
            wasCollideLastFrame=true;
        }
        else
        {
            wasCollideLastFrame = false;
        }

    }

    private void Break()
    {
        StartCoroutine(StartBreak());
    }
    IEnumerator StartBreak()
    {
        onBreak = true;
        yield return new WaitForSeconds(delay);
        onBreak = false;
    }
}
