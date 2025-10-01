using UnityEngine;

public class Damagable : MonoBehaviour
{
    [SerializeField] private int health = 100;
    public int Health => health;
    private int _maxHealth = 100;

    public virtual void TakeDamage(int damage, Transform sourceTransform = null)
    {
        health -= damage;
        if (health <= 0)
        {
            Kill();
        }
    }

    public virtual void Kill()
    {
        Destroy(gameObject);
    }
}
