using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float speed;
    public GameObject ball;
    public float bombSpeed;
    public GameObject cuserObject;
    public Transform BulletPos;

    Rigidbody2D rb;
    float xInput, yInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.GetButtonDown("Jump"))
        {
            InvokeRepeating("spawnBall", 0f, 0.2f);
        }

        if (Input.GetButtonUp("Jump"))
        {
            CancelInvoke("spawnBall");
        }

        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(xInput * speed, yInput * speed, 0);
    }

    void spawnBall()
    {
        GameObject bomb = Instantiate(ball, BulletPos.position, transform.rotation);
        bomb.GetComponent<Rigidbody2D>().velocity = transform.right * bombSpeed;
    }
}