using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PpippiTalkLevelUP : MonoBehaviour
{
    public GameObject _playerObj;
    public GameObject _ppippiObj;
    public int _myLevel;

    private BoxCollider2D _boxColl;
    private PlayerCtrl _player;
    private Dialogueballoon _ppippi;

    private void Awake()
    {
        _player = _playerObj.GetComponent<PlayerCtrl>();
        _ppippi = _ppippiObj.GetComponent<Dialogueballoon>();
        _boxColl = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            print("player");
            _boxColl.enabled = false;
            _ppippi._levelCount = _myLevel;
        }
    }
}
