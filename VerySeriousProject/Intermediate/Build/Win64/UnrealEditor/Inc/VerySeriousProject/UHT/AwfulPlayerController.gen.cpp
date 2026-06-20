// Copyright Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "UObject/GeneratedCppIncludes.h"
#include "VerySeriousProject/Public/AwfulPlayerController.h"
PRAGMA_DISABLE_DEPRECATION_WARNINGS
void EmptyLinkFunctionForGeneratedCodeAwfulPlayerController() {}

// Begin Cross Module References
ENGINE_API UClass* Z_Construct_UClass_APlayerController();
UPackage* Z_Construct_UPackage__Script_VerySeriousProject();
VERYSERIOUSPROJECT_API UClass* Z_Construct_UClass_AAwfulPlayerController();
VERYSERIOUSPROJECT_API UClass* Z_Construct_UClass_AAwfulPlayerController_NoRegister();
// End Cross Module References

// Begin Class AAwfulPlayerController
void AAwfulPlayerController::StaticRegisterNativesAAwfulPlayerController()
{
}
IMPLEMENT_CLASS_NO_AUTO_REGISTRATION(AAwfulPlayerController);
UClass* Z_Construct_UClass_AAwfulPlayerController_NoRegister()
{
	return AAwfulPlayerController::StaticClass();
}
struct Z_Construct_UClass_AAwfulPlayerController_Statics
{
#if WITH_METADATA
	static constexpr UECodeGen_Private::FMetaDataPairParam Class_MetaDataParams[] = {
#if !UE_BUILD_SHIPPING
		{ "Comment", "/**\n * \n */" },
#endif
		{ "HideCategories", "Collision Rendering Transformation" },
		{ "IncludePath", "AwfulPlayerController.h" },
		{ "ModuleRelativePath", "Public/AwfulPlayerController.h" },
	};
#endif // WITH_METADATA
	static UObject* (*const DependentSingletons[])();
	static constexpr FCppClassTypeInfoStatic StaticCppClassTypeInfo = {
		TCppClassTypeTraits<AAwfulPlayerController>::IsAbstract,
	};
	static const UECodeGen_Private::FClassParams ClassParams;
};
UObject* (*const Z_Construct_UClass_AAwfulPlayerController_Statics::DependentSingletons[])() = {
	(UObject* (*)())Z_Construct_UClass_APlayerController,
	(UObject* (*)())Z_Construct_UPackage__Script_VerySeriousProject,
};
static_assert(UE_ARRAY_COUNT(Z_Construct_UClass_AAwfulPlayerController_Statics::DependentSingletons) < 16);
const UECodeGen_Private::FClassParams Z_Construct_UClass_AAwfulPlayerController_Statics::ClassParams = {
	&AAwfulPlayerController::StaticClass,
	"Game",
	&StaticCppClassTypeInfo,
	DependentSingletons,
	nullptr,
	nullptr,
	nullptr,
	UE_ARRAY_COUNT(DependentSingletons),
	0,
	0,
	0,
	0x009002A4u,
	METADATA_PARAMS(UE_ARRAY_COUNT(Z_Construct_UClass_AAwfulPlayerController_Statics::Class_MetaDataParams), Z_Construct_UClass_AAwfulPlayerController_Statics::Class_MetaDataParams)
};
UClass* Z_Construct_UClass_AAwfulPlayerController()
{
	if (!Z_Registration_Info_UClass_AAwfulPlayerController.OuterSingleton)
	{
		UECodeGen_Private::ConstructUClass(Z_Registration_Info_UClass_AAwfulPlayerController.OuterSingleton, Z_Construct_UClass_AAwfulPlayerController_Statics::ClassParams);
	}
	return Z_Registration_Info_UClass_AAwfulPlayerController.OuterSingleton;
}
template<> VERYSERIOUSPROJECT_API UClass* StaticClass<AAwfulPlayerController>()
{
	return AAwfulPlayerController::StaticClass();
}
AAwfulPlayerController::AAwfulPlayerController(const FObjectInitializer& ObjectInitializer) : Super(ObjectInitializer) {}
DEFINE_VTABLE_PTR_HELPER_CTOR(AAwfulPlayerController);
AAwfulPlayerController::~AAwfulPlayerController() {}
// End Class AAwfulPlayerController

// Begin Registration
struct Z_CompiledInDeferFile_FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_Public_AwfulPlayerController_h_Statics
{
	static constexpr FClassRegisterCompiledInInfo ClassInfo[] = {
		{ Z_Construct_UClass_AAwfulPlayerController, AAwfulPlayerController::StaticClass, TEXT("AAwfulPlayerController"), &Z_Registration_Info_UClass_AAwfulPlayerController, CONSTRUCT_RELOAD_VERSION_INFO(FClassReloadVersionInfo, sizeof(AAwfulPlayerController), 3765335731U) },
	};
};
static FRegisterCompiledInInfo Z_CompiledInDeferFile_FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_Public_AwfulPlayerController_h_1626048803(TEXT("/Script/VerySeriousProject"),
	Z_CompiledInDeferFile_FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_Public_AwfulPlayerController_h_Statics::ClassInfo, UE_ARRAY_COUNT(Z_CompiledInDeferFile_FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_Public_AwfulPlayerController_h_Statics::ClassInfo),
	nullptr, 0,
	nullptr, 0);
// End Registration
PRAGMA_ENABLE_DEPRECATION_WARNINGS
