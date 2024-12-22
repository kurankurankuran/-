using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderFloor : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    //void OnCollisionEnter(Collision col)
    //{
    //    if (col.transform.tag == "Foot")
    //    {

    //        foreach (ContactPoint point in col.contacts)
    //        {
    //            Vector3 relativePoint = transform.InverseTransformPoint(point.point);

               
    //            if (relativePoint.x > 0.2)
    //            {
    //                this.transform.GetComponent<Collider>().isTrigger = true;
    //            }

    //            else if (relativePoint.x < -0.2)
    //            {
    //                this.transform.GetComponent<Collider>().isTrigger = true;
    //            }

    //            if (relativePoint.y > 0.1)
    //            {
    //                Debug.Log(relativePoint.y);
    //                this.transform.GetComponent<Collider>().isTrigger = false;
    //            }


    //        }
    //    }

    //}

       
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Foot")
        {
           
            //foreach (ContactPoint point in other.GetComponent<Collision>().contacts)
            //{
            Vector3 hitPos = transform.InverseTransformPoint(other.ClosestPointOnBounds(this.transform.position));
            //Vector3 relativePoint = transform.InverseTransformPoint(point.point);


            //if (relativePoint.x > 0.2)
            //{
            //    this.transform.GetComponent<Collider>().isTrigger = true;
            //}

            //else if (relativePoint.x < -0.2)
            //{
            //    this.transform.GetComponent<Collider>().isTrigger = true;
            //}

            if (hitPos.y > -0.5)
            {
                Debug.Log(other.name);
                this.transform.GetComponent<Collider>().isTrigger = false;
            }


            //}
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        
        if (collision.transform.tag == "Player")
        {
            Debug.Log(collision.transform.name);
            this.transform.GetComponent<Collider>().isTrigger = true;
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        this.transform.GetComponent<Collider>().isTrigger = true;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")  
    //    {
    //        this.transform.GetComponent<Collider>().isTrigger = false;
    //    }
    //}


}
