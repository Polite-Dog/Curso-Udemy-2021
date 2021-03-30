using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeController : MonoBehaviour
{
    private Animator _animator;

    private const string MOVE_HAND = "Move Hand";
    private const string MOVE_X = "Move_X";
    private const string MOVE_Y = "Move_Y";
    private const string IS_MOVING = "Is Moving";

    private bool isMovingHand = false;
    private bool isMoving = false;
    private float moveX = 0, moveY = 0;






    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool(MOVE_HAND, isMovingHand);
        _animator.SetFloat(MOVE_X, moveX);
        _animator.SetFloat(MOVE_Y, moveY);
        _animator.SetBool(IS_MOVING, isMoving);
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

       if(Mathf.Sqrt(moveX*moveX+moveY*moveY)>0.1)
        {

            _animator.SetBool(IS_MOVING, true);
            _animator.SetFloat(MOVE_X, moveX);
            _animator.SetFloat(MOVE_Y, moveY);
            
            
        }
        else
        {
            _animator.SetBool(IS_MOVING, false);
            _animator.SetFloat(MOVE_X, 0);
            _animator.SetFloat(MOVE_Y, 0);
        }
      
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isMovingHand = !isMovingHand;
            _animator.SetBool(MOVE_HAND, isMovingHand);
        }         
                
                
                
    }
}
