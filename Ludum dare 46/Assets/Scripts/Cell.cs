using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Virus"))
        {
            AudioManager.PlayHitSound();

            Manager.playerDead = true;
            Destroy(GameObject.Find("Player(Clone)"));
        }
        else return;
    }
}
