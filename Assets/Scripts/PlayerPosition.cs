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
    private bool _isActive;

    private void Awake()
    {
        _isActive = false;
        _spriteRenderer = GetComponent<SpriteRenderer>();
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

    public bool GetActive()
    {
        return _isActive;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameManager.Instance.gameMode == GameMode.MainMenu)
        {
            Tougle();
        }
    }

    public void Tougle()
    {
        var active = _player.active;
        _player.SetActive(!active);
        _spriteRenderer.enabled = active;
        _isActive = !active;
    }
}