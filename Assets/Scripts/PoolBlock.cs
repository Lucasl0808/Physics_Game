using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolBlock : MonoBehaviour
{
    private Vector3 location;
    public PoolBlock block;
    // Start is called before the first frame update
    void Start()
    {
        //location = new Vector3(Random.Range(-4f, 5f), 4f, Random.Range(12f, 20f));
        //transform.position = location;
    }
    /*
    public PoolBlock()
    {
        //PoolBlock poolBlock = new PoolBlock();
        block = Instantiate(block);
    }
    */

    // Update is called once per frame
    void Update()
    {
        
    }
}
