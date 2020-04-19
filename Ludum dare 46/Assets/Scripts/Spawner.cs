using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject virus;
    public float startSpawnInterval, intervalDecrease, xMin, xMax, yMin, yMax, treshold;
    private float spawnInterval;
    private bool spawnStarted = false;
    private Transform player;

    private void Start()
    {
        StopAllCoroutines();
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawnStarted)
        {
            spawnInterval = startSpawnInterval;
            player = GameObject.Find("Cell").transform;
            StartCoroutine(EnemySpawn());
            spawnStarted = true;
        }

        if (spawnInterval > .3f)
        {
            spawnInterval -= Time.deltaTime / intervalDecrease;
        } else
        {
            Manager.LevelUp();
            spawnInterval = startSpawnInterval;
            StartCoroutine(EnemySpawn());
        }
    }

    IEnumerator EnemySpawn()
    {
        while (true)
        {
            float x = 0f, y = 0f;

            while (Mathf.Abs(x) < treshold || Mathf.Abs(y) < treshold)
            {
                x = Random.Range(xMin, xMax);
                y = Random.Range(yMin, yMax);
            }

            Vector2 spawnPosition = new Vector2(x, y);
            spawnPosition += new Vector2(player.position.x, player.position.y);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(virus, spawnPosition, spawnRotation);


            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
