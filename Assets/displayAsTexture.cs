using UnityEngine;

public class displayAsTexture : MonoBehaviour
{
    public uDesktopDuplication.Texture uDDTex;
    [SerializeField] bool forceInvertY = false;
    // Start is called before the first frame update
    void Start()
    {
        if (forceInvertY)
        {
            forceInvertY_ = true;
        }
    }
    public bool forceInvertY_
    {
        get
        {
            return uDDTex.invertY;
        }
        set
        {
            uDDTex.invertY = value;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
