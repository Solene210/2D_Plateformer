using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarDamage : MonoBehaviour
{
    #region Expose

    [SerializeField]
    private Sprite[] _sprites;

    [SerializeField]
    private int _healthPoint;

    #endregion

    #region Unity Lyfecycle
    void Start()
    {
        _graphics = transform.Find("PillierGraphics");
        _renderer = _graphics.GetComponent<SpriteRenderer>();

        ChangeSprite();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Weapon"))
        {
            _nbDamage++;
            if(_nbDamage >= _healthPoint) 
            {
                Destroy(gameObject);
            }
            else
            {
                ChangeSprite();
            }
        }
    }
    #endregion

    #region Methods

    private void ChangeSprite()
    {
        _renderer.sprite = _sprites[_nbDamage];
    }
    #endregion

    #region Private & Protected

    private int _nbDamage = 0;
    private Transform _graphics;
    private SpriteRenderer _renderer;

    #endregion
}
