using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackPanel : MonoBehaviour
{
    public GameObject _stageMgrObj;

    private StageMgr _stageMgr;
    private float _y;

    private void Awake()
    {
        _stageMgr = _stageMgrObj.GetComponent<StageMgr>();
    }

    private void Start()
    {
        _stageMgr._audio.mute = true;
        StartCoroutine(OnGameOver());
    }

    private IEnumerator OnGameOver()
    {
        while (transform.position.y <= 638.0f)
        {
            _y += Time.deltaTime * 0.5f;
            transform.position = new Vector3(transform.position.x, transform.position.y + _y, transform.position.z);
            yield return null;
        }

        yield return new WaitForSeconds(1.5f);
    }
}
