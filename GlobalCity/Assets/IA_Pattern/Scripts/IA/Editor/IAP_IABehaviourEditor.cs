using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(IAP_IABehaviour))]
public class IAP_IABehaviourEditor : Editor
{
    IAP_IABehaviour eTarget = null;
    private void OnEnable()
    {
        eTarget = (IAP_IABehaviour)target;
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
        Handles.color = new Color(.2f, 0.5f, .8f, 1f);
        Handles.DrawWireDisc(eTarget.StartPos, Vector3.up, eTarget.StartPosRange);
        Handles.color = new Color(.2f, 0.5f, .8f, .2f);
        Handles.DrawSolidDisc(eTarget.StartPos, Vector3.up, eTarget.StartPosRange);
        Handles.color = Color.green;
        Handles.DrawWireDisc(eTarget.transform.position, Vector3.up, eTarget.AggroRange);
    }
}
