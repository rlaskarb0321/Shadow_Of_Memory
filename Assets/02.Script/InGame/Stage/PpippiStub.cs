using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PpippiStub : MonoBehaviour
{
    [HideInInspector]
    public bool _isPlayerTriggered;

    private BoxCollider2D _boxColl;

    private void Awake()
    {
        _boxColl = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            _isPlayerTriggered = true;
            _boxColl.enabled = false;
        }
    }
}
