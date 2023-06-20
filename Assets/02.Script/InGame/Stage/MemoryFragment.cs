using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MemoryFragment : MonoBehaviour
{
    //[SerializeField]
    //private int _fragNumber;
    [SerializeField]
    private PlayableDirector _fragProduction;

    private void Update()
    {
        // 가만히있을때
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.GetComponent<PlayerCtrl>().GetMemoryFragment();
            // Destroy(gameObject);
            ProductionMgr.StartProduction(_fragProduction);
        }
    }
}
