using UnityEngine;
//using UnityEngine.Playables;
using UnityEngine.UI;

public class MemoryFragment : MonoBehaviour
{
    [SerializeField] private int _fragNumber;
    //[SerializeField] private PlayableDirector _fragProduction;
    [SerializeField] private Sprite _memoryImg;
    [SerializeField] private GameObject _collectCountUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PlayerMemory player = collision.GetComponent<PlayerMemory>();
            if (player == null)
                return;

            player.GetMemoryFragment(_fragNumber, _memoryImg);
            _collectCountUI.GetComponent<Animator>().enabled = true;
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
}
