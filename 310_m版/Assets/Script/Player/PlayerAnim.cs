using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//==============================================
// 移動とジャンプif文条件式に追記
//==============================================


public class PlayerAnim : MonoBehaviour
{
    // Animator コンポーネント
    private static Animator animator;

    // 設定したフラグの名前
    private const string key_isWait = "isWait";                 //待機アニメーション
    private const string key_isRun = "isRun";                   //走りアニメーション
    private const string key_isJump_start = "isJump_start";     //ジャンプ予備動作アニメーション
    private const string key_isJumping = "isJumping";           //ジャンプ上昇中アニメーション
    private const string key_isJump_down = "isJump_down";       //ジャンプ下降中アニメーション
    private const string key_isJump_landing = "isJump_landing"; //着地アニメーション
    private const string key_isDamage = "isDamage";             //被ダメージアニメーション
    private const string key_isClear = "isClear";               //クリア時アニメーション

    //着地判定用
    private bool old_OnGround;

    //ダメージアニメーション用
    private bool damage_anim;

    //private bool push_JumpBotton;

    TestJump jump;

    Rigidbody my_rigidbody;

    SoulCnt clear_condition;

    PlayerMove PlayerMoveScript;

    // Start is called before the first frame update
    void Start()
    {
        PlayerMoveScript = GetComponent<PlayerMove>();

        // 自分に設定されているAnimatorコンポーネントを習得する
        animator = GetComponent<Animator>();

        jump = GetComponent<TestJump>();

        my_rigidbody = GetComponent<Rigidbody>();

        if(SceneManager.GetActiveScene().buildIndex != 0)
        clear_condition = GameObject.Find("Souls").GetComponent<SoulCnt>();

        //push_JumpBotton = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PlayerMoveScript.GetMoveFlg())
        {
            
            if (!Pause.GetOnoffflg())
            {
                // DキーかAキーを押下している
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) ||
                    Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) ||
                    Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) ||
                    Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow) ||
                    Input.GetAxisRaw("Con_Horizontal") < 0 || Input.GetAxisRaw("Con_Horizontal") > 0)//Horizontal追記
                {
                    // WaitからRunに遷移する
                    animator.SetBool(key_isRun, true);
                }
                else
                {
                    animator.SetBool(key_isRun, false);
                }

                if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow)) 
                {
                    // WaitからRunに遷移する
                    animator.SetBool(key_isRun, false);
                    //this.animator.SetBool(key_isWait, true);
                }


                // Jumpに切り替える処理

                if (animator.GetBool(key_isJump_start))
                {
                    animator.SetBool(key_isJump_start, false);
                }
                // スペースキーを押下している
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Con_Jump"))//Con_Jump追記
                {
                    // Wait or RunからJumpに遷移する
                    animator.SetBool(key_isJump_start, true);
                }


                // 上昇中
                if (!jump.OnGround && my_rigidbody.velocity.y > 0)
                {
                    //this.animator.SetBool(key_isJump_start, false);
                    animator.SetBool(key_isJumping, true);
                    animator.SetBool(key_isRun, false);
                }
                else
                {
                    animator.SetBool(key_isJumping, false);
                }
                // 下降中
                if (!jump.OnGround && my_rigidbody.velocity.y < -1)
                {
                    animator.SetBool(key_isJumping, false);
                    animator.SetBool(key_isJump_down, true);
                    animator.SetBool(key_isRun, false);
                }



                if (animator.GetBool(key_isJump_landing))
                {
                    animator.SetBool(key_isJump_landing, false);
                }
                // 着地
                if (!old_OnGround && jump.OnGround)
                {

                    animator.SetBool(key_isJump_down, false);
                    if (
                        (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)) || 
                        (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))  ||
                        (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)) ||
                        (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow))
                        )
                    {

                        animator.SetBool(key_isJump_landing, true);
                    }
                    else
                    {
                        //this.animator.SetBool(key_isJump_down, false);
                        animator.SetBool(key_isRun, true);
                    }
                }
            }
            old_OnGround = jump.OnGround;

            if (jump.OnGround &&
                !animator.GetBool(key_isJump_start) &&
                !animator.GetBool(key_isJumping) &&
                !animator.GetBool(key_isJump_down) &&
                !animator.GetBool(key_isJump_landing) &&
                !animator.GetBool(key_isRun) &&
                !animator.GetBool(key_isDamage))
            {
                // JumpからWait or Runに遷移する
                //this.animator.SetBool(key_isJump_start, false);
                //this.animator.SetBool(key_isJumping, false);
                //this.animator.SetBool(key_isJump_down, false);
                //this.animator.SetBool(key_isJump_landing, false);

                animator.SetBool(key_isWait, true);
            }
            else
            {
                animator.SetBool(key_isWait, false);
            }

          
        }

        // クリア時アニメーション
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (clear_condition.CoinCount < 1)
            {
                animator.SetBool(key_isClear, true);
            }
        }
    }
    public static void SetDamageAnim(bool _bDamageAnim)
    {
        animator.SetBool(key_isDamage, _bDamageAnim);
    }

    public bool GetDamageAnim()
    {
        return damage_anim;
    }

    public static void AnimationAllReset()
    {
        animator.SetBool(key_isJump_start, false);
        animator.SetBool(key_isJumping, false);
        animator.SetBool(key_isJump_down, false);
        animator.SetBool(key_isJump_landing, false);
        animator.SetBool(key_isRun, false);
        animator.SetBool(key_isDamage, false);
    }


    void PlayerAnimReset()
    {
     
        animator.SetBool(key_isDamage, false);
      
    }


}