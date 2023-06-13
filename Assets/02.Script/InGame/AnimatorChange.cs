using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorChange : MonoBehaviour
{
    public RuntimeAnimatorController[] anims;

    public GameObject _player;
    public Animator _currAnimator;

    private void Awake()
    {
        _currAnimator = _player.GetComponent<Animator>();
    }

    public void ChangeAnimator(int index)
    {
        _currAnimator.runtimeAnimatorController = anims[index];
    }
}
