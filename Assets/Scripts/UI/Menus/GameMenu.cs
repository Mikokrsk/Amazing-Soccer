using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameMenu : MonoBehaviour
{
    [SerializeField] protected CanvasGroup _canvasGroup;

    public virtual void Start()
    {
        if (_canvasGroup == null)
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }
    }

    public virtual void EnableMenu()
    {
        //  UIManager.Instance.Pause();
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
    }

    public virtual void DisableMenu()
    {
        //  UIManager.Instance.Unpause();
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
    }
}