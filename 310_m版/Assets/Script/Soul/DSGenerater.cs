/**
* @file DSGenerater.cs
* @brief DSGeneraterクラスの実装
* @author 倉　和規
* @date 5/5
*
* @details 
* @note 
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/** クラスの概要説明 */
/**
* 機能：
* ・ねじれによってオブジェクトを生成する
* 使い方:
* １ オブジェクトにアタッチする
* 2 インスペクターに生成したいオブジェクトをD&D
*/
public class DSGenerater : MonoBehaviour
{
    [SerializeField] public GameObject DsObject;

    [Header("最初から生成されているかどうか")]
    [SerializeField]
    private bool bGenerate = true;
   
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Gage")
        {
            if (bGenerate/*transform.childCount <= 0*/)
            {
                
                bGenerate = false;

                GameObject Ds = Instantiate(DsObject, this.transform.position, Quaternion.identity); //ゲームオブジェクト生成

                Ds.transform.rotation = transform.rotation;
                Ds.transform.parent = this.transform.parent;
                


                foreach (Transform childTransform in Ds.transform)
                {
                    childTransform.GetComponent<DarkSoulScript>().SetPlayer(GameObject.FindGameObjectWithTag("Player"));

                    break;
                }
               

               
            }
            else
            {
                bGenerate = true;
            }
        }
    }
}
