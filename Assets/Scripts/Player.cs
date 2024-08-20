using Services.EightDirection;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private EightDirectionMono _eightDirectionService;
    [SerializeField] private Sprite[] _sprites;
    private Vector2 _direction;
    private void Start()
    {
        _eightDirectionService.SetDirection(new Vector2(1, -1));
    }
    private void Update()
    {
        _direction = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        if (_direction.x != 0) _eightDirectionService.SetDirection(new Vector2(_direction.x < 0 ? -1 : 1, -1));
    }
    private void FixedUpdate()
    {
        transform.position += new Vector3(_direction.x, 0, _direction.y) * Time.deltaTime*4;
    }
}
