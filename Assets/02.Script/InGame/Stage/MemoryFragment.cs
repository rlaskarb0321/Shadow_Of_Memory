using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryFragment : MonoBehaviour
{
    [SerializeField] private GameObject _endPortalObj;

    private EndPortal _endPortal;

    private void Awake()
    {
        _endPortal = _endPortalObj.GetComponent<EndPortal>();
    }

    private void Start()
    {
        _endPortal._fragMaxCount++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            print("´ê");
            collision.GetComponent<PlayerCtrl>().GetMemoryFragment();
            Destroy(gameObject);
        }
    }
}
