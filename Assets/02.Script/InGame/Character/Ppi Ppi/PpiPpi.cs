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

    [SerializeField]
    private Transform _playerObj;

    [SerializeField]
    private Transform _ppippiPos;

    [SerializeField]
    private float _speed;

    private float _characterScaleX;

    private void Update()
    {
        _characterScaleX = -_playerObj.localScale.x;
    }

    private void FixedUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector2 ppippiRotate;
        switch (_characterScaleX)
        {
            case -1:
                ppippiRotate = new Vector2(_characterScaleX, transform.localScale.y);
                transform.localScale = ppippiRotate;
                break;

            case 1:
                ppippiRotate = new Vector2(_characterScaleX, transform.localScale.y);
                transform.localScale = ppippiRotate;
                break;
        }
        Vector2 ppippiPos = new Vector2(_ppippiPos.position.x, _ppippiPos.position.y);
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y);

        transform.position = Vector2.Lerp(myPos, ppippiPos, _speed);
    }
}
