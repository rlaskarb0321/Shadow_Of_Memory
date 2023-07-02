using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyCube : MapEvent
{
    [SerializeField]
    private GameObject[] _hiddenGrounds;

    [SerializeField]
    private GameObject _effect;

    [SerializeField]
    private MapEventState _cubeState;

    [SerializeField]
    private float _deltaValue;

    [SerializeField]
    [Range(0.1f, 0.25f)]
    private float _silhouetteValue;

    private bool _isRun;
    private SpriteRenderer[] _hiddenGroundSR;
    private BoxCollider2D[] _hiddenGroundBoxColl;

    private void Awake()
    {
        _hiddenGroundSR = new SpriteRenderer[_hiddenGrounds.Length];
        _hiddenGroundBoxColl = new BoxCollider2D[_hiddenGrounds.Length];
    }

    private void Start()
    {
        switch (_cubeState)
        {
            case MapEventState.Open:
                // ¿Ã∆Â∆Æ
                break;

            case MapEventState.Close:
                // ¿Ã∆Â∆Æ
                break;
        }

        for (int i = 0; i < _hiddenGrounds.Length; i++)
        {
            Color color = Color.white;

            _hiddenGroundSR[i] = _hiddenGrounds[i].GetComponent<SpriteRenderer>();
            _hiddenGroundBoxColl[i] = _hiddenGrounds[i].GetComponent<BoxCollider2D>();

            switch (_cubeState)
            {
                case MapEventState.Open:
                    color.a = Color.white.a;
                    _hiddenGroundSR[i].color = color;
                    _hiddenGroundBoxColl[i].enabled = true;
                    break;

                case MapEventState.Close:
                    color.a = _silhouetteValue;
                    _hiddenGroundSR[i].color = color;
                    _hiddenGroundBoxColl[i].enabled = false;
                    break;
            }
        }
    }

    public override void Interaction(PlayerCtrl player)
    {
        if (_isRun)
        {
            return;
        }

        _isRun = true;
        for (int i = 0; i < _hiddenGroundSR.Length; i++)
        {
            StartCoroutine(CtrlHiddenGroundBrighten(_hiddenGroundSR[i], _hiddenGroundBoxColl[i]));
        }
    }

    private IEnumerator CtrlHiddenGroundBrighten(SpriteRenderer sr, BoxCollider2D boxColl)
    {
        Color color = sr.color;
        float time;
        switch (_cubeState)
        {
            case MapEventState.Open:
                time = 1.0f;
                while (time >= _silhouetteValue)
                {
                    color.a = time;
                    sr.color = color;
                    time -= Time.deltaTime * _deltaValue;
                    yield return null;
                }

                boxColl.enabled = false;
                _cubeState = MapEventState.Close;
                _isRun = false;
                break;

            case MapEventState.Close:
                time = sr.color.a;
                while (time <= 1.0f)
                {
                    color.a = time;
                    sr.color = color;
                    time += Time.deltaTime * _deltaValue;
                    yield return null;
                }

                boxColl.enabled = true;
                _cubeState = MapEventState.Open;
                _isRun = false;
                break;
        }
    }
}
