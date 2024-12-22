using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearMoe : MonoBehaviour
{
    //private Transform obj;
    private Transform Cameraobj;
    private int Speed = 2;
    private bool Clear = false;

    //[SerializeField]
    private GameObject PlayerObj;

    //[SerializeField]
    private int ForwardDistance;

    Vector3 CameraForward;

    Vector3 VecCtoP;

    // Start is called before the first frame update
    void Start()
    {
        ForwardDistance = 7;
        PlayerObj = GameObject.FindGameObjectWithTag("Player");
        //obj = GameObject.Find("Position").transform;
        
        //Cameraobj = GameObject.Find("Main Camera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 objPosition = obj.position;

        if (ClearShow.DanChu == true)
        {
            if (!Clear)
            {
                Clear = true;

                CameraForward = new Vector3(transform.forward.x, transform.forward.y, transform.forward.z);

                VecCtoP = new Vector3(
                    PlayerObj.transform.position.x - transform.position.x,
                    PlayerObj.transform.position.y - transform.position.y,
                    PlayerObj.transform.position.z - transform.position.z
                    );
                VecCtoP.Normalize();

                VecCtoP = VecCtoP * ForwardDistance;
            }
        }
        if (Clear == true)
        {

            if (Vector3.Distance(transform.position, PlayerObj.transform.position) > ForwardDistance)
            {
                float step = Speed * Time.unscaledDeltaTime;
                //gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, objPosition, step);
                transform.position = Vector3.MoveTowards(transform.position, transform.position + VecCtoP, step);
            }
        }




    }

 
}
