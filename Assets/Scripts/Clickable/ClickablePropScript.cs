using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Props { Table, Chair, Picture}
public class ClickablePropScript : MonoBehaviour
{
    
    public Props imProp;
    [SerializeField]
    MeshRenderer meshRenderer;
    private List<Material> materials = new List<Material>();
    [SerializeField]
    private Texture2D texture2D;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = transform.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HighlightMe(Material outlinemat)
    {
        if (materials.Count < 2)
        {
            outlinemat.SetTexture("_texture2D", texture2D);
            meshRenderer.GetMaterials(materials);
            materials.Add(outlinemat);
            Material[] arrayOfMeshes = materials.ToArray();
            meshRenderer.materials = arrayOfMeshes;
        }
        else
        {
            materials.Remove(outlinemat);
            Material[] arrayOfMeshes = materials.ToArray();
            meshRenderer.materials = arrayOfMeshes;
        }
        
    }
}
