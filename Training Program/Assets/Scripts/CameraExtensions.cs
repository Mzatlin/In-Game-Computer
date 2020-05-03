using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CameraExtensions
{

    public static void FixateToPoint(this Camera cam, Transform camPosition)
    {
    //    camPosition.transform.position = Vector3.Lerp(camPosition.transform.position, fixationPoint.position, 15 * Time.deltaTime);
    //    var q = Quaternion.LookRotation(fixationPoint.position - fixationPoint.transform.position);
    //    camPosition.transform.rotation = Quaternion.RotateTowards(camPosition.transform.rotation, q, 90.0f * Time.deltaTime);
    }
}
