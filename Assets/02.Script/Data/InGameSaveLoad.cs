using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSaveLoad : MonoBehaviour
{
    // SeriralizeField
    [Header("=== Extract List ===")]
    [SerializeField] private GameObject _player;

    [Header("=== Game Data ===")]
    public GameData _data;

    // HideInInspector
    private PlayerMemory _playerMemory;

    private void Awake()
    {
        _data = GameDataPackage._gameData;

        _playerMemory = _player.GetComponent<PlayerMemory>();

        // ���⼭ �־��� �����ͷ� �ش� ���� �����͸� �ʱ�ȭ�ؾ���
    }

    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            GameData saveData = 
                new GameData(_playerMemory.transform.position, _playerMemory._isFragIdxGet, _playerMemory._collectMemoryCount);
            SaveData character = new SaveData(saveData);
            _data = saveData;

            SaveSystem.Save(character, "Save" + GameDataPackage._index.ToString());
        }

        //if (Input.GetKeyDown("l"))
        //{
        //    SaveData loadData = SaveSystem.Load("Save1");
        //    print("Load Success");
        //}

    }
}
