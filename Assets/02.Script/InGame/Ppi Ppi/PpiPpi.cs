using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PpiPpi : MonoBehaviour
{
    [SerializeField]
    private GameObject _ppippiOriginPos;

    //[HideInInspector]
    public bool _isHoldPos;

    public void TogglePpiPpiPos(bool isHoldPos)
    {
        if (isHoldPos)
        {
            transform.parent = null;
            _isHoldPos = true;
        }
        else
        {
            transform.parent = _ppippiOriginPos.transform;
            transform.localPosition = Vector3.zero;
            transform.localScale = Vector3.one;
            _isHoldPos = false;
        }
    }
}
