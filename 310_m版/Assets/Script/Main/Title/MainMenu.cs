//**************************************************************:
// �@�\�F
// �E���j���[�̃Q�[���J�n.�I��.�I�v�V����
//**************************************************************�F
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
   
    //�Q�[���V�[����
   public void PlayGame()
   {
        //  //�t�F�[�h�C���J�n
        //  fade.DanChu = true;
        ////��̃V�[���ɍs��
        //WaterWaveFade.Onoff = true;
        //WaterWaveFade.ScenesNum = 1;
        SceneManager.LoadSceneAsync(1);
        // GameObject.Find("Canvas").GetComponent<LoadScene>().StartLoad1(1);
        

    }
   
    //�I��
    public void QuitGame()
    {
        Debug.Log("QUIT!");

        Application.Quit();


    }


}
