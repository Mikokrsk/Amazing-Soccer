using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    [SerializeField] private float _hitForse;
    [SerializeField] private BoxCollider2D _range;
    public GameObject ball;
    public GameObject ballPosition;
    public VariableJoystick variableJoystick;

    private void OnEnable()
    {
        VariableJoystick.hitTheBall += HitTheBall;
    }
    private void OnDisable()
    {
        VariableJoystick.hitTheBall -= HitTheBall;
    }

    private void Start()
    {
        if (_range == null)
        {
            _range = GetComponentInParent<BoxCollider2D>();
        }
        if (_rb == null)
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        if (variableJoystick == null)
        {
            variableJoystick = VariableJoystick.Instance;
        }
    }

    public void HitTheBall()
    {
        if (ball != null)
        {
            var balls = ball;
            ball = null;
            balls.GetComponent<Rigidbody2D>().AddForce(transform.right * _hitForse, ForceMode2D.Impulse);
        }
    }

    public void Update()
    {
        if (GameManager.Instance.GetCurrentGameMode() == GameMode.Game)
        {
            Move();
            Bounds();
        }
    }

    private void Move()
    {
        float horizontal = variableJoystick.Horizontal;
        float vertical = variableJoystick.Vertical;

        Vector3 movement = new Vector3(horizontal, vertical).normalized;
        _rb.transform.position += movement * _speed * Time.deltaTime;

        if (movement != Vector3.zero)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            _rb.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        if (ball != null)
        {
            ball.transform.position = ballPosition.transform.position;
        }
    }

    private void Bounds()
    {
        if (transform.position.x > _range.bounds.max.x)
        {
            transform.position = new Vector2(_range.bounds.max.x, transform.position.y);
        }
        if (transform.position.x < _range.bounds.min.x)
        {
            transform.position = new Vector2(_range.bounds.min.x, transform.position.y);
        }
        if (transform.position.y > _range.bounds.max.y)
        {
            transform.position = new Vector2(transform.position.x, _range.bounds.max.y);
        }
        if (transform.position.y < _range.bounds.min.y)
        {
            transform.position = new Vector2(transform.position.x, _range.bounds.min.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ball == null && collision.CompareTag("Ball"))
        {
            ball = collision.gameObject;
        }
    }
}