//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class RoopCube : MonoBehaviour
//{
//    [SerializeField]
//    private GameObject TeleportObj;
    

   

//    // Start is called before the first frame update
//    void Start()
//    {
       
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.gameObject.tag == "Player")
//        {
//            GameObject objTeleport = other.gameObject;

//            Vector3 TeleposVec;

//            if (objTeleport.transform.position.y - this.transform.position.y > 0)
//            {
//                // à íuí≤êÆ
//                TeleposVec = new Vector3(
//                    objTeleport.transform.position.x - this.transform.position.x,
//                    -1.0f,
//                    objTeleport.transform.position.z - this.transform.position.z);

//                Debug.Log("pri");
//            }
//            else
//            {
//                Debug.Log("voi");
//                // à íuí≤êÆ
//                TeleposVec = new Vector3(
//                    objTeleport.transform.position.x - this.transform.position.x,
//                    1.0f,
//                    objTeleport.transform.position.z - this.transform.position.z);
//            }


//            objTeleport.transform.position = new Vector3(
//                TeleportObj.transform.position.x + TeleposVec.x,
//                TeleportObj.transform.position.y + TeleposVec.y,
//                TeleportObj.transform.position.z + TeleposVec.z);



//        }
//    }
    




//}
