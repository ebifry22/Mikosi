using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private GameObject PlayerObj;
    [SerializeField] private player Player;
    [SerializeField] private Vector3 FrontPos;
    [SerializeField] private Vector3 RightPos;
    [SerializeField] private Vector3 LeftPos;
    [SerializeField] private Quaternion FrontAngle;
    [SerializeField] private Quaternion RightAngle;
    [SerializeField] private Quaternion LeftAngle;
    [SerializeField] private float speed;
    [SerializeField] private float Anglespeed;
    [SerializeField] private MikoshiCollisionDetection mikosiCollision;
    [SerializeField] private float adjustment;
    [SerializeField] private int ColumLimit;
    private bool Air = false;
    // Start is called before the first frame update
 
    // Update is called once per frame
    void FixedUpdate()
    {
        int Colum = ColumLimit < mikosiCollision.ColumnCount ? ColumLimit : mikosiCollision.ColumnCount;
        if(Player.turn_complete_R||Player.turn_complete_L)
        {
            switch (Player.Angle)
            {
                case player.playerType.Right:
                    MainCamera.transform.localPosition = Vector3.Lerp(MainCamera.transform.localPosition, RightPos - new Vector3(0, 0, (Colum * adjustment) + (Player.forward_or_back_speed - 1)+20), speed);
                    MainCamera.transform.localRotation = Quaternion.Lerp(MainCamera.transform.localRotation, RightAngle, Anglespeed); break;
                case player.playerType.Left:
                    MainCamera.transform.localPosition = Vector3.Lerp(MainCamera.transform.localPosition, LeftPos - new Vector3(0, 0, (Colum * adjustment) + (Player.forward_or_back_speed - 1)+20), speed);
                    MainCamera.transform.localRotation = Quaternion.Lerp(MainCamera.transform.localRotation, LeftAngle, Anglespeed); break;
                default:
                    MainCamera.transform.localPosition = Vector3.Lerp(MainCamera.transform.localPosition, FrontPos - new Vector3(0, 0, (Colum * adjustment) + (Player.forward_or_back_speed - 1)+20), speed);
                    MainCamera.transform.localRotation = Quaternion.Lerp(MainCamera.transform.localRotation, FrontAngle, Anglespeed); break;
            }
        }
        else if(Player.JumpCheck)
        {
            Air = true;
            switch (Player.Angle)
            {
                case player.playerType.Right:
                    MainCamera.transform.localPosition = Vector3.Lerp(MainCamera.transform.localPosition, RightPos - new Vector3(0, 0, (Colum * adjustment) + (Player.forward_or_back_speed - 1) + 10), speed);
                    MainCamera.transform.localRotation = Quaternion.Lerp(MainCamera.transform.localRotation, RightAngle, Anglespeed); break;
                case player.playerType.Left:
                    MainCamera.transform.localPosition = Vector3.Lerp(MainCamera.transform.localPosition, LeftPos - new Vector3(0, 0, (Colum * adjustment) + (Player.forward_or_back_speed - 1) + 10), speed);
                    MainCamera.transform.localRotation = Quaternion.Lerp(MainCamera.transform.localRotation, LeftAngle, Anglespeed); break;
                default:
                    MainCamera.transform.localPosition = Vector3.Lerp(MainCamera.transform.localPosition, FrontPos - new Vector3(0, 0, (Colum * adjustment) + (Player.forward_or_back_speed - 1) + 10), speed);
                    MainCamera.transform.localRotation = Quaternion.Lerp(MainCamera.transform.localRotation, FrontAngle, Anglespeed); break;
            }
        }
        else if (Air && transform.localPosition.y <= 10)
        {
            transform.DOComplete();
            transform.DOShakePosition(0.1f * Time.deltaTime, 10000);
            transform.DOShakeRotation(0.1f * Time.deltaTime, 10000);
            Air = false;
            Debug.Log("�h��܂���");
        }
        else
        {
            switch (Player.Angle)
            {
                case player.playerType.Right:
                    MainCamera.transform.localPosition = Vector3.Lerp(MainCamera.transform.localPosition, RightPos - new Vector3(0, 0, (Player.forward_or_back_speed - 1)), speed);
                    MainCamera.transform.localRotation = Quaternion.Lerp(MainCamera.transform.localRotation, RightAngle, Anglespeed); break;
                case player.playerType.Left:
                    MainCamera.transform.localPosition = Vector3.Lerp(MainCamera.transform.localPosition, LeftPos - new Vector3(0, 0,  (Player.forward_or_back_speed - 1)), speed);
                    MainCamera.transform.localRotation = Quaternion.Lerp(MainCamera.transform.localRotation, LeftAngle, Anglespeed); break;
                default:
                    MainCamera.transform.localPosition = Vector3.Lerp(MainCamera.transform.localPosition, FrontPos - new Vector3(0, 0, (Player.forward_or_back_speed - 1)), speed);
                    MainCamera.transform.localRotation = Quaternion.Lerp(MainCamera.transform.localRotation, FrontAngle, Anglespeed); break;
            }
        }
        
     
        
    }
}
