using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryEnd : MonoBehaviour
{
    [SerializeField] private PlayerMemory _player;
    [SerializeField] private InGameSaveLoad _saveLoad;

    public void EndEntry()
    {
        _player._isEntryPlayTimeEnd = true;
        if (!_saveLoad._isDeveloper)
        {
            _saveLoad.SaveToServer(_player); 
        }
    }
}
