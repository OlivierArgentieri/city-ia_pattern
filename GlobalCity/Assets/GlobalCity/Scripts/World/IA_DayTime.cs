using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IA_DayTime : MonoBehaviour
{
    public static IA_DayTime Instance = null;
    public static event Action<int> OnUpdateTime = null;
    [SerializeField,Range(0,20)] float daySpeed = 1;
    public float DaySpeed => daySpeed;
    [SerializeField] int dayTime = 12;
    int lastTime = 0;
    [SerializeField] float angle = 0;
    [SerializeField] Light sun = null;

    void Awake() => Instance = this;
    private void Start()
    {
        lastTime = dayTime;
        OnUpdateTime?.Invoke(dayTime);
    }
    private void Update()
    {
        UpdateTime();
        UpdateSun();
    }
    void UpdateTime()
    {
        angle += Time.deltaTime* daySpeed;
        angle = angle > 360  ? 1 : angle;
        dayTime = (int) (angle / 360 * 24);
        if(dayTime != lastTime)
        {
            OnUpdateTime?.Invoke(dayTime);
            lastTime = dayTime;
        }
    }
    void UpdateSun()
    {
        if (sun)
        {
            sun.transform.position = -GetSunPosition();
            sun.transform.LookAt(Vector3.zero);
        }
    }
    Vector3 GetSunPosition()
    {
        float _x = Mathf.Cos(angle * Mathf.Deg2Rad) * 100;
        float _z = Mathf.Sin(angle * Mathf.Deg2Rad) * 100 ;
        return new Vector3(_z, _x, 0);
    }
    private void OnGUI()
    {
        GUILayout.Box($"Heure : {dayTime} h 00");
    }
}
