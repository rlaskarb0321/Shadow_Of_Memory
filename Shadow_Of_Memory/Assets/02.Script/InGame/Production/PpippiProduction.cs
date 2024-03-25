using UnityEngine;
using UnityEngine.Playables;


public class PpippiProduction : MonoBehaviour
{
    [SerializeField] private PlayableDirector _ppippiProduction;
    [SerializeField] private GameObject _ppippiStubObj;
    [SerializeField] private GameObject _dummyPpippi;
    [SerializeField] private GameObject _realPpippi;
    [SerializeField] private GameObject[] _vCams;
    [SerializeField] private GameObject _player;

    private PpippiStub _stub;
    private PlayerMemory _playerMemory;

    private void Awake()
    {
        _stub = _ppippiStubObj.GetComponent<PpippiStub>();
        _playerMemory = _player.GetComponent<PlayerMemory>();
    }

    private void Update()
    {
        if (_stub._isPlayerTriggered && !ProductionMgr._isPlayProduction)
        {
            ProductionMgr.StartProduction(_ppippiProduction);
            _stub._isPlayerTriggered = false;
            return;
        }
    }

    // »ß»ß¿ÍÀÇ ¸¸³² ÄÆ½ÅÀÇ ³¡ ºÎºÐ¿¡ ÀÌº¥Æ® ¸®½Ã¹ö·Î È£Ãâ, ´õ¹Ì»ß»ß¿Í ÁøÂ¥»ß»ß¸¦ ¹Ù²ãÁÜ
    public void ShiftPpippi()
    {
        print("»ß»ß ¹Ù²Ù±â");
        _playerMemory._isMeetPpippi = true;
        _dummyPpippi.gameObject.SetActive(false);
        _realPpippi.gameObject.SetActive(true);

        for (int i = 0; i < _vCams.Length; i++)
        {
            _vCams[i].gameObject.SetActive(false);
        }
    }
}
