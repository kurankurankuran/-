using System.Collections;
using UnityEngine;
using XInputDotNetPure;//0507�U���p�ǋL

public class CameraShake : MonoBehaviour
{
    private static bool bShake;

    private void Start()
    {
        bShake = true;
    }

    public void Shake(float duration, float magnitude)
    {
        if (bShake)
        {
            StartCoroutine(DoShake(duration, magnitude));
            bShake = false;
        }
    }

    private IEnumerator DoShake(float duration, float magnitude)
    {
        var pos = transform.localPosition;

        var elapsed = 0f;

        while (elapsed < duration)
        {
            var x = pos.x + Random.Range(-5f, 5f) * magnitude;
            var y = pos.y + Random.Range(-5f, 5f) * magnitude;

            transform.localPosition = new Vector3(x, y, pos.z);

            elapsed += 1.0f/*Time.deltaTime*/;

            //�U��0507�ǋL
            GamePad.SetVibration(0, 1, 1);

            yield return null;

            //�U�����~�߂�0507�ǋL
            GamePad.SetVibration(0, 0, 0);
        }

        bShake = true;
        transform.localPosition = pos;
    }
}