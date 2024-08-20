using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Services.EightDirection
{
    public class EightDirectionService
    {
        public int CountOfNodes => Nodes.Count;

        public List<EightDirectionNode> Nodes;

        public EightDirectionService()
        {
            Nodes = new List<EightDirectionNode>();
        }
        public EightDirectionService(List<EightDirectionNode> nodes)
        {
            Nodes = nodes;
        }

        public void CreateNode(SpriteRenderer renderer)
        {
            var transform = renderer.GetComponent<Transform>();
            var mask = renderer.maskInteraction == SpriteMaskInteraction.None ? transform.GetComponent<SpriteMask>() : null;
            Nodes.Add(new EightDirectionNode(transform, renderer, mask));
        }
        public void CreateNode(Transform transform, SpriteRenderer renderer)
        {
            Nodes.Add(new EightDirectionNode(transform, renderer, null));
        }
        public void CreateNode(Transform transform, SpriteRenderer renderer, SpriteMask mask)
        {
            Nodes.Add(new EightDirectionNode(transform, renderer, mask));
        }
        public void InitDirection(Vector2 direction)
        {
            for (var i = 0; i < Nodes.Count; i++)
            {
                Nodes[i].InitDirection(direction);
            }
        }
        public void SetDirection(Vector2 direction)
        {
            for (var i = 0; i < Nodes.Count; i++)
            {
                Nodes[i].SetDirection(direction);
            }
        }
    }
}
