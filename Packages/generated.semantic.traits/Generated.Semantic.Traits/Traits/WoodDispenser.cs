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
    [AddComponentMenu("Semantic/Traits/WoodDispenser (Trait)")]
    [RequireComponent(typeof(SemanticObject))]
    public partial class WoodDispenser : MonoBehaviour, ITrait
    {
        public Generated.Semantic.Traits.Enums.Pickups DispenseWood
        {
            get
            {
                if (m_EntityManager != default && m_EntityManager.HasComponent<WoodDispenserData>(m_Entity))
                {
                    m_p0 = m_EntityManager.GetComponentData<WoodDispenserData>(m_Entity).DispenseWood;
                }

                return m_p0;
            }
            set
            {
                WoodDispenserData data = default;
                var dataActive = m_EntityManager != default && m_EntityManager.HasComponent<WoodDispenserData>(m_Entity);
                if (dataActive)
                    data = m_EntityManager.GetComponentData<WoodDispenserData>(m_Entity);
                data.DispenseWood = m_p0 = value;
                if (dataActive)
                    m_EntityManager.SetComponentData(m_Entity, data);
            }
        }
        public WoodDispenserData Data
        {
            get => m_EntityManager != default && m_EntityManager.HasComponent<WoodDispenserData>(m_Entity) ?
                m_EntityManager.GetComponentData<WoodDispenserData>(m_Entity) : GetData();
            set
            {
                if (m_EntityManager != default && m_EntityManager.HasComponent<WoodDispenserData>(m_Entity))
                    m_EntityManager.SetComponentData(m_Entity, value);
            }
        }

        #pragma warning disable 649
        [SerializeField]
        [InspectorName("DispenseWood")]
        Generated.Semantic.Traits.Enums.Pickups m_p0 = (Generated.Semantic.Traits.Enums.Pickups)0;
        #pragma warning restore 649

        EntityManager m_EntityManager;
        World m_World;
        Entity m_Entity;

        WoodDispenserData GetData()
        {
            WoodDispenserData data = default;
            data.DispenseWood = m_p0;

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

            if (!destinationManager.HasComponent(entity, typeof(WoodDispenserData)))
            {
                destinationManager.AddComponentData(entity, GetData());
            }
        }

        void OnDestroy()
        {
            if (m_World != default && m_World.IsCreated)
            {
                m_EntityManager.RemoveComponent<WoodDispenserData>(m_Entity);
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
            TraitGizmos.DrawGizmoForTrait(nameof(WoodDispenserData), gameObject,Data);
        }
#endif
    }
}
