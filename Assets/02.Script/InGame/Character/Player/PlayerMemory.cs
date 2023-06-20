using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMemory : MonoBehaviour
{
    // SerializeField
    [SerializeField]
    private bool[] _isFragIdxGet;

    [SerializeField]
    private int _recentFragIdx; // 플레이어가 최근에 획득한 기억조각의 번호, 삐삐와의 스토리대화를 요청하면 최근 획득한 기억조각 번호번째 대화가 출력됨
    public int _playerCollectMemoryCount;

    [Header("=== Memory Board ===")] [SerializeField]
    private GameObject[] _memoryPuzzles;

    [SerializeField]
    private Text _acheivementRateText;

    [SerializeField]
    private Text _descriptionText;

    [SerializeField]
    private string[] _descriptionContent;

    // HideInInspector


    private void Start()
    {
        _acheivementRateText.text = "0 %";
        _descriptionText.text = "";
    }

    public void GetMemoryFragment(int index)
    {
        // 사운드 연출

        // 습득 후 Player쪽 처리
        _playerCollectMemoryCount++;
        _recentFragIdx = index;
        _isFragIdxGet[_recentFragIdx - 1] = true;

        // 습득 후 MemoryBoard쪽 처리
        _memoryPuzzles[_recentFragIdx - 1].gameObject.SetActive(true);
        _acheivementRateText.text = $"{(Mathf.Round((_playerCollectMemoryCount / 6.0f) * 100)) * 0.01f * 100} %";
    }

    // 메모리 보드에있는 퍼즐을 클릭할 때 
    public void OnClickMemoryPuzzle(int index)
    {
        _descriptionText.text = _descriptionContent[index - 1];
    }

    public void OnClickStoryDialog()
    {
        if (_playerCollectMemoryCount == 0)
        {
            print("현재 수집한 기억이 없습니다");
            return;
        }

        print(_recentFragIdx + "번 째 스토리 대화가 출력");
    }
}
