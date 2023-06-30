using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowKeyTuto : MonoBehaviour
{
    [SerializeField] private GameObject _keytutoImg;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _ppippiQuest;

    private PlayerMemory _playerMemory;

    private void Awake()
    {
        _playerMemory = _player.GetComponent<PlayerMemory>();
    }

    public void ShowKeyTutoImg()
    {
        _ppippiQuest.SetActive(true);
        _playerMemory._isEntryPlayTimeEnd = true;
        _keytutoImg.SetActive(true);
    }
}
