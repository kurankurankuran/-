using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge_generated_effect : MonoBehaviour
{
    [SerializeField]
    public GameObject particleObject;

    //Soul mySoul;

    // Start is called before the first frame update
    void Start()
    {
        //mySoul = GetComponent<Soul>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayEffect()
    {

        GameObject Particle = Instantiate(particleObject, this.transform.position, Quaternion.identity); //�p�[�e�B�N���p�Q�[���I�u�W�F�N�g����
        Particle.transform.parent = transform;

    }


}
