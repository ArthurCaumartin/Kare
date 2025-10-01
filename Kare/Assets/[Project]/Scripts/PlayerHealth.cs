using System;
using UnityEngine;

public class PlayerHealth : Damagable
{
    [SerializeField] private ParticleSystem damageEffect;

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (damageEffect != null)
        {
            ParticleSystem effect = Instantiate(damageEffect, transform.position, Quaternion.identity);
            Destroy(effect.gameObject, effect.main.duration);
        }
    }

    public override void Kill()
    {
        GameManager.Instance.EndGame();
    }
}