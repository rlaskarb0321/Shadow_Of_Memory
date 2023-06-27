using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowKeyTuto : MonoBehaviour
{
    [SerializeField] private GameObject _keytutoImg;
    [SerializeField] private GameObject _player;

    private PlayerMemory _playerMemory;

    private void Awake()
    {
        _playerMemory = _player.GetComponent<PlayerMemory>();
    }

    public void ShowKeyTutoImg()
    {
        print("Key Tuto Img 띄우고 입장영상 봤음 체크");
        _playerMemory._isEntryPlayTimeEnd = true;
        //_keytutoImg.SetActive(true);
    }
}
