// Copyright Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "UObject/GeneratedCppIncludes.h"
#include "VerySeriousProject/Public/BuffComponent.h"
PRAGMA_DISABLE_DEPRECATION_WARNINGS
void EmptyLinkFunctionForGeneratedCodeBuffComponent() {}

// Begin Cross Module References
ENGINE_API UClass* Z_Construct_UClass_UActorComponent();
UPackage* Z_Construct_UPackage__Script_VerySeriousProject();
VERYSERIOUSPROJECT_API UClass* Z_Construct_UClass_UBuffComponent();
VERYSERIOUSPROJECT_API UClass* Z_Construct_UClass_UBuffComponent_NoRegister();
VERYSERIOUSPROJECT_API UEnum* Z_Construct_UEnum_VerySeriousProject_EStats();
VERYSERIOUSPROJECT_API UScriptStruct* Z_Construct_UScriptStruct_FBuff();
VERYSERIOUSPROJECT_API UScriptStruct* Z_Construct_UScriptStruct_FDebuff();
// End Cross Module References

// Begin Enum EStats
static FEnumRegistrationInfo Z_Registration_Info_UEnum_EStats;
static UEnum* EStats_StaticEnum()
{
	if (!Z_Registration_Info_UEnum_EStats.OuterSingleton)
	{
		Z_Registration_Info_UEnum_EStats.OuterSingleton = GetStaticEnum(Z_Construct_UEnum_VerySeriousProject_EStats, (UObject*)Z_Construct_UPackage__Script_VerySeriousProject(), TEXT("EStats"));
	}
	return Z_Registration_Info_UEnum_EStats.OuterSingleton;
}
template<> VERYSERIOUSPROJECT_API UEnum* StaticEnum<EStats>()
{
	return EStats_StaticEnum();
}
struct Z_Construct_UEnum_VerySeriousProject_EStats_Statics
{
#if WITH_METADATA
	static constexpr UECodeGen_Private::FMetaDataPairParam Enum_MetaDataParams[] = {
		{ "Bitflags", "" },
		{ "BlueprintType", "true" },
		{ "FutureStuff.Name", "EStats::FutureStuff" },
		{ "Health.Name", "EStats::Health" },
		{ "LuckMul.Name", "EStats::LuckMul" },
		{ "ModuleRelativePath", "Public/BuffComponent.h" },
		{ "None.Name", "EStats::None" },
		{ "Speed.Name", "EStats::Speed" },
		{ "Strength.Name", "EStats::Strength" },
	};
#endif // WITH_METADATA
	static constexpr UECodeGen_Private::FEnumeratorParam Enumerators[] = {
		{ "EStats::None", (int64)EStats::None },
		{ "EStats::Speed", (int64)EStats::Speed },
		{ "EStats::Strength", (int64)EStats::Strength },
		{ "EStats::Health", (int64)EStats::Health },
		{ "EStats::LuckMul", (int64)EStats::LuckMul },
		{ "EStats::FutureStuff", (int64)EStats::FutureStuff },
	};
	static const UECodeGen_Private::FEnumParams EnumParams;
};
const UECodeGen_Private::FEnumParams Z_Construct_UEnum_VerySeriousProject_EStats_Statics::EnumParams = {
	(UObject*(*)())Z_Construct_UPackage__Script_VerySeriousProject,
	nullptr,
	"EStats",
	"EStats",
	Z_Construct_UEnum_VerySeriousProject_EStats_Statics::Enumerators,
	RF_Public|RF_Transient|RF_MarkAsNative,
	UE_ARRAY_COUNT(Z_Construct_UEnum_VerySeriousProject_EStats_Statics::Enumerators),
	EEnumFlags::None,
	(uint8)UEnum::ECppForm::EnumClass,
	METADATA_PARAMS(UE_ARRAY_COUNT(Z_Construct_UEnum_VerySeriousProject_EStats_Statics::Enum_MetaDataParams), Z_Construct_UEnum_VerySeriousProject_EStats_Statics::Enum_MetaDataParams)
};
UEnum* Z_Construct_UEnum_VerySeriousProject_EStats()
{
	if (!Z_Registration_Info_UEnum_EStats.InnerSingleton)
	{
		UECodeGen_Private::ConstructUEnum(Z_Registration_Info_UEnum_EStats.InnerSingleton, Z_Construct_UEnum_VerySeriousProject_EStats_Statics::EnumParams);
	}
	return Z_Registration_Info_UEnum_EStats.InnerSingleton;
}
// End Enum EStats

