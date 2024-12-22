using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wireframe : MonoBehaviour
{
   

    private void OnValidate()
    {

        //MeshFilter meshFilter = GetComponent<MeshFilter>();
        //meshFilter.mesh.SetIndices(meshFilter.mesh.GetIndices(0), MeshTopology.Lines, 0);

    }


    // Start is called before the first frame update
    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh.SetIndices(meshFilter.mesh.GetIndices(0), MeshTopology.Lines, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
