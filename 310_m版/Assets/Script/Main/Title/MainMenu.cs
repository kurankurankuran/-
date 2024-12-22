//**************************************************************:
// 機能：
// ・メニューのゲーム開始.終了.オプション
//**************************************************************：
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
   
    //ゲームシーンへ
   public void PlayGame()
   {
        //  //フェードイン開始
        //  fade.DanChu = true;
        ////一のシーンに行く
        //WaterWaveFade.Onoff = true;
        //WaterWaveFade.ScenesNum = 1;
        SceneManager.LoadSceneAsync(1);
        // GameObject.Find("Canvas").GetComponent<LoadScene>().StartLoad1(1);
        

    }
   
    //終了
    public void QuitGame()
    {
        Debug.Log("QUIT!");

        Application.Quit();


    }


}
