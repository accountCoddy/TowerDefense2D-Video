using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<Transform> Waypoints = new();

    private void OnValidate()
    {
        Waypoints.Clear();

        for (int i = 0; i < transform.childCount; i++)
        {
            Waypoints.Add(transform.GetChild(i));
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        for (int i = 1; i < transform.childCount; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i - 1).position, transform.GetChild(i).position);
            Gizmos.DrawSphere(transform.GetChild(i - 1).position, 0.2f);
        }

        Gizmos.DrawSphere(transform.GetChild(transform.childCount - 1).position, 0.2f);
    }

}
