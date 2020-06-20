using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectProximity : MonoBehaviour, IFindDistance {

    [SerializeField]
    float distanceFromObject = 10;

    public bool FindDistance(RaycastHit hit)
    {
        var dot = Vector3.Dot(transform.forward, hit.transform.forward);
        if (dot < 0 && Vector3.Distance(transform.position, hit.transform.position) < distanceFromObject)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
