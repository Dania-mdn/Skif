using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CreateDembroidery : MonoBehaviour
{
    public GameObject StartObject;
    public Transform StartHorizontalConnect;
    public Transform StartDiagonalConnect;
    [SerializeField] private GameObject[] _litersHorizontal;
    [SerializeField] private GameObject[] _litersDiagonal;
    private bool _isHorisontal = true;
    private Dictionary<char, int> _dictionary;
    public string TextForCreateDembroidery;
    private int i = 0;
    private char[] WriteChar;
    private bool isCreate = false;
    private bool isOutofRange;
    public Color BlackColor;
    public Color HorizontalColor;
    public Color DiagonalColor;
    public UnityEvent UnityEvent;
    private void OnEnable()
    {
        EventManager.Create += SetCreate;
        EventManager.CreateFalse += SetCreateFalse;
    }
    private void OnDisable()
    {
        EventManager.Create -= SetCreate;
        EventManager.CreateFalse -= SetCreateFalse;
    }
    private void Start()
    {
        _dictionary = new Dictionary<char, int>
        {
            { '�', 0}, { '�', 1}, { '�', 2}, { '�', 3}, { '�', 4},
            { '�', 5}, { '�', 6}, { '�', 7}, { '�', 8}, { '�', 9},
            { '�', 10}, { '�', 11}, { '�', 12}, { '�', 13}, { '�', 14},
            { '�', 15}, { '�', 16}, { '�', 17}, { '�', 18}, { '�', 19},
            { '�', 20}, { '�', 21}, { '�', 22}, { '�', 23}, { '�', 24},
            { '�', 25}, { '�', 26}, { '�', 27}, { '�', 28}, { '�', 29},
            { '�', 30}, { '�', 31}, { '�', 32}
        };
    }
    private void Update()
    {
        if (!isCreate) return;

        if (i < WriteChar.Length)
        {
            foreach (var Char in _dictionary)
            {
                if (Char.Key == WriteChar[i] && _isHorisontal)
                {
                    SpawnHorizontal(_litersHorizontal[Char.Value]);
                    _isHorisontal = false;
                    isOutofRange = true;
                    break;
                }
                else if (Char.Key == WriteChar[i] && !_isHorisontal)
                {
                    SpawnDiagonal(_litersDiagonal[Char.Value]);
                    _isHorisontal = true; 
                    isOutofRange = true;
                    break;
                }
                else if (Char.Key != WriteChar[i])
                {
                    isOutofRange = false;
                }
            }
            i++;
            if (isOutofRange)
            {
                isCreate = false;
            }
        }

    }
    public void CangeColor()
    {
        EventManager.DoChangeColorRB(HorizontalColor, DiagonalColor);
    }
    public void CangeColorBlak()
    {
        EventManager.DochangeColorBlack(BlackColor);
    }
    public void MyTextHandler()
    {
        WriteChar = TextForCreateDembroidery.ToCharArray();
        isCreate = true;
    }
    public void SetCreate()
    {
        isCreate = true;
    }
    public void SetCreateFalse()
    {
        _isHorisontal = true;
        isCreate = false; 
        i = 0;
    }
    private void SpawnHorizontal(GameObject gameObject)
    {
        var horizontalObject0 = Instantiate(gameObject, StartObject.transform);
        horizontalObject0.transform.position = StartHorizontalConnect.position;
        horizontalObject0.GetComponent<Location>().Color = HorizontalColor;
        this.UnityEvent.Invoke();
    }
    private void SpawnDiagonal(GameObject gameObject)
    {
        var diagonalObject = Instantiate(gameObject, StartObject.transform);
        diagonalObject.transform.position = StartDiagonalConnect.position;
        diagonalObject.GetComponent<Location>().Color = DiagonalColor;
        this.UnityEvent.Invoke();
    }
    public void URLInstagramm() => Application.OpenURL("https://www.instagram.com/skifiajewelry/");
}
