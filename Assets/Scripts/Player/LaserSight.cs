using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSight : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
                lineRenderer.SetPosition(1, new Vector3(0, 0, hit.distance));
        }
        else
            lineRenderer.SetPosition(1, new Vector3(0, 0, 100));
            
    }
}
