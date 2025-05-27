using UnityEngine;

public class Material_LoopMap : MonoBehaviour
{

    private MeshRenderer renderer;
    public float offsetSpeed = 0.1f;

  
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    
    void Update()
    {
        //변경된 offset값 
        Vector2 offset = Vector2.right * offsetSpeed * Time.deltaTime;

        //SetTextureoffset = texture의 offset을 적용/바꾸겠다 라는 함수, "_MainTex"는 BaseMap
        renderer.material.SetTextureOffset("_MainTex", renderer.material.mainTextureOffset + offset);

    }
}
