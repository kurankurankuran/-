
using UnityEngine;
using UnityEngine.UI;

public static class ImageExt
{
    /// <summary>
    /// Image�̕s�����x��ݒ肷��
    /// </summary>
    /// <param name="image">�ݒ�Ώۂ�Image�R���|�[�l���g(this)</param>
    /// <param name="alpha">�s�����x�B0=���� 1=�s����</param>
    public static void SetOpacity(this Image image, float alpha)
    {
        var c = image.color;
        image.color = new Color(c.r, c.g, c.b, alpha);
    }

    public static float GetOpacity(this Image image)
    {
        

        return image.color.a;

        //var c = image.color;
        //image.color = new Color(c.r, c.g, c.b, alpha);
    }
}