using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public class IAP_Stats
{
    public event Action<float> OnLifeNormalized = null;
    public event Action OnDie = null;

    [SerializeField] Image lifeUI = null;
    [SerializeField, Range(0, 100)] float healSpeed = 2;

    [SerializeField, Range(0, 100)] float life = 100;
    [SerializeField, Range(1, 100)] int damage = 10;
    public int Damage => damage;
    public float Life
    {
        get { return life; }
        set
        {
            life = value;
            life = life > 100 ? 100 : life;
            OnLifeNormalized?.Invoke((life / 100f));
            if (life <= 0)
            {
                life = 0;
                OnDie?.Invoke();
            }
        }
    }
    public bool IsValid => lifeUI;
    public bool NeedHeal =>  life < 100;
    public bool IsDead => life <= 0;
    public ParticleSystem ParticleHeal { get; set; }
    [SerializeField] ParticleSystem damageFx;
    public ParticleSystem ParticleDamage => damageFx;

    public IAP_Stats()
    {
        OnLifeNormalized += SetLifeDataUI;
        OnLifeNormalized?.Invoke(1);
    }
    public void Init() => OnLifeNormalized?.Invoke(Life/100);
    public void FillLife()
    {
        Life += Time.deltaTime* healSpeed;
    }
    public void SetDamage(int _dmg)
    {
        Life -= _dmg;
    }
    public void ShowDamageFx(Vector3 _position)
    {
        if (!damageFx) return;
            GameObject.Instantiate(damageFx, _position,Quaternion.identity);
    }
    void SetLifeDataUI(float _life)
    {
        if (!IsValid) return;
        lifeUI.fillAmount = _life;
        lifeUI.color = Color.Lerp(Color.red, Color.green, _life);
    }
}
