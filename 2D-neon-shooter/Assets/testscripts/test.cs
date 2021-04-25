using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    public string printText;
    public float speed;
    public bool killPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        print("Started - text: " + printText);

        gameObject.GetComponent<Renderer>().material.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed, 0, 0);

        if (killPlayer)
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        print("Enabled");
    }

    void OnDisable()
    {
        print("Disabled");
    }
}
