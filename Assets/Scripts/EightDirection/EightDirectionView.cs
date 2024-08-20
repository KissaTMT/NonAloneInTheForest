using System;
using UnityEngine;

namespace Services.EightDirection
{
    [Serializable]
    public struct EightDirectionView
    {
        public Vector2 Position;
        public Vector3 LocalScale;
        public Vector3 EulerAngles;
        public Sprite Sprite;
        public int Order;

        public EightDirectionView(Transform transform, SpriteRenderer renderer)
        {
            Position = transform.localPosition;
            LocalScale = transform.localScale;
            EulerAngles = transform.localEulerAngles;
            Sprite = renderer.sprite;
            Order = renderer.sortingOrder;
        }
        public override string ToString() => Sprite.ToString();
    }
}
