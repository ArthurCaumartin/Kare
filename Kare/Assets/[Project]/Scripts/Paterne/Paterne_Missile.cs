using System.Collections;
using UnityEngine;

public class Paterne_Missile : Paterne
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotateSpeed = 5;
    [SerializeField] private float _trackingDuration = 3f;

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
    }

    private IEnumerator TrackDelay(float duration)
    {
        yield return new WaitForSeconds(duration);
        _isTracking = false;
    }
}
