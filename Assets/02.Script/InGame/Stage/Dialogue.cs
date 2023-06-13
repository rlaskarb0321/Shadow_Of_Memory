using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [Header("Events")]
    public int _collectFragCount; // 처음획득시, 이 후 일정파편개수만큼 획득시
    public bool _firstExp; // 처음 입장시
    public bool _firstEneryCube; // 에너지 큐브 처음 상호작용 시

    [Space(12.0f)]
    public string[] _firstExpDialogues; // 첫 입장시 대사 목록
    public string[] _fragDialogues; // 파편관련 상호작용 대사 목록
    
    [Space(12.0f)]
    public string[] _energyCubeDialogues; // 에너지 큐브 상호작용 대사 목록
    public string[] _trapDialogues; // 함정(가시) 상호작용 대사
}
    