using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Script : MonoBehaviour
{

    public float SpawnerTimer = 10f;
    [SerializeField]
    private GameObject enemy1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(SpawnerTimer, enemy1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newenemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5f), Random.Range(-3f, 3f), 0), Quaternion.identity);
        newenemy.layer = 3;
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
