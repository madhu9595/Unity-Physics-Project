using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrechSetUp: MonoBehaviour
{
    public GameObject _SelectedWrench;
    public GameObject _SelectedBolt;
    public GameObject _SelectedNut;
    private bool mLocked = false;
    private Vector3 mOldRotation;
    private float mTotalWrenchRotation;
    private float mTotalBoltRotation;
    private Vector3 mDesiredRotation;
    private Vector3 mSocketPosition;
    private Quaternion mSocketRotation;
    private GameObject mBoltCentre;
    private Vector3 CurrentPosition;
    private bool grab = false;

    // Start is called before the first frame update
    void Start()
    {
        CurrentPosition = _SelectedBolt.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mTotalWrenchRotation = mOldRotation.y - _SelectedWrench.transform.rotation.eulerAngles.y;
        mDesiredRotation = _SelectedBolt.transform.rotation.eulerAngles + new Vector3(0, -mTotalWrenchRotation, 0);
        if (mLocked && (mTotalWrenchRotation < -0.1) && (grab = true))
        {
            // print("Rotating clockwise..");
            // mDesiredRotation = _SelectedBolt.transform.rotation.eulerAngles + new Vector3(0, -mTotalWrenchRotation, 0);
            //_SelectedWrench.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //_SelectedWrench.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            //_SelectedWrench.gameObject.GetComponent<Rigidbody>().angularDrag = 0f;

            //_SelectedBolt.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            //_SelectedBolt.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            //_SelectedBolt.transform.parent = _SelectedWrench.transform;
            //// _SelectedBolt.transform.rotation = Quaternion.Slerp(_SelectedBolt.transform.rotation, Quaternion.Euler(mDesiredRotation), Time.deltaTime * 15f);
            //_SelectedWrench.transform.position -= new Vector3(0f, Time.deltaTime * 10f, 0f);
        }
        if (mLocked && (mTotalWrenchRotation > 0.1) && (grab = true))
        {
            //// print("Rotating Anticlockwise..");
            //_SelectedBolt.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            //_SelectedBolt.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            //_SelectedBolt.transform.SetParent(_SelectedWrench.transform, true);
            //_SelectedWrench.transform.position += new Vector3(0f, Time.deltaTime * 10f, 0f);
        }
        mOldRotation = _SelectedWrench.transform.rotation.eulerAngles;
    }

    void OnCollisionStay(Collision obj)
    {
        if (this.gameObject.tag == obj.gameObject.tag)
        {
            mLocked = true;
          

            //this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //this.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            //this.gameObject.GetComponent<Rigidbody>().angularDrag = 0f;

            //_SelectedBolt.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            //_SelectedBolt.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
           
            //mOldRotation = obj.transform.rotation.eulerAngles;
        }

    }

    void OnTriggerStay(Collider obj)
    {
        if (obj.gameObject.tag == this.gameObject.tag)
        {
            // print("inside trigger");
            grab = true;
        }
    }
    void OnTriggerExit(Collider obj)
    {
        if (obj.gameObject.tag == this.gameObject.tag)
        {
            print("outside trigger");
            grab = false;
        }
    }
}
