using UnityEngine;
//using UnityEngine.Playables;
using UnityEngine.UI;

public class MemoryFragment : MonoBehaviour
{
    [SerializeField] private int _fragNumber;
    //[SerializeField] private PlayableDirector _fragProduction;
    [SerializeField] private Sprite _memoryImg;
    [SerializeField] private GameObject _collectCountUI;
    [SerializeField] private PpippiEventMgr _ppippiEventList;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ppippiEventData data = new ppippiEventData(string.Format("{0}번 기억 조각", _fragNumber), _fragNumber, "Ppippi Dialog");

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PlayerMemory player = collision.GetComponent<PlayerMemory>();
            if (player == null)
                return;

            if (_collectCountUI.activeSelf)
            {
                _collectCountUI.SetActive(false);
            }

            _ppippiEventList.CreateNewList(data);
            player.GetMemoryFragment(_fragNumber, _memoryImg);
            _collectCountUI.SetActive(true);
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
}
