using UnityEngine;
using UnityEngine.Rendering;

[ExecuteInEditMode]
public class NoiseBall3 : MonoBehaviour
{
    #region Editable attributes

    [SerializeField] int _triangleCount = 100;

    public int triangleCount {
        get { return _triangleCount; }
        set { _triangleCount = value; }
    }

    [SerializeField] float _triangleExtent = 0.1f;

    public float triangleExtent {
        get { return _triangleExtent; }
        set { _triangleExtent = value; }
    }

    [SerializeField] float _shuffleSpeed = 4;

    public float shuffleSpeed {
        get { return _shuffleSpeed; }
        set { _shuffleSpeed = value; }
    }

    [SerializeField] float _noiseAmplitude = 1;

    public float noiseAmplitude {
        get { return _noiseAmplitude; }
        set { _noiseAmplitude = value; }
    }

    [SerializeField] float _noiseFrequency = 1;

    public float noiseFrequency {
        get { return _noiseFrequency; }
        set { _noiseFrequency = value; }
    }

    [SerializeField] Vector3 _noiseMotion = Vector3.up;

    public Vector3 noiseMotion {
        get { return _noiseMotion; }
        set { _noiseMotion = value; }
    }

    [SerializeField] Color _color = Color.white;

    public Color color {
        get { return _color; }
        set { _color = value; }
    }

    [SerializeField, Range(0, 1)] float _metallic = 0.5f;

    public float metallic {
        get { return _metallic; }
        set { _metallic = value; }
    }

    [SerializeField, Range(0, 1)] float _smoothness = 0.5f;

    public float smoothness {
        get { return _smoothness; }
        set { _smoothness = value; }
    }

    [SerializeField, ColorUsage(false, true)]
    Color _emissionColor = Color.white;

    public Color emissionColor {
        get { return _emissionColor; }
        set { _emissionColor = value; }
    }

    #endregion

    #region Hidden attribute

    [SerializeField, HideInInspector] Shader _shader = null;

    #endregion

    #region Private variables

    Material _material;

    #endregion

    #region MonoBehaviour functions

    void OnValidate()
    {
        _triangleCount = Mathf.Max(0, _triangleCount);
        _triangleExtent = Mathf.Max(0, _triangleExtent);
        _noiseFrequency = Mathf.Max(0, _noiseFrequency);
    }

    void OnDestroy()
    {
        if (_material != null)
        {
            if (Application.isPlaying)
                Destroy(_material);
            else
                DestroyImmediate(_material);
        }
    }

    void Update()
    {
        if (_material == null)
        {
            _material = new Material(_shader);
            _material.hideFlags = HideFlags.DontSave;
        }

        var time = Application.isPlaying ? Time.time : 3.3333f;

        _material.SetColor("_Color", _color);
        _material.SetFloat("_Metallic", _metallic);
        _material.SetFloat("_Smoothness", _smoothness);
        _material.SetColor("_Emission", _emissionColor);

        _material.SetInt("_TriangleCount", _triangleCount);
        _material.SetFloat("_LocalTime", time * _shuffleSpeed);
        _material.SetFloat("_Extent", _triangleExtent);
        _material.SetFloat("_NoiseAmplitude", _noiseAmplitude);
        _material.SetFloat("_NoiseFrequency", _noiseFrequency);
        _material.SetVector("_NoiseOffset", _noiseMotion * time);

        _material.SetMatrix("_LocalToWorld", transform.localToWorldMatrix);
        _material.SetMatrix("_WorldToLocal", transform.worldToLocalMatrix);

        Graphics.DrawProcedural(
            _material,
            new Bounds(transform.position, transform.lossyScale * 5),
            MeshTopology.Triangles, _triangleCount * 3, 1,
            null, null,
            ShadowCastingMode.TwoSided, true, gameObject.layer
        );
    }

    #endregion
}
