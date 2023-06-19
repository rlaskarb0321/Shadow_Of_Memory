using UnityEngine;
using UnityEngine.Playables;


public class PpippiProduction : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector _ppippiProduction;
    [SerializeField]
    private GameObject _ppippiStubObj;

    private PpippiStub _stub;
    private bool _isRun;

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
}
