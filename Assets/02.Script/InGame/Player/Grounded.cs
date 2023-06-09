using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    public bool _isGrounded;

    private void OnTriggerStay2D(Collider2D collision)
    {
        _isGrounded = true;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        _isGrounded = false;
    }
}
