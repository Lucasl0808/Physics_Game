using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BlockSpawnPool : MonoBehaviour
{
    //private int poolSize = 4;
    public static ObjectPool<PoolBlock> _pool;
    //private List<PoolBlock> spawnList;
    //private int spawnCount;
    public PoolBlock spawnBlock;
    public int maxPoolSize;
    public float interval = 2f;


    // Start is called before the first frame update
    void Start()
    {
        // from https://thegamedev.guru/unity-cpu-performance/object-pooling/
        //_pool = new ObjectPool<PoolBlock>(createFunc: () => new PoolBlock() , actionOnGet: (obj) => obj.gameObject.SetActive(true), actionOnRelease: (obj) => obj.gameObject.SetActive(false), actionOnDestroy: (obj) => Destroy(obj), collectionCheck: false, defaultCapacity: 4, maxSize: 4);

        /*spawnList = new List<PoolBlock>();
        PoolBlock temp;
        for(int i = 0; i < poolSize; i++)
        {
            if (spawnCount < poolSize)
            {
                temp = Instantiate(spawnBlock);
                spawnList.Add(temp);
                spawnCount++;
            }
        }
        */
        InvokeRepeating("spawnBlocks", 0f, interval);
        
        
    }

    void spawnBlocks()
    {

        Vector3 location = new Vector3(Random.Range(-4f, 5f), 4f, Random.Range(12f, 20f));
        PoolBlock obj = Instantiate(spawnBlock, location, Quaternion.identity);
        Destroy(obj.gameObject, 2f);
    }
}
