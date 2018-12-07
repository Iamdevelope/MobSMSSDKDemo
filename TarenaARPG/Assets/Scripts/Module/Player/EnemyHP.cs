using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TRPG
{
    public class EnemyHP : MonoBehaviour
    {
        private Slider slide;
        private Transform CameraRig;
        private void Start()
        {
            slide = GetComponentInChildren<Slider>();
            CameraRig = FindObjectOfType<Follower>().transform;
        }
        private void Update()
        {
            transform.LookAt(Camera.main.transform.position);
        }
        public void SetEnemyHp(float Hp, float maxHp)
        {
            slide.value = Hp / maxHp;
        }
    }
}