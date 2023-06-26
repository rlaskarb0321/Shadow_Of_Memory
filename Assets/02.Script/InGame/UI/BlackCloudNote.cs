using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCloudNote : MonoBehaviour
{
    private Animator _animator;
    private readonly int _hashIsInput = Animator.StringToHash("isInput");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("space Input");
            _animator.SetTrigger(_hashIsInput);
        }
    }

    public void SetOffSelf()
    {
        gameObject.SetActive(false);
    }
}
