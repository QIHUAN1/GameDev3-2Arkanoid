using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyPrefeb;

    [SerializeField]
    private GameObject EnemyTarget;


    [SerializeField]
    private float enemyInterval = 20f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(enemyInterval, EnemyPrefeb));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnEnemy(float intervel, GameObject enemy)
    {
        yield return new WaitForSeconds(intervel);
        GameObject newEnemy = Instantiate(enemy, new Vector3(EnemyTarget.transform.position.x, EnemyTarget.transform.position.y, 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(intervel, enemy));
    }
}
