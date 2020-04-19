using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    public float smoothSpeed, moveSpeed;
    public Vector2 minPosition, maxPosition;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 dir = new Vector3(transform.position.x - mousePos.x, transform.position.y - mousePos.y, 0);

        transform.up = Vector3.Lerp(transform.up, dir, smoothSpeed);
    }

    private void LateUpdate()
    {
        ClampPlayerPosition();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveInput() * moveSpeed * 100f * Time.fixedDeltaTime;
    }

    Vector2 moveInput()
    {
        float x, y;
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        return new Vector2(x, y);
    }

    void ClampPlayerPosition()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPosition.x, maxPosition.x), Mathf.Clamp(transform.position.y, minPosition.y, maxPosition.y), transform.position.z);
    }
}
