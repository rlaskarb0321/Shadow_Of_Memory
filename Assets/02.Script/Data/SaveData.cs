using UnityEngine;

[System.Serializable]
public class SaveData
{
    public Vector3 _playerPos;

    public SaveData(Vector3 playerPos)
    {
        _playerPos = playerPos;
    }
}
