using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : Character
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float moveSpeed = 5f;

    private bool isMoving = false;

    private CounterTime counter = new CounterTime();

    private bool IsCanUpdate => GameManager.Ins.IsState(GameState.GamePlay) || GameManager.Ins.IsState(GameState.Setting);

    public SkinType skinType;
    public WeaponType weaponType;
    public HatType hatType;
    public AccessoryType accessoryType;
    public PantType pantType;

    [SerializeField] ParticleSystem reviveVFX;

    public int Coin => Score * 10;

    private void Update()
    {
        if (IsCanUpdate && !IsDead)
        {
            if (Input.GetMouseButtonDown(0))
            {
                counter.Cancel();
            }

            if (Input.GetMouseButton(0) && JoystickControl.direct != Vector3.zero)
            {
                //rb.velocity = JoystickControl.direct * moveSpeed * Time.deltaTime;
                rb.MovePosition(rb.position + JoystickControl.direct * moveSpeed * Time.deltaTime);
                transform.position = rb.position;

                transform.forward = JoystickControl.direct;

                ChangeAnim(Constant.ANIM_RUN);
                isMoving = true;
            }
            else
            {
                counter.Execute();
            }

            if (Input.GetMouseButtonUp(0))
            {
                isMoving = false;
                OnMoveStop();
                OnAttack();

            }
            }
        }

    public override void OnInit()
    {
        OnTakeClothesData();
        base.OnInit();
        TF.rotation = Quaternion.Euler(Vector3.up * 180);
        SetSize(MIN_SIZE);
        indicator.SetName("You");
    }
    public override void WearClothes()
    {
        base.WearClothes();
        ChangeSkin(skinType);
        ChangeWeapon(weaponType);
        ChangeHat(hatType);
        ChangeAccessory(accessoryType);
        ChangePant(pantType);
    }


    public override void OnMoveStop()
    {
        rb.velocity = Vector3.zero;
        base.OnMoveStop();
    }
    public override void AddTarget(Character target)
    {
        base.AddTarget(target);
        if (!target.IsDead && !IsDead)
        {
            target.SetMark(true);
            if (!counter.IsRunning && !isMoving)
            {
                OnAttack();
            }
        }
    }
    public override void RemoveTarget(Character target)
    {
        base.RemoveTarget(target);
        target.SetMark(false);
    }
    public override void OnAttack()
    {
        base.OnAttack();
        if (target && currentSkin.Weapon.IsCanAttack)
        {
            counter.Start(Throw, TIME_DELAY_THROW);
            ResetAnim();
        }
    }
    protected override void SetSize(float size)
    {
        base.SetSize(size);
        CameraFollower.Ins.SetRateOffset((this.size - MIN_SIZE) / (MAX_SIZE - MIN_SIZE));
    }
    public void OnRevive()
    {
        ChangeAnim(Constant.ANIM_IDLE);
        IsDead = false;
        ClearTarget();

        reviveVFX.Play();
    }
    public override void OnDeath()
    {
        base.OnDeath();
        counter.Cancel();
    }
    public void TryCloth(UIShop.ShopType shopType, Enum type)
    {
        switch (shopType)
        {
            case UIShop.ShopType.Hat:
                currentSkin.DespawnHat();
                ChangeHat((HatType)type);
                break;
            case UIShop.ShopType.Pant:
                ChangePant((PantType)type);
                break;
            case UIShop.ShopType.Accessory:
                currentSkin.DespawnAccessory();
                ChangeAccessory((AccessoryType)type);
                break;
            case UIShop.ShopType.Skin:
                TakeOffClothes();
                skinType = (SkinType)type;
                break;
            case UIShop.ShopType.Weapon:
                currentSkin.DespawnWeapon();
                ChangeWeapon((WeaponType)type);
                break;
            default:
                break;
        }
    }
    public void OnTakeClothesData()
    {
        // take old cloth data
        skinType = UserData.Ins.playerSkin;
        weaponType = UserData.Ins.playerWeapon;
        hatType = UserData.Ins.playerHat;
        accessoryType = UserData.Ins.playerAccessory;
        pantType = UserData.Ins.playerPant;
    }
}
