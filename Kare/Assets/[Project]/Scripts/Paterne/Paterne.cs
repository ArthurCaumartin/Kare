using UnityEngine;

public class Paterne : MonoBehaviour
{
    [SerializeField] protected int damage = 10;
    protected Camera _camera;
    protected Transform player;

    public virtual void Init(Camera camera, GameObject player)
    {
        this._camera = camera;
        this.player = player.transform;
    }

    protected virtual void Start()
    {
        Destroy(gameObject, 10f);
    }

    protected virtual void Update()
    {

    }

    protected void PaterneHit()
    {

    }

    protected Vector2 GetPosInCamera()
    {
        float screenX = Random.Range(0, Screen.width);
        float screenY = Random.Range(0, Screen.height);
        Vector3 screenPosition = new Vector3(screenX, screenY, _camera.nearClipPlane);
        Vector3 worldPosition = _camera.ScreenToWorldPoint(screenPosition);
        return new Vector2(worldPosition.x, worldPosition.y);
    }
    protected Vector2 GetPosOutCamera()
    {
        float screenX = Random.Range(0, Screen.width);
        float screenY = Random.Range(0, Screen.height);
        int side = Random.Range(0, 4);
        switch (side)
        {
            case 0: // Top
                screenY = Screen.height + 100;
                break;
            case 1: // Bottom
                screenY = -100;
                break;
            case 2: // Left
                screenX = -100;
                break;
            case 3: // Right
                screenX = Screen.width + 100;
                break;
        }
        Vector3 screenPosition = new Vector3(screenX, screenY, _camera.nearClipPlane);
        Vector3 worldPosition = _camera.ScreenToWorldPoint(screenPosition);
        return new Vector2(worldPosition.x, worldPosition.y);
    }
}


public class Paterne_Crescent : Paterne
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotateSpeed = 5f;
    [SerializeField] private float _centerOffsetRadius = 2f;
    private Vector2 _target;

    public override void Init(Camera camera, GameObject player)
    {
        base.Init(camera, player);
        transform.position = GetPosOutCamera();

        Vector2 centreOffset = Random.insideUnitCircle * _centerOffsetRadius;
        
    }

    protected override void Start()
    {
        base.Start();
        Destroy(gameObject, 15f);
    }


}