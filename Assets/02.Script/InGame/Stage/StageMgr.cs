using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StageMgr : MonoBehaviour
{
    public GameObject _playerObj;

    [SerializeField]
    private int _maxFragCount;

    [HideInInspector]
    private PlayerCtrl _player;
    private AudioSource _audio;

    private void Awake()
    {
        _player = _playerObj.GetComponent<PlayerCtrl>();
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {

    }
}
