using AbilityMadness.Code.Common.Behaviours;
using UnityEngine;

namespace AbilityMadness.Code.Infrastructure.View
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
