using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisCharge_Generate_Effect : MonoBehaviour
{
    [SerializeField] public GameObject particleObject;

    GameObject Particle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Generate_Effect()
    {
        Particle = Instantiate(particleObject, this.transform.position, Quaternion.identity); //�p�[�e�B�N���p�Q�[���I�u�W�F�N�g����
        Particle.transform.parent = transform;
    }
}
