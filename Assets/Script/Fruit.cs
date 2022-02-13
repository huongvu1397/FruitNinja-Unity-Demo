using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{

    public GameObject slicedFruitPrefab;
    public float explosionRadius = 5f;
    private GameManager myGm;
    public int scoreAmount = 3;

    public void CreateSlicedFruit()
    {
        GameObject inst = Instantiate(slicedFruitPrefab, transform.position, transform.rotation);

        Rigidbody[] rbOnSliced = inst.transform.GetComponentsInChildren<Rigidbody>();

        foreach (var rigidbody in rbOnSliced)
        {
            rigidbody.transform.rotation = Random.rotation;
            rigidbody.AddExplosionForce(Random.Range(500,1000), transform.position, explosionRadius);
        }

        //dung kieu nay cung dc ma khong nen
        //FindObjectOfType<GameManager>().InCreaseScore(3);
        //nen dung kieu nay
        myGm.InCreaseScore(scoreAmount);

        //play sound
        myGm.PlayRandomSliceSound();

        //destroy the current sliced fruit.
        Destroy(inst, 5f);
        //destroy the current fruit.
        Destroy(gameObject);
    }

    private void Start()
    {
        myGm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();

        if (!b)
        {
            return;
        }
        CreateSlicedFruit();
    }

}
