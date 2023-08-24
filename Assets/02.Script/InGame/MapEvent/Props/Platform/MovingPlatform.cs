using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float _movSpeed;
    [SerializeField] private GameObject[] _route;
    [SerializeField] private Transform _ground;
    [SerializeField] private Transform _character;

    private int _idx = 0;

    private void Update()
    {
        GoToRoute();
    }

    private void GoToRoute()
    {
        if (_ground.position.Equals(_route[_idx].transform.position))
        {
            print("correct");
            _idx++;
            _idx %= _route.Length;
        }

        _ground.position = Vector2.MoveTowards(_ground.position, _route[_idx].transform.position, _movSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.layer.Equals(LayerMask.NameToLayer("Player")))
        {
            return;
        }

        collision.transform.SetParent(_ground);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.layer.Equals(LayerMask.NameToLayer("Player")))
        {
            return;
        }

        collision.transform.SetParent(_character);
        collision.transform.SetAsFirstSibling();
    }
}