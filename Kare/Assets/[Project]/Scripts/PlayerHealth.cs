using System;
using UnityEngine;

public class PlayerHealth : Damagable
{
    [SerializeField] private ParticleSystem damageEffect;

    public override void TakeDamage(int damage, Transform sourceTransform = null)
    {
        base.TakeDamage(damage);

        if (damageEffect != null && sourceTransform)
        {
            ParticleSystem effect = Instantiate(damageEffect, transform.position, Quaternion.identity);
            effect.transform.up = sourceTransform.up;
            Destroy(effect.gameObject, effect.main.duration);
        }
    }

    public override void Kill()
    {
        GameManager.Instance.EndGame();
    }
}