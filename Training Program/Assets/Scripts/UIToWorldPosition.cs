using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIToWorldPosition : MonoBehaviour
{

    [SerializeField]
    Transform targetTransform;

    void Update()
    {
        Vector3 ScreenPoint = Camera.main.WorldToScreenPoint(targetTransform.position);
        transform.position = ScreenPoint;

        Vector3 viewPortPoint = Camera.main.WorldToViewportPoint(targetTransform.position);
        float distanceFromCenter = Vector3.Distance(viewPortPoint, Vector2.one * 0.5f);
        // bool show = distanceFromCenter < 0.5f;

    }
}
