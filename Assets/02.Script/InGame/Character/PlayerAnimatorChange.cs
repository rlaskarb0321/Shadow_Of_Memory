using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorChange : MonoBehaviour
{
    public RuntimeAnimatorController[] _anims;
    [SerializeField] private GameObject _groundCollObj;

    private BoxCollider2D _groundColl;
    private CapsuleCollider2D _capsuleColl2D;
    private Animator _currAnimator;
    private int _number;

    private void Awake()
    {
        _currAnimator = GetComponent<Animator>();
        _capsuleColl2D = GetComponent<CapsuleCollider2D>();
        _groundColl = _groundCollObj.GetComponent<BoxCollider2D>();
    }

    public void ChangeAnimator(int index)
    {
        _currAnimator.runtimeAnimatorController = _anims[index];
        switch (index)
        {
            // Level2
            case 1:
                _groundCollObj.transform.localPosition = new Vector3
                    (ConstData._LEVEL2_GROUND_COLL_TR_X, 
                     ConstData._LEVEL2_GROUND_COLL_TR_Y,
                     _groundCollObj.transform.position.z);

                _groundColl.size = new Vector2
                    (ConstData._LEVEL2_GROUND_COLL_SIZE_X, 
                     ConstData._LEVEL2_GROUND_COLL_SIZE_Y);

                _capsuleColl2D.offset = Vector2.zero;
                _capsuleColl2D.size = new Vector2(ConstData._LEVEL2_CAPSULE_COLL_SIZE_X, ConstData._LEVEL2_CAPSULE_COLL_SIZE_Y);
                break;

            // Level3
            case 2:
                _groundCollObj.transform.localPosition = new Vector3
                    (ConstData._LEVEL3_GROUND_COLL_TR_X,
                     ConstData._LEVEL3_GROUND_COLL_TR_Y,
                     _groundCollObj.transform.position.z);

                _groundColl.size = new Vector2
                    (ConstData._LEVEL3_GROUND_COLL_SIZE_X,
                     ConstData._LEVEL3_GROUND_COLL_SIZE_Y);

                _capsuleColl2D.offset = Vector2.zero;
                _capsuleColl2D.size = new Vector2(ConstData._LEVEL3_CAPSULE_COLL_SIZE_X, ConstData._LEVEL3_CAPSULE_COLL_SIZE_Y);
                break;
        }
    }
}
