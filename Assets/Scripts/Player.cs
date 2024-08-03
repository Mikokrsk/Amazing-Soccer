using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    public VariableJoystick variableJoystick;

    public void FixedUpdate()
    {
        // Vector3 direction = Vector3.up * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        //_rb.AddForce(direction * _speed * Time.fixedDeltaTime, ForceMode2D.Force);
        // _rb.transform.Translate(transform.position + direction);
        _rb.transform.position = new Vector2(_rb.transform.position.x + _speed * variableJoystick.Horizontal * Time.deltaTime
            , _rb.transform.position.y + _speed * variableJoystick.Vertical * Time.deltaTime);
    }
}