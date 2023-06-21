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

        print("������� ����");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Memory Fragment"))
            return;

        print("������� �־���");
    }
}
