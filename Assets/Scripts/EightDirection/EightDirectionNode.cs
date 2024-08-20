using System;
using System.Collections.Generic;
using UnityEngine;

namespace Services.EightDirection
{
    [Serializable]
    public class EightDirectionNode
    {
        private static Dictionary<Vector2,int> _keys = new Dictionary<Vector2, int>()
        {
            { Vector2.right, 0 }, { Vector2.left, 1 }, { Vector2.up, 2 }, { Vector2.down, 3 },
            { new Vector2(1, 1), 4 }, { new Vector2(1, -1), 5 }, { new Vector2(-1, 1), 6 }, { new Vector2(-1, -1), 7 }
        };
        public Vector2 CurrentDirection => _currentDirection;
        public Transform Transform => _transform;
        public SpriteRenderer Renderer => _renderer;

        public Transform _transform;
        public SpriteRenderer _renderer;
        public SpriteMask _mask;

        public EightDirectionView[] _views;
        public EightDirectionView _currentView;
        public Vector2 _currentDirection;

        public EightDirectionNode(Transform transform, SpriteRenderer renderer, SpriteMask mask)
        {
            _transform = transform;
            _renderer = renderer;
            _mask = mask;
            if (_mask) _mask.sprite = _renderer.sprite;
            _views = new EightDirectionView[8];
        }

        public void InitDirection(Vector2 direction)
        {
            _views[GetKey(direction)] = new EightDirectionView(_transform, _renderer);
        }
        public void SetDirection(Vector2 direction)
        {
            _currentDirection = direction;
            _currentView = _views[GetKey(direction)];
            _transform.localPosition = _currentView.Position;
            _transform.localScale = _currentView.LocalScale;
            _transform.localRotation = Quaternion.Euler(_currentView.EulerAngles);
            _renderer.sprite = _currentView.Sprite;
            _renderer.sortingOrder = _currentView.Order;
            if (_renderer.maskInteraction == SpriteMaskInteraction.None) _mask.sprite = _currentView.Sprite;
        }
        public override string ToString() => _transform.name;
        private int GetKey(Vector2 direction)
        {
            //var hash = $"{direction.x * 3} {direction.y * 2}".GetHashCode() % _views.Length;
            //hash = hash >= 0 ? hash : _views.Length + hash;
            //return hash;
            return _keys[direction];
        }
    }
}
