using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAP_Animator : MonoBehaviour
{
    [SerializeField] Animator animator = null;
    public bool IsValid => animator;
    public void SetBool(string _paramName, bool _status)
    {
        if (!IsValid) return;
        animator.SetBool(_paramName, _status);
    }
}