// Begin ScriptStruct FBuff
static FStructRegistrationInfo Z_Registration_Info_UScriptStruct_Buff;
class UScriptStruct* FBuff::StaticStruct()
{
	if (!Z_Registration_Info_UScriptStruct_Buff.OuterSingleton)
	{
		Z_Registration_Info_UScriptStruct_Buff.OuterSingleton = GetStaticStruct(Z_Construct_UScriptStruct_FBuff, (UObject*)Z_Construct_UPackage__Script_VerySeriousProject(), TEXT("Buff"));
	}
	return Z_Registration_Info_UScriptStruct_Buff.OuterSingleton;
}
template<> VERYSERIOUSPROJECT_API UScriptStruct* StaticStruct<FBuff>()
{
	return FBuff::StaticStruct();
}
struct Z_Construct_UScriptStruct_FBuff_Statics
{
#if WITH_METADATA
	static constexpr UECodeGen_Private::FMetaDataPairParam Struct_MetaDataParams[] = {
		{ "BlueprintType", "true" },
		{ "ModuleRelativePath", "Public/BuffComponent.h" },
	};
	static constexpr UECodeGen_Private::FMetaDataPairParam NewProp_Name_MetaData[] = {
		{ "Category", "Buff" },
		{ "ModuleRelativePath", "Public/BuffComponent.h" },
	};
	static constexpr UECodeGen_Private::FMetaDataPairParam NewProp_Stat_MetaData[] = {
		{ "Category", "Buff" },
		{ "ModuleRelativePath", "Public/BuffComponent.h" },
	};
	static constexpr UECodeGen_Private::FMetaDataPairParam NewProp_bExpires_MetaData[] = {
		{ "Category", "Buff" },
		{ "ModuleRelativePath", "Public/BuffComponent.h" },
	};
	static constexpr UECodeGen_Private::FMetaDataPairParam NewProp_RemainingTime_MetaData[] = {
		{ "Category", "Buff" },
		{ "ModuleRelativePath", "Public/BuffComponent.h" },
	};
#endif // WITH_METADATA
	static const UECodeGen_Private::FStrPropertyParams NewProp_Name;
	static const UECodeGen_Private::FBytePropertyParams NewProp_Stat_Underlying;
	static const UECodeGen_Private::FEnumPropertyParams NewProp_Stat;
	static void NewProp_bExpires_SetBit(void* Obj);
	static const UECodeGen_Private::FBoolPropertyParams NewProp_bExpires;
	static const UECodeGen_Private::FFloatPropertyParams NewProp_RemainingTime;
	static const UECodeGen_Private::FPropertyParamsBase* const PropPointers[];
	static void* NewStructOps()
	{
		return (UScriptStruct::ICppStructOps*)new UScriptStruct::TCppStructOps<FBuff>();
	}
	static const UECodeGen_Private::FStructParams StructParams;
};
const UECodeGen_Private::FStrPropertyParams Z_Construct_UScriptStruct_FBuff_Statics::NewProp_Name = { "Name", nullptr, (EPropertyFlags)0x0010000000000005, UECodeGen_Private::EPropertyGenFlags::Str, RF_Public|RF_Transient|RF_MarkAsNative, nullptr, nullptr, 1, STRUCT_OFFSET(FBuff, Name), METADATA_PARAMS(UE_ARRAY_COUNT(NewProp_Name_MetaData), NewProp_Name_MetaData) };
const UECodeGen_Private::FBytePropertyParams Z_Construct_UScriptStruct_FBuff_Statics::NewProp_Stat_Underlying = { "UnderlyingType", nullptr, (EPropertyFlags)0x0000000000000000, UECodeGen_Private::EPropertyGenFlags::Byte, RF_Public|RF_Transient|RF_MarkAsNative, nullptr, nullptr, 1, 0, nullptr, METADATA_PARAMS(0, nullptr) };
const UECodeGen_Private::FEnumPropertyParams Z_Construct_UScriptStruct_FBuff_Statics::NewProp_Stat = { "Stat", nullptr, (EPropertyFlags)0x0010000000000005, UECodeGen_Private::EPropertyGenFlags::Enum, RF_Public|RF_Transient|RF_MarkAsNative, nullptr, nullptr, 1, STRUCT_OFFSET(FBuff, Stat), Z_Construct_UEnum_VerySeriousProject_EStats, METADATA_PARAMS(UE_ARRAY_COUNT(NewProp_Stat_MetaData), NewProp_Stat_MetaData) }; // 2103247463
void Z_Construct_UScriptStruct_FBuff_Statics::NewProp_bExpires_SetBit(void* Obj)
{
	((FBuff*)Obj)->bExpires = 1;
}
const UECodeGen_Private::FBoolPropertyParams Z_Construct_UScriptStruct_FBuff_Statics::NewProp_bExpires = { "bExpires", nullptr, (EPropertyFlags)0x0010000000000005, UECodeGen_Private::EPropertyGenFlags::Bool | UECodeGen_Private::EPropertyGenFlags::NativeBool, RF_Public|RF_Transient|RF_MarkAsNative, nullptr, nullptr, 1, sizeof(bool), sizeof(FBuff), &Z_Construct_UScriptStruct_FBuff_Statics::NewProp_bExpires_SetBit, METADATA_PARAMS(UE_ARRAY_COUNT(NewProp_bExpires_MetaData), NewProp_bExpires_MetaData) };
const UECodeGen_Private::FFloatPropertyParams Z_Construct_UScriptStruct_FBuff_Statics::NewProp_RemainingTime = { "RemainingTime", nullptr, (EPropertyFlags)0x0010000000000005, UECodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, nullptr, nullptr, 1, STRUCT_OFFSET(FBuff, RemainingTime), METADATA_PARAMS(UE_ARRAY_COUNT(NewProp_RemainingTime_MetaData), NewProp_RemainingTime_MetaData) };
const UECodeGen_Private::FPropertyParamsBase* const Z_Construct_UScriptStruct_FBuff_Statics::PropPointers[] = {
	(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UScriptStruct_FBuff_Statics::NewProp_Name,
	(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UScriptStruct_FBuff_Statics::NewProp_Stat_Underlying,
	(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UScriptStruct_FBuff_Statics::NewProp_Stat,
	(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UScriptStruct_FBuff_Statics::NewProp_bExpires,
	(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UScriptStruct_FBuff_Statics::NewProp_RemainingTime,
};
static_assert(UE_ARRAY_COUNT(Z_Construct_UScriptStruct_FBuff_Statics::PropPointers) < 2048);
const UECodeGen_Private::FStructParams Z_Construct_UScriptStruct_FBuff_Statics::StructParams = {
	(UObject* (*)())Z_Construct_UPackage__Script_VerySeriousProject,
	nullptr,
	&NewStructOps,
	"Buff",
	Z_Construct_UScriptStruct_FBuff_Statics::PropPointers,
	UE_ARRAY_COUNT(Z_Construct_UScriptStruct_FBuff_Statics::PropPointers),
	sizeof(FBuff),
	alignof(FBuff),
	RF_Public|RF_Transient|RF_MarkAsNative,
	EStructFlags(0x00000001),
	METADATA_PARAMS(UE_ARRAY_COUNT(Z_Construct_UScriptStruct_FBuff_Statics::Struct_MetaDataParams), Z_Construct_UScriptStruct_FBuff_Statics::Struct_MetaDataParams)
};
UScriptStruct* Z_Construct_UScriptStruct_FBuff()
{
	if (!Z_Registration_Info_UScriptStruct_Buff.InnerSingleton)
	{
		UECodeGen_Private::ConstructUScriptStruct(Z_Registration_Info_UScriptStruct_Buff.InnerSingleton, Z_Construct_UScriptStruct_FBuff_Statics::StructParams);
	}
	return Z_Registration_Info_UScriptStruct_Buff.InnerSingleton;
}
// End ScriptStruct FBuff

// Begin ScriptStruct FDebuff
static FStructRegistrationInfo Z_Registration_Info_UScriptStruct_Debuff;
class UScriptStruct* FDebuff::StaticStruct()
{
	if (!Z_Registration_Info_UScriptStruct_Debuff.OuterSingleton)
	{
		Z_Registration_Info_UScriptStruct_Debuff.OuterSingleton = GetStaticStruct(Z_Construct_UScriptStruct_FDebuff, (UObject*)Z_Construct_UPackage__Script_VerySeriousProject(), TEXT("Debuff"));
	}
	return Z_Registration_Info_UScriptStruct_Debuff.OuterSingleton;
}
template<> VERYSERIOUSPROJECT_API UScriptStruct* StaticStruct<FDebuff>()
{
	return FDebuff::StaticStruct();
}
struct Z_Construct_UScriptStruct_FDebuff_Statics
{
#if WITH_METADATA
	static constexpr UECodeGen_Private::FMetaDataPairParam Struct_MetaDataParams[] = {
		{ "BlueprintType", "true" },
		{ "ModuleRelativePath", "Public/BuffComponent.h" },
	};
	static constexpr UECodeGen_Private::FMetaDataPairParam NewProp_Name_MetaData[] = {
		{ "Category", "Debuff" },
		{ "ModuleRelativePath", "Public/BuffComponent.h" },
	};
	static constexpr UECodeGen_Private::FMetaDataPairParam NewProp_Stat_MetaData[] = {
		{ "Category", "Debuff" },
		{ "ModuleRelativePath", "Public/BuffComponent.h" },
	};
	static constexpr UECodeGen_Private::FMetaDataPairParam NewProp_bExpires_MetaData[] = {
		{ "Category", "Debuff" },
		{ "ModuleRelativePath", "Public/BuffComponent.h" },
	};
	static constexpr UECodeGen_Private::FMetaDataPairParam NewProp_RemainingTime_MetaData[] = {
		{ "Category", "Debuff" },
		{ "ModuleRelativePath", "Public/BuffComponent.h" },
	};
#endif // WITH_METADATA
	static const UECodeGen_Private::FStrPropertyParams NewProp_Name;
	static const UECodeGen_Private::FBytePropertyParams NewProp_Stat_Underlying;
	static const UECodeGen_Private::FEnumPropertyParams NewProp_Stat;
	static void NewProp_bExpires_SetBit(void* Obj);
	static const UECodeGen_Private::FBoolPropertyParams NewProp_bExpires;
	static const UECodeGen_Private::FFloatPropertyParams NewProp_RemainingTime;
	static const UECodeGen_Private::FPropertyParamsBase* const PropPointers[];
	static void* NewStructOps()
	{
		return (UScriptStruct::ICppStructOps*)new UScriptStruct::TCppStructOps<FDebuff>();
	}
	static const UECodeGen_Private::FStructParams StructParams;
};
const UECodeGen_Private::FStrPropertyParams Z_Construct_UScriptStruct_FDebuff_Statics::NewProp_Name = { "Name", nullptr, (EPropertyFlags)0x0010000000000005, UECodeGen_Private::EPropertyGenFlags::Str, RF_Public|RF_Transient|RF_MarkAsNative, nullptr, nullptr, 1, STRUCT_OFFSET(FDebuff, Name), METADATA_PARAMS(UE_ARRAY_COUNT(NewProp_Name_MetaData), NewProp_Name_MetaData) };
const UECodeGen_Private::FBytePropertyParams Z_Construct_UScriptStruct_FDebuff_Statics::NewProp_Stat_Underlying = { "UnderlyingType", nullptr, (EPropertyFlags)0x0000000000000000, UECodeGen_Private::EPropertyGenFlags::Byte, RF_Public|RF_Transient|RF_MarkAsNative, nullptr, nullptr, 1, 0, nullptr, METADATA_PARAMS(0, nullptr) };
const UECodeGen_Private::FEnumPropertyParams Z_Construct_UScriptStruct_FDebuff_Statics::NewProp_Stat = { "Stat", nullptr, (EPropertyFlags)0x0010000000000005, UECodeGen_Private::EPropertyGenFlags::Enum, RF_Public|RF_Transient|RF_MarkAsNative, nullptr, nullptr, 1, STRUCT_OFFSET(FDebuff, Stat), Z_Construct_UEnum_VerySeriousProject_EStats, METADATA_PARAMS(UE_ARRAY_COUNT(NewProp_Stat_MetaData), NewProp_Stat_MetaData) }; // 2103247463
void Z_Construct_UScriptStruct_FDebuff_Statics::NewProp_bExpires_SetBit(void* Obj)
{
	((FDebuff*)Obj)->bExpires = 1;
}
const UECodeGen_Private::FBoolPropertyParams Z_Construct_UScriptStruct_FDebuff_Statics::NewProp_bExpires = { "bExpires", nullptr, (EPropertyFlags)0x0010000000000005, UECodeGen_Private::EPropertyGenFlags::Bool | UECodeGen_Private::EPropertyGenFlags::NativeBool, RF_Public|RF_Transient|RF_MarkAsNative, nullptr, nullptr, 1, sizeof(bool), sizeof(FDebuff), &Z_Construct_UScriptStruct_FDebuff_Statics::NewProp_bExpires_SetBit, METADATA_PARAMS(UE_ARRAY_COUNT(NewProp_bExpires_MetaData), NewProp_bExpires_MetaData) };
const UECodeGen_Private::FFloatPropertyParams Z_Construct_UScriptStruct_FDebuff_Statics::NewProp_RemainingTime = { "RemainingTime", nullptr, (EPropertyFlags)0x0010000000000005, UECodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, nullptr, nullptr, 1, STRUCT_OFFSET(FDebuff, RemainingTime), METADATA_PARAMS(UE_ARRAY_COUNT(NewProp_RemainingTime_MetaData), NewProp_RemainingTime_MetaData) };
const UECodeGen_Private::FPropertyParamsBase* const Z_Construct_UScriptStruct_FDebuff_Statics::PropPointers[] = {
	(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UScriptStruct_FDebuff_Statics::NewProp_Name,
	(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UScriptStruct_FDebuff_Statics::NewProp_Stat_Underlying,
	(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UScriptStruct_FDebuff_Statics::NewProp_Stat,
	(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UScriptStruct_FDebuff_Statics::NewProp_bExpires,
	(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UScriptStruct_FDebuff_Statics::NewProp_RemainingTime,
};
static_assert(UE_ARRAY_COUNT(Z_Construct_UScriptStruct_FDebuff_Statics::PropPointers) < 2048);
const UECodeGen_Private::FStructParams Z_Construct_UScriptStruct_FDebuff_Statics::StructParams = {
	(UObject* (*)())Z_Construct_UPackage__Script_VerySeriousProject,
	nullptr,
	&NewStructOps,
	"Debuff",
	Z_Construct_UScriptStruct_FDebuff_Statics::PropPointers,
	UE_ARRAY_COUNT(Z_Construct_UScriptStruct_FDebuff_Statics::PropPointers),
	sizeof(FDebuff),
	alignof(FDebuff),
	RF_Public|RF_Transient|RF_MarkAsNative,
	EStructFlags(0x00000001),
	METADATA_PARAMS(UE_ARRAY_COUNT(Z_Construct_UScriptStruct_FDebuff_Statics::Struct_MetaDataParams), Z_Construct_UScriptStruct_FDebuff_Statics::Struct_MetaDataParams)
};
UScriptStruct* Z_Construct_UScriptStruct_FDebuff()
{
	if (!Z_Registration_Info_UScriptStruct_Debuff.InnerSingleton)
	{
		UECodeGen_Private::ConstructUScriptStruct(Z_Registration_Info_UScriptStruct_Debuff.InnerSingleton, Z_Construct_UScriptStruct_FDebuff_Statics::StructParams);
	}
	return Z_Registration_Info_UScriptStruct_Debuff.InnerSingleton;
}
// End ScriptStruct FDebuff

// Begin Class UBuffComponent
void UBuffComponent::StaticRegisterNativesUBuffComponent()
{
}
IMPLEMENT_CLASS_NO_AUTO_REGISTRATION(UBuffComponent);
UClass* Z_Construct_UClass_UBuffComponent_NoRegister()
{
	return UBuffComponent::StaticClass();
}
struct Z_Construct_UClass_UBuffComponent_Statics
{
#if WITH_METADATA
	static constexpr UECodeGen_Private::FMetaDataPairParam Class_MetaDataParams[] = {
		{ "BlueprintSpawnableComponent", "" },
		{ "ClassGroupNames", "Custom" },
		{ "IncludePath", "BuffComponent.h" },
		{ "ModuleRelativePath", "Public/BuffComponent.h" },
	};
	static constexpr UECodeGen_Private::FMetaDataPairParam NewProp_ActiveBuffs_MetaData[] = {
		{ "Category", "BuffComponent" },
		{ "ModuleRelativePath", "Public/BuffComponent.h" },
	};
	static constexpr UECodeGen_Private::FMetaDataPairParam NewProp_ActiveDebuffs_MetaData[] = {
		{ "Category", "BuffComponent" },
		{ "ModuleRelativePath", "Public/BuffComponent.h" },
	};
#endif // WITH_METADATA
	static const UECodeGen_Private::FStructPropertyParams NewProp_ActiveBuffs_Inner;
	static const UECodeGen_Private::FArrayPropertyParams NewProp_ActiveBuffs;
	static const UECodeGen_Private::FStructPropertyParams NewProp_ActiveDebuffs_Inner;
	static const UECodeGen_Private::FArrayPropertyParams NewProp_ActiveDebuffs;
	static const UECodeGen_Private::FPropertyParamsBase* const PropPointers[];
	static UObject* (*const DependentSingletons[])();
	static constexpr FCppClassTypeInfoStatic StaticCppClassTypeInfo = {
		TCppClassTypeTraits<UBuffComponent>::IsAbstract,
	};
	static const UECodeGen_Private::FClassParams ClassParams;
};
const UECodeGen_Private::FStructPropertyParams Z_Construct_UClass_UBuffComponent_Statics::NewProp_ActiveBuffs_Inner = { "ActiveBuffs", nullptr, (EPropertyFlags)0x0000000000000000, UECodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, nullptr, nullptr, 1, 0, Z_Construct_UScriptStruct_FBuff, METADATA_PARAMS(0, nullptr) }; // 3966428338
const UECodeGen_Private::FArrayPropertyParams Z_Construct_UClass_UBuffComponent_Statics::NewProp_ActiveBuffs = { "ActiveBuffs", nullptr, (EPropertyFlags)0x0010000000000005, UECodeGen_Private::EPropertyGenFlags::Array, RF_Public|RF_Transient|RF_MarkAsNative, nullptr, nullptr, 1, STRUCT_OFFSET(UBuffComponent, ActiveBuffs), EArrayPropertyFlags::None, METADATA_PARAMS(UE_ARRAY_COUNT(NewProp_ActiveBuffs_MetaData), NewProp_ActiveBuffs_MetaData) }; // 3966428338
const UECodeGen_Private::FStructPropertyParams Z_Construct_UClass_UBuffComponent_Statics::NewProp_ActiveDebuffs_Inner = { "ActiveDebuffs", nullptr, (EPropertyFlags)0x0000000000000000, UECodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, nullptr, nullptr, 1, 0, Z_Construct_UScriptStruct_FDebuff, METADATA_PARAMS(0, nullptr) }; // 3636035441
const UECodeGen_Private::FArrayPropertyParams Z_Construct_UClass_UBuffComponent_Statics::NewProp_ActiveDebuffs = { "ActiveDebuffs", nullptr, (EPropertyFlags)0x0010000000000005, UECodeGen_Private::EPropertyGenFlags::Array, RF_Public|RF_Transient|RF_MarkAsNative, nullptr, nullptr, 1, STRUCT_OFFSET(UBuffComponent, ActiveDebuffs), EArrayPropertyFlags::None, METADATA_PARAMS(UE_ARRAY_COUNT(NewProp_ActiveDebuffs_MetaData), NewProp_ActiveDebuffs_MetaData) }; // 3636035441
const UECodeGen_Private::FPropertyParamsBase* const Z_Construct_UClass_UBuffComponent_Statics::PropPointers[] = {
	(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_UBuffComponent_Statics::NewProp_ActiveBuffs_Inner,
	(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_UBuffComponent_Statics::NewProp_ActiveBuffs,
	(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_UBuffComponent_Statics::NewProp_ActiveDebuffs_Inner,
	(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_UBuffComponent_Statics::NewProp_ActiveDebuffs,
};
static_assert(UE_ARRAY_COUNT(Z_Construct_UClass_UBuffComponent_Statics::PropPointers) < 2048);
UObject* (*const Z_Construct_UClass_UBuffComponent_Statics::DependentSingletons[])() = {
	(UObject* (*)())Z_Construct_UClass_UActorComponent,
	(UObject* (*)())Z_Construct_UPackage__Script_VerySeriousProject,
};
static_assert(UE_ARRAY_COUNT(Z_Construct_UClass_UBuffComponent_Statics::DependentSingletons) < 16);
const UECodeGen_Private::FClassParams Z_Construct_UClass_UBuffComponent_Statics::ClassParams = {
	&UBuffComponent::StaticClass,
	"Engine",
	&StaticCppClassTypeInfo,
	DependentSingletons,
	nullptr,
	Z_Construct_UClass_UBuffComponent_Statics::PropPointers,
	nullptr,
	UE_ARRAY_COUNT(DependentSingletons),
	0,
	UE_ARRAY_COUNT(Z_Construct_UClass_UBuffComponent_Statics::PropPointers),
	0,
	0x00B000A4u,
	METADATA_PARAMS(UE_ARRAY_COUNT(Z_Construct_UClass_UBuffComponent_Statics::Class_MetaDataParams), Z_Construct_UClass_UBuffComponent_Statics::Class_MetaDataParams)
};
UClass* Z_Construct_UClass_UBuffComponent()
{
	if (!Z_Registration_Info_UClass_UBuffComponent.OuterSingleton)
	{
		UECodeGen_Private::ConstructUClass(Z_Registration_Info_UClass_UBuffComponent.OuterSingleton, Z_Construct_UClass_UBuffComponent_Statics::ClassParams);
	}
	return Z_Registration_Info_UClass_UBuffComponent.OuterSingleton;
}
template<> VERYSERIOUSPROJECT_API UClass* StaticClass<UBuffComponent>()
{
	return UBuffComponent::StaticClass();
}
DEFINE_VTABLE_PTR_HELPER_CTOR(UBuffComponent);
UBuffComponent::~UBuffComponent() {}
// End Class UBuffComponent

// Begin Registration
struct Z_CompiledInDeferFile_FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_Public_BuffComponent_h_Statics
{
	static constexpr FEnumRegisterCompiledInInfo EnumInfo[] = {
		{ EStats_StaticEnum, TEXT("EStats"), &Z_Registration_Info_UEnum_EStats, CONSTRUCT_RELOAD_VERSION_INFO(FEnumReloadVersionInfo, 2103247463U) },
	};
	static constexpr FStructRegisterCompiledInInfo ScriptStructInfo[] = {
		{ FBuff::StaticStruct, Z_Construct_UScriptStruct_FBuff_Statics::NewStructOps, TEXT("Buff"), &Z_Registration_Info_UScriptStruct_Buff, CONSTRUCT_RELOAD_VERSION_INFO(FStructReloadVersionInfo, sizeof(FBuff), 3966428338U) },
		{ FDebuff::StaticStruct, Z_Construct_UScriptStruct_FDebuff_Statics::NewStructOps, TEXT("Debuff"), &Z_Registration_Info_UScriptStruct_Debuff, CONSTRUCT_RELOAD_VERSION_INFO(FStructReloadVersionInfo, sizeof(FDebuff), 3636035441U) },
	};
	static constexpr FClassRegisterCompiledInInfo ClassInfo[] = {
		{ Z_Construct_UClass_UBuffComponent, UBuffComponent::StaticClass, TEXT("UBuffComponent"), &Z_Registration_Info_UClass_UBuffComponent, CONSTRUCT_RELOAD_VERSION_INFO(FClassReloadVersionInfo, sizeof(UBuffComponent), 558343357U) },
	};
};
static FRegisterCompiledInInfo Z_CompiledInDeferFile_FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_Public_BuffComponent_h_3869936929(TEXT("/Script/VerySeriousProject"),
	Z_CompiledInDeferFile_FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_Public_BuffComponent_h_Statics::ClassInfo, UE_ARRAY_COUNT(Z_CompiledInDeferFile_FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_Public_BuffComponent_h_Statics::ClassInfo),
	Z_CompiledInDeferFile_FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_Public_BuffComponent_h_Statics::ScriptStructInfo, UE_ARRAY_COUNT(Z_CompiledInDeferFile_FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_Public_BuffComponent_h_Statics::ScriptStructInfo),
	Z_CompiledInDeferFile_FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_Public_BuffComponent_h_Statics::EnumInfo, UE_ARRAY_COUNT(Z_CompiledInDeferFile_FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_Public_BuffComponent_h_Statics::EnumInfo));
// End Registration
PRAGMA_ENABLE_DEPRECATION_WARNINGS
