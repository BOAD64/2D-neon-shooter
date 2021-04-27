using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class test : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject ball;
    [SerializeField] private float bombSpeed;
    [SerializeField] private GameObject cuserObject;
    [SerializeField] private Transform BulletPos;
    [SerializeField] private float FireRate;

    Rigidbody2D rb;
    float xInput, yInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("testCoroutine");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.GetButtonDown("Fire1"))
        {
            InvokeRepeating("spawnBall", 0f, FireRate);
        }

        if (Input.GetButtonUp("Fire1"))
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

    IEnumerator testCoroutine()
    {
        print("Coroutine start");
        yield return new WaitForSeconds(4f);
        print("wha yo");
        yield return new WaitForSeconds(2f);
        print("done");
    }
}