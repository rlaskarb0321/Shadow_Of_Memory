using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEffect : MonoBehaviour
{
    protected void SetEffectOff()
    {
        gameObject.SetActive(false);
    }
}
