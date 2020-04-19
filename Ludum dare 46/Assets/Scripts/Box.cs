using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 vel = Vector2.one * speed;

        rb.AddForce(transform.TransformDirection(vel));
        rb.AddForce(-transform.TransformDirection(vel) * 0.7f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float rot = Random.Range(89f, 269f);

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + rot);
    }

    bool stuck ()
    {
        return false;
    }
}
