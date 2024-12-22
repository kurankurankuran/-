using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
public class FovModifier : MonoBehaviour
{
    [SerializeField, Range(0.0001f, 179.0f)] private float verticalFov;
    [SerializeField, Range(0.0001f, 179.0f)] private float horizontalFov;

    private new Camera camera;
    private float currentVerticalFov;
    private float currentHorizontalFov;
    public float Aspect { get; private set; }

    public void ResetHorizontalFov()
    {
        this.camera.ResetAspect();
        this.GetCameraFov();
        this.UpdateFov();
       
    }

    public void GetCameraFov()
    {
        this.verticalFov = this.camera.fieldOfView;
        this.horizontalFov = Mathf.Atan(Mathf.Tan(this.verticalFov * 0.5f * Mathf.Deg2Rad) * this.camera.aspect) *
                             2.0f * Mathf.Rad2Deg;
    }

    private void UpdateFov()
    {
        if ((this.currentVerticalFov != this.verticalFov) || (this.currentHorizontalFov != this.horizontalFov))
        {
            //Debug.Log("CameraUpdate");
            this.Aspect = Mathf.Tan(this.horizontalFov * 0.5f * Mathf.Deg2Rad) /
                          Mathf.Tan(this.verticalFov * 0.5f * Mathf.Deg2Rad);
            this.camera.fieldOfView = this.verticalFov;
            this.camera.aspect = this.Aspect;
            this.currentHorizontalFov = this.horizontalFov;
            this.currentVerticalFov = this.verticalFov;
        }
    }

    private void OnEnable()
    {
        this.camera = this.GetComponent<Camera>();
        this.GetCameraFov();
        this.UpdateFov();
    }

    private void Update()
    {
       
        this.UpdateFov();
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(FovModifier))]
public class FovModifierEditor : Editor
{
    private FovModifier fovModifier;

    /// <inheritdoc />
    public override void OnInspectorGUI()
    {
        this.fovModifier.GetCameraFov();
        base.OnInspectorGUI();
        if (GUILayout.Button("Reset Horizontal Fov"))
        {
            
            
            this.fovModifier.ResetHorizontalFov();
            this.serializedObject.ApplyModifiedProperties();
        }

        EditorGUILayout.LabelField("Aspect", this.fovModifier.Aspect.ToString("F4"));
    }

    private void OnEnable()
    {
        this.fovModifier = this.target as FovModifier;
    }
}
#endif
