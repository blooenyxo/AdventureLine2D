using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private PlayerInput playerInput;
    private float temp_x;
    public bool selectedUnit = false;
    public Vector3 viewDirection;

    // Use this for initialization
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        viewDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (playerInput.directionalInput.x == 0)
        {
            MoveAnimation(false, playerInput.directionalInput.x);
        }
        else
        {
            MoveAnimation(true, playerInput.directionalInput.x);

        }

        if (Input.GetButtonDown("Jump"))
        {
            JumpAnimation(true);
        }
        else
        {
            JumpAnimation(false);
        }


        if (viewDirection.x < transform.position.x && playerInput.selectedUnit == true)
        {
            temp_x = -1;
        }
        if (viewDirection.x > transform.position.x && playerInput.selectedUnit == true)
        {
            temp_x = 1;
        }


        anim.SetFloat("lastMoveX", temp_x);
    }

    public void MoveAnimation(bool state, float direction)
    {
        anim.SetBool("isWalking", state);
        anim.SetFloat("moveX", direction);
    }

    public void JumpAnimation(bool state)
    {
        anim.SetBool("isJumping", state);
    }
}
