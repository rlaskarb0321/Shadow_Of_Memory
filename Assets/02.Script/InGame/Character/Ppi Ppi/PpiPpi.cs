using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PpiPpi : MonoBehaviour
{
    #region ªﬂªﬂ ∞Ì¡§Ω√≈∞±‚
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
    #endregion ªﬂªﬂ ∞Ì¡§Ω√≈∞±‚

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
}
