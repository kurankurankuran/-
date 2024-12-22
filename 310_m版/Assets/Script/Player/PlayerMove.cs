//**************************************************************:
// �@�\�F
// �E�v���C���[�̃W�����v�̎����Ƒ��x����
//***************************************************************
// �g����
// �P�@�v���C���[�I�u�W�F�N�g�ɃA�^�b�`
// �Q�@�C���X�y�N�^�[����l��ݒ�
// �R�@�ȏ�
// ���ړ��ɂ��Ă�distortion�X�N���v�g�Őݒ�
//**************************************************************


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //[Header("�W�����v��")]
    //[SerializeField]
    //private float jumpPower;

    [Header("�ړ����x����")]
    [SerializeField]
    float LimitSpeed;

    [Header("�~���̉�]���x�i�����v���C���[�̈ړ����x�j")]
    public float RotSpeed = 0.1f;

    [SerializeField]
    private Rigidbody rb;
    
    //private bool bJump;

    private float x;

    [HideInInspector]
    public bool bMoveRight { set; get; }

    [HideInInspector]
    public bool bMoveLeft { set; get; }

    [HideInInspector]
    public GameObject RightObj;

    [HideInInspector]
    public GameObject LeftObj;

    GameObject CameraObj;

    //Behaviour myBehavior;
    private bool bMove = false;

    private int RunSECount = 0;

    private TestJump testJump;
    private GAudio gAudio;

    // Start is called before the first frame update
    void Start()
    {


        //myBehavior = GetComponent<Behaviour>();
        //bMove = true;
        gAudio = GameObject.Find("AudioController").GetComponent<GAudio>();
        testJump = GetComponent<TestJump>();

        CameraObj = GameObject.FindWithTag("MainCamera");
      
        bMoveRight = true;
        bMoveLeft = true;
    }

    private void FixedUpdate()
    {
        //if (tutorial.IsDoing()) 
        //{
           
        //    bMove = false;
        //}
        //if ( tutorial.TutorialDone())
        //{
          
        //    bMove = true;
        //}
        


        if (bMove)
        {
            // ���͂��������Ɍ�������

            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
            {
                // �������Ȃ�
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetAxisRaw("Con_Horizontal") > 0)
            {


                transform.rotation = Quaternion.LookRotation(CameraObj.transform.right, CameraObj.transform.up);
               
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetAxisRaw("Con_Horizontal") < 0)
            {
                transform.rotation = Quaternion.LookRotation(-CameraObj.transform.right, CameraObj.transform.up);
            }

            if (testJump.OnGround == true)
            {
                
                

                var controllerNames = Input.GetJoystickNames();

                int currentConnectionCount = 0;

                for (int i = 0; i < controllerNames.Length; i++)
                {
                    currentConnectionCount++;
                    //if (controllerNames[i] != "")
                    //{
                    //    currentConnectionCount++;
                    //}
                }

                if (currentConnectionCount == 0/*controllerNames[0].Length == 0*/)
                {
                    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)
                       )
                    {
                        RunSECount = 0;
                        gAudio.AudioPSE.Stop();

                    }

                    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)

                        )
                    {
                        RunSECount += 1;

                        if (RunSECount == 20.0f)
                        {
                            RunSECount = 0;
                            gAudio.AudioPSE.Play();
                        }
                    }
                }
                else
                {
                    if (Input.GetAxisRaw("Con_Horizontal") == 0 && RunSECount != 0)
                    {
                        RunSECount = 0;
                        gAudio.AudioPSE.Stop();

                    }

                    if (Input.GetAxisRaw("Con_Horizontal")!=0)
                    {
                        RunSECount += 1;

                        if (RunSECount == 20.0f)
                        {
                            RunSECount = 0;
                            gAudio.AudioPSE.Play();
                        }
                    }
                }


            }
        }

        //���x����
        if (rb.velocity.magnitude > LimitSpeed)
        {
            rb.velocity = rb.velocity.normalized * LimitSpeed;
        }
    }

   


    public void CirCleMove(Transform Rottransform)
    {
       
        if (bMove/*myBehavior.enabled*/)
        {

            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow))
            {
                // �������Ȃ�
            }
            else
            {
             
                var controllerNames = Input.GetJoystickNames();

                int currentConnectionCount = 0;

                for (int i = 0; i < controllerNames.Length; i++)
                {
                    currentConnectionCount++;
                    //if (controllerNames[i] != "")
                    //{
                    //    currentConnectionCount++;
                    //}
                }

                if (currentConnectionCount == 0/*controllerNames[0].Length == 0*/) 
                {
                    //Debug.Log("pp");
                    x = Input.GetAxis("Horizontal") * RotSpeed;
                }
                else
                {
                    x = Input.GetAxis("Con_Horizontal") * RotSpeed;
                }

                if (!bMoveRight)
                {
                    if (x > 0)
                    {
                        x = 0;
                    }

                }
                if (!bMoveLeft)
                {
                    if (x < 0)
                    {
                        x = 0;
                    }

                }

                Rottransform.RotateAround(Rottransform.position/*new Vector3(0.0f, 0.0f, 0.0f)*/, new Vector3(0.0f, 1.0f, 0.0f), -x);
            }
        }
    }

    public void SetMoveFlg(bool _bMove)
    {
        bMove = _bMove;
    }

    public bool GetMoveFlg()
    {
        return bMove;
    }
}
