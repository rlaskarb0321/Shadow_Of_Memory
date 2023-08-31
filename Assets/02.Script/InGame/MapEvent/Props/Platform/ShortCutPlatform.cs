using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortCutPlatform : MonoBehaviour
{
    [SerializeField] GameObject _shortCuts;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player"))
            return;

        _shortCuts.SetActive(true);
    }
}
