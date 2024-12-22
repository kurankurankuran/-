/**
* @file distortion.cs
* @brief distortion�N���X�̎���
* @author �q�@�a�K
* @date 5/5
*
* @details 
* @note 
*/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//using System.Linq;


/** �N���X�̊T�v���� */
/**
* �@�\�F
* �E�~�����̂̉�]
* �E��]���̉�]���x�A�����̐ݒ�
* �E�˂���̕����A�����̐ݒ�
* �E�\����ON/OFF
* �E���C���[�t���[������
* 
* �g����:
* �P�@��]�����q�I�u�W�F�N�g�Ƃ���e�I�u�W�F�N�g�ɃA�^�b�`����
* �Q�@�C���X�y�N�^�[���炻�ꂼ��̒l������
* �R�@�ȏ�
*/

public class distortion : MonoBehaviour
{
    [Header("��]���P�{���Ƃ̉�]���x")]
    [SerializeField]
    public float RotValue;

    [Header("�˂��ꂪ�������܂ł̃t���[����")]
    [SerializeField]
    public float RotTime;

    [Header("��]���P�{���Ƃ̉�]�������t�ɂ���")]
    [SerializeField]
    private bool RotReverse;

    [Header("�˂���̐i�s�������t�ɂ���")]
    [SerializeField]
    private bool distortionReverse;

    [Header("�\����ON/OFF")]
    [SerializeField]
    private bool Renderer;

    //[Header("���C���[�t���[���\���i���j�iRender��ON�K�{�j")]
    //[SerializeField]
    //private bool WireFrame;

    //[Header("�~���̉�]���x�i�����v���C���[�̈ړ����x�j")]
    //public float RotSpeed;

    //[Header("�~�������̃e�N�X�`���\�Q�̐e�I�u�W�F�N�g")]
    //[SerializeField]
    //private GameObject parentTex;

    // �~�������̃e�N�X�`���\�Q�̎q�I�u�W�F�N�g
    //private List<GameObject> childTexList = new List<GameObject>();

    //[Header("�~���O���̃e�N�X�`���\�Q�̐e�I�u�W�F�N�g")]
    //[SerializeField]
    //private GameObject parentTexOut;

    // �~���O���̃e�N�X�`���\�Q�̎q�I�u�W�F�N�g
    //private List<GameObject> childTexOutList = new List<GameObject>();

    //! ���̉�]������]���n�߂�܂ł̎���
    private float DiffCnt;

    //! ��]���S�ẴI�u�W�F�N�g�i�[�pList
    private List<GameObject> childList = new List<GameObject>();

    [Header("�˂��ꔭ���ꏊ�ԍ�")]
    //[SerializeField]
    //! ��]�����]���̔ԍ����w��
    public int childNum = 0;
    
    //! ���ꂪDiffCnt�𒴂���Ǝ��̉�]������]���n�߂�
    private float childCnt;

    //! ���ꂼ��̉�]���ɕt�^���ꂽRotObj�X�N���v�g�i�[�p
    private List<RotObj> RotObjScript = new List<RotObj>();

    //! ���ꂼ��̉�]���̊p�x��RotValue��������]��������
    private List<int> RotCnt = new List<int>();

    //! RotCnt�̒l������Ƃ߂�,����180����]�����Ƃ���RotCnt�̒l
    private float RotMax;

    //! ���̃X�N���v�g�ɉ�]���̐���n���p
    [System.NonSerialized] // public�����C���X�y�N�^�[�ɕ\�����Ȃ�
    public int MaxPillarNum = 360;

