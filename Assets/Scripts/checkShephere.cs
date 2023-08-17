using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkShephere : MonoBehaviour
{
    public float radius;
    public LayerMask layer;

    void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, radius, layer))
        {
            Debug.Log("check overlap");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, radius);
    }
}
