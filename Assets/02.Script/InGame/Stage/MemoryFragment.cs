using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryFragment : MonoBehaviour
{
    //[SerializeField] private GameObject _endPortalObj;

    // private EndPortal _endPortal;
    //private float _maxYPos;
    //private float _minYPos;
    //private float _movePos;

    private void Awake()
    {
        //_endPortal = _endPortalObj.GetComponent<EndPortal>();
    }

    private void Start()
    {
        //_endPortal._fragMaxCount++;

        //_maxYPos = transform.position.y + _range;
        //_minYPos = transform.position.y - _range;
    }

    //private void Update()
    //{
    //    transform.position = new Vector2(transform.position.x, _movePos);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.GetComponent<PlayerCtrl>().GetMemoryFragment();
            Destroy(gameObject);
        }
    }
}
