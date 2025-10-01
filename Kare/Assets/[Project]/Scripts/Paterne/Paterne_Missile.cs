using System.Collections;
using UnityEngine;

public class Paterne_Missile : Paterne
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotateSpeed = 5;
    [SerializeField] private float _trackingDuration = 3f;
    [Space]
    [SerializeField] private float _damageRaduis = 0.5f;
    [SerializeField] private Vector2 _damageOffset;

    private Vector2 _direction;
    private bool _isTracking = true;

    public override void Init(Camera camera, GameObject player)
    {
        base.Init(camera, player);
        transform.position = GetPosOutCamera();
        _isTracking = true;
    }

    protected override void Start()
    {
        base.Start();
        StartCoroutine(TrackDelay(_trackingDuration));
    }

    protected override void Update()
    {
        base.Update();
        _direction = (player.position - transform.position).normalized;
        if (_isTracking)
            transform.up = Vector2.Lerp(transform.up, _direction, Time.deltaTime * _rotateSpeed);

        transform.Translate(Vector2.up * _moveSpeed * Time.deltaTime);

        Damagable damagable = TryGetDamagable();
        if (damagable != null)
        {
            damagable.TakeDamage(damage, transform);
            Destroy(gameObject);
        }
    }

    private IEnumerator TrackDelay(float duration)
    {
        yield return new WaitForSeconds(duration);
        _isTracking = false;
    }

    private Damagable TryGetDamagable()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll((Vector2)transform.position + _damageOffset, 0.5f);
        foreach (var hit in hits)
        {
            Damagable damagable = hit.GetComponent<Damagable>();
            if (damagable)
                return damagable;
        }
        return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector2)transform.position + _damageOffset, _damageRaduis);
    }
}
