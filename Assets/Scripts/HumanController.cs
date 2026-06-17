using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;

public class HumanController : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;

    public float fearRadius = 5f;
    public float humanSpeed = 5f;
    public Transform playerTransform;


    void FixedUpdate()
    {
        // Human fear mechanic
        float distance = Vector2.Distance(playerTransform.position, this.transform.position);
        if (distance < fearRadius)
        {
            rb.linearVelocity = (this.transform.position - playerTransform.position).normalized * humanSpeed;
            Debug.Log(distance);
        }
        else rb.linearVelocity = new Vector2(0f,0f);     
        

    }
}
