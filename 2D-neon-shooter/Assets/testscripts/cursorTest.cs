using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            print(Input.mousePosition.x + " " + Input.mousePosition.y);
        }

        Vector3 pos = Input.mousePosition;

        pos = Camera.main.ScreenToWorldPoint(pos);
        pos.z = 0;

        transform.position = pos;
    }
}
