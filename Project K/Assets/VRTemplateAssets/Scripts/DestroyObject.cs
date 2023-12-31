using UnityEngine;

namespace VRTemplateAssets.Scripts
{
    /// <summary>
    /// Destroys GameObject after a few seconds.
    /// </summary>
    public class DestroyObject : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Time before destroying in seconds.")]
        float m_Lifetime = 5f;

        void Start()
        {
            Destroy(gameObject, m_Lifetime);
        }
    }
}
