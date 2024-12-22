using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;

public class SelectCursor : MonoBehaviour
{
    Rigidbody _rb;
    public bool isUseCameraDirection;    // �J�����̌����ɍ��킹�Ĉړ����������ꍇ��true
    public float moveSpeed;              // �ړ����x
    public float moveForceMultiplier;    // �ړ����x�̓��͂ɑ΂���Ǐ]�x
    public GameObject mainCamera;
    float _horizontalInput;
    float _verticalInput;




    private int SceneNum = 0;

    //[Header("�����̃��W�b�h�{�f�B��D&D")]
    //[SerializeField]
    //Rigidbody myRigidbody;

    //[Header("�ړ������g�ɉ������")]
    //[SerializeField]
    //private float Power = 500; 

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        if (mainCamera == null)
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {


        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        //if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
        //{
        //    // �������Ȃ�
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    myRigidbody.AddForce(new Vector3(-Power, 0.0f, 0.0f));
        //}
        //else if (Input.GetKey(KeyCode.A))
        //{
        //    myRigidbody.AddForce(new Vector3(Power, 0.0f, 0.0f));
        //}

        //if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        //{
        //    // �������Ȃ�
        //}
        //else if (Input.GetKey(KeyCode.W))
        //{
        //    myRigidbody.AddForce(new Vector3(0.0f, -Power, 0.0f));
        //}
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    myRigidbody.AddForce(new Vector3(0.0f, Power, 0.0f));
        //}



        if (SceneNum != 0)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SAudio.AudioSE.Play();

                //WaterWaveFade.Onoff = true;
                ////�s�������V�[���̔ԍ�
                //WaterWaveFade.ScenesNum = SceneNum + 1/*�V�[���ԍ�����Ă�̒����� +1 */;

                //GameObject.Find("Canvas").GetComponent<LoadScene>().StartLoad(SceneNum + 1);
                LoadScene.StartLoad(SceneNum + 1);
            }
        }
    }


    void FixedUpdate()
    {
        Vector3 moveVector = Vector3.zero;    // �ړ����x�̓���

        if (isUseCameraDirection)
        {
            Vector3 cameraForward = mainCamera.transform.forward;
            Vector3 cameraRight = mainCamera.transform.right;
            cameraForward.y = 0.0f;    // ���������Ɉړ����������ꍇ��y����������0�ɂ���
            cameraRight.y = 0.0f;

            moveVector = moveSpeed * (cameraRight.normalized * -_horizontalInput + cameraForward.normalized * -_verticalInput);
        }
        else
        {
            moveVector.x = moveSpeed * -_horizontalInput;
            moveVector.z = moveSpeed * -_verticalInput;
        }

        _rb.AddForce(moveForceMultiplier * (moveVector - _rb.velocity));
    }


    // SceneNum�X�N���v�g����SceneNum��ݒ肷��
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SceneNumScript>() != null)
        {
            SceneNum = other.GetComponent<SceneNumScript>().GetSceneNum();
        }

    }

    // SceneNum�X�N���v�g������I�u�W�F�N�g���痣����SceneNum��0�ɂ���
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<SceneNumScript>() != null)
        {
            SceneNum = 0;
        }

    }


}
