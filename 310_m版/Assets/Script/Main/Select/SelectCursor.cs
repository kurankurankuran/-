using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;

public class SelectCursor : MonoBehaviour
{
    Rigidbody _rb;
    public bool isUseCameraDirection;    // カメラの向きに合わせて移動させたい場合はtrue
    public float moveSpeed;              // 移動速度
    public float moveForceMultiplier;    // 移動速度の入力に対する追従度
    public GameObject mainCamera;
    float _horizontalInput;
    float _verticalInput;




    private int SceneNum = 0;

    //[Header("自分のリジッドボディをD&D")]
    //[SerializeField]
    //Rigidbody myRigidbody;

    //[Header("移動時自身に加える力")]
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
        //    // 何もしない
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
        //    // 何もしない
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
                ////行きたいシーンの番号
                //WaterWaveFade.ScenesNum = SceneNum + 1/*シーン番号ずれてるの調整分 +1 */;

                //GameObject.Find("Canvas").GetComponent<LoadScene>().StartLoad(SceneNum + 1);
                LoadScene.StartLoad(SceneNum + 1);
            }
        }
    }


    void FixedUpdate()
    {
        Vector3 moveVector = Vector3.zero;    // 移動速度の入力

        if (isUseCameraDirection)
        {
            Vector3 cameraForward = mainCamera.transform.forward;
            Vector3 cameraRight = mainCamera.transform.right;
            cameraForward.y = 0.0f;    // 水平方向に移動させたい場合はy方向成分を0にする
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


    // SceneNumスクリプトからSceneNumを設定する
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SceneNumScript>() != null)
        {
            SceneNum = other.GetComponent<SceneNumScript>().GetSceneNum();
        }

    }

    // SceneNumスクリプトがあるオブジェクトから離れるとSceneNumを0にする
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<SceneNumScript>() != null)
        {
            SceneNum = 0;
        }

    }


}
