using UnityEngine;

//=======================================================
// spaceを押したらジャンプの条件式にCon_Jump追記
//=======================================================
public class TestJump : MonoBehaviour
{

    public Rigidbody rb;
    public float JumpPower;
    //接地判定
    public bool OnGround { get; set; }//追記

    PlayerMove PlayerMoveScript;

    //追記
    private void Start()
    {
        PlayerMoveScript = GetComponent<PlayerMove>();
        OnGround = false;
    }

    private void Update()
    {
        if (PlayerMoveScript.GetMoveFlg())
        {
            //接地していればジャンプできる
            if (Input.GetButtonDown("Jump") && OnGround || (Input.GetButtonDown("Con_Jump") && OnGround))//Con_Jump:コントローラーでのジャンプボタン追記
            {
                GameObject.Find("AudioController").GetComponent<GAudio>().JumpSEPlay();

                //rb.velocity = transform.up * JumpPower;
                rb.AddForce(Vector3.up * JumpPower);
                //ジャンプした瞬間接地判定を解除
                //OnGround = false;//追記
            }
        }


    }
    
    public void PlayerFall()
    {
        rb.AddForce(Vector3.down * 1);
        OnGround = false;//追記
        
    }
}