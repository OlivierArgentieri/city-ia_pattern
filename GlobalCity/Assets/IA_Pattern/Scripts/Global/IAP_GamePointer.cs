using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class IAP_GamePointer : MonoBehaviour
{
    public static Action<GameObject, bool> OnTargetSelect = null;
    public static Action<Vector3,bool> OnMoveInput = null;
    public bool ActionInput => Input.GetKeyDown(KeyCode.Mouse0);
    Transform lastTarget = null;

    [SerializeField] LayerMask targetLayer = 0;
    [SerializeField] LayerMask moveLayer = 0;

    private void Awake()
    {
        IAP_Camera.OnCameraRay += SelectTarget;
        IAP_Camera.OnCameraRay += SelectDestination;
    }
    void SelectDestination(Ray _pos)
    {
        RaycastHit _groundHit;
        bool _hit = (Physics.Raycast(_pos, out _groundHit, 100, moveLayer));
        if(_hit)
           OnMoveInput?.Invoke(_groundHit.point, ActionInput);
    }
    void SelectTarget(Ray _r)
    {
        RaycastHit _targetHit;
        bool _hit = (Physics.Raycast(_r, out _targetHit, 100, targetLayer));
        Transform _target = _hit ? _targetHit.transform : null;
        OnTargetSelect?.Invoke(_target?.gameObject, ActionInput);
    }
}
