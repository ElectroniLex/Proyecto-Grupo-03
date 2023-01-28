using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    public Transform Yasmin_CameraRig;

    private void LateUpdate()
    {
        Vector2 newPosition = Yasmin_CameraRig.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
}
