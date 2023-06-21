using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MapEvent
{
    [SerializeField] private GameObject _otherPortal;
    [SerializeField] private float _portalCoolTime;
    [SerializeField] private int _portalNumber;

    [Range(1.0f, 2.5f)] private float _currCoolTime;

    private void Start()
    {
        _currCoolTime = _portalCoolTime;
    }

    public override void Interaction(PlayerCtrl player)
    {
        if (_currCoolTime < _portalCoolTime)
        {
            return;
        }

        Vector3 playerTr = player.GetComponent<Transform>().position;
        Vector3 targetPos = _otherPortal.transform.position;

        player.transform.position = targetPos;

        StartCoroutine(CoolDownPortal());
        StartCoroutine(_otherPortal.GetComponent<Portal>().CoolDownPortal());
    }

    private IEnumerator CoolDownPortal()
    {
        _currCoolTime = 0.0f;
        while (_currCoolTime < _portalCoolTime)
        {
            _currCoolTime += Time.deltaTime;
            if (_currCoolTime >= _portalCoolTime)
            {
                _currCoolTime = _portalCoolTime;
            }
            yield return null;
        }
    }
}
