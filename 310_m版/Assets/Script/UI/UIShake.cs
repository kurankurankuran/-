/**
* @file UIShake.cs
* @brief UIShakeクラスの実装
* @author 倉　和規
* @date 5/5
*
* @details 
* @note 
*/

using System.Collections;
using UnityEngine;
using UnityEngine.UI;


/** クラスの概要説明 */
/**
* 機能：
* Imageを揺らすクラス
*/
public class UIShake : MonoBehaviour
{
    [SerializeField]
    Image image;


    /**
* 関数の概要説明
*
* @param[in] duration 揺れの時間 
* @param[in] magnitude 揺れの幅
*/
    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(DoShake(duration, magnitude));
    }

    private IEnumerator DoShake(float duration, float magnitude)
    {
        var pos = image.rectTransform.localPosition;

        var elapsed = 0f;

        while (elapsed < duration)
        {
            var x = pos.x + Random.Range(-10f, 10f) * magnitude;
            var y = pos.y + Random.Range(-10f, 10f) * magnitude;

            transform.localPosition = new Vector3(x, y, pos.z);

            elapsed += 1.0f/*Time.deltaTime*/;

            yield return null;
        }

        transform.localPosition = pos;
    }
}