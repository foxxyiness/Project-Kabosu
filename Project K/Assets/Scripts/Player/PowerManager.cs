using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

namespace Player
{
   public class PowerManager : MonoBehaviour
   {
      [SerializeField] private InputActionReference inputActionReference;
      [SerializeField] private float intensity, duration = 0.5F;
      [SerializeField] private XRBaseController rightController;
      [SerializeField] private GameObject fireBall;
      [SerializeField] private Transform rightPowerSpawnPoint;
      [SerializeField] private float shootForce = 10f;
      
      private bool _itemGrabbed;
      private bool _canFire;

      private void Awake()
      {
         _canFire = true;
      }

      public void SetItemGrabTrue()
      { _itemGrabbed = true; Debug.Log("ITEM GRABBED");}

      public void SetItemGrabFalse()
      { _itemGrabbed = false; Debug.Log("ITEM DROPPED");}

      private void OnEnable()
      {
         inputActionReference.action.Enable();
      }

      private void OnDisable()
      {
         inputActionReference.action.Disable();
      }
   
      private void Update()
      {
         StartCoroutine(nameof(Fire));
      }

      private IEnumerator Fire()
      {
         if (inputActionReference.action.triggered && !_itemGrabbed && _canFire)
         {
            _canFire = false;
            Debug.Log("FIRE");
            TriggerHaptic(rightController);
            GameObject fireBallShot = Instantiate(fireBall, rightPowerSpawnPoint.position, Quaternion.identity);
            fireBallShot.GetComponent<Rigidbody>().AddForce(rightPowerSpawnPoint.transform.forward * shootForce, ForceMode.Impulse);
            yield return new WaitForSeconds(1);
            _canFire = true;
         }
      }
      private void TriggerHaptic(XRBaseController controller)
      {
         controller.SendHapticImpulse(intensity, duration);
      }
   }
}