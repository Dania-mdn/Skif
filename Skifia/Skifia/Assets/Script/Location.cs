using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Location : MonoBehaviour
{
    private float x;
    private float y;
    [SerializeField] private bool _isHorizontal;
    public Transform[] StartPosition;
    private Vector2 _direction;
    private RaycastHit2D _hit;
    private float[] _distanceValue;
    private bool _isConnect = false;
    public Color Color;
    public SpriteRenderer _spriteRenderer;
    private Vector2 PozitionZero;
    private bool isBlak = false;
    public ParticleSystem particle;
    private void OnEnable()
    {
        EventManager.Delete += Delete;
        EventManager.changeColor += ChacgeColor;
        EventManager.changeColorBlack += ChacgeColorBlack;
    }
    private void OnDisable()
    {
        EventManager.Delete -= Delete;
        EventManager.changeColor -= ChacgeColor;
        EventManager.changeColorBlack -= ChacgeColorBlack;
    }
    private void Start()
    {
        PozitionZero.y = PlayerPrefs.GetFloat("PozitionZero");
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (PlayerPrefs.HasKey("Color"))
        {
            SetColor(color: Color.black);
            isBlak = true;
        }
        else
        {
            SetColor(Color);
        }
        _distanceValue = new float[StartPosition.Length];
        if (!_isHorizontal)
        {
            _direction = new Vector2(-1, -1);
            transform.position = new Vector3(transform.position.x, transform.position.y + PozitionZero.y + 0.08f / 2, transform.position.z);
        }
        else
        {
            _direction = Vector2.down;
        }
    }
    private void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }
    private void ChacgeColor(Color colorHorizotal, Color colorDiagonal)
    {
        if (isBlak == false)
        {
            if (_spriteRenderer.color == colorHorizotal)
            {
                SetColor(colorDiagonal);
            }
            else if (_spriteRenderer.color == colorDiagonal)
            {
                SetColor(colorHorizotal);
            }
        }
        else
        {
            SetColor(Color); 
            isBlak = false;
        }
        PlayerPrefs.DeleteKey("Color");
    }
    public void ChacgeColorBlack(Color colorBlack)
    {
        SetColor(colorBlack);
        isBlak = true; 
        PlayerPrefs.SetInt("Color", 1);
    }
    private void FixedUpdate()
    {
        if (_isConnect) return;

        for(int i = 0; i < StartPosition.Length; i++)
        {
            _hit = Physics2D.Raycast(StartPosition[i].position, _direction);
            if (_hit.collider != null)
            {
                _distanceValue[i] = Vector2.Distance(_hit.point, StartPosition[i].position);
                if (_distanceValue[i] < 0.002f)
                {
                    startCorutine();
                    Vector3 position1;
                    Vector3 position2;
                    Vector3 position3;
                    if (_isHorizontal)
                    {
                        if (_hit.collider.tag == "Respawn")
                        {
                            PozitionZero = new Vector2(0, transform.position.y - StartPosition[i].position.x);
                            PlayerPrefs.SetFloat("PozitionZero", PozitionZero.y);
                        }
                        position1 = new Vector3((PozitionZero.x + (StartPosition[i].position.y - PozitionZero.y) - 0.08f / 2) - (StartPosition[i].position.y - transform.position.y), PozitionZero.y + 0.08f / 2, transform.position.z);
                        Inastatiate(position1, -90);
                        position2 = new Vector3(PozitionZero.x, (PozitionZero.y - (StartPosition[i].position.y - PozitionZero.y) + 0.08f) + (StartPosition[i].position.y - transform.position.y), transform.position.z);
                        Inastatiate(position2, -180);
                        position3 = new Vector3((PozitionZero.x - (StartPosition[i].position.y - PozitionZero.y) + 0.08f / 2) + (StartPosition[i].position.y - transform.position.y), PozitionZero.y + 0.08f / 2, transform.position.z);
                        Inastatiate(position3, -270);
                    }
                    else
                    {
                        position1 = new Vector3(transform.position.x, ((PozitionZero.y - StartPosition[i].position.y) + 0.08f / 2) + (StartPosition[i].position.y - transform.position.y), transform.position.z);
                        Inastatiate(position1, -90);
                        position2 = new Vector3(-transform.position.x, ((PozitionZero.y - StartPosition[i].position.y) + 0.08f / 2) + (StartPosition[i].position.y - transform.position.y), transform.position.z);
                        Inastatiate(position2, -180);
                        position3 = new Vector3(-transform.position.x, ((StartPosition[i].position.y - PozitionZero.y) - 0.08f / 2) - (StartPosition[i].position.y - transform.position.y), transform.position.z);
                        Inastatiate(position3, -270);
                    }
                    Invoke("DoCreate", 0.6f);
                    _isConnect = true;
                    break;
                }
            }
        }
        if (!_isHorizontal)
        {
            x = (Mathf.Sqrt((_distanceValue.Min() * _distanceValue.Min()))) / 2;
            y = x;
        }
        else
        {
            y = _distanceValue.Min();
        }
        transform.position = new Vector3(transform.position.x - x, transform.position.y - y, transform.position.z);
    }
    private void DoCreate()
    {
        EventManager.DoCreate();
    }
    private void Inastatiate(Vector3 position, int rotate)
    {
        var horizontalObject1 = Instantiate(gameObject, position, Quaternion.Euler(0, 0, rotate), transform.parent);
        horizontalObject1.GetComponent<Location>()._isConnect = true;
        horizontalObject1.GetComponent<Location>().Color = Color;
        horizontalObject1.GetComponent<Location>().startCorutine();
    }
    private void Delete()
    {
        Destroy(this.gameObject);
    }
    public void startCorutine()
    {
        particle.Play();
        StartCoroutine(Animation());
    }
    IEnumerator Animation()
    {
        bool isUp = true;

        float startScale = 1.0f;
        float endScale = 1.5f;

        float duration = 0.7f;
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            if (isUp)
            {
                float scale = Mathf.Lerp(startScale, endScale, (elapsedTime / duration) * 5 );
                transform.localScale = new Vector3(scale, scale, scale);
                elapsedTime += Time.deltaTime;
                yield return null;
                if (transform.localScale.y == endScale) isUp = false;
            }
            else
            {
                float scale = Mathf.Lerp(endScale, startScale, (elapsedTime / duration) * 2 );
                transform.localScale = new Vector3(scale, scale, scale);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}
