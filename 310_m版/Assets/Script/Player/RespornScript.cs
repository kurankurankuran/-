using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespornScript : MonoBehaviour
{
    //[Header("Player")]
    //[SerializeField]
    private GameObject PlayerObj;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
   
    }

    public void Resporn()
    {
        // リスポーン地点までの角度を計算
        float angle = Vector3.SignedAngle(
            new Vector3(PlayerObj.transform.position.x, 0.0f, PlayerObj.transform.position.z),
            new Vector3(transform.position.x, 0.0f, transform.position.z),
            new Vector3(0.0f, 1.0f, 0.0f)
            );

        PlayerObj.transform.position = new Vector3(PlayerObj.transform.position.x, transform.position.y, PlayerObj.transform.position.z);
        transform.root.gameObject.transform.RotateAround(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f), -angle);


    }
}
