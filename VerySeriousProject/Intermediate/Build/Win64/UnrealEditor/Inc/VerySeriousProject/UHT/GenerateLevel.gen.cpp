// Copyright Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "UObject/GeneratedCppIncludes.h"
#include "VerySeriousProject/GenerateLevel.h"
PRAGMA_DISABLE_DEPRECATION_WARNINGS
void EmptyLinkFunctionForGeneratedCodeGenerateLevel() {}

// Begin Cross Module References
ENGINE_API UClass* Z_Construct_UClass_AActor();
ENGINE_API UClass* Z_Construct_UClass_UStaticMesh_NoRegister();
UPackage* Z_Construct_UPackage__Script_VerySeriousProject();
VERYSERIOUSPROJECT_API UClass* Z_Construct_UClass_AGenerateLevel();
VERYSERIOUSPROJECT_API UClass* Z_Construct_UClass_AGenerateLevel_NoRegister();
// End Cross Module References

// Begin Class AGenerateLevel
void AGenerateLevel::StaticRegisterNativesAGenerateLevel()
{
}
IMPLEMENT_CLASS_NO_AUTO_REGISTRATION(AGenerateLevel);
UClass* Z_Construct_UClass_AGenerateLevel_NoRegister()
{
	return AGenerateLevel::StaticClass();
}
struct Z_Construct_UClass_AGenerateLevel_Statics
{
#if WITH_METADATA
	static constexpr UECodeGen_Private::FMetaDataPairParam Class_MetaDataParams[] = {
		{ "IncludePath", "GenerateLevel.h" },
		{ "ModuleRelativePath", "GenerateLevel.h" },
	};
	static constexpr UECodeGen_Private::FMetaDataPairParam NewProp_CubeMesh_MetaData[] = {
		{ "ModuleRelativePath", "GenerateLevel.h" },
	};
#endif // WITH_METADATA
	static const UECodeGen_Private::FObjectPropertyParams NewProp_CubeMesh;
	static const UECodeGen_Private::FPropertyParamsBase* const PropPointers[];
	static UObject* (*const DependentSingletons[])();
	static constexpr FCppClassTypeInfoStatic StaticCppClassTypeInfo = {
		TCppClassTypeTraits<AGenerateLevel>::IsAbstract,
	};
	static const UECodeGen_Private::FClassParams ClassParams;
};
const UECodeGen_Private::FObjectPropertyParams Z_Construct_UClass_AGenerateLevel_Statics::NewProp_CubeMesh = { "CubeMesh", nullptr, (EPropertyFlags)0x0040000000000000, UECodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, nullptr, nullptr, 1, STRUCT_OFFSET(AGenerateLevel, CubeMesh), Z_Construct_UClass_UStaticMesh_NoRegister, METADATA_PARAMS(UE_ARRAY_COUNT(NewProp_CubeMesh_MetaData), NewProp_CubeMesh_MetaData) };
const UECodeGen_Private::FPropertyParamsBase* const Z_Construct_UClass_AGenerateLevel_Statics::PropPointers[] = {
	(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AGenerateLevel_Statics::NewProp_CubeMesh,
};
static_assert(UE_ARRAY_COUNT(Z_Construct_UClass_AGenerateLevel_Statics::PropPointers) < 2048);
UObject* (*const Z_Construct_UClass_AGenerateLevel_Statics::DependentSingletons[])() = {
	(UObject* (*)())Z_Construct_UClass_AActor,
	(UObject* (*)())Z_Construct_UPackage__Script_VerySeriousProject,
};
static_assert(UE_ARRAY_COUNT(Z_Construct_UClass_AGenerateLevel_Statics::DependentSingletons) < 16);
const UECodeGen_Private::FClassParams Z_Construct_UClass_AGenerateLevel_Statics::ClassParams = {
	&AGenerateLevel::StaticClass,
	"Engine",
	&StaticCppClassTypeInfo,
	DependentSingletons,
	nullptr,
	Z_Construct_UClass_AGenerateLevel_Statics::PropPointers,
	nullptr,
	UE_ARRAY_COUNT(DependentSingletons),
	0,
	UE_ARRAY_COUNT(Z_Construct_UClass_AGenerateLevel_Statics::PropPointers),
	0,
	0x009000A4u,
	METADATA_PARAMS(UE_ARRAY_COUNT(Z_Construct_UClass_AGenerateLevel_Statics::Class_MetaDataParams), Z_Construct_UClass_AGenerateLevel_Statics::Class_MetaDataParams)
};
UClass* Z_Construct_UClass_AGenerateLevel()
{
	if (!Z_Registration_Info_UClass_AGenerateLevel.OuterSingleton)
	{
		UECodeGen_Private::ConstructUClass(Z_Registration_Info_UClass_AGenerateLevel.OuterSingleton, Z_Construct_UClass_AGenerateLevel_Statics::ClassParams);
	}
	return Z_Registration_Info_UClass_AGenerateLevel.OuterSingleton;
}
template<> VERYSERIOUSPROJECT_API UClass* StaticClass<AGenerateLevel>()
{
	return AGenerateLevel::StaticClass();
}
DEFINE_VTABLE_PTR_HELPER_CTOR(AGenerateLevel);
AGenerateLevel::~AGenerateLevel() {}
// End Class AGenerateLevel

// Begin Registration
struct Z_CompiledInDeferFile_FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_GenerateLevel_h_Statics
{
	static constexpr FClassRegisterCompiledInInfo ClassInfo[] = {
		{ Z_Construct_UClass_AGenerateLevel, AGenerateLevel::StaticClass, TEXT("AGenerateLevel"), &Z_Registration_Info_UClass_AGenerateLevel, CONSTRUCT_RELOAD_VERSION_INFO(FClassReloadVersionInfo, sizeof(AGenerateLevel), 953950849U) },
	};
};
static FRegisterCompiledInInfo Z_CompiledInDeferFile_FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_GenerateLevel_h_3464520571(TEXT("/Script/VerySeriousProject"),
	Z_CompiledInDeferFile_FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_GenerateLevel_h_Statics::ClassInfo, UE_ARRAY_COUNT(Z_CompiledInDeferFile_FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_GenerateLevel_h_Statics::ClassInfo),
	nullptr, 0,
	nullptr, 0);
// End Registration
PRAGMA_ENABLE_DEPRECATION_WARNINGS
