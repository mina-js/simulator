using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private bool holding = false;
    private Vector3 moveVec;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (holding)
        {
            transform.position += moveVec;
        }
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        if(ctx.performed && !ctx.started) //not sure why its not the other way around but this detects press, not release
        {
            holding = true;
            Vector2 inputVec = ctx.action.ReadValue<Vector2>();
            moveVec = new Vector3(inputVec.x, 0, inputVec.y);
        }
        else
        {
            holding = false;
        }

    }
}
