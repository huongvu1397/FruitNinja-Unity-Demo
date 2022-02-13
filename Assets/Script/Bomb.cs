using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    private GameManager myGm;

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
        myGm.PlayBombSound();
        myGm.OnBombHit();
    }

    

}
