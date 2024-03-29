// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Pawn.h"

#include "../Public/InputController.h"
#include "Sound/SoundCue.h"

#include "PlayerPawn.generated.h"

UCLASS()
class THUNDERDOMEARENA_API APlayerPawn : public APawn
{
	GENERATED_BODY()

public:
	// Sets default values for this pawn's properties
	APlayerPawn();
private:

	//Initialize
	void InitMaterials();
	UStaticMeshComponent* InitBaseMesh(void);
	UStaticMeshComponent* InitWeapon2Mesh(void);
	UStaticMeshComponent* InitWeaponBaseMesh(void);
	UStaticMeshComponent* InitWeaponMesh(void);
	class UCameraComponent* InitCamera(void);
	void InitComponents(void);
	void MovePlayer(float a_fDeltaTime);

	// Callbacks
	void HandleForwardMoving(float a_fInput);
	void HandleRightMoving(float a_fInput);

	UFUNCTION()
	void OpenMenuAction();
	UFUNCTION()
	void ShootAction();
	UFUNCTION()
	void AimAction();
	UFUNCTION()
	void GetMousePositions();
	void ShootBullets();

	void EnableShooting();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:
	// Called every frame
	virtual void Tick(float DeltaTime) override;
	void OnPickUpEvent();
	// Called to bind functionality to input
	virtual void SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent) override;

private:

	// consts
	const FString M_S_MAT_BASE = TEXT("/Script/Engine.Material'/Game/Materials/M_Black.M_Black'");
	const FString M_S_MAT_DEC = TEXT("/Script/Engine.Material'/Game/Materials/M_Basic_Floor.M_Basic_Floor'");
	const FString M_S_MAT_WIN = TEXT("/Script/Engine.Material'/Game/Materials/M_Basic_Floor.M_Basic_Floor'");

	const FString M_S_MESH_BASE = TEXT("/Script/Engine.StaticMesh'/Game/Meshes/Car.Car'");
	const FString M_S_MESH_WEAPON_BASE = TEXT("/Script/Engine.StaticMesh'/Game/Meshes/Weapon_Weapon_Holder.Weapon_Weapon_Holder'");
	const FString M_S_MESH_WEAPON = TEXT("/Script/Engine.StaticMesh'/Game/Meshes/Weapon_Weapon.Weapon_Weapon'");
	const FString M_S_MESH_WEAPON_2 = TEXT("/Script/Engine.StaticMesh'/Game/Meshes/Weapon_2.Weapon_2'");
	const FString M_S_MESH_BULLET = TEXT("/Script/Engine.StaticMesh'/Game/Meshes/Bullet.Bullet'");

	const FString M_S_MESH_BASE_NAME = TEXT("CarBase");
	const FString M_S_MESH_WEAPON_BASE_NAME = TEXT("WeaponHolder");
	const FString M_S_MESH_WEAPON_NAME = TEXT("Weapon");
	const FString M_S_MESH_WEAPON_2_NAME = TEXT("Weapon2");
	const FString M_S_MESH_BULLET_NAME = TEXT("Bullet");

	const FString M_S_SHOOT_SOUND = TEXT("/Script/Engine.SoundWave'/Game/Audio/miniGun_Shoot.miniGun_Shoot'");

	// member

	FVector m_cameraLocation = FVector(0.0f, -300.0f, 150.0f);
	FRotator m_cameraRotation = FRotator(0.0f, 90.0f, 0.0f);

	//Movement
	FVector m_direction = FVector(0.0f, 0.0f, 0.0f);
	FRotator m_baseRotation = FRotator(0.0f, 0.0f, 0.0f);
	FRotator m_weaponRotation = FRotator(0.0f, 0.0f, 0.0f);

	//UStaticMeshComponent* m_pMesh_WeaponHolder;
	UCameraComponent* m_PCamera;
	FTimerHandle ShotTimerHandle;
	float m_fShotCooldown = 0.5f;
	bool m_bCanShoot = true;


	float m_fMousePosX;
	float m_fMousePosY;

	UPROPERTY(EditAnywhere,
		meta = (DisplayName = "Input", Category = "GameMode"))
	AInputController* m_pInput = nullptr;


	UPROPERTY(EditAnywhere,
		meta = (DisplayName = "MovementSpeed", Category = "Movement"))
	float m_fSpeed = 200.0f;

	UPROPERTY(EditAnywhere,
		meta = (DisplayName = "MovementSpeed", Category = "Movement"))
	float m_fRotationSpeed = 100.0f;

	UPROPERTY(EditAnywhere,
		meta = (DisplayName = "MovementSpeed", Category = "Movement"))
	float m_fBulletSpeed = 100.0f;


	// Materials & Meshes
	UPROPERTY(EditAnywhere,
		meta = (DisplayName = "Base", Category = "Components"))
	TObjectPtr<UMaterialInterface> m_pMaterial_Base = nullptr;

	UPROPERTY(EditAnywhere,
		meta = (DisplayName = "Decoration", Category = "Components"))
	TObjectPtr<UMaterialInterface> m_pMaterial_Decoration = nullptr;

	UPROPERTY(EditAnywhere,
		meta = (DisplayName = "Window", Category = "Components"))
	TObjectPtr<UMaterialInterface> m_pMaterial_Window = nullptr;

	UPROPERTY(EditAnywhere,
		meta = (DisplayName = "BaseMesh", Category = "Components"))
	TObjectPtr<UStaticMeshComponent> m_pMesh_Base = nullptr;

	UPROPERTY(EditAnywhere,
		meta = (DisplayName = "Weapon", Category = "Components"))
	TObjectPtr<UStaticMeshComponent> m_pMesh_Weapon = nullptr;

	UPROPERTY(EditAnywhere,
		meta = (DisplayName = "Weapon_2", Category = "Components"))
	TObjectPtr<UStaticMeshComponent> m_pMesh_2_Weapon = nullptr;

	UPROPERTY(EditAnywhere,
		meta = (DisplayName = "WeaponHolder", Category = "Components"))
	TObjectPtr<UStaticMeshComponent> m_pMesh_WeaponHolder = nullptr;

	// Camera
	UPROPERTY(EditAnywhere,
		meta = (DisplayName = "Camera", Category = "Components"))
	TObjectPtr<class UCameraComponent> m_pCamera = nullptr;

};
