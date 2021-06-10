using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Semantic.Traits;
using Unity.Entities;
using UnityEngine;

namespace Generated.Semantic.Traits
{
    [ExecuteAlways]
    [DisallowMultipleComponent]
    [AddComponentMenu("Semantic/Traits/NeedWarmth (Trait)")]
    [RequireComponent(typeof(SemanticObject))]
    public partial class NeedWarmth : MonoBehaviour, ITrait
    {
        public Generated.Semantic.Traits.Enums.Need Warmth
        {
            get
            {
                if (m_EntityManager != default && m_EntityManager.HasComponent<NeedWarmthData>(m_Entity))
                {
                    m_p1 = m_EntityManager.GetComponentData<NeedWarmthData>(m_Entity).Warmth;
                }

                return m_p1;
            }
            set
            {
                NeedWarmthData data = default;
                var dataActive = m_EntityManager != default && m_EntityManager.HasComponent<NeedWarmthData>(m_Entity);
                if (dataActive)
                    data = m_EntityManager.GetComponentData<NeedWarmthData>(m_Entity);
                data.Warmth = m_p1 = value;
                if (dataActive)
                    m_EntityManager.SetComponentData(m_Entity, data);
            }
        }
        public System.Int32 Amount
        {
            get
            {
                if (m_EntityManager != default && m_EntityManager.HasComponent<NeedWarmthData>(m_Entity))
                {
                    m_p5 = m_EntityManager.GetComponentData<NeedWarmthData>(m_Entity).Amount;
                }

                return m_p5;
            }
            set
            {
                NeedWarmthData data = default;
                var dataActive = m_EntityManager != default && m_EntityManager.HasComponent<NeedWarmthData>(m_Entity);
                if (dataActive)
                    data = m_EntityManager.GetComponentData<NeedWarmthData>(m_Entity);
                data.Amount = m_p5 = value;
                if (dataActive)
                    m_EntityManager.SetComponentData(m_Entity, data);
            }
        }
        public NeedWarmthData Data
        {
            get => m_EntityManager != default && m_EntityManager.HasComponent<NeedWarmthData>(m_Entity) ?
                m_EntityManager.GetComponentData<NeedWarmthData>(m_Entity) : GetData();
            set
            {
                if (m_EntityManager != default && m_EntityManager.HasComponent<NeedWarmthData>(m_Entity))
                    m_EntityManager.SetComponentData(m_Entity, value);
            }
        }

        #pragma warning disable 649
        [SerializeField]
        [InspectorName("Warmth")]
        Generated.Semantic.Traits.Enums.Need m_p1 = (Generated.Semantic.Traits.Enums.Need)0;
        [SerializeField]
        [InspectorName("Amount")]
        System.Int32 m_p5 = 75;
        #pragma warning restore 649

        EntityManager m_EntityManager;
        World m_World;
        Entity m_Entity;

        NeedWarmthData GetData()
        {
            NeedWarmthData data = default;
            data.Warmth = m_p1;
            data.Amount = m_p5;

            return data;
        }

        
        void OnEnable()
        {
            // Handle the case where this trait is added after conversion
            var semanticObject = GetComponent<SemanticObject>();
            if (semanticObject && !semanticObject.Entity.Equals(default))
                Convert(semanticObject.Entity, semanticObject.EntityManager, null);
        }

        public void Convert(Entity entity, EntityManager destinationManager, GameObjectConversionSystem _)
        {
            m_Entity = entity;
            m_EntityManager = destinationManager;
            m_World = destinationManager.World;

            if (!destinationManager.HasComponent(entity, typeof(NeedWarmthData)))
            {
                destinationManager.AddComponentData(entity, GetData());
            }
        }

        void OnDestroy()
        {
            if (m_World != default && m_World.IsCreated)
            {
                m_EntityManager.RemoveComponent<NeedWarmthData>(m_Entity);
                if (m_EntityManager.GetComponentCount(m_Entity) == 0)
                    m_EntityManager.DestroyEntity(m_Entity);
            }
        }

        void OnValidate()
        {

            // Commit local fields to backing store
            Data = GetData();
        }

#if UNITY_EDITOR
        void OnDrawGizmos()
        {
            TraitGizmos.DrawGizmoForTrait(nameof(NeedWarmthData), gameObject,Data);
        }
#endif
    }
}
