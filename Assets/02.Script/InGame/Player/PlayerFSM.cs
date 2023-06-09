using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : MonoBehaviour
{
    public enum ePlayerState { Idle, Move, Fall, Jump, }

    private ePlayerState _ePlayerFSM;
    public ePlayerState ePlayerFSM { get { return _ePlayerFSM; } set { _ePlayerFSM = value; } }
}
