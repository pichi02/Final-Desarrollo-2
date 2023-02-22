
using UnityEditor;
using UnityEngine;

namespace TankGame
{
    [CreateAssetMenu(fileName = "NewEnemyScriptableObject", menuName = "Enemy Scriptable Object")]
    public class EnemyScriptableObject : ScriptableObject
    {
        [SerializeField] private float speed;

        public float Speed { get { return speed; } }
    }
}
