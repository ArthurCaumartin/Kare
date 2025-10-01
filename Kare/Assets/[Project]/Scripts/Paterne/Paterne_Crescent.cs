using UnityEngine;

public class Paterne_Crescent : Paterne
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotateSpeed = 5f;
    [SerializeField] private float _centerOffsetRadius = 2f;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private Vector2 _direction;

    public override void Init(Camera camera, GameObject player)
    {
        base.Init(camera, player);
        transform.position = GetPosOutCamera();

        Vector2 centreOffset = Random.insideUnitCircle * _centerOffsetRadius;
        _direction = centreOffset - (Vector2)transform.position;
        transform.up = _direction.normalized;
    }

    protected override void Start()
    {
        base.Start();
        Destroy(gameObject, 15f);
    }

    protected override void Update()
    {
        base.Update();
        transform.Translate(Vector2.up * _moveSpeed * Time.deltaTime);
        _spriteRenderer.transform.Rotate(Vector3.forward, _rotateSpeed * Time.deltaTime);

        Damagable damagable = TryGetDamagable();
        if (damagable != null)
        {
            damagable.TakeDamage(damage, transform);
            Destroy(gameObject);
        }
    }
}