    Rotate distBGM;
    
    
    private void Awake()
    {
        //! �q���擾
        foreach (Transform child in transform)//! transform�̗v�f�̐������J��Ԃ��i���Ԃ�q�I�u�W�F�N�g��transform�̐������J��Ԃ��Ă���͂��j
        {
            bool bSkip = false;
            for (int i = 0; i < childList.Count; ++i)
            {
                if (childList[i].gameObject.name == child.gameObject.name)
                {
                    bSkip = true;
                }
            }

            if (!bSkip)
            {
                childList.Add(child.gameObject);
                RotCnt.Add(0);
            }

        }

        //! ���l�A�A���t�@�x�b�g���Ƀ\�[�g
        childList.Sort(
          (a, b) =>
          {
              return string.Compare(a.name, b.name);
          }
        );

        

        //! �l����
        MaxPillarNum = childList.Count;





        ///////////////////////////////////////////////////////////////////////////////////

        //! �q�I�u�W�F�N�g�i��]����RotObj��BWSwitch�X�N���v�g��t�^�j
        for (int i = 0; i < childList.Count; ++i)
        {
            if (childList[i].GetComponent<RotObj>() == null)
            {
                childList[i].AddComponent<RotObj>();
            }

            //if (childList[i].GetComponent<BWSwitch>() == null)
            //{
            //    childList[i].AddComponent<BWSwitch>();
            //}

            //! ���ꂼ��̉�]���ɕt�^���ꂽRotObj�X�N���v�g�擾
            RotObjScript.Add(childList[i].GetComponent<RotObj>());


        }




    }

    //Inspector�̓��e���ύX���ꂽ���Ɏ��s
    private void OnValidate()
    {
        //! �q���擾
        foreach (Transform child in transform)//! transform�̗v�f�̐������J��Ԃ��i���Ԃ�q�I�u�W�F�N�g��transform�̐������J��Ԃ��Ă���͂��j
        {
            bool bSkip = false;
            for (int i = 0; i < childList.Count; ++i)
            {
                if (childList[i].gameObject.name == child.gameObject.name)
                {
                    bSkip = true;
                }
            }

            if (!bSkip)
            {
                childList.Add(child.gameObject);
                RotCnt.Add(0);
            }

        }

        //! ���l�A�A���t�@�x�b�g���Ƀ\�[�g
        childList.Sort(
          (a, b) =>
          {
              return string.Compare(a.name, b.name);
          }
        );

        
        //! �l����
        MaxPillarNum = childList.Count;

        


        //PlayerMoveScript = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //RotTime *= 60;

        if(SceneManager.GetActiveScene().buildIndex!=0)
        distBGM = GameObject.Find("DistortionBGM").GetComponent<Rotate>();

        DiffCnt = RotTime / childList.Count;//! ���̒�����]����܂ł̎���




        //Debug.Log(DiffCnt);
        childCnt = 0;

        RotMax = 180 / RotValue;

        float distDiff = 180 / RotValue;//! ��]�����ꂼ�ꂪ�����ɂ�����t���[����
                                        //! float distCnt = distDiff / DiffCnt;
                                        //! Debug.Log(distDiff);


        if (RotReverse)
        {
            RotValue = -RotValue;
        }
       

        
        //! �����˂���ʒu
        int j = 0;
        if (distortionReverse)
        {

            //childNum = 0;
            for (int i = childNum; i < childNum + distDiff; ++i, ++j)
            {
                childList[i].transform.Rotate(j * -RotValue /** DiffCnt*/, 0.0f, 0.0f);
               

                RotObjScript[i].RotBool = true;

                //RotCnt[i] = j;
                RotCnt[i] = (int)((distDiff - j));

                if (RotCnt[i] >= (int)distDiff)
                {
                    RotObjScript[i].RotBool = false;
                    RotCnt[i] = 0;
                }

            }
            childNum += (int)distDiff;
        }
        else
        {
            //childNum = (int)distCnt;
            for (int i = childNum; i > childNum - distDiff; --i, ++j)
            {
                if (i < 0)
                    return;

                childList[i].transform.Rotate(j * -RotValue /** DiffCnt*/, 0.0f, 0.0f);
               
                RotObjScript[i].RotBool = true;
                
                RotCnt[i] = (int)((distDiff - j));

                if (RotCnt[i] >= (int)distDiff)
                {
                    RotObjScript[i].RotBool = false;
                    RotCnt[i] = 0;
                }
            }

            childNum -= (int)distDiff;
        }
    }

