using UnityEngine;
//using UnityEngine.Playables;
using UnityEngine.UI;

public class MemoryFragment : MonoBehaviour
{
    [SerializeField] private int _fragNumber;
    //[SerializeField] private PlayableDirector _fragProduction;
    [SerializeField] private Sprite _memoryImg;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.GetComponent<PlayerMemory>().GetMemoryFragment(_fragNumber, _memoryImg);
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
}
