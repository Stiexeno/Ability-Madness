using UnityEngine;

namespace AbilityMadness.Code.Common.Behaviours
{
    public class EntityComponent : MonoBehaviour
    {
        private EntityView _entityView;

        protected EntityView EntityView
        {
            get
            {
                if (_entityView == null)
                {
                    _entityView = GetComponent<EntityView>();
                }

                return _entityView;
            }
        }
    }
}
