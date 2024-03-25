using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowCam : MonoBehaviour
{
    public Transform _playerBody;
    public Vector3 _camPlusPos;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _playerBody.position + _camPlusPos, 1.0f);
        transform.Translate(0, 0, -10);
    }
}
