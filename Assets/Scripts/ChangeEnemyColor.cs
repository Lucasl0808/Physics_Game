using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEnemyColor : MonoBehaviour
{
    public GameObject enemy;
    private List<ColorWeight> colorWeights = new List<ColorWeight>()
    {
        new ColorWeight(Color.red, 2),
        new ColorWeight(Color.blue, 1),
        new ColorWeight(Color.green, 3)
    };
    // Start is called before the first frame update
    private class ColorWeight
    {
        public Color color;
        public int weight;
        public ColorWeight(Color color, int weight)
        {
            this.color = color;
            this.weight = weight;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeEnemy()
    {
        Renderer rend = enemy.GetComponent<Renderer>();
        if (rend != null && rend.sharedMaterial != null)
        {
            Color selected = GetColor();
            rend.sharedMaterial.color = selected;
            
            //if (rend.sharedMaterial.color == Color.red)
            //{
             //   rend.sharedMaterial.color = Color.blue;
            //}
            //else 
           //{
            //    rend.sharedMaterial.color = Color.red;
           // }
        }
    }
    private Color GetColor()
    {
        int total = 0;
        foreach (var colorWeight  in colorWeights)
        {
            total += colorWeight.weight;
        }
        int randomNum = Random.Range(0, total);
        foreach(var colorWeight in colorWeights)
        {
            randomNum -= colorWeight.weight;
            if(randomNum <= 0)
            {
                return colorWeight.color;
            }
        }
        return Color.white;
    }
}
