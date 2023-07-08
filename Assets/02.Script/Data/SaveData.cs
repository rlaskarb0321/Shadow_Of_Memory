using System;
using UnityEngine;

public class SaveData
{
    /*
    저장할 데이터

1 플레이어의 (x, y) 위치 -> Vector3 _playerPos;

2 조각 모음 현황
2.1 맵에 남아있는 조각들의 인덱스 -> bool[] _isFragIdxGet;
2.2 현재 모은 현황, 메모리보드 달성도 -> int _currCollectCount; ,  _currCollectCount / _TOTALMEMORYCOUNT;

3 삐삐와의 상호작용
3.1 최근얻은 기억파편 인덱스 -> int _recentFragIdx
3.2 최근얻은 기억파편 인덱스에 대한 대화를 했는지 안했는지

4 플레이어의 성장 단계
4.1 성장 단계에 따른 capsule 2d 콜리더의 size 값 -> ok
4.2 성장 단계에 따른 grounded coll 의 transform 과 size -> ok

5. 컷신
5.1 입장 컷신은 초기 생성할때에만 본다. 저장후 불러왔을때 또 볼 필요는 없음 -> bool _isFirstEnter;
5.2 삐삐 컷신을 보기 전과 후로 나무에 앉은 더미 삐삐 활성화 여부도 데이터에 추가 -> bool _isMeetPpippi;

6. 최근 저장 날짜
6.1 저장했을때 날짜 -> string _nowTime;

7. 삐삐 이벤트 리스트 : 값만 전달 후, 불러올때 GObj을 생성시키고 값을 적용시키자
7.1 강조 리스트 항목
7.2 올드 리스트 항목

     */

    public GameData _gameData;

    public SaveData(GameData gameData)
    {
        // 매개변수가 온다면, 온 값으로 초기화
        _gameData = gameData;
    }

    public SaveData()
    {
        // 매개변수없이 생성되면 초기값으로 생성
        _gameData = new GameData(
                new Vector3(ConstData._INITPOSX, ConstData._INITPOSY, ConstData._INITPOSZ), // 매개변수 1 -> 플레이어 위치
                new bool[ConstData._TOTALMEMORYCOUNT],                                      // 매개변수 2 -> 기억조각 인덱스별 획득 여부
                ConstData._INITCOLLECTCOUNT,                                                // 매개변수 3 -> 현재 모은 조각 수
                0,                                                                          // 매개변수 4 -> 새로먹은 조각의 인덱스
                false,                                                                      // 매개변수 5 -> 입장컷신 다 봤는지
                false,                                                                      // 매개변수 6 -> 삐삐랑 만났는지    
                new bool[ConstData._TOTALMEMORYCOUNT],                                      // 매개변수 7 -> 메모리 보드의 인덱스별 활성화 여부
                null,                                                                       // 매개변수 8 -> 새 삐삐 이벤트
                null);                                                                      // 매개변수 9 -> 기존 삐삐 이벤트들
    }
}
