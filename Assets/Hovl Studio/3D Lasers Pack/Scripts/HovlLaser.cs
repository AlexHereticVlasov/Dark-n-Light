using UnityEngine;

public class HovlLaser : MonoBehaviour
{
    private const string MainTexture = "_MainTex";
    private const string Noise = "_Noise";
    private const string ReflectionTag = "Mirror";

    private readonly float _maxLength = 100;

    [SerializeField] private LayerMask _mask;
    public GameObject HitEffect;
    public float HitOffset = 0;
    public bool useLaserRotation = false;

    private LineRenderer _line;

    public float MainTextureLength = 1f;
    public float NoiseTextureLength = 1f;
    private Vector4 _length = new Vector4(1, 1, 1, 1);

    private bool _laserSaver = false;
    private bool _updateSaver = false;

    private ParticleSystem[] _effects;
    private ParticleSystem[] _hit;

    [SerializeField] private GameObject _hitedObject;

    private void Start()
    {
        _line = GetComponent<LineRenderer>();
        _effects = GetComponentsInChildren<ParticleSystem>();
        _hit = HitEffect.GetComponentsInChildren<ParticleSystem>();
        _line.SetPosition(0, transform.position);
    }

    private void Update()
    {
        _line.material.SetTextureScale(MainTexture, new Vector2(_length[0], _length[1]));
        _line.material.SetTextureScale(Noise, new Vector2(_length[2], _length[3]));
        
        int pointsAmount = 1;
        var ray = new Ray2D(transform.position, transform.forward);
        _line.SetPosition(0, transform.position);
        BuildRay(ray, gameObject, ref pointsAmount);
        _line.positionCount = pointsAmount + 1;

        //    //Insurance against the appearance of a laser in the center of coordinates!
        if (_line.enabled == false && _laserSaver == false)
        {
            _laserSaver = true;
            _line.enabled = true;
        }
        //}
    }

    private void BuildRay(Ray2D ray2D, GameObject @this, ref int index)
    {
        var hits = Physics2D.RaycastAll(ray2D.origin, ray2D.direction, _maxLength, _mask);

        foreach (var hit in hits)
        {
            if (hit.transform.gameObject == @this) continue;

            _line.SetPosition(index, hit.point);
            if (hit.transform.CompareTag(ReflectionTag))
            {
                Vector2 reflection = Vector2.Reflect(ray2D.direction, hit.normal);
                index++;
                _line.positionCount = index + 1;
                var ray = new Ray2D(hit.point, reflection);
                BuildRay(ray, hit.transform.gameObject, ref index);
            }
            //ToDo: Portal case
            else
            {
                if (hit)
                    EndOnCollision(hit, index);
                else
                    EndInInfinity(index);
            }
            return;
        }
    }

    private void EndInInfinity(int index)
    {
        var endPos = transform.position + transform.forward * _maxLength;
        _line.SetPosition(index, endPos);
        HitEffect.transform.position = endPos;
        foreach (var effect in _hit)
            if (effect.isPlaying) effect.Stop();

        TextureTiling(endPos);
    }

    private void EndOnCollision(RaycastHit2D hit, int index)
    {
        _line.SetPosition(index, hit.point);

        HitEffect.transform.position = hit.point + hit.normal * HitOffset;
        if (useLaserRotation)
            HitEffect.transform.rotation = transform.rotation;
        else
            HitEffect.transform.LookAt(hit.point + hit.normal);

        foreach (var effect in _effects)
            if (effect.isPlaying == false)
                effect.Play();

        TextureTiling(hit.point);

        if (_hitedObject != hit.transform.gameObject)
        {
            DeactivatePrevious();
            _hitedObject = hit.transform.gameObject;
            ActivateNew();
        }
    }

    private void DeactivatePrevious()
    {
        if (_hitedObject != null && _hitedObject.TryGetComponent(out RayHost previous))
            previous.Deactivate();
    }

    private void ActivateNew()
    {
        if (_hitedObject.TryGetComponent(out RayHost host))
            host.Activate();
    }

    private void TextureTiling(Vector2 endPos)
    {
        _length[0] = MainTextureLength * (Vector2.Distance(transform.position, endPos));
        _length[2] = NoiseTextureLength * (Vector2.Distance(transform.position, endPos));
    }

    public void DisablePrepare()
    {
        if (_line != null)
            _line.enabled = false;
        
        _updateSaver = true;
        //Effects can = null in multiply shooting
        if (_effects != null)
        {
            foreach (var effect in _effects)
                if (effect.isPlaying) effect.Stop();
        }
    }
}

