using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayShooting : MonoBehaviour
{
    public Transform firePoint;
    public LineRenderer lineRender;
    public Transform cuserObject;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shootRay();
        }
    }
    void shootRay()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, cuserObject.position);
        if (hitInfo)
        {
            lineRender.SetPosition(0, firePoint.position);
            lineRender.SetPosition(1, hitInfo.point);
            Debug.Log(hitInfo.transform.name + " was hit");
        }
        else
        {
            lineRender.SetPosition(0, firePoint.position);
            lineRender.SetPosition(1, cuserObject.position);
        }
    }
}
