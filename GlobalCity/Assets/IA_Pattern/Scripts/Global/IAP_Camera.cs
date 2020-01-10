using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class IAP_Camera : MonoBehaviour
{
    public static Action<Ray> OnCameraRay = null;
    public static Action<Vector3> OnCameraCursor = null;

    public void Update()
    {
        GetRayCast();
        GetMousePosition();
    }
    void GetRayCast()
    {
        Ray _r = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        OnCameraRay?.Invoke(_r);
    }
    void GetMousePosition()
    {
        Vector3 _r = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        OnCameraCursor?.Invoke(_r);
    }
}
