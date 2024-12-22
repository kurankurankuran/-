//**************************************************************:
// 機能：
// ・選択メニュー・仮のGameOver
//**************************************************************：
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Select : MonoBehaviour
{
    //シーンの番号
    public int Number;

    //ゲームシーンへ
    public void Scene()
    {
        fade.DanChu = true;
        //行きたいシーンの番号
        fade.ScenesNum =Number;
    }

    


}
