using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBox : MonoBehaviour
{
    //public enum TYPE
    //{
    //    NONE_TYPE = 0,
    //    SPEED_TYPE,
    //    JUMP_TYPE,

    //    MAX_TYPE
    //}

    [SerializeField]
    private AbilityType.TYPE TypeNum_1 = AbilityType.TYPE.SPEED_TYPE;

    [SerializeField]
    private AbilityType.TYPE TypeNum_2 = AbilityType.TYPE.JUMP_TYPE;

    private AbilityType.TYPE PlusType_Num;

    // Start is called before the first frame update
    void Start()
    {
        PlusType_Num = TypeNum_1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(other.GetComponent<AbilityType>().bAbility)
            {
                other.GetComponent<AbilityType>().TypeNum = PlusType_Num;
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Gage")
        {
            if (PlusType_Num == TypeNum_1)
            {
                PlusType_Num = TypeNum_2;
            }
            else if (PlusType_Num == TypeNum_2)
            {
                PlusType_Num = TypeNum_1;
            }
        }
    }
}
