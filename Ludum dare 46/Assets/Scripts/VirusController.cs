using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusController : MonoBehaviour
{

    public float speed;

    private Transform cell;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cell == null)
        {
            cell = GameObject.Find("Cell").transform;
        }

        Vector3 cellPos = cell.position;
        Vector3 dir = new Vector3(transform.position.x - cellPos.x, transform.position.y - cellPos.y, 0f);

        transform.up = dir;
    }

    private void FixedUpdate()
    {
        Vector2 dir = Vector2.down * speed * 100;
        dir = transform.TransformDirection(dir);

        rb.velocity = dir * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Shield")
        {
            AudioManager.PlayEnemyHitSound();
            Manager.enemiesDestroyed++;
            Destroy(gameObject);
        }
        else return;
    }
}
