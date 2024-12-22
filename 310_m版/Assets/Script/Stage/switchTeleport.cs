//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class switchTeleport : MonoBehaviour
//{
//    [SerializeField] GameObject TeleportObj1;
//    [SerializeField] GameObject TeleportObj2;

//    GameObject TeleportObj;

   
//    GameObject BWObj; 
//    BWSwitch script;
//    bool bOldBWSwitch;

//    // Start is called before the first frame update
//    void Start()
//    {
//        BWObj = GameObject.Find("BWManager");
//        script = BWObj.GetComponent<BWSwitch>();

//        bOldBWSwitch = script.bBWSwich;

//        if (script.bBWSwich)
//        {
//            TeleportObj = TeleportObj1;
//        }
//        else
//        {
//            TeleportObj = TeleportObj2;
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (script.bBWSwich != bOldBWSwitch)
//        {
//            if (TeleportObj != TeleportObj1)
//            {
//                TeleportObj = TeleportObj1;
//            }
//            else if (TeleportObj != TeleportObj2)
//            {
//                TeleportObj = TeleportObj2;
//            }
//        }

//        bOldBWSwitch = script.bBWSwich;
//    }

//    void OnCollisionEnter(Collision collision)
//    {

//        if (collision.gameObject.tag == "Player")
//        {
//            GameObject objTeleport = collision.gameObject;

//            Vector3 TeleposVec;

//            if (objTeleport.transform.position.x - this.transform.position.x > 0)
//            {
//                // à íuí≤êÆ
//                TeleposVec = new Vector3(
//                    -1.0f,
//                    objTeleport.transform.position.y - this.transform.position.y,
//                    objTeleport.transform.position.z - this.transform.position.z);

//                Debug.Log("pri");
//            }
//            else
//            {
//                Debug.Log("voi");
//                // à íuí≤êÆ
//                TeleposVec = new Vector3(
//                    1.0f,
//                    objTeleport.transform.position.y - this.transform.position.y,
//                    objTeleport.transform.position.z - this.transform.position.z);
//            }


//            objTeleport.transform.position = new Vector3(
//                TeleportObj.transform.position.x + TeleposVec.x,
//                TeleportObj.transform.position.y + TeleposVec.y,
//                TeleportObj.transform.position.z + TeleposVec.z);



//        }

//    }




//}