    private void FixedUpdate()
    {
        //! �~����]�����Ɖ�]�����ꂼ��̉�]����
        for (int i = 0; i < childList.Count; i++)
        {


            //! ��]�����ꂼ��̉�]����
            if (!RotObjScript[i].RotBool) continue;

            childList[i].transform.Rotate(RotValue, 0f, 0f/*, Space.Self*/);
            //GameObject.Find("AudioController").GetComponent<GAudio>().NejireSE.Play();


            RotCnt[i]++;
            if (RotCnt[i] >= RotMax/* - 1*/)
            {
                RotObjScript[i].RotBool = false;
                RotCnt[i] = 0;

                //! �q�I�u�W�F�N�g��S�Ď擾����
                foreach (Transform childTransform in RotObjScript[i].transform)
                {
                    childTransform.gameObject.GetComponent<MeshRenderer>().enabled = true;
                }

            }
        }


        //! �אڂ����]�������]�������X�ɉ�]�����Ă��������i�˂���𐶂ݏo���j
        childCnt += 1.0f;
        if (childCnt > DiffCnt)
        {
            RotObjScript[childNum].RotBool = true;
           
            //! �q�I�u�W�F�N�g��S�Ď擾����
            foreach (Transform childTransform in RotObjScript[childNum].transform)
            {
                //childTransform.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }

            childCnt = 0;
            if (distortionReverse)
            {
                childNum++;
                if (childNum >= childList.Count)
                {
                    childNum = 0;

                }
            }
            else
            {
                childNum--;
                if (childNum < 0)
                {
                    childNum = childList.Count - 1;

                }

            }

            if (SceneManager.GetActiveScene().buildIndex != 0)
                distBGM.SetCubePos(childNum);
            //GAudio.distBGMPlay();
            //gAudio.distBGMPlay();
        }

    }

    // Update is called once per frame
    void Update()
    {
        //// �~����]�����Ɖ�]�����ꂼ��̉�]����
        //for (int i = 0; i < childList.Count; i++)
        //{


        //    // ��]�����ꂼ��̉�]����
        //    if (!RotObjScript[i].RotBool) continue;
        //    childList[i].transform.Rotate(RotValue, 0f, 0f/*, Space.Self*/);


        //    RotCnt[i]++;
        //    if (RotCnt[i] > RotMax - 1)
        //    {
        //        RotObjScript[i].RotBool = false;
        //        RotCnt[i] = 0;

        //        // �q�I�u�W�F�N�g��S�Ď擾����
        //        foreach (Transform childTransform in RotObjScript[i].transform)
        //        {
        //            childTransform.gameObject.GetComponent<MeshRenderer>().enabled = true;
        //        }

        //    }
        //}


        //// �אڂ����]�������]�������X�ɉ�]�����Ă��������i�˂���𐶂ݏo���j
        //childCnt += 0.1f;
        //if (childCnt > DiffCnt)
        //{
        //    RotObjScript[childNum].RotBool = true;

        //    // �q�I�u�W�F�N�g��S�Ď擾����
        //    foreach (Transform childTransform in RotObjScript[childNum].transform)
        //    {
        //        //childTransform.gameObject.GetComponent<MeshRenderer>().enabled = false;
        //    }

        //    childCnt = 0;
        //    if (distortionReverse)
        //    {
        //        childNum++;
        //        if (childNum >= childList.Count)
        //        {
        //            childNum = 0;

        //        }
        //    }
        //    else
        //    {
        //        childNum--;
        //        if (childNum < 0)
        //        {
        //            childNum = childList.Count - 1;

        //        }

        //    }
        //}


    }

}
