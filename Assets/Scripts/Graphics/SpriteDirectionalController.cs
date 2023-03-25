using UnityEngine;

public class SpriteDirectionalController : MonoBehaviour
{
    [SerializeField] Transform mainTransform;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;


    private void LateUpdate()
    {
        Vector3 camForwardVector = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z);
        Debug.DrawRay(Camera.main.transform.position, camForwardVector * 5f, Color.magenta);

        float signedAngle = Vector3.SignedAngle(mainTransform.forward, camForwardVector, Vector3.up);

        Vector2 animationDirection = new Vector2(0f, 1f);

        float angle = signedAngle + 180f;

        /*
            FRONT =  angle <= 22.5 || angle > 337.5
            FRONT-RIGHT =  22.5 < angle <= 67.5
            RIGHT = 67.5 < angle <= 112.5
            BACK-RIGHT = 112.5 < angle <= 157.5
            BACK = 157.5 < angle <= 202.5
            BACK-LEFT = 202.5 < angle <= 247.5
            LEFT = 247.5 < angle <= 292.5
            FRONT-LEFT = 292.5 < angle <= 337.5
        */

        if (angle <= 23f || angle > 338f)
        {
            //Back Animation
            animationDirection = new Vector2(0f, -1f);
        }
        else if(angle > 23f && angle <= 68f)
        {
            //Back-Right Animation
            animationDirection = new Vector2(-0.5f, -0.5f);
        }
        else if (angle > 68f && angle <= 113f)
        {
            //Right Animation
            animationDirection = new Vector2(1f, 0f);
        }
        else if (angle > 113f && angle <= 158f)
        {

            //Front-Right Animation
            animationDirection = new Vector2(0.5f, 0.5f);
        }
        else if (angle > 158f && angle <= 203f)
        {
            //Front Animation
            animationDirection = new Vector2(0f, 1f);
        }
        else if (angle > 203f && angle <= 248f)
        {
            //Front-Left Animation
            animationDirection = new Vector2(-0.5f, 0.5f);
        }
        else if (angle > 248f && angle <= 293f)
        {
            //Left Animation
            animationDirection = new Vector2(-1f, 0f);
        }
        else
        {
            //Back-Left Animation
            animationDirection = new Vector2(0.5f, -0.5f);
        }

        animator.SetFloat("moveX", animationDirection.x);
        animator.SetFloat("moveY", animationDirection.y);
        //Debug.Log("Angle = ");
        //Debug.Log(angle);
    }
}
