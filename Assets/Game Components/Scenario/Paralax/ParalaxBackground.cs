using UnityEngine;
using static Constants;

public class ParalaxBackground : MonoBehaviour
{
    [SerializeField] private Texture2D texture;
    [SerializeField] private float offsetXAmount;
    [SerializeField] private float offsetSpeed;

    [Header("Sorting layer")]
    
    [SerializeField] private string sortingLayerName;
    [SerializeField] private int sortingLayerOrder;

    private MeshRenderer meshRenderer;
    private Material mainMaterial;    
    private float offset = 1;
    private bool isMooving;
    
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        
        mainMaterial = meshRenderer.materials[0];
        meshRenderer.material.SetTexture(MAIN_TEXTURE, texture);
        offset = mainMaterial.GetTextureOffset(MAIN_TEXTURE).x;

        meshRenderer.sortingLayerName = sortingLayerName;
        meshRenderer.sortingOrder = sortingLayerOrder;

        isMooving = true;
        
    }


    private void FixedUpdate()
    {
        if (isMooving)
        {
            offset += offsetXAmount;
            mainMaterial.SetTextureOffset(MAIN_TEXTURE, new Vector2(offset * offsetSpeed, 0));
        }
    }

    public void Stop()
    {
        isMooving = false;
    }
}
