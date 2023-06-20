using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Playables;

public class MemoryFragment : MonoBehaviour
{
    [SerializeField]
    private int _fragNumber;
    //[SerializeField]
    //private PlayableDirector _fragProduction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.GetComponent<PlayerMemory>().GetMemoryFragment(_fragNumber);
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
}
