using UnityEngine;
using UnityEngine.InputSystem;

public class FlickScript : MonoBehaviour
{
    private Vector2 startTouchPos;
    private Vector2 endTouchPos;

    private float flickValue_x;
    private float flickValue_y;

    private Animator anim;
    private Rigidbody player_rb;

    void Start()
    {
        player_rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // タッチ入力
        if (Touchscreen.current != null)
        {
            var touch = Touchscreen.current.primaryTouch;

            if (touch.press.wasPressedThisFrame)
            {
                startTouchPos = touch.position.ReadValue();
            }

            if (touch.press.wasReleasedThisFrame)
            {
                endTouchPos = touch.position.ReadValue();
                FlickDirection();
                GetDirection();
            }
        }

        // マウス入力（Editor・PC用）
        if (Mouse.current != null)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                startTouchPos = Mouse.current.position.ReadValue();
            }

            if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                endTouchPos = Mouse.current.position.ReadValue();
                FlickDirection();
                GetDirection();
            }
        }
    }

    void FlickDirection()
    {
        flickValue_x = endTouchPos.x - startTouchPos.x;
        flickValue_y = endTouchPos.y - startTouchPos.y;

        Debug.Log("x スワイプ量は " + flickValue_x);
        Debug.Log("y スワイプ量は " + flickValue_y);
    }

    void GetDirection()
    {
        //anim.SetBool("Attack", false);

        if (flickValue_x > 500f)
        {
            Debug.Log("右フリック");
            anim.Play("Attack");
        }

        if (flickValue_x < -500f)
        {
            Debug.Log("左フリック");
            //anim.SetBool("Attack", true);
            anim.Play("Attack");
        }

        if (flickValue_y > 500f)
        {
            Debug.Log("上フリック");
            anim.Play("Attack");
        }

        if (flickValue_y < -500f)
        {
            Debug.Log("下フリック");
            anim.Play("Attack");
        }
    }
}