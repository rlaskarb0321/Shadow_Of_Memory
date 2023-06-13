using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleBackGround : MonoBehaviour
{
    public GameObject[] _puzzlePieces;
    public GameObject _monologue;

    private Piece[] _pieces;

    private void Awake()
    {
        _pieces = new Piece[_puzzlePieces.Length];
    }

    private void Start()
    {
        for (int i = 0; i < _puzzlePieces.Length; i++)
        {
            _pieces[i] = _puzzlePieces[i].GetComponentInChildren<Piece>();
        }
        StartCoroutine(ActiveOnPuzzle());
    }

    IEnumerator ActiveOnPuzzle()
    {
        int index = 0;
        while (index < _puzzlePieces.Length)
        {
            _puzzlePieces[index].gameObject.SetActive(true);
            yield return new WaitUntil(() => _pieces[index]._isEnd);
            index++;
        }

        yield return new WaitForSeconds(5.0f);

        _monologue.SetActive(true);
    }
}
