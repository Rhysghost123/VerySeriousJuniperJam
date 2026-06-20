// Fill out your copyright notice in the Description page of Project Settings.


#include "AwfulPlayerController.h"

void AAwfulPlayerController::ChangeHealth(HealthChangeFlag Flag, int Value) {
	if (Flag == HealthChangeFlag::SUB) {
		auto NewHealth = Health - Value;
		Health = NewHealth;
	}
	else if (Flag == HealthChangeFlag::ADD) {
		auto NewHealth = Health + Value;
		Health = NewHealth;
	}
}