using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] fruitToSpawnPrefabs;
    public GameObject bombPrefab;

    public Transform[] spawnPlaces;
    public int changeToSpawnBomb = 10;
    public float minWait = 0.3f;
    public float maxWait = 1f;
    public float minForce = 5;
    public float maxForce = 15;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    private IEnumerator SpawnFruits()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));

            Transform t = spawnPlaces[Random.Range(0, spawnPlaces.Length)];

            GameObject go = null;
            float rnd = Random.Range(0, 100);

            if (rnd < changeToSpawnBomb)
            {
                go = bombPrefab;
            }
            else
            {
                go = fruitToSpawnPrefabs[Random.Range(0, fruitToSpawnPrefabs.Length)];
            }


            GameObject fruit = Instantiate(go, t.position, t.rotation);

            fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minForce, maxForce), ForceMode2D.Impulse);

            Debug.Log("Spawning fruit");

            Destroy(fruit, 5f);
        }
    }
}
