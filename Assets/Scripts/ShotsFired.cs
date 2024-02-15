using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShotsFired : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI number;
    private int shots = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump")){
            updateText();
        }
    }
    public void updateText()
    {
        shots++;
        number.text = shots.ToString();
    }
}
