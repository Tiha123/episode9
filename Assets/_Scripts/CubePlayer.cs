using UnityEngine;

public class CubePlayer : MonoBehaviour
{
    float vert, horz;
    Rigidbody rb;
    MeshRenderer mesh;
    Vector3 move;
    
    void Start()
    {
        if(TryGetComponent<Rigidbody>(out rb)==false)
        {
            Debug.Log("No RB");
        }

        if(TryGetComponent<MeshRenderer>(out mesh)==false)
        {
            Debug.Log("No MR");
        }
    }

    void Update()
    {
        vert=Input.GetAxis("Vertical");
        horz=Input.GetAxis("Horizontal");
        move=new Vector3(horz*5f,0f,vert*5f);
        rb.linearVelocity=move;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag!="Player")
        {
            return;
        }

        mesh.material.color=Color.blue;
    }

    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag!="Player")
        {
            return;
        }

        mesh.material.color=Color.white;
    }
}
