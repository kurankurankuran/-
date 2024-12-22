using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RShock : MonoBehaviour
{
    PlayerMove PlayerMoveScript;
    Quaternion Rotate;
    Vector3 Position;

    //�ڒn�����ꍇ�̏���
    public UnityEvent OnEnterGround;
    //�n�ʂ��痣�ꂽ�ꍇ�̏���
    public UnityEvent OnExitGround;
    //�ڒn��
    //private int enterNum = 0;

    //! ��]���S�ẴI�u�W�F�N�g�i�[�pList
    private List<Renderer> EnterList = new List<Renderer>();

    // Start is called before the first frame update
    void Start()
    {

        Rotate = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        Position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        //transform.rotation = Rotate;


        PlayerMoveScript = transform.parent.GetComponent<PlayerMove>();
    }




    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < EnterList.Count; ++i)
        {
            if (EnterList[i] == null)
            {
                EnterList.Remove(EnterList[i]);
                if (EnterList.Count <= 0)
                    OnExitGround.Invoke();
                continue;
            }
            if (!EnterList[i].enabled)
            {
                if (EnterList[i].name == "eff_pfb_Darksoul")
                {


                    continue;

                }
                EnterList.Remove(EnterList[i]);
                if (EnterList.Count <= 0)
                    OnExitGround.Invoke();
            }
        }

        transform.rotation = new Quaternion(Rotate.x, Rotate.y, Rotate.z, Rotate.w);
        transform.position = new Vector3(Position.x, transform.parent.position.y + 0.5f, Position.z);

     
    }

  

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag != "Screen" && other.tag != "ThatScreen" && other.tag != "Gage")
        //{
        //    if (!other.isTrigger)
        //    {

        //        PlayerMoveScript.bMoveRight = false;
        //        PlayerMoveScript.RightObj = other.gameObject;
        //    }
        //}

        if (other.tag != "Player")
        {
            if (other.tag != "Screen" && other.tag != "ThatScreen" && other.tag != "Gage")
            {
                if (!other.isTrigger)
                {

                    var render = other.GetComponent<Renderer>();
                    if (render != null)
                    {
                        if (render.enabled || render.name == "eff_pfb_Darksoul")
                        {

                            OnEnterGround.Invoke();
                            EnterList.Add(render);

                        }

                        //enterNum++;

                    }
                    else
                    {

                        //Debug.Log("�����_�[�Ȃ�");
                    }
                }
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
   

        if (other.tag != "Player")
        {
            if (other.tag != "Screen" && other.tag != "ThatScreen" && other.tag != "Gage")
            {
                if (!other.isTrigger)
                {
                    var render = other.GetComponent<Renderer>();

                    if (render != null)
                    {
                        //Renderer render = other.GetComponent<Renderer>();
                        if (render.enabled || other.name == "eff_pfb_Darksoul")
                        {
                            
                            EnterList.Remove(render);
                        }

                        if (EnterList.Count <= 0)
                            OnExitGround.Invoke();
                    }
                    else
                    {
                        //Debug.Log("�����_�[�Ȃ�");
                    }
                }
            }
        }
    }
    
}
