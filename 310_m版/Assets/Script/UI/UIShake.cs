/**
* @file UIShake.cs
* @brief UIShake�N���X�̎���
* @author �q�@�a�K
* @date 5/5
*
* @details 
* @note 
*/

using System.Collections;
using UnityEngine;
using UnityEngine.UI;


/** �N���X�̊T�v���� */
/**
* �@�\�F
* Image��h�炷�N���X
*/
public class UIShake : MonoBehaviour
{
    [SerializeField]
    Image image;


    /**
* �֐��̊T�v����
*
* @param[in] duration �h��̎��� 
* @param[in] magnitude �h��̕�
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