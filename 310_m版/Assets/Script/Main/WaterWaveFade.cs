
using UnityEngine;
using UnityEngine.SceneManagement;
public class WaterWaveFade : SimplePostEffectsBase {


    [Header("距離")]
    [Range(0f, 30.0f)]
    public  float DistanceFactor = 20.0f;
   
    [Header("時間")]
    [Range(-30f, 30.0f)]
    public  float TimeFactor = -21.5f;

    [Header("sin関数結果")]
    [Range(0f, 30.0f)]
    public  float TotalFactor = 20.5f;

    [Header("波紋幅：ファントムブラッド")]
    [Range(0f, 1f)]
    public  float WaveWidth = 0.529f;

    [Header("波紋拡散速度：オーバードライブ")]
    [Range(0f, 2f)]
    public  float WaveSpeed = 1.55f;
   


    public static bool Onoff = false;

    private int index;

    private static float waveStartTime;
    private static Vector4 startPos = new Vector4(0.5f, 0.5f, 0, 0);
    public static AsyncOperation async;

    void OnRenderImage (RenderTexture source, RenderTexture destination)
    {
        float curWaveDistance = (Time.time - waveStartTime) * WaveSpeed;
        

        _Material.SetFloat("_distanceFactor", DistanceFactor);
        _Material.SetFloat("_timeFactor", TimeFactor);
        _Material.SetFloat("_totalFactor", TotalFactor);
        _Material.SetFloat("_waveWidth", WaveWidth);
        _Material.SetFloat("_curWaveDis", curWaveDistance);
        _Material.SetVector("_startPos", startPos);
		Graphics.Blit (source, destination, _Material);
	}

    void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1;
    }



    void Update()
    {
       
        if (Onoff == true) 
        {
            
            startPos = new Vector4(0.5f, 0.5f, 0, 0);
            waveStartTime = Time.time;
            Onoff = false;

        }

        if (index == 0 || index == 1)
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 mousePos = Input.mousePosition;
                startPos = new Vector4(mousePos.x / Screen.width, mousePos.y / Screen.height, 0, 0);
                waveStartTime = Time.time;
            }
        }

        
    }



}