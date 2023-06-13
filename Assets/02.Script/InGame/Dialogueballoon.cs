using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct ppippiDialogue
{
    public Image[] dialogue;
}

public class Dialogueballoon : MonoBehaviour
{
    public ppippiDialogue[] _dialouges;

    [SerializeField]
    private GameObject _ballon;
    public int _levelCount;
    [SerializeField]
    private Vector3 _pos;

    private void Update()
    {
        _ballon.transform.position = Camera.main.WorldToScreenPoint(transform.position + _pos);
    }
}
