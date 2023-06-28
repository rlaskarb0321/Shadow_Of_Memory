using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObj : MonoBehaviour
{
    [SerializeField] private GameObject _followObj;
    [SerializeField] private float _speed;


    private void Update()
    {
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
        transform.position = Vector2.Lerp(myPos, _followObj.transform.position, _speed);
    }
}
