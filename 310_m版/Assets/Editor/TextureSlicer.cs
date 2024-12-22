using System.IO;
using UnityEngine;
using UnityEditor;

/// <summary>
/// �e�N�X�`�����c���ɐ؂��Čʂɕۑ�����
/// </summary>
public class TextureSlicer : EditorWindow
{
    Texture2D texture;
    int horizontalSlices;
    int verticalSlices;

    int partWidth;
    int partHeight;

    [MenuItem("Tools/TextureSlicer")]
    static void Open()
    {
        var window = EditorWindow.GetWindow<TextureSlicer>();
        window.Show();
    }

    /// <summary>
    ///  GUI�X�V
    /// </summary>
    void OnGUI()
    {
        EditorGUILayout.LabelField("Texture�𕪊����ʂɕۑ����܂��B");

        texture = EditorGUILayout.ObjectField("target Texture", texture, typeof(Texture2D), true) as Texture2D;
        
        horizontalSlices = EditorGUILayout.IntField("horizontalSlices", horizontalSlices);
        verticalSlices = EditorGUILayout.IntField("verticalSlices", verticalSlices);

        if (horizontalSlices == 0 || verticalSlices == 0)
        {
            return;
        }

        if (GUILayout.Button("Go Slice"))
        {
            var assetPath = AssetDatabase.GetAssetPath(texture);
            var dirPath = System.IO.Path.GetDirectoryName(assetPath);
            var fileNamePath = System.IO.Path.GetFileNameWithoutExtension(assetPath);

            partWidth = texture.width / horizontalSlices;
            partHeight = texture.height / verticalSlices;
            var fileNameIndex = 0;

            for (var partY = verticalSlices; partY > 0; partY--)
            {
                for (var partX = 0; partX < horizontalSlices; partX++)
                {
                    // �ۑ�
                    var savePath = string.Format("{0}\\{1}{2}.png", dirPath, fileNamePath, fileNameIndex);

                    // ���������ꖇ���̃s�N�Z���擾
                    var partPixels = ReadPartPixels(partX, partY, texture);

                    // �`������
                    var partTexture = new Texture2D(partWidth, partHeight, TextureFormat.RGBA32, false);
                    partTexture.SetPixels(partPixels);
                    partTexture.Apply();

                    SaveBinaryToLocal(savePath, partTexture.EncodeToPNG());
                    AssetDatabase.ImportAsset(savePath);
                    AssetDatabase.SaveAssets();

                    fileNameIndex++;
                }
            }
        }
    }

    Color[] ReadPartPixels(int partX, int partY, Texture2D texture)
    {
        var pixels = new Color[partWidth * partHeight];
        var offsetX = partX * partWidth;
        var offsetY = partY * partHeight;

        for (int y = offsetY, y_ = partHeight - 1; y > offsetY - partHeight; y--, y_--)
        {
            for (int x = offsetX, x_ = 0; x < offsetX + partWidth; x++, x_++)
            {
                pixels[y_ * partWidth + x_] = texture.GetPixel(x, y);
            }
        }

        return pixels;
    }

    void SaveBinaryToLocal(string path, byte[] binaryData)
    {
        var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
        var binaryWriter = new BinaryWriter(fileStream);

        binaryWriter.Write(binaryData);

        binaryWriter.Close();
        fileStream.Close();
    }
}