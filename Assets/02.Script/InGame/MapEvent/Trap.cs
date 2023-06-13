using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private SpriteRenderer _sr;
    private BoxCollider2D _boxColl;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        _boxColl = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerCtrl player = collision.gameObject.GetComponent<PlayerCtrl>();
        StartCoroutine(player.Trapped());

        _sr.enabled = false;
        _boxColl.enabled = false;
    }
}
