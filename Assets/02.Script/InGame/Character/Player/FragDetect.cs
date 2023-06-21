using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FragDetect : MonoBehaviour
{
    [SerializeField]
    private GameObject _collectFragUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Memory Fragment"))
            return;

        print("기억조각 접근");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Memory Fragment"))
            return;

        print("기억조각 멀어짐");
    }
}
