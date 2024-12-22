using UnityEngine;

//=======================================================
// space����������W�����v�̏�������Con_Jump�ǋL
//=======================================================
public class TestJump : MonoBehaviour
{

    public Rigidbody rb;
    public float JumpPower;
    //�ڒn����
    public bool OnGround { get; set; }//�ǋL

    PlayerMove PlayerMoveScript;

    //�ǋL
    private void Start()
    {
        PlayerMoveScript = GetComponent<PlayerMove>();
        OnGround = false;
    }

    private void Update()
    {
        if (PlayerMoveScript.GetMoveFlg())
        {
            //�ڒn���Ă���΃W�����v�ł���
            if (Input.GetButtonDown("Jump") && OnGround || (Input.GetButtonDown("Con_Jump") && OnGround))//Con_Jump:�R���g���[���[�ł̃W�����v�{�^���ǋL
            {
                GameObject.Find("AudioController").GetComponent<GAudio>().JumpSEPlay();

                //rb.velocity = transform.up * JumpPower;
                rb.AddForce(Vector3.up * JumpPower);
                //�W�����v�����u�Ԑڒn���������
                //OnGround = false;//�ǋL
            }
        }


    }
    
    public void PlayerFall()
    {
        rb.AddForce(Vector3.down * 1);
        OnGround = false;//�ǋL
        
    }
}