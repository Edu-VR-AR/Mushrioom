using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Animator _animator;
    private Rigidbody2D _player;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(1 * _speed * Time.deltaTime, 0, 0);
            _animator.SetFloat("Speed", 1.0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(1 * _speed * Time.deltaTime, 0, 0);
            _animator.SetFloat("Speed", 1.0f);
        }
        else
        {
            _animator.SetFloat("Speed", 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up);

            if (hit.collider && hit.distance < 0.45f)
            {
                _player.AddForce(Vector2.up * _jumpForce);
                _animator.SetTrigger("Attack");
            }
        }
    }
}
