using System.Collections;   
using System.Collections.Generic;
using UnityEngine;

public class Lever : MapEvent
{
    [SerializeField] private MapEventState _mapEventState;
    [SerializeField] private GameObject _door;

    private float _expandScaleY;
    private float _currScaleY;
    private float _shirinkScaleY;
    private bool _isInteractive;

    private void Start()
    {
        _expandScaleY = _door.transform.localScale.y;
        _currScaleY = _door.transform.localScale.y;
        _shirinkScaleY = 0.1f;
        _mapEventState = MapEventState.Close;
    }

    private void Update()
    {
        if (_isInteractive)
        {
            switch (_mapEventState)
            {
                case MapEventState.Open:
                    if (_currScaleY < _expandScaleY)
                    {
                        _currScaleY += Time.deltaTime * 3.0f;
                        _door.transform.localScale = new Vector3(transform.localScale.x, _currScaleY, transform.localScale.z);
                    }
                    else
                    {
                        _currScaleY = _expandScaleY;
                        _door.transform.localScale = new Vector3(transform.localScale.x, _currScaleY, transform.localScale.z);

                        _mapEventState = MapEventState.Close;
                        _isInteractive = false;
                    }
                    break;

                case MapEventState.Close:
                    if (_currScaleY >= _shirinkScaleY)
                    {
                        _currScaleY -= Time.deltaTime * 3.0f;
                        _door.transform.localScale = new Vector3(transform.localScale.x, _currScaleY, transform.localScale.z);
                    }
                    else
                    {
                        _currScaleY = _shirinkScaleY;
                        _door.transform.localScale = new Vector3(transform.localScale.x, _currScaleY, transform.localScale.z);

                        _mapEventState = MapEventState.Open;
                        _isInteractive = false;
                    }
                    break;
                default:
                    break;
            }
        }
    }

    public override void Interaction(PlayerCtrl player)
    {
        if (!_isInteractive)
        {
            _isInteractive = true;
        }
        //switch (_mapEventState)
        //{
        //    case MapEventState.Open:
        //        _mapEventState = MapEventState.Close;
        //        Close();
        //        break;

        //    case MapEventState.Close:
        //        _mapEventState = MapEventState.Open;
        //        Open();
        //        break;
        //}
    }

    protected override void Open()
    {

    }

    protected override void Close()
    {
         
    }
}