#region Legacy
/*
 using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System;
using UnityEngine;

public class Hovl_Laser : MonoBehaviour
{
    public int damageOverTime = 30;

    public GameObject HitEffect;
    public float HitOffset = 0;
    public bool useLaserRotation = false;

    public float MaxLength;
    private LineRenderer Laser;

    public float MainTextureLength = 1f;
    public float NoiseTextureLength = 1f;
    private Vector4 Length = new Vector4(1,1,1,1);
    //private Vector4 LaserSpeed = new Vector4(0, 0, 0, 0); {DISABLED AFTER UPDATE}
    //private Vector4 LaserStartSpeed; {DISABLED AFTER UPDATE}
    //One activation per shoot
    private bool LaserSaver = false;
    private bool UpdateSaver = false;

    private ParticleSystem[] Effects;
    private ParticleSystem[] Hit;

    void Start ()
    {
        //Get LineRender and ParticleSystem components from current prefab;  
        Laser = GetComponent<LineRenderer>();
        Effects = GetComponentsInChildren<ParticleSystem>();
        Hit = HitEffect.GetComponentsInChildren<ParticleSystem>();
        //if (Laser.material.HasProperty("_SpeedMainTexUVNoiseZW")) LaserStartSpeed = Laser.material.GetVector("_SpeedMainTexUVNoiseZW");
        //Save [1] and [3] textures speed
        //{ DISABLED AFTER UPDATE}
        //LaserSpeed = LaserStartSpeed;
    }

    void Update()
    {
        //if (Laser.material.HasProperty("_SpeedMainTexUVNoiseZW")) Laser.material.SetVector("_SpeedMainTexUVNoiseZW", LaserSpeed);
        //SetVector("_TilingMainTexUVNoiseZW", Length); - old code, _TilingMainTexUVNoiseZW no more exist
        Laser.material.SetTextureScale("_MainTex", new Vector2(Length[0], Length[1]));                    
        Laser.material.SetTextureScale("_Noise", new Vector2(Length[2], Length[3]));
        //To set LineRender position
        if (Laser != null && UpdateSaver == false)
        {
            Laser.SetPosition(0, transform.position);
            //RaycastHit hit; //DELETE THIS IF YOU WANT USE LASERS IN 2D
            //ADD THIS IF YOU WANNT TO USE LASERS IN 2D:
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, MaxLength);       
            //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, MaxLength))//CHANGE THIS IF YOU WANT TO USE LASERRS IN 2D:
            if (hit.collider != null)
            {
                //End laser position if collides with object
                Laser.SetPosition(1, hit.point);

                    HitEffect.transform.position = hit.point + hit.normal * HitOffset;
                if (useLaserRotation)
                    HitEffect.transform.rotation = transform.rotation;
                else
                    HitEffect.transform.LookAt(hit.point + hit.normal);

                foreach (var AllPs in Effects)
                {
                    if (!AllPs.isPlaying) AllPs.Play();
                }
                //Texture tiling
                Length[0] = MainTextureLength * (Vector3.Distance(transform.position, hit.point));
                Length[2] = NoiseTextureLength * (Vector3.Distance(transform.position, hit.point));
                //Texture speed balancer {DISABLED AFTER UPDATE}
                //LaserSpeed[0] = (LaserStartSpeed[0] * 4) / (Vector3.Distance(transform.position, hit.point));
                //LaserSpeed[2] = (LaserStartSpeed[2] * 4) / (Vector3.Distance(transform.position, hit.point));
                //Destroy(hit.transform.gameObject); // destroy the object hit
                //hit.collider.SendMessage("SomeMethod"); // example
                /*if (hit.collider.tag == "Enemy")
                {
                    hit.collider.GetComponent<HittedObject>().TakeDamage(damageOverTime * Time.deltaTime);
                }
            }
            else
{
    //End laser position if doesn't collide with object
    var EndPos = transform.position + transform.forward * MaxLength;
    Laser.SetPosition(1, EndPos);
    HitEffect.transform.position = EndPos;
    foreach (var AllPs in Hit)
    {
        if (AllPs.isPlaying) AllPs.Stop();
    }
    //Texture tiling
    Length[0] = MainTextureLength * (Vector3.Distance(transform.position, EndPos));
    Length[2] = NoiseTextureLength * (Vector3.Distance(transform.position, EndPos));
    //LaserSpeed[0] = (LaserStartSpeed[0] * 4) / (Vector3.Distance(transform.position, EndPos)); {DISABLED AFTER UPDATE}
    //LaserSpeed[2] = (LaserStartSpeed[2] * 4) / (Vector3.Distance(transform.position, EndPos)); {DISABLED AFTER UPDATE}
}
//Insurance against the appearance of a laser in the center of coordinates!
if (Laser.enabled == false && LaserSaver == false)
{
    LaserSaver = true;
    Laser.enabled = true;
}
        }  
    }

    public void DisablePrepare()
{
    if (Laser != null)
    {
        Laser.enabled = false;
    }
    UpdateSaver = true;
    //Effects can = null in multiply shooting
    if (Effects != null)
    {
        foreach (var AllPs in Effects)
        {
            if (AllPs.isPlaying) AllPs.Stop();
        }
    }
}
}
*/
#endregion
