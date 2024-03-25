using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVFXPool : MonoBehaviour
{
    public GameVFX[] _vfxPool;

    public void DisplayVFX(Vector3 pos)
    {
        for (int i = 0; i < _vfxPool.Length; i++)
        {
            if (!_vfxPool[i].gameObject.activeSelf)
            {
                _vfxPool[i].transform.position = pos;
                _vfxPool[i].gameObject.SetActive(true);
                break;
            }
        }
    }
}
