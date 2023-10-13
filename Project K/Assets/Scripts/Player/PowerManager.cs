using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.iOS;
using UnityEngine.Serialization;
using UnityEngine.XR.Interaction.Toolkit;

namespace Player
{
   public class PowerManager : MonoBehaviour
   {
      [SerializeField] private DayManager _dayManager;
      [FormerlySerializedAs("inputActionReference")] [SerializeField] private InputActionReference fireActionReference;
      [SerializeField] private InputActionReference sunActionReference;
      [SerializeField] private InputActionReference timeActionReference;
      [SerializeField] private float intensity, duration = 0.5F;
      [SerializeField] private XRBaseController leftController;
      [SerializeField] private XRBaseController rightController;
      [SerializeField] private GameObject fireBall;
      [SerializeField] private Transform rightPowerSpawnPoint;
      [SerializeField] private float shootForce = 10f;

      public bool timePower;
      
      private bool _itemGrabbed;
      private bool _canFire;

      private void Awake()
      {
         _canFire = true;
         timePower = false;
      }

      public void SetItemGrabTrue()
      { _itemGrabbed = true; Debug.Log("ITEM GRABBED");}

      public void SetItemGrabFalse()
      { _itemGrabbed = false; Debug.Log("ITEM DROPPED");}

      private void OnEnable()
      {
         fireActionReference.action.Enable();
         timeActionReference.action.Enable();
      }

      private void OnDisable()
      {
         fireActionReference.action.Disable();
         timeActionReference.action.Disable();
      }
   
      private void Update()
      {
         StartCoroutine(nameof(Fire));
         TimeForward();
      }

      private IEnumerator Fire()
      {
         if (fireActionReference.action.triggered && !_itemGrabbed && _canFire)
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

      private void TimeForward()
      {
         if (timeActionReference.action.triggered && timePower)
         {
            leftController.SendHapticImpulse(1, 5);
            rightController.SendHapticImpulse(1, 5);
            _dayManager.FastForward();
         }
      }
      
      private void TriggerHaptic(XRBaseController controller)
      {
         controller.SendHapticImpulse(intensity, duration);
      }
   }
}
