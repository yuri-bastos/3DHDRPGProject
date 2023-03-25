using UnityEngine;

public class SpriteBillboard : MonoBehaviour
{
    [SerializeField] bool freezeXZAxis = true;
    [SerializeField] bool shouldCastShadows = true;

    void Start()
    {
        if(shouldCastShadows)
        {
            GetComponent<SpriteRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        }
        else
        {
            GetComponent<SpriteRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        }
    }

    void LateUpdate()
    {
        float CameraY = Camera.main.transform.rotation.eulerAngles.y;
        if (freezeXZAxis)
        {
            transform.rotation = Quaternion.Euler(0f, CameraY, 0f);
        }
        else
        {
            transform.rotation = Camera.main.transform.rotation;
        }
        
    }
}
