using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrench_Bolt : MonoBehaviour
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
    public GameObject _Pivot;
    //private bool mBound;
    private float dist;

    // Start is called before the first frame update
    void Start()
    {      
        CurrentPosition = _SelectedBolt.transform.position;
        //  Destroy(_SelectedWrench.transform.GetChild(0));

        // print("hiiiiiii");
        // print("Distance: "+dist);
       // _SelectedBolt.transform.parent = _SelectedNut.transform;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //dist = Vector3.Distance(_SelectedBolt.transform.position, _SelectedNut.transform.position);
        dist = _SelectedBolt.transform.position.y -  _SelectedNut.transform.position.y;
        print("Distance: " + dist);
        mTotalWrenchRotation = mOldRotation.y - _SelectedWrench.transform.rotation.eulerAngles.y;
        mDesiredRotation = _SelectedBolt.transform.rotation.eulerAngles + new Vector3(0, -mTotalWrenchRotation, 0);
        //  print("bound"+mBound);
        //if (mLocked && (mTotalWrenchRotation < -0.1) && (grab = true)&& (mBound==false))
        if (mLocked && (mTotalWrenchRotation < -0.1) && (grab = true))
        {
            // print("Rotating clockwise..");
            // mDesiredRotation = _SelectedBolt.transform.rotation.eulerAngles + new Vector3(0, -mTotalWrenchRotation, 0);

            //_SelectedWrench.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //_SelectedWrench.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            //_SelectedWrench.gameObject.GetComponent<Rigidbody>().angularDrag = 0f;

            _SelectedBolt.GetComponent<Rigidbody>().velocity = Vector3.zero;
            _SelectedBolt.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            _SelectedBolt.GetComponent<Rigidbody>().angularDrag = 0f;

            // _SelectedBolt.GetComponent<Rigidbody>().velocity = transform.forward * _SelectedBolt.GetComponent<Rigidbody>().velocity.magnitude;

            _SelectedBolt.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
          _SelectedBolt.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            // mPivot = GameObject.Find("Pivot");
            //_SelectedWrench.transform.parent = mPivot.transform;
            // _SelectedBolt.transform.position =new Vector3(CurrentPosition.x, _SelectedBolt.transform.position.y,CurrentPosition.z) ;
           // _SelectedBolt.transform.parent = null;
            _SelectedBolt.transform.parent = _SelectedWrench.transform;
            _SelectedBolt.GetComponent<Rigidbody>().isKinematic = true;
           // _SelectedWrench.CenterOnChildren();
           // _SelectedBolt.transform.rotation = Quaternion.Slerp(_SelectedBolt.transform.rotation, Quaternion.Euler(mDesiredRotation), Time.deltaTime * 15f);
            _SelectedWrench.transform.position -= new Vector3(0f, Time.deltaTime * 2f, 0f);           
        }
        //if (mLocked && (mTotalWrenchRotation > 0.1) && (grab = true)&& (mBound == false))
        if (mLocked && (mTotalWrenchRotation > 0.1) && (grab = true))
        {
           // print("Rotating Anticlockwise..");
            _SelectedBolt.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
           // _SelectedBolt.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
             _SelectedBolt.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            _SelectedBolt.transform.SetParent(_SelectedWrench.transform, true);
            _SelectedWrench.transform.position += new Vector3(0f, Time.deltaTime * 2f, 0f);
        }
        //if (mLocked && (mTotalWrenchRotation ==0.0f) && (grab = true))
        //    _SelectedBolt.transform.parent = null;
        mOldRotation = _SelectedWrench.transform.rotation.eulerAngles;

        

    }
    void Update()
    {
        //if (mLocked && (grab == true))
        //{

        //    Vector3 Direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _SelectedWrench.transform.position;
        //    float angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        //    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //    _SelectedWrench.transform.rotation = Quaternion.Slerp(_SelectedWrench.transform.rotation, rotation, Time.deltaTime * 5f);

        //}

        // if (!grab && !mBound)
        if (!grab)
        {
                  
        Rigidbody rb =_SelectedWrench.GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.Space))
            {
                // print("left side");
                //rb.AddForce(Vector3.left);
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                _SelectedWrench.transform.Translate(Vector3.left * 15f * Time.deltaTime);
               

            }       
       
        }
        // print("Grab : " + grab + " Bound : " + mBound);
        //if (grab && !mBound && (Input.GetAxis("Horizontal") > 0) && dist>=2.350256)
        if (grab && (Input.GetAxis("Horizontal") > 0) && dist >= 0.1f)
        {
            // print("Left Arrow Pressed");

            // _SelectedWrench.transform.position = _Pivot.transform.position;
            //_SelectedWrench.transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * 35f * Time.deltaTime, Space.World);

            _SelectedWrench.transform.Rotate(Vector3.forward, Input.GetAxis("Horizontal") * 35f * Time.deltaTime);
           
           
            //_SelectedWrench.transform.RotateAround(_Pivot.transform.position,Vector3.up, Input.GetAxis("Horizontal") * 35f * Time.deltaTime);          
        }
        //if (grab && mBound && (Input.GetAxis("Horizontal") < 0))
        if (grab && (Input.GetAxis("Horizontal")<0) && dist <= 21f)
        {
            // print("Left Arrow Pressed");
            _SelectedWrench.transform.Rotate(Vector3.forward, Input.GetAxis("Horizontal") * 35f * Time.deltaTime);
        }
    }
    void OnCollisionStay(Collision obj)
    {
        if (this.gameObject.tag == obj.gameObject.tag)
        {
            mLocked = true;
           // _SelectedBolt.GetComponent<Rigidbody>().isKinematic = true;
            _SelectedBolt.GetComponent<Rigidbody>().AddForce(Vector3.zero);
            //_SelectedWrench.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            //_SelectedWrench.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            //obj.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //obj.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            //obj.gameObject.GetComponent<Rigidbody>().angularDrag = 0f;

            //this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //this.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            //this.gameObject.GetComponent<Rigidbody>().angularDrag = 0f;

            // this.gameObject.GetComponent<Rigidbody>().velocity = -(this.gameObject.GetComponent<Rigidbody>().velocity);

            _SelectedBolt.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            _SelectedBolt.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            //this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //this.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            //this.gameObject.GetComponent<Rigidbody>().angularDrag = 0f;
            mOldRotation = obj.transform.rotation.eulerAngles;
           // _SelectedBolt.GetComponent<Rigidbody>().isKinematic = false;
            //_SelectedBolt.transform.position = CurrentPosition;
        }

    }
    void OnTriggerEnter(Collider obj)
    {
       
        _SelectedWrench.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.zero);
        // _SelectedBolt.transform.position = CurrentPosition ;
    }
        void OnTriggerStay(Collider obj)
    {
        //this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //this.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        //this.gameObject.GetComponent<Rigidbody>().angularDrag = 0f;
        if (obj.gameObject.tag == this.gameObject.tag)
        {
            // print("inside trigger");
          //  print("Inside Trigger : "+obj.gameObject.name);
            grab = true;
           // _Pivot.transform.parent = _SelectedWrench.transform;
        }
        if (obj.gameObject.tag == "nut")
        {
            //print("Inside Trigger : " + obj.gameObject.name);
            //mBound = true;
        }
    }
    void OnTriggerExit(Collider obj)
    {
        if (obj.gameObject.tag == this.gameObject.tag)
        {
           // print("Outside Trigger : " + obj.gameObject.name);
           // grab = false;
        }
        if (obj.gameObject.tag == "nut")
        {
            //print("Outside Trigger : " + obj.gameObject.name);
           // mBound = false;
        }
    }
    //public void MoveWrench()
    //{
    //    //_SelectedWrench.transform.position +=(Vector3.left * 5f);
    //    //_SelectedWrench.GetComponent<Rigidbody>().AddForce(Vector3.left *5f,ForceMode.Impulse);
    //    _SelectedWrench.transform.Translate(Vector3.left * 5f* Time.deltaTime);
      
    //}
    //public void RotateWrench()
    //{
    //    _SelectedWrench.transform.rotation =Quaternion.Euler(_SelectedWrench.transform.rotation.eulerAngles + new Vector3(0f,1f,0f)); 
    //}
}
