using NaughtyAttributes;
using System;
using UnityEngine;

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
        meshRenderer.material.SetTexture("_MainTex", texture);
        offset = mainMaterial.GetTextureOffset("_MainTex").x;

        meshRenderer.sortingLayerName = sortingLayerName;
        meshRenderer.sortingOrder = sortingLayerOrder;

        isMooving = true;
    }


    private void FixedUpdate()
    {
        if (isMooving)
        {
            offset += offsetXAmount;
            mainMaterial.SetTextureOffset("_MainTex", new Vector2(offset * offsetSpeed, 0));
        }
    }

    public void Stop()
    {
        isMooving = false;
    }
}
