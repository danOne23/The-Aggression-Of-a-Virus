using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static void PlayHitSound()
    {
        GameObject.Find("HitSound").GetComponent<AudioSource>().Play();
    }

    public static void PlayClickSound()
    {
        GameObject.Find("ClickSound").GetComponent<AudioSource>().Play();
    }

    public static void PlayEnemyHitSound()
    {
        GameObject.Find("EnemyHitSound").GetComponent<AudioSource>().Play();
    }
}
