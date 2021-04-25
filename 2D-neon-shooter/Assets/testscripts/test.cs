using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float speed;
    public bool killPlayer = false;

    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<Renderer>().material.color = Color.green;
        //InvokeRepeating("spawnBall", 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(speed, 0, 0);

        if (Input.GetButtonDown("Jump"))
        {
            Invoke("spawnBall", 0f);
            transform.Translate(speed, 0, 0);
        }

        if (killPlayer)
        {
            Destroy(gameObject);
        }

        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        transform.Translate(xInput * speed, yInput * speed, 0);

    }

    void spawnBall()
    {
        Instantiate(ball, transform.position + new Vector3(0, -0.5f, 0), Quaternion.identity);
    }
}