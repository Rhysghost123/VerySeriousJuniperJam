// Copyright Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "UObject/GeneratedCppIncludes.h"
#include "VerySeriousProject/Public/BuffData.h"
PRAGMA_DISABLE_DEPRECATION_WARNINGS
void EmptyLinkFunctionForGeneratedCodeBuffData() {}

// Begin Cross Module References
ENGINE_API UClass* Z_Construct_UClass_UDataAsset();
UPackage* Z_Construct_UPackage__Script_VerySeriousProject();
VERYSERIOUSPROJECT_API UClass* Z_Construct_UClass_UBuffData();
VERYSERIOUSPROJECT_API UClass* Z_Construct_UClass_UBuffData_NoRegister();
VERYSERIOUSPROJECT_API UEnum* Z_Construct_UEnum_VerySeriousProject_EStats();
// End Cross Module References

// Begin Class UBuffData
void UBuffData::StaticRegisterNativesUBuffData()
{
}
IMPLEMENT_CLASS_NO_AUTO_REGISTRATION(UBuffData);
UClass* Z_Construct_UClass_UBuffData_NoRegister()
{
	return UBuffData::StaticClass();
}
struct Z_Construct_UClass_UBuffData_Statics
{
#if WITH_METADATA
	static constexpr UECodeGen_Private::FMetaDataPairParam Class_MetaDataParams[] = {
		{ "BlueprintType", "true" },
		{ "IncludePath", "BuffData.h" },
		{ "ModuleRelativePath", "Public/BuffData.h" },
	};
	static constexpr UECodeGen_Private::FMetaDataPairParam NewProp_Name_MetaData[] = {
		{ "Category", "BuffData" },
		{ "ModuleRelativePath", "Public/BuffData.h" },
	};
	static constexpr UECodeGen_Private::FMetaDataPairParam NewProp_Stat_MetaData[] = {
		{ "Category", "BuffData" },
		{ "ModuleRelativePath", "Public/BuffData.h" },
	};
	static constexpr UECodeGen_Private::FMetaDataPairParam NewProp_Duration_MetaData[] = {
		{ "Category", "BuffData" },
		{ "ModuleRelativePath", "Public/BuffData.h" },
	};
#endif // WITH_METADATA
	static const UECodeGen_Private::FStrPropertyParams NewProp_Name;
	static const UECodeGen_Private::FBytePropertyParams NewProp_Stat_Underlying;
	static const UECodeGen_Private::FEnumPropertyParams NewProp_Stat;
	static const UECodeGen_Private::FFloatPropertyParams NewProp_Duration;
	static const UECodeGen_Private::FPropertyParamsBase* const PropPointers[];
	static UObject* (*const DependentSingletons[])();
	static constexpr FCppClassTypeInfoStatic StaticCppClassTypeInfo = {
		TCppClassTypeTraits<UBuffData>::IsAbstract,
	};
	static const UECodeGen_Private::FClassParams ClassParams;
};
const UECodeGen_Private::FStrPropertyParams Z_Construct_UClass_UBuffData_Statics::NewProp_Name = { "Name", nullptr, (EPropertyFlags)0x0010000000000001, UECodeGen_Private::EPropertyGenFlags::Str, RF_Public|RF_Transient|RF_MarkAsNative, nullptr, nullptr, 1, STRUCT_OFFSET(UBuffData, Name), METADATA_PARAMS(UE_ARRAY_COUNT(NewProp_Name_MetaData), NewProp_Name_MetaData) };
const UECodeGen_Private::FBytePropertyParams Z_Construct_UClass_UBuffData_Statics::NewProp_Stat_Underlying = { "UnderlyingType", nullptr, (EPropertyFlags)0x0000000000000000, UECodeGen_Private::EPropertyGenFlags::Byte, RF_Public|RF_Transient|RF_MarkAsNative, nullptr, nullptr, 1, 0, nullptr, METADATA_PARAMS(0, nullptr) };
const UECodeGen_Private::FEnumPropertyParams Z_Construct_UClass_UBuffData_Statics::NewProp_Stat = { "Stat", nullptr, (EPropertyFlags)0x0010000000000001, UECodeGen_Private::EPropertyGenFlags::Enum, RF_Public|RF_Transient|RF_MarkAsNative, nullptr, nullptr, 1, STRUCT_OFFSET(UBuffData, Stat), Z_Construct_UEnum_VerySeriousProject_EStats, METADATA_PARAMS(UE_ARRAY_COUNT(NewProp_Stat_MetaData), NewProp_Stat_MetaData) }; // 2103247463
const UECodeGen_Private::FFloatPropertyParams Z_Construct_UClass_UBuffData_Statics::NewProp_Duration = { "Duration", nullptr, (EPropertyFlags)0x0010000000000001, UECodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, nullptr, nullptr, 1, STRUCT_OFFSET(UBuffData, Duration), METADATA_PARAMS(UE_ARRAY_COUNT(NewProp_Duration_MetaData), NewProp_Duration_MetaData) };
const UECodeGen_Private::FPropertyParamsBase* const Z_Construct_UClass_UBuffData_Statics::PropPointers[] = {
	(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_UBuffData_Statics::NewProp_Name,
	(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_UBuffData_Statics::NewProp_Stat_Underlying,
	(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_UBuffData_Statics::NewProp_Stat,
	(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_UBuffData_Statics::NewProp_Duration,
};
static_assert(UE_ARRAY_COUNT(Z_Construct_UClass_UBuffData_Statics::PropPointers) < 2048);
UObject* (*const Z_Construct_UClass_UBuffData_Statics::DependentSingletons[])() = {
	(UObject* (*)())Z_Construct_UClass_UDataAsset,
	(UObject* (*)())Z_Construct_UPackage__Script_VerySeriousProject,
};
static_assert(UE_ARRAY_COUNT(Z_Construct_UClass_UBuffData_Statics::DependentSingletons) < 16);
const UECodeGen_Private::FClassParams Z_Construct_UClass_UBuffData_Statics::ClassParams = {
	&UBuffData::StaticClass,
	nullptr,
	&StaticCppClassTypeInfo,
	DependentSingletons,
	nullptr,
	Z_Construct_UClass_UBuffData_Statics::PropPointers,
	nullptr,
	UE_ARRAY_COUNT(DependentSingletons),
	0,
	UE_ARRAY_COUNT(Z_Construct_UClass_UBuffData_Statics::PropPointers),
	0,
	0x000000A0u,
	METADATA_PARAMS(UE_ARRAY_COUNT(Z_Construct_UClass_UBuffData_Statics::Class_MetaDataParams), Z_Construct_UClass_UBuffData_Statics::Class_MetaDataParams)
};
UClass* Z_Construct_UClass_UBuffData()
{
	if (!Z_Registration_Info_UClass_UBuffData.OuterSingleton)
	{
		UECodeGen_Private::ConstructUClass(Z_Registration_Info_UClass_UBuffData.OuterSingleton, Z_Construct_UClass_UBuffData_Statics::ClassParams);
	}
	return Z_Registration_Info_UClass_UBuffData.OuterSingleton;
}
template<> VERYSERIOUSPROJECT_API UClass* StaticClass<UBuffData>()
{
	return UBuffData::StaticClass();
}
UBuffData::UBuffData(const FObjectInitializer& ObjectInitializer) : Super(ObjectInitializer) {}
DEFINE_VTABLE_PTR_HELPER_CTOR(UBuffData);
UBuffData::~UBuffData() {}
// End Class UBuffData

// Begin Registration
struct Z_CompiledInDeferFile_FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_Public_BuffData_h_Statics
{
	static constexpr FClassRegisterCompiledInInfo ClassInfo[] = {
		{ Z_Construct_UClass_UBuffData, UBuffData::StaticClass, TEXT("UBuffData"), &Z_Registration_Info_UClass_UBuffData, CONSTRUCT_RELOAD_VERSION_INFO(FClassReloadVersionInfo, sizeof(UBuffData), 10169519U) },
	};
};
static FRegisterCompiledInInfo Z_CompiledInDeferFile_FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_Public_BuffData_h_1628729241(TEXT("/Script/VerySeriousProject"),
	Z_CompiledInDeferFile_FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_Public_BuffData_h_Statics::ClassInfo, UE_ARRAY_COUNT(Z_CompiledInDeferFile_FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_Public_BuffData_h_Statics::ClassInfo),
	nullptr, 0,
	nullptr, 0);
// End Registration
PRAGMA_ENABLE_DEPRECATION_WARNINGS
