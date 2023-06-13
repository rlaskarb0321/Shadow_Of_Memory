using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PpippiTalk : MonoBehaviour
{
    public GameObject _playerObj;
    public GameObject _ppippiObj;
    public int _myLevel;

    private PlayerCtrl _player;
    private PpiPpi _ppippi;

    private void Awake()
    {
        _player = _playerObj.GetComponent<PlayerCtrl>();
        _ppippi = _ppippiObj.GetComponent<PpiPpi>();
    }


}
