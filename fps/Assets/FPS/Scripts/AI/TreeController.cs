using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.Game;
using UnityEngine.AI;
using UnityEngine.Events;

namespace Unity.FPS.AI
{
    public class TreeController : MonoBehaviour
    {
        //[Header("VFX")]
        //[Tooltip("����������ʱ��VFXԤ�ƾͲ�����")]
        public GameObject DeathVfx;

        //[Tooltip("����VFX�����ĵ�")]
        public Transform DeathVfxSpawnPoint;

        Health m_Health;
        //[Tooltip("��������Ϸ���󱻴ݻٵ��ӳ�(������)")]
        public float DeathDuration = 0f;
        EnemyManager m_EnemyManager;

        // Start is called before the first frame update
        void Start()
        {
            m_EnemyManager = FindObjectOfType<EnemyManager>();//���س����е��������͵��������ͼ���

            m_Health = GetComponent<Health>();
            // Subscribe to damage & death actions
            m_Health.OnDie += OnDie;
            m_Health.OnDamaged += OnDamaged;
        }

        // Update is called once per frame
        void Update()
        {

        }


        void OnDie()
        {
            // spawn a particle system when dying
            //������ʱ��������ϵͳ
            var vfx = Instantiate(DeathVfx, DeathVfxSpawnPoint.position, Quaternion.identity);
            Destroy(vfx, 5f);
     
            // this will call the OnDestroy function
            //�⽫����OnDestroy����
            Destroy(gameObject, DeathDuration);
        }


        void OnDamaged(float damage, GameObject damageSource)
        {

        }
    }
}
