using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//==============================================
// �ړ��ƃW�����vif���������ɒǋL
//==============================================


public class PlayerAnim : MonoBehaviour
{
    // Animator �R���|�[�l���g
    private static Animator animator;

    // �ݒ肵���t���O�̖��O
    private const string key_isWait = "isWait";                 //�ҋ@�A�j���[�V����
    private const string key_isRun = "isRun";                   //����A�j���[�V����
    private const string key_isJump_start = "isJump_start";     //�W�����v�\������A�j���[�V����
    private const string key_isJumping = "isJumping";           //�W�����v�㏸���A�j���[�V����
    private const string key_isJump_down = "isJump_down";       //�W�����v���~���A�j���[�V����
    private const string key_isJump_landing = "isJump_landing"; //���n�A�j���[�V����
    private const string key_isDamage = "isDamage";             //��_���[�W�A�j���[�V����
    private const string key_isClear = "isClear";               //�N���A���A�j���[�V����

    //���n����p
    private bool old_OnGround;

    //�_���[�W�A�j���[�V�����p
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

        // �����ɐݒ肳��Ă���Animator�R���|�[�l���g���K������
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
                // D�L�[��A�L�[���������Ă���
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) ||
                    Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) ||
                    Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) ||
                    Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow) ||
                    Input.GetAxisRaw("Con_Horizontal") < 0 || Input.GetAxisRaw("Con_Horizontal") > 0)//Horizontal�ǋL
                {
                    // Wait����Run�ɑJ�ڂ���
                    animator.SetBool(key_isRun, true);
                }
                else
                {
                    animator.SetBool(key_isRun, false);
                }

                if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow)) 
                {
                    // Wait����Run�ɑJ�ڂ���
                    animator.SetBool(key_isRun, false);
                    //this.animator.SetBool(key_isWait, true);
                }


                // Jump�ɐ؂�ւ��鏈��

                if (animator.GetBool(key_isJump_start))
                {
                    animator.SetBool(key_isJump_start, false);
                }
                // �X�y�[�X�L�[���������Ă���
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Con_Jump"))//Con_Jump�ǋL
                {
                    // Wait or Run����Jump�ɑJ�ڂ���
                    animator.SetBool(key_isJump_start, true);
                }


                // �㏸��
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
                // ���~��
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
                // ���n
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
                // Jump����Wait or Run�ɑJ�ڂ���
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

        // �N���A���A�j���[�V����
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