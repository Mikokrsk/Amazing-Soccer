using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerPosition : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private BoxCollider2D _areaResponsibility;
    [SerializeField] private Vector2 _areaResponsibilityOffset;
    [SerializeField] private Vector2 _areaResponsibilitySize;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _player;

    private void Awake()
    {
        // _areaResponsibility = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        //   _player = GetComponentInChildren<GameObject>();

        _areaResponsibility.offset = _areaResponsibilityOffset;
        _areaResponsibility.size = _areaResponsibilitySize;
    }

    private void Start()
    {
        _player.SetActive(false);
        _spriteRenderer.enabled = true;
    }

    public BoxCollider2D GetRange()
    {
        return _areaResponsibility;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameManager.Instance.gameMode == GameMode.Game)
        {
            Tougle();
        }
    }

    public void Tougle()
    {
        _player.SetActive(!_player.active);
        _spriteRenderer.enabled = !_player.active;
    }
}