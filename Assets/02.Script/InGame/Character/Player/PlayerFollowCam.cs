using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowCam : MonoBehaviour
{
    public Transform _playerBody;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _playerBody.position, 1.0f);
        transform.Translate(0, 0, -10);
    }
}
