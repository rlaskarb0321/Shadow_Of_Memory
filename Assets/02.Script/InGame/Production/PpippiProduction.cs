using UnityEngine;
using UnityEngine.Playables;


public class PpippiProduction : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector _ppippiProduction;
    [SerializeField]
    private GameObject _ppippiStubObj;
    [SerializeField]
    private GameObject _dummyPpippi;
    [SerializeField]
    private GameObject _realPpippi;
    [SerializeField]
    private GameObject[] _vCams;


    private PpippiStub _stub;

    private void Awake()
    {
        _stub = _ppippiStubObj.GetComponent<PpippiStub>();
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

    public void ShiftPpippi()
    {
        _dummyPpippi.gameObject.SetActive(false);
        _realPpippi.gameObject.SetActive(true);

        for (int i = 0; i < _vCams.Length; i++)
        {
            _vCams[i].gameObject.SetActive(false);
        }
    }
}
