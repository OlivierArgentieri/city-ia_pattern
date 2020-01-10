using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(IAP_Player))]
public class IAP_PlayerEditor : Editor
{
    IAP_Player eTarget = null;
    private void OnEnable()
    {
        eTarget = (IAP_Player)target;
    }
    private void OnSceneGUI()
    {
        Handles.color = Color.white;
        Handles.DrawWireDisc(eTarget.transform.position, Vector3.up, eTarget.AttackRange);
        if (eTarget.CanAttack)
        {
            Handles.color = new Color(1, 0, 0, .1f);
            Handles.DrawSolidDisc(eTarget.transform.position, Vector3.up, eTarget.AttackRange);
        }
    }
}
