//**************************************************************:
// �@�\�F
// �E�I�����j���[�E����GameOver
//**************************************************************�F
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Select : MonoBehaviour
{
    //�V�[���̔ԍ�
    public int Number;

    //�Q�[���V�[����
    public void Scene()
    {
        fade.DanChu = true;
        //�s�������V�[���̔ԍ�
        fade.ScenesNum =Number;
    }

    


}
