using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using NaughtyAttributes;

namespace Services.EightDirection
{
    public class EightDirectionMono : MonoBehaviour
    {
        [SerializeField] private EightDirectionNode[] _nodes;
        private EightDirectionService _service; 

#if UNITY_EDITOR
        [SerializeField, Dropdown(nameof(GetDirectionValues))] private Vector2 _direction;

        private DropdownList<Vector2> GetDirectionValues()
        {
            return new DropdownList<Vector2>() {
                { "Right",   Vector2.right },
                { "Left",    Vector2.left },
                { "Up",      Vector2.up },
                { "Down",    Vector2.down },
                { "Up Right", new Vector2(1,1) },
                { "Up Left",    new Vector2(-1,1) },
                { "Down Right",    new Vector2(1,-1) },
                { "Down Left",    new Vector2(-1,-1) }
            };
        }
        [Button("Initialize Direction")]
        private void EditorInitDirection()
        {
            _service.InitDirection(_direction);
            Debug.Log($"Added settings to {_direction} node");
        }
        [Button("Set Direction")]
        private void EditorSetDirection()
        {
            _service.SetDirection(_direction);
            Debug.Log($"Test settings to {_direction} node");
        }
        
        [Button("Generate Nodes")]
        private void EditorGenerateDirectionNodes()
        {
            var nodesCount = GenerateDirectionNodes();
            Debug.Log(nodesCount == 0 ? "No objects suitable for creating nodes were found"
                : $"Was generated {nodesCount} direction nodes!");
        }
#endif
        public int GenerateDirectionNodes()
        {
            var children = GetComponentsInChildren<SpriteRenderer>();

            if (children == null || children.Length == 0) return 0;

            _service = _service ?? new EightDirectionService();
            _service.Nodes.Clear();

            for (var i = 0; i < children.Length; i++)
            {
                _service.CreateNode(children[i]);
            }
            _service.Nodes.CopyTo(_nodes);
            return _service.CountOfNodes;
        }
        public void SetDirection(Vector2 direction)
        {
            _service.SetDirection(direction);
        }
        private void Awake()
        {
            _service = new EightDirectionService(_nodes.ToList());
        }
    }
}
