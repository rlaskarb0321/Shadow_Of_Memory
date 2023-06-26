using System;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    /*
    저장할 데이터

1 플레이어의 (x, y) 위치

2 조각 모음 현황
2.1 맵에 남아있는 조각들의 인덱스
2.2 현재 모은 현황, 메모리보드 달성도

3 삐삐와의 상호작용
3.1 최근얻은 기억파편 인덱스
3.2 최근얻은 기억파편 인덱스에 대한 대화를 했는지 안했는지

4 플레이어의 성장 단계
4.1 성장 단계에 따른 콜리더 크기 기타 등등

5. 컷신
5.1 입장 컷신은 초기 생성할때에만 본다. 저장후 불러왔을때 또 볼 필요는 없음
5.2 삐삐 컷신을 보기 전과 후로 나무에 앉은 더미 삐삐 활성화 여부도 데이터에 추가

6. 최근 저장 날짜
6.1 저장했을때 날짜

     */

    public GameData _gameData;
    public Vector3 _playerPos; // 플레이어의 (x, y) 위치
    public string _nowTime; // 저장할 당시 현재 시간
    public bool[] _isFragIdxGet; // 획득한 기억조각의 인덱스
    public int _currCollectCount; // 현재 모은 조각의 수

    public SaveData(GameData gameData)
    {
        // 매개변수가 온다면, 온 값으로 초기화
        _gameData = gameData;

        _playerPos = gameData._playerPos;
        _nowTime = gameData._nowTime;
        _isFragIdxGet = gameData._isFragIdxGet;
        _currCollectCount = gameData._currCollectCount;
    }

    public SaveData()
    {
        // 매개변수없이 생성되면 초기값으로 생성
        _gameData = new GameData(Vector3.zero, new bool[ConstData._MEMORYCOUNT], 0);

        _playerPos = _gameData._playerPos;
        _nowTime = _gameData._nowTime;
        _isFragIdxGet = _gameData._isFragIdxGet;
        _currCollectCount = _gameData._currCollectCount;
    }
}
