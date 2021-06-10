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
    [AddComponentMenu("Semantic/Traits/Inventory (Trait)")]
    [RequireComponent(typeof(SemanticObject))]
    public partial class Inventory : MonoBehaviour, ITrait
    {
        public Generated.Semantic.Traits.Enums.Pickups NewProperty
        {
            get
            {
                if (m_EntityManager != default && m_EntityManager.HasComponent<InventoryData>(m_Entity))
                {
                    m_p8 = m_EntityManager.GetComponentData<InventoryData>(m_Entity).NewProperty;
                }

                return m_p8;
            }
            set
            {
                InventoryData data = default;
                var dataActive = m_EntityManager != default && m_EntityManager.HasComponent<InventoryData>(m_Entity);
                if (dataActive)
                    data = m_EntityManager.GetComponentData<InventoryData>(m_Entity);
                data.NewProperty = m_p8 = value;
                if (dataActive)
                    m_EntityManager.SetComponentData(m_Entity, data);
            }
        }
        public System.Int32 Amount
        {
            get
            {
                if (m_EntityManager != default && m_EntityManager.HasComponent<InventoryData>(m_Entity))
                {
                    m_p10 = m_EntityManager.GetComponentData<InventoryData>(m_Entity).Amount;
                }

                return m_p10;
            }
            set
            {
                InventoryData data = default;
                var dataActive = m_EntityManager != default && m_EntityManager.HasComponent<InventoryData>(m_Entity);
                if (dataActive)
                    data = m_EntityManager.GetComponentData<InventoryData>(m_Entity);
                data.Amount = m_p10 = value;
                if (dataActive)
                    m_EntityManager.SetComponentData(m_Entity, data);
            }
        }
        public InventoryData Data
        {
            get => m_EntityManager != default && m_EntityManager.HasComponent<InventoryData>(m_Entity) ?
                m_EntityManager.GetComponentData<InventoryData>(m_Entity) : GetData();
            set
            {
                if (m_EntityManager != default && m_EntityManager.HasComponent<InventoryData>(m_Entity))
                    m_EntityManager.SetComponentData(m_Entity, value);
            }
        }

        #pragma warning disable 649
        [SerializeField]
        [InspectorName("NewProperty")]
        Generated.Semantic.Traits.Enums.Pickups m_p8 = (Generated.Semantic.Traits.Enums.Pickups)0;
        [SerializeField]
        [InspectorName("Amount")]
        System.Int32 m_p10 = 0;
        #pragma warning restore 649

        EntityManager m_EntityManager;
        World m_World;
        Entity m_Entity;

        InventoryData GetData()
        {
            InventoryData data = default;
            data.NewProperty = m_p8;
            data.Amount = m_p10;

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

            if (!destinationManager.HasComponent(entity, typeof(InventoryData)))
            {
                destinationManager.AddComponentData(entity, GetData());
            }
        }

        void OnDestroy()
        {
            if (m_World != default && m_World.IsCreated)
            {
                m_EntityManager.RemoveComponent<InventoryData>(m_Entity);
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
            TraitGizmos.DrawGizmoForTrait(nameof(InventoryData), gameObject,Data);
        }
#endif
    }
}
