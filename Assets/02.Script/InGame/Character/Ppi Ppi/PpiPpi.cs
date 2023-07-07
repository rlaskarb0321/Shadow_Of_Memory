using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PpiPpi : MonoBehaviour
{
    #region 삐삐 고정시키기
    //[SerializeField]
    //private GameObject _ppippiOriginPos;

    ////[HideInInspector]
    //public bool _isHoldPos;

    //public void TogglePpiPpiPos(bool isHoldPos)
    //{
    //    if (isHoldPos)
    //    {
    //        transform.parent = null;
    //        _isHoldPos = true;
    //    }
    //    else
    //    {
    //        transform.parent = _ppippiOriginPos.transform;
    //        transform.localPosition = Vector3.zero;
    //        transform.localScale = Vector3.one;
    //        _isHoldPos = false;
    //    }
    //}
    #endregion 삐삐 고정시키기

    [Header("=== Ppippi Event List ===")]
    [SerializeField] PpippiEventList _ppippiEventList;

    // SerializeField
    [Header("=== Ppippi Follow ===")]
    [SerializeField] private Transform _playerObj;
    [SerializeField] private GameObject _ppippiBody;
    [SerializeField] private GameObject _followObj;
    [SerializeField] private float _speed;

    // HideInInspector
    private float _changeScaleX;

    private void Update()
    {
        FollowObj();
        ReverseScaleX();
    }

    private void FollowObj()
    {
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
        transform.position = Vector2.Lerp(myPos, _followObj.transform.position, _speed);
    }

    private void ReverseScaleX()
    {
        _changeScaleX = -_playerObj.localScale.x;
        Vector2 ppippiRotate = new Vector2(_changeScaleX, transform.localScale.y);

        _ppippiBody.transform.localScale = ppippiRotate;
    }

    // 플레이어가 새 이벤트를 발견했을때 호출되는 함수
    // 삐삐의 머리위에 느낌표가 뜨고, 삐삐 이벤트 ui에게 값을 전달한다
    public void DiscoverNewEvent(PpippiEvent ppippiEvent)
    {
        _ppippiEventList.CreateNewList(ppippiEvent);
    }
}
