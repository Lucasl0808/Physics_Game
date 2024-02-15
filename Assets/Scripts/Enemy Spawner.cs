using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public ObjectPool<GameObject> pool;
    public List<EnemySpawner> list;
    public int poolSize = 5;
    private Vector3 startPos;
    private Quaternion startRot;
    // Start is called before the first frame update

    private void Awake()
    {
        pool = new ObjectPool<GameObject>(CreateEnemy, null, PutEnemyBack, defaultCapacity: 5);
    }
    void Start()
    {
        startPos = Enemy.transform.position;
        startRot = Enemy.transform.rotation;

    }
    private GameObject CreateEnemy()
    {
        var newEnemy = Instantiate(Enemy, startPos, startRot);
        return newEnemy;
    }

    private void PutEnemyBack(GameObject newEnemy)
    {
        newEnemy.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 pos = new Vector3(Random.Range(-6f, 8f), 1f, Random.Range(14f, 30f));
            Debug.Log("Entered Spawner");
            var createdEnemy = pool.Get();
            createdEnemy.transform.position = pos;
            Debug.Log("pooling");
            
        }

    }
}
