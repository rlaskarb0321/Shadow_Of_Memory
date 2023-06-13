using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    public bool _isGrounded;

    private Rigidbody2D _rbody2D;

    private void Awake()
    {
        _rbody2D = GetComponentInParent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_rbody2D.velocity.y >= 0.0f)
        {
            return;
        }
        _isGrounded = true;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        _isGrounded = false;
    }
}
